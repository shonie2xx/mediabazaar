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
    public partial class AbsenceForm : Form
    {
        ConnectionClass conn;
        AbsenceManager am;
        public AbsenceForm()
        {
            InitializeComponent();
            conn = new ConnectionClass();
            am = new AbsenceManager();
            DataUpdate();
        }
        public void DataUpdate()
        {
            dataGridView1.Rows.Clear();
            am.LoadAllAbsenceRequest();
            BindingList<Absence> bindlist = new BindingList<Absence>(am.GetAllAbsenceRequest());
            dataGridView1.DataSource = bindlist;
            this.dataGridView1.Columns["EmployeeId"].Visible = false;
            this.dataGridView1.Columns["Description"].Visible = false;

        }
        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int selectedid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AbsenceId"].Value);
            if (am.GetAbsenceRequest(selectedid) != null)
            {
                //MessageBox.Show(am.GetDescription(selectedid));
                AbsenceADWindow aw = new AbsenceADWindow(am, selectedid);
                aw.Show();
            }
            else
            {
                MessageBox.Show("error");
            }
        }

        private void AbsenceForm_MouseClick(object sender, MouseEventArgs e)
        {
            DataUpdate();
        }
    }
}
