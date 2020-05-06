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
        WriteLine($"res = {mean1:f5} with err. est. = {err1:f5}, analytical sol = {4:f5}, actural abs. error = {(mean1-4):f5}");
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
        WriteLine($"res = {mean2:f5}, err. est. = {err2:f5}, analytical res = {PI:f5}, actural abs. error = {(mean2-PI):f5}");
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
        WriteLine($"res = {mean3}, err. est. = {err3}, analytical res = {correct_res}, actural abs. error = {(mean3-correct_res):f5}");

        return 0;
    }
}