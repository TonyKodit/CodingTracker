using System.Globalization;

internal class GetUserInput
{
    CodingController codingController = new();
    private string[] args;

    internal void MainMenu()
    {
        bool closeApp = false;
        while (closeApp == false)
        {
            Console.WriteLine("\n\nMAIN MENU(Coding Tracker)");
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
                    codingController.Get();
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
        
        string  date = GetDateInput();
        
        string duration = GetDuration();

        Coding coding = new();

        coding.Date = date;
        coding.Duration = duration;

        codingController.Post(coding);

    }

    private void ProcessDelete()
    {
        codingController.Get();
        Console.WriteLine("Please the type the Id of the category you want to delete. (or 0 to return to Main Menu).");

        var commandInput = Console.ReadLine();

        while (!Int32.TryParse(commandInput, out _) || string.IsNullOrEmpty(commandInput) || Int32.Parse(commandInput) < 0)
        {
            Console.WriteLine("You have to type a valid Id (or 0 to return to Main Menu).\n");
            commandInput = Console.ReadLine();
        }

        var id = Int32.Parse(commandInput);

        if (id == 0) MainMenu();

        var coding = codingController.GetById(id);

        while (coding.Id == 0)
        {
            //Console.WriteLine($"Record with id {id} doesn't exist");
            Console.WriteLine("Please add id of the category you want to delete (or 0 to return to Main Menu).");
            ProcessDelete();

            //commandInput = Console.ReadLine();
            //id = Int32.Parse(commandInput);

            //if (id == 0) MainMenu();

            coding = codingController.GetById(id);
        }

        codingController.Delete(id);
    }



    private void ProcessUpdate()
    {
        codingController.Get();

        Console.WriteLine("Please type the id of the data you want to update (or 0 to return to Main Menu).");

        var commandInput = Console.ReadLine();


        while (!Int32.TryParse(commandInput, out _) || string.IsNullOrEmpty(commandInput) || Int32.Parse(commandInput) < 0)
        {
            Console.WriteLine("You will have to enter a valid Id (or ) to return to Main Menu).");
            commandInput = Console.ReadLine();
        }

        var id = Int32.Parse(commandInput);

        if (id == 0) MainMenu();

        var coding = codingController.GetById(id);

        while (coding.Id == 0)
        {
            Console.WriteLine("Please add id of the category you want to update (or 0 to return to Main Menu).");
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
                    coding.Date =GetDateInput();
                    break;

                case "t":
                    coding.Duration = GetDuration();
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

        codingController.Update(coding);
        MainMenu();

    }





    internal string GetDateInput()
    {
        Console.WriteLine("\nPlease insert the date: (Format: dd-mm-yy). Type 0 to return to main menu.\n");

        var dateInput = Console.ReadLine();

        if (dateInput == "0") MainMenu();

        while(!DateTime.TryParseExact(dateInput, "dd-MM-yy", new CultureInfo("en-US"), DateTimeStyles.None, out _))
        {
            Console.WriteLine("\n\nNot a valid date, Please insert the date with the format: dd-mm-yy\n\n");
            dateInput = Console.ReadLine();
        }

        return dateInput;
    }


    internal string GetDuration()
    {
        Console.WriteLine("\n\n Please insert your coding duration: (Format: hh:mm). Type 0 to return to main menu.\n\n");

        var durationInput = Console.ReadLine();

        if(durationInput == "0") MainMenu();

        while(!TimeSpan.TryParseExact(durationInput, "h\\:mm", CultureInfo.InvariantCulture, out _))
        {
            Console.WriteLine("\n\nInvalid Duration. Please insert the duration: (Format: hh:mm) or type 0 to return to main menu\n\n");
            durationInput = Console.ReadLine();
            if(durationInput == "0") MainMenu();
        }

        //no need for validation for negative date, while loop does that already
       
        var parseDuration = TimeSpan.Parse(durationInput);

        //long date = parseDuration.Ticks;
        //if(date < 0)
        //{
        //    Console.WriteLine("\n\nNegative Time is not allowed.\n\n)
        //    GetDurationInput();
        //}
        



        return durationInput;
    }
}