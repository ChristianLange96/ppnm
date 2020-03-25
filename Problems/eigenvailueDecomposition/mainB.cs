using System;

public class mainB{
    public static int Main(){
        int n = 5; // Size of quadratic matrix M.
        var rnd = new Random(2);
        Console.WriteLine("Part B");
        matrix M = new matrix(n,n);
        for(int i = 0; i < n; i++){
            for(int j = 0; j < n; j++){
                M[i,j] = 4 * rnd.NextDouble() - 1.5;
                M[j,i] = M[i,j];
            }
        }
        matrix M2 = M.copy();
        int m = 3; // Number of wanted lowest eigenvalues 
        M.print("Random matrix M = ");
        Console.WriteLine("");
        Console.WriteLine("All eigenvalues and eigenvectors calculated with method implemented in part A:");
        var (D1,V1,sweep1) = jac_diag.cyclic_sweep(M);
        D1.print("All eigenvalues:");
        V1.print("Corresponding eigenvectors:");

        Console.WriteLine("");
        Console.WriteLine($"Now using method implimented in part B only {m} eigenvalues and eigenvectors are calculated:");
        var (D2,V2,sweep2) = jac_diag.lowest_eigen(M2,m);
        D2.print($"{m} lowest eigenvalues:");
        V2.print("Corresponding eigenvectors");
        M2.print($"To check, that only the {m} first rows have been calculated, M =  ");

        return 0;
    }
}