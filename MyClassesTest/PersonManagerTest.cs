using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class PersonManagerTest
    {
        [TestMethod]
        public void CreatePerson_OfTypeEmployeeTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("Marlon", "Olaya", false);

            Assert.IsInstanceOfType(per, typeof(Employee));
        }

        [TestMethod]
        public void GetEmployeesTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> employees;

            employees = mgr.GetEmployees();

            CollectionAssert.AllItemsAreInstancesOfType(employees, typeof(Employee));
        }
    }
}
