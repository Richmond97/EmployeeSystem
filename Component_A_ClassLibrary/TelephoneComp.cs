using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Component_A_ClassLibrary
{
    public partial class TelephoneComp : TextBox
    {
        public string NumberTel { get => telephoneNum.Text; set => telephoneNum.Text = value; }
        public TelephoneComp()
        {
            InitializeComponent();
        }

        public TelephoneComp(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }



        public static bool IsPhoneNumber(string number)
        {
            if (Regex.Match(number, @"^(\+[0-9]{9})$").Success)
            {
               MessageBox.Show("valid");
                return true;
            }
            else
            {
                return false;
            }
        }
         
        
}
}
