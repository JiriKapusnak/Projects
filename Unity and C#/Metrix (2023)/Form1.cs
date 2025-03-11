using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metrix
{
    public partial class Matrix : Form
    {
        //1920 / 100 = 19,2 pixelu
        //ZOBRAZUJE SE MAXIMALNE 6 LABELU NARAZ!!!

        //HONOTY PRO VYPOCET RANDOM CISLA (KGENERATOR A VLASTNIGENERATOR)
        Generatory generator = new Generatory();
        KnihovnaMetod knihovna = new KnihovnaMetod();

        //PRO KAZDY LABEL VLASTNI CISLO LABELU A STEP
        public static int[] cislolabelu = new int[50]; //{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 , 0, 0, 0, 0, 0, 0 , 0, 0}; //KAZDY LABEL ZACINA NA CISLE 0 ZE 100
        public static int[] step = new int[50]; //KAZDY LABEL MA VLASTNI STEP
        public static int[] kolikznaku = new int[50]; //POCET ZNAKU KOLIK BUDE V KAZDYM LABELU
        public static Label[,] labely = new Label[50, 100]; //20 RUZNYCH POLI LABELU PO 100 LABELECH

        //100 BODU NA x-ose KDYZ 1920x1080
        public static double pixel = 19.2; //jeden bod
        public static int vylosovanex = 0; //x ve kterym se cislo objevi

        //ZNAKY A BARVY
        public static char[] znaky = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' }; //10 ZNAKU
        public static Color[] barvy = new Color[10] { Color.White, Color.Red, Color.AliceBlue, Color.Aqua, Color.Yellow, Color.Orange, Color.Green, Color.Purple, Color.LightBlue, Color.LightGray };

        public Matrix()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            knihovna.vytvorenilabelu(); //VSEM LABELUM SE NASTAVI HODNOTA PRI STARTU
            knihovna.generaceznaku(); //VYGENEROVANI ZNAKU
            knihovna.nastavenikroku();
            pridanidoformu(); //GENERACE PRVNICH LABELU
        }

        void pridanidoformu()
        {
            for (int i = 0; i < 50; i++)
            {
                this.Controls.Add(labely[i, cislolabelu[i]]);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 50; i++) //CYKLUS SESTI PRO KAZDEJ LABEL
            {
                labely[i, cislolabelu[i]].Location = new Point(labely[i, cislolabelu[i]].Location.X, labely[i, cislolabelu[i]].Location.Y + step[i]); //KAZDEJ LABEL UDELA STEP

                if (labely[i, cislolabelu[i]].Location.Y > 1300) //KDYZ JE LABEL DOSTATECNE POD FORMEM TAK SE POSUNE NA DALSI CISLOLABELU A TO SE VYGENERUJE
                {
                    if (cislolabelu[i] == 99) //OCHRANA PRED SPADNUTIM MATRIXU KDYZ JE CISLO VETSI NEZ POLE (100...)
                        cislolabelu[i] = 0;
                    cislolabelu[i]++; //POSUNUTI POLE LABELU O JEDNO NA DALSI LABEL
                    kolikznaku[i] = (int)generator.vlastnigenerace2(); //VYGENERUJE SE NOVEJ POCET ZNAKU PRO NOVEJ LABEL
                    pridanidoformu(); //PRIDANI LABELU DO FORMU
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 50; i++) //CYKLUS SESTI PRO KAZDEJ LABEL
            {
                labely[i, cislolabelu[i]].Text = knihovna.Finalnitext()[i]; //ZAPISE SE TEXTOVE POLE Z METODY
            }
        }
    }
}
