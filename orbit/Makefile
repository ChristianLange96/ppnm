all: PlotA.svg PlotB1.svg PlotB2.svg PlotB3.svg



PlotB1.svg : plotB1.gpi out.B1.txt
	gnuplot $<

PlotB2.svg : plotB2.gpi out.B2.txt
	gnuplot $<

PlotB3.svg : plotB3.gpi out.B3.txt
	gnuplot $< 

out.B2.txt : mainB.exe Makefile
	mono $< udiff0=0.5 |sed -e "s/,/./g"  1> $@ 

out.B3.txt : mainB.exe Makefile
	mono $< u0=1 udiff0=0.5 eps=0.03     2>log |sed -e "s/,/./g"  1> $@ 

PlotA.svg: plotA.gpi out.A.txt
	gnuplot $<

out.B1.txt: mainB.exe Makefile
	mono $<  2>log | sed -e "s/,/./g" 1> $@

mainB.exe : mainB.cs matlib.dll
	mcs $< -reference:matlib.dll $<

out.A.txt : mainA.exe Makefile
	mono $< 2>log | sed -e "s/,/./g" 1>$@

mainA.exe : mainA.cs matlib.dll
	mcs -reference:matlib.dll $<

matlib.dll: ../matlib/matrix/vector.cs ../matlib/ode/ode.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.dll *.exe log* out* *.svg
