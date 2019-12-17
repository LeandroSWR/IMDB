using System;
using System.Collections.Generic;
using System.Text;

namespace IMDBSearcher
{
    class Menus
    {
        // The user input for the search
        private string searchString;

        // The key pressed by the user
        private ConsoleKey pressedKey;

        // Declare an Instance for the Search Settings
        private SearchSettings searchSettings;

        // Variable that works as a table of NameBasics from a db with a single key
        private ImdbTable nameBasics;

        // Variable that works as a table of TitleAkas from a db with a single key
        public ImdbTable TitleAkas { get; private set; }

        // Variable that works as a table of TitleBasics from a db with a single key
        public ImdbTable TitleBasics { get; private set; }

        // Variable that works as a table of TitleCrew from a db with a single key
        private ImdbTable titleCrew;

        // Variable that works as a table of TitleEpisode from a db with a single key
        private ImdbTable titleEpisode;

        // Variable that works as a table of TitlePrincipals from a db with a single key
        private ImdbTable titlePrincipals;

        // Variable that works as a table of TitleRatings from a db with a single key
        private ImdbTable titleRatings;

        /// <summary>
        /// The Class Empty Constructor
        /// </summary>
        public Menus() {

            // Initialize the Search Settings passing a reference to this script
            searchSettings = new SearchSettings(this);
        }

        /// <summary>
        /// Draws the Menu
        /// </summary>
        /// <param name="menuType">The type of menu we're drawing</param>
        public void DrawMainMenu()
        {
            // Clears the Console
            Console.Clear();

            // Draw the lines that are independent of the menu type
            Console.WriteLine(" _________________________________");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|        Search Type Menu         |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|  1. Titles                      |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|  2. Exit                        |");
            Console.WriteLine("|_________________________________|");

            // Calls the Selection method which waits for input
            SelectFromTheMenu();
        }

        /// <summary>
        /// Method that reads the user's input on the Menu 
        /// </summary>
        private void SelectFromTheMenu()
        {
            // Reads the input
            switch (Console.ReadKey().Key)
            {
                // Asks for what the user wants to search
                case ConsoleKey.D1:

                    // Start asking the user for all search related parameters
                    AskForSearchParameters();
                    break;
                // Closes the Console
                case ConsoleKey.D2:

                    // Exit the application
                    Environment.Exit(0);
                    break;

                // Draws the Menu if the input is incorrect
                default:

                    DrawMainMenu();
                    break;
            }

            // Draws the Menu
            DrawMainMenu();
        }

        /// <summary>
        /// Ask what the user wants to search for
        /// </summary>
        private void AskForSearchParameters()
        {
            // Loops
            do
            {
                // Clears the Console
                Console.Clear();

                // Ask the user if he wants a specific type of ordering
                Console.WriteLine("Do you want a specific order? (y/n)");

                // If so...
                if ((pressedKey = Console.ReadKey().Key) == ConsoleKey.Y)
                {
                    // Let the user choose how the search results will be ordered
                    searchSettings.SetSearchParameters();
                }

                // Until the user selects an option of yes or no for the order by
            } while (pressedKey != ConsoleKey.Y && pressedKey != ConsoleKey.N);


            // Loops
            do
            {
                // Clears the Console
                Console.Clear();

                // Ask the user if he wants a specific type of ordering
                Console.WriteLine("Do you want to add filters? (y/n)");

                // If so...
                if ((pressedKey = Console.ReadKey().Key) == ConsoleKey.Y)
                {
                    // Ask the user what search filters he wants to use (Can be none)
                    AskForSearchFilters();
                }

                // Until the user selects an option of yes or no for the order by
            } while (pressedKey != ConsoleKey.Y && pressedKey != ConsoleKey.N);

            // Clears the Console
            Console.Clear();

            // Ask the user to search for what he wants
            Console.WriteLine("Search IMDB Input:");

            // Save what the user wants to search for
            searchString = Console.ReadLine();

            TitleBasics = new ImdbTable();

            TitleBasics.FillList(Constants.filleTitleBasics, ref searchString);

            // Clears the Console
            Console.Clear();

            ListFilter lf = new ListFilter();

            TitleBasics = lf.SortList(searchSettings.TOrderBy, TitleBasics, titleRatings);

            foreach (TitleBasics tb in TitleBasics)
            {
                Console.WriteLine(tb.OriginalTitle);
            }

            Console.ReadLine();
        }

        
        /// <summary>
        /// Asks the user what search filters he wants to use
        /// </summary>
        public void AskForSearchFilters()
        {
            // Clears the Console
            Console.Clear();

            // WriteLines that print the filtering parameters
            Console.WriteLine("Select which filters you want to use.\n");

            // List all the filters available
            Console.WriteLine("\n1. Type\n2. Primary Title\n3. Adult\n" +
                "4. Start Date\n5. End Date\n6. Genre\n\n0. Continue");

            // Set the filter acording to player selection
            searchSettings.SetTitleFilters();
        }

        /// <summary>
        /// Called when the user input is invalit
        /// </summary>
        public void InvalidInputErrorDisplay()
        {
            // Clears the Console
            Console.Clear();

            // Display an error message for invalid parameters
            Console.WriteLine("Invalid input, please try again...");

            // Waits for the used to press any key
            Console.ReadKey();
        }
    }
}
