CSFLAGS = -warn:2 -optimize-

out.txt : main.exe
	mono $< > $@

main.exe : main.cs cmath.dll
	mcs $(CSFLAGS) -r:cmath.dll -out:$@ $<


cmath.dll : cmath.cs complex.cs
	mcs -target:library -out:cmath.dll cmath.cs complex.cs


clean:
	rm -f out.txt main.exe

