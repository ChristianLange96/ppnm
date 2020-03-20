using static System.Math;
using static System.Console;
using System.IO;
class mainA{
    public static int Main(){


        // Creating points
        double n = 20.0;     // Creating n points
        double a = 0, b = 4 * PI;
        vector xs = new vector((int) n);
        vector ys = new vector((int) n);
        StreamWriter outputfileData = new StreamWriter("out-xydata.txt", append:false);

        for(int i = 0; i < n; i++){
            xs[i] = (double) i * b/n ;
            ys[i] = (double) Cos(xs[i]);
            outputfileData.WriteLine("{0} {1}", xs[i], ys[i]);
        }
        outputfileData.Close();

        /// Interpolating and integrating ///
        //Outputfiles are created
         StreamWriter outputfileSpline = new StreamWriter("out-lsplinedata.txt", append:false);
         StreamWriter outputfileIntegration = new StreamWriter("out-lintegration.txt", append:false);

        double k = 50;
        double z = 0;
        a = xs[0]; b = xs[xs.size-1];
        for(double i = 0.0; i < k; i++){
            z = a + i * b/k;
            outputfileSpline.WriteLine("{0} {1}", z, linspline.lspline(xs,ys,z));
            outputfileIntegration.WriteLine("{0} {1} {2}", z, linspline.linerpInteg(xs,ys,z), Sin(z));
        }
        outputfileSpline.Close();
        outputfileIntegration.Close();


    return 0;
    }
    



}