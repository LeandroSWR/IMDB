using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBSearcher
{
    struct TitleBasics
    {
        private readonly string tConst;
        private readonly string titleType;
        private readonly string primaryTitle;
        private readonly string originalTitle;
        private readonly bool? isAdult;
        private readonly ushort? startYear;
        private readonly ushort? endYear;
        private readonly byte? runtimeMinutes;
        private readonly string[] genres;
        
        public TitleBasics(string tConst, string titleType, string primaryTitle, string originalTitle, 
            bool? isAdult, ushort? startYear, ushort? endYear, byte? runtimeMinutes, 
            string[] genres) : this()
        {
            this.tConst = tConst;
            this.titleType = titleType;
            this.primaryTitle = primaryTitle;
            this.originalTitle = originalTitle;
            this.isAdult = isAdult;
            this.startYear = startYear;
            this.endYear = endYear;
            this.runtimeMinutes = runtimeMinutes;
            this.genres = genres;
        }

        public string TConst { get => tConst; }
        public string TitleType { get => titleType; }
        public string PrimaryTitle { get => primaryTitle; }
        public string OriginalTitle { get => originalTitle; }
        public bool? IsAdult { get => isAdult; }
        public ushort? StartYear { get => startYear; }
        public ushort? EndYear { get => endYear; }
        public byte? RuntimeMinutes { get => runtimeMinutes; }
        public string[] Genres { get => genres; }
    }
}
