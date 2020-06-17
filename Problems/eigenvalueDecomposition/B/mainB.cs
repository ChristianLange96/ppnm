using System;
using System.Diagnostics;
using System.IO;
using static System.Math;
using static System.Console;


public class mainB{
    public static int Main(){
        StreamWriter outputB1 = new StreamWriter("outB1.data", append:false);

        Stopwatch sw = new Stopwatch();
        Stopwatch sw2 = new Stopwatch();
        sw.Start();
        sw2.Start();

        // Part B1 - O(n^3) dependence

        for(int n = 20; n < 161; n+= 20 ){

            var Arnd = jac_diag.makeRnmSymMatrix(n);
            matrix V = new matrix(n,n);
            vector D = new vector(n);
            sw.Restart();
            var sweeps = jac_diag.cyclic_sweep(Arnd, V, D);
            sw.Stop();
            outputB1.WriteLine("{0} {1} {2}", n, sw.ElapsedMilliseconds/1000.0, sweeps);
        }

        outputB1.Close();

        // Part B3 Comparison between lowest eigen and cyclic - sweeps
        StreamWriter outputB_sweeps = new StreamWriter("outB_rotations.data", append:false);
        for(int n = 40; n < 301; n +=10){
            var Arnd = jac_diag.makeRnmSymMatrix(n);
            matrix V = new matrix(n,n);
            vector D = new vector(n);

            // No. of elements above the diagonal + the diagonal - cycled over in cyclic sweep
            int factor = (n*n-n)/2;

            var Arnd2 = Arnd.copy();
            matrix V2 = V.copy();
            vector D2  = D.copy();
            sw.Restart();
            var sweeps_cyclic = jac_diag.cyclic_sweep(Arnd, V, D);
            sw.Stop();
            sw2.Restart();
            var sweeps_lowest = jac_diag.first_eigen(Arnd2, V2, D2, 1, true);
            sw2.Stop();
            outputB_sweeps.WriteLine("{0} {1} {2} {3} {4}", n, sweeps_cyclic * factor, sweeps_lowest,sw.ElapsedMilliseconds/1000.0, sw2.ElapsedMilliseconds/1000.0) ;
        }
        outputB_sweeps.Close();
        // Part B3 Comparison between all val by val and cyclic - sweeps
        StreamWriter outputB_sweeps_all = new StreamWriter("outB_rotations_all.data", append:false);
        for(int n = 40; n < 101; n +=10){
            var Arnd = jac_diag.makeRnmSymMatrix(n);
            matrix V = new matrix(n,n);
            vector D = new vector(n);

            // No. of elements above the diagonal + the diagonal - cycled over in cyclic sweep
            int factor = (n*n-n)/2;

            var Arnd2 = Arnd.copy();
            matrix V2 = V.copy();
            vector D2  = D.copy();
            
            var sweeps_cyclic = jac_diag.cyclic_sweep(Arnd, V, D);
            sw.Restart();
            var sweeps_all    = jac_diag.first_eigen(Arnd2, V2, D2, n, true);
            sw.Stop();
            outputB_sweeps_all.WriteLine("{0} {1} {2} {3}", n, sweeps_cyclic * factor, sweeps_all, sw.ElapsedMilliseconds/1000.0);
        }
        outputB_sweeps_all.Close();

        // Comparing time for all 




        return 0;
    }
}