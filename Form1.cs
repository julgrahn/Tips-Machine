using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tips_Machine
{
    public partial class Form1 : Form
    {
#pragma warning disable IDE0044 // Add readonly modifier
        List<Book> bookList = new List<Book>();
#pragma warning restore IDE0044 // Add readonly modifier
#pragma warning disable IDE0044 // Add readonly modifier
        List<string[]> vektorList = new List<string[]>();
#pragma warning restore IDE0044 // Add readonly modifier

        public Form1()
        {
            InitializeComponent();
        }

#pragma warning disable IDE1006 // Naming Styles
        private void button1_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            FileLoader(); //läser in metoden FileLoader
            Random rng = new Random(); //genererar ett "slumpmässigt" tal
            int nr = rng.Next(0, bookList.Count); //skapar ett "slumpmässigt" nummer mellan 0 och mängden böcker i vår lista
            textBox1.Text = bookList[nr].ToString(); //utskrift av boklistans element
            textBox2.Text = "Boknummer: " + Convert.ToString(nr); //skriver ut boknumret ur vår lista av böcker

        }

        public void FileLoader() //metod som vi skriver för att läsa in från filen samt lägga till det i vår boklista
        {
            if(File.Exists(@"C:\Users\Alexa.DESKTOP-N1BFAKT\source\repos\Tips Machine\Tips Machine\texter.txt")) //kollar om textfilen "texter.txt" finns i angiven sökväg
            {
                List<string> items = new List<string>(); //lägger till en lista av strängar som tar emot allt i textfilen
                StreamReader reader = new StreamReader(@"C:\Users\Alexa.DESKTOP-N1BFAKT\source\repos\Tips Machine\Tips Machine\texter.txt", Encoding.Default, true); //funktion för att läsa in text från filer
                string item;
                while((item = reader.ReadLine()) != null) //läser igenom filen radvis till sista radbrytet
                {
                    items.Add(item); //lägger till en sträng i vår lista "items"
                }


                foreach(string b in items) //itererar över allt som lagts till i listan "items"
                {
                    string[] vektor = b.Split(new string[] { "###" }, StringSplitOptions.None); //"splittar" de inlästa strängarna för varje ###-tecken i filen och lägger till en strängvektor 
                    vektorList.Add(vektor); //lägger till den inlästa strängvektorn

                    switch (vektor[2]) //läser av vektor nummer 3 (element 2) för att se om boken är en roman, novellsamling eller tidskrift
                    {
                        case "Roman":
                            bookList.Add(new Roman(vektor[0], vektor[1], vektor[2], vektor[3])); //lägger till en bok i bookList i formatet titel, författare, boktyp och om den finns inne eller ej
                            break;
                        case "Novellsamling":
                            bookList.Add(new Novellsamling(vektor[0], vektor[1], vektor[2], vektor[3]));
                            break;
                        case "Tidskrift":
                            bookList.Add(new Tidskrift(vektor[0], vektor[1], vektor[2], vektor[3]));
                            break;
                        default:
                            break;
                    }
                }
            }
        }

#pragma warning disable IDE1006 // Naming Styles
        private void textBox1_TextChanged(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class Novellsamling : Book
    {
        public Novellsamling(string title, string author, string type, string exists) : base (title, author, type, exists) //underklass till bok
        {
            Type = "Novellsamling"; //läser in boktypen från konstruktorn direkt
        }
        public override string ToString() //skriver om listans värden till strängar oavsett vad för datatyp som lästs in
        {
            string status; 
            if (Exists == "true") //vi läser av värdet "exists" som ett objekt från bokklassen för att kolla om värdet är "true" eller "false"
                status = "Finns inne"; //anger om boken finns eller inte beroende på "bool"-värdet i textfilen
            else
                status = "Finns inte inne";

            return "\"" + Title +"\"" + " av " + Author + ": " + Type + " - " + status; //formaterar utmatningen så den blir mer lättläst
        }
    }

    public class Roman : Book
    {
        public Roman(string title, string author, string type, string exists) : base(title, author, type, exists)
        {
            Type = "Roman";
        }
        public override string ToString()
        {
            string status;
            if (Exists == "true")
                status = "Finns inne";
            else
                status = "Finns inte inne";

            return "\"" + Title + "\"" + " av " + Author + ": " + Type + " - " + status;
        }
    }

    public class Tidskrift : Book
    {
        public Tidskrift(string title, string author, string type, string exists) : base(title, author, type, exists)
        {
            Type = "Tidskrift";
        }
        public override string ToString()
        {
            string status;
            if (Exists == "true")
                status = "Finns inne";
            else
                status = "Finns inte inne";

            return "\"" + Title + "\"" + " av" + Author + ": " + Type + " - " + status;

        }
    }
}
