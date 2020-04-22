using System; 
using static System.Console; 
using static System.Math;
//using System.Collections.Generic;
using static vector;
using static qr_gs;

public class rootFinder{
    public static vector newton(Func<vector,vector> f, vector x, double epsilon=1e-3,double dx=1e-7) {
        int n = x.size;
        vector xtemp;
        vector dfdx = new vector(n);
        vector DelX;
        matrix J = new matrix(n, n);

        // Running until converging
        do{
            // Calculating Jacobian matrix
            for(int k = 0; k < n; k++){
                xtemp = x.copy();
                xtemp[k] = xtemp[k] + dx;
                dfdx = (f(xtemp) - f(x))/dx;
                for(int i = 0; i < n; i++){
                    J[i,k] = dfdx[i];
                }
            }
            //Solving J \Delta x =  - f(x)
            matrix R = new matrix(n,n);
            qr_gs_decomp(J,R);
            DelX = qr_gs_solve(J,R, -1.0 * f(x));

            // Finding right lambda until converged
            double lam = 1.0;
            while(f(x + lam * DelX).norm() > (1 - lam/2) * f(x).norm() && lam >= 1.0/64 ){
                lam = lam/2;
            }
            x = x + lam * DelX;
            // Stop if converged, otherwise continue for udpated x
        } while(f(x).norm() > epsilon && max(abs(DelX)) > dx);
        return x;
    } 
}