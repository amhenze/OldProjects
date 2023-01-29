using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTextreader
{
    class Fileworker
    {
        public static void SetDir()
        {
            var allDirectories = Directory.GetDirectories(Program.rootpath);
            foreach (string directoryName in allDirectories)
            {
                int position = directoryName.IndexOf("/TXT");
                Console.WriteLine(directoryName.Substring(position + 5)); // отображать только название директорий
            }
            var tempDirectory = Console.ReadLine();
            if (tempDirectory == "new")
            {
                CreateDeleteFile.Create();
            }
            else
            {
                Program.directory = tempDirectory;
            }
        }

        public static async Task ReadAsync(List<Line> lines)
        {
            try
            {
                if (Directory.Exists(Program.rootpath + Program.directory))
                {
                    CreateDeleteFile.Delete(Program.rootpath + Program.directory, "result*.txt");
                    var allfiles = Directory.GetFiles(Program.rootpath + Program.directory);
                    foreach (string filename in allfiles)
                    {
                        string[] file = await File.ReadAllLinesAsync(filename);
                        foreach (var line in file)
                        {
                            var tokens = line.Split(';');
                            var linestruct = new Line { Numbers = Int32.Parse(tokens[0]), Letters = tokens[1] };
                            if (ExtraLogic.Remain(linestruct))
                            {
                                lines.Add(linestruct);
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("dir not exist");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static async Task Save(List<Line> lines, SortTypeEnum sortType)
        {
            using FileStream file = new($"{Program.rootpath}{Program.directory}/result{sortType}.txt", FileMode.OpenOrCreate);
            using StreamWriter fileOut = new StreamWriter(file);
            foreach (var line in lines)
            {
                switch (sortType)
                {
                    case SortTypeEnum.Numbers: await fileOut.WriteLineAsync(line.Numbers.ToString()); break;
                    case SortTypeEnum.Letters: await fileOut.WriteLineAsync(line.Letters); break;
                    case SortTypeEnum.All: await fileOut.WriteLineAsync(line.Numbers + ";" + line.Letters); break;
                }
            }
        }
    }
}
