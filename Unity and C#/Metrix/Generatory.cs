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
    class Generatory
    {

        //HONOTY PRO VYPOCET RANDOM CISLA (KGENERATOR A VLASTNIGENERATOR)
        double omg;
        double x;
        double y = DateTime.Now.Millisecond; //seed

        public double vlastnigenerace() //z nejakyho duvodu musim definovat cas a hned mu nastavit promennou a nemuzu definovat vsechny najednou
        {
            double cas;
            cas = DateTime.Now.Millisecond;
            if (cas == 0)
                cas++;

            x = (cas * cas + (cas + 20));
            omg = x / 100; //posunuti desetinné čárky aby nevycházela moc podobná čísla
            omg = Math.Round(omg, MidpointRounding.AwayFromZero); //zaokrouhleni normalni
            return omg % 10; //zobrazeni poslednich 2 cisel
        }

        public double kgenerator() //Kgenerator nahodnych cisel pro interval 0,100
        {
            double p;
            y = (1103515245 * y + 12345) % 4294967296; //konstatnty které jsem opsal z teamsu. Vhodné hodnoty, které využívá např. standardní knihovna jazyka C jsou M= 2 na 32,A= 1103515245,C= 12345.
            p = y / (4294967296); //x = (1103515245 * x + 12345) % 4294967296; return x / ((double)4294967296); => prevedeni do intervalu <0,1) tim, že zaokrouhlíme na 0 desetinných míst
            return (Math.Round(p, 2)) * 100; //bez *100 by bylo napr. 0,83, interval pro jedno desetinne cislo by bylo zaokrouhleni na jedno cislo a * 10
        }

        public double vlastnigenerace2() //z nejakyho duvodu musim definovat cas a hned mu nastavit promennou a nemuzu definovat vsechny najednou
        {
            double cas;
            cas = DateTime.Now.Millisecond;
            if (cas == 0)
                cas++;

            x = (cas * cas + (cas + 20));
            omg = x / 100; //posunuti desetinné čárky aby nevycházela moc podobná čísla
            omg = Math.Round(omg, MidpointRounding.AwayFromZero); //zaokrouhleni normalni
            return omg % 25; //zobrazeni poslednich 2 cisel
        }
    }
}
