using static System.Console;
using static System.Math;
using static montecarlo;
using System;

public class mainA{
    public static int Main(){
        
        // Testing monte carlo integration //

        // sin(x) * sin(y)
        Func<vector,double> f1 = (v) => {return Sin(v[0]) * Sin(v[1]);};
        vector a1 = new vector(0,0);
        vector b1 = new vector(PI,PI);
        int N = (int) 1e6;
        vector res1 = plainmc(f1, a1, b1, N);
        double mean1 = res1[0];
        double err1  = res1[1];
        WriteLine("Integral of sin(x)*sin(y) from 0 to pi in both x and y:");
        WriteLine($"res =               {mean1}");
        WriteLine($"analytical sol =    {4.0}");
        WriteLine($"with err. est. =    {err1}");
        WriteLine($"actual abs. error = {Abs((mean1-4))}");
        WriteLine("");

        // Finding half volume of a sphere with integration
        double r = Pow(3.0/2,1.0/3);
        Func<vector, double> f2 = (v) => {      // Return hight if point is inside sphere.
            if(v[0]*v[0] + v[1] * v[1] <= r *r) return Sqrt(r*r - v[0] * v[0] - v[1] * v[1]);
            else return 0;
        };
        vector a2 = new vector(-r,-r);
        vector b2 = new vector(r,r);
        vector res2 = plainmc(f2, a2, b2, N);
        double mean2 = res2[0];
        double err2  = res2[1];

        WriteLine($"Integral of ciricle w. radius r = {r:f5} [(3/2)^(1/3) = {Pow(3.0/2,1.0/3):f5}]. Calculating half volume of the corresponding sphere.");
        WriteLine($"res =               {mean2}");
        WriteLine($"analytical sol =    {PI}");
        WriteLine($"with err. est. =    {err2}");
        WriteLine($"actual abs. error = {Abs((mean2-PI))}");
        WriteLine("");
        WriteLine("");


        // Dimitri's function
        Func<vector,double> f3 = (v) => {return 1.0/Pow(PI,3) * 1.0/(1 - Cos(v[0]) * Sin(v[1]) * Cos(v[2]));};
        vector a3 = new vector(0, 0, 0);
        vector b3 = new vector(PI, PI, PI);
        vector res3 = plainmc(f3, a3, b3, N);
        double mean3 = res3[0];
        double err3  = res3[1];
        WriteLine("Integral of (1/PI)^3 * 1/(1 - Cos(x) * Sin(y) * Cos(z))");
        double correct_res = 1.3932039296856768591842462603255;
        WriteLine($"res =               {mean3}");
        WriteLine($"analytical sol =    {correct_res}");
        WriteLine($"with err. est. =    {err3}");
        WriteLine($"actual abs. error = {Abs(mean3-correct_res)}");
        WriteLine("");
        WriteLine("The error est. is in general a little too conservative, but this can fluctuate from integral to integral.");

        return 0;
    }
}