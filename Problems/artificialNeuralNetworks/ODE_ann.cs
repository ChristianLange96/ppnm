using System; 
using static System.Console; 
using static System.Math;
using System.Collections.Generic;
using static vector;
using static minimizer;
using static adaptive_integrator;

public partial class ODE_ann{
    Func<double,double> f;
    Func<double,double> fm;
    Func<double,double> fmm;
    int n;
    vector p;
    int nxs;
    double[] xs;
    
    private void init (int n){
        f = (x) =>  x * Exp(-x * x);    // Activation function
        fm = (x) => Exp(-x * x) - 2 * x * x * Exp(-x * x);  // Deriv og f
        fmm = (x) => - 2 * x * Exp(-x * x) -4 * x * Exp(-x * x) + 4 * x * x * x * Exp(-x * x); // Double deriv of f
        p = new vector(3 * n);
    }

    public ODE_ann(int m){
        init(m);
        n = m;
        nxs = 64;
        xs = new double[nxs]; // For crude integration
    }

	public double feedforward(double x){
        double res = 0;
        for(int i = 0; i < n; i++){
            double ai = p[3 * i + 0];
            double bi = p[3 * i + 1];
            double wi = p[3 * i + 2];
            res += wi * f((x-ai)/bi);
        }
        //Error.WriteLine($"Feedfoward has been called");
        return res;
    }
   
    public void train(Func<double, double, double, double, double> phi, double a, double b, double c, double yc, double ycm){
        
        // For integration
        for(int i = 0; i < nxs; i++){
            xs[i] = a + (b - a ) * i / (nxs-1);
        }
        
        
        Func<vector, double> cost = (ps) => {
            p = ps;
            //double acc = 1e-3;
            //double eps = 1e-3;
            double costSum = 0;
            Func<double, double> integrand = (x) => Pow(phi(x,feedforward(x), deriv(x), double_deriv(x)), 2);
            
            // Crude numerical integration
            for(int i = 0; i < nxs; i++){
                costSum += integrand(xs[i]);
            }
            costSum *= (b-a)/(nxs-1); // Scaling to interval

            costSum += Pow(feedforward(c)-yc, 2) * (b - a);
            costSum += Pow(deriv(c) - ycm, 2) * (b - a);
            return costSum;
        };
        vector pa = p.copy();
        for(int i = 0; i < n; i++){         // Starting conditions for parameters
            double ai = a + (b-a) * i / (n-1);
            double bi = 5;
            double wi = 1;
            pa[3 * i + 0] = ai;
            pa[3 * i + 1] = bi;
            pa[3 * i + 2] = wi;
        }
        int ncounts = qnewton_min(cost, ref pa, 1e-3);
        ncounts += 0; // Removes the warning
        p = pa;
    }

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

        public double double_deriv(double x){  // Returns the derivative at x.
        double res = 0;
        for(int i = 0; i < n; i++){
            double ai = p[3 * i + 0];
            double bi = p[3 * i + 1];
            double wi = p[3 * i + 2];
            res += wi * fmm((x-ai)/bi)/bi/bi;
        }
        return res;
    } // double_deriv

}