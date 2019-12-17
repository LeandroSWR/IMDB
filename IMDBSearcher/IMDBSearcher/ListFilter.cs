using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace IMDBSearcher
{
    class ListFilter
    {
        private List<ICollection<object>> tempBasicsRantings;

        private List<TitleBasics> basicsTemp;
        private List<object> fullTemp;
        
        public ListFilter() {
            basicsTemp = new List<TitleBasics>();
            fullTemp = new List<object>();
        }

        /// <summary>
        /// Responsible for sorting all games acording to the selected sort method
        /// </summary>
        public ImdbTable SortList(TitlesOrderBy orderCriteria, ImdbTable titleBasics, ImdbTable titleRatings)
        {
            tempBasicsRantings = new List<ICollection<object>>(titleBasics.Count);

            for (int i = 0; i < titleBasics.Count; i++)
            {
                if (titleBasics[i] != null && titleBasics[i] is TitleBasics)
                {
                    basicsTemp.Add((TitleBasics)titleBasics[i]);

                    if (orderCriteria == TitlesOrderBy.Classification)
                    {
                        fullTemp.Add(((TitleBasics)titleBasics[i]).TConst);
                        fullTemp.Add(((TitleBasics)titleBasics[i]).TitleType);
                        fullTemp.Add(((TitleBasics)titleBasics[i]).PrimaryTitle);
                        fullTemp.Add(((TitleBasics)titleBasics[i]).OriginalTitle);
                        fullTemp.Add(((TitleBasics)titleBasics[i]).IsAdult);
                        fullTemp.Add(((TitleBasics)titleBasics[i]).StartYear);
                        fullTemp.Add(((TitleBasics)titleBasics[i]).EndYear);
                        fullTemp.Add(((TitleBasics)titleBasics[i]).RuntimeMinutes);
                        fullTemp.Add(((TitleBasics)titleBasics[i]).Genres);

                        tempBasicsRantings.Add(fullTemp);
                    }
                }
            }

            if (orderCriteria == TitlesOrderBy.Classification)
            {
                for (int i = 0; i < titleRatings.Count; i++)
                {
                    if (titleRatings[i] != null && titleRatings[i] is TitleRatings)
                    {
                        for (int a = 0; a < tempBasicsRantings.Count; a++)
                        {
                            if ((string)(tempBasicsRantings[a] as List<object>)[0] == ((TitleRatings)titleRatings[i]).TConst)
                            {
                                (tempBasicsRantings[a] as List<object>).Add(((TitleRatings)titleRatings[i]).AverageRating);
                                (tempBasicsRantings[a] as List<object>).Add(((TitleRatings)titleRatings[i]).NumVotes);
                            }
                        }
                    }
                }
            }

            switch (orderCriteria)
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
                // Sorts by the classification score
                case TitlesOrderBy.Classification:
                    tempBasicsRantings = tempBasicsRantings.
                        OrderByDescending(title => (title as List<object>)[9]).ToList();
                    break;
                // Sorts by number of Owners Descending
                default:
                    return titleBasics;
            }

            if (orderCriteria != TitlesOrderBy.Classification)
            {
                for (int i = 0; i < basicsTemp.Count; i++)
                {
                    titleBasics[i] = basicsTemp[i];
                }

                return titleBasics;
            }
             else 
            {
                
                for (int i = 0; i < tempBasicsRantings.Count; i++)
                {
                    titleBasics[i] = new TitleBasics(
                            (string)(tempBasicsRantings[i] as List<object>)[0],
                            (string)(tempBasicsRantings[i] as List<object>)[1],
                            (string)(tempBasicsRantings[i] as List<object>)[2],
                            (string)(tempBasicsRantings[i] as List<object>)[3],
                            (bool?)(tempBasicsRantings[i] as List<object>)[4],
                            (ushort?)(tempBasicsRantings[i] as List<object>)[5],
                            (ushort?)(tempBasicsRantings[i] as List<object>)[6],
                            (byte?)(tempBasicsRantings[i] as List<object>)[7],
                            (string[])(tempBasicsRantings[i] as List<object>)[8]);
                }

                return titleBasics;
            }
              
        }
    }
}
