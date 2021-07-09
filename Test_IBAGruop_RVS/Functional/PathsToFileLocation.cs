using System.Collections.Generic;
using System.IO;


namespace Test_IBAGruop_RVS.Functional
{
    internal static class PathsToFileLocation
    {
        internal static string MainDirectiry = @"C:\Users\Император\source\repos\Test_IBAGruop_RVS\Test_IBAGruop_RVS\bin\Debug\net5.0\DATABASE";
        internal static Dictionary<int, string> stringRepresentationOFTheDay = new Dictionary<int, string>
        {
            { 1 ,  "one" },
            { 2 ,  "two" },
            { 3 ,  "three" },
            { 4 ,  "four" },
            { 5 ,  "five" },
            { 6 ,  "six" },
            { 7 ,  "seven" },
            { 8 ,  "eight" },
            { 9 ,  "nine" },
            { 10 , "ten" },
            { 11 , "eleven" },
            { 12,  "twelve" },
            { 13,  "thirteen" },
            { 14,  "fourteen" },
            { 15,  "fifteen" },
            { 16,  "sixteen" },
            { 17,  "seventeen" },
            { 18,  "eighteen" },
            { 19,  "nineteen" },
            { 20,  "twenty" },
            { 21,  "twenty-one" },
            { 22,  "twenty-two" },
            { 23,  "twenty-three" },
            { 24,  "twenty-four" },
            { 25,  "twenty-five" },
            { 26,  "twenty-six" },
            { 27,  "twenty-seven" },
            { 28,  "twenty-eight" },
            { 29,  "twenty-nine" },
            { 30,  "thirty" },
            { 31,  "thirty-one" }
        };

        internal static void CreatCompletelyNewDataBase()
        {
            Directory.CreateDirectory(MainDirectiry);
            DirectoryInfo subdirectory = new DirectoryInfo(MainDirectiry);
            int i = 1;
            while (i < 13)
            {
                subdirectory.CreateSubdirectory(i.ToString());
                i++;
            }
        }
        internal static void CreatTextFile(string pathDirectory, string nameTextFile, string numberTextFile, out string newPathTextFale)
        {
            int tempNumber = int.Parse(numberTextFile);

            tempNumber++;
            string tempPath = pathDirectory + nameTextFile + "-Data-" + tempNumber.ToString() + ".txt";

            if (!(Directory.Exists(pathDirectory)))
            {
                Directory.CreateDirectory(pathDirectory);
            }

            File.Create(tempPath).Close();
            newPathTextFale = tempPath;

        }
        internal static void CreatDinaryFile(string pathDirectory, string nameBinFile, string numberBinFile, out string newPathBinFale)
        {
            int tempNumber = int.Parse(numberBinFile);

            tempNumber++;

            string tempPath = pathDirectory + nameBinFile + "-Index-" + tempNumber.ToString() + ".dat";

            if (!(Directory.Exists(pathDirectory)))
            {
                Directory.CreateDirectory(pathDirectory);
            }
            File.Create(tempPath).Close();
            newPathBinFale = tempPath;
        }
    }
}
