
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


            var selectionInput = Console.ReadLine();

            switch (selectionInput)
            {
                case "a":
                    Console.Clear();
                    break;
                case "c":
                    getUserInput.MainMenu();
                    break;

                case "w":
                    getuserInput2.MainMenu();
                    break;


                default:
                    Console.WriteLine("You will have to type a valid entry.(or type 'a' to return to the Top Menu.)");
                    break;
            }
        }
       
       

        





    }
}