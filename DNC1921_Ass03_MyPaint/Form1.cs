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
                case 6: // Parallelogram(Hình bình hành)
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

                case 7: // Parallelogram (Hình bình hành) với LinearGradientBrush
                    GraphicsPath parallelogramPath = new GraphicsPath();
                    parallelogramPath.AddPolygon(new Point[] {
                    startPoint,
                    new Point(startPoint.X + (e.Location.X - startPoint.X) / 2, e.Location.Y),
                    e.Location,
                    new Point(e.Location.X - (e.Location.X - startPoint.X) / 2, startPoint.Y)
                    });

                    LinearGradientMode gradientMode;
                    gradientMode = LinearGradientMode.Horizontal;

                    // Tạo LinearGradientBrush với chế độ gradient được chọn
                    LinearGradientBrush linearGradientBrush = new LinearGradientBrush(
                        new Rectangle(xLoc, yLoc, width, height), // Điểm bắt đầu và kích thước của hình bình hành
                        FillColor, // Màu FillColor ở đầu
                        Color.White, // Màu trắng ở cuối
                        gradientMode); // Chế độ gradient

                    // Tô màu cho hình bình hành
                    g.DrawPath(myPen, parallelogramPath); // Vẽ hình bình hành với đường viền
                    g.FillPath(linearGradientBrush, parallelogramPath); // Tô màu bằng LinearGradientBrush
                    shapes.Add(new MyParallelogram
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        FillBrush = linearGradientBrush // Gán LinearGradientBrush vào FillBrush của hình
                    });
                    break;

                case 8: // Parallelogram(Hình bình hành) với PathGradientBrush 
                    GraphicsPath parallelogramPat = new GraphicsPath();
                    parallelogramPat.AddPolygon(new Point[] {
                    startPoint,
                    new Point(startPoint.X + (e.Location.X - startPoint.X) / 2, e.Location.Y),
                    e.Location,
                    new Point(e.Location.X - (e.Location.X - startPoint.X) / 2, startPoint.Y)
                    });

                    PathGradientBrush pathGradientBrush;

                    pathGradientBrush = new PathGradientBrush(parallelogramPat);

                    Color[] colors = { FillColor, Color.White };

                    pathGradientBrush.CenterColor = FillColor;


                    pathGradientBrush.SurroundColors = new Color[] { Color.White };

                    // Fill the Parallelogram shape with the PathGradientBrush
                    g.DrawPath(myPen, parallelogramPat); // Draw the outline
                    g.FillPath(pathGradientBrush, parallelogramPat); // Fill with gradient

                    // Add the MyParallelogram object to the list of shapes
                    shapes.Add(new MyParallelogram
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        FillBrush = pathGradientBrush
                    });
                    break;


                case 9: // Parallelogram(Hình bình hành) với -	TextureBrush

                    OpenFileDialog openFileDialog = new OpenFileDialog();

                    openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        // Load the selected image
                        Image selectedImage = Image.FromFile(openFileDialog.FileName);

                        TextureBrush textureBrush = new TextureBrush(selectedImage);

                        g.FillRectangle(textureBrush, 100, 100, 500, 400);

                        shapes.Add(new MyParallelogram
                        {
                            startPoint = startPoint,
                            endPoint = e.Location,
                            Pen = myPen,
                            FillBrush = textureBrush
                        });

                    }
                    break;

                case 10: //Parallelogram(Hình bình hành) với - HatchBrush

                    GraphicsPath parallelogramPath_bh = new GraphicsPath();
                    parallelogramPath_bh.AddPolygon(new Point[] {
                    startPoint,
                    new Point(startPoint.X + (e.Location.X - startPoint.X) / 2, e.Location.Y),
                    e.Location,
                    new Point(e.Location.X - (e.Location.X - startPoint.X) / 2, startPoint.Y)
                    });

                    HatchBrush hatchBrush = new HatchBrush(HatchStyle.Horizontal, FillColor, BorderColor);

                    g.DrawPath(myPen, parallelogramPath_bh); // Vẽ hình bình hành với đường viền
                    g.FillPath(hatchBrush, parallelogramPath_bh); // Tô màu bằng hatchBrush
                    shapes.Add(new MyParallelogram
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        FillBrush = hatchBrush // Gán hatchBrush vào FillBrush của hình
                    });
                    break;

                case 11: // Rhombus (Hình thoi)
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

                case 12: // Rhombus (Hình thoi) với LinearGradientBrush
                    GraphicsPath rhombusPath = new GraphicsPath();
                    rhombusPath.AddPolygon(new Point[] {
                     new Point((startPoint.X + e.Location.X) / 2, startPoint.Y),
                     new Point(e.Location.X, (startPoint.Y + e.Location.Y) / 2),
                     new Point((startPoint.X + e.Location.X) / 2, e.Location.Y),
                     new Point(startPoint.X, (startPoint.Y + e.Location.Y) / 2)
                    });

                    // Chọn chế độ gradient
                    LinearGradientMode gradientMode_thoi = LinearGradientMode.Horizontal;

                    // Tạo LinearGradientBrush với chế độ gradient được chọn
                    LinearGradientBrush linearGradientBrush_thoi = new LinearGradientBrush(
                        new Rectangle(xLoc, yLoc, width, height), // Điểm bắt đầu và kích thước của hình thoi
                        FillColor, // Màu FillColor ở đầu
                        Color.White, // Màu trắng ở cuối
                        gradientMode_thoi); // Chế độ gradient

                    // Tô màu cho hình thoi
                    g.DrawPath(myPen, rhombusPath); // Vẽ hình thoi với đường viền
                    g.FillPath(linearGradientBrush_thoi, rhombusPath); // Tô màu bằng LinearGradientBrush
                    shapes.Add(new MyRhombus
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        FillBrush = linearGradientBrush_thoi // Gán LinearGradientBrush vào FillBrush của hình
                    });
                    break;

                case 13:// Rhombus (Hình thoi) với PathGradientBrush
                    GraphicsPath rhombusPath_pathGradientBrush = new GraphicsPath();
                    rhombusPath_pathGradientBrush.AddPolygon(new Point[] {
                    new Point((startPoint.X + e.Location.X) / 2, startPoint.Y),
                    new Point(e.Location.X, (startPoint.Y + e.Location.Y) / 2),
                    new Point((startPoint.X + e.Location.X) / 2, e.Location.Y),
                    new Point(startPoint.X, (startPoint.Y + e.Location.Y) / 2)
                    });

                    // Tạo PathGradientBrush với hình dạng hình thoi
                    PathGradientBrush pathGradientBrus = new PathGradientBrush(rhombusPath_pathGradientBrush);

                    // Xác định các màu để kết hợp
                    Color[] color_pathGradientBrush = { FillColor, Color.White }; // Màu ví dụ

                    // Đặt màu tâm
                    pathGradientBrus.CenterColor = FillColor;

                    // Đặt các màu xung quanh
                    pathGradientBrus.SurroundColors = new Color[] { Color.White }; // Màu xung quanh ví dụ

                    // Tô màu cho hình thoi bằng PathGradientBrush
                    g.DrawPath(myPen, rhombusPath_pathGradientBrush); // Vẽ viền
                    g.FillPath(pathGradientBrus, rhombusPath_pathGradientBrush); // Tô màu gradient

                    // Thêm đối tượng MyRhombus vào danh sách các hình
                    shapes.Add(new MyRhombus
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        FillBrush = pathGradientBrus // Gán PathGradientBrush vào FillBrush của hình
                    });
                    break;

                case 14: //Rhombus (Hình thoi) với TextureBrush

                    OpenFileDialog openFileDialo = new OpenFileDialog();

                    openFileDialo.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
                    if (openFileDialo.ShowDialog() == DialogResult.OK)
                    {

                        // Load image đã chọn
                        Image selectedImage = Image.FromFile(openFileDialo.FileName);

                        // Tạo a TextureBrush chọn
                        TextureBrush textureBrush = new TextureBrush(selectedImage);

                        g.FillRectangle(textureBrush, 100, 100, 500, 400);

                        shapes.Add(new MyRhombus
                        {
                            startPoint = startPoint,
                            endPoint = e.Location,
                            Pen = myPen,
                            FillBrush = textureBrush
                        });

                    }
                    break;

                case 15: //Rhombus (Hình thoi) với - HatchBrush

                    GraphicsPath parallelogramPath_hatchBrush = new GraphicsPath();
                    parallelogramPath_hatchBrush.AddPolygon(new Point[] {
                    new Point((startPoint.X + e.Location.X) / 2, startPoint.Y),
                    new Point(e.Location.X, (startPoint.Y + e.Location.Y) / 2),
                    new Point((startPoint.X + e.Location.X) / 2, e.Location.Y),
                    new Point(startPoint.X, (startPoint.Y + e.Location.Y) / 2)
                    });

                    HatchBrush hatchBrus = new HatchBrush(HatchStyle.Horizontal, FillColor, BorderColor);

                    g.DrawPath(myPen, parallelogramPath_hatchBrush); // Vẽ hình thoi với đường viền
                    g.FillPath(hatchBrus, parallelogramPath_hatchBrush); // Tô màu bằng hatchBrush
                    shapes.Add(new MyRhombus
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        FillBrush = hatchBrus // Gán hatchBrush vào FillBrush của hình
                    });
                    break;

                case 16: // Circle
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
                case 17: // Fill Circle
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
    }
}
