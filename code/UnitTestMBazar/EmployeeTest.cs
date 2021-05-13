using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaBazaarProject.Logic;

namespace UnitTestMBazar
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void NewEmployeeTest1()
        {
            Employee employee = new Employee("John", "Doe", "john@gmail.com");
            Assert.AreEqual("John", employee.FName);
            Assert.AreEqual("Doe", employee.LName);
            Assert.AreEqual("john@gmail.com", employee.Email);
        }
        [TestMethod]
        public void NewEmployeeTest2()
        {
            Employee employee = new Employee("John", "Doe", Gender.MALE, Position.EMPLOYEE, Department.DEPOT, DateTime.Now, "Netherlands", "Eindhoven", "5612JC", "JohannesWaalsweg", "john@gmail.com", "Dutch", "Dutch", 123, "reason");
            Assert.AreEqual("John", employee.FName);
            Assert.AreEqual("Doe", employee.LName);
            Assert.AreEqual("MALE", employee.Gender);
            Assert.AreEqual("EMPLOYEE", employee.Positions);
            Assert.AreEqual(Department.DEPOT, employee.Department);
            //Assert.AreEqual(DateTime.Now, employee.BirthDate);
            Assert.AreEqual("Netherlands", employee.BirthPlace);
            Assert.AreEqual("Eindhoven", employee.City);
            Assert.AreEqual("5612JC", employee.Zipcode);
            Assert.AreEqual("JohannesWaalsweg", employee.Adress);
            Assert.AreEqual("john@gmail.com", employee.Email);
            Assert.AreEqual("Dutch", employee.Nationality);
            Assert.AreEqual("Dutch", employee.Languages);
            Assert.AreEqual(123, employee.BSN);
            Assert.AreEqual("reason", employee.Reason);
        }
        [TestMethod]
        public void NewEmployeeTest3()
        {
            Employee employee = new Employee("John", "Doe", Gender.MALE, Position.EMPLOYEE, Department.DEPOT, DateTime.Now, "Netherlands", "Eindhoven", "5612JC", "JohannesWaalsweg", "john@gmail.com", "Dutch", "Dutch", 123, DateTime.Now, 3);
            Assert.AreEqual("John", employee.FName);
            Assert.AreEqual("Doe", employee.LName);
            Assert.AreEqual("MALE", employee.Gender);
            Assert.AreEqual("EMPLOYEE", employee.Positions);
            Assert.AreEqual(Department.DEPOT, employee.Department);
            //Assert.AreEqual(DateTime.Now, employee.BirthDate);
            Assert.AreEqual("Netherlands", employee.BirthPlace);
            Assert.AreEqual("Eindhoven", employee.City);
            Assert.AreEqual("5612JC", employee.Zipcode);
            Assert.AreEqual("JohannesWaalsweg", employee.Adress);
            Assert.AreEqual("john@gmail.com", employee.Email);
            Assert.AreEqual("Dutch", employee.Nationality);
            Assert.AreEqual("Dutch", employee.Languages);
            Assert.AreEqual(123, employee.BSN);
            //Assert.AreEqual(DateTime.Now, employee.ContractEnd);
            Assert.AreEqual(3, employee.FTE);
        }
        [TestMethod]
        public void NewEmployeeTest4()
        {
            Employee employee = new Employee(1, "John", "Doe", Gender.MALE, Position.EMPLOYEE, Department.HUMANRESOURCES, DateTime.Now, "Netherlands", "Eindhoven", "5612JC", "JohannesWaalsweg", "john@gmail.com", "Dutch", "Dutch", 123, DateTime.Now, 3);
            Assert.AreEqual(1, employee.WorkrID);
            Assert.AreEqual("John", employee.FName);
            Assert.AreEqual("Doe", employee.LName);
            Assert.AreEqual("MALE", employee.Gender);
            Assert.AreEqual("EMPLOYEE", employee.Positions);
            Assert.AreEqual(Department.HUMANRESOURCES, employee.Department);
            //Assert.AreEqual(DateTime.Now, employee.BirthDate);
            Assert.AreEqual("Netherlands", employee.BirthPlace);
            Assert.AreEqual("Eindhoven", employee.City);
            Assert.AreEqual("5612JC", employee.Zipcode);
            Assert.AreEqual("JohannesWaalsweg", employee.Adress);
            Assert.AreEqual("john@gmail.com", employee.Email);
            Assert.AreEqual("Dutch", employee.Nationality);
            Assert.AreEqual("Dutch", employee.Languages);
            Assert.AreEqual(123, employee.BSN);
            //Assert.AreEqual(DateTime.Now, employee.ContractEnd);
            Assert.AreEqual(3, employee.FTE);
        }
        [TestMethod]
        public void NewPasswordTest()
        {
          // Employee employee = new Employee("John", "Doe", "john@gmail.com");
          //  employee.GenerateRandomPassword();
            
        }
    }
}
