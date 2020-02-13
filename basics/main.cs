using static System.Console;
using static System.Math;
class main{
	string s = "Old String \n";
	static int Main(){
		double x = 1.23;
		int nmax = 100; 
		string s = "Hello\n";
		Write(s);
		int two = 2;
		int one = 1;
		if(two > one) {Write("2>1 \n");}
		else {Write("2!>1 \n");}
		
		int i = 0;		
		for(i = 0; i<10; i++){
			Write(" i = {0} \n",i);	
		}
		i = 0;
		while(i<10){Write("While loop: i = {0}\n", i);
		i++;}
		Write("pi = {0:f2} \n",PI);

		double[] v = new double[10];
		for(i = 0; i < 10; i++) {v[i] = Sin(i);}
		for(i = 0; i < 10; i++) {Write($"v[{i}] = {v[i]}\n");}
		System.Array.Resize(ref v, v.Length +1);
		Write($"v.Length = {v.Length}\n");	
	




	return 0;
	}
}



