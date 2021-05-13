using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace MediaBazaarProject.Logic
{
    class ConnectionClass
    {
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        private DataTable dt;
        private SqlDataReader dr;
        private string query = "";

        public ConnectionClass()
        {
            // Dimitar : "Server=studmysql01.fhict.local;Uid=dbi431660;Database=dbi431660;Pwd=TestPass;"
            // Bojidar : "Server = studmysql01.fhict.local; Uid = dbi434236; Database = dbi434236; Pwd = baitosho;"
            // Aleksandar : "Server = localhost;Uid = website-project;Database = website-project;Pwd = "";"
            string database = "Server = localhost;Uid = root;Database = website-project;Pwd= ;";
            conn = new MySqlConnection(database);
        }

        #region Basic Functions
        public void AddWithValue(string parameterName, object value)
        {
            cmd.Parameters.AddWithValue(parameterName, value);
        }

        public void NonQueryEx()
        {
            cmd.ExecuteNonQuery();
        }

        public void Close()
        {
            conn.Close();
        }

        public DataRowCollection DataRow()
        {
            return dt.Rows;
        }
        private bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Could not connect to the server, please restart the application and try again");
                        break;

                    case 1045:
                        MessageBox.Show("Database authentication error");
                        break;
                }
                return false;
            }
        }
        public bool QueryEx()
        {
            da = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            dt.Columns.Add("Person");
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;

        }
        public void SqlQuery(string queryText)
        {
            cmd = new MySqlCommand(queryText, conn);
        }
        #endregion
        #region Employee-related functions
        public bool Login(string email, string password)
        {
            if (OpenConnection() == true)
            {
                query = "Select Email, Password FROM employees WHERE Email = @Email AND Password = @Password";
                SqlQuery(query);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                QueryEx();
                if (QueryEx() == true)
                {
                    conn.Close();
                    return true;

                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            else
                return false;

        }
        public bool INSERTEmployeesToDB(Employee e)
        {
            if (OpenConnection() == true)
            {
                query = "INSERT INTO employees (ID,FirstName,LastName,Password,Gender,Birthdate,Birthplace,Email,Department,Nationality,Language,BSN,Salary,City,Zipcode,Address,Position, ContractEnd, FTE) " +
                "VALUES (@ID,@FirstName,@LastName,@Password,@Gender,@Birthdate,@Birthplace,@Email,@Department,@Nationality,@Language,@BSN,@Salary,@City,@Zipcode,@Address,@Position,@ContractEnd,@FTE)";
                SqlQuery(query);
                cmd.Parameters.AddWithValue("@ID", e.WorkrID);
                cmd.Parameters.AddWithValue("@FirstName", e.FName);
                cmd.Parameters.AddWithValue("@LastName", e.LName);
                cmd.Parameters.AddWithValue("@Gender", e.Gender);
                cmd.Parameters.AddWithValue("@Birthdate", e.BirthDate);
                cmd.Parameters.AddWithValue("@Birthplace", e.BirthPlace);
                cmd.Parameters.AddWithValue("@Email", e.Email);
                cmd.Parameters.AddWithValue("@Department", e.Department);
                cmd.Parameters.AddWithValue("@Nationality", e.Nationality);
                cmd.Parameters.AddWithValue("@City", e.City);
                cmd.Parameters.AddWithValue("@Zipcode", e.Zipcode);
                cmd.Parameters.AddWithValue("@Language", e.Languages);
                cmd.Parameters.AddWithValue("@BSN", e.BSN);
                cmd.Parameters.AddWithValue("@Salary", e.Salary);
                cmd.Parameters.AddWithValue("@Address", e.Adress);
                cmd.Parameters.AddWithValue("@Position", e.Positions);
                cmd.Parameters.AddWithValue("@Password", e.Pass);
                cmd.Parameters.AddWithValue("@ContractEnd", e.ContractEnd);
                cmd.Parameters.AddWithValue("@FTE", e.FTE);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }




        }
        public bool INSERTFormerEmployeesToDB(Employee e, string reason)
        {
            if (OpenConnection() == true)
            {
                query = "INSERT INTO endedcontract (ID,FirstName,LastName,Password,Gender,Birthdate,Birthplace,Email,Department,Nationality,Language,BSN,City,Zipcode,Address,Position,Reason) " +
                "VALUES (@ID,@FirstName,@LastName,@Password,@Gender,@Birthdate,@Birthplace,@Email,@Department,@Nationality,@Language,@BSN,@City,@Zipcode,@Address,@Position,@Reason)";
                SqlQuery(query);
                cmd.Parameters.AddWithValue("@FirstName", e.FName);
                cmd.Parameters.AddWithValue("@LastName", e.LName);
                cmd.Parameters.AddWithValue("@Gender", e.Gender);
                cmd.Parameters.AddWithValue("@Birthdate", e.BirthDate);
                cmd.Parameters.AddWithValue("@Birthplace", e.BirthPlace);
                cmd.Parameters.AddWithValue("@Email", e.Email);
                cmd.Parameters.AddWithValue("@Department", e.Department);
                cmd.Parameters.AddWithValue("@Nationality", e.Nationality);
                cmd.Parameters.AddWithValue("@City", e.City);
                cmd.Parameters.AddWithValue("@Zipcode", e.Zipcode);
                cmd.Parameters.AddWithValue("@Language", e.Languages);
                cmd.Parameters.AddWithValue("@BSN", e.BSN);
                cmd.Parameters.AddWithValue("@ID", e.WorkrID);
                cmd.Parameters.AddWithValue("@Address", e.Adress);
                cmd.Parameters.AddWithValue("@Position", e.Positions);
                cmd.Parameters.AddWithValue("@Password", e.Pass);
                cmd.Parameters.AddWithValue("@Reason", reason);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }
        }
        public bool INSERTPositionHistory(Employee e, string newPos)
        {
            DateTime date = DateTime.Now;
            if (OpenConnection() == true)
            {
                query = "INSERT INTO positionhistory (ID,FirstName,LastName,Department,ChangedTo,Date) " +
                "VALUES (@ID,@FirstName,@LastName,@Department,@Position,@Date)";
                SqlQuery(query);
                cmd.Parameters.AddWithValue("@FirstName", e.FName);
                cmd.Parameters.AddWithValue("@LastName", e.LName);
                cmd.Parameters.AddWithValue("@ID", e.WorkrID);
                cmd.Parameters.AddWithValue("@Position", newPos);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Department", e.Department);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }
        }
        public List<Employee> GetEmployees()
        {
            Gender gender = Gender.OTHER;
            Position pos = Position.EMPLOYEE;
            Department dep = Department.SALES;
            if (OpenConnection() == true)
            {
                query = "SELECT * FROM employees";
                SqlQuery(query);
                QueryEx();
                MySqlDataReader datareader = cmd.ExecuteReader();
                List<Employee> newList = new List<Employee>();
                foreach (DataRow dr in dt.Rows)
                {

                    if (newList.Contains(dr["FirstName"]))
                    {
                        break;
                    }
                    else
                    {
                        switch (dr["Gender"])
                        {
                            case "FEMALE":
                                gender = Gender.FEMALE;
                                break;
                            case "MALE":
                                gender = Gender.MALE;
                                break;
                            case "OTHER":
                                gender = Gender.OTHER;
                                break;
                        }
                        switch (dr["Position"])
                        {
                            case "CEO":
                                pos = Position.CEO;
                                break;
                            case "MANAGER":
                                pos = Position.MANAGER;
                                break;
                            case "EMPLOYEE":
                                pos = Position.EMPLOYEE;
                                break;
                        }
                        switch (dr["Department"])
                        {
                            case "DEPOT":
                                dep = Department.DEPOT;
                                break;
                            case "SALES":
                                dep = Department.SALES;
                                break;
                            case "HUMANRESOURCES":
                                dep = Department.HUMANRESOURCES;
                                break;
                            case "PR":
                                dep = Department.PR;
                                break;
                        }
                        newList.Add(new Employee(Convert.ToInt32(dr["ID"]), dr["FirstName"].ToString(), dr["LastName"].ToString(), gender, pos, dep, Convert.ToDateTime(dr["Birthdate"]), dr["BirthPlace"].ToString(), dr["City"].ToString(), dr["Zipcode"].ToString(), dr["Address"].ToString(), dr["Email"].ToString(), dr["Nationality"].ToString(), dr["Language"].ToString(), Convert.ToInt32(dr["BSN"]), Convert.ToDateTime(dr["ContractEnd"]), Convert.ToDouble(dr["FTE"])));

                    }
                }
                conn.Close();
                return newList;

            }
            else
                MessageBox.Show("Nnoo");
            return null;

        }
        public List<Employee> GetFormerEmployees()
        {
            Gender gender = Gender.OTHER;
            Position pos = Position.EMPLOYEE;
            Department dep = Department.SALES;
            if (OpenConnection() == true)
            {
                query = "SELECT * FROM endedcontract";
                SqlQuery(query);
                QueryEx();
                List<Employee> newList = new List<Employee>();
                foreach (DataRow dr in dt.Rows)
                {
                    if (newList.Contains(dr["FirstName"]))
                    {
                        break;
                    }
                    else
                    {


                        switch (dr["Gender"])
                        {
                            case "FEMALE":
                                gender = Gender.FEMALE;
                                break;
                            case "MALE":
                                gender = Gender.MALE;
                                break;
                            case "OTHER":
                                gender = Gender.OTHER;
                                break;
                        }
                        switch (dr["Position"])
                        {
                            case "CEO":
                                pos = Position.CEO;
                                break;
                            case "MANAGER":
                                pos = Position.MANAGER;
                                break;
                            case "EMPLOYEE":
                                pos = Position.EMPLOYEE;
                                break;
                        }
                        switch (dr["Department"])
                        {
                            case "DEPOT":
                                dep = Department.DEPOT;
                                break;
                            case "SALES":
                                dep = Department.SALES;
                                break;
                            case "HUMANRESOURCES":
                                dep = Department.HUMANRESOURCES;
                                break;
                            case "PR":
                                dep = Department.PR;
                                break;
                        }
                        newList.Add(new Employee(dr["FirstName"].ToString(), dr["LastName"].ToString(), gender, pos, dep, Convert.ToDateTime(dr["Birthdate"]), dr["BirthPlace"].ToString(), dr["City"].ToString(), dr["Zipcode"].ToString(), dr["Address"].ToString(), dr["Email"].ToString(), dr["Nationality"].ToString(), dr["Language"].ToString(), Convert.ToInt32(dr["BSN"]), dr["Reason"].ToString()));
                    }
                }
                conn.Close();
                return newList;

            }
            else
                MessageBox.Show("Nnoo");
            return null;
        }
        public bool UPDATEPositions(Employee e, string newPos)
        {
            if (OpenConnection() == true)
            {
                query = "UPDATE employees SET Position = @Position WHERE Email = @Email";
                SqlQuery(query);
                cmd.Parameters.AddWithValue("@Email", e.Email);
                cmd.Parameters.AddWithValue("@Position", newPos.ToString());
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }


        }
        public bool UPDATEContract(Employee e, DateTime newContract)
        {
            if (OpenConnection() == true)
            {
                query = "UPDATE employees SET ContractEnd = @Contract WHERE Email = @Email";
                SqlQuery(query);
                cmd.Parameters.AddWithValue("@Email", e.Email);
                cmd.Parameters.AddWithValue("@Contract", newContract);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }


        }
        public List<PositionLog> GetPositionLogs()
        {
            if (OpenConnection() == true)
            {
                query = "SELECT FirstName, LastName, Department, ChangedTo, Date FROM positionhistory";
                SqlQuery(query);
                QueryEx();
                List<PositionLog> newList = new List<PositionLog>();
                foreach (DataRow dr in dt.Rows)
                {
                    newList.Add(new PositionLog(dr["FirstName"].ToString(), dr["LastName"].ToString(), dr["Department"].ToString(), dr["ChangedTo"].ToString(), Convert.ToDateTime(dr["Date"])));
                }
                conn.Close();
                return newList;

            }
            else
                MessageBox.Show("Nnoo");
            return null;
        }
        public bool DeleteFromEndedContract(Employee e)
        {
            if (OpenConnection() == true)
            {
                query = "DELETE FROM endedcontract WHERE Email = @Email";
                SqlQuery(query);
                cmd.Parameters.AddWithValue("@Email", e.Email);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }
        }
        public bool DeleteFromEmployees(Employee e)
        {
            if (OpenConnection() == true)
            {
                query = "DELETE FROM employees WHERE Email = @Email";
                SqlQuery(query);
                cmd.Parameters.AddWithValue("@Email", e.Email);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }
        }
        #endregion
        #region Scheduler-related functions
        public bool SaveShifts(List<Shift> shifts)
        {
            if (shifts.Count > 0)
            {
                if (OpenConnection() == true)
                {
                    query = "INSERT INTO schedule (shiftNumb,Date,Department,Storefloor,ID) " +
                    "VALUES (@shiftNumb,@Date,@Department,@Storefloor,@ID)";
                    foreach (Shift s in shifts)
                    {


                        SqlQuery(query);

                        cmd.Parameters.AddWithValue("@shiftNumb", s.ShiftNumber);
                        cmd.Parameters.AddWithValue("@Date", s.Date);
                        cmd.Parameters.AddWithValue("@Department", s.DepartmentGet.ToString());
                        cmd.Parameters.AddWithValue("@Storefloor", s.FloorOfStore);
                        cmd.Parameters.AddWithValue("@ID", s.ShiftID);

                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool CommitChangesToShifts(List<Shift> shifts)
        {
            if (shifts.Count > 0)
            {
                if (OpenConnection() == true)
                {
                    foreach (Shift s in shifts)
                    {
                        query = "DELETE FROM `schedule_employee` WHERE schedule_id = '" + s.ShiftID + "' ";
                        SqlQuery(query);
                        cmd.ExecuteNonQuery();
                    }

                    query = "INSERT INTO schedule_employee (schedule_id,employee_id) " +
                            "VALUES (@schedule_id,@employee_id)";
                    foreach (Shift s in shifts)
                    {
                        if (s.EmployeesAssigned.Count > 0)
                        {

                            foreach (Employee e in s.EmployeesAssigned)
                            {
                                SqlQuery(query);

                                cmd.Parameters.AddWithValue("@schedule_id", s.ShiftID);
                                cmd.Parameters.AddWithValue("@employee_id", e.WorkrID);

                                cmd.ExecuteNonQuery();
                            }
                        }

                    }
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public List<Shift> LoadShifts(Department department, List<Employee> employees)
        {

            if (OpenConnection() == true)
            {
                query = "SELECT COUNT(ID) FROM schedule";
                SqlQuery(query);
                QueryEx();
                int Count = -1;
                Count = int.Parse(cmd.ExecuteScalar() + "");
                Shift.shiftSeeder = Count + 1;

                query = "SELECT * FROM schedule WHERE Department='" + department.ToString() + "'";
                SqlQuery(query);
                QueryEx();
                MySqlDataReader datareader = cmd.ExecuteReader();
                List<Shift> newList = new List<Shift>();

                foreach (DataRow dr in dt.Rows)
                {
                    string checker = null;
                    if (department == Department.SALES)
                    {
                        checker = dr["Storefloor"].ToString();
                    }

                    newList.Add(new Shift(Convert.ToInt32(dr["shiftNumb"]), Convert.ToInt32(dr["ID"]), dr["Department"].ToString(), Convert.ToDateTime(dr["Date"]), checker));

                }
                datareader.Close();
                query = "SELECT * FROM schedule_employee";
                SqlQuery(query);
                QueryEx();
                MySqlDataReader datareader2 = cmd.ExecuteReader();
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (Shift s in newList)
                    {
                        if (s.ShiftID == Convert.ToInt32(dr["schedule_id"]))
                        {
                            Employee emp = employees.Find(x => x.WorkrID == Convert.ToInt32(dr["employee_id"]));
                            s.AssignEmployee(emp);
                        }
                    }
                }

                conn.Close();
                return newList;

            }
            else
                MessageBox.Show("An error occured please try again later");
            return null;

        }
        public List<Preference> LoadPreferences()
        {
            if (OpenConnection() == true)
            {
                List<Preference> preferences = new List<Preference>();
                query = "SELECT * FROM preference";
                SqlQuery(query);
                QueryEx();
                foreach (DataRow dr in dt.Rows)
                {


                    preferences.Add(new Preference(Convert.ToInt32(dr["id"]), Convert.ToInt32(dr["employee_id"]), Convert.ToInt32(dr["shiftNumber"]), dr["dayOfWeek"].ToString()));


                }

                conn.Close();
                return preferences;
            }
            else
            {
                MessageBox.Show("Loading preferences failed, please make an attempt later!");
                return null;
            }
        }
       
        public AsssigningLimit LoadAssigningLimits()
        {
            AsssigningLimit loadedLimit = null;
            if (OpenConnection() == true)
            {

                query = "SELECT * FROM assigning_limits";
                SqlQuery(query);
                QueryEx();
                foreach (DataRow dr in dt.Rows)
                {

                    loadedLimit = new AsssigningLimit(Convert.ToInt32(dr["HR"]), Convert.ToInt32(dr["PR"]), Convert.ToInt32(dr["SALES_F1"]), Convert.ToInt32(dr["SALES_F2"]), Convert.ToInt32(dr["SALES_F3"]), Convert.ToInt32(dr["SALES_F4"]), Convert.ToInt32(dr["DEPOT"]));

                }

                conn.Close();
                return loadedLimit;
            }
            else
            {
                MessageBox.Show("Limitations not loaded, please make an attempt later!");
                return null;
            }
        }
        public bool SaveNewAssigningLimits(AsssigningLimit al)
        {

            if (OpenConnection() == true)
            {

                query = "TRUNCATE TABLE assigning_limits";
                SqlQuery(query);
                cmd.ExecuteNonQuery();


                query = "INSERT INTO assigning_limits (HR,PR,SALES_F1,SALES_F2,SALES_F3,SALES_F4,DEPOT) " +
                        "VALUES (@HR,@PR,@SALES_F1,@SALES_F2,@SALES_F3,@SALES_F4,@DEPOT)";

                SqlQuery(query);

                cmd.Parameters.AddWithValue("@HR", al.HR_Limit);
                cmd.Parameters.AddWithValue("@PR", al.PR_Limit);
                cmd.Parameters.AddWithValue("@SALES_F1", al.SALES_F1_Limit);
                cmd.Parameters.AddWithValue("@SALES_F2", al.SALES_F2_Limit);
                cmd.Parameters.AddWithValue("@SALES_F3", al.SALES_F3_Limit);
                cmd.Parameters.AddWithValue("@SALES_F4", al.SALES_F4_Limit);
                cmd.Parameters.AddWithValue("@DEPOT", al.DEPOT_Limit);
                cmd.ExecuteNonQuery();

                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }


        }
        #endregion
        #region Product-related functions
        public bool AddProductToDB(Product p)
        {
            if (OpenConnection() == true)
            {
                query = "INSERT INTO products(name, price, stocks, sold, department, requested) " +
                "VALUES (@name,@price,@stocks,@sold,@department, @requested)";
                SqlQuery(query);
                cmd.Parameters.AddWithValue("@name", p.Name);
                cmd.Parameters.AddWithValue("@price", p.Price);
                cmd.Parameters.AddWithValue("@stocks", p.Stocks);
                cmd.Parameters.AddWithValue("@sold", p.Sold);
                cmd.Parameters.AddWithValue("@department", p.Category);
                cmd.Parameters.AddWithValue("@requested", p.Requested);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }

            else
            {
                conn.Close();
                return false;
            }

        }

        public bool DeleteFromProducts(Product p)
        {
            if (OpenConnection() == true)
            {
                query = "DELETE FROM products WHERE name = @name";
                SqlQuery(query);
                cmd.Parameters.AddWithValue("@name", p.Name);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }
        }

        public bool UPDATEProductsStock(Product p)
        {
            if (OpenConnection() == true)
            {
                query = "UPDATE products SET stocks = @stocks WHERE name = @name AND department = @department";
                SqlQuery(query);
                cmd.Parameters.AddWithValue("@name", p.Name);
                cmd.Parameters.AddWithValue("@stocks", p.Stocks);
                cmd.Parameters.AddWithValue("@department", p.Category);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }


        }

        public bool UPDATEProductsStockDepot(Product p)
        {
            if (OpenConnection() == true)
            {
                query = "UPDATE products SET stocks = @stocks WHERE name = @name AND department = @department";
                SqlQuery(query);
                cmd.Parameters.AddWithValue("@name", p.Name);
                cmd.Parameters.AddWithValue("@stocks", p.Stocks);
                cmd.Parameters.AddWithValue("@department", p.Category);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }


        }

        public bool UPDATEProductsSold(Product p)
        {
            if (OpenConnection() == true)
            {
                query = "UPDATE products SET sold = @sold WHERE name = @name";
                SqlQuery(query);
                cmd.Parameters.AddWithValue("@name", p.Name);
                cmd.Parameters.AddWithValue("@sold", p.Sold);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }

        }

        public bool UPDATEProductsRequest(Product p)
        {
            if (OpenConnection() == true)
            {
                query = "UPDATE products SET requested = @requested WHERE name = @name";
                SqlQuery(query);
                cmd.Parameters.AddWithValue("@name", p.Name);
                cmd.Parameters.AddWithValue("@requested", p.Requested);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }

        }

        public bool UPDATEreStock(Product p)
        {
            if (OpenConnection() == true)
            {
                query = "UPDATE products SET stocks, requested  = @stocks, @requested WHERE name = @name";
                SqlQuery(query);
                cmd.Parameters.AddWithValue("@name", p.Name);
                cmd.Parameters.AddWithValue("@stocks", p.Stocks);
                cmd.Parameters.AddWithValue("@requested", p.Requested);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }

        }

        public List<Product> GetProductsFromDB()
        {

            Department dep = Department.SALES;
            if (OpenConnection() == true)
            {
                query = "SELECT * FROM products";
                SqlQuery(query);
                QueryEx();
                MySqlDataReader datareader = cmd.ExecuteReader();
                List<Product> newListProduct = new List<Product>();


                foreach (DataRow dr in dt.Rows)
                {

                    if (newListProduct.Contains(dr["name"]))
                    {
                        break;
                    }
                    else
                    {

                        switch (dr["department"])
                        {
                            case "DEPOT":
                                dep = Department.DEPOT;
                                break;
                            case "SALES":
                                dep = Department.SALES;
                                break;

                        }
                        newListProduct.Add(new Product(dr["name"].ToString(), Convert.ToDouble(dr["price"]), Convert.ToInt32(dr["stocks"]), Convert.ToInt32(dr["sold"]), dr["department"].ToString(), Convert.ToInt32(dr["requested"])));
                    }
                }
                conn.Close();
                return newListProduct;
            }
            else
                MessageBox.Show("Nnoo");
            return null;
        }
        #endregion
        #region Absence
        public List<Absence> LoadAbsence()
        {
            if (OpenConnection() == true)
            {
                List<Absence> availability = new List<Absence>();
                query = "SELECT * FROM availability WHERE confirmation = false";
                SqlQuery(query);
                QueryEx();
                foreach (DataRow dr in dt.Rows)
                {

                    availability.Add(new Absence(Convert.ToInt32(dr["id"]),Convert.ToInt32(dr["employee_id"]),dr["first_name"].ToString(),dr["last_name"].ToString(), dr["description"].ToString(), Convert.ToDateTime(dr["startDate"]), Convert.ToDateTime(dr["endDate"])));

                }

                conn.Close();
                return availability;
            }
            else
            {
                MessageBox.Show("Loading availability failed, please make an attempt later!");
                return null;
            }

        }
        public List<Absence> LoadAcceptedAbsence()
        {
            if (OpenConnection() == true)
            {
                List<Absence> acceptedabs = new List<Absence>();
                query = "SELECT * FROM availability WHERE confirmation = true";
                SqlQuery(query);
                QueryEx();
                foreach (DataRow dr in dt.Rows)
                {

                    acceptedabs.Add(new Absence(Convert.ToInt32(dr["id"]), Convert.ToInt32(dr["employee_id"]), dr["first_name"].ToString(), dr["last_name"].ToString(), dr["description"].ToString(), Convert.ToDateTime(dr["startDate"]), Convert.ToDateTime(dr["endDate"])));

                }

                conn.Close();
                return acceptedabs;
            }
            else
            {
                MessageBox.Show("Loading availability failed, please make an attempt later!");
                return null;
            }

        }
        public bool UpdateAbsence(Absence e, bool confirmation)
        {
            if (OpenConnection())
            {
                query = "UPDATE availability SET confirmation = @Confirmation WHERE id = @ID";
                SqlQuery(query);
                cmd.Parameters.AddWithValue("@ID", e.AbsenceID );
                cmd.Parameters.AddWithValue("@Confirmation", confirmation);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            else
                return false;
        }
        public bool DeleteAbsence(Absence a)
        {
            if (OpenConnection())
            {
                query = "DELETE FROM availability WHERE id = @ID";
                SqlQuery(query);
                cmd.Parameters.AddWithValue("@ID", a.AbsenceID);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            else
                return false;
        }
        #endregion

    }
}
