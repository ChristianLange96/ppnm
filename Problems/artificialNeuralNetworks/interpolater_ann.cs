using System; 
using static System.Console; 
using static System.Math;
using System.Collections.Generic;
using static vector;
using static minimizer;

public partial class interpolater_ann {
    Func<double,double> f;
    Func<double,double> fm;
    Func<double,double> fmm;
    Func<double,double> fi;
    int n;
    vector p;
    Random rand = new Random();
    int ncalls;
    
    private void init (int n){
    ncalls = 0;
    f = (x) =>  x * Exp(-x * x);    // Activation function
    fm = (x) => Exp(-x * x) - 2 * x * x * Exp(-x * x);  // Deriv og f
    fmm = (x) => - 2 * x * Exp(-x * x) -4 * x * Exp(-x * x) + 4 * x * x * x * Exp(-x * x); // Double deriv of f
    fi = (x) => -Exp(-x * x)/2;    // Integral of f
    p = new vector(3 * n);
    }

    public interpolater_ann(int m){
        init(m);
        n = m;        
        for(int i = 0; i < 3 * n; i++){
            // Creating random numbers from normal distribution - found online
            double u1 = 1.0 - rand.NextDouble(); 
            double u2 = 1.0 - rand.NextDouble();
            p[i] = Math.Sqrt(-2.0 * Math.Log(u1))* Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
        }
        //p.eprint("p initialized to: ");
    }
	public double feedforward(double x){
        double y = 0;
        for(int i = 0; i < n; i++){
            double ai = p[3 * i + 0];
            double bi = p[3 * i + 1];
            double wi = p[3 * i + 2];
            y += wi * f((x-ai)/bi);
        }
        //Error.WriteLine($"Feedfoward has been called");
        return y;
    }
   
    public void train(vector x,vector y){
        double res1 = 0;
        Func<vector,double> delta_p =  (k) => {
            p = k;
            double res = 0;
            for(int i = 0; i < x.size; i++){
                res += Pow((feedforward(x[i]) - y[i]), 2);
            }
            //Error.WriteLine($"costfun = {res}");
            res1 = res;
            return res;
        };
        vector pa = p.copy();
        int ncounts = qnewton_min(delta_p, ref pa, 1e-8);
        p = pa;
        Error.WriteLine($"res1 = {res1}"); 
        double threshhold = 0.01; 
        if(res1 > threshhold){
            ncalls++;
            Error.WriteLine($"Costfunction did not meat criteria, costfun = {res1}, threshold =  {threshhold}."); 
            Error.WriteLine("New initial parameters are tried.");
            Error.WriteLine($"No. of. recursive calls: {ncalls}");
            res1 = 0;
            for(int i = 0; i < 3 * n; i++){
                double u1 = 1.0 - rand.NextDouble(); 
                double u2 = 1.0 - rand.NextDouble();
                p[i] = Math.Sqrt(-2.0* Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
                }
            train(x,y);
        }
        //Error.WriteLine($"Converged with cost. fun = {res1}, threshhold = {threshhold}, no. of. rec. calls = {ncalls}");
        //p.eprint("p after trained is: ");
    } // train

    public double deriv(double x){  // Returns the derivative at x.
        double res = 0;
        for(int i = 0; i < n; i++){
            double ai = p[3 * i + 0];
            double bi = p[3 * i + 1];
            double wi = p[3 * i + 2];
            res += wi * fm((x-ai)/bi)/bi;
        }
        return res;
    } // deriv

    public double integral(double x, double a){ // Integral from a to x
        double res = 0;
        for(int i = 0; i < n; i++){
            double ai = p[3 * i + 0];
            double bi = p[3 * i + 1];
            double wi = p[3 * i + 2];
            res += wi * fi((x-ai)/bi) * bi; 
            res -= wi * fi((a-ai)/bi) * bi;           
        }
        return res;
    } // Integral
}