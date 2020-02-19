all: outcmdline.txt outstdin.txt

outcmdline.txt : readcmdline.exe
	mono readcmdline.exe 1 2 3 4 5 > $@

readcmdline.exe : readcmdline.cs
	CSC $< -out:$@

outstdin.txt : readstdin.exe input.txt
	mono $< < $(word 2,$^) > $@

readstdin.exe : readstdin.cs
	CSC $< -out:$@

input.txt: Makefile
	echo '0.5\n2.5\n3.5' > $@

clean:
	$(RM) *.exe out*
