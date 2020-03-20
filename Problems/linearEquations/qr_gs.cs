using static System.Math;
using System;

public class qr_gs{

    public static void qr_gs_decomp(matrix A, matrix R){
        for(int i = 0; i < A.size2; i++){
            R[i,i] = Sqrt(A[i].dot(A[i]));
            A[i] = A[i]/R[i,i];
            for(int j = i+1; j < A.size2; j++){
                R[i,j] = A[i].dot(A[j]);
                A[j] = A[j] - A[i] * R[i,j];
            }
        }
    }

    public static vector qr_gs_solve(matrix Q, matrix R, vector b){
        vector x = new vector(Q.T * b);
        for(int i = x.size-1; i >= 0; i--){
            double temp = x[i];
            for(int j = i + 1 ; j < x.size; j++){
                temp -= R[i,j] * x[j];
            }
            x[i] = temp/R[i,i];
        } 
        return x; 
    }

    public static matrix qr_gs_inverse(matrix Q, matrix R){
        matrix c = new matrix(Q.size1, Q.size2);
        c.set_identity();
        matrix B = new matrix(Q.size1, Q.size2);
        for(int m = 0; m < Q.size1; m++){
            B[m] = qr_gs_solve(Q,R,c[m]);
        }
        return B;
    }




}