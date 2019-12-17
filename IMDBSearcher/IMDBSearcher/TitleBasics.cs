using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBSearcher
{
    /// <summary>
    /// Immutable struct contaning all the information on a specific title
    /// </summary>
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
        
        /// <summary>
        /// TitleBasics constructor
        /// </summary>
        /// <param name="tConst">The ID of the title</param>
        /// <param name="titleType">The type of title</param>
        /// <param name="primaryTitle">The primary title</param>
        /// <param name="originalTitle">The original title</param>
        /// <param name="isAdult">If it's adult only</param>
        /// <param name="startYear">The year of release</param>
        /// <param name="endYear">The year it ended</param>
        /// <param name="runtimeMinutes">The total runtime in minutes</param>
        /// <param name="genres">Array with all the genres</param>
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
