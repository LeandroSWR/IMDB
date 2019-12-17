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
    /// Enumerator for the People Order By
    /// </summary>
    public enum PeopleOrderBy
    {
        None,
        Name,
        BirthYear,
        DeathYear
    }

    /// <summary>
    /// Enumerator with all the Title Types
    /// </summary>
    public enum TitleType
    {
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

    public enum PrimaryProfessions
    {
        actor,
        actress,
        cinematographer,
        composer,
        director,
        editor,
        executive,
        miscellaneous,
        producer,
        soundtrack,
        stunts,
        writer,
        animation_department,
        art_department,
        art_director,
        assistant_director,
        camera_department,
        casting_department,
        casting_director,
        costume_department,
        costume_designer,
        editorial_department,
        make_up_department,
        music_department,
        production_designer,
        production_manager,
        set_decorator,
        sound_department,
        special_effects,
        transportation_department,
        visual_effects,
        location_management
    }
}
