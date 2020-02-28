plot.svg : plot.gpi out.txt
	gnuplot $<

out.txt : main.exe Makefile
	mono $< 2>log | sed -e "s/,/./g" 1>$@

main.exe : main.cs matlib.dll
	mcs -reference:matlib.dll $<

matlib.dll: ../matlib/matrix/vector.cs ../matlib/ode/ode.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.dll *.exe log* out*
