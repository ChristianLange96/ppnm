all: plotC.svg

plotC.svg : outC1.data plotC.gpi
	gnuplot plotC.gpi

outC1.data : mainC.exe
	mono $< >$@

mainC.exe : mainC.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../../../matlib
SRC := $(LIBDIR)/matrix

matlib.dll : $(SRC)/matrix.cs $(SRC)/vector.cs ../rootfinder.cs ../../ODEs/ODE_integrator.cs ../../linearEquations/qr_gs.cs ../B/hydrogen.cs
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg