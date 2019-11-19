using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class AssertClassTest
    {
        #region AreEqual/AreNotEqual Tets
        [TestMethod]
        [Owner("Marlon")]
        public void AreEqualTest()
        {
            string str1 = "Marlon";
            string str2 = "Marlon";

            Assert.AreEqual(str1, str2);
        }

        [TestMethod]
        [Owner("Esteban")]
        [ExpectedException(typeof(AssertFailedException))]
        public void AreEqualCaseSensitiveTest()
        {
            string str1 = "Marlon";
            string str2 = "marlon";

            Assert.AreEqual(str1, str2, false);
        }

        [TestMethod]
        [Owner("Marlon")]
        public void AreNotEqualTest()
        {
            string str1 = "Marlon";
            string str2 = "Esteban";

            Assert.AreNotEqual(str1, str2);
        }
        #endregion

        #region AreSame/AreNotSame Test

        [TestMethod]
        [Owner("Marlon")]
        public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            Assert.AreSame(x, y);
        }

        [TestMethod]
        [Owner("Esteban")]
        public void AreNotSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();

            Assert.AreNotSame(x, y);
        }
        #endregion

        #region IsInstanceOfType Test
        [TestMethod]
        [Owner("Marlon")]
        public void IsInstanceOfTypeTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("Marlon", "Olaya", true);

            Assert.IsInstanceOfType(per, typeof(Supervisor));
        }
        #endregion

        #region IsNull Test
        [TestMethod]
        [Owner("Esteban")]
        public void IsNullTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("", "Olaya", true);

            Assert.IsNull(per);
        }
        #endregion

    }
}
