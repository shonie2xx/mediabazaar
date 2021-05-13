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
    public partial class FormLogin : Form
    {
        ConnectionClass conn;
        public FormLogin()
        {
            InitializeComponent();
            conn = new ConnectionClass();


        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = tbxUsername.Text;
            string password = tbxPassword.Text;
            if (conn.Login(email, password))
            {
                Managment mg = new Managment(email);
                AbsenceForm af = new AbsenceForm();
                af.Show();
                mg.Show();
            }
            else
            {
                MessageBox.Show("Invalid data!");
            }

        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblMin_Click(object sender, EventArgs e)
        {

        }

        private void tbxUsername_Click(object sender, EventArgs e)
        {
            tbxUsername.Clear();
        }

        private void tbxPassword_Click(object sender, EventArgs e)
        {
            tbxPassword.Clear();
        }
    }
}
