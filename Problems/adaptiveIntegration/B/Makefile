OutB.txt : mainB.exe
	mono $< >$@

mainB.exe : mainB.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../../../matlib
SRC := $(LIBDIR)/matrix

matlib.dll : $(SRC)/matrix.cs $(SRC)/vector.cs ../adaptive_integrator.cs $(LIBDIR)/integration/quado8.cs
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll