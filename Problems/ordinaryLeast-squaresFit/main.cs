using System;
using static System.Math;
using System.IO;

class main{
    public static int Main(){

        // Creating data
        var t = new vector(new double[] {1,2,3,4,6,9,10,13,15});
        var y = new vector(new double[] {117, 100, 88, 72, 53, 29.5, 25.2, 15.2, 11.1});
        var dy = new vector(new double[] {117.0/20, 100.0/20, 88.0/20, 72.0/20, 53.0/20, 29.5/20, 25.2/20, 15.2/20, 11.1/20});
        Func<double,double>[] f = {(x) => 1, (x) => x};

        var lny = new vector(y.size);
        var lndy = new vector(dy.size);

        // Converting into ln 
        for(int i = 0; i < lny.size; i++){
            lny[i] = Log(y[i]);
            lndy[i] = dy[i]/y[i];
        }

        // Fitting linearly
        var (c,S) = ols_fitter.lsfit(t,lny,lndy,f);


        Console.Error.WriteLine($"Calculated coefficients:");
        for(int i = 0; i < c.size; i++){ 
        Console.Error.WriteLine($"c[{i}] = {c[i]:f5}");
        }
        Console.Error.WriteLine($@"So \lambda = {-c[1]:f5} (t_1/2 = {-Log(2)/c[1]}), litterature value for 
        today is \lambda = 0.191 (t_1/2 = 3.6319), so af deviation of ~10%.");

        Console.Error.WriteLine("Covariance matrix S:");
        for(int i = 0; i < S.size1; i++){ 
            for(int j = 0; j< S.size2; j++ ){
                Console.Error.WriteLine($"S[{i},{j}] = {S[i,j]:f5}");
            }
        }
        Console.Error.WriteLine("The uncertainty of the half life (t_{1/2} = ln(2)/lambda):");
        Console.Error.WriteLine($"delta_t_(1/2) = ln(2)/(lamda^2) * deltaLambda = {Log(2)/Pow(c[1],2) * Sqrt(S[1,1]):f5}");
        Console.Error.WriteLine("The uncertainty does thus not reach todays litterature value.");

        // Sending data to output
        StreamWriter outData = new StreamWriter("outData.txt", append:false);
        StreamWriter outFitData = new StreamWriter("outFitData.txt", append:false);

        for(int i = 0; i < t.size; i++){
            outData.WriteLine("{0} {1} {2}",t[i], y[i], dy[i]);
        }
        int n = 50; 
        double a = t[0], b  = t[t.size-1];
        var resy = new vector(n);
        var rest = new vector(n);
        var resyPlus = new vector(n);
        var resyMinus = new vector(n);
        for(int i = 0; i < n; i++){
            rest[i] = a + i * b/n;
            resy[i] = Exp(c[0] + c[1] * rest[i]); // Exponentiating
            resyPlus[i] = Exp(c[0]+Sqrt(S[0,0]) + (c[1]+Sqrt(S[1,1])) * rest[i]);
            resyMinus[i] = Exp(c[0]-Sqrt(S[0,0]) + (c[1]-Sqrt(S[1,1])) * rest[i]);
            outFitData.WriteLine("{0} {1} {2} {3}", rest[i], resy[i], resyPlus[i], resyMinus[i]);
        }
        outData.Close();
        outFitData.Close();



        return 0;
    }

}