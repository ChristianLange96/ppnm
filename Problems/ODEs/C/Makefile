all: PlotC.svg

PlotC.svg : outC.data plotC.gpi
	gnuplot plotC.gpi

outC.data : mainC.exe
	mono mainC.exe 

mainC.exe : mainC.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../../../matlib
SRC := $(LIBDIR)/matrix

matlib.dll : $(SRC)/matrix.cs $(SRC)/vector.cs ../ODE_integrator.cs
	mcs $^ -target:library -out:$@

clean:
	-$(RM) *.data *.exe *.dll *.svg