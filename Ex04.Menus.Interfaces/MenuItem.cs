using System;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private string m_ItemText;
        private object m_ItemValue;
        private ChoiceNotifier m_Notify;

        public string ItemText
        {
            get { return m_ItemText; }
        }

        public object ItemValue
        {
            get { return m_ItemValue; }
        }

        public MenuItem
            (string i_ItemText, object i_ItemValue,
            ChoiceNotifier i_Notify)
        {
            m_ItemText = i_ItemText;
            m_ItemValue = i_ItemValue;
            m_Notify = i_Notify;
        }

        public void MenuItemChosen()
        {
            if (m_Notify != null)
            {
                Console.Clear();
                m_Notify.Notify(this);
            }
        }
    }
}
