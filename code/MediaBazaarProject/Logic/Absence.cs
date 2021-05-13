using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarProject.Logic
{
    public class Absence
    {
        private int id;
        private int employee_id;
        private string firstName;
        private string lastName;
        private string description;
        private DateTime startDate;
        private DateTime endDate;

        #region Properties
        public int AbsenceID
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public int EmployeeID
        {
            get { return this.employee_id; }
            set { this.employee_id = value; }
        }
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
        public DateTime StartDate
        {
            get { return this.startDate; }
            set { this.startDate = value; }
        }
        public DateTime EndDate
        {
            get { return this.endDate; }
            set { this.endDate = value; }
        }
        #endregion
        public Absence(int id,int employeeId,string firstName,string lastName,string desc,DateTime sDate,DateTime eDate)
        {
            AbsenceID = id;
            EmployeeID = employeeId;
            FirstName = firstName;
            LastName = lastName;
            Description = desc;
            StartDate = sDate;
            EndDate = eDate;
        }



    }
}
