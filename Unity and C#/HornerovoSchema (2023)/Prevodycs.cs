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
    class Prevodycs
    {
        public double vysledek;
        public double mezivysledek1;
        public double mezivysledek2;
        public double zbytek;
        public char[] sestnactznaky = new char[6] { 'A', 'B', 'C', 'D', 'E', 'F' };
        public double[] sestnactdoubleznaky = new double[6] { 10, 11, 12, 13, 14, 15 };

        public void prevod(int volba, int predeslasoustava, int nasledujicisoustava)
        {
            int pocetcyklu = 0;
            bool zapsano = false;
            double znak;
            double pocetznaku = 0;
            vysledek = 0;
            bool konec = false;

            switch (volba)
            {
                case 10: //DESITKOVA SOUSTAVA
                    foreach (char c in HornerovoSchema.cislo) //PRECTENI KOLIK ZNAKU PRO HORNEROVO SCHEMA
                    {
                        pocetznaku++;
                    }
                    pocetznaku--; //ZMENSENI POCET ZNAKU O 1 KVULI MATEMATICKYM VYPOCTUM
                    foreach (char c in HornerovoSchema.cislo) //PRO KAZDY ZNAK V POLI ZNAKU ZKONTROLUJ A VYPOCITEJ HODNOTU, PREDELEJ NA DESITKOVOU
                    {
                        pocetcyklu = 0;
                        znak = c - '0';
                        foreach (char p in sestnactznaky)
                        {
                            if (p == c) //KONTROLA JESTLI ZNAKY NEJSOU ZE SESTNACTKOVY (A-F)
                                znak = sestnactdoubleznaky[pocetcyklu];
                            else
                                pocetcyklu++; 
                        }
                        vysledek += Math.Pow(predeslasoustava, pocetznaku) * znak; //VYPOCET PODLE HORNEROVA SCHEMATU
                        pocetznaku--;
                    }
                    HornerovoSchema.vysledekint = Convert.ToInt32(vysledek); //VYSLEDEK
                    break;
                case 8:
                    List<double> znaky2 = new List<double>();

                    konec = false;
                    foreach (char c in HornerovoSchema.cislo) //VYPOCITANI ZNAKU
                    {
                        pocetznaku++;
                    }
                    pocetznaku--;
                    foreach (char c in HornerovoSchema.cislo) //PREVEDENI NA DESITKOVOU SOUSTAVU
                    {
                        pocetcyklu = 0;
                        znak = c - '0';
                        foreach (char p in sestnactznaky)
                        {
                            if (p == c)
                                znak = sestnactdoubleznaky[pocetcyklu];
                            else
                                pocetcyklu++;
                        }
                        mezivysledek1 += Math.Pow(predeslasoustava, pocetznaku) * znak;
                        pocetznaku--;
                    }
                    while (konec == false) //CYKLUS VE KTEREM SE BUDE POCITAT DLE SOUSTAVY 
                    {
                        mezivysledek2 = Math.Floor(mezivysledek1 / nasledujicisoustava); //MEZIVYSLEDEK = CISLO V DESITKOVE / VYDELENI SOUSTAVOU NA KTEROU PREVADIME A ZAOKROUHLENI DOLU
                        zbytek = mezivysledek1 - (mezivysledek2 * nasledujicisoustava); //VYPOCITANI ZBYTKU, KTERY DALE ZAPISEME DO POLE
                        mezivysledek1 = mezivysledek2; //DALE POCITAME S NASIM VYPOCITANYM VYSLEDKEM A OPAKUJEME DOKUD VYSLEDEK NEBUDE 0
                        znaky2.Add(zbytek);
                        if (mezivysledek1 == 0)
                            konec = true;
                    }
                    double[] vysledekznaky = znaky2.ToArray(); //ULOZENI LISTU DO POLE PODLE TOHO KOLIK TAM JE ZNAKU
                    Array.Reverse(vysledekznaky); //OTOCENI POLE JELIKOZ TIM ZPUSOBEM CO JA DELAM SE TO DELA OD KONCE
                    foreach (double d in vysledekznaky)
                    {
                        HornerovoSchema.vysledekstring += d; //ZAPISOVANI DO VYSLEDKU
                    }
                    break;
                case 16:
                    List<double> znaky3 = new List<double>();

                    konec = false;
                    foreach (char c in HornerovoSchema.cislo)
                    {
                        pocetznaku++;
                    }
                    pocetznaku--;
                    foreach (char c in HornerovoSchema.cislo)
                    {
                        pocetcyklu = 0;
                        znak = c - '0';
                        foreach (char p in sestnactznaky)
                        {
                            if (p == c)
                                znak = sestnactdoubleznaky[pocetcyklu];
                            else
                                pocetcyklu++;
                        }
                        mezivysledek1 += Math.Pow(predeslasoustava, pocetznaku) * znak;
                        pocetznaku--;
                    }
                    while (konec == false) { 
                        mezivysledek2 = Math.Floor(mezivysledek1 / nasledujicisoustava);
                        zbytek = mezivysledek1 - (mezivysledek2 * nasledujicisoustava);
                        mezivysledek1 = mezivysledek2;
                        znaky3.Add(zbytek);
                        if (mezivysledek1 == 0)
                            konec = true;
                       }
                    double[] vysledekznaky2 = znaky3.ToArray();
                    Array.Reverse(vysledekznaky2);
                    foreach (double d in vysledekznaky2)
                    {
                        zapsano = false;
                        for (int j = 10; j < 16; j++)
                        {
                            if (d == j) //KONTROLA ZDA CISLO NENI ZNAK A-F A POPRIPADE JEHO ZAPSANI DO STRINGU
                            {
                                zapsano = true;
                                HornerovoSchema.vysledekstring += sestnactznaky[j - 10];
                            }
                        }
                        if (zapsano == false)
                            HornerovoSchema.vysledekstring += d;
                    }
                    break;
                case 2:
                    List<double> znaky4 = new List<double>();

                    konec = false;
                    foreach (char c in HornerovoSchema.cislo)
                    {
                        pocetznaku++;
                    }
                    pocetznaku--;
                    foreach (char c in HornerovoSchema.cislo)
                    {
                        pocetcyklu = 0;
                        znak = c - '0';
                        foreach (char p in sestnactznaky)
                        {
                            if (p == c)
                                znak = sestnactdoubleznaky[pocetcyklu];
                            else
                                pocetcyklu++;
                        }
                        mezivysledek1 += Math.Pow(predeslasoustava, pocetznaku) * znak;
                        pocetznaku--;
                    }
                    while (konec == false)
                    {
                        mezivysledek2 = Math.Floor(mezivysledek1 / nasledujicisoustava);
                        zbytek = mezivysledek1 - (mezivysledek2 * nasledujicisoustava);
                        mezivysledek1 = mezivysledek2;
                        znaky4.Add(zbytek);
                        if (mezivysledek1 == 0)
                            konec = true;
                    }
                    double[] vysledekznaky3 = znaky4.ToArray();
                    Array.Reverse(vysledekznaky3);
                    foreach (double d in vysledekznaky3)
                    {
                        HornerovoSchema.vysledekstring += d;
                    }
                    break;
            } 
        }
    }
}
