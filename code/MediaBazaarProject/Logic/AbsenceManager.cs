using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarProject.Logic
{
    public class AbsenceManager
    {
        ConnectionClass conn;
        List<Absence> absenceempl;

        public AbsenceManager()
        {
            absenceempl = new List<Absence>();
            conn = new ConnectionClass();
        }
        public void LoadAllAbsenceRequest()
        {
            foreach (Absence item in conn.LoadAbsence())
            {
                absenceempl.Add(item);
            }
        }
        public Absence GetAbsenceRequest(int id)
        {
            foreach (Absence item in absenceempl)
            {
                if(item.AbsenceID == id)
                {
                    return item;
                }
            }
            return null;
        }
        public List<Absence> GetAllAbsenceRequest()
        {
            return absenceempl;
        }
        public string GetDescription(int id)
        {
            Absence a = GetAbsenceRequest(id);
            if(a!=null)
            {
                return a.Description;
            }
            return null;
        }
        public void AcceptAbsence(Absence a, bool accept)
        {
            conn.UpdateAbsence(a, accept);
        }
        public void DeclineAbsence(Absence a)
        {
            conn.DeleteAbsence(a);
        }
    }
}
