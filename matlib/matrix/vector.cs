// (C) 2020 Dmitri Fedorov; License: GNU GPL v3+; no warranty.
using System;
using static System.Math;
public partial class vector{

private double[] data;
public int size{ get{return data.Length;} }

public double this[int i]{
	get{return data[i];}
	set{data[i]=value;}
}

public vector(int n){data=new double[n];}
public vector(double[] a){data=a;}
public vector(double a, double b)
	{ data = new double[]{a,b}; }

public vector(double a){data = new double[] {a};}

public vector(double a, double b, double c)
	{ data = new double[]{a,b,c}; }
public vector(double a, double b, double c, double d)
	{ data = new double[]{a,b,c,d}; }
public vector(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k, double l)
	{ data = new double[]{a,b,c,d,e,f,g,h,i,j,k,l}; }

public static implicit operator vector (double[] a){ return new vector(a); }
public static implicit operator double[] (vector v){ return v.data; }

public void eprint(string s=""){ // For debugging
	System.Console.Error.Write(s);
	for(int i=0;i<size;i++) System.Console.Error.Write("{0:f3} ",this[i]);
	System.Console.Error.Write("\n");
}

public void print(string s=""){
	System.Console.Write(s);
	for(int i=0;i<size;i++) System.Console.Write("{0:f3} ",this[i]);
	System.Console.Write("\n");
}

public void print(int n, string s=""){		// Only prints n first values
	System.Console.Write(s);
	for(int i=0;i<n;i++) System.Console.Write("{0:f3} ",this[i]);
	System.Console.Write("\n");
}


public static vector operator+(vector v, vector u){
	vector r=new vector(v.size);
	for(int i=0;i<r.size;i++)r[i]=v[i]+u[i];
	return r; }

public static vector operator-(vector v, vector u){
	vector r=new vector(v.size);
	for(int i=0;i<r.size;i++)r[i]=v[i]-u[i];
	return r; }

public static vector operator*(vector v, double a){
	vector r=new vector(v.size);
	for(int i=0;i<v.size;i++)r[i]=a*v[i];
	return r; }

public static vector operator*(double a, vector v){
	return v*a; }

public static vector operator/(vector v, double a){
	vector r=new vector(v.size);
	for(int i=0;i<v.size;i++)r[i]=v[i]/a;
	return r; }

public double dot(vector o){
	double sum=0;
	for(int i=0;i<size;i++)sum+=this[i]*o[i];
	return sum;
	}

public double norm(){
	double meanabs=0;
	for(int i=0;i<size;i++)meanabs+=Abs(this[i]);
	if(meanabs==0)meanabs=1;
	meanabs/=size;
	double sum=0;
	for(int i=0;i<size;i++)sum+=(this[i]/meanabs)*(this[i]/meanabs);
	return meanabs*Sqrt(sum);
	}

public vector copy(){
	vector b=new vector(this.size);
	for(int i=0;i<this.size;i++)b[i]=this[i];
	return b;
}

public static bool approx(double x, double y, double acc=1e-9, double eps=1e-9){
	if(Abs(x-y)<acc)return true;
	if(Abs(x-y)/Max(Abs(x),Abs(y))<eps)return true;
	return false;
	}

public bool approx(vector o){
	for(int i=0;i<size;i++)
		if(!approx(this[i],o[i]))return false;
	return true;
	}

public static double max(vector v){
    double max = v[0];
    for(int i=1;i<v.size;i++){
        if (v[i]>max)
            max = v[i];
    }
    return max; 
}

public static double min(vector v){
    double min = v[0];
    for(int i=1;i<v.size;i++){
        if (v[i]< min)
            min = v[i];
    }
    return min; 
}


public static vector abs(vector v){
    vector r = new vector(v.size);
    for(int i=0;i<v.size;i++)r[i]=Abs(v[i]);
    return r; 
}


}//vector
