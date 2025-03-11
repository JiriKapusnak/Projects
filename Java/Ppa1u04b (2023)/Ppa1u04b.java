import java.io.*;
import java.util.*;
import java.text.*;

public class Ppa1u04b {

    public static void main(String[] args) throws Exception 
    {
        Scanner sken = new Scanner(System.in); //Zalozeni noveho scanneru (abychom mohli precist vstup uzivatele)

        //POMOCNE HODNOTY
        int velikostokna = 4;
        double vysledek = 0;
        double cislo = 0;
        double[] cisla = new double[velikostokna];
        int deleni = 10;
        int poradi = 1;
        int i = 0;

        //PRECTENI A UPRAVENI VSTUPU
        for (;;) {
            cislo = sken.nextDouble(); //ulozeni zapsaneho cisla
            if (cislo == 0) { //kdyz 0 konec
                break;
            }
            else {
                cisla[i] = cislo; //zapsani cisla do pole
                if (poradi > 3) {
                    //VYPOCET PRUMERU
                    for (int j = 0; j < velikostokna; j++) {
                        vysledek += cisla[j] * (j+1); //vypocet prumeru bez deleni
                    }
                    System.out.printf(Locale.ENGLISH, "%d;%.2f;%.2f\n", poradi, cislo, (vysledek/deleni)); //vypsani

                    //PREPSANI POLE (NA SILU :D)
                    cisla[0] = cisla[1]; //z 1 na 0
                    cisla[1] = cisla[2]; //z 2 na 1
                    cisla[2] = cisla[3]; //z 3 na 2
                    i--; //pro udrzeni i na jednom a tom samem cisle a my vzdy doplnili jen cisla[3]
                    vysledek = 0;

                }
                else {
                    System.out.printf(Locale.ENGLISH, "%d;%.2f;\n", poradi, cislo); //vypsani pro prvni 3 cisla
                }
            }
            poradi++; //poradi se zvetsuje kazdym cislem
            i++;
        }
    }
}