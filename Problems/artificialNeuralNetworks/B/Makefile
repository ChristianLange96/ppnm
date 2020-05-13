all:plotB.svg

plotB.svg : plotB.gpi outB.txt
	gnuplot plotB.gpi

outB.txt : mainB.exe
	mono $< >$@

mainB.exe : mainB.cs matlib.dll
	mcs $< -reference:matlib.dll


LIBDIR = ../../../matlib
SRC := $(LIBDIR)/matrix

matlib.dll : $(SRC)/matrix.cs $(SRC)/vector.cs ../interpolater_ann.cs ../../minimization/minimizer.cs 
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg