all: eigenvalues.txt plot_times.svg

plot_times.svg : plot_times.gpi out_times.data
	gnuplot $<
	
out_times.data : main_time.exe
	mono $< >$@

eigenvalues.txt : main_eigen.exe
	mono $< >$@

main_time.exe : main_time.cs matlib.dll
	mcs $< -reference:matlib.dll

main_eigen.exe : main_eigen.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../matlib
SRC := $(LIBDIR)/matrix

matlib.dll : $(SRC)/matrix.cs $(SRC)/vector.cs ../Problems/eigenvalueDecomposition/jac_diag.cs Symm_RankOne.cs ../Problems/rootFinding/rootFinder.cs ../Problems/linearEquations/qr_gs.cs
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg *.data *.log