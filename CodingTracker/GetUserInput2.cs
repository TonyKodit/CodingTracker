using System.Globalization;
using System.Text;

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
            Console.WriteLine("Type 0 to Exit app");


            var commandInput = Console.ReadLine();

            while (string.IsNullOrEmpty(commandInput))
            {
                Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4.(Or 'p' to return to Top Menu)\n");
                commandInput = Console.ReadLine();
            }


            switch (commandInput)
            {
                case "0":
                    Console.WriteLine("\nGoodbye");
                    closeApp = true;
                    Environment.Exit(0);
                    break;
                case "p":
                    Console.Clear();
                    Program.Main(args);
                    break;
                case "1":
                    workoutController.Get();
                    break;
                case "2":
                    ProcessAdd();
                    break;
                case "3":
                    ProcessDelete();
                    break;
                case "4":
                    ProcessUpdate();
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

        workoutController.Post(workout);
    }

    private void ProcessUpdate()
    {
        workoutController.Get();
        Console.WriteLine("Enter the id of the data you want to update (or you enter 0 to return to Main Menu)");

        var commandInput = Console.ReadLine();

        while (!Int32.TryParse(commandInput, out _) || string.IsNullOrEmpty(commandInput) || Int32.Parse(commandInput) < 0)
        {
            Console.WriteLine("You will have to enter a valid Id (or ) to return to Main Menu).");
            commandInput = Console.ReadLine();
        }

        var id = Int32.Parse(commandInput);

        if (id == 0) MainMenu();

        var workout = workoutController.GetById(id);

        while (workout.Id == 0)
        {
            Console.WriteLine("Please type the id of the category you want to update (or 0 to return to Main Menu).");
            ProcessUpdate();
        }


        bool updating = true;
        while (updating == true)
        {
            Console.WriteLine("\n What do you want to update \n");
            Console.WriteLine($"\nType 'd' for Date\n");
            Console.WriteLine($"\nType 't' for Duration\n");
            Console.WriteLine($"\nType 's' to save Update\n");
            Console.WriteLine($"\nType '0' to go back to Main Menu \n");

            var updateInput = Console.ReadLine();


            switch (updateInput)
            {
                case "d":
                    workout.Date = GetDateInput();
                    break;

                case "t":
                    workout.Duration = GetDuration();
                    break;

                case "0":
                    MainMenu();
                    updating = false;
                    break;

                case "s":
                    updating = false;
                    break;

                default:
                    Console.WriteLine("Press 0 to go back to Main Menu");
                    break;
            }
        }

        workoutController.Update(workout);
        MainMenu();
    }



    private void ProcessDelete()
    {
        workoutController.Get();
        Console.WriteLine("Please type the id of the category you want to update (or 0 to return to Main Menu).");

        var commandInput = Console.ReadLine();

        while (!Int32.TryParse(commandInput, out _) || string.IsNullOrEmpty(commandInput) || Int32.Parse(commandInput) < 0)
        {
            Console.WriteLine("You have to type a valid Id (or 0 to return to Main Menu).\n");
            commandInput = Console.ReadLine();
        }

        var id = Int32.Parse(commandInput);

        if (id == 0) MainMenu();

        var workout = workoutController.GetById(id);

        while (workout.Id == 0)
        {
            //Console.WriteLine($"Record with id {id} doesn't exist");
            Console.WriteLine("Please add id of the category you want to delete (or 0 to return to Main Menu).");
            ProcessDelete();

            //commandInput = Console.ReadLine();
            //id = Int32.Parse(commandInput);

            //if (id == 0) MainMenu();

            workout = workoutController.GetById(id);
        }

        workoutController.Delete(id);

    }




    private string GetDateInput()
    {
        Console.WriteLine("Enter the date.(Format: dd-MM-yy) or enter 0 to exit app");
        var dateInput = Console.ReadLine();

        if (dateInput == "0") MainMenu();

        while (!DateTime.TryParseExact(dateInput, "dd-MM-yy", new CultureInfo("en-US"), DateTimeStyles.None,out _))
        {
            Console.WriteLine("Please enter valid date.(Format: dd-MM-yy)");
            
            dateInput = Console.ReadLine(); 
        }

        return dateInput;
    }

    private string GetDuration()
    {
        Console.WriteLine("Enter the duration.(Format: hh:mm), or enter 0 to exit app");

        var durationInput = Console.ReadLine();

        if(durationInput == "0") MainMenu();

        while (!TimeSpan.TryParseExact(durationInput, "h\\:mm",CultureInfo.InvariantCulture,out _))
        {
            Console.WriteLine("Plese enter a valid time.(Format: hh:mm)");

            durationInput = Console.ReadLine();
        }

        return durationInput;
    }

}