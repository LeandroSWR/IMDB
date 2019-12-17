using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBSearcher
{
    /// <summary>
    /// Responsible for setting up all search settings and parameters
    /// </summary>
    class SearchSettings
    {
        // Declare an Instance for the Menus
        Menus menu;

        // What to order by if we're searching for Titles
        private TitlesOrderBy tOrderBy;
        public TitlesOrderBy TOrderBy { get => tOrderBy; }

        // Filters if we're searching for Titles
        public TitleFilters TFilters { get; private set; }

        // The key pressed by the user
        private ConsoleKey pressedKey;

        // String to save the current input of the user
        private string userInput;

        // A readonly stringof what the user needs to write if he wants to go back
        private readonly string backString;

        /// <summary>
        /// Constructor for our Search Settings
        /// </summary>
        /// <param name="menu">Reference to the Menus script</param>
        public SearchSettings(Menus menu)
        {
            // Initialize the Title Filters
            TFilters = new TitleFilters();

            // Initialize the string to go back
            backString = "back";

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

            // Ask the user to define what he want's to search for
            Console.WriteLine("Order by? (Type, PrimaryTitle, IsAdult, " +
                "BeginingDate, EndDate, Classification)");

            // Try to parse the inpunt into an Enum type
            if (!Enum.TryParse(Console.ReadLine(), out tOrderBy))
            {
                menu.InvalidInputErrorDisplay();
                SetSearchParameters();
            }

            // Space between the last request and the new
            Console.WriteLine();
        }

        /// <summary>
        /// Set's all the filters for Title Search based on user input
        /// </summary>
        public void SetFilters()
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

                        // Save the user input
                        userInput = Console.ReadLine();

                        // Until the user chooses a valid option
                    } while (!Enum.TryParse(userInput, out chosenType) && userInput != backString);

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
                    Genres?[] genres = new Genres?[3];

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
    }
}
