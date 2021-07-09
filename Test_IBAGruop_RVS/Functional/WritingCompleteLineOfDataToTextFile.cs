using System.IO;
using Test_IBAGruop_RVS.Models;


namespace Test_IBAGruop_RVS.Functional
{
    internal static class WritingCompleteLineOfDataToTextFile
    { 
        internal static void WriteData(string pathFale, FixationSystemData systemDatas, int indexData)
        {
            using (FileStream fstreamWrite = new FileStream(pathFale, FileMode.OpenOrCreate))
            {
                if (fstreamWrite.Length != 0)
                {
                    fstreamWrite.Seek(-6, SeekOrigin.End);
                }
                indexData++;
                string temp = systemDatas.TravelSpeed.Length == 4 ? " " + systemDatas.TravelSpeed : systemDatas.TravelSpeed;
                byte[] array = System.Text.Encoding.Default.GetBytes(string.Format("{0:d6}", indexData) + " " +
                    systemDatas.DateTime.ToString() + " " + systemDatas.CarNumber +" " + temp);
                fstreamWrite.Write(array, 0, array.Length);
                array = null;

                byte[] arrayByte = System.Text.Encoding.Default.GetBytes("\n" + string.Format("{0:d6}", indexData));
                fstreamWrite.Write(arrayByte, 0, arrayByte.Length);
                arrayByte = null;
            }
        }
    }
}
