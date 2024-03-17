using System;
using Interfaces = Ex04.Menus.Interfaces;
using Delegates = Ex04.Menus.Delegates;
using Ex04.Menus.Interfaces;


namespace Ex04.Menus.Test
{
    public class Program
    {
        internal enum eChoiceOptions
        {
            ShowDate,
            ShowTime,
            CountCapitals,
            ShowVersion
        }

        internal static class Actions
        {
            internal static void showDate()
            {
                Console.WriteLine(DateTime.Now.ToShortDateString());
            }

            internal static void showTime()
            {
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
            }

            internal static void countCapitals()
            {
                string userInput;
                int count = 0;

                Console.WriteLine("Please enter your sentence:");
                userInput = Console.ReadLine();
                foreach (char charcter in userInput)
                {
                    if (char.IsUpper(charcter))
                    {
                        count++;
                    }
                }

                Console.WriteLine(@"There are {0} capitals in your sentance.", count);
            }

            internal static void showVersion()
            {
                const string version = "24.1.4.9633";
                Console.WriteLine(@"Version: {0}", version);
            }
        }

        public static void Main()
        {
            InterfaceMainMenuTest interfaceMainMenuTest = new InterfaceMainMenuTest();
            DelegatesMainMenuTest delegatesMainMenuTest = new DelegatesMainMenuTest();

            Console.WriteLine("---Starting interfaces menu---");
            interfaceMainMenuTest.InterfaceMainMenu.show();
            Console.Clear();
            Console.WriteLine("---Starting delegates menu---");
            delegatesMainMenuTest.DelegatesMainMenu.show();
        }

        

    }
}
