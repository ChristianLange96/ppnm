using static ODE_integrator;
using System;
using System.Collections.Generic;

public class hydrogen{

    // Integrating the Schrodinger ODE for given energy, e, as a function of r.
    public static double fe(double e, double r){
        // Lower limit for r->0:
        double rmin = 1e-6;
        if(r < rmin) return r - r*r; 

        // Defining equation for ODE ( -1/2 f'' - 1/r f = e f)
        Func<double, vector, vector> f = (l,y) => {return new vector(y[1], - 2 * (e + 1.0/l) * y[0]);};

        // Defining initialconditions ( f(r -> 0) = r - r*r ==>  f'(r ->0) = 1-2*r )  
        vector ymin = new vector(rmin - rmin * rmin, 1 - 2 * rmin);

        // Integrating the ODE in finding the solution at ymax
        List<double> ts = new List<double>(); 
        List<vector> ys = new List<vector>();
        vector ymax = driver(f, rmin, ymin, r, 1e-3, 1e-6, 1e-6, ts, ys);
        return ymax[0];
    }  

    
}