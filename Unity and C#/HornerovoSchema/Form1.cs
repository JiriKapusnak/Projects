using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HornerovoSchema
{
    public partial class HornerovoSchema : Form
    {
        Knihovna knihovna = new Knihovna();
        Prevodycs prevody = new Prevodycs();

        //REPREZENTACE CISELNYCH SOUSTAV V INTECH
        public static int dvojkova = 2;
        public static int osmickova = 8;
        public static int desitkova = 10;
        public static int sestnactkova = 16;

        //VYTVORENE POLE
        public static TextBox[] textboxy = new TextBox[4]; //Do pole pro lepsi pracovani s textboxy
        public static Button[] tlacitka = new Button[4]; //Do pole pro lepsi pracovani s tlacitkama
        public static CheckBox[] checkboxy = new CheckBox[3]; //Do pole pro lepsi pracovani s checkboxy

        //POMOCNE PROMENNE
        public static string cislo; //CISLO Z TEXTBOXU
        public static int vysledekint; //VYSLEDEK PREVODU V INTU
        public static string vysledekstring; //VYSLEDEK PREVODU V STRINGU 

        public HornerovoSchema()
        {
            InitializeComponent();
            textboxy[0] = dvatextbox; textboxy[1] = osmtextbox; textboxy[3] = desettextbox; textboxy[2] = sestnacttextbox; //Pridani textboxu do pole
            tlacitka[0] = dvojabut; tlacitka[1] = osmbutt; tlacitka[3] = desetbutt; tlacitka[2] = sestnactbutt; //Pridani tlacitek do pole
            checkboxy[0] = dvacheck; checkboxy[1] = osmcheck; checkboxy[2] = sestnactcheck; //Pridani checkboxu do pole

            //Nastaveni progressbaru
            progressbar.Dock = DockStyle.Bottom; //TAK ABY BYL PROGRESS BAR UPLNE DOLE
            progressbar.Maximum = 160; //MAXIMUM 160 NA 16TKOVOU SOUSTAVU, PRI DESITKOVE NASTAVUJU TREBA 100, PRI DVOJKOVE 20 ATD...
            progressbar.Minimum = 0;

            for (int i = 0; i < 4; i++)
            {
                textboxy[i].Enabled = false; //NASTAVENI VSECH TEXTBOXU NA VYPLE ABY TAM NIKDO NEMOHL PSAT
            }
        }

        private void kontrolasoustav_Tick(object sender, EventArgs e)
        {
            knihovna.Kontrola(); //VYPINANI TLACITEK A TEXTBOXU PODLE ZVOLENE SOUSTAVY
        }

        private void dvojabut_Click(object sender, EventArgs e)
        {
            if (osmcheck.Checked == true) //KDYZ JE OSMICKOVA ZASKRTNUTA
            {
                cislo = textBox1.Text; //UCHOVANI SLOVA DO STRINGU A NASLEDNA PRACE SNIM
                knihovna.KontrolaOsm(cislo);
                if (knihovna.KontrolaOsm(cislo) == 1) //KONTROLA ZDA JSOU NAPSANY JEN CISLA MEZI 0 - 7
                {
                    progressbar.Value = 80; //NASTAVENI PROGRESS BARU
                    prevody.prevod(2, osmickova, dvojkova); //PREVOD, VOLBA JE DVOJKOVA SOUSTAVA (2), SOUSTAVA Z KTERE PREVADIME JE OSMICKOVA A PREVADIME NA DVOJKOVOU
                    dvatextbox.Text = vysledekstring; //ZAPSANI VYSLEDKU
                    vysledekstring = ""; //VYMAZANI TEXTU ZE STRINGU PRO DALI NAPIS
                }
            }
            else if (sestnactcheck.Checked == true) //KDYZ JE SESNACTKOVA ZAKRNUTA
            {
                cislo = textBox1.Text; //UCHOVANI SLOVA
                knihovna.KontrolaSestnact(cislo);
                if (knihovna.KontrolaSestnact(cislo) == 1) //KONTROLA ZDA JSOU VSECHNY CISLA MEZI 0-9 A PISMENA MEZI A-F
                {
                    progressbar.Value = 160; //PROGRESS BAR NA MAX PROTOZE NEJVYSSI SOUSTAVA
                    prevody.prevod(2, sestnactkova, dvojkova); //PREVOD, NA DVOJKOVOU Z SESNACTKOVE
                    dvatextbox.Text = vysledekstring; //ZAPSANI VYSLEDKU
                    vysledekstring = ""; //VYNULOVANI STRINGU
                }
            }
            else //KDYZ JE DESITKA ZAKRTNUTA
            {
                cislo = textBox1.Text; //UCHOVANI SLOVA
                knihovna.KontrolaDeset(cislo);
                if (knihovna.KontrolaDeset(cislo) == 1) //KONTROLA ZDA JSOU VSECHNY CISLA MEZI 0-9 A NEJSOU ZADNA PISMENA
                {
                    progressbar.Value = 100; //PROGRESS BAR NA 100 PROTOZE DESITKOVA SOUSTAVA
                    prevody.prevod(2, desitkova, dvojkova); //PREVOD NA DVOJKOVOU Z DESITKOVE
                    dvatextbox.Text = vysledekstring; //ZAPSANI VYSLEDKU
                    vysledekstring = ""; //VYNULOVANI
                }
            }
        }

        private void osmbutt_Click(object sender, EventArgs e)
        {
            if (dvacheck.Checked == true) //NA DVOJKOVOU
            {
                cislo = textBox1.Text; //UCHOVANI SLOVA
                knihovna.KontrolaDva(cislo); 
                if (knihovna.KontrolaDva(cislo) == 1) //KONTROLA ZDA JSOU JEN 1 A 0
                {
                    progressbar.Value = 20; //PROGRESS BAR NA 20 PROTOZE DVOJKOVA SOUSTAVA
                    prevody.prevod(8, dvojkova, osmickova); //PREVOD
                    osmtextbox.Text = vysledekstring; //VYSLEDEK
                    vysledekstring = ""; //VYNULOVANI
                }
            }
            else if (sestnactcheck.Checked == true) //NA SESTNACTKOVOU
            {
                cislo = textBox1.Text; //UCHOVANI SLOVA
                knihovna.KontrolaSestnact(cislo);
                if (knihovna.KontrolaSestnact(cislo) == 1) //KONTROLA
                {
                    progressbar.Value = 160; //PROGRESS BAR
                    prevody.prevod(8, sestnactkova, osmickova); //PREVOD
                    osmtextbox.Text = vysledekstring; //VYSLEDEK
                    vysledekstring = ""; //VYNULOVANI
                }
            }
            else //NA DESITKOVOU
            {
                cislo = textBox1.Text; //UCHOVANI SLOVA
                knihovna.KontrolaDeset(cislo);
                if (knihovna.KontrolaDeset(cislo) == 1) //KONTROLA
                {
                    progressbar.Value = 100; //PROGRESS BAR
                    prevody.prevod(8, desitkova, osmickova); //PREVOD
                    osmtextbox.Text = vysledekstring; //VYSLEDEK
                    vysledekstring = ""; //VYNULOVANI
                }
            }
        }

        private void desetbutt_Click(object sender, EventArgs e)
        {
            if (dvacheck.Checked == true) //NA DVOJKOVOU
            {
                cislo = textBox1.Text; //UCHOVANI SLOVA
                knihovna.KontrolaDva(cislo);
                if (knihovna.KontrolaDva(cislo) == 1) //KONTROLA
                {
                    progressbar.Value = 20; //PROGRESS BAR
                    prevody.prevod(10, dvojkova, desitkova); //PREVOD
                    desettextbox.Text = Convert.ToString(vysledekint); //VYSLEDEK V INTU PROTOZE NA DESITKOVOU SOUSTAVU JSEM PRACOVAL JEN S VYSLEDKEM INTU A NE S POLEM ZNAKU
                    vysledekstring = ""; //VYNULOVANI
                }
            }
            else if (sestnactcheck.Checked == true) //NA SESTNACTKOVOU
            {
                cislo = textBox1.Text; //UCHOVANI SLOVA
                knihovna.KontrolaSestnact(cislo);
                if (knihovna.KontrolaSestnact(cislo) == 1) //KONTROLA
                {
                    progressbar.Value = 160; //PROGRESS BAR
                    prevody.prevod(10, sestnactkova, desitkova); //PREVOD
                    desettextbox.Text = Convert.ToString(vysledekint); //VYSLEDEK
                    vysledekstring = ""; //VYNULOVANI
                }
            }
            else //NA OSMICKOVOU
            {
                cislo = textBox1.Text; //UCHOVANI SLOVA
                knihovna.KontrolaOsm(cislo);
                if (knihovna.KontrolaOsm(cislo) == 1) //KONTROLA
                {
                    progressbar.Value = 80; //PROGRESS BAR
                    prevody.prevod(10, osmickova, desitkova); //PREVOD
                    desettextbox.Text = Convert.ToString(vysledekint); //VYSLEDEK
                    vysledekstring = ""; //VYNULOVANI
                }
            }
        }

        private void sestnactbutt_Click(object sender, EventArgs e)
        {
            if (dvacheck.Checked == true) //NA DVOJKOVOU SOUSTAVU
            {
                cislo = textBox1.Text; //UCHOVANI SLOVA
                knihovna.KontrolaDva(cislo);
                if (knihovna.KontrolaDva(cislo) == 1) //KONTROLA
                {
                    progressbar.Value = 20; //PROGRESS BAR
                    prevody.prevod(16, dvojkova, sestnactkova); //PREVOD
                    sestnacttextbox.Text = vysledekstring; //VYSLEDEK
                    vysledekstring = ""; //VYNULOVANI
                }
            }
            else if (osmcheck.Checked == true) //NA OSMICKOVOU SOUSTAVU
            {
                cislo = textBox1.Text; //UCHOVANI SLOVA 
                knihovna.KontrolaOsm(cislo);
                if (knihovna.KontrolaOsm(cislo) == 1) //KONTROLA
                {
                    progressbar.Value = 80; //PROGRESS BAR
                    prevody.prevod(16, osmickova, sestnactkova); //PREVOD
                    sestnacttextbox.Text = vysledekstring; //VYSLEDEK
                    vysledekstring = ""; //VYNULOVANI
                }
            }
            else //DESITKOVA SOUSTAVA
            {
                cislo = textBox1.Text; //UCHOVANI SLOVA
                knihovna.KontrolaDeset(cislo);
                if (knihovna.KontrolaDeset(cislo) == 1) //KONTROLA
                {
                    progressbar.Value = 100; //PROGRESS BAR
                    prevody.prevod(16, desitkova, sestnactkova); //PREVOD
                    sestnacttextbox.Text = vysledekstring; //VYSLEDEK
                    vysledekstring = ""; //VYNULOVANI
                }
            }
        }
        private void konecbutt_Click(object sender, EventArgs e)
        {
            Application.Exit(); //UKONCENI APLIKACE
        }

        private void dvacheck_Click(object sender, EventArgs e)
        {
            osmcheck.Checked = false;
            sestnactcheck.Checked = false;
        }

        private void osmcheck_Click(object sender, EventArgs e)
        {
            dvacheck.Checked = false;
            sestnactcheck.Checked = false;
        }

        private void sestnactcheck_Click(object sender, EventArgs e)
        {
            dvacheck.Checked = false;
            osmcheck.Checked = false;
        }
    }
}
