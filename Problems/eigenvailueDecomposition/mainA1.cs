using System;

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
        var (D,V,sweeps) = jac_diag.cyclic_sweep(M);
        matrix temp2 = V.T*M2*V;
        Console.WriteLine($"Total number of sweeps = {sweeps}");
        temp2.print("V.T*M*V = ");
        D.print("Eigenvalues = ");
        M.print("To check that it's only changed the upper triangle, M = ");


        return 0;
    }
}