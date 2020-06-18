all: OutA.txt

OutA.txt : mainA.exe
	mono $< >$@

mainA.exe : mainA.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../../../matlib
SRC := $(LIBDIR)/matrix

matlib.dll : $(SRC)/matrix.cs $(SRC)/vector.cs ../minimizer.cs 
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll