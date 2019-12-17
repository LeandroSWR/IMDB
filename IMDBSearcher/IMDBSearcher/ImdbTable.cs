using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace IMDBSearcher
{
    class ImdbTable : List<object>
    {
        private const string appName = "MyIMDBSearcher";
        private readonly string folderWithFiles = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            appName);

        public ImdbTable() { }

        private string[] currentLine;

        private ushort? currentSParse;
        private byte? currentBParse;
        private int? currentIParse = null;
        private ushort sParse;
        private byte bParse;
        private int iParse;

        public void FillList(string filePath, ref string searchString)
        {
            byte b = 0;
            try
            {
                using (FileStream reader = File.OpenRead(Path.Combine(folderWithFiles, filePath)))
                {
                    using (GZipStream zip = new GZipStream(reader, CompressionMode.Decompress, true))
                    {
                        using (StreamReader unzip = new StreamReader(zip))
                        {
                            while (!unzip.EndOfStream)
                            {
                                currentLine = unzip.ReadLine().Split("\t");
                                if (b != 0)
                                    SaveFileData(ref searchString, ref filePath);
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

        private void SaveFileData(ref string searchString, ref string filePath)
        {
            switch (filePath)
            {
                case Constants.filleNameBasics:
                    Add(new NameBasics(
                        currentLine[0], 
                        currentLine[1],
                        ushort.TryParse(currentLine[2], out sParse) ? (currentSParse = sParse) : null, 
                        ushort.TryParse(currentLine[3], out sParse) ? (currentSParse = sParse) : null, 
                        currentLine[4].Split(" "), 
                        currentLine[5].Split(" ")));
                    break;
                case Constants.filleTitleAkas:
                    
                        Add(new TitleAkas(
                        currentLine[0],
                        currentLine[1],
                        currentLine[2],
                        currentLine[3],
                        currentLine[4],
                        currentLine[5].Split(" ", StringSplitOptions.RemoveEmptyEntries),
                        currentLine[6].Split(" ", StringSplitOptions.RemoveEmptyEntries),
                        ushort.TryParse(currentLine[3], out sParse) ? (sParse == 1) : (bool?)null));
                    break;
                case Constants.filleTitleBasics:
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
                    break;
                case Constants.filleTitleCrew:
                    Add(new TitleCrew(
                        currentLine[0],
                        currentLine[1].Split(" "),
                        currentLine[2].Split(" ")));
                    break;
                case Constants.filleTitleEpisode:
                    Add(new TitleEpisode(
                        currentLine[0],
                        currentLine[1],
                        byte.TryParse(currentLine[2], out bParse) ? (currentBParse = bParse) : null,
                        ushort.TryParse(currentLine[3], out sParse) ? (currentSParse = sParse) : null));
                    break;
                case Constants.filleTitlePrincipals:
                    Add(new TitlePrincipals(
                        currentLine[0],
                        Convert.ToInt32(currentLine[1]),
                        currentLine[2],
                        currentLine[3],
                        currentLine[4],
                        currentLine[5]));
                    break;
                case Constants.filleTitleRatings:
                    Add(new TitleRatings(
                        currentLine[0],
                        Convert.ToSingle(currentLine[1]),
                        Convert.ToUInt16(currentLine[2])));
                    break;
            }
        }
    }
}
