using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace IMDBSearcher
{
    class ListFilter
    {
        private List<TitleBasics> basicsTemp;

        public ListFilter() {
            basicsTemp = new List<TitleBasics>();
        }

        public ImdbTable FilterTitles(SearchSettings searchSet, ImdbTable titleBasics)
        {
            TitleFilters filter = searchSet.TFilters;

            for (int i = 0; i < titleBasics.Count; i++)
            {
                if (titleBasics[i] != null && titleBasics[i] is TitleBasics)
                {
                    basicsTemp.Add((TitleBasics)titleBasics[i]);
                }
            }

            // Filters the Title list using the filter parameters selected by the user
            basicsTemp = basicsTemp.Where(title => 
                (title.TitleType == filter.Type.ToString() || filter.Type == TitleType.none) &&
                (title.PrimaryTitle == filter.PrimaryTitle || filter.PrimaryTitle == null) &&
                (title.IsAdult == filter.Adult || filter.Adult == null) &&
                (title.StartYear == filter.StartDate || filter.StartDate == null) &&
                (title.EndYear == filter.EndDate || filter.EndDate == null) &&
                (filter.Genre == null || 
                ((title.Genres.Contains(filter.Genre[0].ToString().Contains("_") ?
                filter.Genre[0].ToString().Replace('_', '-') : filter.Genre[0].ToString()) ||
                filter.Genre[0] == null) &&
                (title.Genres.Contains(filter.Genre[1].ToString().Contains("_") ?
                filter.Genre[1].ToString().Replace('_', '-') : filter.Genre[1].ToString()) ||
                filter.Genre[1] == null) &&
                (title.Genres.Contains(filter.Genre[2].ToString().Contains("_") ?
                filter.Genre[2].ToString().Replace('_', '-') : filter.Genre[2].ToString()) ||
                filter.Genre[2] == null)))).ToList();

            titleBasics.Clear();

            for (int i = 0; i < basicsTemp.Count; i++)
            {
                titleBasics.Add(basicsTemp[i]);
            }

            return SortList(searchSet, titleBasics);
        }

        /// <summary>
        /// Responsible for sorting all games acording to the selected sort method
        /// </summary>
        public ImdbTable SortList(SearchSettings searchSet, ImdbTable titleBasics)
        {
            for (int i = 0; i < titleBasics.Count; i++)
            {
                if (titleBasics[i] != null && titleBasics[i] is TitleBasics)
                {
                    basicsTemp.Add((TitleBasics)titleBasics[i]);
                }
            }

            switch (searchSet.TOrderBy)
            {
                // Sorts by Title name in alphabetical order
                case TitlesOrderBy.PrimaryTitle:
                    basicsTemp = basicsTemp.OrderBy(title => title.PrimaryTitle).ToList();
                    break;
                // Sorts by the type of title in alphabetical order
                case TitlesOrderBy.Type:
                    basicsTemp = basicsTemp.OrderBy(title => title.TitleType).ToList();
                    break;
                // Sorts by if is Adult
                case TitlesOrderBy.IsAdult:
                    basicsTemp = basicsTemp.OrderBy(title => title.IsAdult == true).ToList();
                    break;
                // Sorts by the Release Date
                case TitlesOrderBy.BeginingDate:
                    basicsTemp = basicsTemp.OrderBy(title => title.StartYear).ToList();
                    break;
                // Sorts by End Date
                case TitlesOrderBy.EndDate:
                    basicsTemp = basicsTemp.OrderBy(title => title.EndYear != null).ToList();
                    break;
                // Sorts by number of Owners Descending
                default:
                    return titleBasics;
            }

            for (int i = 0; i < basicsTemp.Count; i++)
            {
                titleBasics[i] = basicsTemp[i];
            }

            return titleBasics;
        }
    }
}
