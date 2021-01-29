using System;

namespace SocialNetworkV1
{
    static class SocialNetwork
    {
        public static string[] MainMenuOptions { get; set; }
        public static string[] UserMenuOptions { get; set; }
        public static string[] AdminMenuOptions { get; set; }

        static SocialNetwork()
        {
            MainMenuOptions = new string[] 
                {"Main Menu", "Admin", "User", "Exit"};
            UserMenuOptions = new string[] 
                {"User", "Show All Posts", "Show", "Like", "Create Post", "Logout"};
            AdminMenuOptions = new string[] 
                {"Admin", "Show All Posts", "Show All Notification", "Show Notification", "Show Post", "Like", "Create Post", "Remove Post", "Logout"};
        }

        public static void PrintMenu(in string[] options)
        {
            if (options != null)
            {
                Console.Clear();
                Console.Title = "Social Network: " + options[0];
                for (int i = 1; i < options.Length; i++)
                {
                    Console.Write($"{i}. {options[i]}\n");
                }
            }
        }

        public static int InputChoice(in int length)
        {
            var choice = 0;
            do
            {
                Console.Write(">> ");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    ClearConsole(length - 1, 10);
                }
            } while (choice < 1 || choice > length);

            return choice;
        }

        public static void ClearConsole(int lineCount, int clearableLine)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Press enter to continue");
            Console.ResetColor();
            Console.ReadLine();
            Console.SetCursorPosition(0, lineCount + clearableLine);
            for (int i = 0; i < clearableLine; i++)
            {
                ClearLastLine();
            }
        }

        public static void ClearLastLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
    }
}