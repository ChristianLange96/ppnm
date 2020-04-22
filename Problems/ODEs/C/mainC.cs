
using static System.Math;
using static ODE_integrator;
using System.Collections.Generic;
using System.IO;
using static System.Console;

class mainC{
    
    static vector three_body (double t, vector y){
    // y is a vector containing [r1x, r1y, r2x, r2y, r3x, r3y, v1x, v1y, v2x, v2y, v3x, v3y]
    // Index:                     0,   1 ,  2,   3,   4,   5,   6 ,  7,   8,   9  , 10 , 11
    // m = g = 1  is assumed. 
    double dx1dt = y[6];
    double dy1dt = y[7];
    double dx2dt = y[8];
    double dy2dt = y[9];
    double dx3dt = y[10];
    double dy3dt = y[11];

    // Distance between objects
    double d12 = Pow( Sqrt(Pow(y[0] - y[2],2) + Pow(y[1] - y[3],2)), 3);
    double d13 = Pow( Sqrt(Pow(y[0] - y[4],2) + Pow(y[1] - y[5],2)), 3);
    double d23 = Pow( Sqrt(Pow(y[2] - y[4],2) + Pow(y[3] - y[5],2)), 3);

    double dv1xdt = - (y[0] - y[2]) / d12 - (y[0] - y[4]) / d13;
    double dv1ydt = - (y[1] - y[3]) / d12 - (y[1] - y[5]) / d13;
    double dv2xdt = - (y[2] - y[0]) / d12 - (y[2] - y[4]) / d23;
    double dv2ydt = - (y[3] - y[1]) / d12 - (y[3] - y[5]) / d23;
    double dv3xdt = - (y[4] - y[0]) / d13 - (y[4] - y[2]) / d23;
    double dv3ydt = - (y[5] - y[1]) / d13 - (y[5] - y[3]) / d23;
    vector res = new vector(dx1dt, dy1dt, dx2dt, dy2dt, dx3dt, dy3dt, dv1xdt, dv1ydt, dv2xdt, dv2ydt, dv3xdt, dv3ydt);
    return res;
    }
   
    public static int Main(){
        StreamWriter outC = new StreamWriter("outC.data", append:false);

        // Initial coniditions found at: https://arxiv.org/pdf/math/0011268.pdf
        double x10 = 0.97000436;
        double y10 = -0.24308753;
        double x20 = -x10;
        double y20 = -y10;
        double x30 = 0;
        double y30 = 0;

        double v3x0 = -0.93240737;
        double v3y0 = -0.86473146;
        double v2x0 = -0.5 * v3x0;
        double v2y0 = -0.5 * v3y0;
        double v1x0 = v2x0;
        double v1y0 = v2y0;

        vector y0 = new vector(x10, y10, x20, y20, x30, y30, v1x0, v1y0, v2x0, v2y0, v3x0, v3y0);

        double a = 0;
        double b = 12;          
        double h0 = 1e-3;
        double acc = 1e-6;
        double eps = 1e-6;
        var ts = new List<double>();
        var ys = new List<vector>();
        vector yb = driver(three_body, a, y0, b, h0, acc, eps, ts, ys);
        for(int i = 0; i < ts.Count; i++){
            outC.WriteLine("{0} {1} {2} {3} {4} {5} {6}", ts[i], ys[i][0], ys[i][1], ys[i][2], ys[i][3], ys[i][4], ys[i][5]);
        }
        outC.Close();

        return 0;
    }
}