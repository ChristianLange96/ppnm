using static System.Math;
using System;
using static rootFinder;

public class Symm_RankOne{

    public static vector symm_update(matrix D, vector u){
        // I take the elements as matrix/vector as a way to store them,
        // such that my root-finding routine is appropriate to use. 
        //I assume D is a diagonal matrix.
        // I take \sigma to be +1 as written in the assignment text compared to the PDF.
        int n = u.size;
        double [] res_array = new double[n]; // To save results.

        // Creating starting conditions
        vector lams = new vector(n);
        for(int i = 0; i < n-1; i++){
            lams[i] = 0.3 * D[i,i] + 0.7 * D[i + 1 ,i + 1]; //This 'weighting' seemed to work the best.
        }
        lams[n-1] = 0.3 * D[n-1, n-1] + 0.7 * (D[n-1, n-1] + u.dot(u));
        
        // Function to be zeroed. I take one at a time since the different eigenvalues 
        // are independent. This way is more efficient and stable, I've found. Also, 
        // it allows me to skip the elements where u is zero that should not be changed,
        // and are thus more time efficient for large matricies.
        Func<vector,vector> f  = (l) => {
            vector res = new vector(1);
            res[0] = 1;
            for(int i = 0; i < n; i++){
                res[0] += u[i]*u[i]/(D[i,i]-l[0]);
            }
            return res;
        };

        // Looping over u. Keeping the corresponding elements in D if u[i] = 0, otherwise I 
        // find the eigenvalue
        for(int i = 0; i < n; i++){
            if(u[i] == 0){
                res_array[i] = D[i,i]; // Element should not be changed if u[i] = 0. 
            }
            else{
                vector temp = new vector(1);
                temp[0] = lams[i];
                vector eigen = newton(f, temp, 1e-12, 1e-10);
                res_array[i] = eigen[0];
            }
        }

        // Sorting res_array
        Array.Sort(res_array); // This is faster than O(n^2), so this is 'permissed'.

        // Writing to vector to be returned. I like working with vectors, however one could
        // also return the result as an array.
        vector res_vec = new vector(n);
        for(int i = 0; i < n; i++){
            res_vec[i] = res_array[i];
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