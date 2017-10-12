using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LinqToObjects());
            //Application.Run(new LinqToXml());
            //Application.Run(new LinqOverview());
            //Application.Run(new SQLToXML());
            Application.Run(new XMLOverview());
        }
    }
}
