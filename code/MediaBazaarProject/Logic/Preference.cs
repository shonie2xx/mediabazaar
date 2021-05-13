using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarProject.Logic
{
    public class Preference
    {
        private int id;
        private int employee_ID;
        private int shiftNumber;
        private string weekday;

        public Preference(int id,int eID,int shifNumb,string weekday)
        {
            this.id = id;
            this.employee_ID = eID;
            this.shiftNumber = shifNumb;
            this.weekday = weekday;
        }
        public int ID
        {
            get { return this.id; }
        }
        public int EmployeeID
        {
            get { return this.employee_ID; }
        }
        public int ShiftNumber
        {
            get { return this.shiftNumber; }
        }
        public string Weekday
        {
            get { return this.weekday; }
        }
    }
}
