using static System.Console;
using static jac_diag;
using static Symm_RankOne;
using static matrix;
using System;

public class main_eigen{
    public static int Main(){

        // Creating random matrix and vector:
        int n = 5; // Size of vector and matrix
        matrix D = sorted_diag_matrix(n);
        vector u = rnd_vector(n);

        
        vector d2 = new vector(n);
        matrix v2 = new matrix(n,n);

        D.print("Matrix D (assumed to be sorted) = ");
        WriteLine("");
        u.print("Vector u = ");
        matrix A = D + outer(u,u);
        matrix M2 = A.copy();
        WriteLine("");
        A.print("And hence matrix A =");
        WriteLine("");
        WriteLine("Now finding eigenvalues.");
        vector eigens = symm_update(D, u);
        eigens.print("Eigenvalues are =                     ");

        int sweeps = cyclic_sweep(M2,v2,d2);
        sweeps++; // To remove warning
        d2.print("Eigenvalues found with cyclic sweep = ");
        WriteLine("");
        v2.print("Corresponding eigenvectors found with old routine:");
        WriteLine("");
        
        
        WriteLine("-- Now for some zero-elements in u --");
        vector u3  = rnd_vector(n);
        u3[1] = 0;
        u3[4] = 0;
        WriteLine("");
        u3.print("u = ");
        matrix D3 = sorted_diag_matrix(n);
        WriteLine("");
        D3.print("D = ");
        matrix A3 = D3 + outer(u3,u3);
        WriteLine("");
        A3.print("Matrix A is then = ");
        matrix M3 = A3.copy();
        vector d3 = new vector(n);
        matrix v3 = new matrix(n,n);
        vector eigens3 = symm_update(D3,u3);
        WriteLine("");
        eigens3.print("Eigenvalues are =                     ");
        int sweeps3 = cyclic_sweep(M3,v3,d3 );
        sweeps3++; // Removes warning
        d3.print("Eigenvalues found with cyclic sweep = ");
        WriteLine("");


        WriteLine("-- Now for all elements in u equal to zero --");
        vector u4  = new vector(n);
        WriteLine("");
        u4.print("u = ");
        matrix D4 = sorted_diag_matrix(n);
        WriteLine("");
        D4.print("D = ");
        matrix A4 = D4 + outer(u4,u4);
        WriteLine("");
        A4.print("Matrix A is then = ");
        matrix M4 = A4.copy();
        vector d4 = new vector(n);
        matrix v4 = new matrix(n,n);
        vector eigens4 = symm_update(D4,u4);
        WriteLine("");
        eigens4.print("Eigenvalues are =                     ");
        int sweeps4 = cyclic_sweep(M4,v4,d4 );
        sweeps4++; // Removes warning
        d4.print("Eigenvalues found with cyclic sweep = ");





        
        




        return 0;
    }




}