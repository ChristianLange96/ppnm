
using static System.Math;
using static ODE_integrator;
using System.Collections.Generic;
using System;
using System.IO;
using static System.Console;

class mainB{
        
    static private vector diff_eq_SIR(double x, vector y, vector param){
        // y is a vector containing [S, I ,R];
        double N    = param[0];
        double T_c  = param[1];
        double T_r  = param[2];
        double dSdt = - y[0] * y [1] / (N * T_c);
        double dIdt = y[0] * y[1] / (N * T_c) - y[1]/T_r;
        double dRdt = y[1]/T_r;
        vector res = new vector(dSdt, dIdt, dRdt);
        return res;
    }
      
    public static int Main(){

        StreamWriter outB1 = new StreamWriter("outB1.data", append:false);
        StreamWriter outB2 = new StreamWriter("outB2.data", append:false);
        StreamWriter outB3 = new StreamWriter("outB3.data", append:false);
        StreamWriter outB4 = new StreamWriter("outB3.txt", append:false);

        // Starting values: (Data found at: https://www.sst.dk/da/corona/tal-og-overvaagning)
        double N = 5.822e6;          // Population size of Denmark
        double I0 = 5635 - 1736 - 237;// Infected pr. 10th of April 2020
        double R0 = 1736 + 237;      // Sum of recovered and deaths.
        double S0 = N - I0 - R0;     // 
        vector y0 = new vector(S0, I0, R0);

        double a = 0;
        double b = 200;              // Step size in days
        double h0 = 1e-1;
        double acc = 1e-6;
        double eps = 1e-6;
        var ts = new List<double>();
        var ys = new List<vector>();
        double T_c = 0.5;                   // Time in days it takes to infect another.
        double T_r = 16.0;                  // Days for recovery
        vector param1 = new vector(N, T_c, T_r);
        Func<double,vector,vector> f1 = (x,y)=>diff_eq_SIR(x, y, param1);
        vector yb1 = driver(f1, a, y0, b, h0, acc, eps, ts, ys);
        for(int i = 0; i < ts.Count; i++){
            outB1.WriteLine("{0} {1} {2} {3}", ts[i], ys[i][0], ys[i][1], ys[i][2]);
        }
        outB1.Close();
        T_c = 5;                   // Time in days it takes to infect another person.
        vector param2 = new vector(N, T_c, T_r);
        Func<double,vector,vector> f2 = (x,y)=>diff_eq_SIR(x, y, param2);
        vector yb2 = driver(f2, a, y0, b, h0, acc, eps, ts, ys);
        for(int i = 0; i < ts.Count; i++){
            outB2.WriteLine("{0} {1} {2} {3}", ts[i], ys[i][0], ys[i][1], ys[i][2]);
        }
        outB2.Close();

        T_c = 10;                   // Time in days it takes to infect another person.
        vector param3 = new vector(N, T_c, T_r);
        Func<double,vector,vector> f3 = (x,y)=>diff_eq_SIR(x, y, param3);
        vector yb3 = driver(f3, a, y0, b, h0, acc, eps, ts, ys);
        for(int i = 0; i < ts.Count; i++){
            outB3.WriteLine("{0} {1} {2} {3}", ts[i], ys[i][0], ys[i][1], ys[i][2]);
        }
        outB3.Close();

        outB4.WriteLine("It's clearly seen on the figures, that the longer time it takes to infect a new person,");
        outB4.WriteLine("the flatter the curve will be, but it will also take longer time for the epidemic to be over.");
        outB4.Close();



        return 0;
    }





}