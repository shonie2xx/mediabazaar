using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaBazaarProject.Logic;

namespace UnitTestMBazar
{
    [TestClass]
public class ShiftsTest
{
    [TestMethod]
    public void NewShiftTest1()
    {
        Shift shift = new Shift(DateTime.Today, 1, Department.DEPOT);
        Assert.AreEqual(DateTime.Today, shift.Date);
        Assert.AreEqual(1, shift.ShiftNumber);
        Assert.AreEqual(Department.DEPOT, shift.DepartmentGet);
    }

    [TestMethod]
    public void NewShiftTest2()
    {
        Shift shift = new Shift(1, 1, "HUMANRESOURCES", DateTime.Today, "");
        Assert.AreEqual(1, shift.ShiftNumber);
        Assert.AreEqual(1, shift.ShiftID);
        Assert.AreEqual(Department.HUMANRESOURCES, shift.DepartmentGet);
        Assert.AreEqual(DateTime.Today, shift.Date);
        Assert.AreEqual("", shift.FloorOfStore);
    }

    [TestMethod]
    public void NewShiftTestStoreFloor2()
    {
        Shift shift = new Shift(1, 1, "SALES", DateTime.Today, "storefloor");
        Assert.AreEqual(1, shift.ShiftNumber);
        Assert.AreEqual(1, shift.ShiftID);
        Assert.AreEqual(Department.SALES, shift.DepartmentGet);
        Assert.AreEqual(DateTime.Today, shift.Date);
        Assert.AreEqual("storefloor", shift.FloorOfStore);
    }

    [TestMethod]
    public void AssignEmployeeTest1()
    {

        Shift shift = new Shift(1, 1, "SALES", DateTime.Today, "storefloor");
        Employee employee1 = new Employee("John", "Doe", Gender.MALE, Position.EMPLOYEE, Department.DEPOT, DateTime.Now, "Netherlands", "Eindhoven", "5612JC", "JohannesWaalsweg", "john@gmail.com", "Dutch", "Dutch", 123, DateTime.Now, 3);
        Employee employee2 = new Employee("Jena", "Jenatova", Gender.FEMALE, Position.EMPLOYEE, Department.DEPOT, DateTime.Now, "Netherlands", "Eindhoven", "5612JC", "JohannesWaalsweg", "john@gmail.com", "Dutch", "Dutch", 123, DateTime.Now, 3);

        shift.AssignEmployee(employee1);
        shift.AssignEmployee(employee2);

        CollectionAssert.AreEquivalent(new Employee[] { employee1, employee2 }, shift.EmployeesAssigned);
    }

    [TestMethod]
    public void UnassignEmployeeTest()
    {
        Shift shift = new Shift(1, 1, "SALES", DateTime.Today, "storefloor");
        Employee employee1 = new Employee("John", "Doe", Gender.MALE, Position.EMPLOYEE, Department.DEPOT, DateTime.Now, "Netherlands", "Eindhoven", "5612JC", "JohannesWaalsweg", "john@gmail.com", "Dutch", "Dutch", 123, DateTime.Now, 3);
        Employee employee2 = new Employee("Jena", "Jenatova", Gender.FEMALE, Position.EMPLOYEE, Department.DEPOT, DateTime.Now, "Netherlands", "Eindhoven", "5612JC", "JohannesWaalsweg", "john@gmail.com", "Dutch", "Dutch", 123, DateTime.Now, 3);

        shift.AssignEmployee(employee1);
        shift.AssignEmployee(employee2);

        shift.UnassignEmployee(employee2);
        CollectionAssert.AreEquivalent(new Employee[] { employee1 }, shift.EmployeesAssigned);

    }
}
}



