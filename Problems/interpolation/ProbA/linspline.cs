using static System.Console;
public class linspline{
    static public double lspline(vector x, vector y, double z){
        if( z<x[0] || z>x[x.size-1])  // Checking for z to be within the interval
            throw new System.ArgumentException($"{z} has to be within the provided interval [{x[0]}, {x[x.size-1]}].");

        // Binary search
        int i = 0, j = x.size-1;
        while(j - i > 1){
            int m = (i+j)/2;
            if (z > x[m])
                i = m;
            else 
                j = m;
            }
        return y[i] + (y[i+1] - y[i])/(x[i+1]-x[i]) * (z-x[i]);
    }

    // Integrating from x[0] to z.
    static public double linerpInteg(vector x, vector y, double z){
        if( z<x[0] || z>x[x.size-1])  // Checking for z to be within the interval
            throw new System.ArgumentException($"z = {z} has to be within the provided interval [{x[0]}, {x[x.size-1]}].");

        int i = 0;             // Indicating where in the x-vector we are.
        double res = 0;
        while( z > x[i+1]){
            res += y[i] * (x[i+1]-x[i]) + 0.5 * (y[i+1]- y[i]) * (x[i+1] - x[i]);
            i++;
        }
        res += y[i]*(z-x[i]) + 0.5 * (y[i+1] - y[i])/(x[i+1] - x[i]) * (z - x[i]) * (z - x[i]);
        return res;
    }
}