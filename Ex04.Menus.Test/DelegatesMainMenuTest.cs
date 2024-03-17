using System;
using Delegates = Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    internal class DelegatesMainMenuTest
    {
        private Delegates.MainMenu m_DelegatesMainMenu;

        internal Delegates.MainMenu DelegatesMainMenu
        {
            get { return m_DelegatesMainMenu; }
        }

        internal DelegatesMainMenuTest()
        {
            m_DelegatesMainMenu = new Delegates.MainMenu();
            Delegates.Menu delegatesShowDateOrTime =
                m_DelegatesMainMenu.StartMenu.CreateSubMenu("Show Date/Time");
            Delegates.Menu delegatesVersionAndCapitals =
                m_DelegatesMainMenu.StartMenu.CreateSubMenu("Version and Capitals");
            Delegates.MenuItem addedMenuItem;

            addedMenuItem = delegatesShowDateOrTime.CreateMenuOption
                ("Show Date", Program.eChoiceOptions.ShowDate);
            addedMenuItem.ItemChosen += new Delegates.ItemChosenHandler(actionItem_ChosenItem_EvenHandler);
            addedMenuItem = delegatesShowDateOrTime.CreateMenuOption
                ("Show Time", Program.eChoiceOptions.ShowTime);
            addedMenuItem.ItemChosen += new Delegates.ItemChosenHandler(actionItem_ChosenItem_EvenHandler);
            addedMenuItem = delegatesVersionAndCapitals.CreateMenuOption
                ("Count Capitals", Program.eChoiceOptions.CountCapitals);
            addedMenuItem.ItemChosen += new Delegates.ItemChosenHandler(actionItem_ChosenItem_EvenHandler);
            addedMenuItem = delegatesVersionAndCapitals.CreateMenuOption
                ("Show Version", Program.eChoiceOptions.ShowVersion);
            addedMenuItem.ItemChosen += new Delegates.ItemChosenHandler(actionItem_ChosenItem_EvenHandler);
        }

        private void actionItem_ChosenItem_EvenHandler(Object sender)
        {
            Program.eChoiceOptions userChoice = (Program.eChoiceOptions)((Delegates.MenuItem)sender).ItemValue;
            switch (userChoice)
            {
                case Program.eChoiceOptions.ShowDate:
                    Program.Actions.showDate();
                    break;
                case Program.eChoiceOptions.ShowTime:
                    Program.Actions.showTime();
                    break;
                case Program.eChoiceOptions.CountCapitals:
                    Program.Actions.countCapitals();
                    break;
                case Program.eChoiceOptions.ShowVersion:
                    Program.Actions.showVersion();
                    break;
                default:
                    break;
            }
            Console.WriteLine();
        }
    }
}


