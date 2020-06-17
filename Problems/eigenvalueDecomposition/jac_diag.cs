using static System.Math;
using System;

public class jac_diag{

    static public int cyclic_sweep(matrix A, matrix V, vector D){
        V.set_identity();
        int sweeps = 0; // Stores the number of sweeps before converging.
        bool changed;
        // Creating D with diagonal equal to diagonal of A
        for(int i = 0; i < A.size1; i++){
            D[i] = A[i,i];
        }

        do{
            changed = false;
            sweeps++;
            for(int p = 0; p < A.size1; p++){
                for(int q = p+1; q < A.size2; q++){
                    // New elements
                    double App = D[p];
                    double Aqq = D[q];
                    double Apq = A[p,q];
                    
                    // Calculating angle
                    double phi = 0.5 * Atan2(2.0 * Apq, Aqq - App);
                    double s = Sin(phi);
                    double c = Cos(phi);

                    double App_updated = c*c * App - 2*s*c*Apq + s*s * Aqq;
                    double Aqq_updated = s*s * App + 2*s*c*Apq + c*c * Aqq;

                    // Now checking if values have been changed. If so, the matrix elements are updated.
                    if(App_updated != App || Aqq_updated != Aqq){
                        D[p] = App_updated;
                        D[q] = Aqq_updated;
                        A[p,q] = 0.0;   // Effectively multiplying the angle
                        changed = true;
                    

                        // Now the rest of the elements are updated
                        for(int i = 0; i < p; i++){
                            double temp_p = A[i,p];
                            double temp_q = A[i,q];
                            A[i,p] = c * temp_p - s * temp_q;
                            A[i,q] = c * temp_q + s * temp_p;
                        }

                        for(int i = p+1; i < q; i++){
                            double temp_p = A[p,i];
                            double temp_q = A[i,q];
                            A[p,i] = c * temp_p - s * temp_q;
                            A[i,q] = c * temp_q + s * temp_p;
                        }

                        for(int i = q+1; i < A.size1; i++){
                            double temp_p = A[p,i];
                            double temp_q = A[q,i];
                            A[p,i] = c * temp_p - s * temp_q;
                            A[q,i] = c * temp_q + s * temp_p;
                        }

                        // Finally the eigenvectors are updated

                        for(int i = 0; i < A.size1; i++){
                            double temp_p = V[i,p];
                            double temp_q = V[i,q];
                            V[i,p] = c * temp_p - s * temp_q;
                            V[i,q] = c * temp_q + s * temp_p;
                        }
                    }
                }
            }
        } 
        while(changed);

    return sweeps;
    }

    static public int first_eigen(matrix A, matrix V, vector D, int n, bool low){ 
        V.set_identity();
        bool changed;
        int sweeps = 0; // Stores the number of sweeps before converging.

        // Creating D with diagonal equal to A
        for(int i = 0; i < A.size1; i++){
            D[i] = A[i,i];
        }

        for(int p = 0; p < n; p++){
            do{
                changed = false;
                for(int q = p+1; q < A.size2; q++){
                    // New elements
                    double App = D[p];
                    double Aqq = D[q];
                    double Apq = A[p,q];
                    double phi;
                    // Calculating angle
                    if(low) {phi = 0.5 * Atan2(2.0 * Apq, Aqq - App);}
                    else    {phi = 0.5 * Atan2(-2.0 * Apq, -Aqq + App);}
                    double s = Sin(phi);
                    double c = Cos(phi);

                    double App_updated = c*c * App - 2*s*c*Apq + s*s * Aqq;
                    double Aqq_updated = s*s * App + 2*s*c*Apq + c*c * Aqq;
                    //Console.Error.WriteLine($"{App_updated - App}");
                    // Now checking if values have been changed. If so, the matrix elements are updated.
                    if(App_updated != App || Aqq_updated != Aqq){
                        D[p] = App_updated;
                        D[q] = Aqq_updated;
                        A[p,q] = 0.0;   // Effectively multiplying the angle
                        changed = true;
                        sweeps++;
                    

                        // Now the rest of the elements are updated
                        for(int i = 0; i < p; i++){
                            double temp_p = A[i,p];
                            double temp_q = A[i,q];
                            A[i,p] = c * temp_p - s * temp_q;
                            A[i,q] = c * temp_q + s * temp_p;
                        }

                        for(int i = p+1; i < q; i++){
                            double temp_p = A[p,i];
                            double temp_q = A[i,q];
                            A[p,i] = c * temp_p - s * temp_q;
                            A[i,q] = c * temp_q + s * temp_p;
                        }

                        for(int i = q+1; i < A.size1; i++){
                            double temp_p = A[p,i];
                            double temp_q = A[q,i];
                            A[p,i] = c * temp_p - s * temp_q;
                            A[q,i] = c * temp_q + s * temp_p;
                        }

                        // Finally the eigenvectors are updated

                        for(int i = 0; i < A.size1; i++){
                            double temp_p = V[i,p];
                            double temp_q = V[i,q];
                            V[i,p] = c * temp_p - s * temp_q;
                            V[i,q] = c * temp_q + s * temp_p;
                        }
                    }
                }
                
            } while(changed);
        }    
    return sweeps;
    }

    public static matrix makeRnmSymMatrix(int n){
        var rand = new Random();
        matrix A = new matrix(n, n);
        for(int i = 0; i < n; i++){
            A[i, i] = rand.NextDouble();
        }
        for(int i = 0; i < n; i ++){
            for(int j = i + 1; j < n; j++){
                double elem = rand.NextDouble();
                A[i, j] = elem;
                A[j, i] = elem;
            }
        }
    return A;
    }
}