using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Component_A_ClassLibrary
{
    public partial class TelephoneDigit : TextBox
    {
        public TelephoneDigit()
        {
            InitializeComponent();
        }

        public TelephoneDigit(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        protected override void OnTextChanged(EventArgs e)
        {
            Point original = Location;
            if (Text.Length > 11)
            {
                BackColor = System.Drawing.Color.Red;
                int shakeCount = 0;
                while (shakeCount < 100)
                {
                    this.Left += 5;
                    this.Refresh();
                    this.Left -= 5;
                    this.Refresh();
                    shakeCount++;
                }
                Location = original;
            }
            else
            {
                BackColor = System.Drawing.Color.White;
            }
           // base.OnTextChanged(base e);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }
    }
}
