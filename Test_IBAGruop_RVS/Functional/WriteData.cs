using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Test_IBAGruop_RVS.Models;

namespace Test_IBAGruop_RVS.Functional
{
    internal static class WriteData
    {
        internal static void WriteInDataBase(FixationSystemData fixation)
        {
            int indexData = 0;
            bool stopSearchFile = false;
            string nameDay = "-" + PathsToFileLocation.stringRepresentationOFTheDay[fixation.DateTime.Day];
            string directoryMonth = PathsToFileLocation.MainDirectiry + @"\" + fixation.DateTime.Month + @"\";
            string pathTextFile = directoryMonth + fixation.DateTime.Day + nameDay + "-Data-1.txt";
            string pathBinaryFile;
            string numberFile = "4";
 
            if (File.Exists(pathTextFile))
            {
                foreach (string str in Directory.GetFiles(directoryMonth, "*.txt"))
                {
                    if (str.Contains(fixation.DateTime.Day.ToString() + nameDay + "-Data-"))
                    {
                        numberFile = str;
                        stopSearchFile = true;
                    }
                    else
                    {
                        if (stopSearchFile)
                        {
                            break;
                        }
                    }
                }
                if (!FileCheck.CheckTheMaxFileSize(numberFile, out indexData))
                {
                    WritingCompleteLineOfDataToTextFile.WriteData(numberFile, fixation, indexData);

                    WritingIndexAndDateInBinaryForm.WriteBinary(PathsToFileLocation.MainDirectiry + @"\" + fixation.DateTime.Month +
                @"\" + fixation.DateTime.Day + nameDay + "-Index-" + numberFile.Substring(numberFile.Length - 5, 1) + ".dat", fixation, indexData);
                }
                else
                {
                    PathsToFileLocation.CreatTextFile(directoryMonth, fixation.DateTime.Day.ToString() + nameDay, numberFile.Substring(numberFile.Length - 5, 1), out pathTextFile);
                    PathsToFileLocation.CreatDinaryFile(directoryMonth, fixation.DateTime.Day.ToString() + nameDay, numberFile.Substring(numberFile.Length - 5, 1), out pathBinaryFile);
                    WritingCompleteLineOfDataToTextFile.WriteData(pathTextFile, fixation, 0);
                    WritingIndexAndDateInBinaryForm.WriteBinary(pathBinaryFile, fixation, 0);
                }

            }
            else
            {

                PathsToFileLocation.CreatTextFile(directoryMonth, fixation.DateTime.Day.ToString() + nameDay, "0", out pathTextFile);
                PathsToFileLocation.CreatDinaryFile(directoryMonth, fixation.DateTime.Day.ToString() + nameDay, "0", out pathBinaryFile);
                WritingCompleteLineOfDataToTextFile.WriteData(pathTextFile, fixation, 0);
                WritingIndexAndDateInBinaryForm.WriteBinary(pathBinaryFile, fixation, 0);


            }


        }
    }
}
