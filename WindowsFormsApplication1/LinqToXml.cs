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
using System.IO;


namespace WindowsFormsApplication1
{
    public partial class LinqToXml : Form
    {
        public LinqToXml()
        {
            InitializeComponent();
        }

        private void LinqToXml_Load(object sender, EventArgs e)
        {


            //https://stackoverflow.com/questions/6041332/best-way-to-get-application-folder-path


            string stream = @"C:\Linq\WindowsFormsApplication1\WindowsFormsApplication1\Products.xml";

            XElement doc = XElement.Load(stream);

            //Query XML file
            var products = from prodname in doc.Descendants("Product")
                           select prodname;

            //Display details
            foreach(var prodname in products)
            {
                txtLinqToXml.AppendText("Product's Detail = " + prodname.FirstAttribute.Value + " ");
                txtLinqToXml.AppendText(prodname.Value);
                txtLinqToXml.AppendText("\n");

                

            }

                LinqToXML_Overview();

        }


        private void LinqToXML_Overview()
        {

            string stream = @"C:\Hamlet.xml";

            //XDocument
            XDocument xdoc = XDocument.Load(stream);

            txtLinqToXml.AppendText(xdoc.Root.Name.ToString());
            txtLinqToXml.AppendText("\n");
            txtLinqToXml.AppendText(xdoc.Root.HasAttributes.ToString());

            //XElement
            XElement xe = new XElement("Company", "Lipper");
            txtLinqToXml.AppendText("\n");
            txtLinqToXml.AppendText(xe.ToString());

            XElement xeComplete = new XElement("Company",
                                  new XElement("ComanyName", "Liper"),
                                  new XElement("CompanyAddress",
                                  new XElement("Address", "123 Main St"),
                                  new XElement("City", "St Louis"),
                                  new XElement("State", "MO"),
                                  new XElement("Country", "USA")));

            txtLinqToXml.AppendText("\n");
            txtLinqToXml.AppendText("\n");
            txtLinqToXml.AppendText(xeComplete.ToString());

            //XNamespace
            XNamespace ns = "http://www.lipperweb.com/ns/1";

            XElement xeCompleteWithNamespace = new XElement(ns + "Company",
                                 new XElement("ComanyName", "Liper"),
                                 new XElement("CompanyAddress",
                                 new XElement("Address", "123 Main St"),
                                 new XElement("City", "St Louis"),
                                 new XElement("State", "MO"),
                                 new XElement("Country", "USA")));

            txtLinqToXml.AppendText("\n");
            txtLinqToXml.AppendText("\n");
            txtLinqToXml.AppendText(xeCompleteWithNamespace.ToString());


            //XNamespace to All the elements
            XNamespace ns1 = "http://www.lipperweb.com/ns/root";
            XNamespace ns2 = "http://www.lipperweb.com/ns/sub";


            XElement xeCompleteWithNamespaces = new XElement(ns1 + "Company",
                                 new XElement(ns2 + "ComanyName", "Liper"),
                                 new XElement(ns2 + "CompanyAddress",
                                 new XElement(ns2 + "Address", "123 Main St"),
                                 new XElement(ns2 + "City", "St Louis"),
                                 new XElement(ns2 + "State", "MO"),
                                 new XElement(ns2 + "Country", "USA")));


            txtLinqToXml.AppendText("\n");
            txtLinqToXml.AppendText("\n");
            txtLinqToXml.AppendText(xeCompleteWithNamespaces.ToString());


            //XComment
            XDocument xDocComment = new XDocument();

            XComment xc = new XComment("Here is the comment.");
            xDocComment.Add(xc);

            XElement xeWithComment = new XElement("Company",
                                  new XElement("ComanyName", "Liper"),
                                  new XElement("CompanyAddress",
                                  new XComment("Here is ANOTHER COMMENT"),
                                  new XElement("Address", "123 Main St"),
                                  new XElement("City", "St Louis"),
                                  new XElement("State", "MO"),
                                  new XElement("Country", "USA")));

            xDocComment.Add(xeWithComment);

            txtLinqToXml.AppendText("\n");
            txtLinqToXml.AppendText("\n");
            txtLinqToXml.AppendText(xDocComment.ToString());

            //XAttribute
            XElement xeWithAttribute = new XElement("Company",
                                  new XAttribute("MyAttribute", "MyAttributeValue"),
                                  new XElement("ComanyName", "Liper"),
                                  new XElement("CompanyAddress",
                                  new XElement("Address", "123 Main St"),
                                  new XElement("City", "St Louis"),
                                  new XElement("State", "MO"),
                                  new XElement("Country", "USA")));

            txtLinqToXml.AppendText("\n");
            txtLinqToXml.AppendText("\n");
            txtLinqToXml.AppendText(xeWithAttribute.ToString());


            //Using Linq to query XML Documents
            XDocument xdocQuery = XDocument.Load(stream);

            var query = from people in xdocQuery.Descendants("PERSONA")
                        select people.Value;

            txtLinqToXml.AppendText("\n");
            txtLinqToXml.AppendText("\n");

            foreach (var item in query)
            {
                txtLinqToXml.AppendText(item.ToString());
                txtLinqToXml.AppendText("\n");
            }

            //Quering Dynamic XML Documents (From Internet)

            XDocument xdocDynamic = XDocument.Load(@"http://geekswithblogs.net/evjen/Rss.aspx");

            var queryDynamic = from rssFeed in xdocDynamic.Descendants("channel")
                               select new
                               {
                                   Title = rssFeed.Element("title").Value,
                                   Description = rssFeed.Element("description").Value,
                                   Link = rssFeed.Element("link").Value,

                               };


            foreach (var item in queryDynamic)
            {
                txtLinqToXml.AppendText("\n");
                txtLinqToXml.AppendText("\n");
                txtLinqToXml.AppendText("TITLE: " + item.Title);
                txtLinqToXml.AppendText("\n");
                txtLinqToXml.AppendText("DESCRIPTION: " + item.Description);
                txtLinqToXml.AppendText("\n");
                txtLinqToXml.AppendText("LINK :" + item.Link);
                txtLinqToXml.AppendText("\n");
            }



            var queryPosts = from myPosts in xdocDynamic.Descendants("item")
                             select new
                             {
                                 Title = myPosts.Element("title").Value,
                                 Published = DateTime.Parse(myPosts.Element("pubDate").Value),
                                 Description = myPosts.Element("description").Value,
                                 Url = myPosts.Element("link").Value,
                                 comments = myPosts.Element("comments").Value

                             };

            foreach(var item in queryPosts)
            {
                txtLinqToXml.AppendText("\n");
                txtLinqToXml.AppendText("\n");
                txtLinqToXml.AppendText("TITLE: " + item.Title);
                txtLinqToXml.AppendText("\n");
                //txtLinqToXml.AppendText("PUBLISHED: " + item.Published);
                //txtLinqToXml.AppendText("\n");
                //txtLinqToXml.AppendText("DESCRIPTION :" + item.Description);
                //txtLinqToXml.AppendText("\n");
                //txtLinqToXml.AppendText("URL :" + item.Url);
                //txtLinqToXml.AppendText("\n");
                //txtLinqToXml.AppendText("COMMENTS :" + item.comments);
                //txtLinqToXml.AppendText("\n");

            }

            //Working Around XML Document

            XDocument xDocAround = XDocument.Load(stream);

            txtLinqToXml.AppendText("\n");
            txtLinqToXml.AppendText("\n");
            txtLinqToXml.AppendText(xDocAround.Element("PLAY").Element("TITLE").Value);

            txtLinqToXml.AppendText("\n");
            txtLinqToXml.AppendText("\n");
            txtLinqToXml.AppendText(xDocAround.Element("PLAY").Element("PERSONAE").Element("PERSONA").Value);

            //Writing to an XML Document
            xDocAround.Element("PLAY").Element("PERSONAE").Element("PERSONA").SetValue("Manuel, King of Denmark");

            txtLinqToXml.AppendText("\n");
            txtLinqToXml.AppendText("\n");
            txtLinqToXml.AppendText(xDocAround.Element("PLAY").Element("PERSONAE").Element("PERSONA").Value);


            //Another way to write to an XML Document
            XElement xeWrite = new XElement("PERSONA", "Gallegos prince of Denmark");

            xDocAround.Element("PLAY").Element("PERSONAE").Add(xeWrite);
            //xDocAround.Element("PLAY").Element("PERSONAE").AddFirst(xeWrite);

            var queryWrite = from people in xDocAround.Descendants("PERSONA")
                             select people.Value;

            txtLinqToXml.AppendText("\n");
            txtLinqToXml.AppendText("\n");
            txtLinqToXml.AppendText("Players Found " + queryWrite.Count());

            txtLinqToXml.AppendText("\n");

            foreach(var item in queryWrite)
            {
                txtLinqToXml.AppendText(item);
                txtLinqToXml.AppendText("\n");
            }




        }

       
    }
}
