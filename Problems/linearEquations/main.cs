using static System.Console;
using static qr_gs;
class main{
    public static int Main(){
        WriteLine("Part A1");
        var rand = new System.Random();
        int m = 3 + rand.Next(5);
        int n = m + rand.Next(5);
        
        var A1 = get_random_matrix(n, m);
        var A1_copy = A1.copy();
        WriteLine("Creating random tall matrix of random dimensions:");
        A1.print("A1 = ");
        var R1 = new matrix(A1.size2, A1.size2);
        qr_gs.qr_gs_decomp(A1,R1); // A1 changed into Q, R changed
        WriteLine("");
        WriteLine("Decomposing into Q and R using GS-factorization:");
        A1.print("Decomp. Q = ");
        R1.print("Decomp. R1 = ");
        var temp = A1.T*A1;
        WriteLine("");
        WriteLine("Making sure Q^T*Q is equal to the identity matrix:");
        temp.print("Q^T*Q = ");
        temp = A1 * R1 - A1_copy;
        WriteLine("Checking that Q*R1-A1 = 0");
        temp.print("Q*R1 - A1 = ");
        Write("\n \n");


        WriteLine("Part A2: Solution to linear system, Ax = b.");        
        var A2 = get_random_matrix(m, m);
        WriteLine("Creating random square matrix, A2:");
        A2.print("A2 = ");
        var b = get_random_vector(m);
        WriteLine("Random vector b:");
        b.print("b = ");
        var R2 = new matrix(A2.size2, A2.size2);
        WriteLine("QR-factorisation");
        qr_gs.qr_gs_decomp(A2,R2); // A2 changed into Q2, R2 changed
        //A2.print("Q2 = ");
        //R2.print("R2 = ");
        vector x = qr_gs.qr_gs_solve(A2,R2,b);
        WriteLine("x, solution to equation:");
        x.print("x = ");
        WriteLine("Checking A*x-b = 0");
        var temp4 = A2 * R2 * x -b;
        temp4.print();

        Write("\n \n");
        WriteLine("Problem B");
        WriteLine("Creating random square matrix:");
        var B1 = get_random_matrix(m,m);
        var B1_copy = B1.copy();
        B1.print("B = ");
        WriteLine("Calculating inverse of A2 by QR-facorization");
        var R3 = new matrix(B1.size2, B1.size2);
        qr_gs_decomp(B1,R3);

        matrix B2 = qr_gs.qr_gs_inverse(B1,R3);
        WriteLine("Inverse og B:");
        B2.print("B^(-1) = ");
        WriteLine("Checking that B * B^(-1) = I:");
        var temp3 = B1_copy * B2;
        temp3.print("B^(-1) * B");

    return 0;
    }



}