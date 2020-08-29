using System;
using System.Collections.Generic;
using System.Text;

namespace AgrixemMobile.ViewModels
{
    public class Sidebar
    {
        public Sidebar()
        {

        }

        public string Name
        {
            get
            {
                return Settings.Name + " " + Settings.Surname;
            }
        }
    }
}
