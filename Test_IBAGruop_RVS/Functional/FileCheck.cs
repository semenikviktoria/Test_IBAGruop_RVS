using System.IO;

namespace Test_IBAGruop_RVS.Functional
{
    internal static class FileCheck
    {
        internal static bool CheckTheMaxFileSize(string pathFale, out int index )
        {
            using (FileStream fstream = File.OpenRead(pathFale))
            {
                if (fstream.Length != 0)
                {
                    fstream.Seek(-6, SeekOrigin.End);
                    byte[] array = new byte[6];
                    fstream.Read(array, 0, 6);
                    string indexFound = System.Text.Encoding.Default.GetString(array);
                    array = null;
                    index = int.Parse(indexFound);
                    return indexFound.Equals("999999");
                }
                else
                {
                    index = 0;
                    return false;
                }
            }
        }
    }

}
