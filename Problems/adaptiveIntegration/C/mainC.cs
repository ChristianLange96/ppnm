using static System.Console;
using static System.Math;
using static adaptive_integrator;
using static quad;
using System;


public class mainC{
    
    public static int Main(){
        double posInf = double.PositiveInfinity;
        double negInf = double.NegativeInfinity;
        double delta = 1e-6;
        double eps   = 1e-6;
        Console.WriteLine("Part C");
        Console.WriteLine("");
        Console.WriteLine("Calculating integral of exp(-x^2) from -inf to inf");
        double noOfCalls = 0;
        double accError = 0;
        Func<double, double> f1 = (x) => {noOfCalls++; return Exp(-Pow(x,2));};
        double res1 = infinite_limits(f1, negInf, posInf, ref accError, delta, eps);
        Console.WriteLine($"The result is:                       {res1}");
        Console.WriteLine($"The analytical result is:            {Sqrt(PI)}");
        Console.WriteLine($"Abs. difference:                     {Abs(res1- Sqrt(PI))}");
        Console.WriteLine($"Spec. tolerace delta + acc*|Q|:      {delta+eps*Abs(res1)}");
        Console.WriteLine($"No. of calls:                        {noOfCalls}");     
        Console.WriteLine("Comparing to 'o8av':");
        noOfCalls = 0;
        double res1b = o8av(f1, negInf, posInf, delta, eps);
        Console.WriteLine($"The result from 'o8av' is {res1b:f10}, with {noOfCalls} recursive calls to the function.");
        Console.WriteLine($"o8av difference:                     {Abs(res1b- Sqrt(PI))}");
        
        Console.WriteLine("");
        noOfCalls = 0;
        accError = 0;
        Console.WriteLine("Calculating integral of 1/(1+x^2) from 0 to inf");
        Func<double,double> f2 = (x) => {noOfCalls++; return 1/(1+Pow(x,2));};
        double res2 = infinite_upper_limit(f2,0,posInf, ref accError, delta, eps);
        Console.WriteLine($"The result is:                       {res2}");
        Console.WriteLine($"The analytical result is:            {PI/2}");
        Console.WriteLine($"Abs. difference:                     {Abs(res2- PI/2)}");
        Console.WriteLine($"Spec. tolerace delta + acc*|Q|:      {delta+eps*Abs(res2)}");
        Console.WriteLine($"No. of calls:                        {noOfCalls}");     
        Console.WriteLine("Comparing to 'o8av':");
        noOfCalls = 0;
        double res2b = o8av(f2, 0, posInf, delta, eps);
        Console.WriteLine($"The result from 'o8av' is {res2b:f10}, with {noOfCalls} recursive calls to the function.");
        Console.WriteLine($"o8av difference:                     {Abs(res2b- PI/2)}");
        Console.WriteLine("");
        
        
        noOfCalls = 0;
        accError = 0;
        Console.WriteLine("Calculating integral of exp(-x^2) from -inf to 0");
        double res3 = infinite_lower_limit(f1, negInf, 0, ref accError, delta, eps);
        Console.WriteLine($"The result is {res3:f10}, with {noOfCalls} recursive calls to the function.");
        Console.WriteLine($"The result is:                       {res3}");
        Console.WriteLine($"The analytical result is:            {Sqrt(PI)/2}");
        Console.WriteLine($"Abs. difference:                     {Abs(res3- Sqrt(PI)/2)}");
        Console.WriteLine($"Spec. tolerace delta + acc*|Q|:      {delta+eps*Abs(res3)}");
        Console.WriteLine($"No. of calls:                        {noOfCalls}");     
        Console.WriteLine("Comparing to 'o8av':");
        noOfCalls = 0;
        double res3b = o8av(f1, negInf, 0, delta, eps);
        Console.WriteLine($"The result from 'o8av' is {res3b:f10}, with {noOfCalls} recursive calls to the function.");
        Console.WriteLine($"o8av difference:                     {Abs(res3b- Sqrt(PI)/2)}");
        Console.WriteLine("");
        Console.WriteLine("o8av peforms worse except for the last integral where it actually keeps the accuracy goals.");
        Console.WriteLine("However, it does achieve the the accuracy goeal with few less recursive calls.");

        return 0;
    }
}