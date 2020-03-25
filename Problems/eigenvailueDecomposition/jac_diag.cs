using static System.Math;
using System;

public class jac_diag{

    static public (vector,matrix, int) cyclic_sweep(matrix A){
        vector D = new vector(A.size1);
        matrix V = new matrix(A.size1,A.size1);
        V.set_identity();
        int sweeps = 0; // Stores the number of sweeps before converging.

        // Creating D with diagonal equal to A
        for(int i = 0; i < A.size1; i++){
            D[i] = A[i,i];
        }
        vector old_D = D.copy();  
        double diff = 0;
        do{
            sweeps++;
            for(int p = 0; p < A.size1; p++){
                for(int q = p+1; q < A.size2; q++){
                    double phi = 0.5 * Atan2(2.0 * A[p,q],(D[q] - D[p]));
                    double s = Sin(phi);
                    double c = Cos(phi);
                    // Saving elements of q and p from previous A and V to calculation of the elements
                    vector Ap = A[p].copy();
                    vector Aq = A[q].copy();
                    vector Vq = V[q].copy();
                    vector Vp = V[p].copy(); 
                    Ap[p] = D[p];
                    Aq[q] = D[q];

                    // Replacing part of vector under the diagonal 
                    // with the part over the diagonal since only upper part is changed from
                    // the previous loop.
                    for(int j = p+1; j < A.size1; j++)
                        Ap[j] = A[p,j];
                        
                    for(int j = q+1; j < A.size1; j++)
                        Aq[j] = A[q,j];

                    // Calculating elements in  A'
                    
                    for(int i = 0; i < A.size1; i++){
                        if(i<p)
                            A[i,p] = c * Ap[i] - s * Aq[i];
                        if (i>p)
                            A[p,i] = c * Ap[i] - s * Aq[i];
                        if(i<q)
                            A[i,q] = s * Ap[i] + c * Aq[i];
                        if (i>q)
                            A[q,i] = s * Ap[i] + c * Aq[i];
                        V[i,p] = c * Vp[i] - s * Vq[i];
                        V[i,q] = s * Vp[i] + c * Vq[i];
                    }

                    D[p] = c*c * Ap[p] - 2*s*c*Ap[q] + s*s * Aq[q];
                    D[q] = s*s * Ap[p] + 2*s*c*Ap[q] + c*c * Aq[q];
                    A[p,q] = s*c* (Ap[p] - Aq[q]) + (c*c - s*s) * Ap[q];
                }
            }

            vector diff_D = D - old_D;
            old_D = D.copy();
            diff = 0;
            for(int i = 0; i < diff_D.size; i++){
               diff += Abs(diff_D[i]);
            }
        } 
        while(diff != 0);

        return (D,V,sweeps);
    }

    static public (vector, matrix, int) lowest_eigen(matrix A, int n){
       
        vector D = new vector(A.size1);
        matrix V = new matrix(A.size1,A.size1);
        V.set_identity();
        int sweeps = 0; // Stores the number of sweeps before converging.

        // Creating D with diagonal equal to A
        for(int i = 0; i < A.size1; i++){
            D[i] = A[i,i];
        }
        vector old_D = D.copy();  
        double diff = 0;
        for(int p = 0; p < n; p++){
            do{
                sweeps++;
                
                    for(int q = p+1; q < A.size2; q++){
                        double phi = 0.5 * Atan2(2.0 * A[p,q],(D[q] - D[p]));
                        double s = Sin(phi);
                        double c = Cos(phi);
                        // Saving elements of q and p from previous A and V to calculation of the elements
                        vector Ap = A[p].copy();
                        vector Aq = A[q].copy();
                        vector Vq = V[q].copy();
                        vector Vp = V[p].copy(); 
                        Ap[p] = D[p];
                        Aq[q] = D[q];

                        // Replacing part of vector under the diagonal 
                        // with the part over the diagonal since only upper part is changed from
                        // the previous loop.
                        for(int j = p+1; j < A.size1; j++)
                            Ap[j] = A[p,j];
                            
                        for(int j = q+1; j < A.size1; j++)
                            Aq[j] = A[q,j];

                        // Calculating elements in  A'
                        
                        for(int i = 0; i < A.size1; i++){
                            if(i<p)
                                A[i,p] = c * Ap[i] - s * Aq[i];
                            if (i>p)
                                A[p,i] = c * Ap[i] - s * Aq[i];
                            if(i<q)
                                A[i,q] = s * Ap[i] + c * Aq[i];
                            if (i>q)
                                A[q,i] = s * Ap[i] + c * Aq[i];
                            V[i,p] = c * Vp[i] - s * Vq[i];
                            V[i,q] = s * Vp[i] + c * Vq[i];
                        }

                        D[p] = c*c * Ap[p] - 2*s*c*Ap[q] + s*s * Aq[q];
                        D[q] = s*s * Ap[p] + 2*s*c*Ap[q] + c*c * Aq[q];
                        A[p,q] = s*c* (Ap[p] - Aq[q]) + (c*c - s*s) * Ap[q];
                    }
                
                vector diff_D = D - old_D;
                old_D = D.copy();
                diff = 0;
                for(int i = 0; i < diff_D.size; i++){
                    diff += Abs(diff_D[i]);
                }
            } while(diff != 0);
        } 
        vector D_res = new vector(n);
        matrix V_res = new matrix(A.size1,n);
        for(int i = 0; i < n; i++){
            D_res[i] = D[i];
            V_res[i] = V[i];
        }


        return (D_res,V_res,sweeps);
    }
}