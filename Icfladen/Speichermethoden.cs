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
        // Liest die Originale XML Datei ein, und überschreibt die Knoten mit den Werten aus der Tabelle. Speichert unter neuem Namen 
        // in alter Formatierung. (Schreibt in alte Struktur hinein)

        private void SpeichernAlt()
        {
            XmlDocument dom = new XmlDocument();
            DataRowCollection Zeilen = Tabelle.Rows;
            DataRow row;
            XmlNode Aktiver;
            dom.Load(Application.StartupPath + "//ICFneu.xml");

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(((XmlDocument)dom).NameTable);
            nsmgr.AddNamespace("d2p1", "http://schemas.datacontract.org/2004/07/Geronto.Framework.Data.Classification.Model.V1");
            nsmgr.AddNamespace("d4p1", "http://schemas.datacontract.org/2004/07/Geronto.Framework.Data.Foundation.Model.V1");

            XmlNode root = dom.DocumentElement;
            Aktiver = root.SelectSingleNode(EinträgeOriginal[0], nsmgr);


            for (int k = 0; k < 1602; k++)
            {
                row = Zeilen[k];
                Aktiver.SelectSingleNode(EinträgeOriginal[1], nsmgr).InnerText = (string)row["Beschreibung"];
                Aktiver.SelectSingleNode(EinträgeOriginal[2], nsmgr).InnerText = (string)row["Code"];
                Aktiver.SelectSingleNode(EinträgeOriginal[3], nsmgr).InnerText = (string)row["Pfad"];
                Aktiver.SelectSingleNode(EinträgeOriginal[4], nsmgr).InnerText = (string)row["Titel"];

                if (Aktiver.SelectSingleNode(EinträgeOriginal[6], nsmgr).HasChildNodes == true)
                {
                    XmlNodeList Addendum = Aktiver.SelectSingleNode(EinträgeOriginal[6], nsmgr).ChildNodes;
                    int AnzahlZusatz = Addendum.Count;
                    if (AnzahlZusatz == 1)
                    {
                        if (!DBNull.Value.Equals(row["Inklusion"]))
                        {
                            row["Inklusion"]= "";
                        }
                        if (!DBNull.Value.Equals(row["Exklusion"]))
                        {
                            row["Exklusion"] = "";
                        }


                        if ((string)row["Inklusion"] != ""&& (string)row["Inklusion"]!=null)
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

        // Speichert die Tabelle in einfacher Formatierung in neue Datei

        private void SpeichernNeu()
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
                    XmlElement newElem = doc.CreateElement(Objekteinträge[i, 1]);
                    newElem.InnerText = row[Objekteinträge[i, 0]].ToString();
                    Kat.AppendChild(newElem);
                }
            }
            doc.PreserveWhitespace = true;
            doc.Save("data.xml");
        }

        // Erschafft Datei, welche die Ursprungsstruktur neu erschafft.

        private void SpeichernNeuInUrsprung()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement newElem;
            DataRowCollection Zeilen = Tabelle.Rows;

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(((XmlDocument)doc).NameTable);
            nsmgr.AddNamespace("d2p1", "http://schemas.datacontract.org/2004/07/Geronto.Framework.Data.Classification.Model.V1");
            nsmgr.AddNamespace("d4p1", "http://schemas.datacontract.org/2004/07/Geronto.Framework.Data.Foundation.Model.V1");
            //nsmgr.AddNamespace("xmlns", "http://schemas.datacontract.org/2004/07/Geronto.Framework.Common.Portable");
            nsmgr.AddNamespace("xmlns:z", "http://schemas.microsoft.com/2003/10/Serialization/");
            nsmgr.AddNamespace("xmlns:i", "http://www.w3.org/2001/XMLSchema-instance");


            XmlElement root=doc.CreateElement("GenericResultContainerOfArrayOfClassificationObjectrBvg5i8m");
            doc.AppendChild(root);
            doc.DocumentElement.SetAttribute("xmlns", "http://schemas.datacontract.org/2004/07/Geronto.Framework.Common.Portable");
            doc.DocumentElement.SetAttribute("xmlns:z", "http://schemas.microsoft.com/2003/10/Serialization/");
            doc.DocumentElement.SetAttribute("z:id", "i1");
            doc.DocumentElement.SetAttribute("xmlns:i", "http://www.w3.org/2001/XMLSchema-instance");

            newElem=doc.CreateElement("Exception");
            root.AppendChild(newElem);
            newElem.SetAttribute("xmlns:d2p1", "http://schemas.datacontract.org/2004/07/System");
            newElem.SetAttribute("i:nil", "true");

            newElem = doc.CreateElement("Messages");
            root.AppendChild(newElem);
            newElem.SetAttribute("xmlns:d2p1", "http://schemas.microsoft.com/2003/10/Serialization/Arrays");

            newElem = doc.CreateElement("Result");
            root.AppendChild(newElem);
            newElem.SetAttribute("xmlns:d2p1", "http://schemas.datacontract.org/2004/07/Geronto.Framework.Data.Classification.Model.V1");

            newElem = doc.CreateElement("ValidCode");
            root.AppendChild(newElem);
            newElem.InnerText = "Ok";            

            foreach (DataRow row in Zeilen)
            {
                newElem = doc.CreateElement("ClassificationObject");
                newElem.Prefix="d2p1";
                root.FirstChild.NextSibling.NextSibling.AppendChild(newElem);

                XmlNode aktiver = newElem;

                newElem = doc.CreateElement("d2p1", "Code", "");
                newElem.SetAttribute("i:nil", "true");
                aktiver.AppendChild(newElem);

                newElem = doc.CreateElement("d2p1", "Codesystem","");
                newElem.SetAttribute("i:nil", "true");
                aktiver.AppendChild(newElem);

                newElem = doc.CreateElement("d2p1", "DescriptionTexts", "");
                newElem.SetAttribute("xmlns:d4p1", "http://schemas.datacontract.org/2004/07/Geronto.Framework.Data.Foundation.Model.V1");
                aktiver.AppendChild(newElem);

                newElem = doc.CreateElement("d2p1", "DisplayTexts","");
                newElem.SetAttribute("xmlns:d4p1", "http://schemas.datacontract.org/2004/07/Geronto.Framework.Data.Foundation.Model.V1");
                aktiver.AppendChild(newElem);

                newElem = doc.CreateElement("d2p1", "GsOid","");
                newElem.InnerText=((string)row["Pfad"]);
                aktiver.AppendChild(newElem);

                newElem = doc.CreateElement("d2p1", "Id","");
                newElem.InnerText = ((string)row["OldId"]);
                aktiver.AppendChild(newElem);

                newElem = doc.CreateElement("d2p1", "Options","");
                newElem.SetAttribute("xmlns:d4p1", "http://schemas.datacontract.org/2004/07/Geronto.Framework.Data.Foundation.Model.V1");
                aktiver.AppendChild(newElem);

                newElem = doc.CreateElement("d2p1", "ParentGsOid","");
                newElem.InnerText = ((string)row["AhnPfad"]);
                if (newElem.InnerText == "")
                    { newElem.SetAttribute("i:nil", "true"); }
                aktiver.AppendChild(newElem);

                newElem = doc.CreateElement("d2p1", "ShortNames","");
                newElem.SetAttribute("xmlns:d4p1", "http://schemas.datacontract.org/2004/07/Geronto.Framework.Data.Foundation.Model.V1");
                aktiver.AppendChild(newElem);

                //ClassificationObjects zweite Ebene
                                
                //XmlNode Laufnode;                
                //Laufnode = aktiver.SelectSingleNode(".//d2p1:DescriptionTexts", nsmgr);

                //newElem = doc.CreateElement("d4p1", "DescriptionText");                
                //Laufnode.AppendChild(newElem);

                //Laufnode = Laufnode.FirstChild;

                //newElem = doc.CreateElement("d4p1", "DescriptionText");
                //Laufnode.AppendChild(newElem);

                //Laufnode = Laufnode.FirstChild;

                //newElem = doc.CreateElement("d4p1", "Lang");
                //newElem.InnerText = ("DE");
                //Laufnode.AppendChild(newElem);

                //newElem = doc.CreateElement("d4p1", "Text");
                //newElem.InnerText = ((string)row["Beschreibung"]);
                //Laufnode.AppendChild(newElem);

                //Laufnode = aktiver.SelectSingleNode(".//d2p1:DisplayTexts",nsmgr);                

                //newElem = doc.CreateElement("d2p1", "DisplayText");
                //Laufnode.AppendChild(newElem);

                //Laufnode = Laufnode.FirstChild;

                //newElem = doc.CreateElement("d2p1", "DisplayText");
                //Laufnode.AppendChild(newElem);

                //Laufnode = Laufnode.FirstChild;

                //newElem = doc.CreateElement("d4p1", "Lang");
                //newElem.InnerText = ("DE");
                //Laufnode.AppendChild(newElem);

                //newElem = doc.CreateElement("d4p1", "Text");
                //newElem.InnerText = ((string)row["Code"]);
                //Laufnode.AppendChild(newElem);

                //Laufnode = aktiver.SelectSingleNode("d2p1:Options",nsmgr);

                //newElem = doc.CreateElement("d4p1", ":Option");                
                //Laufnode.AppendChild(newElem);

                //Laufnode = Laufnode.FirstChild;

                //if (row.IsNull(5)==false)
                //{
                //    newElem = doc.CreateElement("d4p1", ":Option");
                //    Laufnode.AppendChild(newElem);

                //    Laufnode = Laufnode.FirstChild;

                //    newElem = doc.CreateElement("d4p1", "Key");
                //    newElem.InnerText = "Text";
                //    Laufnode.AppendChild(newElem);

                //    newElem = doc.CreateElement("d4p1", "Lang");
                //    newElem.InnerText = "DE";
                //    Laufnode.AppendChild(newElem);

                //    newElem = doc.CreateElement("d4p1", "Sort");
                //    newElem.InnerText = "1";
                //    Laufnode.AppendChild(newElem);

                //    newElem = doc.CreateElement("d4p1", "Value");
                //    newElem.InnerText = (string)row["Inklusion"];
                //    Laufnode.AppendChild(newElem);
                //}

                //Laufnode = aktiver.SelectSingleNode("Options",nsmgr);

                //if (row.IsNull(6)==false)
                //{
                //    newElem = doc.CreateElement("d4p1", "Option");
                //    Laufnode.AppendChild(newElem);

                //    Laufnode = Laufnode.FirstChild;

                //    newElem = doc.CreateElement("d4p1", "Key");
                //    newElem.InnerText = "Text";
                //    Laufnode.AppendChild(newElem);

                //    newElem = doc.CreateElement("d4p1", "Lang");
                //    newElem.InnerText = "DE";
                //    Laufnode.AppendChild(newElem);

                //    newElem = doc.CreateElement("d4p1", "Sort");
                //    newElem.InnerText = "1";
                //    Laufnode.AppendChild(newElem);

                //    newElem = doc.CreateElement("d4p1", "Value");
                //    newElem.InnerText = (string)row["Exklusion"];
                //    Laufnode.AppendChild(newElem);
                //}

                //Laufnode = aktiver.SelectSingleNode("d2p1:ShortNames",nsmgr);

                //newElem = doc.CreateElement("d4p1", "ShortName");
                //Laufnode.AppendChild(newElem);

                //Laufnode = Laufnode.FirstChild;

                //newElem = doc.CreateElement("d4p1", "ShortName");
                //Laufnode.AppendChild(newElem);

                //Laufnode = Laufnode.FirstChild;

                //newElem = doc.CreateElement("d4p1", "Lang");
                //newElem.InnerText = "DE";
                //Laufnode.AppendChild(newElem);

                //newElem = doc.CreateElement("d4p1", "Value");
                //newElem.InnerText = (string)row["Titel"];
                //Laufnode.AppendChild(newElem);

            }

            doc.PreserveWhitespace = true;
            doc.Save("Struktur.xml");

        }
    }





}

