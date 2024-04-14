using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        public LinearGradientBrush? gradientMode { get; set; }

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
            g.FillPolygon(SolidBrush, points);
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
                g.FillPolygon(SolidBrush, points);
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

    //==========================================================================================================//
    public class MyRectangleHorizontal : MyShape
    {
        public override void Draw(Graphics g)
        {
            int xLoc = Math.Min(startPoint.X, endPoint.X);
            int yLoc = Math.Min(startPoint.Y, endPoint.Y);
            int width = Math.Abs(startPoint.X - endPoint.X);
            int height = Math.Abs(startPoint.Y - endPoint.Y);
            Rectangle rectangle = new Rectangle(xLoc, yLoc, width, height);

            // Vẽ hình chữ nhật
            g.DrawRectangle(Pen, rectangle);

            // Tô màu
            if (FillBrush != null)
            {
                if (FillBrush is LinearGradientBrush linearGradientBrush)
                {
                    g.FillRectangle(linearGradientBrush, rectangle);
                }
                else if (FillBrush is SolidBrush solidBrush)
                {
                    g.FillRectangle(solidBrush, rectangle);
                }
            }
        }
    }

    public class MyRectanglePathGradientBrush : MyShape
    {
        public override void Draw(Graphics g)
        {
            if (startPoint == null || endPoint == null || Pen == null || FillBrush == null)
            {
                // Nếu các thuộc tính không được khởi tạo, không thể vẽ hình chữ nhật
                return;
            }

            int x = Math.Min(startPoint.X, endPoint.X);
            int y = Math.Min(startPoint.Y, endPoint.Y);
            int width = Math.Abs(startPoint.X - endPoint.X);
            int height = Math.Abs(startPoint.Y - endPoint.Y);

            // Vẽ hình chữ nhật với PathGradientBrush
            g.DrawRectangle(Pen, x, y, width, height);
            g.FillRectangle(FillBrush, x, y, width, height);
        }
    }

    public class MyRectangleTextureBrush : MyShape
    {
        public override void Draw(Graphics g)
        {
            if (startPoint != null && endPoint != null && Pen != null && FillBrush != null)
            {
                // Vẽ hình chữ nhật bằng TextureBrush
                g.FillRectangle((TextureBrush)FillBrush, startPoint.X, startPoint.Y, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);

                // Vẽ viền của hình chữ nhật
                g.DrawRectangle(Pen, startPoint.X, startPoint.Y, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
            }
        }
    }

    public class MyRectangleHatchBrush : MyShape
    {
        public override void Draw(Graphics g)
        {
            if (startPoint != null && endPoint != null && Pen != null && FillBrush != null)
            {
                // Tạo đường dẫn cho hình chữ nhật
                GraphicsPath rectanglePath = new GraphicsPath();
                rectanglePath.AddRectangle(new Rectangle(startPoint.X, startPoint.Y, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y));

                // Kiểm tra loại FillBrush
                if (FillBrush is HatchBrush)
                {
                    // Vẽ hình chữ nhật bằng HatchBrush
                    g.FillRectangle((HatchBrush)FillBrush, startPoint.X, startPoint.Y, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
                }
                else
                {
                    // Vẽ hình chữ nhật bằng SolidBrush hoặc TextureBrush
                    g.FillRectangle(FillBrush, startPoint.X, startPoint.Y, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
                }

                // Vẽ viền của hình chữ nhật
                g.DrawRectangle(Pen, startPoint.X, startPoint.Y, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
            }
        }
    }
    //==========================================================================================================//
    public class MyEllipseHorizontal : MyShape
    {
        public override void Draw(Graphics g)
        {
            int xLoc = Math.Min(startPoint.X, endPoint.X);
            int yLoc = Math.Min(startPoint.Y, endPoint.Y);
            int width = Math.Abs(startPoint.X - endPoint.X);
            int height = Math.Abs(startPoint.Y - endPoint.Y);
            Rectangle rectangle = new Rectangle(xLoc, yLoc, width, height);
            
            // Vẽ hình ellipse
            g.DrawEllipse(Pen, rectangle);

            // Tô màu
            if (FillBrush != null)
            {
                if (FillBrush is LinearGradientBrush linearGradientBrush)
                {
                    // Tạo một linear gradient brush theo mode horizontal
                    linearGradientBrush.WrapMode = WrapMode.TileFlipX;
                    g.FillEllipse(linearGradientBrush, rectangle);
                }
                else if (FillBrush is SolidBrush solidBrush)
                {
                    g.FillEllipse(solidBrush, rectangle);
                }
            }
        }
    }

    public class MyEllipsePathGradientBrush : MyShape
    {
        public override void Draw(Graphics g)
        {
            if (startPoint != null && endPoint != null && Pen != null && FillBrush != null)
            {
                // Tính kích thước của hình ellipse
                int widthEllipse = Math.Abs(endPoint.X - startPoint.X);
                int heightEllipse = Math.Abs(endPoint.Y - startPoint.Y);

                // Tính tọa độ x và y của hình ellipse
                int xEllipse = Math.Min(startPoint.X, endPoint.X);
                int yEllipse = Math.Min(startPoint.Y, endPoint.Y);

                // Tạo đường dẫn cho hình ellipse
                GraphicsPath ellipsePath = new GraphicsPath();
                ellipsePath.AddEllipse(new Rectangle(xEllipse, yEllipse, widthEllipse, heightEllipse));

                // Kiểm tra loại FillBrush
                if (FillBrush is PathGradientBrush)
                {
                    // Vẽ hình ellipse bằng PathGradientBrush
                    g.FillEllipse((PathGradientBrush)FillBrush, xEllipse, yEllipse, widthEllipse, heightEllipse);
                }
                else
                {
                    // Vẽ hình ellipse bằng SolidBrush, TextureBrush hoặc HatchBrush
                    g.FillEllipse(FillBrush, xEllipse, yEllipse, widthEllipse, heightEllipse);
                }

                // Vẽ viền của hình ellipse
                g.DrawEllipse(Pen, xEllipse, yEllipse, widthEllipse, heightEllipse);
            }
        }
    }


    public class MyEllipseTextureBrush : MyShape
    {
        public override void Draw(Graphics g)
        {
            if (startPoint != null && endPoint != null && Pen != null && FillBrush != null)
            {
                // Tính kích thước của hình ellipse
                int width = Math.Abs(endPoint.X - startPoint.X);
                int height = Math.Abs(endPoint.Y - startPoint.Y);

                // Tính tọa độ x và y của hình ellipse
                int x = Math.Min(startPoint.X, endPoint.X);
                int y = Math.Min(startPoint.Y, endPoint.Y);

                // Vẽ hình ellipse bằng TextureBrush
                g.FillEllipse((TextureBrush)FillBrush, x, y, width, height);

                // Vẽ viền của hình ellipse
                g.DrawEllipse(Pen, x, y, width, height);
            }
        }
    }

    public class MyEllipseHatchBrush : MyShape
    {
        public override void Draw(Graphics g)
        {
            if (startPoint != null && endPoint != null && Pen != null && FillBrush != null)
            {
                // Tính kích thước của hình ellipse
                int width = Math.Abs(endPoint.X - startPoint.X);
                int height = Math.Abs(endPoint.Y - startPoint.Y);

                // Tính tọa độ x và y của hình ellipse
                int x = Math.Min(startPoint.X, endPoint.X);
                int y = Math.Min(startPoint.Y, endPoint.Y);

                // Vẽ hình ellipse bằng HatchBrush
                g.FillEllipse((HatchBrush)FillBrush, x, y, width, height);

                // Vẽ viền của hình ellipse
                g.DrawEllipse(Pen, x, y, width, height);
            }
        }
    }


    //==========================================================================================================//
    public class MyParallelogramHorizontal : MyShape
    {
        public override void Draw(Graphics g)
        {
            int xLoc = Math.Min(startPoint.X, endPoint.X);
            int yLoc = Math.Min(startPoint.Y, endPoint.Y);
            int width = Math.Abs(startPoint.X - endPoint.X);
            int height = Math.Abs(startPoint.Y - endPoint.Y);
            Rectangle rectangle = new Rectangle(xLoc, yLoc, width, height);

            // Tính toán các điểm của hình Parallelogram
            Point[] points =
            {
            new Point(xLoc, yLoc),
            new Point(xLoc + width, yLoc),
            new Point(xLoc + width + (height / 2), yLoc + height),
            new Point(xLoc + (height / 2), yLoc + height)
        };

            // Vẽ hình Parallelogram
            g.DrawPolygon(Pen, points);

            // Tô màu
            if (FillBrush is LinearGradientBrush linearGradientBrush)
            {
                // Tạo một linear gradient brush theo mode horizontal
                linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
                g.FillPolygon(linearGradientBrush, points);
            }
            else if (FillBrush is SolidBrush solidBrush)
            {
                g.FillPolygon(solidBrush, points);
            }
        }
    }

    //==========================================================================================================//
    public class MyRhombusHorizontal : MyShape
    {
        public override void Draw(Graphics g)
        {
            int xLoc = Math.Min(startPoint.X, endPoint.X);
            int yLoc = Math.Min(startPoint.Y, endPoint.Y);
            int width = Math.Abs(startPoint.X - endPoint.X);
            int height = Math.Abs(startPoint.Y - endPoint.Y);
            Rectangle rectangle = new Rectangle(xLoc, yLoc, width, height);

            // Tính toán các điểm của hình Rhombus
            Point[] points =
            {
            new Point(xLoc + (width / 2), yLoc),
            new Point(xLoc + width, yLoc + (height / 2)),
            new Point(xLoc + (width / 2), yLoc + height),
            new Point(xLoc, yLoc + (height / 2))
        };

            // Vẽ hình Rhombus
            g.DrawPolygon(Pen, points);

            // Tô màu
            if (FillBrush != null)
            {
                if (FillBrush is LinearGradientBrush linearGradientBrush)
                {
                    // Tạo một linear gradient brush theo mode horizontal
                    linearGradientBrush.WrapMode = WrapMode.TileFlipX;
                    g.FillPolygon(linearGradientBrush, points);
                }
                else
                {
                    // Nếu FillBrush không phải là LinearGradientBrush, sử dụng FillBrush bình thường
                    g.FillPolygon(FillBrush, points);
                }
            }
        }
    }

    public class MyRhombusPathGradientBrush : MyShape
    {
        public override void Draw(Graphics g)
        {
            if (startPoint != null && endPoint != null && Pen != null && FillBrush != null)
            {
                // Tính các điểm để vẽ hình thoi
                Point[] rhombusPoints = {
                new Point((startPoint.X + endPoint.X) / 2, startPoint.Y),
                new Point(endPoint.X, (startPoint.Y + endPoint.Y) / 2),
                new Point((startPoint.X + endPoint.X) / 2, endPoint.Y),
                new Point(startPoint.X, (startPoint.Y + endPoint.Y) / 2)
            };

                // Tạo đường dẫn cho hình thoi
                GraphicsPath rhombusPath = new GraphicsPath();
                rhombusPath.AddPolygon(rhombusPoints);

                // Kiểm tra loại FillBrush
                if (FillBrush is PathGradientBrush)
                {
                    // Vẽ hình thoi bằng PathGradientBrush
                    g.FillPolygon((PathGradientBrush)FillBrush, rhombusPoints);
                }
                else
                {
                    // Vẽ hình thoi bằng SolidBrush, TextureBrush hoặc HatchBrush
                    g.FillPolygon(FillBrush, rhombusPoints);
                }

                // Vẽ viền của hình thoi
                g.DrawPolygon(Pen, rhombusPoints);
            }
        }
    }

    public class MyRhombusTextureBrush : MyShape
    {
        public override void Draw(Graphics g)
        {
            if (startPoint != null && endPoint != null && Pen != null && FillBrush != null)
            {
                // Tính các điểm để vẽ hình thoi
                Point[] rhombusPoints = {
                new Point((startPoint.X + endPoint.X) / 2, startPoint.Y),
                new Point(endPoint.X, (startPoint.Y + endPoint.Y) / 2),
                new Point((startPoint.X + endPoint.X) / 2, endPoint.Y),
                new Point(startPoint.X, (startPoint.Y + endPoint.Y) / 2)
            };

                // Tính kích thước của hình thoi
                int width = endPoint.X - startPoint.X;
                int height = endPoint.Y - startPoint.Y;

                // Tạo TextureBrush từ hình ảnh đã chọn
                TextureBrush textureBrush = new TextureBrush(((Bitmap)FillBrush.Image), WrapMode.Tile);

                // Vẽ hình thoi bằng TextureBrush
                g.FillPolygon(textureBrush, rhombusPoints);

                // Vẽ viền của hình thoi
                g.DrawPolygon(Pen, rhombusPoints);
            }
        }
    }

    public class MyRhombusHatchBrush : MyShape
    {
        public override void Draw(Graphics g)
        {
            
        }
    }



    //==========================================================================================================//

    public class MyCircleHorizontal : MyShape
    {
        public override void Draw(Graphics g)
        {
            int xLoc = Math.Min(startPoint.X, endPoint.X);
            int yLoc = Math.Min(startPoint.Y, endPoint.Y);
            int diameter = Math.Min(Math.Abs(startPoint.X - endPoint.X), Math.Abs(startPoint.Y - endPoint.Y));
            Rectangle rectangle = new Rectangle(xLoc, yLoc, diameter, diameter);

            // Vẽ hình tròn
            g.DrawEllipse(Pen, rectangle);

            // Tô màu
            if (FillBrush != null)
            {
                if (FillBrush is LinearGradientBrush linearGradientBrush)
                {
                    // Tạo một linear gradient brush theo mode horizontal
                    linearGradientBrush.WrapMode = WrapMode.TileFlipX;
                    g.FillEllipse(linearGradientBrush, rectangle);
                }
                else if (FillBrush is SolidBrush solidBrush)
                {
                    g.FillEllipse(solidBrush, rectangle);
                }
            }
        }
    }

}
