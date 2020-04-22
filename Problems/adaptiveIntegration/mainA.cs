using static System.Console;
using static System.Math;
using static adaptive_integrator;
using System;


public class mainA{
    
    public static int Main(){
        Console.WriteLine("Part A");
        Console.WriteLine("");
        Console.WriteLine("Calculating integral of Sqrt(x) dx from 0 to 1");
        Func<double,double> f = (x) => Sqrt(x);

        double res1 = integrator(f, 0, 1, 1e-6, 1e-6);
        Console.WriteLine($"The result is {res1:f5}");
        Console.WriteLine($"The analytical result is {2.0/3:f5}, so it matches perfectly.");
        Console.WriteLine("");
        Console.WriteLine("Calculating integral of 4* Sqrt(1-x^2) dx from 0 to 1");
        Func<double, double> g = (x) => Sqrt(1-Pow(x,2)) * 4.0;
        double res2 = integrator(g, 0, 1, 1e-6, 1e-6);
        Console.WriteLine($"The result is {res2:f5}");
        Console.WriteLine($"The analytical result is {PI:f5}, so this also matches perfectly.");



        return 0;
    }
}