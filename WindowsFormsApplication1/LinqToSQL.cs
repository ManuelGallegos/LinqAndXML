using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.Linq;
using System.Data.Linq.Mapping;

[Table(Name = "Person.Person")]
public class Contact
{
    [Column]
    public string Title;
    [Column]
    public string FirstName;
    [Column]
    public string LastName;
}

namespace WindowsFormsApplication1
{
    public partial class LinqToSQL : Form
    {
        public LinqToSQL()
        {
            InitializeComponent();
        }

        private void LinqToSQL_Load(object sender, EventArgs e)
        {

            //connection string
            string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\AdventureWorks2014.mdf;Integrated Security=True;Connect Timeout=30";

            try
            {
                //Create data context
                DataContext db = new DataContext(connString);
                //create typed table
                Table<Contact> contacts = db.GetTable<Contact>();

                //Linq to DB Query database
                var contactDetails = from c in contacts
                                     where c.Title == "Mr."
                                     orderby c.FirstName
                                     select c;

                //Display contact dtails
                foreach(var c in contactDetails)
                {
                    txtLinqToSql.AppendText(c.Title);
                    txtLinqToSql.AppendText("\t");
                    txtLinqToSql.AppendText(c.FirstName);
                    txtLinqToSql.AppendText("\t");
                    txtLinqToSql.AppendText(c.LastName);
                    txtLinqToSql.AppendText("\n");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

    }
}
}
