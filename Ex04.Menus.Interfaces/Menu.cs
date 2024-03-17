using System;

namespace Ex04.Menus.Interfaces
{
    public class Menu : ChoiceNotifier
    {
        private string m_MenuName;
        private readonly List<MenuItem> m_MenuItems;
        private bool m_IsMainMenu;

        public string MenuName
        {
            get { return m_MenuName; }
            set { m_MenuName = value; }
        }

        protected internal Menu(string i_MenuName, bool i_IsMainMenu)
        {
            m_MenuName = i_MenuName;
            m_IsMainMenu = i_IsMainMenu;
            m_MenuItems = new List<MenuItem>();
        }

        public void CreateMenuOption
            (String i_ItemText, object i_ItemValue, 
            ChoiceNotifier i_Notifier)
        {
            MenuItem newOption = new MenuItem
                (i_ItemText, i_ItemValue, i_Notifier);
            m_MenuItems.Add (newOption);
        }

        public Menu CreateSubMenu(String i_SubMenuName)
        {
            const bool v_SubMenu = false;
            Menu addedSubMenu = new Menu(i_SubMenuName, v_SubMenu);

            CreateMenuOption(i_SubMenuName, addedSubMenu, this);

            return addedSubMenu;
        }

        internal void Show()
        {
            bool continueLoop = true;
            int userIntInput;

            while (continueLoop)
            {
                try
                {
                    printMenu();
                    reciveUserInput(out userIntInput);
                    if (userIntInput != 0)
                    {
                        m_MenuItems[userIntInput - 1].MenuItemChosen();
                    }
                    else
                    {
                        continueLoop = false;
                    }
                }
                catch(Exception i_ExceptionOccurred)
                {
                    Console.Clear();
                    Console.WriteLine($"!!!!{i_ExceptionOccurred.Message}!!!!\n");
                }
            }
        }

        private void printMenu ()
        {
            const int startingChoiceNumbering = 1;
            int choiceNumbering = startingChoiceNumbering;
            string endingMenuItemPrint = endingMenuItem(); 

            Console.WriteLine(
@"**{0}**
{1}", m_MenuName, new String('-', 20));
            foreach (MenuItem item in m_MenuItems)
            {
                Console.WriteLine(@"{0} -> {1}", choiceNumbering, item.ItemText);
                choiceNumbering++;
            }

            Console.WriteLine(
@"
0 -> {0}
{1}
Enter your request: ({2} to {3} or press '0' to {0})",
endingMenuItemPrint, new String('-', 20),
startingChoiceNumbering, m_MenuItems.Count);
        }

        private string endingMenuItem()
        {
            string endingMenuItem;

            if (m_IsMainMenu == true)
            {
                endingMenuItem = "Exit";
            }
            else
            {
                endingMenuItem = "Back";
            }

            return endingMenuItem;
        }

        private void reciveUserInput (out int o_userIntInput) 
        {
            string userInput;

            userInput = Console.ReadLine();
            if (!int.TryParse(userInput, out o_userIntInput))
            {
                throw new Exception("Incorrect input type! Please enter an int!");
            }

            if(o_userIntInput > m_MenuItems.Count || o_userIntInput < 0)
            {
                throw new Exception("Input out of range! Please Enter an int in the correct range!");
            }
        }

        public void Notify(Object sender)
        {
            ((Menu)((MenuItem)sender).ItemValue).Show();
            Console.Clear();
        }

    }
}
