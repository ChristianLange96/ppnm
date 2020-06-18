Here is my solution for the exam.

Student number: 201706578
78 mod 22 = 12 -> I do exam problem nr. 12: 
Symmetric rank-1 update of a size-n symmetric eigenvalue problem

Comments:
    When comparing the exam question w. the 'eigen.pdf' I take \sigma = 0.
    I've tried to make comments in the code where it makes sense. 
    Since the equations are independent w respect to the different eigenvalues, 
    I've chosen to solve for one \lambda at a time,
    as it is more time effective due to the nature of the rootfinding-routine. 
    This could also have been done with all lambdas at a time, but this is not as time efficient nor as stable.

The files of interest are the following:

    Eigenvalues.txt:    This file shows that I create a matrix(n,n) on the form:
                        A = D + u * u^T, where D is a diagonal matrix and u is a a vector.
                        The I calculate the eigenvalues by using the symmetric update 
                        and compare it with the eigenvalues found by our previously implemented routine. 
                        I have also implemented special cases: One where some elements
                        in u are zero, and one where all elements
                        in u are zero. These speed up the calculations for big matrices.

    Plot_times.svg:     Here I plot the time it takes to find the eigenvalues as function
                        of matrix size n. This is fitted with the routine from gnuplot and
                        we see a good agreement to O(n^2).
                        It should me noted that the time can fluctuate depending on the matrix.
    
    Plot_comparison.svg:This is a comparison between this Rank 1 update - method and the cyclic
                        sweep - method. This is only done for matrices on the form:
                        A = D + u*u^T, where D is a diagonal matrix. It is clearly seen that the
                        Rank 1 update - method outperforms the cyclic sweep for these matrices.