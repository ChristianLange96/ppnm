using static System.Console;
using static System.Math;
using static adaptive_integrator;
using static quad;
using System;


public class mainB{
    
    public static int Main(){
        Console.WriteLine("Part B");
        Console.WriteLine("");
        Console.WriteLine("Calculating integral of 1/Sqrt(x) dx from 0 to 1 with Clenshaw-Curtis transformaiton");
        int noOfCalls = 0;
        double delta = 1e-3;
        double eps   = 1e-3;

        Func<double,double> f1 = (x) => {noOfCalls++; return 1.0/Sqrt(x);};
        double res1 = clenshaw_curtis(f1, 0, 1, delta, eps);

        Console.WriteLine($"The result is:                       {res1}");
        Console.WriteLine($"The analytical result is:            {2.0}");
        Console.WriteLine($"Abs. difference:                     {Abs(res1-2.0)}");
        Console.WriteLine($"Spec. tolerace delta + acc*|Q|:      {delta+eps*Abs(res1)}");
        Console.WriteLine($"No. of calls:                        {noOfCalls}");     
        Console.WriteLine("");
       
       
        Console.WriteLine("Calculating integral of 1/Sqrt(x) dx from 0 to 1 without Clenshaw-Curtis transformation");
        noOfCalls = 0;
        double res2 = integrator(f1,0,1,delta, eps);
        Console.WriteLine($"The result is:                       {res2}");
        Console.WriteLine($"The analytical result is:            {2.0}");
        Console.WriteLine($"Abs. difference:                     {Abs(res2-2.0)}");
        Console.WriteLine($"Spec. tolerace delta + acc*|Q|:      {delta+eps*Abs(res2)}");
        Console.WriteLine($"No. of calls:                        {noOfCalls}");     
        Console.WriteLine("");
        Console.WriteLine("Clearly the transformation drastically reduces the number of calls.");

        Console.WriteLine("");
        Console.WriteLine("Calculating integral of ln(x)/Sqrt(x) dx from 0 to 1 with Clenshaw-Curtis transformaiton");
        noOfCalls = 0;
        Func<double,double> f2 = (x) => {noOfCalls++; return Log(x)/Sqrt(x);};
        double res3 = clenshaw_curtis(f2,0,1, delta, eps);
        Console.WriteLine($"The result is:                       {res3}");
        Console.WriteLine($"The analytical result is:            {-4.0}");
        Console.WriteLine($"Abs. difference:                     {Abs(res3- (-4.0))}");
        Console.WriteLine($"Spec. tolerace delta + acc*|Q|:      {delta+eps*Abs(res3)}");
        Console.WriteLine($"No. of calls:                        {noOfCalls}");     
        Console.WriteLine("");


        Console.WriteLine("Calculating integral of ln(x)/Sqrt(x) dx from 0 to 1 without Clenshaw-Curtis transformaiton");
        noOfCalls = 0;
        double res4 = integrator(f2, 0, 1, delta, eps);
        Console.WriteLine($"The result is:                       {res4}");
        Console.WriteLine($"The analytical result is:            {-4.0}");
        Console.WriteLine($"Abs. difference:                     {Abs(res4- (-4.0))}");
        Console.WriteLine($"Spec. tolerace delta + acc*|Q|:      {delta+eps*Abs(res4)}");
        Console.WriteLine($"No. of calls:                        {noOfCalls}");     
        Console.WriteLine("");
        Console.WriteLine("Clearly the transformation drastically reduces the number of calls.");
        Console.WriteLine("");


        Console.WriteLine("Calculating integral of 4 * Sqrt(1-x^2) dx from 0 to 1 with Clenshaw-Curtis transformaiton");
        noOfCalls = 0;
        Func<double,double> f3 = (x) => {noOfCalls++; return 4 * Sqrt(1- Pow(x,2));};
        double res5 = clenshaw_curtis(f3, 0, 1, delta, eps);
        Console.WriteLine($"The result is:                       {res5}");
        Console.WriteLine($"The analytical result is:            {PI}");
        Console.WriteLine($"Abs. difference:                     {Abs(res5- PI)}");
        Console.WriteLine($"Spec. tolerace delta + acc*|Q|:     {delta+eps*Abs(res5)}");
        Console.WriteLine($"No. of calls:                        {noOfCalls}");     
        Console.WriteLine("");



        Console.WriteLine("Calculating integral of 4 * Sqrt(1-x^2) dx from 0 to 1 without Clenshaw-Curtis transformaiton");
        noOfCalls = 0;
        double res6 = integrator(f3, 0, 1, delta, eps);
        Console.WriteLine($"The result is:                       {res6}");
        Console.WriteLine($"The analytical result is:            {PI}");
        Console.WriteLine($"Abs. difference:                     {Abs(res6- PI)}");
        Console.WriteLine($"Spec. tolerace delta + acc*|Q|:      {delta+eps*Abs(res6)}");
        Console.WriteLine($"No. of calls:                        {noOfCalls}");     
        Console.WriteLine("");

        Console.WriteLine("So the transformation get a numerical result closer to PI than without but also uses more recursive calls");
        Console.WriteLine("");
        Console.WriteLine("Comparing to the 'o8av' integrator routine from matlib");
        noOfCalls = 0;
        double res7 = o8av(f3, 0, 1, delta, eps);
        Console.WriteLine($"The result is {res7:f10}, with {noOfCalls} recursive calls to the function");
        Console.WriteLine($"Abs. difference:                     {Abs(res7- PI)}");
        Console.WriteLine("So 'o8av' is much faster in terms of calls but not as accurate - but that can be improved by adjusting acc and eps, of course.");

        return 0;
    }
}