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
        
        // Variable that works as a table of TitleBasics from a db with a single key
        public ImdbTable TitleBasics { get; private set; }

        // Create a new list filter
        ListFilter listFilter;

        
        /// <summary>
        /// The Class Empty Constructor
        /// </summary>
        public Menus() {

            // Initialize the Search Settings passing a reference to this script
            searchSettings = new SearchSettings(this);

            // Initialize the list filter
            listFilter = new ListFilter();

            // Initialise the TitleBasics
            TitleBasics = new ImdbTable(this);
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

            // Fill the list based on the search string
            TitleBasics.FillList(searchString);

            // Filter the list
            TitleBasics = listFilter.FilterTitles(searchSettings, TitleBasics);

            // Displays the Filtered title list
            DisplayFilteredList();
        }

        /// <summary>
        /// Display the list (Already filtered)
        /// </summary>
        private void DisplayFilteredList()
        {
            // Clears the Console
            Console.Clear();

            // Goes trough each title on the list
            foreach (TitleBasics tb in TitleBasics)
            {
                // Display it's name with a small left offset
                Console.WriteLine("   " + tb.OriginalTitle);
            }

            // Call SelectFromList
            SelectFromList();
        }

        /// <summary>
        /// Ask the user to select a title from the list
        /// </summary>
        private void SelectFromList()
        {
            // If nothing was found
            if (TitleBasics.Count == 0)
            {
                // Allert the user
                Console.WriteLine("Nothing was found with those parameters");

                // Wait for input
                Console.ReadLine();
            }

            // Saves the current cursor position
            int currentPos = 0;

            // Saves the current key input
            ConsoleKey cKey;

            // Set the cursor position to 0
            Console.SetCursorPosition(0, currentPos);
            Console.Write("->");

            // Do..
            do
            {
                cKey = Console.ReadKey().Key;

                // If the user presses 'W' or 'Up Arrow'
                if (cKey == ConsoleKey.W || cKey == ConsoleKey.UpArrow)
                {
                    if (currentPos != 0)
                    {
                        // Blank the previous down spot
                        Console.SetCursorPosition(0, currentPos);
                        Console.Write("  ");

                        // Decrease the currentPos
                        currentPos--;

                        // Display an arrow on the new spot
                        Console.SetCursorPosition(0, currentPos);
                        Console.Write("->");
                    } else
                    {
                        // Rewrite the current spot
                        Console.SetCursorPosition(0, currentPos);
                        Console.Write("  ");
                    }
                } // If the user presses 'S' or 'Down Arrow'
                else if (cKey == ConsoleKey.S || cKey == ConsoleKey.DownArrow)
                {
                    if (currentPos != TitleBasics.Count - 1)
                    {
                        // Blank the previous up spot
                        Console.SetCursorPosition(0, currentPos);
                        Console.Write("  ");

                        // Decrease the currentPos
                        currentPos++;

                        // Display an arrow on the new spot
                        Console.SetCursorPosition(0, currentPos);
                        Console.Write("->");
                    } else
                    {
                        // Rewrite the current spot
                        Console.SetCursorPosition(0, currentPos);
                        Console.Write("->");
                    }
                } // If another key was pressed
                else
                {
                    // Rewrite the current spot
                    Console.SetCursorPosition(0, currentPos);
                    Console.Write("->");
                }

            } while (cKey != ConsoleKey.Enter);

            DisplayTitleProperties(currentPos);
        }

        /// <summary>
        /// Displays the selected title
        /// </summary>
        /// <param name="selection">Index for the selected title</param>
        private void DisplayTitleProperties(int selection)
        {
            // Clears the console
            Console.Clear();

            // Writes the title ID
            Console.WriteLine("Tittle ID:\t\t" + 
                ((TitleBasics)TitleBasics[selection]).TConst);

            // Writes the type of title
            Console.WriteLine("Tittle Type:\t\t" + 
                ((TitleBasics)TitleBasics[selection]).TitleType);

            // Writes the primary title of the video
            Console.WriteLine("Primary Tittle:\t\t" + 
                ((TitleBasics)TitleBasics[selection]).PrimaryTitle ?? @"\N");

            // Writes the original title of the video
            Console.WriteLine("Original Tittle:\t" + 
                ((TitleBasics)TitleBasics[selection]).OriginalTitle ?? @"\N");

            // Writes true or false if the video is Adult only
            Console.WriteLine("isAdult:\t\t" + 
                ((TitleBasics)TitleBasics[selection]).IsAdult);

            // Writes the year in which the video was released
            Console.WriteLine("Start Date:\t\t" + 
                ((TitleBasics)TitleBasics[selection]).StartYear ?? @"\N");

            // Writes the year the show was ended
            Console.WriteLine("End Date:\t\t" + 
                ((TitleBasics)TitleBasics[selection]).EndYear ?? @"\N");

            // Writes the Runtime in minutes the video runs for
            Console.WriteLine("Runtime:\t\t" + 
                ((TitleBasics)TitleBasics[selection]).RuntimeMinutes ?? @"\N" + "minutes");

            // Write "Genres on the console with 3 tabs"
            Console.Write("Genres:\t\t\t");

            // Write the Genres
            if(((TitleBasics)TitleBasics[selection]).Genres != null)
            {
                // Go through all the genres the title has
                for(int i = 0; i < ((TitleBasics)TitleBasics[selection]).Genres.Length; i++)
                {
                    // Write each one
                    Console.Write(((TitleBasics)TitleBasics[selection]).Genres[i]);

                    // If we're not on the last genre
                    if (i != ((TitleBasics)TitleBasics[selection]).Genres.Length - 1)
                    {
                        // Place a comma
                        Console.Write(", ");
                    }
                }
            } else
            {
                // If there's no genres writes "\N"
                Console.Write(@"\N");
            }

            // Wait for user input
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
            searchSettings.SetFilters();
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
