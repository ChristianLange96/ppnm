using static System.Console;
using static System.Math;
using static rootFinder;
using static hydrogen;
using System.IO;
using System;

public class mainC{
    public static int Main(){
        StreamWriter outC1data = new StreamWriter("outC1.data", append:false);
        StreamWriter outC2data = new StreamWriter("outC2.data", append:false);
        // Looking solutions for which fe(rmax) = 0 is satisfied. 

        for(double rmax = 2.0; rmax <= 10.0; rmax+=2.0){
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
                for(double i = 0.0; i <= rmax + 0.01; i += 0.10){  
                    outC1data.WriteLine("{0} {1}", i, fe(e_found,i));
                }
            outC1data.WriteLine(" ");
            outC1data.WriteLine(" ");
            }
        for(double i = 0; i <= 10; i += 0.1){
            outC1data.WriteLine("{0} {1} ", i, i * Exp(-i));
        }

        for(double rmax = 0.5; rmax <= 10.0; rmax+=2.0){
            Func<vector, vector> fe_root = (vector m) => {
            double e = m[0];
            double fe_rmax = fe(e, rmax);
            double k= Sqrt(- 2 * e);
            return new vector(fe_rmax - rmax * Exp(- k * rmax));
            }; 
            // Initial condition
            vector m0 = new vector(-1.0);   // I know the root is around -0.5.
            vector mroots = newton(fe_root, m0);

            // Obtaining the energy satisfying the boundary condition 
            double e_found = mroots[0];
                for(double i = 0.0; i <= rmax + 0.01; i += 0.10){ 
                    outC2data.WriteLine("{0} {1}", i, fe(e_found,i));
                }
            outC2data.WriteLine(" ");
            outC2data.WriteLine(" ");
        }
        for(double i = 0; i <= 10; i += 0.1){
            outC2data.WriteLine("{0} {1} ", i, i * Exp(-i));
        }

        outC1data.Close();
        outC2data.Close();










        return 0;
    }
}