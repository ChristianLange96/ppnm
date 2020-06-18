all: Plot_O3Dependence.svg PlotComparisonLowest.svg PlotComparisonAll.svg PlotTimeComparisonAll.svg Out_eigen.txt

PlotTimeComparisonAll.svg : PlotTimeComparisonAll.gpi outB_rotations.data outB_rotations_all.data
	gnuplot $< >$@

PlotComparisonAll.svg : plotComparisonAll.gpi outB_rotations.data
	gnuplot $< >$@

PlotComparisonLowest.svg : plotComparisonLowest.gpi outB_rotations.data
	gnuplot $< >$@

Plot_O3Dependence.svg : plotB1.gpi outB1.data
	gnuplot $< >$@

Out_eigen.txt outB1.data outB_rotations.data outB_rotations_all.data : mainB.exe 
	mono $< >Out_eigen.txt

mainB.exe : mainB.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../../../matlib
SRC := $(LIBDIR)/matrix

matlib.dll : $(SRC)/matrix.cs $(SRC)/vector.cs ../jac_diag.cs
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg *.data



