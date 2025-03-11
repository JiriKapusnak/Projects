import static org.junit.Assert.*;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import java.io.PrintStream;
import java.util.Locale;
import java.util.Random;
import java.util.Scanner;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;

import ppa1.Postava;
import ppa1.Ppa1u07;
import ppa1.Zbran;

public class Ppa1u07Test {


	/**
	 * Testuje spravnou funci mainu
	 */
	@Test
	public void main() {		
		try {
			
			/* Vstup:
			 * Pat
			 * 1
			 * 1
			 * 1
			 * 
			 * 
			 * Mat
			 * 0
			 * 0
			 * 1
			 * Kladivko
			 * 1
			 * 0
			 * Hrebik
			 * 1
			 * 1
			 * 
			 */

			Ppa1u07.main(null);
			
			System.setIn(save_in);			
		} catch (Exception e) {
			assertTrue(String.format("Pri testu se vyskytla vyjimka %s. Pricinou muze byt chybne nacitani z klavesnice. Pouzivejte metodu nextLine()", e.getMessage()),true);
		}
				
		String actual = redir_out.toString().trim().toLowerCase().replaceAll("\\s+"," ");
		assertTrue("Pri souboji Pat bez kladiva vs Mat s kladivem mel vyhrat mat", actual.contains("vitez: mat"));		
		assertFalse("Pri souboji Pat bez kladiva vs Mat s kladivem mel vyhrat mat", actual.contains("vitez: pat"));		
	}

	/**
	 * Test metody nactiPostavu. Opravdu se cte z predaneho Scanneru? 
	 */
	@Test
	public void nactiPostavu() {
		Random rand = new Random();
		int sila = rand.nextInt(50)+1;
		int hbitost = rand.nextInt(50)+1;
		int vitalita = rand.nextInt(50)+1;				
		String jmeno = "nactiPostavu";
		String input = String.format(Locale.US,"%s\n%d\n%d\n%d",jmeno,sila,hbitost,vitalita);
		Scanner sc = new Scanner(input);

		try {
			Postava postava = Ppa1u07.nactiPostavu(sc);
			PostavaTest.assertPostava("Nactena postava tvrdi, ze ma jine vlastnosti, nez by mela mit.", postava, jmeno, vitalita, vitalita, sila, hbitost);
		} catch (Exception e) {
			assertTrue("Nacteni postavy se nepovedlo, opravdu ctete z predaneho Scanneru?", false);
		}
	}
	
	
	/**
	 * Test metody nactiZbran. 
	 */
	@Test
	public void nactiZbran() {
		Random rand = new Random();
		int obrana = rand.nextInt(50)+1;
		int utok = rand.nextInt(50)+1;
		String nazev = "nactiZbran";

		try {
			String input = String.format(Locale.US,"%s\n%d\n%d",nazev,utok,obrana);
			Scanner sc = new Scanner(input);
			Zbran zbran = Ppa1u07.nactiZbran(sc);
			ZbranTest.assertZbran("Nactena zbran tvrdi, ze ma jine vlastnosti, nez by mela mit.", zbran, nazev, utok, obrana);

			input = String.format(Locale.US,"\n");
			sc = new Scanner(input);
			zbran = Ppa1u07.nactiZbran(sc);
			assertTrue("Nemela se nacist zadna zbran", zbran==null);			
		} catch (Exception e) {
			assertTrue("Nacteni zbrane se nepovedlo, opravdu ctete z predaneho Scanneru?", false);
		}
		
	}
	
	/**
	 * Testuje, zda se postava spravne vyzbrojila 
	 */
	@Test
	public void vyzbrojPostavu() {
		Random rand = new Random();
		int sila = rand.nextInt(50)+1;
		int levyUtok = rand.nextInt(50)+1;
		int pravyUtok = rand.nextInt(50)+1;
		int hbitost = rand.nextInt(50)+1;
		int levaObrana = rand.nextInt(50)+1;
		int pravaObrana = rand.nextInt(50)+1;	
		int vitalita = rand.nextInt(50)+1;
				
		String jmeno = "vyzbrojPostavu";
		Postava postava = new Postava(jmeno,sila,hbitost,vitalita);
		Zbran leva = new Zbran("Leva",levyUtok,levaObrana);
		Zbran prava = new Zbran("Prava",pravyUtok,pravaObrana);
		
		Ppa1u07.vyzbrojPostavu(postava, null, prava);
		PostavaTest.assertPostava("Vyzbrojeni postavy se nepovedlo, cekal jsem jiny utok.", 
				postava, jmeno, vitalita, vitalita, sila+pravyUtok, hbitost+pravaObrana);
		
		Ppa1u07.vyzbrojPostavu(postava, leva, null);
		PostavaTest.assertPostava("Vyzbrojeni postavy se nepovedlo, cekal jsem jiny utok.", 
				postava, jmeno, vitalita, vitalita, sila+pravyUtok+levyUtok, hbitost+pravaObrana+levaObrana);
	}

	@Test
	/**
	 * Testuje, zda souboj probehl spravne
	 */
	public void souboj() {
		Postava p1 = new Postava("Golias",3,0,10);
		Postava p2 = new Postava("David",1,1,20); 
		String p1t = p1.toString();
		String p2t = p2.toString();
				
		Postava result = Ppa1u07.souboj(p1, p2);
		assertEquals(String.format("%s zautocil na %s a mel vyhrat", p1t,p2t), p1, result);
		
		p1 = new Postava("Golias",3,0,10);
		p2 = new Postava("David",1,1,20); 				
		p1t = p1.toString();
		p2t = p2.toString();
		result = Ppa1u07.souboj(p2, p1);
		assertEquals(String.format("%s zautocil na %s a mel vyhrat", p2t,p1t), p2, result);		
	}
	
	private final ByteArrayOutputStream redir_out = new ByteArrayOutputStream();
	private PrintStream save_out;
	private static InputStream save_in;

	/**
	 * Presmerovani stdin
	 */
	@BeforeClass
	public static void setInRedirect() {
		save_in = System.in;
		String input = String.format(Locale.US,"Pat\n1\n1\n1\n\n\nMat\n0\n0\n1\nKladivo\n1\n0\nHrebik\n1\n1");
		System.setIn(new ByteArrayInputStream(input.getBytes()));		
	}
	
	/**
	 * Obnoveni stdin
	 */
	@AfterClass
	public static void resetInRedirect() {
		System.setIn(save_in);
	}
	
	
	/**
	 * Presmerovani stdout do byte streamu
	 */
	@Before
	public void setRedirect() {
		save_out = System.out;
		System.setOut(new PrintStream(redir_out));
	}

	/**
	 * Obnoveni stdout
	 */
	@After
	public void resetRedirect() {
		System.setOut(save_out);
	}

}

