using static System.Console;
using static System.Math;
using static rootFinder;
using static hydrogen;
using System.IO;
using System;

public class mainB{
    public static int Main(){
        StreamWriter outBdata = new StreamWriter("outB.data", append:false);
        StreamWriter outBtxt = new StreamWriter("OutB.txt", append:false);
        // Defining rmax
        double rmax = 10;

        // Looking solutions for which fe(rmax) = 0 is satisfied. 

        // Defining the function to find root of
        Func<vector, vector> fe_root = (vector m) => {
            double e = m[0];
            double fe_rmax = fe(e, rmax);
            return new vector(fe_rmax);
        }; 
    
        // Initial condition
        vector m0 = new vector(-1.0);   // I know the root is around -0.5.
        vector mroots = newton(fe_root, m0);

        // Obtaining the energy satisfying the boundary condition 
        double e_found = mroots[0];

        for(double i = 0; i < rmax; i += 0.1){
            outBdata.WriteLine("{0} {1} {2}", i, fe(e_found,i), i * Exp(-i));
        }

        vector e_found_vec = new vector(e_found);
        outBtxt.WriteLine($"Accuracy goal: {1e-3}");
        outBtxt.WriteLine("Error at root = {0}.",fe_root(e_found_vec)[0]);
        outBtxt.WriteLine("In 'outB.data' you will see the comparison between the calculated result (2nd column).");
        outBtxt.WriteLine("And the excact result (3rd column).");

        outBdata.Close();
        outBtxt.Close();
        return 0;
    }
}