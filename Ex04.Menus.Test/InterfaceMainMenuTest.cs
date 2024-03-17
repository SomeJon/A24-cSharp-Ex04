using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class InterfaceMainMenuTest : ChoiceNotifier
    {
        private Interfaces.MainMenu m_InterfacesMainMenu;

        public Interfaces.MainMenu InterfaceMainMenu
        {
            get { return m_InterfacesMainMenu; }
        }

        public InterfaceMainMenuTest()
        {
            m_InterfacesMainMenu = new Interfaces.MainMenu();
            Interfaces.Menu interfacesShowDateOrTime =
                m_InterfacesMainMenu.StartMenu.CreateSubMenu("Show Date/Time");
            Interfaces.Menu interfacesVersionAndCapitals =
                m_InterfacesMainMenu.StartMenu.CreateSubMenu("Version and Capitals");

            interfacesShowDateOrTime.CreateMenuOption
                ("Show Date", Program.eChoiceOptions.ShowDate, this);
            interfacesShowDateOrTime.CreateMenuOption
                ("Show Time", Program.eChoiceOptions.ShowTime, this);
            interfacesVersionAndCapitals.CreateMenuOption
                ("Count Capitals", Program.eChoiceOptions.CountCapitals, this);
            interfacesVersionAndCapitals.CreateMenuOption
                ("Show Version", Program.eChoiceOptions.ShowVersion, this);
        }

        public void Notify(object sender)
        {
            Program.eChoiceOptions userChoice =
                (Program.eChoiceOptions)((Interfaces.MenuItem)sender).ItemValue;
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
