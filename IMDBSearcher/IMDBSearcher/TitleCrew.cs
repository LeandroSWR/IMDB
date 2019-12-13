using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBSearcher
{
    struct TitleCrew
    {
        private readonly string tconst;
        private readonly string[] directors;
        private readonly string[] writers;

        public TitleCrew(string tconst, string[] directors, string[] writers)
        {
            this.tconst = tconst;
            this.directors = directors;
            this.writers = writers;
        }
        
        public string Tconst { get => tconst; }
        public string[] Directors { get => directors; }
        public string[] Writers { get => writers; }
    }
}
