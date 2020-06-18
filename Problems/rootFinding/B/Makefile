all: PlotB.svg

PlotB.svg : outB.data plotB.gpi
	gnuplot plotB.gpi

outB.data : mainB.exe
	mono $< >$@

mainB.exe : mainB.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../../../matlib
SRC := $(LIBDIR)/matrix

matlib.dll : $(SRC)/matrix.cs $(SRC)/vector.cs ../rootfinder.cs ../../ODEs/ODE_integrator.cs ../../linearEquations/qr_gs.cs hydrogen.cs
	mcs $^ -target:library -out:$@

clean:
	-$(RM) *.data *.txt *.exe *.dll *.svg