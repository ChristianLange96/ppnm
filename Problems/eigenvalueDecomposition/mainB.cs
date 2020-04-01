using System;
using System.Diagnostics;
using System.IO;
using static System.Math;


public class mainB{
    public static int Main(){
        StreamWriter outputB1 = new StreamWriter("outB1.data", append:false);
        StreamWriter outputB3 = new StreamWriter("outB3.data", append:false);
        
        var rnd = new Random(1);
        int N = 20;        // Max size of matrix
        int n0 = 15;        // Starting matrix size

        for(int n = n0; n < N; n+= 100 ){
            Stopwatch sw = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();
            Stopwatch sw3 = new Stopwatch();
            var Arnd = new matrix(n,n);
            for(int i = 0; i < n; i++){
                for(int j = 0; j < n; j++){
                    Arnd[i,j] = 4 * rnd.NextDouble() - 1.5;
                    Arnd[j,i] = Arnd[i,j];
                 }
            }
            matrix V = new matrix(n,n);
            vector D = new vector(n);

            matrix V2 = V.copy();
            vector D2 = D.copy();
            matrix Arnd2 = Arnd.copy();

            matrix V4 = V.copy();
            vector D4 = D.copy();
            matrix Arnd4 = Arnd.copy();

            sw.Start();
            var sweeps = jac_diag.cyclic_sweep(Arnd, V, D);
            sw.Stop();

            sw2.Start();
            var sweeps2 = jac_diag.lowest_eigen(Arnd2, V2, D2, 1);
            sw2.Stop();

            sw3.Start();
            var sweeps3 = jac_diag.lowest_eigen(Arnd4, V4, D4, n);
            sw3.Stop();

            outputB1.WriteLine("{0} {1} {2}", Log(n), Log(sw.ElapsedMilliseconds), 3 * (Log(n) - Log(n0)));
            outputB3.WriteLine("{0} {1} {2} {3}", n, Log(sw.ElapsedMilliseconds), Log(sw2.ElapsedMilliseconds), Log(sw3.ElapsedMilliseconds));
        }

        outputB1.Close();
        outputB3.Close();


        //StreamWriter outputB2 = new StreamWriter("outB2.txt", append:false);
        int s = 5; // Size of quadratic matrix M.
        Console.WriteLine("Part B2");
        matrix M = new matrix(s,s);

        for(int i = 0; i < s; i++){
            for(int j = 0; j < s; j++){
                M[i,j] = 4 * rnd.NextDouble() - 1.5;
                M[j,i] = M[i,j];
            }
        }
        matrix M3 = M.copy();
        matrix M4 = M.copy();
        matrix M5 = M.copy();
        int m = 1; // Number of wanted lowest eigenvalues 
        M.print("Random matrix M = ");
        Console.WriteLine("");
        Console.WriteLine("All eigenvalues and eigenvectors calculated with method implemented in part A:");
        matrix V1 = new matrix(s,s);
        vector D1 = new vector(s);
        var sweep1 = jac_diag.cyclic_sweep(M, V1, D1);
        D1.print("All eigenvalues:");
        V1.print("Corresponding eigenvectors:");

        Console.WriteLine("");
        Console.WriteLine($"Now using method implimented in part B only {m} eigenvalues and eigenvectors are calculated:");
        matrix V3 = new matrix(s,s);
        vector D3 = new vector(s);

        var sweep2 = jac_diag.lowest_eigen(M3, V3, D3, m);
        D3.print(m, $"{m} lowest eigenvalues:");
        var temp2 = V3.T*M4*V3;
        temp2.print($"{m} rows should be zeroed:");

        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Part B3 and B4");
        Console.WriteLine("See plotB3.svg");
        Console.WriteLine("");

        Console.WriteLine("Part B5");

        M5.print("Random matrix M5 = ");
        vector D5 = new vector(M5.size1);
        matrix V5 = new matrix(M5.size1, M5.size2);
        int sweeps5 = jac_diag.cyclic_sweep_highest_first(M5, V5, D5);
        matrix temp5 = V5.T*M5*V5;
        Console.WriteLine("Now calculating the largest eigenvalue.")
        temp2.print("V.T*M*V = ");
        D5.print("Eigenvalues = ");
        Console.WriteLine("");
        Console.WriteLine("To get the largest eigenvalue first, I've changed the arguments in Atan2(a,b) to Atan2(-a,-b,).");


        

        return 0;
    }
}