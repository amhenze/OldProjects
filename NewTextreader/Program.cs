using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace NewTextreader
{
    internal class Program
    {
        public static readonly string? rootpath = "C:/Users/Amhenze/source/repos/CsharpTestProject/TXT/";
        public static string? directory;

        static async Task Main()
        {
            List<Line> lines = new List<Line>();
            Fileworker.SetDir();
            await Fileworker.ReadAsync(lines);
            if (directory != null)
            {
                List<Line> sortedLines = lines
                    .OrderBy(l => l.Numbers)
                    .ThenByDescending(l => l.Letters)
                    .ToList();
                await Fileworker.Save(sortedLines, SortTypeEnum.All);
            }
        }
    }
}