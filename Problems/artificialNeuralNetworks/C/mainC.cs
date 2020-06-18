using static System.Console;
using static System.Math;
using static ODE_ann;
using System;

public class mainC{
    public static int Main(){
        ODE_ann our_ann = new ODE_ann(3);
        double a = -PI;
        double b = PI;
        double c = 0;
        Func<double, double, double, double, double> phi1 = (x, y, ym, ymm) => {return ymm + y;};
        double yc = Sin(c);
        double ycm = Cos(c);

        our_ann.train(phi1, a, b, c, yc, ycm);

        int k = 50;
        for(int i = 0; i <= k; i++){
            double thisx = a + i * (b-a)/k;
            WriteLine($"{thisx} {Sin(thisx)} {our_ann.feedforward(thisx)} {our_ann.deriv(thisx)} {our_ann.double_deriv(thisx)} {Cos(thisx)} {-Sin(thisx)}");
        }
        return 0;
    }
}