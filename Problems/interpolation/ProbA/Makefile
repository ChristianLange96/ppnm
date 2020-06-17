
all: PlotA.svg

PlotA.svg : plotA.gpi out-xydata.txt out-lsplinedata.txt out-lintegration.txt
	gnuplot $<

out-xydata.txt out-lsplinedata.txt out-lintegration.txt : mainA.exe
	mono  $< >$@

mainA.exe : mainA.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../../../matlib
SRC := $(LIBDIR)/matrix/vector.cs

matlib.dll : $(SRC) linspline.cs
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg