import static org.junit.Assert.*;

import java.util.Random;

import org.junit.Test;

import ppa1.Postava;
import ppa1.Zbran;

public class ZbranTest {
	Random rand = new Random();
	
	public static void assertZbran(String zprava, Zbran zbran, String nazev, int utok, int obrana) {
		String text = String.format("%s (%d/%d)", nazev, utok, obrana);		
		assertTrue(zprava, zbran.toString().equals(text));			
	}

	
	@Test
	public void Zbran() {
		int obrana = rand.nextInt(100);
		int utok = rand.nextInt(100);
		
		Zbran zbran = new Zbran("Zbran", utok, obrana);
		
		assertEquals("Vytvorena zbran ma jinou obranu, nez s jakou byla vytvorena.", obrana, zbran.getObrana());
		assertEquals("Vytvorena zbran ma jiny utok, nez s jakym byla vytvorena.", utok, zbran.getUtok());
		assertZbran("Vytvorena zbran se lisi od zadani", zbran, "Zbran", utok, obrana);
	}

}

