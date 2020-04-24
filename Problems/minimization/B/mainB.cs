using static System.Console;
using static System.Math;
using static minimizer;
using static vector;
using System;

public class mainB{

    static System.Collections.Generic.List<double> energy,signal,error;

    // Defining the function to me minimized
    public static double D (vector x){
        double m    = x[0];
        double gam  = x[1];
        double A    = x[2];
        double res  = 0;
        for(int i = 0; i < energy.Count; i++){
            res += Pow((BW(m, gam, A, energy[i]) - signal[i])/error[i],2);
        }
        return res;
    }

    public static double BW(double m, double gam, double A, double e){
        return A /(Pow(e-m,2) + Pow(gam,2)/4.0);
    }

    public static int Main(){
        // Creating lists with data
        energy = new System.Collections.Generic.List<double>();
        signal = new System.Collections.Generic.List<double>();
        error  = new System.Collections.Generic.List<double>();
        string energy_string = "101 103 105 107 109 111 113 115 117 119 121 123 125 127 129 131 133 135 137 139 141 143 145 147 149 151 153 155 157 159";
        string signal_string = "-0.25 -0.30 -0.15 -1.71 0.81 0.65 -0.91 0.91 0.96 -2.52 -1.01 2.01 4.83 4.58 1.26 1.01 -1.26 0.45 0.15 -0.91 -0.81 -1.41 1.36 0.50 -0.45 1.61 -2.21 -1.86 1.76 -0.50";
        string error_string  = "2.0 2.0 1.9 1.9 1.9 1.9 1.9 1.9 1.6 1.6 1.6 1.6 1.6 1.6 1.3 1.3 1.3 1.3 1.3 1.3 1.1 1.1 1.1 1.1 1.1 1.1 1.1 0.9 0.9 0.9";

        // Splitting up numbers
        string [] energy_arr = energy_string.Split(' ');
        string [] signal_arr = signal_string.Split(' ');  
        string [] error_arr = error_string.Split(' ');

        // Converting into doubles and added to lists
        for(int i = 0; i < energy_arr.Length; i++){
            energy.Add(Convert.ToDouble(energy_arr[i]));
            signal.Add(Convert.ToDouble(signal_arr[i]));
            error.Add(Convert.ToDouble(error_arr[i]));
        }
    
        // Giving start estimates
        vector x = new vector(120, 2, 6);
        int nsteps = qnewton_min(D, ref x, 1e-6);

        // Writing found values
        double m    = x[0];
        double gam  = x[1];
        double A    = x[2];
        WriteLine($"Number of steps     = {nsteps}");
        WriteLine($"Calculated mass     = {m:f6}");
        WriteLine($"Calculated gamma    = {gam:f6}");
        WriteLine($"Caluculated A       = {A:f6}");
        WriteLine($"D-func minimized to = {Sqrt(D(x)/energy.Count):f6}");
        WriteLine("");
        WriteLine("");

        // Writing data
        for(int i = 0; i < energy.Count; i++) {
            WriteLine($"{energy[i]} {signal[i]} {error[i]}");
        }
        WriteLine("");
        WriteLine("");

        for(double i = 101.0 ; i <= 159.0; i += 0.1){
            WriteLine($"{i} {BW(m, gam, A, i)}");
        }

        return 0;
    }
}