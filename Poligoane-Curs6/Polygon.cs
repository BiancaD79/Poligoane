using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Poligoane_Curs6
{
    public class Polygon
    {
        PointF[] points;
        public static Random rnd = new Random();
        public Polygon(int n, int maxX,int maxY)
        {
            points = new PointF[n];
            for (int i = 0; i < n; i++)
            {
                points[i] = new PointF(rnd.Next(maxX), rnd.Next(maxY));
            }
        }
        public Polygon(string fileName)
        { 
            TextReader reader = new StreamReader(fileName);
            List<string> lines = new List<string>();
            string buffer;
            while((buffer = reader.ReadLine()) != null)
            {
                lines.Add(buffer); 
            }
            reader.Close();
            points = new PointF[lines.Count];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new PointF(float.Parse(lines[i].Split(' ')[0]), float.Parse(lines[i].Split(' ')[1]));
            }
        }
        public float Perimeter()
        {
            float toReturn = 0;
            for (int i = 0; i < points.Length ; i++)
                toReturn += MyMath.Distance(points[i],points[(i+1)% points.Length]);
            
            return toReturn;
        }

        public PointF G()
        {
            float toReturnX = 0;
            float toReturnY = 0;

            for (int i = 0; i < points.Length; i++)
            {
                toReturnX += points[i].X;
                toReturnY += points[i].Y;
            }
            return new PointF(toReturnX / points.Length, toReturnY / points.Length);
        }
        public float Area()
        {
            float area = 0;
            for (int i = 0; i < points.Length; i++)
            {
                area += (points[i].X * points[(i + 1) % points.Length].Y - points[i].Y * points[(i + 1) % points.Length].X ) * 0.5f;
            }
            return area;
        }

        public void Draw(Graphics handler)
        {
            handler.DrawPolygon(Pens.Black, points);
        }
    }
}
