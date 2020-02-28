using System;
using static System.Math;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
class main{
	static int Main(){
	Func<double,vector,vector> sincos = delegate(double x, vector y) {
		var result = new vector(y[1], -y[0]);
		return result;
		};
		double a = 0;
		vector ya =  new vector(0,1);
		double b = 10;
		List<double> xs = new List<double>();
		List<vector> ys = new List<vector>();
		vector yb = ode.rk23(sincos,a,ya,b,xs,ys);
		for(int i = 0; i < xs.Count; i++)
			WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]}");
	return 0;
	}
}
