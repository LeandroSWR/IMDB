using System;

namespace IMDBSearcher
{
    /// <summary>
    /// Starts the program
    /// </summary>
    class Program
    {
        /// <summary>
        /// The Main method from the Program Class
        /// </summary>
        /// <param name="args">Arguments accepted by the console</param>
        static void Main(string[] args)
        {
            // Creates an instance of the Display class
            Menus myDisplay = new Menus();

            // Calls the method to draw the Menu
            myDisplay.DrawMainMenu(); 
        }
    }
}
