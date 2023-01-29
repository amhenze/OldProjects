using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTextreader
{
    internal class CreateDeleteFile
    {
        public static void Create()
        {
            int totalFiles = 10;
            Console.WriteLine("set new_dir name:");
            string directoryName = Console.ReadLine();
            Directory.CreateDirectory(Program.rootpath + directoryName);
            for (int j = 0; j < totalFiles; j++)
            {
                int linesCount = Randomize.GetRandomInt(1, 100, 1000);
                string fileName = "newgen" + Randomize.GetRandomInt(1, 100, 999);
                using StreamWriter file = new($"{Program.rootpath}{directoryName}/{fileName}.txt");
                for (int i = 0; i < linesCount; i++)
                {
                    file.WriteLine(Convert.ToString(Randomize.GetRandomInt(1, 0, 100000)) + Randomize.GetRandomString());
                }
            }
        }

        public static void Delete(string root,string mask)
        {
            foreach (string file in Directory.EnumerateFiles(root, mask))
            {
                File.Delete(file);
            }
        }
    }
}
