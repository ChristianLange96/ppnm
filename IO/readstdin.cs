using System;
class readcmdline{
	static int Main() {
	do{
		string s = Console.ReadLine();
		if(s == null)  break;
		string [] words = s.Split(' ',',','\t');
		foreach(var word in words){
		double x = double.Parse(word);
		Console.WriteLine("{0}, {1}, {2}",x, Math.Cos(x), Math.Sin(x));
		}
	}
	while(true);
	return 0;
	}
}
