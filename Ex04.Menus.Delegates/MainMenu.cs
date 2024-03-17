using System;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private Menu m_StartMenu;

        public Menu StartMenu
        {
            get { return m_StartMenu; }
        }

        public MainMenu() : this("Main Menu") { }

        public MainMenu(string i_MainMenuName)
        {
            const bool v_MainMenu = true;

            m_StartMenu = new Menu(i_MainMenuName, v_MainMenu);
        }

        public void show()
        {
            m_StartMenu.Show();
        }
    }
}
