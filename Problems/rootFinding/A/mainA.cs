using static System.Console;
using static System.Math;
using static rootFinder;
using System;

public class mainA{
    public static int Main(){
        WriteLine("A)");
        WriteLine("Finding roots for x^2 - 4");
        Func<vector,vector> f = (z) => {double p = Pow(z[0],2) - 4; return new vector(p);};
        vector x = new vector(1.0);
        vector res1 = newton(f,x);
        WriteLine($"Accuracy goal:       {1e-3}");
        res1.print("Result:             ");
        WriteLine($"Analytical solution is {Sqrt(4.0):f3}.");
        WriteLine($"Deviation from analytical = {Abs(Sqrt(4.0)-res1[0])}");
        WriteLine("");
        Func<vector,vector> f2 = (z) => {return new vector(-2.0*(1-z[0]) - 400*(z[1] - Pow(z[0],2)) * z[0], 200 * (z[1] - Pow(z[0],2)));};
        vector x2 = new vector(3, 4);
        vector res2 = newton(f2,x2);
        vector excact_res = new vector(1.0, 1.0);
        WriteLine("Finding the minimum for Rosenbrock's valley function");
        WriteLine($"Accuracy goal:                {1e-3}");
        res2.print("Result:                       ");
        excact_res.print("Analytical res:               ");
        vector temp_diff = res2-excact_res;
        temp_diff.print("Deviation from analytical =   ");
        

        return 0;
    }
}