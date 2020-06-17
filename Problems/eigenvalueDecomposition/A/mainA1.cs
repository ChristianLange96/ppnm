using System;
using static System.Console;

public class mainA1{
    public static int Main(){
        int n = 5; // Size of quadratic matrix M.
        var rnd = new Random(1);
        Console.WriteLine("Part A1");
        matrix M = new matrix(n,n);
        for(int i = 0; i < n; i++){
            for(int j = 0; j < n; j++){
                M[i,j] = 4 * rnd.NextDouble() - 1.5;
                M[j,i] = M[i,j];
            }
        }
        matrix M2 = M.copy();
        M.print("Random matrix M = ");
        vector D = new vector(n);
        matrix V = new matrix(n,n);
        int sweeps = jac_diag.cyclic_sweep(M, V, D);
        matrix temp2 = V.T*M2*V;
        Console.WriteLine($"Total number of sweeps = {sweeps}");
        temp2.print("V.T*M*V  (should be diagonal)= ");
        WriteLine("Eigenvalues from D (should be the values in the diagonal)= ");
        D.print("");
        M.print("To check that only the upper triangle of M has been changed, M = ");


        return 0;
    }
}