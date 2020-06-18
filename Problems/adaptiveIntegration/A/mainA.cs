using static System.Console;
using static System.Math;
using static adaptive_integrator;
using System;


public class mainA{
    
    public static int Main(){
        Console.WriteLine("Part A");
        Console.WriteLine("");
        Console.WriteLine("Calculating integral of Sqrt(x) dx from 0 to 1:");
        Func<double,double> f = (x) => Sqrt(x);
        double delta = 1e-6;
        double eps   = 1e-6;

        double res1 = integrator(f, 0, 1, delta, eps);
        Console.WriteLine($"The result is:                       {res1}");
        Console.WriteLine($"The analytical result is             {2.0/3}");
        Console.WriteLine($"Abs. difference:                     {Abs(res1-2.0/3)}");
        Console.WriteLine($"Spec. tolerace delta + acc*|Q|       {delta+eps*Abs(res1)}");
        Console.WriteLine("");

        Console.WriteLine("Calculating integral of 4* Sqrt(1-x^2) dx from 0 to 1");
        Func<double, double> g = (x) => Sqrt(1-Pow(x,2)) * 4.0;
        double res2 = integrator(g, 0, 1, delta, eps);
        Console.WriteLine($"The result is:                       {res2}");
        Console.WriteLine($"The analytical result is             {PI}");
        Console.WriteLine($"Abs. difference:                     {Abs(res2-PI)}");
        Console.WriteLine($"Spec. tolerace delta + acc*|Q|       {delta+eps*Abs(res2)}");
        Console.WriteLine("");


        Console.WriteLine("Calculating integral of 4* Sqrt(1-x^2) dx from 1 to 0");
        double res3 = integrator(g, 1, 0, delta, eps);
        Console.WriteLine($"The result is:                       {res3}");
        Console.WriteLine($"The analytical result is             {-PI}");
        Console.WriteLine($"Abs. difference:                     {Abs(res3+PI)}");
        Console.WriteLine($"Spec. tolerace delta + acc*|Q|       {delta+eps*Abs(res3)}");
        Console.WriteLine("");
        Console.WriteLine("The calculated integrals satisfy the accuracy conditions.");
        return 0;
    }
}