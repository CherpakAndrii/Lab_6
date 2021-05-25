namespace Lab6
{
    public class Camera
    {
        private Point Center;
        private int height, width;

        public Camera(Point center, int h, int w)
        {
            Center = center;
            height = h;
            width = w;
            Point focus;
            byte[][][] image = new byte[height][][];
            for (int i = 0; i < 100; i++)
            {
                image[i] = new byte[width][];
                for (int j = 0; j < 100; j++)
                {
                    image[i][j] = new[] {(byte)0, (byte)0, (byte)0};
                }
            }

            focus = new Point(Center.X, Center.Y, Center.Z * 7 / 8);
        }
        public byte[][][] GetImage(RTree tree)
        {
            return null;
        }
    }
}