all:PlotA.svg

PlotA.svg : plotA.gpi outA.txt
	gnuplot plotA.gpi

outA.txt : mainA.exe
	mono $< >$@

mainA.exe : mainA.cs matlib.dll
	mcs $< -reference:matlib.dll


LIBDIR = ../../../matlib
SRC := $(LIBDIR)/matrix

matlib.dll : $(SRC)/matrix.cs $(SRC)/vector.cs ../interpolater_ann.cs ../../minimization/minimizer.cs 
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg