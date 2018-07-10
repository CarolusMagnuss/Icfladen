﻿using System;
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
        string[,] Liste = new string[1602, 4];
        string[] Einträge = { "//d2p1:ClassificationObject",
                              ".//d2p1:DescriptionTexts/d4p1:DescriptionText/d4p1:DescriptionText/d4p1:Text",
                              ".//d2p1:DisplayTexts/d4p1:DisplayText/d4p1:DisplayText/d4p1:Text",
                              ".//d2p1:GsOid",
                              ".//d2p1:ShortNames/d4p1:ShortName/d4p1:ShortName/d4p1:Text"};

        DataTable Tabelle = new DataTable("Klassifikationsobjekte");

        private void MakeTable() // Tabelle für die ICF Klassifikationsobjekte erschaffen.
        {
            DataColumn column;
            

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            column.ReadOnly = true;
            column.Unique = true;
            Tabelle.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Beschreibung";
            column.ReadOnly = false;
            column.Unique = false;
            Tabelle.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Code";
            column.ReadOnly = false;
            column.Unique = false;
            Tabelle.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Pfad";
            column.ReadOnly = false;
            column.Unique = false;
            Tabelle.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Zusatz";
            column.ReadOnly = false;
            column.Unique = false;
            Tabelle.Columns.Add(column);

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = Tabelle.Columns["id"];
            Tabelle.PrimaryKey = PrimaryKeyColumns;

        }



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


        private void ICFtoTable(string Datei)//liest die XML Datei aus und füllt die Tabelle mit den Kategorien.
        {
            DataRow row;
            XmlNode Aktiver;
            XmlDocument dom = new XmlDocument();
            dom.Load(Application.StartupPath + Datei);
            

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(((XmlDocument)dom).NameTable);
            nsmgr.AddNamespace("d2p1", "http://schemas.datacontract.org/2004/07/Geronto.Framework.Data.Classification.Model.V1");
            nsmgr.AddNamespace("d4p1", "http://schemas.datacontract.org/2004/07/Geronto.Framework.Data.Foundation.Model.V1");
            XmlNode root = dom.DocumentElement;
            Aktiver = root.SelectSingleNode(Einträge[0], nsmgr);

            for (int k = 0; k < 1602; k++)
            {
                                
                row = Tabelle.NewRow();
                row["id"] = k;
                row["Beschreibung"] = Aktiver.SelectSingleNode(Einträge[1], nsmgr).InnerText;
                row["Code"] = Aktiver.SelectSingleNode(Einträge[2], nsmgr).InnerText;
                row["Pfad"] = Aktiver.SelectSingleNode(Einträge[3], nsmgr).InnerText;
                row["Zusatz"] = Aktiver.SelectSingleNode(Einträge[4], nsmgr).InnerText;
                Tabelle.Rows.Add(row);
                Aktiver = Aktiver.NextSibling;
            }
        }
        
        private void Populate() //Nutzt die Daten der Tabelle zur Erstellung der Knoten im ICF TreeView.
        {
            DataRow[] Zeilen = Tabelle.Select();
            int[] Pfadnummern = new int[] { 0, 0, 0, 0, 0, 0 };

            DataRow rowa = Zeilen[0];
            //Pfadnummern[0] = (int)char.GetNumericValue(GSOID[6]);
            

           
            foreach (DataRow row in Zeilen)
            {
             string GSOID = (string)row["Pfad"];
             int Ebene = (GSOID.Length - 5) / 2;

                for (int t = 0; t < (Ebene-1); t++)
                {
                Pfadnummern[t] = (int)char.GetNumericValue(GSOID[(((t + 1) * 2) + 4)]);                    
                }

            Ausgabe.Text = GSOID + Pfadnummern[1].ToString() + Pfadnummern[2].ToString() + Pfadnummern[3].ToString()+ Pfadnummern[4].ToString() + Pfadnummern[5].ToString()+" "+ GSOID;

            switch (Ebene)
            {
                case 1:
                    ICFTree.Nodes.Add((string)row["Code"]+(string)row["Beschreibung"]);
                    break;
                case 2:
                    ICFTree.Nodes[(Pfadnummern[0]-1)].Nodes.Add((string)row["Code"] + (string)row["Beschreibung"]);
                    break;
                case 3:
                    ICFTree.Nodes[(Pfadnummern[0]-1)].Nodes[(Pfadnummern[1]-1)].Nodes.Add((string)row["Code"] + (string)row["Beschreibung"]);
                    break;
                case 4:
                    ICFTree.Nodes[(Pfadnummern[0]-1)].Nodes[(Pfadnummern[1]-1)].Nodes[(Pfadnummern[2]-1)].Nodes.Add((string)row["Code"] + (string)row["Beschreibung"]);
                    break;
                case 5:
                    ICFTree.Nodes[(Pfadnummern[0]-1)].Nodes[(Pfadnummern[1]-1)].Nodes[(Pfadnummern[2])-1].Nodes[(Pfadnummern[3]-1)].Nodes.Add((string)row["Code"] + (string)row["Beschreibung"]);
                    break;
                case 6:
                    ICFTree.Nodes[(Pfadnummern[0]-1)].Nodes[(Pfadnummern[1]-1)].Nodes[(Pfadnummern[2])-1].Nodes[(Pfadnummern[3])-1].Nodes[(Pfadnummern[4]-1)].Nodes.Add((string)row["Code"] + (string)row["Beschreibung"]);
                    break;
            }




            }



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
            MakeTable();
            ICFtoTable(XMLDatei);
            ICFTabelle.DataSource = Tabelle;
            Populate();
            
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

        private void Ansichtwechsel_Click(object sender, EventArgs e)
        {
            if (ICFTabelle.Visible==false)
            {
                ICFTabelle.Visible = true;
                ICFTree.Visible = false;
            }
            else
            {
                ICFTabelle.Visible = false;
                ICFTree.Visible = true;
            }
        }
    }
}