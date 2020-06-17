using System;
using static System.Console;
using static System.Math;
using System.IO;

public class mainA2{
    public static int Main(){
        StreamWriter eigenenergies = new StreamWriter("energies.txt", append:false);
        StreamWriter outData = new StreamWriter("outA2.data", append:false);
        int n = 99;
        double s=1.0/(n+1);
        matrix H = new matrix(n,n);
        for(int i=0;i<n-1;i++){
            matrix.set(H,i,i,-2);
            matrix.set(H,i,i+1,1);
            matrix.set(H,i+1,i,1);
        }
        matrix.set(H,n-1,n-1,-2);
        matrix.scale(H,-1/s/s);
        
        vector D = new vector(n);
        matrix V = new matrix(n,n);
        eigenenergies.WriteLine("n       calc                    exact");
        int sweeps = jac_diag.cyclic_sweep(H, V, D);
        for (int k=0; k < n/3; k++){
            double exact = PI*PI*(k+1)*(k+1);
            double calculated = D[k];
            eigenenergies.WriteLine($"{k}       {calculated}        {exact}");
        }

        for(int k=0;k<4;k++){
            outData.WriteLine($"{0} {0}");
            for(int i=0;i<n;i++){
                double factor = Sign(V[0,k]);
                outData.WriteLine($"{(i+1.0)/(n+1.0)} {V[i,k]*factor/Sqrt(s)}");
            }
            outData.WriteLine($"{1} {0}");
            outData.WriteLine("");
         }

        outData.Close();
        eigenenergies.Close();

        return 0;
    }
}