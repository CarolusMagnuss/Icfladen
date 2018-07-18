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
            MakeTable();
            ICFtoTable(XMLDatei);
            ICFTabelle.DataSource = Tabelle;
            TabellenUI();
            Populate();
        }

        //string XMLDatei = "\\ICF.xml";
        string XMLDatei = "\\data.xml";
        string[,] Liste = new string[1602, 4];
        string[] EinträgeOriginal = { "//d2p1:ClassificationObject",
                              ".//d2p1:DescriptionTexts/d4p1:DescriptionText/d4p1:DescriptionText/d4p1:Text",
                              ".//d2p1:DisplayTexts/d4p1:DisplayText/d4p1:DisplayText/d4p1:Text",
                              ".//d2p1:GsOid",
                              ".//d2p1:ShortNames/d4p1:ShortName/d4p1:ShortName/d4p1:Text",
                              ".//d2p1:Options/d4p1:Option/d4p1:Option/d4p1:Value",
                              ".//d2p1:Options/d4p1:Option"};
        string[] EinträgeNeu = {"//ClassificationObject",
                                ".//Beschreibung",
                                ".//ID",
                                ".//ICF-Code",
                                ".//Titel",
                                ".//Hierachienummer",
                                ".//Frage",
                                ".//Inklusion",
                                ".//Exklusion"};
        int LetzedierteZeile;

        DataTable Tabelle = new DataTable("Klassifikationsobjekte");

        private void MakeTable() // Tabelle für die ICF Klassifikationsobjekte erschaffen.
        {
            DataColumn column;


            column = new DataColumn
            {
                DataType = Type.GetType("System.Int32"),
                ColumnName = "id",
                ReadOnly = true,
                Unique = true
            };
            Tabelle.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Titel",
                ReadOnly = false,
                Unique = false
            };

            Tabelle.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Beschreibung",
                ReadOnly = false,
                Unique = false
            };
            Tabelle.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Code",
                ReadOnly = false,
                Unique = false
            };
            Tabelle.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Pfad",
                ReadOnly = false,
                Unique = false
            };
            Tabelle.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Inklusion",
                ReadOnly = false,
                Unique = false
            };
            Tabelle.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Exklusion",
                ReadOnly = false,
                Unique = false
            };
            Tabelle.Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Frageformulierung",
                ReadOnly = false,
                Unique = false
            };
            Tabelle.Columns.Add(column);

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = Tabelle.Columns["id"];
            Tabelle.PrimaryKey = PrimaryKeyColumns;

        }

        private void ICFtoTable(string Datei)//liest die XML Datei aus und füllt die Tabelle mit den Kategorien.
        {
            DataRow row;
            XmlNode Aktiver;
            XmlDocument dom = new XmlDocument();
            dom.Load(Application.StartupPath + Datei);

            if (Datei == "\\ICF.xml")
            {
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(((XmlDocument)dom).NameTable);
                nsmgr.AddNamespace("d2p1", "http://schemas.datacontract.org/2004/07/Geronto.Framework.Data.Classification.Model.V1");
                nsmgr.AddNamespace("d4p1", "http://schemas.datacontract.org/2004/07/Geronto.Framework.Data.Foundation.Model.V1");
                XmlNode root = dom.DocumentElement;
                Aktiver = root.SelectSingleNode(EinträgeOriginal[0], nsmgr);

                for (int k = 0; k < 1602; k++)
                {

                    row = Tabelle.NewRow();
                    row["id"] = k;
                    row["Beschreibung"] = Aktiver.SelectSingleNode(EinträgeOriginal[1], nsmgr).InnerText;
                    row["Code"] = Aktiver.SelectSingleNode(EinträgeOriginal[2], nsmgr).InnerText;
                    row["Pfad"] = Aktiver.SelectSingleNode(EinträgeOriginal[3], nsmgr).InnerText;
                    row["Titel"] = Aktiver.SelectSingleNode(EinträgeOriginal[4], nsmgr).InnerText;
                    if (Aktiver.SelectSingleNode(EinträgeOriginal[6], nsmgr).HasChildNodes == true)
                    {
                        XmlNodeList Addendum = Aktiver.SelectSingleNode(EinträgeOriginal[6], nsmgr).ChildNodes;
                        foreach (XmlNode node in Addendum)
                        {
                            string caption = node.LastChild.InnerText;
                            if (caption[0] == 'I')
                            {
                                row["Inklusion"] = caption;
                            }
                            else
                            {
                                row["Exklusion"] = caption;
                            }
                        }
                    }
                    Tabelle.Rows.Add(row);
                    Aktiver = Aktiver.NextSibling;
                }
            }
            else
            {
                XmlNode root = dom.DocumentElement;
                Ausgabe.Text = root.SelectSingleNode("//Speicher").InnerText;
                Aktiver = root.SelectSingleNode(EinträgeNeu[0]);

                for (int k = 0; k < 1602; k++)
                {

                    row = Tabelle.NewRow();
                    row["id"] = Aktiver.SelectSingleNode(EinträgeNeu[2]).InnerText;
                    row["Beschreibung"] = Aktiver.SelectSingleNode(EinträgeNeu[1]).InnerText;
                    row["Code"] = Aktiver.SelectSingleNode(EinträgeNeu[3]).InnerText;
                    row["Pfad"] = Aktiver.SelectSingleNode(EinträgeNeu[5]).InnerText;
                    row["Titel"] = Aktiver.SelectSingleNode(EinträgeNeu[4]).InnerText;
                    row["Frageformulierung"] = Aktiver.SelectSingleNode(EinträgeNeu[6]).InnerText;
                    row["Inklusion"] = Aktiver.SelectSingleNode(EinträgeNeu[7]).InnerText;
                    row["Exklusion"] = Aktiver.SelectSingleNode(EinträgeNeu[8]).InnerText;
                    Tabelle.Rows.Add(row);
                    Aktiver = Aktiver.NextSibling;
                }
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

                for (int t = 0; t < (Ebene - 1); t++)
                {
                    Pfadnummern[t] = (int)char.GetNumericValue(GSOID[(((t + 1) * 2) + 4)]);
                }

                //Ausgabe.Text = GSOID + Pfadnummern[1].ToString() + Pfadnummern[2].ToString() + Pfadnummern[3].ToString()+ Pfadnummern[4].ToString() + Pfadnummern[5].ToString()+" "+ GSOID;

                switch (Ebene)
                {
                    case 1:
                        ICFTree.Nodes.Add((string)row["Titel"]);
                        break;
                    case 2:
                        ICFTree.Nodes[(Pfadnummern[0] - 1)].Nodes.Add((string)row["Titel"]);
                        break;
                    case 3:
                        ICFTree.Nodes[(Pfadnummern[0] - 1)].Nodes[(Pfadnummern[1] - 1)].Nodes.Add((string)row["Code"] + " " + (string)row["Titel"]);
                        break;
                    case 4:
                        ICFTree.Nodes[(Pfadnummern[0] - 1)].Nodes[(Pfadnummern[1] - 1)].Nodes[(Pfadnummern[2] - 1)].Nodes.Add((string)row["Code"] + " " + (string)row["Titel"]);
                        break;
                    case 5:
                        ICFTree.Nodes[(Pfadnummern[0] - 1)].Nodes[(Pfadnummern[1] - 1)].Nodes[(Pfadnummern[2]) - 1].Nodes[(Pfadnummern[3] - 1)].Nodes.Add((string)row["Code"] + " " + (string)row["Titel"]);
                        break;
                    case 6:
                        ICFTree.Nodes[(Pfadnummern[0] - 1)].Nodes[(Pfadnummern[1] - 1)].Nodes[(Pfadnummern[2]) - 1].Nodes[(Pfadnummern[3]) - 1].Nodes[(Pfadnummern[4] - 1)].Nodes.Add((string)row["Code"] + " " + (string)row["Titel"]);
                        break;
                }
            }
        }

        private void TabellenUI()
        {
            ICFTabelle.Columns[0].Width = 40;
            ICFTabelle.Columns[1].Width = 350;
            ICFTabelle.Columns[2].Width = 350;
            ICFTabelle.Columns[3].Width = 80;
            ICFTabelle.Columns[4].Width = 100;
            ICFTabelle.Columns[5].Width = 100;
        }//Spaltenbreiten der Tabelle

        private void LadeButton_Click(object sender, EventArgs e)// Datei in alter Formattierung speichern
        {
            XmlDocument dom = new XmlDocument();
            DataRowCollection Zeilen = Tabelle.Rows;
            DataRow row;
            XmlNode Aktiver;
            dom.Load(Application.StartupPath + "//ICF.xml");

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(((XmlDocument)dom).NameTable);
            nsmgr.AddNamespace("d2p1", "http://schemas.datacontract.org/2004/07/Geronto.Framework.Data.Classification.Model.V1");
            nsmgr.AddNamespace("d4p1", "http://schemas.datacontract.org/2004/07/Geronto.Framework.Data.Foundation.Model.V1");

            XmlNode root = dom.DocumentElement;
            Aktiver = root.SelectSingleNode(EinträgeOriginal[0], nsmgr);


            for (int k = 0; k < 1602; k++)
            {
                row = Zeilen[k];
                Aktiver.SelectSingleNode(EinträgeOriginal[1], nsmgr).InnerText = (string)row["Beschreibung"];
                Aktiver.SelectSingleNode(EinträgeOriginal[1], nsmgr).InnerText = (string)row["Code"];
                Aktiver.SelectSingleNode(EinträgeOriginal[3], nsmgr).InnerText = (string)row["Pfad"];
                Aktiver.SelectSingleNode(EinträgeOriginal[4], nsmgr).InnerText = (string)row["Titel"];

                if (Aktiver.SelectSingleNode(EinträgeOriginal[6], nsmgr).HasChildNodes == true)
                {
                    XmlNodeList Addendum = Aktiver.SelectSingleNode(EinträgeOriginal[6], nsmgr).ChildNodes;
                    int AnzahlZusatz = Addendum.Count;
                    if (AnzahlZusatz==1)
                    {
                        
                        if ((string)row["Inklusion"] != "")
                        {
                            Addendum[0].LastChild.InnerText = (string)row["Inklusion"];
                        }
                        else
                        {
                            Addendum[0].LastChild.InnerText = (string)row["Exklusion"];
                        }
                    }
                    else
                    {
                        Addendum[0].LastChild.InnerText = (string)row["Inklusion"];
                        Addendum[1].LastChild.InnerText = (string)row["Exklusion"];
                    }
                }                
                Aktiver = Aktiver.NextSibling;
            }
            dom.PreserveWhitespace = true;
            dom.Save("ICFneu.xml");
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
        }//Wechselt zwischen Treeviewansicht und GridViewAnsicht

        private void Save_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<ClassificationObjects></ClassificationObjects>");
            XmlElement Speicher = doc.CreateElement("Speicher");
            Speicher.InnerText = LetzedierteZeile.ToString();
            doc.DocumentElement.AppendChild(Speicher);
            string[,] Objekteinträge = { { "Beschreibung", "Beschreibung" },
                                         { "id","ID" },
                                         { "Code","ICF-Code"},
                                         { "Titel","Titel"},
                                         {"Pfad","Hierachienummer" },
                                         {"Frageformulierung","Frage" },
                                         {"Inklusion" , "Inklusion"},
                                         { "Exklusion" , "Exklusion" } };
            
            foreach (DataRow row in Tabelle.Rows)  
            {
                XmlElement Kat = doc.CreateElement("ClassificationObject");
                doc.DocumentElement.AppendChild(Kat);
                for (int i = 0; i < 8; i++)
                {
                    XmlElement newElem = doc.CreateElement(Objekteinträge[i,1]);
                    newElem.InnerText = row[Objekteinträge[i,0]].ToString();
                    Kat.AppendChild(newElem);                    
                }
            }            
            doc.PreserveWhitespace = true;
            doc.Save("data.xml");

        } //speichert die Bearbeitete Tabelle in die data.xml

        private void ICFTabelle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Point Adresse = ICFTabelle.CurrentCellAddress;
            LetzedierteZeile = Adresse.Y;
            Ausgabe.Text = LetzedierteZeile.ToString();

        }

        private void ICFTabelle_CurrentCellChanged(object sender, EventArgs e)
        {
            if (ICFTabelle.CurrentCell != null)
            {
                EdierBox.Text = ICFTabelle.CurrentCell.Value.ToString();
            }
            
        }

        private void Change_Click(object sender, EventArgs e)
        {
            ICFTabelle.CurrentCell.Value = EdierBox.Text;
        }
    }
}
