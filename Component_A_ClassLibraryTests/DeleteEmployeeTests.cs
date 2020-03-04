using Microsoft.VisualStudio.TestTools.UnitTesting;
using Component_A_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Component_A_ClassLibrary.Tests
{
    [TestClass()]
    public class DeleteEmployeeTests
    {

        private readonly DataClasses1DataContext db = new DataClasses1DataContext();

        [TestMethod()]
        public void DeleteStaffTest()
        {
            // Create a new employee object
            employee addedEmployee = new employee
            {
                FirstName = "Testman",
                LastName = "MacTest",
                Password = "TestPassword",
                Telephone = "09876543234",
                EmailAddress = "Test@test.ac.uk",
                Address = "123test-test-test-test",
                DateJoined = DateTime.Today.Date,
                StaffID = 987456
            };
            Console.WriteLine(" today date is " + DateTime.Today.Date);

            // Create a new Department object

            department addedDept = new department
            {
                DeptName = DepartmentType.Carpentry.ToString()
            };

            // Create a new role object and add the employee and department
            role addedRole = new role
            {
                RoleType = Roletype.Head.ToString(),
                employee = addedEmployee,
                department = addedDept
            };

            //Save changes to Database
            db.roles.InsertOnSubmit(addedRole);

            db.SubmitChanges();

            DeleteEmployee delete = new DeleteEmployee();
           // delete.DeleteStaff("987456");
            int expected = 1;
            int actual = delete.deleteCount;

            Assert.AreEqual(expected, actual);
        }       

    }
}