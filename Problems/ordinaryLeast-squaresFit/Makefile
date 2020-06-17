all: plotA.svg B.txt plotC.svg

plotC.svg : plotC.gpi outFitData.txt outData.txt
	gnuplot plotC.gpi

plotA.svg : plotA.gpi outFitData.txt outData.txt
	gnuplot plotA.gpi

outFitData.txt outData B.txt: main.exe
	mono $< >$@

main.exe : main.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../../matlib
SRC := $(LIBDIR)/matrix

matlib.dll : $(SRC)/matrix.cs $(SRC)/vector.cs ../linearEquations/qr_gs.cs ols_fitter.cs
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg