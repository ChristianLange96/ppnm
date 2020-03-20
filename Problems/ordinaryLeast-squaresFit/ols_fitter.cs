using System;
using System.Collections.Generic;

public class ols_fitter{


    public static (vector,matrix) lsfit(vector xs, vector ys, vector dys, Func<double,double>[] fs){
        int n = xs.size;
        int m = fs.Length;
        matrix A = new matrix(n,m); // It should be n>m
        vector b = new vector(n);
        matrix R = new matrix(m,m);
        matrix R2 = new matrix(m,m);

        // Creating A and b
        for(int i = 0; i < n; i++){
            b[i] = ys[i]/dys[i];
            for(int k = 0; k < m; k++){
                A[i,k] = fs[k](xs[i])/dys[i];
            }
        }

        qr_gs.qr_gs_decomp(A,R); // A is now Q, R changed

        vector c = qr_gs.qr_gs_solve(A,R,b);
        qr_gs.qr_gs_decomp(R,R2); // R is now Q2, R2 changed
        matrix inverse_R = qr_gs.qr_gs_inverse(R,R2);
        matrix S = inverse_R * inverse_R.T;
        return (c,S);
    }







}