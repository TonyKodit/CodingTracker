
using System.Configuration;

class Program
{
    static string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");

    public static void Main(string[] args)
    {
        DatabaseManager databaseManager = new();
        GetUserInput getUserInput = new();

        GetUserInput2 getuserInput2 = new();

        bool closeApp = false;

        while (closeApp == false)
        {
            databaseManager.CreateTable(connectionString);
            Console.WriteLine("\nTOP MENU\n");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("Press 'c' for Coding Tracker");
            Console.WriteLine("Press 'w' for Workout Tracker");
            Console.WriteLine("Press '0' to exit app");


            var selectionInput = Console.ReadLine();

            switch (selectionInput)
            {
                
                case "c":
                    getUserInput.MainMenu();
                    break;

                case "w":
                    getuserInput2.MainMenu();
                    break;
                case "0":
                    Console.WriteLine("\nGoodbye");
                    closeApp = true;
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("You will have to enter a valid entry.");
                    break;
            }
        }
       
       

        





    }
}