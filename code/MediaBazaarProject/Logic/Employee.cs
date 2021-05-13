using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarProject.Logic
{
    public class Employee
    {
        private string firstName;
        private string lastName;
        private int workerID;
        private string gender;
        private string position;
        private Department department;
        private DateTime birthDate;
        private string birthPlace;
        private static int seederID = 1;
        private string adress;
        private string email;
        private string zipcode;
        private string city;
        private string nationality;
        private string languages;
        private int bsn;
        private double salary;
        private string pass;
        private string reason;
        private DateTime contractEnd;
        private double fte;
               
        ConnectionClass conn = new ConnectionClass();

        #region Properties
        public string FName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }
        public string LName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
        public string Pass
        {
            get { return this.pass; }
            set { this.pass = value; }
        }
        
        public int WorkrID
        {
            get { return this.workerID; }
            private set { this.workerID = value; }

        }
        public string Gender
        {
            get { return this.gender; }
            set { this.gender = value; }
        }
        public string Positions
        {
            get { return this.position; }
            set { this.position = value; }
        }
        public Department Department
        {
            get { return this.department; }
            set { this.department = value; }
        }
        public DateTime BirthDate
        {
            get { return this.birthDate; }
            set { this.birthDate = value; }
        }
        public string BirthPlace
        {
            get { return this.birthPlace; }
            set
            {
                this.birthPlace = value;
            }
        }
        public string Adress
        {
            get { return this.adress; }
            set { this.adress = value; }
        }
        public string Zipcode
        {
            get { return this.zipcode; }
            set { this.zipcode = value; }
        }
        public string City
        {
            get { return this.city; }
            set { this.city = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public string Nationality
        {
            get { return this.nationality; }
            set { this.nationality = value; }
        }
        public string Languages
        {
            get { return this.languages; }
            set { this.languages = value; }
        }
        public int BSN
        {
            get { return this.bsn; }
            set { this.bsn = value; }
        }
        public double Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }
        public double FTE
        {
            get { return this.fte; }
            set { this.fte = value; }
        }

        public string Reason
        {
            get { return this.reason; }
            set { this.reason = value; }
        }
        public DateTime ContractEnd
        {
            get { return this.contractEnd; }
            set { this.contractEnd = value; }
        }
        
        #endregion
        //Getting employee
        public Employee(int workerID,string fname, string lname, Gender gender, Position position, Department department, DateTime birthdate, string birthplace, string city, string zipcode, string adress, string email, string nationality, string languages, int bsn, DateTime ContractEnd, double FTE)
        {

            this.workerID = workerID;
            if (seederID <= workerID)
            {
                seederID = workerID + 1;
            }
            this.firstName = fname;
            this.lastName = lname;
            this.city = city;
            this.zipcode = zipcode;
            this.gender = gender.ToString();
            this.position = position.ToString();
            this.department = department;
            this.birthDate = birthdate;
            this.birthPlace = birthplace;
            this.adress = adress;
            this.email = email;
            this.nationality = nationality;
            this.languages = languages;
            this.bsn = bsn;
            this.contractEnd = ContractEnd;
            this.fte = FTE;
            //GenerateRandomPassword();
            if (this.position == Position.CEO.ToString())
                this.salary = 3000;
            else if (this.position == Position.EMPLOYEE.ToString())
                this.salary = 1000;
            else if (this.position == Position.MANAGER.ToString())
                this.salary = 2000;

        }
        //Adding new employee
        public Employee(string fname, string lname, Gender gender, Position position, Department department, DateTime birthdate, string birthplace, string city, string zipcode, string adress, string email, string nationality, string languages, int bsn, DateTime ContractEnd, double FTE)
        {
            this.firstName = fname;
            this.lastName = lname;
            this.workerID = seederID;
            seederID++;
            this.city = city;
            this.zipcode = zipcode;
            this.gender = gender.ToString();
            this.position = position.ToString();
            this.department = department;
            this.birthDate = birthdate;
            this.birthPlace = birthplace;
            this.adress = adress;
            this.email = email;
            this.nationality = nationality;
            this.languages = languages;
            this.bsn = bsn;
            this.contractEnd = ContractEnd;
            this.fte = FTE;
            GenerateRandomPassword();
            if (this.position == Position.CEO.ToString())
                this.salary = 3000;
            else if (this.position == Position.EMPLOYEE.ToString())
                this.salary = 1000;
            else if (this.position == Position.MANAGER.ToString())
                this.salary = 2000;

        }
        //Former employees
        public Employee(string fname, string lname, Gender gender, Position position, Department department, DateTime birthdate, string birthplace, string city, string zipcode, string adress, string email, string nationality, string languages, int bsn, string reason)
        {


            this.firstName = fname;
            this.lastName = lname;
            this.city = city;
            this.zipcode = zipcode;
            this.gender = gender.ToString();
            this.position = position.ToString();
            this.department = department;
            this.birthDate = birthdate;
            this.birthPlace = birthplace;
            this.adress = adress;
            this.email = email;
            this.nationality = nationality;
            this.languages = languages;
            this.bsn = bsn;
            this.reason = reason;
            GenerateRandomPassword();
            if (this.position == Position.CEO.ToString())
                this.salary = 3000;
            else if (this.position == Position.EMPLOYEE.ToString())
                this.salary = 1000;
            else if (this.position == Position.MANAGER.ToString())
                this.salary = 2000;

        }
        public Employee(string fname, string lname, string email)
        {
            this.email = email;
            this.firstName = fname;
            this.lastName = lname;
        }
       
        public void GenerateRandomPassword()
        {
            int minLenght = 8;
            int maxLenght = 12;

            string charAvailable = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            StringBuilder password = new StringBuilder();
            Random rdm = new Random();

            int passwordLenght = rdm.Next(minLenght, maxLenght + 1);
            while (passwordLenght-- > 0)
            {
                password.Append(charAvailable[rdm.Next(charAvailable.Length)]);
            }
            this.pass = password.ToString();
        }
        #region OldQueries
        //public bool EndedContractEmployee()
        //{
        //    conn.SqlQuery("SELECT * FROM endedcontract WHERE FirstName = '" + this.firstName + "' AND LastName = '" + this.lastName + "'");
        //    conn.QueryEx();
        //    if (conn.QueryEx() == false)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}
        //public void AddToSchedule()
        //{
        //    conn.OpenCon();
        //    conn.SqlQuery("INSERT INTO schedule (FirstName_Assigned, LastName_Assigned, Email, Department) " +
        //        "VALUES (@FirstName_Assigned,@LastName_Assigned,@Email,@Department)");
        //    conn.AddWithValue("@FirstName_Assigned", this.firstName);
        //    conn.AddWithValue("@LastName_Assigned", this.lastName);
        //    conn.AddWithValue("@Email", this.email);
        //    conn.AddWithValue("@Department", this.department);
        //    conn.NonQueryEx();
        //    conn.Close();


        //}
        //public bool AddToDB()
        //{
        //    conn.SqlQuery("SELECT * FROM employees WHERE FirstName = '" + this.firstName + "' AND LastName = '" + this.lastName + "' AND Email='" + this.email + "' ");
        //    conn.QueryEx();
        //    if (conn.QueryEx() == false)
        //    {
        //        conn.SqlQuery("INSERT INTO employees (FirstName,LastName,Password,Gender,Birthdate,Birthplace,Email,Department,Nationality,Language,BSN,Salary,City,Zipcode,Address,Position) " +
        //        "VALUES (@FirstName,@LastName,@Password,@Gender,@Birthdate,@Birthplace,@Email,@Department,@Nationality,@Language,@BSN,@Salary,@City,@Zipcode,@Address,@Position)");
        //        conn.AddWithValue("@FirstName", this.firstName);
        //        conn.AddWithValue("@LastName", this.lastName);
        //        conn.AddWithValue("@Password", this.pass);
        //        conn.AddWithValue("@Gender", this.gender);
        //        conn.AddWithValue("@Birthdate", this.birthDate);
        //        conn.AddWithValue("@Birthplace", this.birthPlace);
        //        conn.AddWithValue("@Email", this.email);
        //        conn.AddWithValue("@Department", this.department);
        //        conn.AddWithValue("@Nationality", this.nationality);
        //        conn.AddWithValue("@City", this.city);
        //        conn.AddWithValue("@Zipcode", this.zipcode);
        //        conn.AddWithValue("@Language", this.languages);
        //        conn.AddWithValue("@BSN", this.bsn);
        //        conn.AddWithValue("@Salary", this.salary);
        //        conn.AddWithValue("@Address", this.adress);
        //        conn.AddWithValue("@Position", this.position);
        //        conn.NonQueryEx();
        //        conn.Close();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;

        //    }

        //}
        #endregion
    }
}
