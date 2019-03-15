using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib
{
    public class Point2D
    {
        public double X { get; set; }
        public double Y { get; set; }


        public static Point2D[] ReadPointsFromFile(String filename)
        {
            List<Point2D> points = new List<Point2D>();
            String[] lines = File.ReadAllLines("C:\\rearrange.txt");
            foreach(String line in lines)
            {
                String[] numbers = line.Split(' ');
                double x = Convert.ToDouble(numbers[0]);
                double y = Convert.ToDouble(numbers[1]);
                Point2D next = new Point2D(x, y);
                points.Add(next);
            }
            return points.ToArray();
        }
        public Point2D(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public String Print()
        {
            return String.Format("({0}, {1})", X, Y);
        }
        public void Scale(double multipler)
        {
            this.X = X * multipler;
            this.Y = Y * multipler;
        }
        public void Transpose(double X = 0, double Y = 0)
        {
            this.X += X;
            this.Y += Y;
        }
        public bool Compare(Point2D B)
        {
            if (X == B.X && Y == B.Y) return true;
            return false;
        }
        public void MoveByVector(IVector v, double partOfVector = 1)
        {
            Transpose(partOfVector * v.GetVector()[0], partOfVector * v.GetVector()[1]);
        }
    }

    public interface IVector
    {
        double[] GetVector();
        double GetLength();
        void MultiplyByNumber(double multipler);

    }
    public class Vector2D : IVector
    {
        private double[] vector = new double[2];

        public Vector2D(Point2D start, Point2D end)
        {
            vector[0] = end.X - start.X;
            vector[1] = end.Y - start.Y;
        }
        public Vector2D(double a, double b)
        {
            vector[0] = a;
            vector[1] = b;
        }
        public double[] GetVector()
        {
            return vector;
        }
        public double GetX()
        {
            return vector[0];
        }
        public double GetY()
        {
            return vector[1];
        }

        public Vector2D Add(Vector2D v)
        {
            double a = v.GetX() - GetX();
            double b = v.GetY() - GetY();
            return new Vector2D(a, b);
        }

        public double GetLength()
        {
            return Math.Sqrt(Math.Pow(GetX(), 2) + Math.Pow(GetY(), 2));
        }

        public void MultiplyByNumber(double number)
        {
            vector[0] *= number;
            vector[1] *= number;
        }
    }
    interface IShape2D
    {
        Point2D[] GetPoints();
        double Area();
        double Circut();
        void Scale(double multiplier);
        void MoveAlongVector(IVector v, double partOfVector);

    }
    public class Polygon : IShape2D
    {
        Point2D[] points = new Point2D[4];
        //Points have to be in connection order, won't work in other case
        public Polygon(Point2D[] coordinates)
        {
            this.points = coordinates;
        }
        public double Area()
        {
            double area = 0;
            int numberOfPoints = points.Length;
            for (int i = 0; i < numberOfPoints - 1; i++)
            {
                area += points[i].X * points[i + 1].Y - points[i].Y * points[i + 1].X;
            }
            area += points[numberOfPoints - 1].X * points[0].Y - points[numberOfPoints - 1].Y * points[0].X;
            area = Math.Abs(area / 2);
            return area;
        }

        public double Circut()
        {
            double circut = 0;
            Vector2D v = new Vector2D(points[points.Length - 1], points[0]);
            circut += v.GetLength();
            Console.WriteLine(v.GetLength());
            for (int i = 0; i < points.Length - 1; i++)
            {
                v = new Vector2D(points[i], points[i + 1]);
                Console.WriteLine(v.GetLength());
                circut += v.GetLength();
            }

            return circut;
        }

        public Point2D[] GetPoints()
        {
            return points;
        }

        //Scaling in relative to point
        public void ScaleRelative(double multiplier, Point2D pointZero)
        {
            foreach(Point2D p in points) {
                if (p.Equals(pointZero)) continue;
                IVector transposeVector = new Vector2D(pointZero, p);
                transposeVector.MultiplyByNumber(multiplier-1);
                p.MoveByVector(transposeVector);
            }
        }
        public void Scale(double multiplier)
        {
            ScaleRelative(multiplier, points[0]);
        }
        public void MoveAlongVector(IVector v, double partOfVector = 1)
        {
            if (v.GetLength() != 2) throw new ArgumentException("Vector should have 2 numbers");
            foreach (Point2D p in points)
            {
                p.MoveByVector(v, partOfVector);
            }
        }
    }
}
