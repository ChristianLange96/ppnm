using static System.Math;
using static ODE_integrator;
using System.Collections.Generic;
using System.IO;
using static System.Console;

class mainA{

    static vector diff_eqA (double t, vector y){
    double dy1dt = y[1];
    double dy2dt = -y[0]; 
    vector res = new vector(dy1dt, dy2dt);
    return res;
    }
    
    public static int Main(){
        StreamWriter outA = new StreamWriter("outA.data", append:false);
        double a = 0;
        double b = 2 * PI;
        vector y0 = new vector(0, 1);
        double h0 = 1e-1;
        double acc = 1e-3;
        double eps = 1e-3;
        var ts = new List<double>();
        var ys = new List<vector>();

        vector yb = driver(diff_eqA, a, y0, b, h0, acc, eps, ts, ys);

        for(int i = 0; i < ts.Count; i++){
            outA.WriteLine("{0} {1} {2}", ts[i], ys[i][0], ys[i][1]);
        }
        outA.Close();


        return 0;
    }





}