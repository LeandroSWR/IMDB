using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBSearcher
{
    struct NameBasics
    {
        private readonly string nConst;
        private readonly string primaryName;
        private readonly ushort? birthYear;
        private readonly ushort? deathYear;
        private readonly string[] primaryProfession;
        private readonly string[] knownForTitles;

        public NameBasics(string nConst, string primaryName, ushort? birthYear, 
            ushort? deathYear, string[] primaryProfession, string[] knownForTitles)
        {
            this.nConst = nConst;
            this.primaryName = primaryName;
            this.birthYear = birthYear;
            this.deathYear = deathYear;
            this.primaryProfession = primaryProfession;
            this.knownForTitles = knownForTitles;
        }

        public string NConst { get => nConst; }
        public string PrimaryName { get => primaryName; }
        public ushort? BirthYear { get => birthYear; }
        public ushort? DeathYear { get => deathYear; }
        public string[] PrimaryProfession { get => primaryProfession; }
        public string[] KnownForTitles { get => knownForTitles; }
    }
}
