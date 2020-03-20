
all: PlotB.svg

PlotB.svg : plotB.gpi out-xydata.txt out-qsplinedata.txt out-qintegration.txt out-qderivative.txt
	gnuplot $<

out-xydata.txt out-qsplinedata.txt out-qintegration.txt out-qderivative.txt: mainB.exe
	mono  $< >$@

mainB.exe : mainB.cs matlib.dll
	CSC $< -reference:matlib.dll

LIBDIR = ../../../matlib
SRC := $(LIBDIR)/matrix/vector.cs

matlib.dll : $(SRC) qspline.cs
	CSC $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg
