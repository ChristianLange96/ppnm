CSC = csc
main.exe : main.cs vector3d.dll
	$(CSC) -reference:$(word 2,$^) $< 
vector3d.dll : vector3d.cs
	$(CSC) -target:library -out:$@ $<
clean:
	rm -f *.dll *.exe out*
