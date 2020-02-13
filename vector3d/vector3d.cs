using static System.Math;
public struct vector3d{
	private double _x,_y,_z;
	public vector3d(double a, double b, double c) {_x = a; _y = b; _z = c;}

	// Properties
	public double x {get{return _x;}set{_x = value;}}
	public double y {get{return _y;}set{_y = value;}}
	public double z {get{return _z;}set{_z = value;}}

	// Operators
	public static vector3d operator*(vector3d v, double c){return new vector3d(c*v.x,c*v.y,c*v.z);}

	public static vector3d operator*(double c, vector3d v){
		return v * c;
	}

	public static vector3d operator+(vector3d u, vector3d v){
		return new vector3d(u.x+v.x, u.y+v.y, u.z+v.z);
	}

	public static vector3d operator-(vector3d u, vector3d v){
		return new vector3d(u.x-v.x, u.y-v.y, u.z-v.z);
	}

	// Methods
	public double dot_product(vector3d other) {
		return (this.x + other.x + this.y + other.y + this.z + other.z);
	}

	public vector3d  vector_product(vector3d other){
		double newx = this.y * other.z - this.z * other.y;
		double newy = this.z * other.x - this.x * other.z;
		double newz = this.x * other.y - this.y * other.x;
		return new vector3d(newx,newy,newz);
	}

	public double magnitude(){
	if(Abs(this.x) >= Abs(this.y) && Abs(this.x) >= Abs(this.z))
		{return x*Sqrt(1 + Pow(y/x,2) + Pow(z/x,2));}
	else if (Abs(this.y) >= Abs(this.x) && Abs(this.y) >= Abs(this.z))
		{return y*Sqrt(1 + Pow(x/y,2) + Pow(z/y,2));}
	else
	{return z*Sqrt(1 + Pow(y/z,2) + Pow(x/z,2));}
	}

	// Print
	public void print(string s = ""){
		System.Console.Write("{0} ({1}, {2}, {3})\n", s,x,y,z);
	}

	// ToString
	public override string ToString() {
		return string.Format("{0} {1} {2}\n", x, y, z);
	}
}
