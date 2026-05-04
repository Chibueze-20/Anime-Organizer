using AnimeOrganizerCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeOrganizer.Forms
{
    public class BaseForm : System.Windows.Forms.Form
    {
        internal int _formIndex;
        //TODO: Complete BaseForm and make all forms inherit from it. This will allow for better code reuse and organization.
        // TODO TASKS:
        // 1. Add a method to get the seperator from the settings and return it as a Seperator enum. This will allow for better code reuse and organization.
        // 2. Add Event handlers for switching between forms. This will allow for better code reuse and organization.
        // 3. Add Close method that will close current form and open the Organizer form or Exit the application if the current form is the Organizer form. This will allow for better code reuse and organization.
        // 4. Add method to check if auto ordanization can be performed. This will allow for better code reuse and organization.
        public Seperator getSeperatorFromSettings()
        {
            Console.WriteLine("Getting seperator from settings: " + Properties.Settings.Default.episodeSep.ToString());
            try
            {
                return (Seperator)Enum.Parse(typeof(Seperator), Properties.Settings.Default.episodeSep.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Sep convert Exception: " + e.Message);
                return Seperator.none;
            }
        }

        private new void Close()
        {
            if (_formIndex != 0)
            {
                new Organizer().Show();
                this.Hide();
            }
        }

        public void OpenDatabaseEvent(object sender, EventArgs e)
        {

            new DatabaseForm().Show();
            this.Hide();
        }
        public void OpenOrganizerEvent(object sender, EventArgs e)
        {
            new Organizer().Show();
            this.Hide();
        }

        private void OpenAutoOrganizerEvent(object sender, EventArgs e)
        {
            new QuickOrganizerV2().Show();
            this.Hide();
        }
    }
}
