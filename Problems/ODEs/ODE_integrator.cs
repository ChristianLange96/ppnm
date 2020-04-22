using System; 
using static System.Math;
using System.Collections.Generic;

public class ODE_integrator{

    public static vector[] rkstep12(Func<double, vector, vector> f, double t, vector yt, double h){ 
        vector k0  = f(t, yt);
        vector k12 = f(t + 0.5 * h, yt + 0.5 * h * k0);
        vector k =  k12;
        vector yh = yt + h * k;
        vector err = (k12 - k0);
        vector[] res = {yh, err * h};
        return res;
    }

        public static vector[] rkstep45(Func<double, vector, vector> f, double t, vector yt, double h){ 
        vector k1 = f(t, yt);
        vector k2 = f(t + 0.25 * h, yt + h * 0.25 * k1);
        vector k3 = f(t + 3.0/8 * h, yt + h *(3.0/32 * k1 + 9.0/32 * k2));
        vector k4 = f(t + 12.0/13 * h, yt + h * (1932.0/2197 * k1 - 7200.0/2197 * k2 + 7296.0/2197 * k3 ));
        vector k5 = f(t + h, yt + h * (439.0/216 * k1 - 8.0 * k2 + 3680.0/513 * k3 - 845.0/4104 * k4));
        vector k6 = f(t + 0.5 * h, yt + h * (-8.0/27 * k1 + 2.0 * k2 - 3544.0/2565 * k3 + 1859.0/4104 * k4 - 11.0/40 * k5));
        vector k_res = 16.0/135 * k1 + 6656.0/12825 * k3 + 28561.0/56430 * k4 -9.0/50 * k5 + 2.0/55 * k6; 
        
        vector err = (16.0/135 - 25.0/216) * k1 + (6656.0/12825 - 1408.0/2565) * k3 + (28561.0/56430 - 2197.0/4104) * k4 + (-9.0/50 + 1.0/5) * k5 + 2.0/55 * k6;
        vector [] res = {yt + k_res * h, err * h};

        return res;
    }

    public static vector driver(Func<double,vector,vector> f, double a, vector ya, double b, double h, double acc,double eps, 
        List<double> ts, List<vector> ys){  
        double t = a;
        vector yt = ya;
        ts.Clear();
        ys.Clear();
        ts.Add(a);
        ys.Add(ya);
        while(t < b) 
        {
            //Console.Error.WriteLine($"t = {t}");
            if ( t + h > b) {h = b - t;} //To ensure last step is at point b.

            vector[] step = rkstep45(f, t, yt, h);
            vector y_step = step[0];
            vector err_step = step[1];

            // Creating tolerance from y_step
            vector tol = new vector(y_step.size);
            for(int i = 0; i < tol.size; i++){
                tol[i] = (acc + eps * Abs(y_step[i])) * Sqrt(h / (b-a));
                if( err_step[i] == 0) err_step[i] = tol[i]/4;
            }

            // Now finiding worst error
            double worst = Abs(tol[0] / err_step[0]);
            
            for(int i = 1; i < tol.size; i++){
                worst = Min(worst, Abs(tol[i]/err_step[i]));
            }
            //Console.Error.WriteLine($"worst = {worst}");
            
            // Checking if step is accepted and adding it to the result
            if(worst > 1.0){   // Meaning that the worst parameter has tol > err --> Step accepted
                t += h; 
                yt = y_step; 
                ts.Add(t);
                ys.Add(y_step);
                //Console.Error.WriteLine($"Step accepted");
            }
            // Creating new step size
            double factor = Pow(worst, 0.25) * 0.95;
            //Console.Error.WriteLine($"factor = {factor}");
            if(factor > 2) factor = 2;
            h *= factor;
            //Console.Error.WriteLine($"h = {h}");
        }
        return yt;
    }   
}










  