using Microsoft.VisualStudio.TestTools.UnitTesting;
using Component_A_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component_A_ClassLibrary.Tests
{
    [TestClass()]
    public class LoginComponentTests
    {
        private readonly DataClasses1DataContext db = new DataClasses1DataContext();

        LoginComponent lc = new LoginComponent();
        
        [TestMethod()]
        
        public void AuthenticationTest()
        {
            string level = lc.EmployeeLevel ="Admin";
            long id = lc.SomeQuery = 2352353;
            bool expected = false;
            bool actual = lc.Authentication(id, level);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void VerificationTest()
        {
            lc.Verification("Admin");
            string level = "Admin";
            long id = lc.StaffID = 111111;
            string pass = lc.Password = "111111";
            bool actual;
            actual = lc.Verification("Admin");
            bool expected = true;
            Assert.AreEqual(expected, actual);
            lc.Verification("Admin");
        }

        [TestMethod()]
        public void VerificationTest1()
        {
            lc.Verification("Admin");
            string level = "Admin";
            long id = lc.StaffID = 111101;
            string pass = lc.Password = "111111";
            bool actual;
            actual = lc.Verification("Admin");
            bool expected = false;
            Assert.AreEqual(expected, actual);
            lc.Verification("Admin");

        }

    }
}