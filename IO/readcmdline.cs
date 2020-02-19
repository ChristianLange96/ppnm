using System;
public class readcmdline{
	public static int Main(string[] args){
	foreach(var s in args){
		double x = double.Parse(s);
		Console.WriteLine("{0}, {1}, {2}",x,Math.Cos(x), Math.Sin(x));
	}
	return 0;
	}




}
