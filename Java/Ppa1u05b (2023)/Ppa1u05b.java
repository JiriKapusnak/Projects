import java.util.Scanner;

public class Ppa1u05b {
    public static void main(String[] args) {
        //  pomocne promenne
        int c; //strana c
        int delitel = 2; //delitel, kterym budeme delit strany a,b, zacina na dvojce jako nejnizsi cislo kterym muzeme delit 
        int a; //strana a
        int b; //strana b
        boolean reseni = true;

        //  naskenovani strany c
        Scanner sken = new Scanner(System.in);
        c = sken.nextInt();
        sken.close();

        //  zjisteni stran a,b a zda reseni existuje/neexistuje
        for (a = 1; a < c; a++) { //cyklus kde se vyzkousi kazde a ktere je mensi nez c
            for (b = 1; b < c; b++) { //cyklus kde se vyzkousi kazde b ktere je mensi nez c
                if ((Math.pow(a, 2) + Math.pow(b, 2) == Math.pow(c, 2))) { //podminka, ktera u kazdeho b zkontroluje zda a^2 + b^2 = c^2
                    if (a < b) { //druha podminka, aby a bylo mensi nez b
                        for (delitel = 2; delitel < c; delitel++) { //cyklus ktery vyzkousi kazdy delitel mensi nez c
                            if (a % delitel == 0 && b % delitel == 0 && c % delitel == 0) { //treti podminka, jestli se najde delitel, ktery podeli vsechny cisla beze zbytku
                                reseni = false;
                            }
                        }

                        if (reseni == true) {
                            System.out.println(a + "^2 + " + b + "^2 = " + c + "^2");
                            return; //ukonceni programu
                        }

                    }
                }
            }
        }
        if (reseni == false) {
            System.out.println("Reseni neexistuje");
        }
    }
}