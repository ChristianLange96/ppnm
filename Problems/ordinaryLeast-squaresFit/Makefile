all: plotA.svg

plotA.svg : plotA.gpi outFitData.txt
	gnuplot plotA.gpi

outFitData.txt : main.exe
	mono $< >$@

main.exe : main.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../../matlib
SRC := $(LIBDIR)/matrix

matlib.dll : $(SRC)/matrix.cs $(SRC)/vector.cs ../linearEquations/qr_gs.cs ols_fitter.cs
	CSC $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg