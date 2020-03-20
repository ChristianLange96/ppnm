using System;

public class cspline {
	vector x,y,b,c,d,dx;
	public cspline(vector xs,vector ys){
            x = new vector(xs.size);
            y = new vector(ys.size);
            c = new vector(xs.size-1);
            b = new vector(xs.size-1);
            d = new vector(xs.size-1); // Not sure of size?
            dx = new vector(xs.size-1);

    		}
    
    public double spline(double z){
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

        return y[i] + b[i] * (z-x[i]) + c[i] * Math.Pow(z-x[i],2) + d[i] * Math.Pow(z-x[[i],3]);
    }


	public double derivative(double z){
       if( z<x[0] || z>x[x.size-1])  // Checking for z to be within the interval
            throw new System.ArgumentException($"z = {z} has to be within the provided interval [{x[0]}, {x[x.size-1]}].");

        int i = 0;             // Indicating where in the x-vector we are.
        double res = 0;
        while( z > x[i+1]){
            i++;
        }
        res += b[i] + 2 * c[i] * (z-x[i]) + 3 * d[i] * Math.Pow(z-x[i],2); 
        return res; 
    }   
    
    public double integral(double z){
        if( z<x[0] || z>x[x.size-1])  // Checking for z to be within the interval
            throw new System.ArgumentException($"z = {z} has to be within the provided interval [{x[0]}, {x[x.size-1]}].");

        int i = 0;             // Indicating where in the x-vector we are.
        double res = 0;
        while( z > x[i+1]){
            res += y[i] * dx[i] + 0.5 * b[i] * Math.Pow(dx[i],2) + 1.0/3.0 * c[i] * Math.Pow((dx[i]),3) + 1.0/4.0 * d[i] * Math.Pow(dx[i],4);
            i++;
        }
        res += y[i]*(z-x[i]) + 0.5 * b[i] * Math.Pow((z - x[i]),2) + 1.0/3.0 * c[i] * Math.Pow(z-x[i],3) + 1.0/4.0 * d[i] * Math.Pow(z-x[i],4);
        return res;
    }
	}