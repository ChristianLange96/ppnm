all: outA.txt outB.txt outC.txt

outC.txt : mainC.exe
	mono $< >$@

outB.txt : mainB.exe
	mono $< >$@

outA.txt : mainA.exe
	mono $< >$@

mainC.exe : mainC.cs matlib.dll
	mcs $< -reference:matlib.dll

mainB.exe : mainB.cs matlib.dll
	mcs $< -reference:matlib.dll

mainA.exe : mainA.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../../matlib
SRC := $(LIBDIR)/matrix

matlib.dll : $(SRC)/matrix.cs $(SRC)/vector.cs adaptive_integrator.cs ../../matlib/integration/quado8.cs
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll *.svg