all: PlotB1.svg PlotB2.svg PlotB3.svg OutB4.txt

PlotB1.svg : plotB1.gpi outB1.data
	gnuplot plotB1.gpi

PlotB2.svg : plotB2.gpi outB2.data
	gnuplot plotB2.gpi

PlotB3.svg : plotB3.gpi outB3.data
	gnuplot plotB3.gpi

outB1.data outB2.data outB3.data OutB4.txt : mainB.exe
	mono mainB.exe

mainB.exe : mainB.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../../../matlib
SRC := $(LIBDIR)/matrix

matlib.dll : $(SRC)/matrix.cs $(SRC)/vector.cs ../ODE_integrator.cs
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg