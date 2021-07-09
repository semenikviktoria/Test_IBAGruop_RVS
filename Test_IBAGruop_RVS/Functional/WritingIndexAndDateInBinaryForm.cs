using System.Collections.Generic;
using System.IO;
using Test_IBAGruop_RVS.Models;


namespace Test_IBAGruop_RVS.Functional
{
    internal static class WritingIndexAndDateInBinaryForm
    {
        internal static void WriteBinary(string pathFale, FixationSystemData systemDatas, int indexDataBin)
        {
            indexDataBin++;
            using (BinaryWriter writerBinary = new BinaryWriter(File.Open(pathFale, FileMode.Append)))
            {
                writerBinary.Write(systemDatas.DateTime.ToShortDateString() + " " + string.Format("{0:d6}", indexDataBin));

            }
        }
    }
}
