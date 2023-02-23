import java.io.*;
import java.util.*;
import java.text.*;

public class Ppa1u04a {

    public static void main(String[] args) throws Exception 
    {
        Scanner sken = new Scanner(System.in); //Zalozeni noveho scanneru (abychom mohli precist vstup uzivatele)

        //POMOCNE HODNOTY A JEJICH ZADANI UZIVATELEM
        double posun = 0.001;
        double a = sken.nextDouble();
        double b = sken.nextDouble();
        double c = sken.nextDouble();
        double x1 = sken.nextDouble();
        double x2 = sken.nextDouble();
        double fx1; //bod ktery je posunuty pred x
        double fx2; //bod primo na x
        double fx3; //bod ktery je posunuty za x
        int min = 0;
        int max = 0;

        //VYPOCET
        for (double x = x1; x <= x2 + posun; x += posun) {
            fx1 = (Math.cos(x-posun) + a * Math.cos(b * (x-posun) + c)); //vypocet bodu pred x
            fx2 = (Math.cos(x) + a * Math.cos(b * x + c)); //vypocet x
            fx3 = (Math.cos(x+posun) + a * Math.cos(b * (x+posun) + c)); //vypocet bodu za x

            if ((fx1 < fx2) && (fx2 > fx3)) { //jestli x je vetsi nez bod pred nim a bod za nim, tak je to maximum
                max++;
            }
            else if ((fx1 > fx2) && (fx2 < fx3)) { //jestli x je mensi nez bod pred nim a bod za nim, tak je to minimum
                min++;
            }
        }

        //VYPIS
        System.out.println("min: " + min);
        System.out.println("max: " + max);

    }
}