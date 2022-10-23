internal class GetUserInput
{
    internal void MainMenu()
    {
        bool closeApp = false;
        while (closeApp == false)
        {
            Console.WriteLine("\n\nMAIN MENU");
            Console.WriteLine("\nWhat woud you like to do");
            Console.WriteLine("Type 1 to view record");
            Console.WriteLine("Type 2 to Add record");
            Console.WriteLine("Type 3 to Delete record");
            Console.WriteLine("Type 4 to Update record");
        }
    }
}