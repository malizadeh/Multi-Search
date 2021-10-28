using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multi_Search
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = wordlist[id];

        }
        bool formclosing = false;
        int id = 0;
        string[] wordlist = new string[] {
                "sauber", "Bar", "Schiff", "anrufen", "putzen", "Badezimmer", "Körper", "Kamera", "Uhr", "Strand", "Knochen", "Lager",
                "schließen", "Bart", "Buch", "Auto", "Wagen", "Kleidung", "schlagen", "Flasche", "Karte", "Verein", "schön",
                "Unterseite", "tragen", "Mantel", "Kaffee", "dunkel", "nach unten", "Energie", "kalt", "Datum", "zeichnen",
                "Motor", "Farbe", "Tochter", "Traum", "Abend", "Computer", "Tag", "Kleid", "Übung", "Konsonant", "tot", "drink ",
                "teuer", "Auftrag", "taub", "fahren", "explodieren", "kochen", "Tod", "Medikament", "Auge", "kühl", "Dezember",
                "trocken", "Gesicht", "Kupfer", "tief", "Staub", "Herbst", "Mais", "Diamant", "Ohr", "fallen", "Ecke", "sterben",
                "Erde", "Familie", "zählen", "graben", "Osten", "berühmt", "Land", "Abendessen", "essen", "Lüfter", "Gericht",
                "Richtung", "Rand", "Fan", "Kuh", "schmutzig", "Ei", "Bauernhof", "Menge", "Krankheit", "acht", "schnell",
                "weinen", "Arzt", "achtzehn", "Vater", "Tasse", "Hund", "achtzig", "Februar", "gebogen", "Dollar", "Wahl",
                "füttern", "schneiden", "Tür", "Elektronik", "weiblich", "tanzen", "Punkt", "Elf", "fünfzehn", "fünfte", "vierzehn",
                "wachsen", "Pferd", "fünfzig", "vierte", "Gewehr", "Krankenhaus", "kämpfen", "Freitag", "Haar", "heiß",
                "finden", "Freund", "Freundin", "Halbe", "Hotel", "Finger", "Vorderseite" };
        private void button1_Click(object sender, EventArgs e)
        {
            //button1.Enabled= false;
            id += 1;
            Clipboard.SetText(textBox1.Text);
            string searchvalue = WebUtility.UrlEncode(textBox1.Text);

            string[] targets = new string[]
            {
                $"https://www.google.de/search?q={searchvalue}&tbm=isch&hl=de&tbs=isz:m&sa=X&ved=0CAMQpwVqFwoTCPiXlKyCz_MCFQAAAAAdAAAAABAC&biw=1903&bih=969" + " --new-window",
                $"https://www.collinsdictionary.com/dictionary/german-english/{searchvalue}",
                $"https://www.verbformen.de/?w={searchvalue}",
                $"https://forvo.com/word/{searchvalue}/#de"
            };

            try
            {
                foreach (var target in targets)
                {
                    var p = new System.Diagnostics.Process();
                    p.StartInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",
                        Arguments = target,
                        UseShellExecute = false,
                        RedirectStandardOutput = true
                    };
                    p.Start();
                    Thread.Sleep(250);
                }
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
            textBox1.Text = wordlist[id];
            DateTime t = DateTime.Now;
            while (DateTime.Now <= t.AddSeconds(90) && !formclosing)
            {
                Thread.Sleep(250);
                TimeSpan ts = DateTime.Now - t;
                label2.Text = $"{ts.TotalSeconds}";
                Application.DoEvents();
            }
            SoundPlayer player = new SoundPlayer(Properties.Resources.pcmwav);
            player.Play();
            label2.Text = "00";

            // button1.Enabled = true;
            textBox1.Focus();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            formclosing = true;
        }
    }
}
