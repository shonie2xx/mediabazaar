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
    public partial class Managment : Form
    {
        ConnectionClass conn;
        ProductManagement ProductManagment;
        BazaarManagment managment;
        Schedule schedule;
        private string email;
        private string pos;
        private string name;
        private string current_email;
        private Department department;
        private DateTime contractEnd;
        private string dataGridString = "";
        public Managment(string email)
        {
            InitializeComponent();
            //cbDepart.DataSource = Enum.GetValues(typeof(Department));
            managment = new BazaarManagment();
            ProductManagment = new ProductManagement();
            conn = new ConnectionClass();
            this.current_email = email;

        }

        private void btnOverview_Click(object sender, EventArgs e)
        {
           
            panelPositionsHistory.Visible = false;
            panelCurrentEmployees.Visible = false;
            panelFormerEmployees.Visible = false;
            panelHireNew.Visible = false;
            panelWelcome.Visible = false;
            panelInfo.Visible = false;
            panelAddProduct.Visible = false;
            panelRestock.Visible = true;
        }


        private void Managment_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panelRestock.Visible = false;
            panelAddProduct.Visible = false;
            Department transfer;
            //UpdateDataGridView();
            managment.LoadAllFormerEmployees();
            managment.LoadAllEmployees();

            
            ProductManagment.ProductsSales.AddRange(managment.LoadSalesProds());
            ProductManagment.ProductsDEPOT.AddRange(managment.LoadDepotProds());
            ProductManagment.RequestedProducts.AddRange(managment.LoadRequestedProducts());
            for (int y = 0; y < ProductManagment.RequestedProducts.Count; y++)
            {
                listBox3.Items.Add(ProductManagment.RequestedProducts[y].GetRequestInfo());
            }


            foreach (Employee em in managment.GetAllEmployees().ToList())
            {
                DateTime date1 = em.ContractEnd;
                DateTime date2 = DateTime.Now;
                DateTime date3 = DateTime.Now.AddDays(7);
                int result = DateTime.Compare(date1, date2);
                if (em.Email == current_email)
                {
                    label1.Text += $", {em.FName} { em.LName}";
                    department = em.Department;
                    if (em.Positions == "EMPLOYEE")
                    {

                        panelLeftSide.Visible = false;
                        label1.Left = 20;
                        label1.Text = "Application is not available for employees,\n but you can see your schedule in our site\n\n www.employeesite.com";
                    }
                    if (em.Department != Department.HUMANRESOURCES)
                    {
                        lblDepartment.Visible = false;
                        cbxDepartment.Visible = false;
                    }

                }
                if (result < 0)
                {
                    managment.AddToFormerEmployees(em.Email, "Contract end");
                    MessageBox.Show($"The contract of {em.FName} {em.LName} ended. He is now added to Former Employees");
                }
                int resultReminder = DateTime.Compare(date1,date3);
                if(resultReminder >= -7 && resultReminder <= 0)
                {
                    MessageBox.Show($"The contract of {em.FName} {em.LName} is about to expire.");
                }

            }
            switch (department)
            {
                case Department.SALES:
                    transfer = Department.SALES;
                    break;
                case Department.PR:
                    transfer = Department.PR;
                    break;
                case Department.DEPOT:
                    transfer = Department.DEPOT;
                    break;
                default:
                    transfer = Department.HUMANRESOURCES;
                    break;
            }

            schedule = new Schedule(managment.GetAllEmployees(), managment.GetAllNewEmployees(), managment.GetAllFormerEmployees(), transfer);
            UpdateDataGridView();

            if (department != Department.DEPOT)
            {
                btnSearch.Visible = false;
                btnRestock.Visible = false;
            }

            if(department == Department.HUMANRESOURCES || department == Department.PR)
            {
                btnProducts.Visible = false;
            }


            //dataGridView1.DataSource = managment.GetAllEmployees();
        }
        public void UpdateDataGridView()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();

            managment.LoadPositionLog();
            managment.LoadAllFormerEmployees(department);
            managment.LoadAllEmployees(department);

            managment.GetPositionLogs();
            managment.GetAllEmployees();
            managment.GetAllFormerEmployees();

            

            BindingList<Employee> bindingList = new BindingList<Employee>(managment.GetAllEmployees());
            BindingList<Employee> listFormerEmployees = new BindingList<Employee>(managment.GetAllFormerEmployees());
            BindingList<PositionLog> pos = new BindingList<PositionLog>(managment.GetPositionLogs());

            BindingSource source = new BindingSource(bindingList, null);
            BindingSource sourceFormerEmployees = new BindingSource(listFormerEmployees, null);
            BindingSource position = new BindingSource(pos, null);

            //BindingList<Product> bindingListProd = new BindingList<Product>(managment.LoadAllProducts());
            //BindingSource listProd = new BindingSource(bindingListProd, null);

            dataGridView3.DataSource = position;
            dataGridView1.DataSource = source;
            dataGridView2.DataSource = sourceFormerEmployees;

            this.dataGridView1.Columns["PASS"].Visible = false;
            this.dataGridView1.Columns["Pass"].Visible = false;
            this.dataGridView1.Columns["Reason"].Visible = false;
            this.dataGridView2.Columns["PASS"].Visible = false;
            this.dataGridView2.Columns["Pass"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
            managment.AddEmployeesToDB();
           
        }

        private void btnFormerEmployees_Click(object sender, EventArgs e)
        {
            panelCurrentEmployees.Visible = false;
            panelFormerEmployees.Visible = true;
            panelHireNew.Visible = false;
            panelWelcome.Visible = false;
            panelInfo.Visible = false;
            panelPositionsHistory.Visible = false;
            panelAddProduct.Visible = false;
            panelRestock.Visible = false;
            panel1.Visible = false;

        }

        private void btnCurrentEmployee_Click(object sender, EventArgs e)
        {
            panelCurrentEmployees.Visible = true;
            panelFormerEmployees.Visible = false;
            panelHireNew.Visible = false;
            panelWelcome.Visible = false;
            panelInfo.Visible = false;
            panelPositionsHistory.Visible = false;
            panelAddProduct.Visible = false;
            panelRestock.Visible = false;
            panel1.Visible = false;
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            string selected_email = dataGridView2.CurrentRow.Cells["Email"].Value.ToString();
            string selected_name = dataGridView2.CurrentRow.Cells["FName"].Value.ToString();
            string selected_surname = dataGridView2.CurrentRow.Cells["LName"].Value.ToString();
            DialogResult dr = MessageBox.Show("Are you sure you want to retrieve " + selected_name + " " + selected_surname + "?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                managment.RetrieveEmployee(selected_email);
            }
            else
            {
                this.Show();
            }

            UpdateDataGridView();

        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            panelEmployees.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selected_email = dataGridView2.CurrentRow.Cells["Email"].Value.ToString();
            string selected_name = dataGridView2.CurrentRow.Cells["FName"].Value.ToString();
            string selected_surname = dataGridView2.CurrentRow.Cells["LName"].Value.ToString();
            DialogResult dr = MessageBox.Show("Are you sure you want to delete " + selected_name + " " + selected_surname + "?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                managment.DeleteEmployee(selected_email);
            }
            else
            {
                this.Show();
            }
            UpdateDataGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnHireNew_Click(object sender, EventArgs e)
        {
            panelHireNew.Visible = true;
            panelCurrentEmployees.Visible = false;
            panelFormerEmployees.Visible = false;
            panelWelcome.Visible = false;
            panelInfo.Visible = false;
            panelPositionsHistory.Visible = false;
            panelProductAdd.Visible = false;
            panelAddProduct.Visible = false;
            panelRestock.Visible = false;
            panel1.Visible = false;
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            string firstName;
            string lastName;
            int bsn = 0;
            Gender gender;
            Position position = Position.EMPLOYEE;
            Department department = Department.SALES;
            DateTime birthDate = dtpicker.Value;
            string birthPlace;
            string adress;
            string city;
            string zipcode;
            string email;
            string nationality;
            string languages;
            DateTime ContractEnd;
            double FTE = Convert.ToDouble(nudFTE.Value);
            foreach (Employee em in managment.GetAllEmployees())
            {
                if (em.Positions == "MANAGER")
                {
                    department = em.Department;
                }
            }
            try { bsn = Convert.ToInt32(tbxBSN.Text); }
            catch (System.FormatException) { MessageBox.Show("Please enter a valid BSN number"); return; }

            if (string.IsNullOrWhiteSpace(tbxFName.Text))
            {
                MessageBox.Show("Please fill in both names");
                return;
            }
            else
            {
                firstName = tbxFName.Text;
            }
            if (string.IsNullOrWhiteSpace(tbxLName.Text))
            {
                MessageBox.Show("Please fill in both names");
                return;
            }
            else
            {
                lastName = tbxLName.Text;
            }
            if (string.IsNullOrWhiteSpace(tbxBirthplace.Text))
            {
                MessageBox.Show("Please enter place of birth");
                return;
            }
            else
            {
                birthPlace = tbxBirthplace.Text;
            }
            if (string.IsNullOrWhiteSpace(tbxAddress.Text))
            {
                MessageBox.Show("Please enter a home address");
                return;
            }
            else
            {
                adress = tbxAddress.Text;
            }
            if (string.IsNullOrWhiteSpace(tbxEmail.Text))
            {
                MessageBox.Show("Please enter an E-mail adress");
                return;
            }
            else
            {
                email = tbxEmail.Text;
            }
            if (string.IsNullOrWhiteSpace(tbxNationality.Text))
            {
                MessageBox.Show("Please enter a nationality");
                return;
            }
            else
            {
                nationality = tbxNationality.Text;
            }
            if (string.IsNullOrWhiteSpace(tbxLanguage.Text))
            {
                MessageBox.Show("Please enter languages");
                return;
            }
            else
            {
                languages = tbxLanguage.Text;
            }
            if (string.IsNullOrWhiteSpace(cbxGender.Text))
            {
                MessageBox.Show("Please enter the gender of your future employee");
                return;
            }
            else
            {
                gender = (Gender)cbxGender.SelectedIndex;
            }
            if (string.IsNullOrWhiteSpace(cbxDepartment.Text) && lblDepartment.Visible == true)
            {
                MessageBox.Show("Please enter a department for your future employee");
                return;
            }
            else
            {

                department = (Department)cbxDepartment.SelectedIndex;

            }
            if (string.IsNullOrWhiteSpace(tbxCity.Text))
            {
                MessageBox.Show("Please enter a city name");
                return;
            }
            else
            {
                city = tbxCity.Text;
            }
            if (string.IsNullOrWhiteSpace(tbxZipcode.Text))
            {
                MessageBox.Show("Please enter a zipcode");
                return;
            }
            else
            {
                zipcode = tbxZipcode.Text;
            }
            if (rbtnOneYear.Checked)
            {
                ContractEnd = DateTime.Now;
                contractEnd = ContractEnd.AddYears(1);
            }
            if (rbtnTwoYears.Checked)
            {
                ContractEnd = DateTime.Now;
                contractEnd = ContractEnd.AddYears(2);
            }
            if (rbtnOneYear.Visible = false && rbtnTwoYears.Visible == false)
            {
                contractEnd = dateTimePicker1.Value;
            }

            managment.AddNewEmployee(firstName, lastName, gender, position, department, birthDate, birthPlace, city, zipcode, adress, email, nationality, languages, bsn, contractEnd, FTE);
            MessageBox.Show("Success");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string selected_email = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();

            lblAdress.Text = "Address: ";
            lblBdate.Text = "Birthdate: ";
            lblBirthPlaceInfo.Text = "Birthplace: ";
            lblBSNInfo.Text = "BSN: ";
            lblCityInfo.Text = "City: ";
            lblDepartmentInfo.Text = "Department: ";
            lblEmailInfo.Text = "Email: ";
            labelGenderInfo.Text = "Gender: ";
            lblLanguages.Text = "Language: ";
            lblName.Text = "Name: ";
            lblNationalityInfo.Text = "Nationality: ";
            lblPosition.Text = "Position: ";
            lblSalaryInfo.Text = "Salary: ";
            lblZipCodeInfo.Text = "ZipCode: ";
            //EmployeeInfo addInfo = new EmployeeInfo(managment.GetEmployeeByEmail(selected_email));
            if (selected_email != "")
            {
                foreach (Employee em in managment.GetAllEmployees())
                {
                    if (em.Email == selected_email)
                    {

                        panelInfo.Visible = true;
                        panelCurrentEmployees.Visible = false;
                        lblAdress.Text += em.Adress;
                        lblBdate.Text += em.BirthDate.ToString();
                        lblBirthPlaceInfo.Text += em.BirthPlace;
                        lblBSNInfo.Text += em.BSN.ToString();
                        lblCityInfo.Text += em.City;
                        lblDepartmentInfo.Text += em.Department;
                        lblEmailInfo.Text += em.Email;
                        labelGenderInfo.Text += em.Gender;
                        lblLanguages.Text += em.Languages;
                        lblName.Text += em.FName + " " + em.LName;
                        lblNationalityInfo.Text += em.Nationality;
                        lblPosition.Text += em.Positions;
                        lblSalaryInfo.Text += em.Salary;
                        lblZipCodeInfo.Text += em.Zipcode;
                        email = em.Email;
                        pos = em.Positions;
                        name = $"{em.FName} {em.LName}";
                    }
                }

            }
            else
            {
                MessageBox.Show("First select!");
            }

        }

        private void btnShowRemove_Click(object sender, EventArgs e)
        {
            gbxRemove.Visible = true;
            btnShowRemove.Visible = false;
            gbxExtendContract.Visible = false;
        }

        private void btnPromote_Click(object sender, EventArgs e)
        {
            if (pos != "MANAGER" && pos != "CEO")
            {
                managment.UPDATEManagePosition(email, "MANAGER");
                managment.AddToPositionHistory(email, "MANAGER");
                MessageBox.Show("Promoted to Manager!");

            }
            else
            {
                MessageBox.Show("Already MANAGER OR CEO!");
            }
        }

        private void btnDemote_Click(object sender, EventArgs e)
        {
            if (pos != "EMPLOYEE" && pos != "CEO")
            {
                managment.UPDATEManagePosition(email, "EMPLOYEE");
                managment.AddToPositionHistory(email, "EMPLOYEE");
                MessageBox.Show("Demoted successfully!");
            }
            else
            {
                MessageBox.Show("Already EMPLOYEE!");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string reason = richTextBox1.Text;
            DialogResult dr = MessageBox.Show("Are you sure you want to remove " + name + "?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                managment.AddToFormerEmployees(email, reason);
            }
            else
            {
                this.Show();
            }
            UpdateDataGridView();


        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            string selected_email = dataGridView2.CurrentRow.Cells["Email"].Value.ToString();
            foreach (Employee em in managment.GetAllFormerEmployees())
            {
                if (em.Email == managment.GetFormerEmployeeByEmail(selected_email).Email)
                {
                    MessageBox.Show(em.Reason);
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelPositionsHistory.Visible = true;
            panelCurrentEmployees.Visible = false;
            panelFormerEmployees.Visible = false;
            panelHireNew.Visible = false;
            panelWelcome.Visible = false;
            panelInfo.Visible = false;
            panelAddProduct.Visible = false;
            panelRestock.Visible = false;
            panel1.Visible = false;
        }

        private void btnSearchCurrent_Click(object sender, EventArgs e)
        {
            string fname = tbxSearchCurrent.Text;

        }

        private void tbxSearchCurrent_TextChanged(object sender, EventArgs e)
        {

            string fname = tbxSearchCurrent.Text;
            if (fname == "")
            {
                UpdateDataGridView();
            }
            else
            {
                List<Employee> eList = new List<Employee>();
                eList.Add(managment.GetEmployeeByName(fname));
                BindingList<Employee> pos = new BindingList<Employee>(eList);
                BindingSource source = new BindingSource(pos, null);
                dataGridView1.DataSource = source;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string fname = tbxSearchFormerEmployee.Text;
            if (fname == "")
            {
                UpdateDataGridView();
            }
            else
            {
                List<Employee> eList = new List<Employee>();
                eList.Add(managment.GetFormerEmployeeByName(fname));
                BindingList<Employee> pos = new BindingList<Employee>(eList);
                BindingSource source = new BindingSource(pos, null);
                dataGridView2.DataSource = source;
            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            string fname = tbxSearch.Text;
            if (fname == "")
            {
                UpdateDataGridView();
            }
            else
            {
                List<PositionLog> eList = new List<PositionLog>();
                eList.Add(managment.GetPositionLogByName(fname));
                BindingList<PositionLog> pos = new BindingList<PositionLog>(eList);
                BindingSource source = new BindingSource(pos, null);
                dataGridView3.DataSource = source;
            }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            panelProducts.Visible = true;
            panelEmployees.Visible = false;
            panelManagment.Visible = false;
        }

        private void rbtnCutom_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = true;
            rbtnOneYear.Visible = false;
            rbtnTwoYears.Visible = false;
            rbtnCutom.Visible = false;
        }
        #region Shifts
        private void btnManagment_Click(object sender, EventArgs e)
        {
            schedule.KeepInCheck(managment.GetAllNewEmployees());
            ScheduleControl scheduleControl = new ScheduleControl(schedule, this);
            scheduleControl.Show();
            this.Hide();
        }

        #endregion

        private void tbxFName_TextChanged(object sender, EventArgs e)
        {
            rbtnOneYear.Visible = true;
            rbtnTwoYears.Visible = true;
            rbtnCutom.Visible = true;
            dateTimePicker1.Visible = false;
        }

        private void Managment_FormClosing(object sender, FormClosingEventArgs e)
        {
            schedule.Save();
        }
        #region Products
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            panelPositionsHistory.Visible = false;
            panelCurrentEmployees.Visible = false;
            panelFormerEmployees.Visible = false;
            panelHireNew.Visible = false;
            panelWelcome.Visible = false;
            panelInfo.Visible = false;
            panelAddProduct.Visible = true;
            panelRestock.Visible = false;
            panel1.Visible = false;
        }

        public void DataGridViewUpdateProducts()
        {
            dataGridString = "SELECT * FROM products WHERE department = 'SALES'";
            datagridSales.Rows.Clear();
            conn.SqlQuery(dataGridString);
            conn.QueryEx();
            foreach (DataRow dr in conn.DataRow())
            {
                int n = datagridSales.Rows.Add();//add new row for each row in data table
                //datagridSales.Rows[n].Cells[""]
                datagridSales.Rows[n].Cells["nameProd"].Value = dr["name"];
                datagridSales.Rows[n].Cells["priceProd"].Value = dr["price"];
                datagridSales.Rows[n].Cells["stockProd"].Value = dr["stocks"];
                datagridSales.Rows[n].Cells["idProd"].Value = dr["id"];
                datagridSales.Rows[n].Cells["soldProd"].Value = dr["sold"];
                datagridSales.Rows[n].Cells["departProd"].Value = dr["department"];

            }
        }

        public void RequestsUpdate()
        {
            listBox3.Items.Clear();
            for (int i = 0; i < ProductManagment.RequestedProducts.Count; i++)
            {
                listBox3.Items.Add(ProductManagment.RequestedProducts[i].GetRequestInfo());
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (tbProdName.Text == "" || tbProdPrice.Text == "" || tbProdStock.Text == "")
            {
                MessageBox.Show("Please fill all boxes!");
            }
            else
            {
                
                string name = tbProdName.Text;
                double price = Convert.ToDouble(tbProdPrice.Text);
                int stock = Convert.ToInt32(tbProdStock.Text);
                int sold = 0;
                string category;
                int amount = 0;

                category = "DEPOT";
                Product prod = new Product(name, price, stock, sold, category, amount);              
                conn.AddProductToDB(prod);
                ProductManagment.AddProductDEPOT(prod);
                MessageBox.Show("Product Added!");
                tbProdName.Text = "";
                tbProdPrice.Text = "" ;
                tbProdStock.Text = "";
                managment.AddProductinDEPOT(prod);
            }

        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            panelPositionsHistory.Visible = false;
            panelCurrentEmployees.Visible = false;
            panelFormerEmployees.Visible = false;
            panelHireNew.Visible = false;
            panelWelcome.Visible = false;
            panelInfo.Visible = false;
            panelAddProduct.Visible = false;
            panelRestock.Visible = false;
            panel1.Visible = true;
        }

        private void BtnProdRestock_Click(object sender, EventArgs e)
        {
            
            listBox3.Items.Clear();
            string ReqName = tbReqName.Text;
            bool ifThere = false;

            foreach(Product p in ProductManagment.RequestedProducts)
            {
                if (p.Name == ReqName)
                    foreach(var item in ProductManagment.ProductsDEPOT)
                    {
                        if(item.Name == ReqName && item.Stocks >= p.Requested)
                        {
                            item.Stocks -= p.Requested;
                            ProductManagment.RestockProducts(ReqName);
                            managment.UPDATEprodRequestR(ReqName);
                            managment.UPDATEprodStockR(ReqName);
                            managment.UPDATEprodStockDepot(ReqName);
                            MessageBox.Show("Product Restocked!");
                            ifThere = true;
                        }
                    }
            }
            if (ifThere == false)
                MessageBox.Show("Product not found or not enough stock in Depot!");

            RequestsUpdate();
            tbReqName.Text = "";
        }
        private void BtnRefresh_Click_1(object sender, EventArgs e)
        {
            DataGridViewUpdateProducts();
            
        }

        private void BtnSaleProd_Click(object sender, EventArgs e)
        {
            string nameProd = tbNameProd.Text;
            int number = Convert.ToInt32(tbNumProd.Text);
            bool ifThere = false;

            foreach (Product p in ProductManagment.ProductsSales)
            {
                if (p.Name == nameProd && p.Category == "SALES" && p.Stocks >= number)
                {
                    ProductManagment.SellProduct(nameProd, number);
                    
                    managment.UPDATEprodSold(nameProd);
                    managment.UPDATEprodStock(nameProd);
                    MessageBox.Show("Done!");
                    ifThere = true;
                }
            }
            if (ifThere == false)
                MessageBox.Show("Product not found or not enough stock!");




            DataGridViewUpdateProducts();
        }

        private void BtnRequestProd_Click(object sender, EventArgs e)
        {
            string nameProd = tbNameProd.Text;
            int number = Convert.ToInt32(tbNumProd.Text);
            bool ifThere = false;

            foreach (Product p in ProductManagment.ProductsSales)
            {
                if (p.Name == nameProd)
                {
                    ProductManagment.AddRequest(nameProd, number);
                    managment.UPDATEprodRequest(nameProd);
                    managment.AddProductinRequest(p);
                    MessageBox.Show("Done!");
                    ifThere = true;
                }
            }
            if (ifThere == false)
                MessageBox.Show("Product Not Found!");

            RequestsUpdate();
        }

        private void BtnsearchProd_Click(object sender, EventArgs e)
        {
           
        }


        #endregion

        private void btnExtendContract_Click(object sender, EventArgs e)
        {
            gbxExtendContract.Visible = true;
            gbxRemove.Visible = false;
            btnShowRemove.Visible = true;
            btnExtendContract.Visible = false;
            

        }

        private void btnExtendContract_gbx_Click(object sender, EventArgs e)
        {
            if(managment.UpdateContract(email, dateTimePicker2.Value))
            {
                MessageBox.Show("Successfully extended contract");
            }
            
        }

        private void BtnSales_Click(object sender, EventArgs e)
        {
            dataGridString = "SELECT * FROM products WHERE department = 'SALES'";
            dataGridView4.Rows.Clear();
            conn.SqlQuery(dataGridString);
            conn.QueryEx();
            foreach (DataRow dr in conn.DataRow())
            {
                int n = dataGridView4.Rows.Add();//add new row for each row in data table
                //datagridSales.Rows[n].Cells[""]
                dataGridView4.Rows[n].Cells["Column1"].Value = dr["name"];
                dataGridView4.Rows[n].Cells["Column2"].Value = dr["price"];
                dataGridView4.Rows[n].Cells["Column3"].Value = dr["stocks"];

                dataGridView4.Rows[n].Cells["Column4"].Value = dr["sold"];
                dataGridView4.Rows[n].Cells["Column5"].Value = dr["department"];

            }
        }

        private void BtnDepot_Click(object sender, EventArgs e)
        {
            dataGridString = "SELECT * FROM products WHERE department = 'DEPOT'";
            dataGridView4.Rows.Clear();
            conn.SqlQuery(dataGridString);
            conn.QueryEx();
            foreach (DataRow dr in conn.DataRow())
            {
                int n = dataGridView4.Rows.Add();//add new row for each row in data table
                //datagridSales.Rows[n].Cells[""]
                dataGridView4.Rows[n].Cells["Column1"].Value = dr["name"];
                dataGridView4.Rows[n].Cells["Column2"].Value = dr["price"];
                dataGridView4.Rows[n].Cells["Column3"].Value = dr["stocks"];

                dataGridView4.Rows[n].Cells["Column4"].Value = dr["sold"];
                dataGridView4.Rows[n].Cells["Column5"].Value = dr["department"];

            }
        }

        private void BtnSea_Click(object sender, EventArgs e)
        {
            string name = tbReqName.Text;
            bool ifThere = false;

            foreach (Product p in ProductManagment.ProductsDEPOT)
            {
                if (p.Name == name)
                {
                    MessageBox.Show("In DEPOT:" + Environment.NewLine + "Product Name: " + p.Name + Environment.NewLine + "Product price: " + p.Price + Environment.NewLine + "Product sold: " + p.Sold + Environment.NewLine + "Product stocks: " + p.Stocks + Environment.NewLine + "Earned money: " + p.Sold * p.Price);
                    ifThere = true;
                }
            }
            if(ifThere == false)
            {
                MessageBox.Show("Product Not Found!");
            }

        }

        private void BtnDepRe_Click(object sender, EventArgs e)
        {
            string name = tbProdName.Text;
            int stock = Convert.ToInt32(tbProdStock.Text);
            bool ifThere = false;

            foreach(Product p in ProductManagment.ProductsDEPOT)
            {
                if(p.Name == name && p.Category == "DEPOT")
                {
                    p.Stocks += stock;
                    managment.UPDATEprodStockDepot(name);
                    MessageBox.Show("Done!");
                    ifThere = true;
                }
            }

            if (ifThere == false)
                MessageBox.Show("Product not Found!");
        }

        private void BtnSalesAdd_Click(object sender, EventArgs e)
        {
            string name = tbProdName.Text;
            int stock = Convert.ToInt32(tbProdStock.Text);
            bool ifThere = false;

            foreach(Product p in ProductManagment.ProductsDEPOT)
            {
                if(p.Name == name && p.Stocks >= stock)
                {
                    p.Stocks -= stock;
                    managment.UPDATEprodStockDepot(name);
                    double price = p.Price;
                    int sold = 0;
                    string category = "SALES";
                    Product pS = new Product(name, price, stock, sold, category, 0);
                    ProductManagment.ProductsSales.Add(pS);
                    conn.AddProductToDB(pS);
                    MessageBox.Show("Done!");
                    managment.AddProductinSALES(pS);
                    ifThere = true;
                }
            }
            if (ifThere == false)
                MessageBox.Show("Product not found or not enough stock!");

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
