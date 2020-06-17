using static System.Math;
using static System.Console;
using System.IO;
class mainC{
    public static int Main(){
        // Creating points
        int n = 11;     // Creating n points
        double a = 0.0, b = 3.0 * PI;
        vector xs = new vector(n);
        vector ys = new vector(n);
        StreamWriter outputfileData = new StreamWriter("out-xy.data", append:false);

        for(int i = 0; i < n; i++){
            xs[i] = a + i * b/(n-1) ;
            ys[i] = Cos(xs[i]);
            outputfileData.WriteLine("{0} {1}", xs[i], ys[i]);
        }
        outputfileData.Close();
        /// Interpolating and integrating ///
        //Outputfiles are created
         StreamWriter outputfileSpline = new StreamWriter("out-cspline.data", append:false);
         StreamWriter outputfileIntegration = new StreamWriter("out-cintegration.data", append:false);
         StreamWriter outputfileDerivative = new StreamWriter("out-cderivative.data", append:false);

        int k = 50;
        double z = 0;
        cspline cSpliner = new cspline(xs,ys);
        a = xs[0]; b = xs[xs.size-1];
        for(int i = 0; i <= k; i++){
            z = a + i * b/k * 1.0;
            outputfileSpline.WriteLine("{0} {1}", z, cSpliner.spline(z));
            outputfileIntegration.WriteLine("{0} {1} {2}", z, cSpliner.integral(z), Sin(z));
            outputfileDerivative.WriteLine("{0} {1} {2}", z, cSpliner.derivative(z), -Sin(z));
        }
        outputfileSpline.Close();
        outputfileIntegration.Close();
        outputfileDerivative.Close();
    return 0;
    }
}