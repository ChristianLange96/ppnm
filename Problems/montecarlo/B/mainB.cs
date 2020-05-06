using static System.Console;
using static System.Math;
using static montecarlo;
using System;

public class mainB{
    public static int Main(){
        
        // Error estimate as function of N.
        int Nmax = (int) 1e7;
        double r = 1;
            Func<vector, double> f2 = (v) => {      // Return hight if point is inside sphere.
                if(v[0]*v[0] + v[1] * v[1] <= r *r) return Sqrt(r*r - v[0] * v[0] - v[1] * v[1]);
                else return 0;
            };
        vector a2 = new vector(-r,-r);
        vector b2 = new vector(r,r);
        for(int N = (int) 1e4; N < (int) Nmax; N = (int)(1.5*N)){
            vector res2 = plainmc(f2, a2, b2, N);
            double mean2 = res2[0];
            double err2  = res2[1];
            WriteLine($"{1/Sqrt(N)} {err2}");
        }
        return 0;
    }
}