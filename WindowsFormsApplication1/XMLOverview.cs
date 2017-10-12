using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml;
using System.IO;



namespace WindowsFormsApplication1
{
    public partial class XMLOverview : Form
    {
        public XMLOverview()
        {
            InitializeComponent();
           
        }

        private void btnGetXMLData_Click(object sender, EventArgs e)
        {
           
            // ** If you are learning XML just 
            // ** A) paste the path for the XML file and 
            // ** B) then run every block commented below.
            // ** Manuel.

            /* 
           
            //READ NODES
            txtResult.Clear();
            XmlReader reader = XmlReader.Create(@"C:\Linq\WindowsFormsApplication1\WindowsFormsApplication1\Books.xml");
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                    txtResult.AppendText(reader.Value + "\r\n");

            }
            
            //READ STRING
            txtResult.Clear();
            XmlReader reader = XmlReader.Create(@"C:\Linq\WindowsFormsApplication1\WindowsFormsApplication1\Books.xml");
            while(!reader.EOF)
            {
                //Looking for the element type
                if(reader.MoveToContent () == XmlNodeType.Element && reader.Name == "title")
                {
                    txtResult.AppendText(reader.ReadElementContentAsString() + "\r\n");
                }
                else
                {
                    reader.Read();
                }
            }
            

            //READ ATTRIBUTES
            txtResult.Clear();
            XmlReader reader = XmlReader.Create(@"C:\Linq\WindowsFormsApplication1\WindowsFormsApplication1\Books.xml");
            //Read a node at a time
            while(reader.Read())
            {
                if(reader.NodeType == XmlNodeType.Element)
                {
                    //If this is a node lets look at the attributes
                    for(int i = 0; i < reader.AttributeCount; i++)
                    {
                        txtResult.AppendText(reader.GetAttribute(i) + "\r\n");
                        if (i == reader.AttributeCount - 1)
                            txtResult.AppendText("\n");
                    }
                }
            }
            

            //VALIDATING WITH XMLREADER
            txtResult.Clear();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, @"C:\Linq\WindowsFormsApplication1\WindowsFormsApplication1\Books.xsd");
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += Settings_ValidationEventHandler;
            XmlReader reader = XmlReader.Create(@"C:\Linq\WindowsFormsApplication1\WindowsFormsApplication1\Books.xml", settings);

            while(reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                    txtResult.AppendText(reader.Value + "\r\n");
            }
            
             
            //XMLWRITER 
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            XmlWriter writer = XmlWriter.Create("newbook.xml", settings);

            writer.WriteStartDocument();
            
            //Elements and attributes
            writer.WriteStartElement("Books");
            writer.WriteStartElement("book");
            writer.WriteAttributeString("genre", "Mystery");
            writer.WriteAttributeString("publicationdate", "2017");
            writer.WriteAttributeString("ISBN", "123456789");
            writer.WriteElementString("title", "Case of the little prince");
            writer.WriteStartElement("author");
            writer.WriteElementString("name", "Cookie Monster");
            writer.WriteEndElement();
            writer.WriteElementString("price", "9.99");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();

            //clean up
            writer.Flush();
            writer.Close();
            txtResult.AppendText("XML file Generated");

            
            //DOM WITH XMLDOCUMENT
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Linq\WindowsFormsApplication1\WindowsFormsApplication1\Books.xml");
            XmlNodeList nodeList = xDoc.GetElementsByTagName("title");
            txtResult.Clear();
            foreach(XmlNode xnode in nodeList)
            {
                txtResult.AppendText(xnode.OuterXml + "\r\n");
            }
            
             
            //XPATH SYNTAX
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Linq\WindowsFormsApplication1\WindowsFormsApplication1\Books.xml");
            XmlNodeList xnodeList = xDoc.SelectNodes("/bookstore/book/title");
            txtResult.Clear();
            foreach(XmlNode xnode in xnodeList)
            {
                txtResult.AppendText(xnode.OuterXml + "\r\n");
            }
            
             
            //INSERTING NODES WITH XMLDOCUMENT instead of XmlWriter
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Linq\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\newbook.xml");
            //new book element
            XmlElement newBook = xDoc.CreateElement("book");
            //attributes
            newBook.SetAttribute("genre", "Mystery");
            newBook.SetAttribute("publicationdate", "2018");
            newBook.SetAttribute("ISBN", "123456789");
            //new title element
            XmlElement newTitle = xDoc.CreateElement("title");
            newTitle.InnerText = "New Book for Manuel";
            newBook.AppendChild(newTitle);
            //new Author Element
            XmlElement newAuthor = xDoc.CreateElement("author");
            newBook.AppendChild(newAuthor);
            //create new name element
            XmlElement newName = xDoc.CreateElement("name");
            newName.InnerText = "MG";
            newAuthor.AppendChild(newName);
            //create new price element
            XmlElement newPrice = xDoc.CreateElement("price");
            newPrice.InnerText = "9.95";
            newBook.AppendChild(newPrice);
            //add to the current element
            xDoc.DocumentElement.AppendChild(newBook);

            //write out the doc to disk
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            XmlWriter writer = XmlWriter.Create("newbookedited.xml", settings);
            xDoc.WriteContentTo(writer);
            writer.Flush();
            writer.Close();

            //Load the titles and the new one
            XmlNodeList xnodeList = xDoc.GetElementsByTagName("title");
            txtResult.Clear();
            foreach(XmlNode xnode in xnodeList)
            {
                txtResult.AppendText(xnode.OuterXml + "\r\n");
            }
            */


            //XMLDOCUMENT WITH ROOT NODE
            XmlDocument xDoc = new XmlDocument();

            //declaration section
            XmlDeclaration xDec = xDoc.CreateXmlDeclaration("1.0", null, null);
            xDoc.AppendChild(xDec);
            //create the root element
            XmlElement xRoot = xDoc.CreateElement("newBookStore");
            xDoc.AppendChild(xRoot);
            //new book element
            XmlElement newBook = xDoc.CreateElement("book");
            //attributes
            newBook.SetAttribute("genre", "Mystery");
            newBook.SetAttribute("publicationdate", "2018");
            newBook.SetAttribute("ISBN", "123456789");
            //new title element
            XmlElement newTitle = xDoc.CreateElement("title");
            newTitle.InnerText = "New Book for Manuel";
            newBook.AppendChild(newTitle);
            //new Author Element
            XmlElement newAuthor = xDoc.CreateElement("author");
            newBook.AppendChild(newAuthor);
            //create new name element
            XmlElement newName = xDoc.CreateElement("name");
            newName.InnerText = "MG";
            newAuthor.AppendChild(newName);
            //create new price element
            XmlElement newPrice = xDoc.CreateElement("price");
            newPrice.InnerText = "9.95";
            newBook.AppendChild(newPrice);
            //add to the current element
            xDoc.DocumentElement.AppendChild(newBook);

            //write out the doc to disk
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            XmlWriter writer = XmlWriter.Create("newbookstore.xml", settings);
            xDoc.WriteContentTo(writer);
            writer.Flush();
            writer.Close();

            //Load the titles and the new one
            XmlNodeList xnodeList = xDoc.GetElementsByTagName("title");
            txtResult.Clear();
            foreach (XmlNode xnode in xnodeList)
            {
                txtResult.AppendText(xnode.OuterXml + "\r\n");
            }

            txtResult.AppendText("XML file Generated" + "\r\n");

        }

        private void Settings_ValidationEventHandler(object sender, System.Xml.Schema.ValidationEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void XML_Load(object sender, EventArgs e)
        {

        }
    }
}
