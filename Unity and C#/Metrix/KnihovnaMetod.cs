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
    class KnihovnaMetod
    {
        Generatory generator = new Generatory();
        Random random = new Random();

        public void generaceznaku() //GENERACE ZNAKU PRO KAZDEJ LABEL KTEREJ JE NA OBRAZOVCE
        {
            for (int i = 0; i < 50; i++)
            {
                Thread.Sleep(100);
                Matrix.kolikznaku[i] = (int)generator.vlastnigenerace2();
            }
        }

        public void vytvorenilabelu()
        {
            for (int k = 0; k < 50; k++) //SMYCKA SESTI PRO KAZDE POLE LABELU
            {
                for (int i = 0; i < 100; i++) //SMYCKA STA PROTOZE KAZDE POLE LABELU MA 100 LABELU
                {
                    Matrix.vylosovanex = (int)generator.kgenerator() * (int)Matrix.pixel; //GENERACE NAHODNEHO CISLA 1-100 VYNASOBENA ZAKLADNIM BODEM
                    Matrix.labely[k, i] = new Label(); //VYTVORENI LABELU
                    Matrix.labely[k, i].ForeColor = Color.LightGreen;
                    Matrix.labely[k, i].BackColor = Color.Transparent;
                    Matrix.labely[k, i].Location = new Point(Matrix.vylosovanex, -300); //NASTAVENI POLOHY (-300 ABY BYL TEXT NAD FORMEM)
                    Matrix.labely[k, i].AutoSize = true;
                    Matrix.labely[k, i].Font = new Font("Arial", 14, FontStyle.Regular); //NASTAVENI VELIKOSTI A FONTU
                }
            }
        }

        public string[] Finalnitext()
        {
            string[] finalnitext = new string[50]; //VYTVORENI 6 TEXTU PRO 6 LABELU
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < Matrix.kolikznaku[i]; j++) //SMYCKA KTERA SE BUDE OPAKOVAT TOLIKRAT KOLIKRAT BUDE MIT LABEL ZNAKU
                {
                    finalnitext[i] += Convert.ToString(Matrix.znaky[random.Next(0, 26)]) + "\n"; //KAZDYMU LABELU SE NA KAZDEJ RADEK VYLOSUJE JINEJ ZNAK
                }
            }
            return finalnitext; //VRATI SE CELE POLE ZNAKU
        }

        public void nastavenikroku()
        {
            for (int i = 0; i < Matrix.step.Length; i++)
            {
                Matrix.step[i] = random.Next(4, 20); ;
            }
        }
    }
}
