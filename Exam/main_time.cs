using static System.Console;
using System.Diagnostics;
using static Symm_RankOne;
using static matrix;
using System;

public class main_time{
    public static int Main(){
        Stopwatch sw = new Stopwatch();
        sw.Start();
        int n_max = 500;
            for(int n = 20; n <= n_max; n += 10 ){
            matrix D = sorted_diag_matrix(n);
            vector u = rnd_vector(n);
            matrix A = D + outer(u,u);
            sw.Restart();
            vector eigens = symm_update(A, u);
            sw.Stop();
            eigens[0] = 0; // Removes warning
            WriteLine("{0} {1}", n, sw.ElapsedMilliseconds);
        } 
        return 0;
    }




}