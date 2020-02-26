using System;
using static System.Console;
using static System.Math;
class main{

const double inf = System.Double.PositiveInfinity;
	// Excercise A and B
	static double gamma(double z){

		if (z < 0) return - PI/Sin(PI*z)/gamma(1+z);
		if (z <=1) return gamma(z+1)/z;
		if (z > 2) return gamma(z-1)*(z-1);
		Func<double,double> f = (x) => Pow(x,z-1) * Exp(-x);
	return quad.o8av(f,0,inf, acc:1e-6, eps:0);
	}

	static Func<double,double> A1 = x => (Log(x)/Sqrt(x)); 
	static Func<double,double> A2 = x => Exp(-Pow(x,2));

	static double A3(double p){
		Func<double,double> f = x => Pow(Log(1/x),p);
		return  quad.o8av(f,0,1, acc:1e-6, eps:0);
	}
	static Func<double,double> B1 = x => Pow(x,3)/(Exp(x)-1);

	// Excercise C
	static double psinorm(double a){
		Func<double,double> f = x => Exp(-a/2 * Pow(x,2));
		return quad.o8av(f,-inf,inf, acc:1e-6, eps:0);
	}

	static double psiHpsi(double a){
		Func<double,double> f = x => (-Pow(a*x,2)/2 + a/2 + Pow(x,2)/2)*Exp(-a*Pow(x,2));
		return quad.o8av(f,-inf,inf, acc:1e-6, eps:0);
	}



	static int Main(){
		WriteLine($"Integral of ln(x)/sqrt(x) from 0 to 1 is = {quad.o8av(A1,0,1)}");
		WriteLine($"Integral of Exp(-Pow(x,2)) from -inf to inf is = {quad.o8av(A2,-inf,inf)}, sqrt(pi) = {Sqrt(PI)}");
		for(double x = 0.5; x<9; x += 0.5)
		WriteLine("Integral of Pow((Log(1/x),{0:f2}) from 0 to 1 is = {1:f6}, while gamma({0:f2} + 1) = {2:f6}",x,A3(x),gamma(x+1));
		WriteLine("Integral of Pow(x,3)/(Exp(x)-1) from 0 to inf is = {0:f6}, while Pow(PI,4)/15 = {1:f6}",quad.o8av(B1,0,inf), Pow(PI,4)/15); 

	return 0;
	}
}
