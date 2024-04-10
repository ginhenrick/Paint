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
        public abstract void Draw(Graphics g);
        public abstract void Resize(Point newEndPoint);
    }

    public class MyLine : MyShape
    {
        public override void Draw(Graphics g)
        {
            g.DrawLine(Pen, startPoint, endPoint);
        }
        public override void Resize(Point newEndPoint)
        {
            endPoint = newEndPoint;
        }
    }

    public class MyRectangle : MyShape
    {
        public override void Draw(Graphics g) {
            
        }
        public override void Resize(Point newEndPoint)
        {
            endPoint = newEndPoint;
        }
    }

    public class MyFillRectangle : MyShape
    {
        public override void Draw(Graphics g) {
            
        }
        public override void Resize(Point newEndPoint)
        {
            endPoint = newEndPoint;
        }
    }

    public class MyParallelogram : MyShape { 
        public override void Draw(Graphics g) { }
        public override void Resize(Point newEndPoint)
        {
            endPoint = newEndPoint;
        }
    }

    public class MyFillParallelogram : MyShape
    {
        public override void Draw(Graphics g) { }
        public override void Resize(Point newEndPoint)
        {
            endPoint = newEndPoint;
        }
    }

    public class MyRhombus : MyShape
    {
        public override void Draw(Graphics g) { }
        public override void Resize(Point newEndPoint)
        {
            endPoint = newEndPoint;
        }
    }

    public class MyFillRhombus : MyShape
    {
        public override void Draw(Graphics g) { }
        public override void Resize(Point newEndPoint)
        {
            endPoint = newEndPoint;
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
        public override void Resize(Point newEndPoint)
        {
            endPoint = newEndPoint;
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
        public override void Resize(Point newEndPoint)
        {
            endPoint = newEndPoint;
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
        public override void Resize(Point newEndPoint)
        {
            endPoint = newEndPoint;
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
        public override void Resize(Point newEndPoint)
        {
            endPoint = newEndPoint;
        }
    }


}
