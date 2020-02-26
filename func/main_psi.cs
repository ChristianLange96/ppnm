using System;
using static System.Console;
using static System.Math;
class main{

const double inf = System.Double.PositiveInfinity;
	// Excercise C
	static double psinorm(double a){
		Func<double,double> f = x => Exp(-a * Pow(x,2));
		return quad.o8av(f,-inf,inf, acc:1e-6, eps:0);
	}

	static double psiHpsi(double a){
		Func<double,double> f = x => (-Pow(a*x,2)/2 + a/2 + Pow(x,2)/2)*Exp(-a*Pow(x,2));
		return quad.o8av(f,-inf,inf, acc:1e-6, eps:0);
	}

	static int Main(){
		for(double a = 0.1; a <=3; a += 0.05)
		WriteLine("{0,10:f6} {1,15:f6}", a, psiHpsi(a)/psinorm(a));
	return 0;
	}
}
