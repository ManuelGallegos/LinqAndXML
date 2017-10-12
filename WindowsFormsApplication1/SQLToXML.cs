using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml.Linq;

namespace WindowsFormsApplication1
{
    public partial class SQLToXML : Form
    {
        public SQLToXML()
        {
            InitializeComponent();
        }

        private void SQLToXML_Load(object sender, EventArgs e)
        {
            //connection string
            //string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\AdventureWorks2014.mdf;Integrated Security=True;Connect Timeout=30";

            //Create data context
            //DataContext dc = new DataContext(connString);

            NorthwindDataContext dc = new NorthwindDataContext();

            XElement xe = new XElement("Person",
                from c in dc.Persons
                select new XElement("PersonType", 
                       new XElement("FirstName", c.FirstName),
                       new XElement("SecondName", c.LastName),
                       new XElement("Suffix", c.Suffix),
                       new XElement("PhoneNumber", c.PersonPhones.Count)));

            xe.Save("myCustomersTest.xml");

            txtSQLToXML.AppendText("File Created!");

        }
    }
}
