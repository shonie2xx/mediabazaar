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
    public partial class ScheduleControl : Form
    {
        #region Day variables
        private DateTime day1;
        private DateTime day2;
        private DateTime day3;
        private DateTime day4;
        private DateTime day5;
        private DateTime day6;
        private DateTime day7;
        private DateTime selectedDay;
        #endregion
        Schedule schedule;
        Managment mng;
        bool preferenceMode = false;

        public ScheduleControl(Schedule formObject, Managment mng)
        {
            this.schedule = formObject;
            this.mng = mng;
            InitializeComponent();
            lblShiftsDepartment.Text = "Department: " + formObject.DepartmentStr;
            if (formObject.DepartmentD == Department.SALES)
            {
                cmbxChooseFloor.Visible = true;
                lblChooseFloor.Visible = true;
            }
            else
            {
                cmbxChooseFloor.Visible = false;
                lblChooseFloor.Visible = false;
            }
            InitializeSchedulerOptionsMenu();
        }
        #region Utility(Labels/DataGridViewsUpdates)
        private void UpdateLivingText()
        {
            gbxDay1.Text = schedule.CheckDate(day1);
            lblDateShow1.Text = schedule.CheckDateNum(day1);
            gbxDay2.Text = schedule.CheckDate(day2);
            lblDateShow2.Text = schedule.CheckDateNum(day2);
            gbxDay3.Text = schedule.CheckDate(day3);
            lblDateShow3.Text = schedule.CheckDateNum(day3);
            gbxDay4.Text = schedule.CheckDate(day4);
            lblDateShow4.Text = schedule.CheckDateNum(day4);
            gbxDay5.Text = schedule.CheckDate(day5);
            lblDateShow5.Text = schedule.CheckDateNum(day5);
            gbxDay6.Text = schedule.CheckDate(day6);
            lblDateShow6.Text = schedule.CheckDateNum(day6);
            gbxDay7.Text = schedule.CheckDate(day7);
            lblDateShow7.Text = schedule.CheckDateNum(day7);
            lblDay1Shift1.Text = schedule.CheckShiftAssignedCountString(day1, 1);
            lblDay1Shift2.Text = schedule.CheckShiftAssignedCountString(day1, 2);
            lblDay1Shift3.Text = schedule.CheckShiftAssignedCountString(day1, 3);
            lblDay2Shift1.Text = schedule.CheckShiftAssignedCountString(day2, 1);
            lblDay2Shift2.Text = schedule.CheckShiftAssignedCountString(day2, 2);
            lblDay2Shift3.Text = schedule.CheckShiftAssignedCountString(day2, 3);
            lblDay3Shift1.Text = schedule.CheckShiftAssignedCountString(day3, 1);
            lblDay3Shift2.Text = schedule.CheckShiftAssignedCountString(day3, 2);
            lblDay3Shift3.Text = schedule.CheckShiftAssignedCountString(day3, 3);
            lblDay4Shift1.Text = schedule.CheckShiftAssignedCountString(day4, 1);
            lblDay4Shift2.Text = schedule.CheckShiftAssignedCountString(day4, 2);
            lblDay4Shift3.Text = schedule.CheckShiftAssignedCountString(day4, 3);
            lblDay5Shift1.Text = schedule.CheckShiftAssignedCountString(day5, 1);
            lblDay5Shift2.Text = schedule.CheckShiftAssignedCountString(day5, 2);
            lblDay5Shift3.Text = schedule.CheckShiftAssignedCountString(day5, 3);
            lblDay6Shift1.Text = schedule.CheckShiftAssignedCountString(day6, 1);
            lblDay6Shift2.Text = schedule.CheckShiftAssignedCountString(day6, 2);
            lblDay6Shift3.Text = schedule.CheckShiftAssignedCountString(day6, 3);
            lblDay7Shift1.Text = schedule.CheckShiftAssignedCountString(day7, 1);
            lblDay7Shift2.Text = schedule.CheckShiftAssignedCountString(day7, 2);
            lblDay7Shift3.Text = schedule.CheckShiftAssignedCountString(day7, 3);
        }
        public void UpdateDataGridView(DateTime date)
        {
            dataGridAssignable.Rows.Clear();
            dataGridAssigned.Rows.Clear();
            List<Employee> assignable = schedule.GiveAllEmployeesForDayNotAssigned(date);
            foreach (Employee e in assignable)
            {
                int n = dataGridAssignable.Rows.Add();
                dataGridAssignable.Rows[n].Cells["FirstNameAssignable"].Value = e.FName;
                dataGridAssignable.Rows[n].Cells["LastNameAssignable"].Value = e.LName;
                dataGridAssignable.Rows[n].Cells["WorkerIDAssignable"].Value = e.WorkrID;
                dataGridAssignable.Rows[n].Cells["DepartmentAssignable"].Value = e.Department;
            }

            List<Shift> assignedControl = schedule.GiveAllShiftForDay(date);
            foreach (Shift s in assignedControl)
            {
                foreach (Employee e in s.EmployeesAssigned)
                {
                    int n = dataGridAssigned.Rows.Add();
                    dataGridAssigned.Rows[n].Cells["FirstName"].Value = e.FName;
                    dataGridAssigned.Rows[n].Cells["LastName"].Value = e.LName;
                    dataGridAssigned.Rows[n].Cells["WorkerIDAssigned"].Value = e.WorkrID;
                    dataGridAssigned.Rows[n].Cells["DepartmentAssigned"].Value = s.DepartmentGet;
                    dataGridAssigned.Rows[n].Cells["ShiftNumber"].Value = s.ShiftNumber;
                    dataGridAssigned.Rows[n].Cells["ShiftID"].Value = s.ShiftID;

                }
            }
        }
        private void UpdatePreferencesGridView()
        {
            dataGridViewPreferences.Rows.Clear();
            List<Employee> assignable = schedule.GiveAllEmployeesForDayNotAssigned(selectedDay);
            List<Preference> prefs = schedule.PreferencesFilterByWeekday(selectedDay);
            foreach (Preference p in prefs)
            {
                foreach (Employee e in assignable)
                {
                    if (p.EmployeeID == e.WorkrID)
                    {
                        int n = dataGridViewPreferences.Rows.Add();
                        dataGridViewPreferences.Rows[n].Cells["PrefEmpFName"].Value = e.FName;
                        dataGridViewPreferences.Rows[n].Cells["PrefEmpLName"].Value = e.LName;
                        dataGridViewPreferences.Rows[n].Cells["PrefEmpID"].Value = e.WorkrID;
                        dataGridViewPreferences.Rows[n].Cells["PrefShiftNumber"].Value = p.ShiftNumber;
                    }
                }

            }
        }
        private void InitializeSchedulerOptionsMenu()
        {
           AsssigningLimit limit= schedule.SchedulerLimit;
            tbxLimitDP.Text = limit.DEPOT_Limit.ToString();
            tbxLimitHR.Text = limit.HR_Limit.ToString();
            tbxLimitPR.Text = limit.PR_Limit.ToString();
            tbxLimitSLF1.Text = limit.SALES_F1_Limit.ToString();
            tbxLimitSLF2.Text = limit.SALES_F2_Limit.ToString();
            tbxLimitSLF3.Text = limit.SALES_F3_Limit.ToString();
            tbxLimitSLF4.Text = limit.SALES_F4_Limit.ToString();
            if (schedule.DepartmentD == Department.HUMANRESOURCES)
            {
                tbxLimitDP.Enabled = false;
                tbxLimitPR.Enabled = false;
                tbxLimitSLF1.Enabled = false;
                tbxLimitSLF2.Enabled = false;
                tbxLimitSLF3.Enabled = false;
                tbxLimitSLF4.Enabled = false;
            }
            if(schedule.DepartmentD == Department.DEPOT)
            {
                tbxLimitHR.Enabled = false;
                tbxLimitPR.Enabled = false;
                tbxLimitSLF1.Enabled = false;
                tbxLimitSLF2.Enabled = false;
                tbxLimitSLF3.Enabled = false;
                tbxLimitSLF4.Enabled = false;
            }
            if(schedule.DepartmentD == Department.SALES)
            {
                tbxLimitDP.Enabled = false;
                tbxLimitPR.Enabled = false;
                tbxLimitDP.Enabled = false;
            }
            if(schedule.DepartmentD == Department.PR)
            {
                tbxLimitDP.Enabled = false;
                tbxLimitHR.Enabled = false;
                tbxLimitSLF1.Enabled = false;
                tbxLimitSLF2.Enabled = false;
                tbxLimitSLF3.Enabled = false;
                tbxLimitSLF4.Enabled = false;
            }
        }
        #endregion
        #region Operational Buttons(All "Manage" buttons, WeekSwitching buttons, Assigning/Unassigning employees to shift, Preference mode enable/disable,Floor switch)
        private void btnDay1_Click(object sender, EventArgs e)
        {
            UpdateDataGridView(day1);
            panelShiftManagement.Visible = true;
            selectedDay = day1;
        }

        private void btnDay2_Click(object sender, EventArgs e)
        {
            UpdateDataGridView(day2);
            panelShiftManagement.Visible = true;
            selectedDay = day2;
        }

        private void btnDay3_Click(object sender, EventArgs e)
        {
            UpdateDataGridView(day3);
            panelShiftManagement.Visible = true;
            selectedDay = day3;
        }

        private void btnDay4_Click(object sender, EventArgs e)
        {
            UpdateDataGridView(day4);
            panelShiftManagement.Visible = true;
            selectedDay = day4;
        }

        private void btnDay5_Click(object sender, EventArgs e)
        {
            UpdateDataGridView(day5);
            panelShiftManagement.Visible = true;
            selectedDay = day5;
        }

        private void btnDay6_Click(object sender, EventArgs e)
        {
            UpdateDataGridView(day6);
            panelShiftManagement.Visible = true;
            selectedDay = day6;
        }

        private void btnDay7_Click(object sender, EventArgs e)
        {
            UpdateDataGridView(day7);
            panelShiftManagement.Visible = true;
            selectedDay = day7;
        }

        private void btnBackToWeek_Click(object sender, EventArgs e)
        {
            panelShiftManagement.Visible = false;
            UpdateLivingText();
        }
        private void btnNextWeek_Click(object sender, EventArgs e)
        {
            btnCurrentWeek.Visible = true;
            day1 = TimeControl.FirstDayOfWeek(DateTime.Today).AddDays(7);
            day2 = TimeControl.FirstDayOfWeek(DateTime.Today).AddDays(8);
            day3 = TimeControl.FirstDayOfWeek(DateTime.Today).AddDays(9);
            day4 = TimeControl.FirstDayOfWeek(DateTime.Today).AddDays(10);
            day5 = TimeControl.FirstDayOfWeek(DateTime.Today).AddDays(11);
            day6 = TimeControl.FirstDayOfWeek(DateTime.Today).AddDays(12);
            day7 = TimeControl.FirstDayOfWeek(DateTime.Today).AddDays(13);
            UpdateLivingText();
            btnNextWeek.Visible = false;
            btnChartToggle.Visible = false;
        }
        private void btnCurrentWeek_Click(object sender, EventArgs e)
        {
            btnNextWeek.Visible = true;
            day1 = TimeControl.FirstDayOfWeek(DateTime.Today);
            day2 = TimeControl.FirstDayOfWeek(DateTime.Today).AddDays(1);
            day3 = TimeControl.FirstDayOfWeek(DateTime.Today).AddDays(2);
            day4 = TimeControl.FirstDayOfWeek(DateTime.Today).AddDays(3);
            day5 = TimeControl.FirstDayOfWeek(DateTime.Today).AddDays(4);
            day6 = TimeControl.FirstDayOfWeek(DateTime.Today).AddDays(5);
            day7 = TimeControl.FirstDayOfWeek(DateTime.Today).AddDays(6);
            UpdateLivingText();
            btnCurrentWeek.Visible = false;
            btnChartToggle.Visible = true;
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            int selectWorkerID;
            if (preferenceMode == true)
            {
                selectWorkerID = Convert.ToInt32(dataGridViewPreferences.CurrentRow.Cells["PrefEmpID"].Value);
            }
            else
            {
                selectWorkerID = Convert.ToInt32(dataGridAssignable.CurrentRow.Cells["WorkerIDAssignable"].Value);
            }

            int shiftNumber = 1;
            if (rbtnShift1.Checked)
            {
                shiftNumber = 1;
            }
            if (rbtnShift2.Checked)
            {
                shiftNumber = 2;
            }
            if (rbtnShift3.Checked)
            {
                shiftNumber = 3;
            }
            if (rbtnShift4.Checked)
            {
                shiftNumber = 4;
            }
            if (rbtnShift5.Checked)
            {
                shiftNumber = 5;
            }
            if (rbtnShift6.Checked)
            {
                shiftNumber = 6;
                
            }
            schedule.AssignEmployeeToShift(selectWorkerID,selectedDay,shiftNumber);

            UpdateDataGridView(selectedDay);
            UpdatePreferencesGridView();
        }
        private void btnUnassign_Click(object sender, EventArgs e)
        {
            int selectWorkerID = Convert.ToInt32(dataGridAssigned.CurrentRow.Cells["WorkerIDAssigned"].Value);
            int selectShiftID = Convert.ToInt32(dataGridAssigned.CurrentRow.Cells["ShiftID"].Value);
            schedule.UnassignEmployeeFromShift(selectWorkerID, selectShiftID);
            UpdateDataGridView(selectedDay);
            UpdatePreferencesGridView();

        }

        private void cbxPreference_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbxPreference.Checked)
            {
                preferenceMode = false;
                dataGridViewPreferences.Visible = false;
                dataGridAssignable.Visible = true;
            }
            else
            {
                preferenceMode = true;
                dataGridViewPreferences.Visible = true;
                dataGridAssignable.Visible = false;
                UpdatePreferencesGridView();
            }

        }
        private void cmbxChooseFloor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxChooseFloor.SelectedIndex == 0)
            {
                schedule.StoreFloor = "Household appliances";
            }
            if (cmbxChooseFloor.SelectedIndex == 1)
            {
                schedule.StoreFloor = "Laptops";
            }
            if (cmbxChooseFloor.SelectedIndex == 2)
            {
                schedule.StoreFloor = "Hardware";
            }
            if (cmbxChooseFloor.SelectedIndex == 3)
            {
                schedule.StoreFloor = "Music, movies and games";
            }
            UpdateLivingText();

        }
        #endregion
        #region Controlling the Form
        private void ScheduleControl_FormClosing(object sender, FormClosingEventArgs e)
        {

            mng.Show();
        }
        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ScheduleControl_Load(object sender, EventArgs e)
        {
            day1 = TimeControl.FirstDayOfWeek(DateTime.Today);
            day2 = TimeControl.FirstDayOfWeek(DateTime.Today).AddDays(1);
            day3 = TimeControl.FirstDayOfWeek(DateTime.Today).AddDays(2);
            day4 = TimeControl.FirstDayOfWeek(DateTime.Today).AddDays(3);
            day5 = TimeControl.FirstDayOfWeek(DateTime.Today).AddDays(4);
            day6 = TimeControl.FirstDayOfWeek(DateTime.Today).AddDays(5);
            day7 = TimeControl.FirstDayOfWeek(DateTime.Today).AddDays(6);
            UpdateLivingText();
        }
        #endregion

        private void btnChartToggle_Click(object sender, EventArgs e)
        {

            panelChart.Visible = true;
                
            chartWeekAssigned.Series["PrevWeek"].Points.AddXY("Monday",3);
            chartWeekAssigned.Series["PrevWeek"].Points.AddXY("Tuesday", 5);
            chartWeekAssigned.Series["PrevWeek"].Points.AddXY("Wednesday", 4);
            chartWeekAssigned.Series["PrevWeek"].Points.AddXY("Thursday", 4);
            chartWeekAssigned.Series["PrevWeek"].Points.AddXY("Friday", 3);
            chartWeekAssigned.Series["PrevWeek"].Points.AddXY("Saturday", 6);
            chartWeekAssigned.Series["PrevWeek"].Points.AddXY("Sunday", 5);
            chartWeekAssigned.Series["CurrentWeek"].Points.AddXY("Monday",schedule.GetShiftAssignedCount(day1));
            chartWeekAssigned.Series["CurrentWeek"].Points.AddXY("Tuesday", schedule.GetShiftAssignedCount(day2));
            chartWeekAssigned.Series["CurrentWeek"].Points.AddXY("Wednesday", schedule.GetShiftAssignedCount(day3));
            chartWeekAssigned.Series["CurrentWeek"].Points.AddXY("Thursday", schedule.GetShiftAssignedCount(day4));
            chartWeekAssigned.Series["CurrentWeek"].Points.AddXY("Friday", schedule.GetShiftAssignedCount(day5));
            chartWeekAssigned.Series["CurrentWeek"].Points.AddXY("Saturday", schedule.GetShiftAssignedCount(day6));
            chartWeekAssigned.Series["CurrentWeek"].Points.AddXY("Sunday", schedule.GetShiftAssignedCount(day7));
        }

        private void btnBackToWeekOverview2_Click(object sender, EventArgs e)
        {
            panelChart.Visible = false;
        }

        private void btnSchedulerInitiation_Click(object sender, EventArgs e)
        {
            schedule.AutomatedAssignmentForADay(day1);
            schedule.AutomatedAssignmentForADay(day2);
            schedule.AutomatedAssignmentForADay(day3);
            schedule.AutomatedAssignmentForADay(day4);
            schedule.AutomatedAssignmentForADay(day5);
            schedule.AutomatedAssignmentForADay(day6);
            schedule.AutomatedAssignmentForADay(day7);
            UpdateLivingText();
        }

        private void btnSchedulerOptions_Click(object sender, EventArgs e)
        {
            panelSchedulerOptions.Visible = true;
        }

        private void btnConfirmLimitationChanges_Click(object sender, EventArgs e)
        {
            int hrLimit =Convert.ToInt32( tbxLimitHR.Text);
            int prLimit = Convert.ToInt32(tbxLimitPR.Text);
            int slF1Limit = Convert.ToInt32(tbxLimitSLF1.Text);
            int slF2Limit = Convert.ToInt32(tbxLimitSLF2.Text);
            int slF3Limit = Convert.ToInt32(tbxLimitSLF3.Text);
            int slF4Limit = Convert.ToInt32(tbxLimitSLF4.Text);
            int dpLimit = Convert.ToInt32(tbxLimitDP.Text);
            if(schedule.UpdateLimitations(hrLimit, prLimit, slF1Limit, slF2Limit, slF3Limit, slF4Limit, dpLimit))
            {
                MessageBox.Show("Update successful!");
            }
            else
            {
                MessageBox.Show("Update failed, please try again later");
            }
        }

        private void btnBackToWeekOverview_Click(object sender, EventArgs e)
        {
            panelSchedulerOptions.Visible = false;
        }
    }
}
