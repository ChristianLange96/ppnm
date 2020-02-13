using System;
using static System.Math;
public class  main{
	static int Main(string[] args){
		if(args.Length != 2){  // You have to specify exactly 2 arguments; input and output. 
		Console.Error.Write("Not correct number of arguments detected. You need to give 2 arguments:\n The input-file and the outpufile.\n");
		return 1;
		}
		else{
			var infile = new System.IO.StreamReader(args[0]);
			// Creating a new file everytime / overwriting existing one.
			var outfile = new System.IO.StreamWriter(args[1],append:false);
			string s;
			// Ensuring that there is a new line to read. 
			while( (s =  infile.ReadLine()) != null){
				double x = double.Parse(s);
				outfile.WriteLine("x = {0:f3}, cos(x) = {1:f3}", x, Cos(x));
			}
		outfile.Close();
		return 0;
		}
	}
}
