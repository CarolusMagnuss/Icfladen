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

namespace Icfladen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string XMLDatei = "\\ICF.xml";

        int Objektzahl;
        XmlNodeList Objektliste;


        private void InitializeTreeView()
        {
            ICFTree.BeginUpdate();
            ICFTree.Nodes.Add("Parent");
            ICFTree.Nodes[0].Nodes.Add("Child 1");
            ICFTree.Nodes[0].Nodes.Add("Child 2");
            ICFTree.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
            ICFTree.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
            ICFTree.EndUpdate();
        }

        private XmlNodeList Klassifizierliste(string Auswahl, string Datei)//lädt die XML Datei und gibt eine XMLNodeliste mit allen ICF Kategorien zurück
        {
            
            XmlDocument dom = new XmlDocument();
            dom.Load(Application.StartupPath + Datei);

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(((XmlDocument)dom).NameTable);
            nsmgr.AddNamespace("d2p1", "http://schemas.datacontract.org/2004/07/Geronto.Framework.Data.Classification.Model.V1");
            nsmgr.AddNamespace("d4p1", "http://schemas.datacontract.org/2004/07/Geronto.Framework.Data.Foundation.Model.V1");
            XmlNode root = dom.DocumentElement;

            return root.SelectNodes(Auswahl, nsmgr);
        }

        private void ICFSize() // Lädt Klassifikation und bestimmt ihre Größe.
        {   
            Objektliste = Klassifizierliste("//d2p1:ClassificationObject", XMLDatei);
            Objektzahl = Objektliste.Count;
        }



        private string[,] ICFtoListe(XmlNodeList Objektliste)
        {
           string[,] Liste= new string[Objektzahl,4];           
           XmlNode Aktiver;
            int i = 0;

            foreach (XmlNode Node in Objektliste)
            {
                if (Node.Name == "d2p1:ClassificationObject")
                {
                    Aktiver = Node.SelectSingleNode("descendant::d2p1:DescriptionTexts/d2p1:DescriptionText/d4p1:Text");
                    Liste[i, 0] = Aktiver.OuterXml;
                    Aktiver = Node;
                       
                    Aktiver = Node.SelectSingleNode("descendant::d2p1:DisplayTexts/d4p1:Text");
                    Liste[i, 1] = Aktiver.OuterXml;
                    Aktiver = Node;

                    Aktiver = Node.SelectSingleNode("descendant::d2p1:GsOid");
                    Liste[i, 2] = Aktiver.OuterXml;

                    Aktiver = Node.SelectSingleNode("descendant::d2p1:ShortNames/d2p1:ShortName/d4p1:Text");
                    Liste[i, 3] = Aktiver.OuterXml;
                }
                i = i + 1;
            }
                      return Liste;
        }

       
        private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)//Hinzufügen der Nodes 
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList nodeList;
            int i;

            // Loop through the XML nodes until the leaf is reached.
            // Add the nodes to the TreeView during the looping process.
            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;
                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];
                    inTreeNode.Nodes.Add(new TreeNode(xNode.Name));
                    tNode = inTreeNode.Nodes[i];
                    AddNode(xNode, tNode);
                }
            }
            else
            {
                // Here you need to pull the data from the XmlNode based on the
                // type of node, whether attribute values are required, and so forth.
                inTreeNode.Text = (inXmlNode.OuterXml).Trim();
            }
        }



        private void LadeButton_Click(object sender, EventArgs e)
        {
            //InitializeTreeView();
            ICFSize();
            Ausgabe.Text = Objektzahl.ToString();
            Ausgabe.Text=ICFtoListe(Objektliste)[0,1];
        }


        private void TreeButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                // SECTION 1. Create a DOM Document and load the XML data into it.
                XmlDocument dom = new XmlDocument();
                dom.Load(Application.StartupPath + "\\sample.xml");

                // SECTION 2. Initialize the TreeView control.
                ICFTree.Nodes.Clear();
                ICFTree.Nodes.Add(new TreeNode(dom.DocumentElement.Name));
                TreeNode tNode = new TreeNode();
                tNode = ICFTree.Nodes[0];

                // SECTION 3. Populate the TreeView with the DOM nodes.
                AddNode(dom.DocumentElement, tNode);

                // SECTION 4. Create a new TreeView Node with only the child nodes.
                XmlNodeList nodelist = dom.SelectNodes("//child");
                //XmlDocument cDom = new XmlDocument();
                //cDom.LoadXml("<children></children>");
                //foreach (XmlNode node in nodelist)
                //{
                //    XmlNode newElem = cDom.CreateNode(XmlNodeType.Element, node.Name, node.LocalName);
                //    newElem.InnerText = node.InnerText;
                //    cDom.DocumentElement.AppendChild(newElem);
                //}
                //
                //ICFTree.Nodes.Add(new TreeNode(cDom.DocumentElement.Name));
                //tNode = ICFTree.Nodes[1];
                //AddNode(cDom.DocumentElement, tNode);
                ICFTree.ExpandAll();
                Objektliste = nodelist;
                Objektzahl = Objektliste.Count;
                Ausgabe.Text = Objektzahl.ToString();
            }

            catch (XmlException xmlEx)
            {
                MessageBox.Show(xmlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
