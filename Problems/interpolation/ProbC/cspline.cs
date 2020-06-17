using System;

public class cspline {
	vector x, y, b, c, d, dx, dy;

	public cspline(vector xs,vector ys){
        x = xs;
        y = ys;
        
        // Creating h = dx, dy and p = dy/dx:
        dx = new vector(xs.size - 1);
        dy = new vector(xs.size - 1);
        vector p  = new vector(dy.size);

        for(int i = 0; i < dx.size; i++){
            dx[i] = xs[i+1] - xs[i];
            dy[i] = ys[i+1] - ys[i];
            p[i]  = dy[i]/dx[i];
        }

        // Now D is calculated
        vector D1 = new vector(xs.size);
        D1[0] = 2;
        D1[D1.size-1] = 2;
        for(int i = 0; i < D1.size-2; i++){
            D1[i+1] = 2 * dx[i]/dx[i + 1] + 2;
        }

        // Calculating Q
        vector Q = new vector(xs.size-1);
        Q[0] = 1;
        for(int i = 0; i < Q.size-1; i++){
            Q[i+1] = dx[i]/dx[i+1];
        }

        // Calculating B1
        vector B1 = new vector(x.size);
        B1[0] = 3 * p[0];
        B1[B1.size-1] = 3 * p[B1.size-2];
        for(int i = 0; i < B1.size-2; i++){
            B1[i+1] = 3 * (p[i] + p[i+1] * dx[i]/dx[i+1]);
        }

        // D-tilde is being calculated
        vector Dt = new vector(D1.size);
        Dt[0] = D1[0];
        for(int i = 1; i < D1.size; i++){
            Dt[i] = D1[i] - Q[i-1]/Dt[i-1];
        }

        // B-tilde is now being calculated
        vector Bt = new vector(B1.size);
        Bt[0] = B1[0];
        for(int i = 1; i < B1.size; i++){
            Bt[i] = B1[i] - Bt[i-1]/Dt[i-1];
        }

        //b's can now be calculated
        b = new vector(x.size);
        b[b.size-1] = Bt[b.size-1]/Dt[b.size-1];
        for(int i = b.size-2; i >= 0; i--){
            b[i] = (Bt[i] - Q[i] * b[i+1])/Dt[i];
        } 
        // c's and d's calculated:
        c = new vector(xs.size - 1);
        d = new vector(xs.size - 1);
        for(int i = 0; i < d.size; i++){
            c[i] = (-2 * b[i] - b[i+1] + 3*p[i])/dx[i];
            d[i] = (b[i] + b[i+1] - 2*p[i])/(dx[i] * dx[i]);
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

        return y[i] + b[i] * (z-x[i]) + c[i] * Math.Pow(z-x[i],2) + d[i] * Math.Pow(z-x[i],3);
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
        while(z > x[i+1]){
            res += y[i] * dx[i] + 0.5 * b[i] * Math.Pow(dx[i],2) + 1.0/3.0 * c[i] * Math.Pow((dx[i]),3) + 1.0/4.0 * d[i] * Math.Pow(dx[i],4);
            i++;
        }
        res += y[i]*(z-x[i]) + 0.5 * b[i] * Math.Pow((z - x[i]),2) + 1.0/3.0 * c[i] * Math.Pow(z-x[i],3) + 1.0/4.0 * d[i] * Math.Pow(z-x[i],4);
        return res;
    }
}