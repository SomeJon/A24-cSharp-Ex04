using System;

namespace Ex04.Menus.Delegates
{
    public delegate void ItemChosenHandler(object sender);
    public class MenuItem
    {
        private string m_ItemText;
        private object m_ItemValue;
        public event ItemChosenHandler? ItemChosen; //This mean I am notifying when I am chosen

        public string ItemText
        {
            get { return m_ItemText; }
        }

        public object ItemValue
        {
            get { return m_ItemValue; }
        }

        public MenuItem
            (string i_ItemText, object i_ItemValue)
        {
            m_ItemText = i_ItemText;
            m_ItemValue = i_ItemValue;
        }

        public void MenuItemChosen()
        {
            Console.Clear();
            OnItemChosen();
        }

        protected virtual void OnItemChosen()
        {
            ItemChosen?.Invoke(this);
        }
    }
}
