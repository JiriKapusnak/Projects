import static org.junit.Assert.*;

import java.util.Random;

import org.junit.Before;
import org.junit.Test;

import ppa1.Zbran;
import ppa1.Postava;
import ppa1.Ruka;

public class PostavaTest {
	Random rand = new Random();

	int sila;
	int levyUtok;
	int pravyUtok;
	int hbitost;
	int levaObrana;
	int pravaObrana;
	int vitalita;
	
	
	@Before
	public void nahodneVlastnosti() {
		sila = rand.nextInt(50)+1;
		levyUtok = rand.nextInt(50)+1;
		pravyUtok = rand.nextInt(50)+1;
		hbitost = rand.nextInt(50)+1;
		levaObrana = rand.nextInt(50)+1;
		pravaObrana = rand.nextInt(50)+1;	
		vitalita = rand.nextInt(50)+1;
	}
		
	public static void assertPostava(String zprava, Postava postava, String jmeno, int zdravi, int vitalita, int utok, int obrana) {
		String text = String.format("%s [%d/%d] (%d/%d)", jmeno, zdravi, vitalita, utok, obrana);		
		assertTrue(zprava, postava.toString().equals(text));			
	}
	
	/**
	 * Testuje vytvoreni postavy a ziskani zakladnich informaci
	 * - getUtok
	 * - getObrana
	 * - getZdravi
	 * - toString
	 */
	@Test
	public void Postava() {
		String jmeno = "Postava";
		String text = String.format("%s [%d/%d] (%d/%d)", jmeno, vitalita, vitalita, sila, hbitost);
		
		Postava postava = new Postava(jmeno, sila, hbitost, vitalita);
		assertPostava("Postava o sobe nepodava spravne informace.", postava, jmeno, vitalita, vitalita, sila, hbitost);
	}
	
	/**
	 * Otestuje, zda si postava umi vzit zbran
	 */
	@Test
	public void vezmiZbran() {
		Postava postava;
		String jmeno = "vezmiZbran";
		String text;

		Zbran leva = new Zbran("LEVA", levyUtok, levaObrana);
		Zbran prava = new Zbran("PRAVA", pravyUtok, pravaObrana);

		postava = new Postava(jmeno, sila, hbitost, 0);
		// pridani zbrane do leve ruky
		assertTrue("Postava tvrdi, ze si nemuze vzit zbran do prazdne leve ruky", postava.vezmiZbran(Ruka.LEVA, leva));
		assertPostava("Postava o sobe nepodava spravne informace", postava, jmeno, 0, 0, sila+levyUtok, hbitost+levaObrana);
		
		// opakovane pridani zbrane do leve ruky
		assertFalse("Postava tvrdi, ze si muze vzit zbran do plne leve ruky", postava.vezmiZbran(Ruka.LEVA, prava));
		assertPostava("Postava o sobe nepodava spravne informace", postava, jmeno, 0, 0, sila+levyUtok, hbitost+levaObrana);
		
		// pridani zbrane do prave ruky, kdyz v leve neco drzi
		assertTrue("Postava tvrdi, ze si nemuze vzit zbran do prazdne prave ruky", postava.vezmiZbran(Ruka.PRAVA, prava));	
		assertPostava("Postava o sobe nepodava spravne informace", postava, jmeno, 0, 0, sila+levyUtok+pravyUtok, hbitost+levaObrana+pravaObrana);
				
		postava = new Postava("vezmiZbran", sila, hbitost, 0);
		// pridani zbrane do prave ruky
		assertTrue("Postava tvrdi, ze si nemuze vzit zbran do prazdne prave ruky", postava.vezmiZbran(Ruka.PRAVA, prava));
		assertPostava("Postava o sobe nepodava spravne informace", postava, jmeno, 0, 0, sila+pravyUtok, hbitost+pravaObrana);
		
		// opakovane pridani zbrane do prave ruky
		assertFalse("Postava tvrdi, ze si muze vzit zbran do plne prave ruky", postava.vezmiZbran(Ruka.PRAVA, prava));
		
		// pridani zbrane do leve ruky, kdyz v prave neco drzi
		assertTrue("Postava tvrdi, ze si nemuze vzit zbran do prazdne leve ruky", postava.vezmiZbran(Ruka.LEVA, prava));
	}

	/**
	 * Testuje, zda se umi postava spravne branit
	 */
	@Test
	public void branSe() {
		Postava postava;
		String text;
		String jmeno = "branSe";
		int utok = rand.nextInt(10)+1;
		
		Zbran leva = new Zbran("LEVA", 0, levaObrana);
		Zbran prava = new Zbran("PRAVA", 0, pravaObrana);
		
		postava = new Postava("branSe", 0, hbitost, vitalita);
		postava.vezmiZbran(Ruka.PRAVA, prava);
		postava.vezmiZbran(Ruka.LEVA, leva);

		// utok mensi nez obrana
		assertTrue("Postava tvrdi, ze utrpela zraneni, i kdyz je utok mensi nez obrana", 0==postava.branSe(hbitost+levaObrana+pravaObrana-1));
		assertPostava("Postava o sobe nepodava spravne informace", postava, jmeno, vitalita, vitalita, 0, hbitost+pravaObrana+levaObrana);
		
		// utok stejny jako obrana
		assertTrue("Postava tvrdi, ze utrpela zraneni, i kdyz je utok stejny jako obrana", 0==postava.branSe(hbitost+levaObrana+pravaObrana));
		assertPostava("Postava o sobe nepodava spravne informace", postava, jmeno, vitalita, vitalita, 0, hbitost+pravaObrana+levaObrana);

		// utok vetsi nez obrana
		assertTrue("Postava tvrdi, ze utrpela jine zraneni, nez mela", utok==postava.branSe(hbitost+levaObrana+pravaObrana+utok));
		assertPostava("Postava o sobe nepodava spravne informace", postava, jmeno, vitalita-utok, vitalita, 0, hbitost+pravaObrana+levaObrana);
	}
	
	/**
	 * Testuje, zda umi spravne zautocit
	 */	
	@Test
	public void zautoc() {
		String jmeno = "zautoc";
		Postava postava;
		
		Zbran leva = new Zbran("LEVA", levyUtok, 0);
		Zbran prava = new Zbran("PRAVA", pravyUtok, 0);
		
		postava = new Postava(jmeno, sila, 0, 0);
		postava.vezmiZbran(Ruka.LEVA, leva);
		postava.vezmiZbran(Ruka.PRAVA, prava);
		
		assertTrue("Postava tvrdi, ze utoci jinou silou, nez jaky je jeji utok.", sila+levyUtok+pravyUtok == postava.zautoc());		
		assertPostava("Postava o sobe nepodava spravne informace", postava, jmeno,  0, 0, sila+levyUtok+pravyUtok, 0);
	}	
	
	@Test
	public void jeZiva() {
		String jmeno = "jeZiva";
		Postava postava;
		
		postava = new Postava(jmeno, 0, 0, vitalita);
		assertTrue("Postava zemrela pri narozeni", postava.jeZiva());
		
		postava.branSe(vitalita);
		assertFalse("Postava nezemrela pri brutalnim utoku", postava.jeZiva());
		
	}
}

