using System; 
using static System.Console; 
using static System.Math;
//using System.Collections.Generic;
using static vector;
using static matrix;

public class minimizer{

public static double EPS=1.0/4194304;

    public static vector gradient(Func<vector, double> f, vector x){
        vector res = new vector(x.size);
        vector xtemp;


        for(int i = 0; i < x.size; i++ ){
		    double dx = Abs(x[i]) * EPS;
		    if(Abs(x[i]) < Sqrt(EPS)) dx = EPS;
            xtemp = x.copy();
            xtemp[i] += dx;
            res[i] = (f(xtemp) - f(x))/dx;
        }
        return res;
    }

    public static int qnewton_min(Func<vector,double> f, ref vector x, double eps=1e-3){  
        // Creating inverse Hessian Matrix
        int n = x.size;
        matrix B = new matrix(n,n);
        B.set_unity();
                
        // Starting values
        double fx = f(x);
        vector gx = gradient(f,x);
        vector DelX;

        int counts = 0;
        do{
            counts++;
            DelX = -B * gx;

            // Back-tracking linesearch
            double fz, lam = 1.0;
            while(true){
                fz = f(x + lam * DelX);    
                if( fz < fx) break; // Step accepted
                if(lam < EPS){
                    B.set_unity();
                    break;          // Step accepted anayway since lamda got too small - not converging.
                }
                lam = lam/2;
            }
            // Calculating new values 
            vector s = lam * DelX;
            vector gz = gradient(f, x + s); 
            vector y = gz - gx;
            vector u = s - B * y;
            double udoty = u.dot(y);
            if( Abs(udoty) > 10e-6){      //Check denominator is not too small
                B = B +  outer(u, u) * 1/udoty;
            }
            x += s;
            gx = gz;
            fx = fz;
        } while(gx.norm() > eps && DelX.norm() > EPS * x.norm() && counts < 999);
        return counts;
    }    
}