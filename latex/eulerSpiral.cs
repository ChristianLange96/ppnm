using System;
using static System.Math;
static class nonef{
	public static vector euler_spiral(double L){
		int a = 0;
		Func<double,double> Cdiff = (s) => Cos(s*s);
		Func<double,double> Sdiff = (s) => Sin(s*s);
		double x =  quad.o8av(Cdiff,a,L,acc:1e-6, eps:1e-6);
		double y =  quad.o8av(Sdiff,a,L,acc:1e-6, eps:1e-6);
		vector result = new vector(x,y);
	return result;
	}
}
