using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaBazaarProject.Logic;

namespace MediaBazaarProject
{
    public partial class AbsenceADWindow : Form
    {
        AbsenceManager absencemanage;
        int id;
        public AbsenceADWindow(AbsenceManager am,int id)
        {
            InitializeComponent();
            absencemanage = am;
            this.id = id;
           lbdescription.Items.Add(absencemanage.GetDescription(this.id));
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                
                Absence a = absencemanage.GetAbsenceRequest(id);
                if (a != null)
                {
                    absencemanage.AcceptAbsence(a, true);
                }
                else { MessageBox.Show("Absence request with this id doesn't exist"); }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please place some id");
            }
            this.Close();
            lbdescription.Items.Clear();
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            try
            {
                Absence a = absencemanage.GetAbsenceRequest(id);
                if (a != null)
                {
                    absencemanage.DeclineAbsence(a);
                }
                else { MessageBox.Show("Absence request with this id doesn't exist"); }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please place some id");
            }
            this.Close();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
