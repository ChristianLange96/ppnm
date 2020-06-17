using static System.Math;
using System;

public class adaptive_integrator{

    static double integratorRec(Func<double,double> f, double a, double b, ref double accError, double acc, double eps, double f2, double f3){
        // Calculating the two new end points:
        double f1 = f(a+(b-a)/6.0); 
        double f4 = f(a+5.0*(b-a)/6);
        // Quadrotures
        double Q = (2.0 * f1 + f2 + f3 + 2.0 * f4)/6 * (b-a);
        double q = (f1 + f2 + f3 + f4)/4.0 * (b-a);
        double tol = acc + eps * Abs(Q);
        double err = Abs(Q-q); 
        if (err < tol) {accError += err; return Q;}
        else return integratorRec(f,a,(a+b)/2, ref accError, acc/Sqrt(2), eps, f1, f2)+
                    integratorRec(f,(a+b)/2,b, ref accError, acc/Sqrt(2),eps, f3, f4);
        }
    
    public static double integrator(Func<double,double> f, double a, double b, double acc, double eps){
        // Calculating f2 and f3
        double accError = 0;
        if(b <= a) {return -1.0 * integrator(f, b, a, ref accError, acc, eps);}
        else {return integrator(f, a, b, ref accError, acc, eps);}
    }


    public static double integrator(Func<double,double> f, double a, double b, ref double accError, double acc, double eps){
        // Calculating f2 and f3
        double f2 = f(a+2.0 * (b-a)/6), f3 = f(a + 4.0 *(b-a)/6);
        return integratorRec(f, a, b, ref accError,acc, eps, f2, f3);
    }

    public static double clenshaw_curtis(Func<double,double> f, double a, double b, double acc, double eps){
        // Chaning integral to be from -1 to 1 instead of 0 to 1:
        Func<double, double>  j = (x) =>  1.0/2 *(b-a)* f(1.0/2 * (a+b) + 1.0/2 * (b-a) *x);
        // Clenshaw Curtis substitution
        Func<double, double>  k = (theta) => j(Cos(theta))*Sin(theta);
        // Integrating with the substitution
        return integrator(k, 0, PI, acc, eps);
    }

    public static double infinite_limits(Func<double,double> f, double a, double b, ref double accError, double acc, double eps){
    // Chaning integral limits from -inf to inf into 0 to 1:
    Func<double, double> j = (t) => 1.0/Pow(t,2) * ( f((1.0-t)/t) + f(- (1.0-t)/t));
    return integrator(j, 0, 1, ref accError, acc,eps);
    }
    public static double infinite_upper_limit(Func<double,double> f, double a, double b, ref double accError, double acc, double eps){
    // Chaning integral limits from a to inf into 0 to 1:
    Func<double, double> j = (t) => f(a + (1.0-t)/t)/Pow(t,2);
    return integrator(j, 0, 1, ref accError, acc,eps);
    }

    public static double infinite_lower_limit(Func<double,double> f, double a, double b, ref double accError, double acc, double eps){
    // Chaning integral limits from a to inf into 0 to 1:
    Func<double, double> j = (t) => f(b - (1.0-t)/t)/Pow(t,2);
    return integrator(j, 0, 1, ref accError, acc,eps);
    }


}
