using static System.Math;
using static System.Console;
using static approx;
class main{
	static int Main(){
		// Opgave A //
		/*
		// Biggest integer
		int i =1;
		while(i+1>i) {i++;}
		Write("My max int = {0} \n",i);
		Write("int.MaxValue = {0} \n", int.MaxValue);

		// Minimum integer
		i = 1;
		while(i-1 < i) {i--;}
		Write("My min int = {0} \n",i);
		Write("int.Minvalue = {0} \n",int.MinValue);


		// Opgave B
		double x = 1;
		while(1+x != 1)
			{x/=2;}
		x*=2;
		Write("My double eps = {0} \n",x);
		Write("System eps(double) = {0}\n",Pow(2,-52));

		float y = 1F;
		while( (float) (1F+y) != 1F)
			{y/=2F;}
		y*=2F;
		Write("My float eps = {0} \n", y);
		Write("System eps(float) = {0} \n",Pow(2,-23));
		// Opgave C
		// Floats
		int max=int.MaxValue/3;

		float float_sum_up=1F;
		for( i=2;i<max;i++)
			float_sum_up += 1F/i;
		Write("float_sum_up = {0}\n",float_sum_up);

		float float_sum_down=1F/max;
		for( i=max-1;i>0;i--)
			float_sum_down+=1F/i;
		Write("float_sum_down = {0}\n",float_sum_down);

		// Doubles
		double double_sum_up = 1.0;
		for(i = 2; i < max; i++)
			double_sum_up += 1.0/i;
		Write("double_sum_up = {0} \n", double_sum_up);

		double double_sum_down = 1.0/max;
		for (i = max-1; i > 0; i--)
			double_sum_down += 1.0/i;
		Write("doube_sum_down = {0} \n", double_sum_down);




		// Explanation of difference
		// The difference arises due to the method of addition. When 
		// we're beginning with a small number we have 7(for floats)
		// of signifigant figures, which gives a larger precision, 
		// that can be added together. Starting from a large number 
		// and going down means we don't have many figures left for 
		// precision -  the small numbers will just add 0, hence why
		// downsum is greater than upsum.

		// The numbers do converge as a function of max, in the sense
		// that at some points even double will add 0 to the number. 
		// I don't think it converges to the analytical convergent 
		// number though. 
*/
		bool app = Approx(1,2);
		Write("Result from approx: {0} \n",app);

	return 0;
}




}


