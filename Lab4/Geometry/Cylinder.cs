namespace Geometry;
public class Cylinder
{
    public double X { get; private set; } = 0;
    public double Y { get; private set; } = 0;
    public double h { get; private set; } = 1;
    public double r { get; private set; } = 1;

    public Cylinder(double X, double Y, double h, double r)
    {
        if (r > 0)
            this.r = r;
        if (h > 0)
            this.h = h;
        this.X = X;
        this.Y = Y;
    }

    public double Volume => CalcVolume(h, r);
    public static double CalcVolume(double h, double r){
        if (r <= 0 || h <= 0)
            return 0;
        
        return Math.PI * (r * r) * h;
    }
}
