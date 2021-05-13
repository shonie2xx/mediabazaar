using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarProject.Logic
{
    public class BazaarManagment
    {
        ConnectionClass conn = new ConnectionClass();
        List<Employee> employees = new List<Employee>();
        List<Employee> newEmployees = new List<Employee>();
        List<Employee> formerEmployees = new List<Employee>();
        List<Employee> newformerEmployees = new List<Employee>();
        List<PositionLog> pos = new List<PositionLog>();

        List<Product> reqProducts = new List<Product>();
        List<Product> loadProducts = new List<Product>();
        List<Product> ProdSales = new List<Product>();
        List<Product> ProdDepot = new List<Product>();

        public Employee[] newEmployeesList { get { return this.newEmployees.ToArray(); } }

        #region Employees
        public void AddNewEmployee(string fname, string lname,Gender gender,Position position,Department department,DateTime birthdate, string birthplace, string city, string zipcode, string adress, string email, string nationality, string language,int bsn, DateTime ContractEnd, double FTE)
        {
            newEmployees.Add(new Employee(fname, lname, gender, position, department, birthdate, birthplace, city, zipcode, adress, email, nationality, language, bsn, ContractEnd, FTE));
        }
        public Employee GetEmployeeByName(string fname)
        {
            foreach(Employee e in employees)
            {
                if(e.FName == fname)
                {
                    return e;
                }
            }
            return null;
        }
        public List<Employee> GetAllNewEmployees()
        {
            return this.newEmployees;
        }
        public List<Employee> GetAllEmployees()
        {
            return this.employees;
        }
        private void SendMail(Employee employee, string email, string pass)
        {
            var message = new MailMessage("mediabazaarproject@gmail.com",email);
            message.Subject = "Welcome to our company";
            message.Body = $"Hello,  \nWelcome to your new Job! \n\n Your username is your email: {email} \n Your passowrd is:  {pass} \n You can change your password later in our app! \n\nKind regards,\nMediaBazaar ";

            //Simple Mail Transfer Protocol
            using (SmtpClient mailer = new SmtpClient("smtp.gmail.com", 587))
            {
                mailer.Credentials = new NetworkCredential("mediabazaarproject@gmail.com", "TestPassForOurProject");
                mailer.EnableSsl = true;
                mailer.Send(message);
            }

        }
        public void AddEmployeesToDB()
        {
            foreach(Employee e in newEmployees)
            {
                conn.INSERTEmployeesToDB(e);
                SendMail(e, e.Email, e.Pass);
            }
        }
        public void LoadAllEmployees(Department department)
        {
            employees.Clear();
            foreach(Employee e in conn.GetEmployees())
            {
                if(e.Department == department)
                {
                    employees.Add(e);
                }
                
            }
            employees.AddRange(newEmployees);
        }
        public void LoadAllEmployees()
        {
            foreach (Employee e in conn.GetEmployees())
            {
                employees.Add(e);
            }

        }
       

        public void UPDATEManagePosition(string email,string position)
        {

            foreach(Employee e in employees)
            {
                if(e.Email == email)
                {
                    conn.UPDATEPositions(e, position);
                }
            }
        }
        public bool UpdateContract(string email, DateTime contractEnd)
        {
            foreach(Employee e in employees)
            {
                if(e.Email == email)
                {
                    conn.UPDATEContract(e,contractEnd);
                    return true;
                }
            }
            return false;
        }

        public void AddToFormerEmployees(string email, string reason)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Email == email)
                {
                    newformerEmployees.Add(employees[i]);
                    employees.Remove(employees[i]);
                }
            }
            foreach(Employee e in newformerEmployees)
            {
                conn.DeleteFromEmployees(e);
                conn.INSERTFormerEmployeesToDB(e, reason);
            }
        }

        #endregion

        #region Position Log
        public void AddToPositionHistory(string email, string pos)
        {
            foreach(Employee e in employees)
            {
                if(e.Email == email)
                {
                    conn.INSERTPositionHistory(e, pos);
                }
            }
        }

        public void LoadPositionLog()
        {
            pos.Clear();
            foreach(PositionLog p in conn.GetPositionLogs())
            {
                pos.Add(p);
            }
        }
        public List<PositionLog> GetPositionLogs()
        {
            return this.pos;
        }
        public PositionLog GetPositionLogByName(string fname)
        {
            foreach (PositionLog p in pos)
            {
                if (p.FirstName == fname)
                {
                    return p;
                }
            }
            return null;
        }

        #endregion

        #region FormerEmployees
        public void LoadAllFormerEmployees()
        {
            foreach (Employee e in conn.GetFormerEmployees())
            {
                formerEmployees.Add(e);
            }
        }
        public void LoadAllFormerEmployees(Department department)
        {
            formerEmployees.Clear();
            foreach (Employee e in conn.GetFormerEmployees())
            {
                if(e.Department == department)
                {
                    formerEmployees.Add(e);
                }
                
            }
        }
        public List<Employee> GetAllFormerEmployees()
        {
            return this.formerEmployees;
        }
        public Employee GetEmployeeByEmail(string email)
        {
            foreach (Employee e in employees)
            {
                if (e.Email == email)
                {
                    return e;
                }
            }
            return null;
        }
        public Employee GetFormerEmployeeByEmail(string email)
        {
            foreach (Employee e in formerEmployees)
            {
                if (e.Email == email)
                {
                    return e;
                }
            }
            return null;
        }
        public Employee GetFormerEmployeeByName(string fname)
        {
            foreach (Employee e in formerEmployees)
            {
                if (e.FName == fname)
                {
                    return e;
                }
            }
            return null;
        }
        public void RetrieveEmployee(string email)
        {

            
            foreach (Employee e in formerEmployees)
            {
                if (e.Email == GetFormerEmployeeByEmail(email).Email)
                {
                    newEmployees.Add(e);
                    conn.DeleteFromEndedContract(e);
                }
            }
            employees.AddRange(newEmployees);
        }
        public void DeleteEmployee(string email)
        {
            foreach (Employee e in formerEmployees)
            {
                if (e.Email == GetFormerEmployeeByEmail(email).Email)
                {
                    conn.DeleteFromEndedContract(e);
                }
            }
        }

        #endregion

        public List<Product> LoadAllProducts()
        {
            foreach (Product p in conn.GetProductsFromDB())
            {
                loadProducts.Add(p);
            }
            return loadProducts;
        }

        public List<Product> LoadSalesProds()
        {
            foreach(Product p in conn.GetProductsFromDB())
            {
                if(p.Category == "SALES")
                {
                    ProdSales.Add(p);
                }
            }
            return ProdSales;
        }

        public List<Product> LoadDepotProds()
        {
            foreach (Product p in conn.GetProductsFromDB())
            {
                if (p.Category == "DEPOT")
                {
                    ProdDepot.Add(p);
                }
            }
            return ProdDepot;
        }

        public List<Product> LoadRequestedProducts()
        {
            foreach (Product p in conn.GetProductsFromDB())
            {
                if(p.Requested > 0)
                {
                    reqProducts.Add(p);
                }
            }
            return reqProducts;
        }

        public void AddProductinSALES(Product p)
        {

            ProdSales.Add(p);
        }

        public void AddProductinDEPOT(Product p)
        {
            ProdDepot.Add(p);

        }

        public void AddProductinRequest(Product p)
        {
            reqProducts.Add(p);

        }

        public void UPDATEprodStock(string name)
        {
            
            foreach (Product p in ProdSales)
            {
                if (p.Name == name && p.Category == "SALES")
                {
                    conn.UPDATEProductsStock(p);
                }
            }
        }

        public void UPDATEprodSold(string name)
        {

            foreach (Product p in ProdSales)
            {
                if (p.Name == name)
                {
                    conn.UPDATEProductsSold(p);
                }
            }
        }

        public void UPDATEprodRequest(string name)
        {

            foreach (Product p in ProdSales)
            {
                if (p.Name == name)
                {
                    conn.UPDATEProductsRequest(p);
                }
            }
        }

        public void UPDATEprodStockR(string name)
        {

            foreach (Product p in reqProducts)
            {
                if (p.Name == name)
                {
                    conn.UPDATEProductsStock(p);
                }
            }
        }

        public void UPDATEprodStockDepot(string name)
        {
            foreach(Product p in ProdDepot)
            {
                if(p.Name == name && p.Category == "DEPOT")
                {
                    conn.UPDATEProductsStockDepot(p);
                }
            }
        }

        

        public void UPDATEprodRequestR(string name)
        {

            foreach (Product p in reqProducts)
            {
                if (p.Name == name)
                {
                    conn.UPDATEProductsRequest(p);
                }
            }
        }

    }
}
