using System;
using System.Diagnostics;
using System.IO;
using static System.Math;
using static System.Console;


public class mainB{
    public static int Main(){

        // Part B5: Finding largest eigenvalues instead
        //StreamWriter outputB_largest_eigen = new StreamWriter("OutB_largest_eigen.txt", append:false);
        int m = 6;
        int k = 2;
        var A_eigen = jac_diag.makeRnmSymMatrix(m);
        WriteLine("Part B1 and B5: Finding lowest largest eigenvalues:");
        var A_eigen3 = jac_diag.makeRnmSymMatrix(m);
        matrix V_eigen = new matrix(m,m);       
        vector D_eigen = new vector(m);
        matrix V_eigen3 = V_eigen.copy();
        vector D_eigen3 = D_eigen.copy();

        var A_eigen4 = A_eigen3.copy();
        matrix V_eigen4 = V_eigen.copy();
        vector D_eigen4 = D_eigen.copy();

        WriteLine("");
        WriteLine($"Finding {k} lowest eigenvalues");
        A_eigen3.print("Random symmetric matrix, A1:");
        WriteLine("");
        var sweeps_eigen1 = jac_diag.first_eigen(A_eigen3, V_eigen3, D_eigen3, k, true);
        WriteLine($"{k} lowest eigenvalues found in {sweeps_eigen1} sweeps:");
        D_eigen3.print(k,"");
        WriteLine("Eigenvalues found by cyclic sweep");
        var sweeps_eigen2 = jac_diag.cyclic_sweep(A_eigen4, V_eigen4, D_eigen4);
        sweeps_eigen2++; // Removes warning
        D_eigen4.print(k,"");
        WriteLine("Indeed a match");
        WriteLine("");

        WriteLine("Finding largest eigenvalues");
        A_eigen.print("Random symmetric matrix, A2:");
        

        var A_eigen2 = A_eigen.copy();
        matrix V_eigen2 = V_eigen.copy();
        vector D_eigen2 = D_eigen.copy(); 

        var sweeps_eigen = jac_diag.first_eigen(A_eigen, V_eigen, D_eigen, k, false);
        WriteLine($"Largest {k} eigenvalues found in {sweeps_eigen} sweeps:");
        D_eigen.print(k,"");
        WriteLine("");
        var sweeps_eigen_cyclic = jac_diag.cyclic_sweep(A_eigen2, V_eigen2, D_eigen2);
        sweeps_eigen_cyclic++; // Removes warning
        D_eigen2.print("Eigenvalues found with cyclic sweep:");
        WriteLine($"Indeed the last {k} matches.");
        WriteLine("");
        WriteLine("To find the largest eigenvalues I've changed the argument in Atan2");
        WriteLine("into (Apg, App - Aqq) ");

        
        StreamWriter outputB1 = new StreamWriter("outB1.data", append:false);

        Stopwatch sw = new Stopwatch();
        Stopwatch sw2 = new Stopwatch();
        sw.Start();
        sw2.Start();

        // Part B1 - O(n^3) dependence

        for(int n = 20; n < 221; n+= 20 ){

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








        return 0;
    }
}