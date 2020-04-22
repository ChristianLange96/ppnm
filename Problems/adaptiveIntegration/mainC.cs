using static System.Console;
using static System.Math;
using static adaptive_integrator;
using static quad;
using System;


public class mainC{
    
    public static int Main(){
        double posInf = double.PositiveInfinity;
        double negInf = double.NegativeInfinity;
        Console.WriteLine("Part C");
        Console.WriteLine("");
        Console.WriteLine("Calculating integral of exp(-x^2) from -inf to inf");
        double noOfCalls = 0;
        double accError = 0;
        Func<double, double> f1 = (x) => {noOfCalls++; return Exp(-Pow(x,2));};
        double res1 = infinite_limits(f1, negInf, posInf, ref accError, 1e-6, 1e-6);
        Console.WriteLine($"The result is {res1:f10}, with {noOfCalls} recursive calls to the function."); 
        Console.WriteLine($"The estimated error is {accError:f10}");
        Console.WriteLine($"The the analytical result is Sqrt(PI) = {Sqrt(PI)}, so it's pretty close.");
        Console.WriteLine("Comparing to 'o8av':");
        noOfCalls = 0;
        double res1b = o8av(f1, negInf, posInf, 1e-6, 1e-6);
        Console.WriteLine($"The result from 'o8av' is {res1b:f10}, with {noOfCalls} recursive calls to the function.");

        Console.WriteLine("");
        noOfCalls = 0;
        accError = 0;
        Console.WriteLine("Calculating integral of 1/(1+x^2) from 0 to inf");
        Func<double,double> f2 = (x) => {noOfCalls++; return 1/(1+Pow(x,2));};
        double res2 = infinite_upper_limit(f2,0,posInf, ref accError, 1e-6, 1e-6);
        Console.WriteLine($"The result is {res2:f10}, with {noOfCalls} recursive calls to the function.");
        Console.WriteLine($"The estimated error is {accError:f10}");
        Console.WriteLine($"The the analytical result is PI/2 = {PI/2}, so it's pretty close.");
        Console.WriteLine("Comparing to 'o8av':");
        noOfCalls = 0;
        double res2b = o8av(f2, 0, posInf, 1e-6, 1e-6);
        Console.WriteLine($"The result from 'o8av' is {res2b:f10}, with {noOfCalls} recursive calls to the function.");

        Console.WriteLine("");
        noOfCalls = 0;
        accError = 0;
        Console.WriteLine("Calculating integral of exp(-x^2) from -inf to 0");
        double res3 = infinite_lower_limit(f1, negInf, 0, ref accError, 1e-6, 1e-6);
        Console.WriteLine($"The result is {res3:f10}, with {noOfCalls} recursive calls to the function.");
        Console.WriteLine($"The estimated error is {accError:f10}");   
        Console.WriteLine($"The the analytical result is Sqrt(PI)/2 = {Sqrt(PI)/2}, so it's pretty close.");
        Console.WriteLine("Comparing to 'o8av':");
        noOfCalls = 0;
        double res3b = o8av(f1, negInf, 0, 1e-6, 1e-6);
        Console.WriteLine($"The result from 'o8av' is {res3b:f10}, with {noOfCalls} recursive calls to the function.");








        return 0;
    }
}