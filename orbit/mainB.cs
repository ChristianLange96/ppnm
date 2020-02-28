using System;
using static System.Math;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
class mainA{
	static int Main(string[] args){

	double N = 6;
	double phia = 0;
	double phib = 2 * N * PI;
	double u0 = 1;
	double eps = 0;
	double udiff0 = 1e-3;

	foreach(string s in args){
		string[] ws=s.Split('=');
		if(ws[0]=="a") phia=double.Parse(ws[1]);
		if(ws[0]=="u0") u0=double.Parse(ws[1]);
		if(ws[0]=="udiff0") udiff0=double.Parse(ws[1]);
		if(ws[0]=="b") phib=double.Parse(ws[1]);
		if(ws[0]=="eps") eps=double.Parse(ws[1]);
		if(ws[0]=="N") N=double.Parse(ws[1]);
	}

	vector ua = new vector(u0,udiff0); // Start vector
	List<double> phis = new List<double>();
	List<vector> us = new List<vector>();

	Func<double,vector,vector> udiff = delegate(double x, vector y){
		var res = new vector(y[1], 1 + eps * Pow(y[0],2) - y[0]);
		return res;
	};

	vector ub = ode.rk23(udiff,phia,ua,phib,phis,us,acc:1e-6, eps:1e-5, h:1e-5, limit: 10000);

	for(int i  = 0; i < phis.Count; i++){
		WriteLine($"{phis[i]} {us[i][0]}");
	}
	return 0;
	}
}
