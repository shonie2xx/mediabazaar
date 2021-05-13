using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarProject.Logic
{
    public class Shift
    {
        private DateTime date;
        private Department department;
        private int shiftNumber;
        private string storeFLOOR = null;
        public static int shiftSeeder = 1;
        private int shiftID;
        List<Employee> assignedEmployees;
        #region Properties
        public int ShiftID
        {
            get { return this.shiftID; }
        }
        public List<Employee> EmployeesAssigned
        {
            get { return this.assignedEmployees; }
        }
        public void SetShiftSeeder(int id)
        {
            if (id > 1)
            {
                shiftSeeder = id;
            }
            
        }
        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }
        public string FloorOfStore
        {
            get
            {
                if (this.department == Department.SALES)
                {
                    return this.storeFLOOR;
                }
                else
                {
                    return "";
                }
            }
            set { this.storeFLOOR = value; }
        }
        public Department DepartmentGet
        {
            get { return this.department; }
            set { this.department = value; }
        }
        
        public int ShiftNumber
        {
            get { return this.shiftNumber; }
        }
        #endregion
        //Create new shift
        public Shift(DateTime date, int shiftNumber, Department department)
        {
            assignedEmployees = new List<Employee>();
            this.shiftNumber = shiftNumber;
            this.department = department;
            this.date = date;
            this.shiftID = shiftSeeder;
            shiftSeeder++;

        }
        //Create new shift DEPARTMENT SALES
        public Shift(DateTime date, int shiftNumber, Department department,string storefloor)
        {
            assignedEmployees = new List<Employee>();
            this.shiftNumber = shiftNumber;
            this.department = department;
            this.date = date;
            this.storeFLOOR = storefloor;
            this.shiftID = shiftSeeder;
            shiftSeeder++;

        }
        //Load shift Constructor
        public Shift(int shiftnumber, int shiftid, string par_department, DateTime date, string floor)
        {
            assignedEmployees = new List<Employee>();
            this.shiftID = shiftid;
            if (shiftSeeder <= shiftid)
            {
                shiftSeeder = shiftid + 1;
            }
          
          
            this.date = date;
            this.shiftNumber = shiftnumber;
            
            switch (par_department)
            {
                case "DEPOT":
                    this.department = Department.DEPOT;
                    break;
                case "SALES":
                    this.department = Department.SALES;
                    this.storeFLOOR = floor;
                    break;
                case "HUMANRESOURCES":
                    this.department = Department.HUMANRESOURCES;
                    break;
                case "PR":
                    this.department = Department.PR;
                    break;
            }

        }
        
        public void AssignEmployee(Employee e)
        {
            assignedEmployees.Add(e);
           
        }
        public void UnassignEmployee(Employee e)
        {
            assignedEmployees.Remove(e);
        }

    }
}
