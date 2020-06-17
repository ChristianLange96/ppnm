using static System.Console;
using static System.Math;
using static interpolater_ann;
using System;

public class mainB{
    public static int Main(){
        interpolater_ann our_ann = new interpolater_ann(3);

        // Creating data from a Sin(x)
        int n = 20;
        double a = -PI;
        double b = PI;
        vector xs = new vector(n+1);
        vector ys = new vector(n+1);
        vector zs = new vector(n+1);
        vector qs = new vector(n+1);              
        for(int i = 0; i <= n; i++){
            xs[i] = (double) a + i * (b-a)/n ;
            ys[i] = (double) Sin(xs[i]);
            zs[i] = (double) Cos(xs[i]); // Deriv of ys
            qs[i] = (double) -Cos(xs[i]);
            WriteLine($"{xs[i]} {ys[i]} {zs[i]} {qs[i]-1}");
        }
        WriteLine(""); 
        WriteLine("");

        our_ann.train(xs, ys);
        int k = 100;
        for(int i = 0; i <= k; i++){
            double thisx = a + i * (b-a)/k;
            WriteLine($"{thisx} {our_ann.feedforward(thisx)} {our_ann.deriv(thisx)} {our_ann.integral(thisx,a)}");
        }
        return 0;
    }
}