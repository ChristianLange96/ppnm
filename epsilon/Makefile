CSFLAGS = -warn:2 -optimize-

out.txt : main.exe
	mono $< > $@

main.exe : main.cs approx.dll
	mcs $(CSFLAGS) -r:approx.dll -out:$@ $<

approx.dll : approx.cs
	mcs $(CSFLAGS) $< -target:library -out:$@ $<

clean:
	rm -f out.txt main.exe

