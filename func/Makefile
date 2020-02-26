CSC = csc

Psi.svg : psi.gpi out.psi.txt
	gnuplot $<

out.psi.txt : main_psi.exe Makefile
	mono $< | sed -e 's/,/./g' > $@

main_psi.exe : main_psi.cs matlib.dll
	$(CSC) $< -reference:matlib.dll

out.txt : main.exe
	mono $< > out.txt

main.exe : main.cs matlib.dll
	$(CSC) $< -reference:matlib.dll

LIBDIR = ../matlib
SRC = $(LIBDIR)/integration/quado8.cs
SRC += $(LIBDIR)/integration/quado4.cs
matlib.dll : $(SRC)
	$(CSC) $^ -target:library -out:$@

clean:
	rm -f *.dll *.exe out*

