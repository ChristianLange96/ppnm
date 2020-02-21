all: Gamma.svg Errfun.svg

Gamma.svg: gamma.gpi out.gamma.txt out.gamma.test.txt 
	gnuplot $< 

Errfun.svg: errfun.gpi out.errfun.txt errfuntab.txt 
	gnuplot $<

out.errfun.txt: main_errfun.exe Makefile
	mono $< | sed -e 's/,/./g' > $@

main_errfun.exe: main_errfun.cs math.dll
	CSC $< -out:$@ -reference:math.dll

out.gamma.txt: main_gamma.exe Makefile
	mono $< | sed -e 's/,/./g' > $@

out.gamma.test.txt: gamma
	./gamma > $@

main_gamma.exe: main_gamma.cs math.dll
	CSC $< -out:$@ -reference:math.dll

math.dll: gamma.cs errfun.cs
	CSC $^ -target:library -out:$@

.PHONEY: clean
clean:
	rm --force *.dll *.exe out* *.svg

