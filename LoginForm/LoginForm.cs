using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            testDate();
            InitializeComponent();
            
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (staffID.Text != string.Empty)
            {
                // Sets the ID and Password to the component
                loginComponent1.StaffID = Int32.Parse(staffID.Text);
                loginComponent1.Password = password.Text;

                // Verification based on the admin desktop application
                if (loginComponent1.Verification("Admin"))
                {
                    Hide();
                    ManageForm manage = ManageForm.Instance;
                    manage.Show();
                }
            }
            else
            {
                MessageBox.Show("Please enter Staff ID");
            }
        }

        private void Lbl_Close(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StaffID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Onlu allows the keyboard to enter in numbers  
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);            
        }

        public void testDate()
        {
            DateTime zeroTime = new DateTime(1, 1, 1);

            DateTime A = new DateTime(2007, 1, 1);
            DateTime B = new DateTime(2007, 1, 10);
            TimeSpan span = B - A;
            // Because we start at year 1 for the Gregorian
            // calendar, we must subtract a year here.
            int days = (B - A).Days;
            // Because we start at year 1 for the Gregorian
            // calendar, we must subtract a year here.
            //int years = (zeroTime + span).Year - 1;
            //double days = (A - B).Days;

            // 1, where my other algorithm resulted in 0.
            MessageBox.Show("Yrs elapsed: " + days);
        }

    }
}
