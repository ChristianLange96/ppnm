all: outA1.txt plotA2.svg plotB1.svg plotB3.svg

plotB3.svg : plotB3.gpi outB3.data
	gnuplot $< >$@

plotB1.svg : plotB1.gpi outB1.data
	gnuplot $< >$@

outB.txt outB1.data outB3.data : mainB.exe
	mono $< >outB.txt

plotA2.svg : outA2.data plotA2.gpi 
	gnuplot plotA2.gpi

mainB.exe : mainB.cs matlib.dll
	mcs $< -reference:matlib.dll

mainA2.exe : mainA2.cs matlib.dll
	mcs $< -reference:matlib.dll

outA2.data eigenenergiesA2.data : mainA2.exe
	mono $< >$@

outA1.txt : mainA1.exe
	mono $< >$@

mainA1.exe : mainA1.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../../matlib
SRC := $(LIBDIR)/matrix

matlib.dll : $(SRC)/matrix.cs $(SRC)/vector.cs jac_diag.cs
	CSC $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg



