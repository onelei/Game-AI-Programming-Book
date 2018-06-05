namespace AStar
{
    public class Point
    {
        public int X;
        public int Y;

        public Point(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }
        
        public static bool operator ==(Point point1,Point point2)
        {
            return point1.X == point2.X && point1.Y == point2.Y;
        }
        
        public static bool operator !=(Point point1,Point point2)
        {
            return point1.X != point2.X || point1.Y != point2.Y;
        }
    }
}