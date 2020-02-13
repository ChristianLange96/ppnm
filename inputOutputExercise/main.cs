using System;
using static System.Math;
public class  main{
	static int Main(string[] args){
		if(args.Length == 0) {
			Console.Error.Write("There was no argument.\n");
			return 1;
			}
		else {
			for(int i = 0; i<args.Length; i++){
				double x = double.Parse(args[i]);
				Console.Write("x = {0}, cos({0}) = {1}\n",x, Cos(x));
			}
			return 0;
			}
	}
}
