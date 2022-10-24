internal class GetUserInput2 
{
    WorkoutController workoutController = new();
    private string[] args;

    internal void MainMenu()
    {
        bool closeApp = false;
        while (closeApp == false)
        {
            Console.WriteLine("\n\nMAIN MENU(Workout Tracker)");
            Console.WriteLine("\nWhat woud you like to do");
            Console.WriteLine("Type 1 to view record");
            Console.WriteLine("Type 2 to Add record");
            Console.WriteLine("Type 3 to Delete record");
            Console.WriteLine("Type 4 to Update record");
            Console.WriteLine("Type p to return to Top Menu");


            var commandInput = Console.ReadLine();

            while (string.IsNullOrEmpty(commandInput))
            {
                Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4.(Or 'p' to return to Top Menu)\n");
                commandInput = Console.ReadLine();
            }


            switch (commandInput)
            {
                case "0":
                    closeApp = true;
                    Environment.Exit(0);
                    Console.WriteLine("\nGoodbye");
                    break;
                case "p":
                    Console.Clear();
                    Program.Main(args);
                    break;
                case "1":
                   // workoutController.Get();
                    break;
                case "2":
                    ProcessAdd();
                    break;
                case "3":
                   // ProcessDelete();
                    break;
                case "4":
                   // ProcessUpdate();
                    break;
                default:
                    Console.WriteLine("\n\nInvalid Command. Please type a number from 0 to 4");
                    break;
            }

        }
    }

    private void ProcessAdd()
    {
        string date = GetDateInput();
        string duration = GetDuration();

        Workout workout = new();

        workout.Date = date;
        workout.Duration = duration;

        WorkoutController.Post();
    }





    private string GetDateInput()
    {
        throw new NotImplementedException();
    }

    private string GetDuration()
    {
        throw new NotImplementedException();
    }

}