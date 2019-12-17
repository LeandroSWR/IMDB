using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace IMDBSearcher
{
    /// <summary>
    /// Reads the file and saves all necessary data in it self
    /// Lists all the titles
    /// </summary>
    class ImdbTable : List<object>
    {
        private const string appName = "MyIMDBSearcher";
        public const string fillePath = "title.basics.tsv.gz";
        private readonly string folderWithFiles = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            appName);

        private Menus menu;

        public ImdbTable(Menus menu) {
            this.menu = menu;
        }

        private string[] currentLine;

        private ushort? currentSParse;
        private byte? currentBParse;
        private ushort sParse;
        private byte bParse;

        public void FillList(string searchString = null)
        {
            byte b = 0;
            try
            {
                using (FileStream reader = File.OpenRead(Path.Combine(folderWithFiles, fillePath)))
                {
                    using (GZipStream zip = new GZipStream(reader, CompressionMode.Decompress, true))
                    {
                        using (StreamReader unzip = new StreamReader(zip))
                        {
                            while (!unzip.EndOfStream)
                            {
                                currentLine = unzip.ReadLine().Split("\t");
                                if (b != 0)
                                    SaveFileData(searchString);
                                else
                                    b++;
                            }
                        }
                    }
                }
            } catch (Exception e)
            {
                Console.WriteLine($"\nError: {e.Message}");
                Console.ReadLine();
            }
        }

        private void SaveFileData(string searchString)
        {
            if (currentLine[2].Contains(searchString, StringComparison.InvariantCultureIgnoreCase))
            {
                Add(new TitleBasics(
                    currentLine[0],
                    currentLine[1],
                    currentLine[2],
                    currentLine[3],
                    Convert.ToUInt16(currentLine[4]) == 1,
                    ushort.TryParse(currentLine[5], out sParse) ? (currentSParse = sParse) : null,
                    ushort.TryParse(currentLine[6], out sParse) ? (currentSParse = sParse) : null,
                    byte.TryParse(currentLine[7], out bParse) ? (currentBParse = bParse) : null,
                    currentLine[8].Split("\\s+")));
            }
        }
    }
}
