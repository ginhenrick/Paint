using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DNC1921_Ass03_MyPaint
{
    public abstract class MyShape
    {
        public Point startPoint {  get; set; }
        public Point endPoint { get; set; }
        public Pen? Pen { get; set; }
        public SolidBrush? SolidBrush { get; set; }
        public Brush? FillBrush { get; set; }
        public abstract void Draw(Graphics g);
    }

    public class MyLine : MyShape
    {
        public override void Draw(Graphics g)
        {
            g.DrawLine(Pen, startPoint, endPoint);
        }
       
    }

    public class MyRectangle : MyShape
    {
        public override void Draw(Graphics g)
        {
            int xLoc = Math.Min(startPoint.X, endPoint.X);
            int yLoc = Math.Min(startPoint.Y, endPoint.Y);
            int width = Math.Abs(startPoint.X - endPoint.X);
            int height = Math.Abs(startPoint.Y - endPoint.Y);
            g.DrawRectangle(Pen, xLoc, yLoc, width, height);
        }

    }

    public class MyFillRectangle : MyShape
    {
        public override void Draw(Graphics g) {
            int xLoc = Math.Min(startPoint.X, endPoint.X);
            int yLoc = Math.Min(startPoint.Y, endPoint.Y);
            int width = Math.Abs(startPoint.X - endPoint.X);
            int height = Math.Abs(startPoint.Y - endPoint.Y);
            g.DrawRectangle(Pen, xLoc, yLoc, width, height);
            g.FillRectangle(SolidBrush, xLoc, yLoc, width, height);

        }
    }

    public class MyParallelogram : MyShape {
        public override void Draw(Graphics g)
        {

            Point[] points = new Point[4];
            points[0] = startPoint;
            points[1] = new Point(startPoint.X + (endPoint.X - startPoint.X) / 2, endPoint.Y);
            points[2] = endPoint;
            points[3] = new Point(endPoint.X - (endPoint.X - startPoint.X) / 2, startPoint.Y);

            // Vẽ parallelogram
            g.DrawPolygon(Pen, points);
            if (FillBrush != null)
                g.FillPolygon(FillBrush, points);
        }      
    }

    public class MyFillParallelogram : MyShape
    {
        public override void Draw(Graphics g)
        {
            Point[] points = new Point[4];
            points[0] = startPoint;
            points[1] = new Point(startPoint.X + (endPoint.X - startPoint.X) / 2, endPoint.Y);
            points[2] = endPoint;
            points[3] = new Point(endPoint.X - (endPoint.X - startPoint.X) / 2, startPoint.Y);
                
            // Vẽ parallelogram
            g.DrawPolygon(Pen, points);
            if (SolidBrush != null)
            g.FillPolygon(SolidBrush, points); // Sử dụng SolidBrush để tô màu
        }
    }

    public class MyRhombus : MyShape
    {
        public override void Draw(Graphics g) {
            Point[] points = new Point[4];
            points[0] = new Point((startPoint.X + endPoint.X) / 2, startPoint.Y);
            points[1] = new Point(endPoint.X, (startPoint.Y + endPoint.Y) / 2);
            points[2] = new Point((startPoint.X + endPoint.X) / 2, endPoint.Y);
            points[3] = new Point(startPoint.X, (startPoint.Y + endPoint.Y) / 2);

            //Vẽ rhombus
            g.DrawPolygon(Pen, points);
            if (FillBrush != null)
                g.FillPolygon(FillBrush, points);
        }
    }

    public class MyFillRhombus : MyShape
    {
        public override void Draw(Graphics g)
        {
            Point[] points = new Point[4];
            points[0] = new Point((startPoint.X + endPoint.X) / 2, startPoint.Y);
            points[1] = new Point(endPoint.X, (startPoint.Y + endPoint.Y) / 2);
            points[2] = new Point((startPoint.X + endPoint.X) / 2, endPoint.Y);
            points[3] = new Point(startPoint.X, (startPoint.Y + endPoint.Y) / 2);

            // Vẽ rhombus
            g.DrawPolygon(Pen, points);
            if (SolidBrush != null)
                g.FillPolygon(SolidBrush, points); // Sử dụng SolidBrush để tô màu
        }
    }

    public class MyEllipse : MyShape
    {
        public override void Draw(Graphics g) {
            int xLoc = Math.Min(startPoint.X, endPoint.X);
            int yLoc = Math.Min(startPoint.Y, endPoint.Y);
            int width = Math.Abs(startPoint.X - endPoint.X);
            int height = Math.Abs(startPoint.Y - endPoint.Y);
            g.DrawEllipse(Pen, xLoc, yLoc, width, height);
        }
       
    }

    public class MyFillEllipse : MyShape
    {
        public override void Draw(Graphics g) {
            int xLoc = Math.Min(startPoint.X, endPoint.X);
            int yLoc = Math.Min(startPoint.Y, endPoint.Y);
            int width = Math.Abs(startPoint.X - endPoint.X);
            int height = Math.Abs(startPoint.Y - endPoint.Y);
            g.DrawEllipse(Pen, xLoc, yLoc, width, height);
            g.FillEllipse(SolidBrush, xLoc, yLoc, width, height);

        }
    }

    public class MyCircle : MyShape
    {
        public override void Draw(Graphics g)
        {
            int diameter = Math.Min(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y); // Assuming a circle inscribed in a rectangle
            int radius = diameter / 2;
            int xLoc = startPoint.X + (endPoint.X - startPoint.X) / 2 - radius;
            int yLoc = startPoint.Y + (endPoint.Y - startPoint.Y) / 2 - radius;
            g.DrawEllipse(Pen, xLoc, yLoc, diameter, diameter);
        }
    }

    public class MyFillCircle : MyShape
    {
        public override void Draw(Graphics g)
        {
            int diameter = Math.Min(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y); // Assuming a circle inscribed in a rectangle
            int radius = diameter / 2;
            int xLoc = startPoint.X + (endPoint.X - startPoint.X) / 2 - radius;
            int yLoc = startPoint.Y + (endPoint.Y - startPoint.Y) / 2 - radius;
            g.DrawEllipse(Pen, xLoc, yLoc, diameter, diameter);
            g.FillEllipse(SolidBrush, xLoc, yLoc, diameter, diameter);
        }
    }


}
