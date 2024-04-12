using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private Dictionary<int, List<string>> brushTypeItems = new Dictionary<int, List<string>>
            {
                { 2, new List<string> { "Rectangle_BackwardDiagonal", "Rectangle_PathGradientBrush", "Rectangle_TextureBrush", "Rectangle_HatchBrush" } },
                { 4, new List<string> { "Ellipse_BackwardDiagonal", "Ellipse_PathGradientBrush", "Ellipse_TextureBrush", "Ellipse_HatchBrush" } },
                { 6, new List<string> { "Parallelogram_BackwardDiagonal", "Parallelogram_PathGradientBrush", "Parallelogram_TextureBrush", "Parallelogram_HatchBrush" } },
                { 8, new List<string> { "Rhombus_BackwardDiagonal", "Rhombus_PathGradientBrush", "Rhombus_TextureBrush", "Rhombus_HatchBrush" } },
                { 10, new List<string> { "Circle_BackwardDiagonal", "Circle_PathGradientBrush", "Circle_TextureBrush", "Circle_HatchBrush" } }
            };
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
                //text
                case 0:
                    break;

                //line
                case 1:
                    g.DrawLine(myPen, startPoint, e.Location);
                    break;

                //rectangle
                case 2:
                    g.DrawRectangle(myPen, xLoc, yLoc, width, height);
                    shapes.Add(new MyRectangle
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        SolidBrush = brush
                    });

                    break;

                //fill rectangle
                case 3:

                    g.FillRectangle(brush, xLoc, yLoc, width, height);
                    shapes.Add(new MyFillRectangle
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        SolidBrush = brush
                    });

                    break;

                //ellipse
                case 4:
                    g.DrawEllipse(myPen, xLoc, yLoc, width, height);
                    shapes.Add(new MyEllipse
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        SolidBrush = brush
                    });
                    break;

                //fill ellipse
                case 5:
                    g.FillEllipse(brush, xLoc, yLoc, width, height);
                    shapes.Add(new MyFillEllipse
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        SolidBrush = brush
                    });
                    break;

                //parallelogram
                case 6:
                    g.DrawPolygon(myPen, new Point[] {
                    startPoint,
                     new Point(startPoint.X + (e.Location.X - startPoint.X) / 2, e.Location.Y),
                    e.Location,
                    new Point(e.Location.X - (e.Location.X - startPoint.X) / 2, startPoint.Y)
                    });
                    shapes.Add(new MyParallelogram
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        SolidBrush = brush
                    });

                    break;

                // fill parallelogram
                case 7:
                    g.DrawPolygon(myPen, new Point[] {
                        startPoint,
                        new Point(startPoint.X + (e.Location.X - startPoint.X) / 2, e.Location.Y),
                        e.Location,
                        new Point(e.Location.X - (e.Location.X - startPoint.X) / 2, startPoint.Y)
                    });
                                    g.FillPolygon(brush, new Point[] {
                        startPoint,
                        new Point(startPoint.X + (e.Location.X - startPoint.X) / 2, e.Location.Y),
                        e.Location,
                        new Point(e.Location.X - (e.Location.X - startPoint.X) / 2, startPoint.Y)
                    });
                    shapes.Add(new MyFillParallelogram
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        SolidBrush = brush
                    });
                    break;

                //rhombus
                case 8:
                    g.DrawPolygon(myPen, new Point[] {
                    new Point((startPoint.X + e.Location.X) / 2, startPoint.Y),
                    new Point(e.Location.X, (startPoint.Y + e.Location.Y) / 2),
                    new Point((startPoint.X + e.Location.X) / 2, e.Location.Y),
                    new Point(startPoint.X, (startPoint.Y + e.Location.Y) / 2)
                    });
                    shapes.Add(new MyRhombus
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        SolidBrush = brush
                    });

                    break;

                //fill rhombus
                case 9:
                    g.DrawPolygon(myPen, new Point[] {
                        new Point((startPoint.X + e.Location.X) / 2, startPoint.Y),
                        new Point(e.Location.X, (startPoint.Y + e.Location.Y) / 2),
                        new Point((startPoint.X + e.Location.X) / 2, e.Location.Y),
                        new Point(startPoint.X, (startPoint.Y + e.Location.Y) / 2)
                    });
                                    g.FillPolygon(brush, new Point[] {
                        new Point((startPoint.X + e.Location.X) / 2, startPoint.Y),
                        new Point(e.Location.X, (startPoint.Y + e.Location.Y) / 2),
                        new Point((startPoint.X + e.Location.X) / 2, e.Location.Y),
                        new Point(startPoint.X, (startPoint.Y + e.Location.Y) / 2)
                    });
                    shapes.Add(new MyFillRhombus
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        SolidBrush = brush
                    });
                    break;

                //circle
                case 10:
                    int diameter = Math.Min(width, height);
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

                //fill circle
                case 11:
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
                    // Handle unexpected case (optional
                    break;
            }
            
            switch(cboBrushType.SelectedIndex)
            {
                case 0:
                    LinearGradientMode gradientMode;
                    gradientMode = LinearGradientMode.BackwardDiagonal;

                    // Tạo LinearGradientBrush với chế độ gradient được chọn
                    LinearGradientBrush linearGradientBrush = new LinearGradientBrush(
                        new Rectangle(xLoc, yLoc, width, height), // Điểm bắt đầu và kích thước của hình bình hành
                        FillColor, // Màu FillColor ở đầu
                        Color.White, // Màu trắng ở cuối
                        gradientMode); // Chế độ gradient
                    break;
                case 1:
                    
                    break;
            }
            
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem item nào được chọn trong cboType
            int selectedCase = cboType.SelectedIndex;

            // Nếu selectedCase tồn tại trong Dictionary và có mục tương ứng trong brushTypeItems
            if (brushTypeItems.ContainsKey(selectedCase))
            {
                // Xóa các mục cũ trong cboBrushType và thêm các mục mới từ Dictionary
                cboBrushType.Items.Clear();
                foreach (string item in brushTypeItems[selectedCase])
                {
                    cboBrushType.Items.Add(item);
                }

                // Hiển thị cboBrushType
                cboBrushType.Visible = true;
                lblBrushType.Visible = true;    
            }
            else
            {
                // Nếu không có mục tương ứng, ẩn cboBrushType
                cboBrushType.Visible = false;
                lblBrushType.Visible = false;
            }
        }

        //ngăn cho người dùng nhập vào combobox
        private void cboType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void FrmMain_ResizeEnd(object sender, EventArgs e)
        {
            //ResizeDrawingPanel();
            //ResizeShapes();
        }

      

        private void FrmMain_Resize(object sender, EventArgs e)
        {

        }

        private void panelKhungVe_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in shapes)
            {
                shape.Draw(g);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (shapes.Count > 0)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "BMP files (*.bmp)|*.bmp|PNG files (*.png)|*.png|JPEG files (*.jpeg)|*.jpeg";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = saveFileDialog.FileName;
                        SaveImage(fileName);
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có hình nào được vẽ để lưu!");
            }
        }

        private void SaveImage(string fileName)
        {
            int width = panelKhungVe.Width;
            int height = panelKhungVe.Height;

            using (Bitmap bmp = new Bitmap(width, height))
            {
                using (Graphics bmpGraphics = Graphics.FromImage(bmp))
                {
                    foreach (var shape in shapes)
                    {
                        shape.Draw(bmpGraphics);
                    }
                }

                // Lưu hình ảnh xuống tệp tin
                bmp.Save(fileName);
            }
        }

        private void cboBrushType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboBrushType_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        

        private void FrmMain_Load(object sender, EventArgs e)
        {
            cboBrushType.Visible = false;
            lblBrushType.Visible = false;
        }
    }
}
