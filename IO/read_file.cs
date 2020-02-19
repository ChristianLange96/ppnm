using System;
using System.IO;
class readcmdline{
	static int Main(string[] args) {
	StreamReader inputfile  = new StreamReader(args[0]);
	StreamWriter outputfile = new StreamWriter(args[1], append:false);
	do{
		string s = inputfile.ReadLine();
		if(s == null)  break;
		string [] words = s.Split(' ',',','\t');
		foreach(var word in words){
		double x = double.Parse(word);
		outputfile.WriteLine("{0}, {1}, {2}",x, Math.Cos(x), Math.Sin(x));
		}
	}
	while(true);
	outputfile.Close();
	inputfile.Close();
	return 0;
	}
}
