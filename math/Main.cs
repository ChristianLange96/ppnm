using static cmath;
using static System.Console;
using static System.Math;
class main{
	public static int Main(){
		// Calculations
		Write("sqrt(2) = {0} \n", sqrt(2));
		Write("exp(i) = {0} \n", exp(new complex(0,1)));
		Write("exp(iπ) = {0} \n", exp(new complex(0,PI)));
		Write("pow(i,i) = {0} \n", new complex(0,1).pow(new complex(0,1)));
		Write("sin(iπ) = {0} \n", sin(new complex(0,PI)));
int i = 0;
Write("{0}\n",i);
Write("{0}\n",i++);
Write("{0}\n",++i);

	return 0;
}


}
