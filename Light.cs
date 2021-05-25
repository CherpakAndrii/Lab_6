namespace Lab6
{
    public class Light
    {
        private Point LightPoint;
        public int Red;
        public int Green;
        public int Blue;

        public Light(double x, double y, double z, int R = 255, int G = 255, int B = 255)
        {
            LightPoint = new Point(x, y, z);
            Red = R;
            Green = G;
            Blue = B;
        }

        public double GetLightCoef(Face f, RTree tree)
        {
            if (f != Camera.GetNearestFace(LightPoint, f.center, tree)) return 0.1;
            Vector LightRay = new Vector(f.center, LightPoint);
            return 0.1 + 0.9 * (f.NormalVector.X * LightRay.X + f.NormalVector.Y * LightRay.Y +
                                f.NormalVector.Z * LightRay.Z)/(f.NormalVector.Module*LightRay.Module);
        }
    }
}
