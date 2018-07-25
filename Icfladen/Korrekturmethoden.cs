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
    public partial class Form1: Form
    {
        //
        // Einmalige Methoden zur ICF Strukturfehlerkorrektur
        //

        // Löschen der überflüssigen Kategorie i110-i130  mmit id838 

        private void Delete838()
        {
            Tabelle.Rows.RemoveAt(838);
        }

        // hinzufügen der Fehlenden Kategorie i520 zwischen GSOID 1335512 und 1335513,  und Korrektur der folgenden Kategorien

        private void Addi520()
        {
            DataRow row = Tabelle.NewRow();
            row["id"] = "15885";
            row["Titel"] = "Beschäftigungssituation";
            row["Beschreibung"] = " Bezieht sich auf Art und Umfang einer Ausbildungs-, Erwerbs- oder ehrenamtlichen Tätigkeit. ";
            row["Code"] = "i520";
            row["Inklusion"] = "Inkl.: Schüler - und Studenten, Hausfrauen, beschäftigungslose Menschen";
            row["Pfad"] = "1.3.3.5.5.1.3";
            row["AhnPfad"] = "1.3.3.5.5.1";
            row["OldId"] = Tabelle.Rows.Find(838)["OldId"];
            Tabelle.Rows.InsertAt(row, 1588);

            row = Tabelle.Rows.Find(1589);
            row.BeginEdit();
            row["Pfad"] = "1.3.3.5.5.1.4";
            row.EndEdit();

            row = Tabelle.Rows.Find(1590);
            row.BeginEdit();
            row["Pfad"] = "1.3.3.5.5.1.5";
            row.EndEdit();
        }

        // Vertauschen der Blöcke in Kapitel b2 mit 1 auf 2, 2 auf 4, 3 auf 1, 4 auf 3

        private void ShiftChapterS2()
        {
            DataRow row;

            for (int i = 132; i < 214; i++)
            {
                row = Tabelle.Rows.Find(i);
                string GSOID = (string)row["Pfad"];
                int Ende = GSOID.Length;
                if (Ende >= 10)
                {
                    string GsOidA = GSOID.Substring(0, 10);
                    string GsOidE = GSOID.Substring(11, Ende - 11);
                    row.BeginEdit();
                    switch (GSOID[10])
                    {
                        case '1':
                            row["Pfad"] = GsOidA + '2' + GsOidE;
                            break;
                        case '2':
                            row["Pfad"] = GsOidA + '4' + GsOidE;
                            break;
                        case '3':
                            row["Pfad"] = GsOidA + '1' + GsOidE;
                            break;
                        case '4':
                            row["Pfad"] = GsOidA + '3' + GsOidE;
                            break;
                    }
                    row.EndEdit();
                }
            }

            for (int i = 0; i < 26; i++)
            {
                DataRow NewRow = Tabelle.NewRow();
                row = Tabelle.Rows.Find(176 + i);
                NewRow.ItemArray = row.ItemArray;

                Tabelle.Rows.RemoveAt(176 + i);
                Tabelle.Rows.InsertAt(NewRow, 132 + i);

            }
            for (int i = 0; i < 13; i++)
            {
                DataRow NewRow = Tabelle.NewRow();
                row = Tabelle.Rows.Find(202 + i);
                NewRow.ItemArray = row.ItemArray;

                Tabelle.Rows.RemoveAt(202 + i);
                Tabelle.Rows.InsertAt(NewRow, 183 + i);
            }
        }






    }



}