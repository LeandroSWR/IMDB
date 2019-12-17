namespace IMDBSearcher
{
    /// <summary>
    /// Enumerator for the search parameters
    /// </summary>
    public enum Parameters
    {
        SearchType,
        OrderBy
    }

    /// <summary>
    /// Enumerator for the Titles Order By
    /// </summary>
    public enum TitlesOrderBy
    {
        None,
        Type,
        PrimaryTitle,
        IsAdult,
        BeginingDate,
        EndDate,
        Classification
    }

    /// <summary>
    /// Enumerator with all the Title Types
    /// </summary>
    public enum TitleType
    {
        none,
        movie,
        tvMovie,
        tvSeries,
        tvEpisode,
        tvSpecial,
        tvMiniSeries,
        videoGame,
        video,
        tvShort,
        shortFilm
    }

    /// <summary>
    /// Enumerator with all the existing Genres
    /// </summary>
    public enum Genres
    {
        Action,
        Adventure,
        Animation,
        Fantasy,
        Thriller,
        Family,
        Mystery,
        Horror,
        History,
        Western,
        Documentary,
        Biography,
        News, 
        Drama,
        Comedy,
        Crime,
        Short,
        Romance,
        Sport,
        War,
        Music,
        Musical,
        Reality_TV,
        Game_Show,
        Sci_Fi,
        Talk_Show,
        Film_Noir
    }
}
