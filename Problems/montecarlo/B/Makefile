all: plotB.svg

plotB.svg : outB.txt plotB.gpi
	gnuplot plotB.gpi


outB.txt : mainB.exe
	mono $< >$@

mainB.exe : mainB.cs matlib.dll
	mcs $< -reference:matlib.dll


LIBDIR = ../../../matlib
SRC := $(LIBDIR)/matrix

matlib.dll : $(SRC)/matrix.cs $(SRC)/vector.cs ../mcintegration.cs 
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg