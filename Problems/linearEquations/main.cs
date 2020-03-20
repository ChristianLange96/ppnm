using static System.Console;
class main{
    public static int Main(){
        WriteLine("Part A1");
        var A1 = new matrix("1 2 4;5 6 3;8 7 10;3 6 1;4 5 2");
        A1.print("A1 = ");
        var R1 = new matrix(A1.size2, A1.size2);
        R1.print("R (not initialized yet) = ");
        qr_gs.qr_gs_decomp(A1,R1); // A1 changed into Q, R changed
        A1.print("Q = ");
        R1.print("R1 = ");
        var temp = A1.T*A1;
        temp.print("Q^T*Q = ");
        temp = A1 * R1;
        temp.print("Q*R1 = ");
        Write("\n \n");
        WriteLine("Part A2");        
        var A2 = new matrix("1 1 1;0 2 5;2 5 -1");
        A2.print("A2 = ");
        var b = new vector(6,-4,27);
        var R2 = new matrix(A2.size2, A2.size2);
        R2.print("R2 = ");
        b.print("b = ");
        WriteLine("QR-factorisation");
        qr_gs.qr_gs_decomp(A2,R2); // A2 changed into Q2, R2 changed
        A2.print("Q2 = ");
        R2.print("R2 = ");
        vector x = qr_gs.qr_gs_solve(A2,R2,b);
        x.print("x = ");
        var Atemp = new matrix("1 1 1;0 2 5;2 5 -1");
        var temp2 = Atemp*x;
        temp2.print("A2*x = ");
        WriteLine("This is verified to be correct");
        Write("\n \n");
        WriteLine("Problem B");
        WriteLine("Calculating inverse of A2");
        matrix B2 = qr_gs.qr_gs_inverse(A2,R2);
        var temp3 = B2*Atemp;
        B2.print("A2^(-1) = ");
        temp3.print("A2^(-1) * A2");






    return 0;
    }



}