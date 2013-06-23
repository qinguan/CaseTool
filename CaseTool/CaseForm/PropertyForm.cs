using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

namespace CaseTool.CaseForm
{
    public partial class PropertyForm : DockContent
    {
        public PropertyForm()
        {
            InitializeComponent();
            this.Text = "属性";
        }

        public PropertyGrid PropertyGrid
        {
            get { return this.propertyGrid; }
        }
    }
}
