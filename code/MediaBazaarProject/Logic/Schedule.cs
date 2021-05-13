using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarProject.Logic
{
    public class Schedule
    {
        ConnectionClass conn = new ConnectionClass();
        #region Collections
        List<Employee> fullListemployees;
        List<Employee> formerEList;
        List<Shift> allshifts;
        List<Shift> newshifts;
        List<Shift> presentAndFutureShifts;
        List<Shift> stageforChanges;
        List<Preference> preferences;
        List<Absence> availability;
        AsssigningLimit limitStorage;
        #endregion
        #region Properties
        private Department department;
        private string storefloor = "Household appliances";
        private DateTime firstDayOfCurrentWeek;
        public string StoreFloor
        {
            get { return this.storefloor; }
            set { this.storefloor = value; }
        }
        public Department DepartmentD
        {
            get { return this.department; }
        }
        public string DepartmentStr
        {
            get
            {
                string d = "";
                switch (this.department)
                {
                    case Department.HUMANRESOURCES:
                        d = "human resources";
                        break;
                    default:
                        d = DepartmentD.ToString().ToLower();
                        break;
                }
                return d;
            }
        }
        public AsssigningLimit SchedulerLimit
        {
            get { return this.limitStorage; }
        }
        #endregion
        #region Loading Collections
        public Schedule(List<Employee> existing, List<Employee> newemployees, List<Employee> formeremployees, Department department)
        {
            this.department = department;
            firstDayOfCurrentWeek = TimeControl.FirstDayOfWeek(DateTime.Today);
            fullListemployees = existing;
            formerEList = formeremployees;
            stageforChanges = new List<Shift>();

            foreach (Employee ne in newemployees)
            {
                if (!fullListemployees.Contains(ne))
                {
                    fullListemployees.Add(ne);
                }
            }

            allshifts = conn.LoadShifts(department, fullListemployees);
            newshifts = new List<Shift>();
            presentAndFutureShifts = new List<Shift>();
            foreach (Shift s in allshifts)
            {
                if (s.Date >= firstDayOfCurrentWeek)
                {
                    presentAndFutureShifts.Add(s);
                }

            }
            preferences = conn.LoadPreferences();
            availability = conn.LoadAcceptedAbsence();
            limitStorage = conn.LoadAssigningLimits();
        }
        public List<Preference> PreferencesFilterByWeekday(DateTime day)
        {
            List<Preference> tempList = new List<Preference>();
            foreach (Preference p in preferences)
            {
                if (p.Weekday == CheckDate(day))
                {
                    tempList.Add(p);
                }
            }
            return tempList;

        }
        public void KeepInCheck(List<Employee> employees)
        {
            foreach (Employee ne in employees)
            {
                if (!fullListemployees.Contains(ne))
                {
                    fullListemployees.Add(ne);
                }
            }
        }
        #endregion
        #region DateManaging
        public string CheckDate(DateTime givendate)
        {
            string LivingDate = givendate.ToString("dddd");



            return LivingDate;
        }
        public string CheckDateNum(DateTime givendate)
        {
            string LivingDateNum = givendate.ToString("dd.MM.yyy");
            return LivingDateNum;
        }
        public void CheckDayShift(DateTime day)
        {
            if (this.department != Department.SALES)
            {
                Shift shift1 = presentAndFutureShifts.Find(x => (x.Date == day) && (x.ShiftNumber == 1));
                if (shift1 == null)
                {
                    Shift create = new Shift(day, 1, this.department);
                    newshifts.Add(create);
                    allshifts.Add(create);
                    presentAndFutureShifts.Add(create);

                }

                Shift shift2 = presentAndFutureShifts.Find(x => (x.Date == day) && (x.ShiftNumber == 2));
                if (shift2 == null)
                {
                    Shift create = new Shift(day, 2, this.department);
                    newshifts.Add(create);
                    allshifts.Add(create);
                    presentAndFutureShifts.Add(create);
                }
                Shift shift3 = presentAndFutureShifts.Find(x => (x.Date == day) && (x.ShiftNumber == 3));
                if (shift3 == null)
                {
                    Shift create = new Shift(day, 3, this.department);
                    newshifts.Add(create);
                    allshifts.Add(create);
                    presentAndFutureShifts.Add(create);
                }
            }
            else
            {
                Shift shift1 = presentAndFutureShifts.Find(x => (x.Date == day) && (x.ShiftNumber == 1) && (x.FloorOfStore == this.storefloor));
                if (shift1 == null)
                {
                    Shift create = new Shift(day, 1, this.department, this.storefloor);
                    newshifts.Add(create);
                    allshifts.Add(create);
                    presentAndFutureShifts.Add(create);

                }

                Shift shift2 = presentAndFutureShifts.Find(x => (x.Date == day) && (x.ShiftNumber == 2) && (x.FloorOfStore == this.storefloor));
                if (shift2 == null)
                {
                    Shift create = new Shift(day, 2, this.department, this.storefloor);
                    newshifts.Add(create);
                    allshifts.Add(create);
                    presentAndFutureShifts.Add(create);
                }
                Shift shift3 = presentAndFutureShifts.Find(x => (x.Date == day) && (x.ShiftNumber == 3) && (x.FloorOfStore == this.storefloor));
                if (shift3 == null)
                {
                    Shift create = new Shift(day, 3, this.department, this.storefloor);
                    newshifts.Add(create);
                    allshifts.Add(create);
                    presentAndFutureShifts.Add(create);
                }
            }


        }
        #endregion
        #region Shift Managing
        public int FindShiftID(DateTime date, int shiftnumber)
        {

            foreach (Shift s in presentAndFutureShifts)
            {
                if (s.Date == date && s.ShiftNumber == shiftnumber)
                {
                    if (department == Department.SALES)
                    {
                        if (s.FloorOfStore == storefloor)
                        {
                            return s.ShiftID;
                        }
                    }
                    else
                    {
                        return s.ShiftID;
                    }
                }
            }
            return 0;
        }
        public Shift FindShift(DateTime date, int shiftnumber)
        {
            int id = FindShiftID(date, shiftnumber);
            Shift shift = presentAndFutureShifts.Find(x => x.ShiftID == id);
            return shift;
        }
        public string CheckShiftAssignedCountString(DateTime date, int shiftnumber)
        {
            CheckDayShift(date);
            int id = FindShiftID(date, shiftnumber);
            string status = "";
            int counter = 0;
            foreach (Shift s in presentAndFutureShifts)
            {
                if (s.ShiftID == id)
                {
                    foreach (Employee e in s.EmployeesAssigned)
                    {
                        counter++;
                    }
                }
            }
            if (counter == 0)
            {
                status = "No workers are assigned";
            }
            else if (counter > 0)
            {
                status = "Assigned workers: " + counter.ToString();
            }

            return "Shift " + shiftnumber + ": " + status;
        }
        public int CheckShiftAssignedCount(Shift shift)
        {
            int counter = 0;
            foreach (Employee e in shift.EmployeesAssigned)
            {
                counter++;
            }

            return counter;
        }
        public int GetShiftAssignedCount(DateTime date)
        {
            CheckDayShift(date);


            int counter = 0;
            foreach (Shift s in presentAndFutureShifts)
            {
                if (s.Date == date)
                {
                    foreach (Employee e in s.EmployeesAssigned)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
        public List<Shift> Example
        {
            get { return this.presentAndFutureShifts; }
        }
        public List<Employee> GiveAllEmployeesForDayNotAssigned(DateTime day)
        {
            List<Employee> tempList = new List<Employee>();
            List<Employee> tempList2 = new List<Employee>();
            foreach (Shift s in presentAndFutureShifts)
            {
                if (s.EmployeesAssigned.Count > 0)
                {
                    if (s.Date == day)
                    {
                        foreach (Employee em in s.EmployeesAssigned)
                        {
                            tempList2.Add(em);
                        }
                    }
                }
            }
            foreach (Shift s in presentAndFutureShifts)
            {
                if (s.Date == day)
                {
                    foreach (Employee e in fullListemployees)
                    {
                        if (!s.EmployeesAssigned.Exists(x => x.WorkrID == e.WorkrID))
                        {

                            if (department == Department.SALES)
                            {
                                if (s.FloorOfStore == storefloor)
                                {
                                    if (!tempList.Exists(x => x.WorkrID == e.WorkrID) && !tempList2.Exists(i => i.WorkrID == e.WorkrID))
                                    {
                                        tempList.Add(e);
                                    }
                                }
                            }
                            else
                            {
                                if (!tempList.Exists(x => x.WorkrID == e.WorkrID) && !tempList2.Exists(i => i.WorkrID == e.WorkrID))
                                {
                                    tempList.Add(e);
                                }
                            }
                        }

                    }
                }
            }
            return tempList;
        }
        public List<Shift> GiveAllShiftForDay(DateTime day)
        {
            List<Shift> tempList = new List<Shift>();
            foreach (Shift s in presentAndFutureShifts)
            {
                if (s.Date == day)
                {

                    tempList.Add(s);

                }
            }
            return tempList;
        }
        public void AssignEmployeeToShift(int employeeID, DateTime day,int shiftNumber)
        {
            int primaryShiftNumber=shiftNumber;
            Employee employee = fullListemployees.Find(x => x.WorkrID == employeeID);
            if (shiftNumber == 4)
            {
                Shift secondaryShift = FindShift(day, 2);
                secondaryShift.AssignEmployee(employee);
                primaryShiftNumber = 1;
                if (!stageforChanges.Exists(i => i.ShiftID == secondaryShift.ShiftID))
                {
                    stageforChanges.Add(secondaryShift);
                }
            }
            if (shiftNumber == 5)
            {
                Shift secondaryShift = FindShift(day, 3);
                secondaryShift.AssignEmployee(employee);
                primaryShiftNumber = 2;
                if (!stageforChanges.Exists(i => i.ShiftID == secondaryShift.ShiftID))
                {
                    stageforChanges.Add(secondaryShift);
                }
            }
            if (shiftNumber == 6)
            {
                Shift secondaryShift = FindShift(day, 2);
                secondaryShift.AssignEmployee(employee);
                Shift tretiaryShift = FindShift(day, 3);
                tretiaryShift.AssignEmployee(employee);
                primaryShiftNumber = 1;
                if (!stageforChanges.Exists(i => i.ShiftID == secondaryShift.ShiftID))
                {
                    stageforChanges.Add(secondaryShift);
                }
                if (!stageforChanges.Exists(i => i.ShiftID == tretiaryShift.ShiftID))
                {
                    stageforChanges.Add(tretiaryShift);
                }
            }
            Shift shift = FindShift(day, primaryShiftNumber);
            shift.AssignEmployee(employee);

            if (!stageforChanges.Exists(i => i.ShiftID == shift.ShiftID))
            {
                stageforChanges.Add(shift);
            }

        }
        public double CheckEmployeeWorkingDaysCount(Employee e, DateTime selectedDay)
        {
            double counter = 0;
            List<Shift> weekShifts = GetAllShiftsForAWeek(selectedDay);
            foreach (Shift s in weekShifts)
            {
                if (s.EmployeesAssigned.Contains(e))
                {
                    counter += 1;
                }
            }
            counter /= 10;
            return counter;
        }
        public List<Shift> GetAllShiftsForAWeek(DateTime day)
        {
            DateTime firstDayOfSelectedWeek = TimeControl.FirstDayOfWeek(day);
            List<Shift> templist = new List<Shift>();
            foreach (Shift s in presentAndFutureShifts)
            {
                if (s.Date >= firstDayOfSelectedWeek && s.Date <= firstDayOfSelectedWeek.AddDays(6))
                {
                    templist.Add(s);
                }
            }
            return templist;
        }
        public List<Employee> GetEmployeesAvailableForAutomatedScheduling(DateTime day)
        {
            List<Employee> tempList = new List<Employee>();
            foreach (Employee e in GiveAllEmployeesForDayNotAssigned(day))
            {

                if (CheckEmployeeWorkingDaysCount(e, day) <Convert.ToDouble( e.FTE))
                {
                    Absence absence = availability.Find(x => x.EmployeeID == e.WorkrID);
                    if (absence != null)
                    {
                        if (absence.StartDate <= day && absence.EndDate < day)
                        {
                                tempList.Add(e);
                            
                        }
                    }
                    else
                    {
                        tempList.Add(e);
                    }

                }

            }
            return tempList;
        }
        public bool CheckShiftBusyness(int shiftNumber,DateTime day)
        {
            if (shiftNumber == 4)
            {
                Shift shift = FindShift(day, 1);
                if (CheckShiftLimitations(shift)){
                    Shift shift2 = FindShift(day, 2);
                    if (CheckShiftLimitations(shift2))
                    {
                        return true;
                    }
                    else { return false; }
                }
                else { return false; }
            }
            else if (shiftNumber == 5)
            {
                Shift shift = FindShift(day, 2);
                if (CheckShiftLimitations(shift))
                {
                    Shift shift2 = FindShift(day, 3);
                    if (CheckShiftLimitations(shift2))
                    {
                        return true;
                    }
                    else { return false; }
                }
                else { return false; }
            }
            else if (shiftNumber == 6)
            {

                Shift shift = FindShift(day, 1);
                if (CheckShiftLimitations(shift))
                {
                    Shift shift2 = FindShift(day, 2);
                    if (CheckShiftLimitations(shift2))
                    {
                        Shift shift3 = FindShift(day, 3);
                        if (CheckShiftLimitations(shift3))
                        {
                            return true;
                        }
                        else { return false; }
                    }
                    else { return false; }
                }
                else { return false; }
            }
            else
            {
                Shift shift = FindShift(day, shiftNumber);
                if (CheckShiftLimitations(shift))
                {
                    return true;
                }
                else { return false; }
            }
        }
        public bool UpdateLimitations(int hr, int pr, int slf1, int slf2, int slf3, int slf4, int dp)
        {
            limitStorage.HR_Limit = hr;
            limitStorage.PR_Limit = pr;
            limitStorage.SALES_F1_Limit = slf1;
            limitStorage.SALES_F2_Limit = slf2;
            limitStorage.SALES_F3_Limit = slf3;
            limitStorage.SALES_F4_Limit = slf4;
            limitStorage.DEPOT_Limit = dp;
            conn.SaveNewAssigningLimits(limitStorage);
            return true;
        }
        public bool CheckShiftLimitations(Shift shift) 
        {
            if (shift != null)
            {
                if (department != Department.SALES)
                {
                    if (department == Department.HUMANRESOURCES)
                    {
                        if (CheckShiftAssignedCount(shift) < limitStorage.HR_Limit)
                        {
                            return true;
                        }
                        else { return false; }
                    }
                    else if (department == Department.DEPOT)
                    {
                        if (CheckShiftAssignedCount(shift) < limitStorage.DEPOT_Limit)
                        {
                            return true;
                        }
                        else { return false; }
                    }
                    else if (department == Department.PR)
                    {
                        if (CheckShiftAssignedCount(shift) < limitStorage.PR_Limit)
                        {
                            return true;
                        }
                        else { return false; }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (shift.FloorOfStore == "Household appliances")
                    {
                        if (CheckShiftAssignedCount(shift) < limitStorage.SALES_F1_Limit)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if(shift.FloorOfStore== "Laptops")
                    {
                        if (CheckShiftAssignedCount(shift) < limitStorage.SALES_F2_Limit)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if(shift.FloorOfStore== "Hardware")
                    {
                        if (CheckShiftAssignedCount(shift) < limitStorage.SALES_F3_Limit)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if(shift.FloorOfStore== "Music, movies and games")
                    {
                        if (CheckShiftAssignedCount(shift) < limitStorage.SALES_F4_Limit)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else { return false; }
                }
            }

            else
            {
                return false;
            }
        }
        public void AutomatedAssignmentForADay(DateTime day)
        {
            List<Employee> availableEmployees = GetEmployeesAvailableForAutomatedScheduling(day);
            foreach (Preference p in preferences)
            {
                if (p.Weekday == CheckDate(day))
                {
                    Employee employeeSearch = availableEmployees.Find(x => x.WorkrID == p.EmployeeID);
                    if (employeeSearch != null)
                    {
                        if (CheckShiftBusyness(p.ShiftNumber, day))
                        {
                            AssignEmployeeToShift(p.EmployeeID, day,p.ShiftNumber);
                    
                            
                            
                            
                            
                            
                            
                            availableEmployees.Remove(employeeSearch);
                        }
                    }
                }
            }
        }
        public void UnassignEmployeeFromShift(int employeeID, int shiftID)
        {
            Employee employee = fullListemployees.Find(x => x.WorkrID == employeeID);
            Shift shift = presentAndFutureShifts.Find(x => x.ShiftID == shiftID);
            shift.UnassignEmployee(employee);

            if (!stageforChanges.Exists(i => i.ShiftID == shift.ShiftID))
            {
                stageforChanges.Add(shift);
            }

        }
        public void Save()
        {
            conn.SaveShifts(this.newshifts);
            conn.CommitChangesToShifts(this.stageforChanges);
        }
        #endregion
    }
}
