using static System.Console;
using static System.Math;
using static minimizer;
using System;

public class mainA{
    public static int Main(){
        WriteLine("Finding minumum of Rosenbrock's Valley function");
        Func<vector,double> f1 = (z) =>  Pow(1-z[0],2) + 100 * Pow(z[1] - Pow(z[0],2),2); 
        vector x0 = new vector(3.0,3.0);
        double eps = 1e-3;
        x0.print("Starting point:    ");
        int ncounts1 = qnewton_min(f1, ref x0, eps);
        WriteLine($"nsteps = {ncounts1}");
        WriteLine($"Found minimum = ({x0[0]:f5}, {x0[1]:f5},)");
        WriteLine($"Exact minimum = (1,1)");
        WriteLine($"Absolute deviation = {Abs(x0[0]-1.0)}, {Abs(x0[1]-1.0)}");
        WriteLine($"Tolerance for gradient = {eps}");
        WriteLine($"Gradient at minimum = {minimizer.gradient(f1,x0).norm():f8}");

        WriteLine("");

        WriteLine("Finding minumum of the Himmelblau's function");
        Func<vector,double> f2 = (z) =>  Pow((Pow(z[0],2) + z[1] - 11),2) + Pow(z[0] + Pow(z[1],2) - 7,2); 
        x0 = new vector(5 ,3.0);
        x0.print("Starting point:    ");
        int ncounts2 = qnewton_min(f2, ref x0, eps);
        WriteLine($"nsteps = {ncounts2}");
        WriteLine($"Found minimum = ({x0[0]:f5}, {x0[1]:f5})");
        WriteLine($"Exact minimum = (-2.805118, 3.131312)");
        WriteLine($"Absolute deviation = {Abs(x0[0]+2.805118)}, {Abs(x0[1]-3.131312)}");
        WriteLine($"Tolerance for gradient = {eps}");
        WriteLine($"Gradient at minimum = {minimizer.gradient(f2,x0).norm():f8}");



        return 0;
    }
}