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
