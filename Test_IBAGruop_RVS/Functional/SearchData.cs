using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Test_IBAGruop_RVS.Models;

namespace Test_IBAGruop_RVS.Functional
{
    internal static class SearchData
    {
        internal static List<FixationSystemData> SearchByDataAndSpeed(FixationSystemData fixation, string soughtSpeed)
        {
            bool searchExitFlag = false;
            string nameDay = "-" + PathsToFileLocation.stringRepresentationOFTheDay[fixation.DateTime.Day];
            string directoryMonth = PathsToFileLocation.MainDirectiry + @"\" + fixation.DateTime.Month + @"\";
            string pathFile = directoryMonth + fixation.DateTime.Day + nameDay + "-Index-1.dat";
            string numberFile;
            List<FixationSystemData> listFixations = new List<FixationSystemData>();

            if (File.Exists(pathFile))
            {
                foreach (string str in Directory.GetFiles(directoryMonth, "*.dat"))
                {
                    if (str.Contains(fixation.DateTime.Day.ToString() + nameDay + "-Index-"))
                    {
                        numberFile = str;
                        List<string> indexList = new List<string>();
                        indexList = SertIndex(numberFile, fixation.DateTime.ToShortDateString().ToString());
                        if (indexList != null)
                        {
                            SertDAtaONIndex(directoryMonth + fixation.DateTime.Day +
                               nameDay + "-Data-" + numberFile.Substring(numberFile.Length - 5, 1) + ".txt",
                                 indexList, soughtSpeed, ref listFixations);
                        }
                        else
                        {
                            return null;
                        }
                        searchExitFlag = true;
                    }
                    else
                    {
                        if (searchExitFlag)
                        {
                            break;
                        }
                    }
                }
                if(soughtSpeed == null)
                {
                    List<FixationSystemData> fixationsMimAndMax = new List<FixationSystemData>();
                    fixationsMimAndMax.Add(listFixations.Min());
                    fixationsMimAndMax.Add(listFixations.Max());
                    return fixationsMimAndMax;
                }
                return listFixations;
            }
            else
            {
                return null;
            }
        }
        private static List<string> SertIndex(string pathFileReader, string searchData)
        {
            List<string> indexList = new List<string>();
            using (BinaryReader readerBinFile = new BinaryReader(File.Open(pathFileReader, FileMode.Open)))
            {

                while (readerBinFile.PeekChar() > -1)
                {
                    string data = readerBinFile.ReadString();
                    if (data.Contains(searchData))
                    {
                        indexList.Add(data.Substring((searchData + " ").Length));
                    }
                }
            }
            if (indexList.Count != 0)
            {
                return indexList;
            }
            else
            {
                return null;
            }
        }
        private static void SertDAtaONIndex(string pathFileReader, List<string> indexList, string comparableSpeed, ref List<FixationSystemData> listSystemData)
        {
            using (FileStream fstream = File.OpenRead(pathFileReader))
            {
                if (comparableSpeed != null)
                {
                    foreach (string ind in indexList)
                    {
                        FixationSystemData fixation = new FixationSystemData(new DateTime(),
               ValidationOfInputData.CarNumberDefault, ValidationOfInputData.SeepdDefault);
                        StreamSearch(fstream,ref fixation, ind);

                        if (DataFiltering.FilteringBySpeed( fixation, comparableSpeed))
                        {
                            listSystemData.Add(fixation);
                        }
                    }
                }
                else
                {
                    foreach (string ind in indexList)
                    {
                        FixationSystemData fixation = new FixationSystemData(new DateTime(),
                ValidationOfInputData.CarNumberDefault, ValidationOfInputData.SeepdDefault);
                        StreamSearch(fstream, ref fixation, ind);
                        listSystemData.Add(fixation);
                    }
                }
            }
        }
        private static void StreamSearch(FileStream fStream, ref FixationSystemData fixation, string indexStream )
        {
            long startingPosition = long.Parse(indexStream) * 43;

            byte[] dataTime = new byte[19];
            byte[] carNumber = new byte[9];
            byte[] travelSpeed = new byte[5];

            fStream.Seek(startingPosition - 36, SeekOrigin.Begin);
            fStream.Read(dataTime, 0, dataTime.Length);
            fixation.DateTime = DateTime.Parse(System.Text.Encoding.Default.GetString(dataTime));
            fStream.Seek(1, SeekOrigin.Current);
            fStream.Read(carNumber, 0, carNumber.Length);
            fixation.CarNumber = System.Text.Encoding.Default.GetString(carNumber);
            fStream.Seek(1, SeekOrigin.Current);
            fStream.Read(travelSpeed, 0, travelSpeed.Length);
            if (travelSpeed[0] == ' ')
            {
                fixation.TravelSpeed = System.Text.Encoding.Default.GetString(travelSpeed[1..4]);
            }
            else
            {
                fixation.TravelSpeed = System.Text.Encoding.Default.GetString(travelSpeed);
            }
            dataTime = null;
            carNumber = null;
            travelSpeed = null;
        }
    }
}
