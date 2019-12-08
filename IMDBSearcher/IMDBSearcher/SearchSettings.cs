using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBSearcher
{
    class SearchSettings
    {
        // Declare an Instance for the Menus
        Menus menu;

        // What type of search it is (Titles or People)
        public SearchType SearchType { get; set; }

        // What to order by if we're searching for Titles
        private TitlesOrderBy tOrderBy;
        public TitlesOrderBy TOrderBy { get => tOrderBy; }

        // What to order by if we're searching for People
        private PeopleOrderBy pOrderBy;
        public PeopleOrderBy POrderBy { get => pOrderBy; }

        // Filters if we're searching for Titles
        public TitleFilters TFilters { get; private set; }

        // Filters if we're searching for People
        public PeopleFilters PFilters { get; private set; }

        // The key pressed by the user
        private ConsoleKey pressedKey;

        /// <summary>
        /// Constructor for our Search Settings
        /// </summary>
        /// <param name="menu">Reference to the Menus script</param>
        public SearchSettings(Menus menu)
        {
            // Initialize the Title Filters
            TFilters = new TitleFilters();

            // Initialize the People Filters
            PFilters = new PeopleFilters();

            // Initialize our menu variable with the recieve value
            this.menu = menu;
        }

        /// <summary>
        /// Set certain parameters for the search
        /// </summary>
        /// <param name="parameterType">What parameters we're setting</param>
        public void SetSearchParameters()
        {
            // Clears the Console
            Console.Clear();

            switch (SearchType)
            {
                case SearchType.Titles:

                    // Ask the user to define what he want's to search for
                    Console.WriteLine("Order by? (Type, PrimaryTitle, IsAdult, " +
                        "BeginingDate, EndDate, Classification)");

                    // Try to parse the inpunt into an Enum type
                    if (!Enum.TryParse(Console.ReadLine(), out tOrderBy))
                    {
                        menu.InvalidInputErrorDisplay();
                        SetSearchParameters();
                    }
                    break;
                case SearchType.People:

                    // Ask the user to define what he want's to search for
                    Console.WriteLine("Order by? (Name, BirthYear, DeathYear)");

                    // Try to parse the inpunt into an Enum type
                    if (!Enum.TryParse(Console.ReadLine(), out pOrderBy))
                    {
                        menu.InvalidInputErrorDisplay();
                        SetSearchParameters();
                    }
                    break;
            }

            // Space between the last request and the new
            Console.WriteLine();
        }

        /// <summary>
        /// Set's all the filters for Title Search based on user input
        /// </summary>
        public void SetTitleFilters()
        {
            switch (Console.ReadKey().Key)
            {
                // Asks for the type (Movie, Serie, etc..)
                case ConsoleKey.D1:

                    // Type of title chosen by the user
                    TitleType chosenType;

                    // Loops..
                    do
                    {
                        // Clears the console
                        Console.Clear();

                        // Ask for the type of title
                        Console.WriteLine("Title Types: movie, tvMovie, tvSeries, tvEpisode, " +
                            "tvSpecial, tvMiniSeries, videoGame, video, tvShort, shortFilm");
                        Console.WriteLine("\nInput the type of title you want:");

                        // Until the user chooses a valid option
                    } while (!Enum.TryParse(Console.ReadLine(), out chosenType));

                    // Set the values in a new filter struct
                    TFilters = new TitleFilters(
                        chosenType, // The type of title
                        TFilters.PrimaryTitle,
                        TFilters.Adult,
                        TFilters.StartDate,
                        TFilters.EndDate,
                        TFilters.Genre);
                    break;

                // Asks for the primary title
                case ConsoleKey.D2:

                    // Clears the console
                    Console.Clear();

                    // Set the values in a new filter struct
                    TFilters = new TitleFilters(
                        TFilters.Type,
                        Console.ReadLine(), // Returns a string with the user input
                        TFilters.Adult,
                        TFilters.StartDate,
                        TFilters.EndDate,
                        TFilters.Genre);
                    break;

                // Asks is it's for Adults only
                case ConsoleKey.D3:

                    // Loops
                    do
                    {
                        // Clears the Console
                        Console.Clear();

                        // Ask the user if he wants a specific type of ordering
                        Console.WriteLine("Is it Adult only? (y/n)");

                        // Save the input value to our variable
                        pressedKey = Console.ReadKey().Key;

                        // Until the user selects an option of yes or no for the order by
                    } while (pressedKey != ConsoleKey.Y && pressedKey != ConsoleKey.N);

                    // Set the values in a new filter struct
                    TFilters = new TitleFilters(
                        TFilters.Type,
                        TFilters.PrimaryTitle,
                        pressedKey == ConsoleKey.Y, // returns a true of false
                        TFilters.StartDate,
                        TFilters.EndDate,
                        TFilters.Genre);
                    break;

                // Asks for the year of release
                case ConsoleKey.D4:

                    // What year it was released
                    ushort rYear = 0;

                    // Run the cycle
                    do
                    {
                        // Clears the console
                        Console.Clear();

                        // Ask for the user to input the year it was released in
                        Console.WriteLine("Input the year of release: (1800 - 2040)");

                        // If we can't parse the string into a ushort
                        if (!UInt16.TryParse(Console.ReadLine(), out rYear) ||
                            rYear < 1800 || rYear > 2040)
                            // Display an invalid input error
                            menu.InvalidInputErrorDisplay();

                        // Untill the user inputs a valid year
                    } while (rYear < 1800 || rYear > 2040);

                    // Set the values in a new filter struct
                    TFilters = new TitleFilters(
                        TFilters.Type,
                        TFilters.PrimaryTitle,
                        TFilters.Adult,
                        rYear, // uShort with the year of release
                        TFilters.EndDate,
                        TFilters.Genre);
                    break;

                // Asks for the year of termination
                case ConsoleKey.D5:

                    // What year it was terminated
                    ushort tYear = 0;

                    // Run the cycle
                    do
                    {
                        // Clears the console
                        Console.Clear();

                        // Ask for the user to input the year it was terminated in
                        Console.WriteLine("Input the year of termination: (1800 - 2040)");

                        // If we can't parse the string into a ushort
                        if (!UInt16.TryParse(Console.ReadLine(), out tYear) ||
                            tYear < 1800 || tYear > 2040)
                            // Display an invalid input error
                            menu.InvalidInputErrorDisplay();

                        // Untill the user inputs a valid year
                    } while (tYear < 1800 || tYear > 2040);

                    // Set the values in a new filter struct
                    TFilters = new TitleFilters(
                        TFilters.Type,
                        TFilters.PrimaryTitle,
                        TFilters.Adult,
                        TFilters.StartDate,
                        tYear, // uShort with the year of it was terminated
                        TFilters.Genre);
                    break;

                // Ask for up to 3 Genres
                case ConsoleKey.D6:

                    // How many genres the user wants (Limit 3)
                    byte numGenres;

                    // Run the cycle
                    do
                    {
                        // Clears the console
                        Console.Clear();

                        // Ask for the user to input the year of birth
                        Console.WriteLine("How many genres do you want to filter? (1-3)");

                        // If we can't parse the string into a ushort
                        if (!Byte.TryParse(Console.ReadLine(), out numGenres))
                            // Display an invalid input error
                            menu.InvalidInputErrorDisplay();

                        // Untill the user inputs a valid year
                    } while (numGenres == 0 || numGenres > 3);

                    // Type of title chosen by the user
                    Genres?[] genres = new Genres?[numGenres];

                    // Current chosen Genre
                    Genres chosenGenre;

                    // Loop the ammout of times the user chose
                    int i = 1;

                    // Loops..
                    do
                    {
                        // Clears the console
                        Console.Clear();

                        // Ask for the type of title
                        Console.WriteLine("List of Genres: \nAction, Adventure, " +
                            "Animation, Fantasy, Thriller, \nFamily, Mystery, " +
                            "Horror, History, Western, \nDocumentary, Biography, " +
                            "News, Drama, Comedy, Crime, \nShort, Romance, Sport, " +
                            "War, Music, Musical, Reality_TV, \nGame_Show, Sci_Fi, " +
                            "Talk_Show, Film_Noir ");
                        Console.WriteLine($"\nInput the Genre you want: ({i}/{numGenres})");

                        // If the parse was successful
                        if (Enum.TryParse(Console.ReadLine(), out chosenGenre))
                        {
                            // Verify if the chosen genre had already been chosen before
                            for (int a = 0; a < genres.Length; a++)
                            {
                                // If so...
                                if (genres[a] != null && genres[a] == chosenGenre)
                                {
                                    // Display an invalid input error
                                    menu.InvalidInputErrorDisplay();
                                    break;
                                }


                                if (genres[a] == null)
                                {

                                    // Had the chosen genre to our array
                                    genres[a] = chosenGenre;

                                    // Increment the i variable
                                    i++;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            // Display an invalid input error
                            menu.InvalidInputErrorDisplay();
                        }

                        // Until the user chooses all valid options
                    } while (i <= numGenres);

                    // Set the values in a new filter struct
                    TFilters = new TitleFilters(
                        TFilters.Type,
                        TFilters.PrimaryTitle,
                        TFilters.Adult,
                        TFilters.StartDate,
                        TFilters.EndDate,
                        genres);    // Array of Genres with all the selecter genres
                    break;

                    // If we chose continue
                case ConsoleKey.D0:

                    // Returns to the previous menu to search
                    return;

                // Display an invalid input error
                default:

                    // Display an input error
                    menu.InvalidInputErrorDisplay();
                    break;
            }

            // Display the filter selection again
            menu.AskForSearchFilters();
        }

        /// <summary>
        /// Set's all the filters for People Search based on user input
        /// </summary>
        public void SetPeopleFilters()
        {
            switch (Console.ReadKey().Key)
            {
                // Asks fot the name
                case ConsoleKey.D1:

                    // Clears the console
                    Console.Clear();

                    // Ask for the name
                    Console.WriteLine("Write the Name:");

                    // Set the values in a new filter struct
                    PFilters = new PeopleFilters(
                        Console.ReadLine(),
                        PFilters.BirthYear,
                        PFilters.DeathYear,
                        PFilters.MainProfessions);
                    break;

                // Asks for the year of birth
                case ConsoleKey.D2:
                    // What year the person was born in
                    ushort bYear = 0;

                    // Run the cycle
                    do
                    {
                        // Clears the console
                        Console.Clear();

                        // Ask for the user to input the year of birth
                        Console.WriteLine("Input the year of birth: (1800 - 2019)");

                        // If we can't parse the string into a ushort
                        if (!UInt16.TryParse(Console.ReadLine(), out bYear) ||
                            bYear < 1800 || bYear > 2019)
                            // Display an invalid input error
                            menu.InvalidInputErrorDisplay();

                        // Untill the user inputs a valid year
                    } while (bYear < 1800 || bYear > 2019);

                    // Set the values in a new filter struct
                    PFilters = new PeopleFilters(
                        PFilters.Name,
                        bYear,
                        PFilters.DeathYear,
                        PFilters.MainProfessions);
                    break;

                // Asks for the year of death
                case ConsoleKey.D3:
                    // What year the person was born in
                    ushort dYear = 0;

                    // Run the cycle
                    do
                    {
                        // Clears the console
                        Console.Clear();

                        // Ask for the user to input the year of death
                        Console.WriteLine("Input the year of death: (1800 - 2019)");

                        // If we can't parse the string into a ushort
                        if (!UInt16.TryParse(Console.ReadLine(), out dYear) ||
                            dYear < 1800 || dYear > 2019)
                            // Display an invalid input error
                            menu.InvalidInputErrorDisplay();

                        // Untill the user inputs a valid year
                    } while (dYear < 1800 || dYear > 2019);

                    // Set the values in a new filter struct
                    PFilters = new PeopleFilters(
                        PFilters.Name,
                        PFilters.BirthYear,
                        dYear,
                        PFilters.MainProfessions);
                    break;

                // Asks for the MainProfessions
                case ConsoleKey.D4:

                    //                                                              //
                    // !!!!!!!!!!!!!!MISSING THE CODE FOR PROFFESSIONS!!!!!!!!!!!!!!//
                    //                                                              //

                    // Clears the console
                    Console.Clear();

                    break;

                // If we chose continue
                case ConsoleKey.D0:

                    // Returns to the previous menu to search
                    return;

                // Display an invalid input error
                default:

                    // Display an input error
                    menu.InvalidInputErrorDisplay();
                    break;
            }

            // Display the filter selection again
            menu.AskForSearchFilters();
        }
    }
}
