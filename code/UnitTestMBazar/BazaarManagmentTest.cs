using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaBazaarProject.Logic;



namespace UnitTestMBazar
{
    [TestClass]
    public class BazaarManagmentTest
    {
        [TestMethod]
        public void AddNewEmployeeTest()
        {
            BazaarManagment bm = new BazaarManagment();
            bm.AddNewEmployee("John", "Doe", Gender.MALE, Position.EMPLOYEE, Department.DEPOT, DateTime.Today, "Netherlands", "Eindhoven", "5612JC", "JohannesWaalsweg", "john@gmail.com", "Dutch", "Dutch", 123, DateTime.Today, 40);
            bm.AddNewEmployee("Jane", "Doe", Gender.FEMALE, Position.MANAGER, Department.HUMANRESOURCES, DateTime.Today, "Netherlandsa", "Eindhovena", "5612JaC", "JohannesWaalswega", "johna@gmail.com", "Dutch", "Dutch", 1234, DateTime.Today, 43);
            Employee e = new Employee("John", "Doe", Gender.MALE, Position.EMPLOYEE, Department.DEPOT, DateTime.Today, "Netherlands", "Eindhoven", "5612JC", "JohannesWaalsweg", "john@gmail.com", "Dutch", "Dutch", 123, DateTime.Today, 40);
            Employee em = new Employee("Jane", "Doe", Gender.FEMALE, Position.MANAGER, Department.HUMANRESOURCES, DateTime.Today, "Netherlandsa", "Eindhovena", "5612JaC", "JohannesWaalswega", "johna@gmail.com", "Dutch", "Dutch", 1234, DateTime.Today, 43);

            CollectionAssert.AreEquivalent(new Employee[]{e, em},bm.newEmployeesList);
        }

    }
}
