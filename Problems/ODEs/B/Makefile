all: plotB1.svg plotB2.svg plotB3.svg outB4.txt

plotB1.svg : plotB1.gpi outB1.data
	gnuplot plotB1.gpi

plotB2.svg : plotB2.gpi outB2.data
	gnuplot plotB2.gpi

plotB3.svg : plotB3.gpi outB3.data
	gnuplot plotB3.gpi

outB1.data outB2.data outB3.data outB4.txt : mainB.exe
	mono mainB.exe

mainB.exe : mainB.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../../../matlib
SRC := $(LIBDIR)/matrix

matlib.dll : $(SRC)/matrix.cs $(SRC)/vector.cs ../ODE_integrator.cs
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg