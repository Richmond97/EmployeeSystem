using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayManager_ClassLibrary.Functionality_D
{
    public partial class PriorityComponent : Component
    {
        public PriorityComponent()
        {
            InitializeComponent();
        }

        public PriorityComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
