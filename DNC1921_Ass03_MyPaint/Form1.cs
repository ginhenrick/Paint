using System.Data;
using System.Drawing;
using System.Net;

namespace DNC1921_Ass03_MyPaint
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            g = panelKhungVe.CreateGraphics();
            ResizeEnd += FrmMain_ResizeEnd;
        }

        Color BorderColor = Color.Black;
        Color FillColor = Color.Black;
        Point startPoint = Point.Empty;
        Graphics g = null;
        List<MyShape> shapes = new List<MyShape>();


        private void btnBorderColor_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();
            cd.FullOpen = true;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                BorderColor = cd.Color;
                btnBorderColor.BackColor = cd.Color;
            }
        }

        private void btnFillColor_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();
            cd.FullOpen = true;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                FillColor = cd.Color;
                btnFillColor.BackColor = cd.Color;
            }
        }

        private void panelKhungVe_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
        }

        private void panelKhungVe_MouseUp(object sender, MouseEventArgs e)
        {
            Pen myPen = new Pen(BorderColor, float.Parse(nudBorderSize.Value.ToString()));

            int xLoc = Math.Min(startPoint.X, e.Location.X);
            int yLoc = Math.Min(startPoint.Y, e.Location.Y);
            int width = Math.Abs(startPoint.X - e.Location.X);
            int height = Math.Abs(startPoint.Y - e.Location.Y);
            SolidBrush brush = new SolidBrush(FillColor);
            switch (cboType.SelectedIndex)
            {
                case 0: // Text
                        // Handle text drawing logic here (e.g., using g.DrawString)
                    break;
                case 1: // Line

                    break;
                case 2: // Rectangle

                    break;
                case 3: // Fill Rectangle

                    break;
                case 4: // Ellipse
                    g.DrawEllipse(myPen, xLoc, yLoc, width, height);
                    shapes.Add(new MyEllipse
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        SolidBrush = brush
                    });
                    break;
                case 5: // Fill Ellipse
                    g.FillEllipse(brush, xLoc, yLoc, width, height);
                    shapes.Add(new MyFillEllipse
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        SolidBrush = brush
                    });
                    break;
                case 6: // Parallelogram
                        // Implement logic to draw a parallelogram based on startPoint, e.Location, width, and height
                        // You might need additional calculations for the second endPoint of the parallelogram

                case 7: // Fill Parallelogram
                        // Implement logic to draw a filled parallelogram based on startPoint, e.Location, width, and height
                        // You might need additional calculations for the second endPoint of the parallelogram

                case 8: // Rhombus
                        // Implement logic to draw a rhombus based on startPoint, e.Location, width, and height
                        // You might need to calculate diagonals for the rhombus

                    break;
                case 9: // Fill Rhombus
                        // Implement logic to draw a filled rhombus based on startPoint, e.Location, width, and height
                        // You might need to calculate diagonals for the rhombus

                    break;
                case 10: // Circle
                    int diameter = Math.Min(width, height); // Assuming a circle inscribed in a rectangle
                    int radius = diameter / 2;
                    g.DrawEllipse(myPen, xLoc, yLoc, diameter, diameter);
                    shapes.Add(new MyCircle
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        SolidBrush = brush
                    });
                    break;
                case 11: // Fill Circle
                    int diameterFill = Math.Min(width, height); // Assuming a circle inscribed in a rectangle
                    int radiusFill = diameterFill / 2;
                    g.FillEllipse(brush, xLoc, yLoc, diameterFill, diameterFill);
                    shapes.Add(new MyFillCircle
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        SolidBrush = brush
                    });
                    break;
                default:
                    // Handle unexpected case (optional)
                    break;
            }
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cboType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void FrmMain_ResizeEnd(object sender, EventArgs e)
        {
            ResizeDrawingPanel();
            ResizeShapes();
        }

        private void ResizeShapes()
        {
            foreach (MyShape shape in shapes)
            {
                // Tính toán kích thước mới của shape dựa trên kích thước mới của form
                int newWidth = panelKhungVe.Width;
                int newHeight = panelKhungVe.Height;

                // Tính toán các thông số mới của shape
                int newStartX = (int)(shape.startPoint.X / (double)panelKhungVe.Width * newWidth);
                int newStartY = (int)(shape.startPoint.Y / (double)panelKhungVe.Height * newHeight);
                int newEndX = (int)(shape.endPoint.X / (double)panelKhungVe.Width * newWidth);
                int newEndY = (int)(shape.endPoint.Y / (double)panelKhungVe.Height * newHeight);

                // Cập nhật vị trí mới cho shape
                shape.startPoint = new Point(newStartX, newStartY);
                shape.endPoint = new Point(newEndX, newEndY);
            }
        }

        private void ResizeDrawingPanel()
        {
            panelKhungVe.Size = ClientSize;
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
           

        }   

      

        

        
    }
}
