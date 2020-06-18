all: OutA1.txt PlotA2.svg Energies.txt

PlotA2.svg : outA2.data plotA2.gpi 
	gnuplot plotA2.gpi

mainA2.exe : mainA2.cs matlib.dll
	mcs $< -reference:matlib.dll

outA2.data Energies.txt : mainA2.exe
	mono $< >$@

OutA1.txt : mainA1.exe
	mono $< >$@

mainA1.exe : mainA1.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../../../matlib
SRC := $(LIBDIR)/matrix

matlib.dll : $(SRC)/matrix.cs $(SRC)/vector.cs ../jac_diag.cs
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg *.data



