public class main{
	public static int Main(){
	vector3d v = new vector3d(3,9,10);
	vector3d u = new vector3d(2,4,6);
	u.print("u =");
	v.print("v =");
	(u+v).print("u + v =");
	(u-v).print("u - v =");
	(2*v).print("2 * v =");
	System.Console.Write("u dot v = {0}\n",u.dot_product(v));
	v.vector_product(u).print("u X v =");
	System.Console.Write("|v| = {0}\n", v.magnitude());
	return 0;
	}



}
