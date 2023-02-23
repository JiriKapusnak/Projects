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
    class Knihovna
    {

        public char[] sestnactznaky = new char[6] { 'A', 'B', 'C', 'D', 'E', 'F' };

        public void Kontrola()
        {
            int stop = 5; //JAKOBY BOOL

            for (int i = 0; i < 3; i++) //KDYZ NEJAKY CHECKBOX JE ZASKRTNUTY, INTU STOP SE ZMENI HODNOTA
            {
                if (HornerovoSchema.checkboxy[i].Checked == true)
                {
                    stop = i;
                    break;
                }
            }

            if (stop != 5) //POKUD HODNOTA ZMENENA VYPNE SE TLACITKO DANE SOUSTAVY A OSTATNI SE ZAPNOU
            { 
                HornerovoSchema.tlacitka[stop].Enabled = false;
                for (int i = 0; i < 4; i++)
                {
                    if (i == stop)
                        i++;
                    if (HornerovoSchema.tlacitka[i].Enabled == false)
                        HornerovoSchema.tlacitka[i].Enabled = true;
                }
            }
            else //POKUD NENI HODNOTA ZMENENA VYPNE SE TLACITKO DESITKOVE SOUSTAVY A OSTATNI SE ZAPNOU
            {
                HornerovoSchema.tlacitka[3].Enabled = false;
                for (int i = 0; i < 3; i++)
                {
                    if (HornerovoSchema.tlacitka[i].Enabled == false)
                        HornerovoSchema.tlacitka[i].Enabled = true;
                }
            }

        }

        public int KontrolaDva(string box) //KONTROLA PRO 2 SOUSTAVU ZDA CISLA JSOU 1 A 0
        {
            foreach (char c in box)
            {
                if (c - '0' < 0 || c - '0' > 1)
                {
                    MessageBox.Show("Prosím zadejte pouze 1 nebo 0!");
                    return 0;
                }
            }
            return 1;
        }

        public int KontrolaOsm(string box) //KONTROLA PRO 8 SOUSTAVU ZDA CISLA JSOU MEZI 0-7
        {
            foreach (char c in box)
            {
                if (c - '0' < 0 || c - '0' > 7)
                {
                    MessageBox.Show("Prosím zadejte čísla mezi 0-7!");
                    return 0;
                }
            }
            return 1;
        }

        public int KontrolaDeset(string box) //KONTROLA PRO 10 SOUSTAVU ZDA CISLA JSOU MEZI 0-9 A NEJSOU TAM PISMENA
        {
            foreach (char c in box)
            {
                if (c - '0' < 0 || c - '0' > 9)
                {
                    MessageBox.Show("Prosím zadejte čísla mezi 0-9");
                    return 0;
                }
            }
            return 1;
        }

        public int KontrolaSestnact(string box) //KONTROLA PRO 16 SOUSTAVU ZDA CISLA JSOU MEZI 0-9 A JSOU TAM PISMENA JEN MEZI A - F VELKYMI
        {
            foreach (char c in box)
            {
                if ((c - '0' > 0) && (c - '0' < 9) || sestnactznaky.Contains(c))
                    continue;
                else
                {
                    MessageBox.Show("Prosím zadejte čísla mezi 0-9 a znaky A-F s velkými písmeny");
                    return 0;
                }
            }
            return 1;
        }
    }
}
