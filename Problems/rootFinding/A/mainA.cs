using static System.Console;
using static System.Math;
using static rootFinder;
using System;

public class mainA{
    public static int Main(){
        WriteLine("Finding roots for x^2 - 4");
        Func<vector,vector> f = (z) => {double p = Pow(z[0],2) - 4; return new vector(p);};
        vector x = new vector(1.0);
        vector res1 = newton(f,x);
        WriteLine($"Newton's method has found the root(s):");
        res1.print();
        WriteLine($"Analytical solution is {Sqrt(4.0):f3}.");
        WriteLine("");
        Func<vector,vector> f2 = (z) => {return new vector(-2.0*(1-z[0]) - 400*(z[1] - Pow(z[0],2)) * z[0], 200 * (z[1] - Pow(z[0],2)));};
        vector x2 = new vector(3, 4);
        vector res2 = newton(f2,x2);
        WriteLine("Finding the minimum for Rosenbrock's valley function");
        res2.print();
        WriteLine("The analytical minimum is at (1,1)");

        return 0;
    }
}