all:plotC.svg

plotC.svg : plotC.gpi outC.txt
	gnuplot plotC.gpi

outC.txt : mainC.exe
	mono $< >$@

mainC.exe : mainC.cs matlib.dll
	mcs $< -reference:matlib.dll


LIBDIR = ../../../matlib
SRC := $(LIBDIR)/matrix

matlib.dll : $(SRC)/matrix.cs $(SRC)/vector.cs ../ODE_ann.cs ../../minimization/minimizer.cs ../../adaptiveIntegration/adaptive_integrator.cs 
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg