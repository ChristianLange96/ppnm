using static System.Console;
using System.Diagnostics;
using static Symm_RankOne;
using static jac_diag;
using static matrix;
using System;

public class main_time{
    public static int Main(){
        Stopwatch sw = new Stopwatch();
        Stopwatch sw2 = new Stopwatch();
        sw.Start();
        sw2.Start();
        int n_max = 400;
            for(int n = 20; n <= n_max; n += 10 ){
            matrix D = sorted_diag_matrix(n);
            vector u = rnd_vector(n);
            matrix A = D + outer(u,u);
            matrix A2 = A.copy(); // For cyclic sweep
            matrix V2 = new matrix(n,n);
            vector D2 = new vector(n);
            sw.Restart();
            vector eigens = symm_update(A, u);
            sw.Stop();
            sw2.Restart();
            double sweeps = cyclic_sweep(A2,V2,D2);
            sw2.Stop();
            eigens[0] = 0; // Removes warning
            sweeps++;      // Removes warning
            WriteLine("{0} {1} {2}", n, sw.ElapsedMilliseconds, sw2.ElapsedMilliseconds);
        } 
        return 0;
    }




}