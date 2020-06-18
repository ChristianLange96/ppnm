all: OutAB.txt

OutAB.txt : main.exe
	mono $< >$@

main.exe : main.cs matlib.dll qr_gs.cs 
	mcs $< -reference:matlib.dll

LIBDIR = ../../matlib
SRC := $(LIBDIR)/matrix

matlib.dll : $(SRC)/matrix.cs $(SRC)/vector.cs qr_gs.cs
	mcs $^ -target:library -out:$@

clean:
	-$(RM) out* *.txt *.exe *.dll