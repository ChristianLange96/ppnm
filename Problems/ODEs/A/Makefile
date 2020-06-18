all: PlotA.svg

PlotA.svg : plotA.gpi outA.data
	gnuplot plotA.gpi

outA.data : mainA.exe
	mono $< 

mainA.exe : mainA.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../../../matlib
SRC := $(LIBDIR)/matrix

matlib.dll : $(SRC)/matrix.cs $(SRC)/vector.cs ../ODE_integrator.cs
	CSC $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg