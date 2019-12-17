using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace IMDBSearcher
{
    /// <summary>
    /// Responsible for filtering the Titles List
    /// </summary>
    class ListFilter
    {
        // A temporary list to be filtered
        private List<TitleBasics> basicsTemp;

        /// <summary>
        /// Constructor for ListFilter
        /// </summary>
        public ListFilter() {
            // Initialize the bsicsTemp List
            basicsTemp = new List<TitleBasics>();
        }

        /// <summary>
        /// Filters the list with the given filters
        /// </summary>
        /// <param name="searchSet">Reference to the searchSettings</param>
        /// <param name="titleBasics">Main list with all the titles</param>
        /// <returns>A completly filtered list</returns>
        public ImdbTable FilterTitles(SearchSettings searchSet, ImdbTable titleBasics)
        {
            // Initialize a new filter to reduce the length of code
            TitleFilters filter = searchSet.TFilters;

            // Go through all the titles in the list
            for (int i = 0; i < titleBasics.Count; i++)
            {
                // If it's not null and is of type TitleBasics
                if (titleBasics[i] != null && titleBasics[i] is TitleBasics)
                {
                    // Add it to the temporary list
                    basicsTemp.Add((TitleBasics)titleBasics[i]);
                }
            }

            // Filters the temporary list using the filter parameters selected by the user
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

            // Clears the main title list
            titleBasics.Clear();

            // Goes through all the titles
            for (int i = 0; i < basicsTemp.Count; i++)
            {
                // Add it to the main titles list
                titleBasics.Add(basicsTemp[i]);
            }

            // Calls the SortList to return the fully filtered and ordered list
            return SortList(searchSet, titleBasics);
        }

        /// <summary>
        /// Responsible for sorting all titles acording to the selected sort method
        /// </summary>
        public ImdbTable SortList(SearchSettings searchSet, ImdbTable titleBasics)
        {
            // Clear the temporary list
            basicsTemp.Clear();

            // Go through all the titles in the list
            for (int i = 0; i < titleBasics.Count; i++)
            {
                // If it's not null and is of type TitleBasics
                if (titleBasics[i] != null && titleBasics[i] is TitleBasics)
                {
                    // Add it to the temporary list
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

            // Clears the main titles list
            titleBasics.Clear();

            // Goes through all the titles
            for (int i = 0; i < basicsTemp.Count; i++)
            {
                // Add it to the main titles list
                titleBasics.Add(basicsTemp[i]);
            }

            // Returns the fully filtered and ordered list
            return titleBasics;
        }
    }
}
