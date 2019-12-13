using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBSearcher
{
    struct TitlePrincipals
    {
        private readonly string tConst;
        private readonly int ordering;
        private readonly string nConst;
        private readonly string category;
        private readonly string job;
        private readonly string characters;

        public TitlePrincipals(string tConst, int ordering, string nConst, string category,
            string job, string characters) : this()
        {
            this.tConst = tConst;
            this.ordering = ordering;
            this.nConst = nConst;
            this.category = category;
            this.job = job;
            this.characters = characters;
        }

        public string TConst { get => tConst; }
        public int Ordering { get => ordering; }
        public string NConst { get => nConst; }
        public string Category { get => category; }
        public string Job { get => job; }
        public string Characters { get => characters; }
    }
}
