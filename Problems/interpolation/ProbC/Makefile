plotC.svg : out-xy.data out-cspline.data out-cintegration.data out-cderivative.data plotC.gpi out-plotUtils.data
	gnuplot plotC.gpi


out-xy.data out-cspline.data out-cintegration.data out-cderivative.data: mainC.exe
	mono  $< >$@

out-plotUtils.data : out-xy.data
	spline $< >$@

mainC.exe : mainC.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../../../matlib
SRC := $(LIBDIR)/matrix/vector.cs

matlib.dll : $(SRC) cspline.cs
	mcs $^ -target:library -out:$@

clean:
	-$(RM) .*data out* *.txt *.exe *.dll *.svg
