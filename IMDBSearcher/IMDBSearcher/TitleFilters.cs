using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBSearcher
{
    /// <summary>
    /// Immutable Struct with all the Title Filters
    /// </summary>
    struct TitleFilters
    {
        private readonly TitleType type;
        private readonly string primaryTitle;
        private readonly bool? adult;
        private readonly ushort? startDate;
        private readonly ushort? endDate;
        private readonly Genres?[] genre;

        public TitleFilters(TitleType type, string primaryTitle, bool? adult, 
            ushort? startDate, ushort? endDate, Genres?[] genre) : this()
        {
            this.type = type;
            this.primaryTitle = primaryTitle;
            this.adult = adult;
            this.startDate = startDate;
            this.endDate = endDate;
            this.genre = genre;
        }

        public TitleType Type { get => type; }
        public string PrimaryTitle { get => primaryTitle; }
        public bool? Adult { get => adult; }
        public ushort? StartDate { get => startDate; }
        public ushort? EndDate { get => endDate; }
        public Genres?[] Genre { get => genre; }
    }
}
