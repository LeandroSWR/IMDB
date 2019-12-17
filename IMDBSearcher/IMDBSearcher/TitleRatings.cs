using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBSearcher
{
    struct TitleRatings
    {
        private readonly string tConst;
        private readonly float averageRating;
        private readonly int numVotes;

        public TitleRatings(string tConst, float averageRating, int numVotes) : this()
        {
            this.tConst = tConst;
            this.averageRating = averageRating;
            this.numVotes = numVotes;
        }

        public string TConst { get => tConst; }
        public float AverageRating { get => averageRating; }
        public int NumVotes { get => numVotes; }
    }
}
