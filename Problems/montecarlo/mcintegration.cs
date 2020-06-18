using System; 
using static System.Console; 
using static System.Math;
using System.Collections.Generic;
using static vector;


public class montecarlo{
    static Random rand = new Random();
    public static vector randomx(vector a, vector b){
        vector x = new vector(a.size);
        for(int i = 0; i < x.size; i++){
            x[i] = a[i] + rand.NextDouble() * (b[i]-a[i]);
        }
        return x;
    }

    public static vector plainmc(Func<vector,double> f, vector a, vector b, int N){
        double V = 1; // Volume
        // Calculating total volume
        for(int i = 0; i < a.size; i++){
            V *= b[i] - a[i];
        }
        double sum = 0;         // Sum for result
        double var_sum = 0;     // Sum for err. est.
        for(int i = 0; i < N; i++){  
            double fx = f(randomx(a,b));
            sum += fx;
            var_sum += fx*fx;
        }
        double mean = sum/N;
        double sigma = Sqrt(var_sum/N - mean*mean); // sigma^2 = <(f_i)^2> - <(f_i)>^2
        return new vector(mean*V, V * sigma/Sqrt(N));   // mean = V<f> , error = V * sigma / sqrt(N)
    }
    
    public static vector stats(vector fxs){
        int n = fxs.size;
        double sum = 0;         // Sum for result
        double var_sum = 0;     // Sum for err. est.
        for(int i = 0; i < n; i++){  
            sum += fxs[i];
            var_sum += fxs[i] * fxs[i];
        }
        double avg = sum/n;
        double var = var_sum/n - avg*avg;
        return new vector(avg, var, n);
    }

        public static vector stats(List<double> fxs){
        int n = fxs.Count;
        double sum = 0;         // Sum for result
        double var_sum = 0;     // Sum for err. est.
        for(int i = 0; i < n; i++){  
            sum += fxs[i];
            var_sum += fxs[i] * fxs[i];
        }
        double avg = sum/n;
        double var = var_sum/n - avg*avg;
        return new vector(avg, var, n);
    }


    public static vector stratmc(Func<vector, double> f, vector a, vector b, double acc = 1e-3, double eps = 1e-3, int N = -1){
        if(N==-1) {N = 64 * a.size;}
        // N is the number of points added in each recursive call before error est.
        double V = 1; // Volume
        // Calculating total volume
        for(int i = 0; i < a.size; i++){
            V *= b[i] - a[i];
        }

        // Creating N points 
        vector fxs = new vector(N);
        for(int i = 0; i < N; i++){
            fxs[i] = f(randomx(a,b));
        }

        // Estimating avg and err
        vector currentstats = stats(fxs);
        
        vector res = strata(f, a, b, acc, eps, N, currentstats,V);

        return new vector(res[0], res[1]);

    }

    public static vector strata(Func<vector, double> f, vector a, vector b, double acc, double eps, int N, vector oldstats, double V){
        vector fxs = new vector(N);
        matrix xs  = new matrix(a.size, N);
        for(int i = 0; i < N; i++){
            xs[i] = randomx(a,b);
            fxs[i] = f(xs[i]);   
        }
        vector currentstats = stats(fxs);
        double integ = V * (currentstats[0] * N + oldstats[0] * oldstats[2])/(N+oldstats[2]);
        double sigma = V * Sqrt(currentstats[0] * currentstats[2] + oldstats[0] * oldstats[2])/(N + oldstats[2]);



        // Check if acceptable
        if( sigma < acc + eps * Abs(integ)) return new vector(integ, sigma, N + oldstats[2]);

        // Vectors to keep track of avg and err in each subdiv
        vector oldL = new vector(3);
        vector oldR = new vector(3);
        vector currentL;
        vector currentR;
        double var_max = -1.0;        // To keep track of the current maximal variance.
        int    dim_max = 0;           // Keep track of the dimension in which the largest variance. 
        List<double> vol1 = new List<double>();
        List<double> vol2 = new List<double>();


        for(int i = 0; i < a.size; i++){
            vol1.Clear();
            vol2.Clear();
            // Subdivide volume in dimension i into 2
            double splitter = (b[i] + a[i])/2.0;
            
            // Looping over all points to split them into two
            for(int j = 0; j < N; j++){
                if(xs[i,j] <= splitter){vol1.Add(fxs[j]);}
                else {vol2.Add(fxs[j]);}
            }
            // From these points est. the variances in each subdivision
            currentL = stats(vol1);
            currentR = stats(vol2);
            double v = Abs(currentL[0] - currentR[0]);
            if (v > var_max){
                var_max = v;
                dim_max = i;
                oldL = currentL;
                oldR = currentR;
            }
        }
  
        // Now the dimension with the largest variance is divided into two and called recursively
        vector a2 = a.copy();
        a2[dim_max] = (a[dim_max]+b[dim_max])/2.0;
        vector b2 = b.copy();
        b2[dim_max] = (a[dim_max]+b[dim_max])/2.0;

        vector resL = strata(f, a, b2, acc/Sqrt(2), eps, N, oldL, V/2.0);
        vector resR = strata(f, a2, b, acc/Sqrt(2), eps, N, oldR, V/2.0);
        double avg1 = resL[0];
        double err1 = resL[1];
        double avg2 = resR[0];
        double err2 = resR[1];

        return new vector(avg1 + avg2, Sqrt(err1 * err1 + err2 * err2));
    }
} 