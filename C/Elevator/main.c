#include <stdio.h>
#include <sys/io.h>
#include <time.h>

int dolu = 232;
int nahoru = 242;

int prava() {
	if (ioperm(0x300,2,1)!= 0) {
		return 0;
	}
	else {
		return 1ů
	}
}
void zvuk() {
	struct timespec t;
	t.tv_sec = 0;
	t.tv_nsec = 10000000;
	outb(223, 0x300);
	nanosleep(&t, NULL);
}

int kontrolabitu(int hodnota, int bit) {
	int maska = (1 << bit);
	int vysledek = (hodnota & maska);
	if (vysledek == 0) {
		return 0;
	}
	else {
		return 1;
	}
}

void segment(int cislo) {
	switch(cislo) {
		case 0:
			outb(252 ,0x301);
			break;
		case 1:
			outb(250 ,0x301);
			break;
		case 2:
			outb(254 ,0x301);
			break;
		case 3:
			outb(249 ,0x301);
			break;
	}
}

void nastavenisegmentu() {
	int stavP4 = inb(0x301);
	for (int i = 0; i < 4; i++) {
		if (kontrolabitu(stavP4, i) == 0) {
			segment(i);
		}
	}
}

int kontroladveri() {
	int stavP4 = inb(0x301);{
	if (kontrolabitu(stavP4, 4) == 0) {
		return 1;
	}
	return 0;
}

int patro() {
	int stavP4 = inb(0x301);
	for (int i = 0; i < 4; i++) {
		if (kontrolabitu(stavP4, i) == 0) {
			return i;
		}
	}
}

int zvolenepatro() {
	int stavP3 = inb(0x300);
	for (int i = 0; i < 4; i++) {
		if (kontrolabitu(stavP3, i) == 0) {
			return i + 1;
		}
	}
	for (int i = 4; i < 8; i++) {
		if (kontrolabitu(stavP3, i) == 0) {
			return i - 3;
		}
	}
	return 0;
}

void vychozipozice() {
	while(kontrolabitu(inb(0x301), 0) != 0) {
		outb(dolu, 0x300);
	}
	zvuk();
	outb(255, 0x300);
	nastavenisegmentu();
}

void nastaveniportu() {
	outb(255, 0x300);
	outb(255, 0x301);
}

void posun(int kam, int patro) {
	while (kontrolabitu(inb(0x301), patro) != 0) {
		if (kontroladveri() == 0) {
			printf("jsou otevrene dvere\n");
			outb(255, 0x300);
		}
		else {
			nastavenisegmentu();
			printf("vytah jede\n");
			outb(kam, 0x300);
		}
		nastavenisegmentu();
		zvuk();
		outb(255, 0x300);
	}
}

int main() {
	if (prava() == 0) {
		return 0;
	}
	else {
		nastaveniportu();
		vychozipozice();
		while (1) {
			int zvolen = zvolenepatro();
			if (zvolen == 0) {
				printf("zvolte patro\n");
			}
			else {
				int pravda = zvolen - 1;
				if (pravda > patro()) {
					posun(nahoru, pravda);
				}
				else if (pravda < patro()) {
					posun(dolu, pravda);
				}
				else {
					outb(255, 0x300);
				}
			}
		}
		
		return 1;
	}
}