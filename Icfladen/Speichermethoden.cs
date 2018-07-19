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
        // in alter Formatierung.

        private void SpeichernAlt()
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
                Aktiver.SelectSingleNode(EinträgeOriginal[2], nsmgr).InnerText = (string)row["Code"];
                Aktiver.SelectSingleNode(EinträgeOriginal[3], nsmgr).InnerText = (string)row["Pfad"];
                Aktiver.SelectSingleNode(EinträgeOriginal[4], nsmgr).InnerText = (string)row["Titel"];

                if (Aktiver.SelectSingleNode(EinträgeOriginal[6], nsmgr).HasChildNodes == true)
                {
                    XmlNodeList Addendum = Aktiver.SelectSingleNode(EinträgeOriginal[6], nsmgr).ChildNodes;
                    int AnzahlZusatz = Addendum.Count;
                    if (AnzahlZusatz == 1)
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
    }



}

