using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarProject.Logic
{
    public class PositionLog
    {
        private string fname;
        private string lname;
        private string dep;
        private string pos;
        private DateTime date;
        public PositionLog(string FirstName, string LastName, string dep, string pos, DateTime date)
        {
            this.fname = FirstName;
            this.lname = LastName;
            this.dep = dep;
            this.pos = pos;
            this.date = date;
        }
        public string FirstName
        {
            get { return this.fname; }
            set { this.fname = value; }
        }
        public string LastName
        {
            get { return this.lname; }
            set { this.lname = value; }
        }
        public string Department
        {
            get { return this.dep; }
            set { this.dep = value; }
        }
        public string ChangedTo
        {
            get { return this.pos; }
            set { this.pos = value; }
        }
        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

    }
}
