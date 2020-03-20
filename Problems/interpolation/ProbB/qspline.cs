using System;

public class qspline {
	vector x,y,b,c,dx;
	public qspline(vector xs,vector ys){
            x = new vector(xs.size);
            y = new vector(ys.size);
            c = new vector(xs.size-1);
            b = new vector(xs.size-1);
            dx = new vector(xs.size-1);

            vector ps = new vector(xs.size-1);
            vector csForward = new vector(xs.size-1);
            vector csBackward = new vector(xs.size-1);
            csForward[0] = 0;
            csBackward[csBackward.size-1] = 0;
            for(int i = 0; i < xs.size; i++){
                x[i] = xs[i];
                y[i] = ys[i]; 
            }

            for(int i = 0; i < ps.size; i++){
                dx[i] = (xs[i+1] - xs[i]);
                ps[i] = (ys[i+1] - ys[i])/ (xs[i+1] - xs[i]);
            }
            
            for(int i = 0; i < csForward.size-1; i++){
                csForward[i+1] = 1/(xs[i+2]-xs[i+1]) * (ps[i+1]-ps[i] - csForward[i] * (xs[i+1] - xs[i])); 
            }
            for(int i = csBackward.size-2; i >= 0; i--){
                csBackward[i] = 1/(xs[i+1]-xs[i]) * (ps[i+1] - ps[i] - csBackward[i+1] * (xs[i+2] - xs[i+1]));
            }

            for(int i = 0; i < c.size; i++){
                c[i] = 0.5 * (csForward[i] + csBackward[i]); 
            }

            for(int i = 0; i < b.size; i++){
                b[i] = ps[i] - c[i] * dx[i];
            }


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

        return y[i] + b[i] * (z-x[i]) + c[i] * Math.Pow(z-x[i],2);
    }


	public double derivative(double z){
       if( z<x[0] || z>x[x.size-1])  // Checking for z to be within the interval
            throw new System.ArgumentException($"z = {z} has to be within the provided interval [{x[0]}, {x[x.size-1]}].");

        int i = 0;             // Indicating where in the x-vector we are.
        double res = 0;
        while( z > x[i+1]){
            i++;
        }
        res += b[i] + 2 * c[i] * (z-x[i]); 
        return res; 
    }   
    
    public double integral(double z){
        if( z<x[0] || z>x[x.size-1])  // Checking for z to be within the interval
            throw new System.ArgumentException($"z = {z} has to be within the provided interval [{x[0]}, {x[x.size-1]}].");

        int i = 0;             // Indicating where in the x-vector we are.
        double res = 0;
        while( z > x[i+1]){
            res += y[i] * dx[i] + 0.5 * b[i] * Math.Pow(dx[i],2) + 1.0/3.0 * c[i] * Math.Pow((dx[i]),3);
            i++;
        }
        res += y[i]*(z-x[i]) + 0.5 * b[i] * Math.Pow((z - x[i]),2) + 1.0/3.0 * c[i] * Math.Pow(z-x[i],3);
        return res;
    }
	}