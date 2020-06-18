all: Eigenvalues.txt Plot_times.svg Plot_comparison.svg

Plot_comparison.svg : plot_comparison.gpi out_times.data
	gnuplot $<

Plot_times.svg : plot_times.gpi out_times.data
	gnuplot $<
	
out_times.data : main_time.exe
	mono $< >$@

Eigenvalues.txt : main_eigen.exe
	mono $< >$@

main_time.exe : main_time.cs matlib.dll
	mcs $< -reference:matlib.dll

main_eigen.exe : main_eigen.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../matlib
SRC := $(LIBDIR)/matrix/matrix.cs
SRC += $(LIBDIR)/matrix/vector.cs 
SRC += ../Problems/eigenvalueDecomposition/jac_diag.cs
SRC += ../Problems/rootFinding/rootFinder.cs
SRC += ../Problems/linearEquations/qr_gs.cs
SRC += symm_rank_one.cs

matlib.dll : $(SRC)
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg *.data *.log