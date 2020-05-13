using static System.Console;
using static System.Math;
using static interpolater_ann;
using System;

public class mainA{
    public static int Main(){
        interpolater_ann our_ann = new interpolater_ann();

        // Creating data from a Sin(x)
        int n = 20;
        double a = -PI;
        double b = PI;
        vector xs = new vector(n+1);
        vector ys = new vector(n+1);        
        for(int i = 0; i <= n; i++){
            xs[i] = (double) a + i * (b-a)/n ;
            ys[i] = (double) Sin(xs[i]);
            WriteLine($"{xs[i]} {ys[i]}");
        }
        WriteLine("");
        WriteLine("");

        our_ann.train(xs, ys);
        int k = 100;
        for(int i = 0; i <= k; i++){
            double thisx = a + i * (b-a)/k;
            WriteLine($"{thisx} {our_ann.feedforward(thisx)}");
        }
        return 0;
    }
}