using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBSearcher
{
    struct TitleAkas
    {
        private readonly string titleId;
        private readonly string ordering;
        private readonly string title;
        private readonly string region;
        private readonly string language;
        private readonly string[] types;
        private readonly string[] attributes;
        private readonly bool? isOriginalTitle;

        public TitleAkas(string titleId, string ordering, string title, string region,
            string language, string[] types, string[] attributes, bool? isOriginalTitle)
        {
            this.titleId = titleId;
            this.ordering = ordering;
            this.title = title;
            this.region = region;
            this.language = language;
            this.types = types;
            this.attributes = attributes;
            this.isOriginalTitle = isOriginalTitle;
        }

        public string TitleId { get => titleId; }
        public string Ordering { get => ordering; }
        public string Title { get => title; }
        public string Region { get => region; }
        public string Language { get => language; }
        public string[] Types { get => types; }
        public string[] Attributes { get => attributes; }
        public bool? IsOriginalTitle { get => isOriginalTitle; }
    }
}
