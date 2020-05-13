using System; 
using static System.Console; 
using static System.Math;
using System.Collections.Generic;
using static vector;
using static minimizer;

public partial class interpolater_ann {
        int n;
        Func<double,double> f;
        vector p;
        Random rand = new Random();
        int ncalls;
        public static double erf(double x){ // To integration of Gaussian
        /// single precision error function (Abramowitz and Stegun, from Wikipedia)
        if(x<0) return -erf(-x);
        double[] a={0.254829592,-0.284496736,1.421413741,-1.453152027,1.061405429};
        double t=1/(1+0.3275911*x);
        double sum=t*(a[0]+t*(a[1]+t*(a[2]+t*(a[3]+t*a[4]))));/* the right thing */
        return 1.0 - sum*Exp(-x*x);
        } 


    public interpolater_ann(){
        ncalls = 0;
        n = 3;                  // No. of neurons
        f = (x) =>  Exp(-x * x);
        p = new vector(3 * n);
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
            y += p[i*3 + 2] * f((x - p[i*3]) / p[i*3 + 1]);
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
        //Error.WriteLine($"res1 = {res1}");
        double threshhold = 5.0;
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
            res += p[3*i+2] * f((x- p[3*i])/p[3*i+1]) * (-2.0/(Pow(p[3*i+1], 2)) *(x-p[3*i]));
        }
        return res;
    } // deriv

    public double integral(double x){
        double res1 = 0;
        double res2 = 0;
        for(int i = 0; i < n; i++){
        res1 += p[3*1+2] *  1/Sqrt(PI) * erf((- p[3*i])/p[3*i+1]);  
        res2 += p[3*1+2] *  1/Sqrt(PI) * erf((x - p[3*i])/p[3*i+1]);
        }
        return res2 - res1;
    }
}