using static System.Math;
using System;
using static rootFinder;

public class Symm_RankOne{

    public static vector symm_update(matrix D, vector u){
        // I take the elements as matrix/vector as a way to store them,
        // such that my root-finding routine is appropriate to use. 
        //I assume D is a diagonal matrix.
        // I take \sigma to be +1 as written in the assignment text compared to the PDF.

        // First I need to find the nonzero elements in u and save the corresponding elements in D 
        int n = u.size; // Number of elements in total
        
        double [] zero_elem     = new double[n];    // Elements in D that should not be updated
        double [] nonzero_elem  = new double[n];    // Elements in D that should be updated
        int [] index            = new int[n];       // Saving index of non-zero elements

        int z = 0; // To keep track of where in the array we are. 
        int m = 0; // It follows that z + m = n-1 after the loop

        for(int i = 0; i < n; i++){
            if (u[i] == 0){
                zero_elem[z] = D[i,i]; // This eigenvalue should not be updated
                z++;
            }
            else{
                nonzero_elem[m] = D[i,i]; // This eigenvalue should be updated
                index[m] = i;
                m++;
                
            }
        }
        if(m == 0){     // This means that all elements in u are zero and we should not update
            vector res = new vector(n);
            for(int i = 0; i < n; i++){
                res[i] = zero_elem[i];  // All elements in D are thus returned straight away.
            }
            Console.WriteLine("From routine: All elements in u are zero: No need to update eigenvalues!");
            return res;
        }

        // Function to be zeroed - I take one eigenvalue at a time,
        // as they are independent of each other.
        Func<vector,vector> f  = (l) => {
            vector res = new vector(1);
            res[0] = 1;
            for(int i = 0; i < m; i++){
                int k = index[i];   // Making sure that we take the non-zero elements of u.
                res[0] += u[k]*u[k]/(nonzero_elem[i]-l[0]);
            }
            return res;
        };

        // Creating start vector for root-finder. I take each lambda to be the middle
        // point between the eigenvalues of D, as suggested by eqs. 22 and 23 in the PDF.
        // I assmume D is sorted.

        vector lams = new vector(m);

        for(int i = 0; i < m-1; i++){
            int k = index[i];
            lams[i] = 0.2 * D[k,k] + 0.8 *D[k+1,k+1];//This 'weighting' seemed to work the best.
        }
        // Checking if lams[m-1] is the last eigenvalue or not
        int j = index[m-1];
        if(j == m-1) {lams[j] = (D[j, j] + u.dot(u));}          // The last eigenvalue
        else {lams[j-1] = 0.2 * D[j,j] + 0.8 * D[j+1, j+1];}    // not the last eigenvalue
     
        // Now my root-finding routine can be called to find the eigenvalues:
        for(int i = 0; i < m; i++){
            vector temp = new vector(1);
            temp[0] = lams[i];
            vector eigen = newton(f, temp, 1e-12, 1e-10);
            zero_elem[z] = eigen[0]; // Putting new eigenvalues into the already found
            z++;
        }
        Array.Sort(zero_elem); // Returning eigenvalues in correct order.
        vector res_vec = new vector(n); // Vector to return as result
        for(int i = 0; i < n; i++){
            res_vec[i] = zero_elem[i];
        }
        return res_vec;
    }

    public static matrix sorted_diag_matrix(int n){ // n: Size of matrix
        var rand = new Random();
        double [] temp = new double[n];
        matrix A = new matrix(n,n);
        for(int i = 0; i < n; i++) temp[i] = 5 * (rand.NextDouble() - 0.5);
        Array.Sort(temp);
        for(int j = 0; j < n; j++) A[j,j] = temp[j];
        return A;
    }

    public static vector rnd_vector(int n){
        var rand = new Random();
        vector b = new vector(n);
        for(int i = 0; i< n; i++) b[i] = 5 * (rand.NextDouble() - 0.5) ;
        return b;
    }
}