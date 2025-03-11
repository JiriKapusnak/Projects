import java.io.*;
import java.util.*;
import java.text.*;

public enum Ruka {
    LEVA, PRAVA
}

public class Postava {

    //PRIVATE PROMENNE PRO TUTO CLASSU
    private String jmeno;
    private int sila;
    private int hbitost;
    private int vitalita;
    private int aktualnizdravi; //pro finalni vypisovani
    private Zbran pravaruka = null; //null ze zakladu kdyz nezadame zbran
    private Zbran levaruka = null; 
    int obrana = 0; //pocatecni obrana je vzdy nulova

    public Postava(String jmeno, int sila, int hbitost, int vitalita) {
        this.jmeno = jmeno;
        this.sila = sila;
        this.hbitost = hbitost;
        this.vitalita = vitalita;
        this.aktualnizdravi = vitalita;
    }

    public boolean vezmiZbran(Ruka ruka, Zbran zbran) {
        if (ruka == Ruka.LEVA && levaruka == null) { //kdyz v leve ruce nema zbran, nastavi ji a vrati true
            levaruka = zbran;
            return true;
        }
        else if (ruka == Ruka.PRAVA && pravaruka == null) { //kdyz v prave ruce nema zbran, nastavi ji a vrati true
            pravaruka = zbran;
            return true;
        }
        else {
            return false;
        }
    }

    public int branSe(int utok) {
        obrana = this.hbitost; //přičteme hbitost do obrany
        if (pravaruka != null) {
            obrana += pravaruka.getObrana(); //kdyz v prave ruce je zbran, pričte obranu
        }
        if (levaruka != null ) {
            obrana += levaruka.getObrana(); //kdyz v leve ruce je zbran, přičte obranu
        }

        int ubranezdravi = utok - obrana; //ubranezdravi podle toho jaky je utok a obrana

        if (ubranezdravi > 0) { //kdyz je utok vetsi nez obrana, tak odecteme od vitality
            this.aktualnizdravi -= ubranezdravi;
        }
        else if (ubranezdravi < 0) { //kdyz je obrana vetsi jak utok, tak ubranezdravi je nula
            ubranezdravi = 0; 
        }
        return ubranezdravi; //vracime kolik jsme ubrali zdravi
    }

    public int zautoc() {
        int utocsila = this.sila; //promenna do ktere si ulozime silu postavy
        if (pravaruka != null) {
            utocsila += pravaruka.getUtok(); //kdyz ma v prave ruce zbran, pricteme silu
        }
        if (levaruka != null) {
            utocsila += levaruka.getUtok(); //kdyz ma v leve ruce zbran, pricteme silu
        }
        return utocsila; //vracime finalni silu
    }

    public boolean jeZiva() {
        if (this.aktualnizdravi > 0) { //kdyz je zdravi vetsi jak 0, zije = return true
            return true;
        }
        else {
            return false;
        }
    }

    public String toString() {
        int celkovautocsila = zautoc();
        int celkovaobransila = this.hbitost;
        if (pravaruka != null) {
            celkovaobransila += pravaruka.getObrana(); //kdyz v prave ruce je zbran, pričte obranu
        }
        if (levaruka != null ) {
            celkovaobransila += levaruka.getObrana(); //kdyz v leve ruce je zbran, přičte obranu
        }
        System.out.println(this.jmeno + " [" + this.aktualnizdravi + "/" + this.vitalita + "] (" + celkovautocsila + "/" celkovaobransila + ")");
    }
}

public class Zbran { 

    private String nazev;
    private int utok;
    private int obrana;

    public Zbran(String nazev, int utok, int obrana) {
        this.nazev = nazev;
        this.utok = utok;
        this.obrana = obrana;
    }

    public int getUtok() {
        return this.utok;
    }

    public int getObrana() {
        return this.obrana;
    }

    public String toString() {
        System.out.println(this.nazev +"(" + this.utok + "/" + this.obrana +")");
    }
}

public class Ppa1u07 {

    Scanner sken = new Scanner(System.in); //Zalozeni noveho scanneru (abychom mohli precist vstup uzivatele)

    public static Postava nactiPostavu(Scanner sc) {
        String jmeno = sc.nextLine();
        int sila = Integer.parseInt(sc.nextLine()); //pouzil bych sc.nextInt, ale v pdf je at pouzijeme tohle, tak pouzivam tohle
        int hbitost = Integer.parseInt(sc.nextLine());
        int vitalita = Integer.parseInt(sc.nextLine());
        return Postava(jmeno, sila, hbitost, vitalita); //vracime vytvorenou postavu podle vstupu
    }

    public static Zbran nactiZbran(Scanner sc) {
        String nazev = sc.nextLine();
        int utok = Integer.parseInt(sc.nextLine()); //tady bych taky pouzil sc.nextInt
        int obrana = Integer.parseInt(sc.nextLine());
        return Zbran(nazev, utok, obrana); //vracime zbran podle vstupu
    }

    public static void vyzbrojPostavu(Postava postava, Zbran leva, Zbran prava) {
        postava.vezmiZbran(Ruka.LEVA, leva); //nastavi zbran podle podminky v metode vezmiZbran
        postava.vezmiZbran(Ruka.PRAVA, prava);
    } 

    public static Postava souboj(Postava postava1, Postava postava2) {
        do {
            postava2.branSe(postava1.zautoc()); //postava 1 zacina utokem na postavu 2
            postava1.branSe(postava2.zautoc()); //postava 2 pokracuje utokem na postavu 1
        } while (postava1.jeZiva() == true && postava2.jeZiva() == true);

        if (postava1.jeZiva() == false) {
            return postava1; //kdyz postava 1 je mrtva, vracime postavu 1
        }
        else {
            return postava2; //obracene kdyz postava 2 je mrtva, vracime postavu 2
        }
    }

    public static void main(String[] args) throws Exception 
    {
        Scanner sken = new Scanner(System.in); //Zalozeni noveho scanneru (abychom mohli precist vstup uzivatele)

        Postava prvnipostava = nactiPostavu(sken);
        vyzbrojPostavu(prvnipostava, NactiZbran(sken), NactiZbran(sken)); //vyzbrojime prvni postavu a nacteme zbran jak pro levou, tak pro pravou ruku
        
        Postava druhapostava = nactiPostavu(sken);
        vyzbrojPostavu(druhapostava, NactiZbran(sken), NactiZbran(sken));

        System.out.println("Vítěz: " + souboj(prvnipostava, druhapostava).ToString());
    }
}