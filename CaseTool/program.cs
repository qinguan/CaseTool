using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CaseTool.CaseForm;
namespace CaseTool
{
    class program
    {
        //public static void Main()
        //{
        //    MainForm t = new MainForm();
        //}

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        
    }
}
