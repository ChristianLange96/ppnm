all: ms.pdf

ms.pdf : ms.tex out-eulerSpiral.tex
	pdflatex $<
	pdflatex $<

out-eulerSpiral.tex : plot-eulerSpiral.gpi  out-eulerSpiral.txt
	gnuplot $< 


main.exe : main.cs eulerSpiral.cs matlib.dll
	mcs $(word 1,$^) $(word 2,$^) -reference:$(lastword $^)

out-eulerSpiral.txt : main.exe
	mono $< | sed -e 's/,/./g' > $@

LIBDIR = ../matlib
SRC := $(LIBDIR)/matrix/vector.cs
SRC += $(LIBDIR)/integration/quado8.cs

matlib.dll : $(SRC)
	mcs $^ -target:library -out:$@

clean:
	$(RM) *.log *.aux *.pdf *.txt
