all: outA1.txt plotA2.svg outB.txt

outB.txt : mainB.exe
	mono $< >$@

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



