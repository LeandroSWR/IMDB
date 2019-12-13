using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBSearcher
{
    struct TitleEpisode
    {
        private readonly string tconst;
        private readonly string parentTconst;
        private readonly byte? seasonNumber;
        private readonly ushort? episodeNumber;

        public TitleEpisode(string tconst, string parentTconst, byte? seasonNumber,
            ushort? episodeNumber)
        {
            this.tconst = tconst;
            this.parentTconst = parentTconst;
            this.seasonNumber = seasonNumber;
            this.episodeNumber = episodeNumber;
        }

        public string Tconst { get => tconst; }
        public string ParentTconst { get => parentTconst; }
        public byte? SeasonNumber { get => seasonNumber; }
        public ushort? EpisodeNumber { get => episodeNumber; }
    }   
}
