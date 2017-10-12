using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class LinqToObjects : Form
    {
        public LinqToObjects()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] names = { "Life is Beautiful",
            "Arshika Aaaa",
            "Seven",
            "Manuel Gallegos",
            "Tomales",
            "Technological"};

            //Linq Query
            IEnumerable<string> namesOfPeople = from name in names where name.Length <= 16 select name;


            foreach(var name in namesOfPeople)
            {
                txtDisplay.AppendText(name + "\n");
            }


        }





    }
}
