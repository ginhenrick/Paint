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
            IsMdiContainer = true;
            this.Resize += new EventHandler(FrmMain_Resize);
        }

        Color BorderColor = Color.Black;
        Color FillColor = Color.Black;
        Color StringColor = Color.Black;
        Point startPoint = Point.Empty;
        Graphics g = null;
        List<MyShape> shapes = new List<MyShape>();
        List<Brush> brushs = new List<Brush>();


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
            {// Case 0: Text

                case 0:
                    // Gọi hàm để chọn màu cho văn bản
                    btnStringColor_Click(sender, e);

                    // Lấy font
                    var font = new Font("Arial", 20);

                    // Lấy màu
                    var stringBrush = new SolidBrush(mauTo);

                    // Lấy vị trí
                    int x = int.Parse(txtX.Text);
                    int y = int.Parse(txtY.Text);

                    // Vẽ văn bản
                    using (var g = panelKhungVe.CreateGraphics())
                    {
                        // Vẽ văn bản
                        g.DrawString(txtString.Text, font, brush, x, y);

                        // Thêm thông tin về văn bản vào danh sách các hình vẽ
                        shapes.Add(new MyString
                        {
                            Text = txtString.Text,
                            Font = font,
                            stringBrush = brush,
                            X = x,
                            Y = y
                        });
                    }
                    break;


                //==================================================================================================================================================
                // Case 1: Line
                case 1:
                    g.DrawLine(myPen, startPoint, e.Location);
                    shapes.Add(new MyLine
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen
                    }
                        );
                    break;
                //==================================================================================================================================================
                // Case 2: Rectangle
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

                // Case 3.1: Rectangle_Horizontal
                case 3:
                    // Tạo đường dẫn cho hình chữ nhật
                    GraphicsPath rectanglePath = new GraphicsPath();
                    rectanglePath.AddRectangle(new Rectangle(xLoc, yLoc, width, height));

                    // Chọn chế độ linear gradient mode là Horizontal
                    LinearGradientMode gradientModeRectangle;
                    gradientModeRectangle = LinearGradientMode.Horizontal;

                    // Tạo LinearGradientBrush với chế độ gradient được chọn
                    LinearGradientBrush linearGradientBrushRectangle = new LinearGradientBrush(
                        new Rectangle(xLoc, yLoc, width, height), // Điểm bắt đầu và kích thước của hình chữ nhật
                        FillColor, // Màu FillColor ở đầu
                        Color.White, // Màu trắng ở cuối
                        gradientModeRectangle); // Chế độ gradient

                    // Vẽ hình chữ nhật với đường viền
                    g.DrawRectangle(myPen, xLoc, yLoc, width, height);

                    // Tô màu bằng LinearGradientBrush
                    g.FillRectangle(linearGradientBrushRectangle, xLoc, yLoc, width, height);

                    // Thêm hình chữ nhật vào danh sách các hình được vẽ
                    shapes.Add(new MyRectangleHorizontal
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        FillBrush = linearGradientBrushRectangle // Gán LinearGradientBrush vào FillBrush của hình
                    });
                    break;

                // Case 3.2: Rectangle_PathGradientBrush
                case 4:
                    // Tạo đường dẫn cho hình chữ nhật
                    GraphicsPath rectanglePathBrush = new GraphicsPath();
                    rectanglePathBrush.AddRectangle(new Rectangle(startPoint.X, startPoint.Y, e.Location.X - startPoint.X, e.Location.Y - startPoint.Y));

                    // Tạo PathGradientBrush từ đường dẫn của hình chữ nhật
                    PathGradientBrush pathGradientBrushRect = new PathGradientBrush(rectanglePathBrush);

                    // Thiết lập màu trung tâm cho PathGradientBrush
                    pathGradientBrushRect.CenterColor = FillColor;

                    // Thiết lập màu xung quanh cho PathGradientBrush
                    pathGradientBrushRect.SurroundColors = new Color[] { Color.White };

                    // Vẽ hình chữ nhật với đường viền
                    g.DrawRectangle(myPen, startPoint.X, startPoint.Y, e.Location.X - startPoint.X, e.Location.Y - startPoint.Y);

                    // Tô màu bằng PathGradientBrush
                    g.FillRectangle(pathGradientBrushRect, startPoint.X, startPoint.Y, e.Location.X - startPoint.X, e.Location.Y - startPoint.Y);

                    // Thêm hình chữ nhật vào danh sách các hình được vẽ
                    shapes.Add(new MyRectanglePathGradientBrush
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        FillBrush = pathGradientBrushRect
                    });
                    break;

                // Case 3.3: Rectangle_TextureBrush
                case 5: // Rectangle TextureBrush
                    using (OpenFileDialog ofRectangle = new OpenFileDialog())
                    {
                        ofRectangle.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
                        if (ofRectangle.ShowDialog() == DialogResult.OK)
                        {
                            // Load the selected image
                            Image selectedImage = Image.FromFile(ofRectangle.FileName);

                            // Tính toán kích thước hình ảnh mới để phù hợp với kích thước của hình chữ nhật
                            int WRec = Math.Abs(e.Location.X - startPoint.X);
                            int HRec = Math.Abs(e.Location.Y - startPoint.Y);

                            // Tạo TextureBrush từ hình ảnh đã chọn
                            TextureBrush textureBrush = new TextureBrush(selectedImage);

                            // Vẽ hình chữ nhật với kích thước mới của hình ảnh
                            g.FillRectangle(textureBrush, startPoint.X, startPoint.Y, width, height);

                            // Thêm hình chữ nhật vào danh sách các hình đã vẽ
                            shapes.Add(new MyRectangleTextureBrush
                            {
                                startPoint = startPoint,
                                endPoint = e.Location,
                                Pen = myPen,
                                FillBrush = textureBrush
                            });
                        }
                    }
                    break;

                // Case 3.4: Rectangle_HatchBrush
                case 6:
                    // Tạo đường dẫn cho hình chữ nhật
                    GraphicsPath rectanglePath_hatchBrush = new GraphicsPath();
                    rectanglePath_hatchBrush.AddRectangle(new Rectangle(startPoint.X, startPoint.Y, e.Location.X - startPoint.X, e.Location.Y - startPoint.Y));

                    // Tạo HatchBrush với mẫu hatch và màu fill
                    HatchBrush Rectangle_HatchBrush = new HatchBrush(HatchStyle.Horizontal, FillColor, BorderColor);

                    // Vẽ hình chữ nhật bằng HatchBrush
                    g.FillRectangle(Rectangle_HatchBrush, startPoint.X, startPoint.Y, e.Location.X - startPoint.X, e.Location.Y - startPoint.Y);

                    // Vẽ viền của hình chữ nhật
                    g.DrawRectangle(new Pen(BorderColor, float.Parse(nudBorderSize.Value.ToString())), startPoint.X, startPoint.Y, e.Location.X - startPoint.X, e.Location.Y - startPoint.Y);

                    // Thêm hình chữ nhật vào danh sách các hình được vẽ
                    shapes.Add(new MyRectangleHatchBrush
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = new Pen(BorderColor, float.Parse(nudBorderSize.Value.ToString())),
                        FillBrush = Rectangle_HatchBrush // Gán hatchBrush vào FillBrush của hình
                    });
                    break;

                // Case 3.5: Fill Rectangle
                case 7:
                    g.FillRectangle(brush, xLoc, yLoc, width, height);
                    shapes.Add(new MyFillRectangle
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        SolidBrush = brush
                    });
                    break;
                //==================================================================================================================================================
                // Case 4: Ellipse
                case 8:
                    g.DrawEllipse(myPen, xLoc, yLoc, width, height);
                    shapes.Add(new MyEllipse
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        SolidBrush = brush
                    });
                    break;

                // Case 4.1: Ellipse_Horizontal
                case 9:
                    // Tạo đường dẫn cho hình ellipse
                    GraphicsPath ellipsePath = new GraphicsPath();
                    ellipsePath.AddEllipse(new Rectangle(xLoc, yLoc, width, height));

                    // Chọn chế độ linear gradient mode là BackwardDiagonal
                    LinearGradientMode gradientModeEllipse;
                    gradientModeEllipse = LinearGradientMode.BackwardDiagonal;

                    // Tạo LinearGradientBrush với chế độ gradient được chọn
                    LinearGradientBrush linearGradientBrushEllipse = new LinearGradientBrush(
                        new Rectangle(xLoc, yLoc, width, height), // Điểm bắt đầu và kích thước của hình ellipse
                        FillColor, // Màu FillColor ở đầu
                        Color.White, // Màu trắng ở cuối
                        gradientModeEllipse); // Chế độ gradient

                    // Vẽ hình ellipse với đường viền
                    g.DrawEllipse(myPen, xLoc, yLoc, width, height);

                    // Tô màu bằng LinearGradientBrush
                    g.FillEllipse(linearGradientBrushEllipse, xLoc, yLoc, width, height);

                    // Thêm hình ellipse vào danh sách các hình được vẽ
                    shapes.Add(new MyEllipseHorizontal
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        FillBrush = linearGradientBrushEllipse // Gán LinearGradientBrush vào FillBrush của hình
                    });
                    break;

                // Case 4.2: Ellipse_PathGradientBrush
                case 10:
                    // Tính kích thước của hình ellipse
                    int widthEllipse = Math.Abs(e.Location.X - startPoint.X);
                    int heightEllipse = Math.Abs(e.Location.Y - startPoint.Y);

                    // Tính tọa độ x và y của hình ellipse
                    int xEllipse = Math.Min(startPoint.X, e.Location.X);
                    int yEllipse = Math.Min(startPoint.Y, e.Location.Y);

                    // Tạo đường dẫn cho hình ellipse
                    GraphicsPath ellipsePathBrush = new GraphicsPath();
                    ellipsePathBrush.AddEllipse(new Rectangle(xEllipse, yEllipse, widthEllipse, heightEllipse));

                    // Tạo PathGradientBrush từ đường dẫn của hình ellipse
                    PathGradientBrush pathGradientBrushEllipse = new PathGradientBrush(ellipsePathBrush);

                    // Thiết lập màu trung tâm cho PathGradientBrush
                    pathGradientBrushEllipse.CenterColor = FillColor;

                    // Thiết lập màu xung quanh cho PathGradientBrush
                    pathGradientBrushEllipse.SurroundColors = new Color[] { Color.White };

                    // Vẽ hình ellipse với đường viền
                    g.DrawEllipse(myPen, xEllipse, yEllipse, widthEllipse, heightEllipse);

                    // Tô màu bằng PathGradientBrush
                    g.FillEllipse(pathGradientBrushEllipse, xEllipse, yEllipse, widthEllipse, heightEllipse);

                    // Thêm hình ellipse vào danh sách các hình được vẽ
                    shapes.Add(new MyEllipsePathGradientBrush
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        FillBrush = pathGradientBrushEllipse
                    });

                    break;


                case 11: // Ellipse với TextureBrush
                    OpenFileDialog ofEllipseTexture = new OpenFileDialog();

                    ofEllipseTexture.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
                    if (ofEllipseTexture.ShowDialog() == DialogResult.OK)
                    {
                        // Load the selected image
                        Image selectedImage = Image.FromFile(ofEllipseTexture.FileName);

                        // Tính kích thước của hình ellipse để phù hợp với kích thước của hình được chọn từ tệp hình ảnh
                        int WidthEllipse = Math.Min(e.Location.X - startPoint.X, selectedImage.Width); // Chọn kích thước nhỏ nhất giữa kích thước của hình được chọn và kích thước của ellipse
                        int HeightEllipse = Math.Min(e.Location.Y - startPoint.Y, selectedImage.Height); // Chọn kích thước nhỏ nhất giữa kích thước của hình được chọn và kích thước của ellipse

                        // Tính tọa độ x và y của hình ellipse để đặt hình chính giữa ellipse
                        int XEllipse = startPoint.X + (e.Location.X - startPoint.X) / 2 - WidthEllipse / 2;
                        int YEllipse = startPoint.Y + (e.Location.Y - startPoint.Y) / 2 - HeightEllipse / 2;

                        // Tạo TextureBrush từ hình ảnh đã chọn
                        TextureBrush textureBrushEllipse = new TextureBrush(selectedImage);

                        // Vẽ hình ellipse bằng TextureBrush
                        g.FillEllipse(textureBrushEllipse, XEllipse, YEllipse, WidthEllipse, HeightEllipse);

                        // Vẽ viền của hình ellipse
                        g.DrawEllipse(myPen, XEllipse, YEllipse, WidthEllipse, HeightEllipse);

                        // Thêm hình ellipse vào danh sách các hình được vẽ
                        shapes.Add(new MyEllipseTextureBrush
                        {
                            startPoint = startPoint,
                            endPoint = e.Location,
                            Pen = myPen,
                            FillBrush = textureBrushEllipse
                        });
                    }
                    break;

                // Case 4.4: Ellipse_HatchBrush
                case 12:
                    // Tính kích thước của hình ellipse để phù hợp với kích thước của hình chữ nhật được chọn
                    int widthEllipseHB = e.Location.X - startPoint.X;
                    int heightEllipseHB = e.Location.Y - startPoint.Y;

                    // Tính tọa độ x và y của hình ellipse để đặt ellipse vào vị trí tương ứng
                    int xEllipseHB = Math.Min(startPoint.X, e.Location.X);
                    int yEllipseHB = Math.Min(startPoint.Y, e.Location.Y);

                    // Tạo đường dẫn cho hình ellipse
                    GraphicsPath ellipsePathHB = new GraphicsPath();
                    ellipsePathHB.AddEllipse(new Rectangle(xEllipseHB, yEllipseHB, widthEllipseHB, heightEllipseHB));

                    // Tạo HatchBrush
                    HatchBrush hatchBrushEllipse = new HatchBrush(HatchStyle.Horizontal, FillColor, BorderColor);

                    // Vẽ hình ellipse với đường viền
                    g.DrawEllipse(myPen, xEllipseHB, yEllipseHB, widthEllipseHB, heightEllipseHB);

                    // Tô màu bằng HatchBrush
                    g.FillEllipse(hatchBrushEllipse, xEllipseHB, yEllipseHB, widthEllipseHB, heightEllipseHB);

                    // Thêm hình ellipse vào danh sách các hình được vẽ
                    shapes.Add(new MyEllipseHatchBrush
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        FillBrush = hatchBrushEllipse
                    });

                    break;


                // Case 4.5: Fill Ellipse
                case 13:
                    g.FillEllipse(brush, xLoc, yLoc, width, height);
                    shapes.Add(new MyFillEllipse
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        SolidBrush = brush
                    });
                    break;
                //==================================================================================================================================================

                // Case 5: Parallelogram
                case 14:
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

                // Case 5.1: Parallelogram_Horizontal
                case 15:
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
                    shapes.Add(new MyParallelogramHorizontal
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        FillBrush = linearGradientBrush // Gán LinearGradientBrush vào FillBrush của hình
                    });

                    break;

                // Case 5.2: Parallelogram_PathGradientBrush
                case 16:
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

                // Case 5.3: Parallelogram_TextureBrush
                case 17: // Parallelogram TextureBrush
                    OpenFileDialog ofParallelogram = new OpenFileDialog();
                    ofParallelogram.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";

                    if (ofParallelogram.ShowDialog() == DialogResult.OK)
                    {
                        // Load the selected image
                        Image selectedImage = Image.FromFile(ofParallelogram.FileName);

                        // Create TextureBrush from the selected image
                        TextureBrush textureBrush = new TextureBrush(selectedImage);

                        // Calculate the width and height of the parallelogram
                        int WPolygon = Math.Abs(e.Location.X - startPoint.X);
                        int HPolygon = Math.Abs(e.Location.Y - startPoint.Y);

                        // Calculate the points of the parallelogram

                        Point[] parallelogramPoints = CalculateParallelogramPoints(startPoint, e.Location);

                        // Draw the parallelogram with the texture
                        g.FillPolygon(textureBrush, parallelogramPoints);

                        // Add the parallelogram to the list of shapes
                        shapes.Add(new MyParallelogramTextureBrush
                        {
                            startPoint = startPoint,
                            endPoint = e.Location,
                            Pen = myPen,
                            FillBrush = textureBrush
                        });
                    }

                    break;


                // Case 5.4: Parallelogram_HatchBrush
                case 18:
                    GraphicsPath parallelogramPath_bh = new GraphicsPath();
                    parallelogramPath_bh.AddPolygon(new Point[] {
                     startPoint,
                     new Point(startPoint.X + (e.Location.X - startPoint.X) / 2, e.Location.Y),
                     e.Location,
                     new Point(e.Location.X - (e.Location.X - startPoint.X) / 2, startPoint.Y)
                     });

                    HatchBrush Parallelogram_HatchBrush = new HatchBrush(HatchStyle.Horizontal, FillColor, BorderColor);

                    g.DrawPath(myPen, parallelogramPath_bh); // Vẽ hình bình hành với đường viền
                    g.FillPath(Parallelogram_HatchBrush, parallelogramPath_bh); // Tô màu bằng hatchBrush
                    shapes.Add(new MyParallelogram
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        FillBrush = Parallelogram_HatchBrush // Gán hatchBrush vào FillBrush của hình
                    });

                    break;

                // Case 5.5: Fill Parallelogram
                case 19:
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
                //==================================================================================================================================================

                // Case 6: Rhombus
                case 20:
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


                case 21: //Horizontal
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
                    shapes.Add(new MyRhombusHorizontal
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        FillBrush = linearGradientBrush_thoi // Gán LinearGradientBrush vào FillBrush của hình
                    });

                    break;

                // Case 6.2: Rhombus_PathGradientBrush
                case 22:
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
                    shapes.Add(new MyRhombusPathGradientBrush
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        FillBrush = pathGradientBrus // Gán PathGradientBrush vào FillBrush của hình
                    });

                    break;

                case 23: // Hình thoi với TextureBrush
                    OpenFileDialog ofRhombus = new OpenFileDialog();
                    ofRhombus.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";

                    if (ofRhombus.ShowDialog() == DialogResult.OK)
                    {
                        // Load the selected image
                        Image selectedImage = Image.FromFile(ofRhombus.FileName);

                        // Create TextureBrush from the selected image
                        TextureBrush textureBrush = new TextureBrush(selectedImage);

                        // Calculate the width and height of the rhombus to fit the selected image
                        int widthRhombus = Math.Min(e.Location.X - startPoint.X, selectedImage.Width);
                        int heightRhombus = Math.Min(e.Location.Y - startPoint.Y, selectedImage.Height);

                        // Calculate the coordinates of the rhombus to center the image within the rhombus
                        int xRhombus = startPoint.X + (e.Location.X - startPoint.X) / 2 - widthRhombus / 2;
                        int yRhombus = startPoint.Y + (e.Location.Y - startPoint.Y) / 2 - heightRhombus / 2;

                        // Create a GraphicsPath for the rhombus
                        GraphicsPath rhombusTexturePath = new GraphicsPath();
                        rhombusTexturePath.AddPolygon(new Point[] {
                                new Point(xRhombus + widthRhombus / 2, yRhombus),
                                new Point(xRhombus + widthRhombus, yRhombus + heightRhombus / 2),
                                new Point(xRhombus + widthRhombus / 2, yRhombus + heightRhombus),
                                new Point(xRhombus, yRhombus + heightRhombus / 2)
                            });

                        // Fill the rhombus with TextureBrush
                        g.FillPath(textureBrush, rhombusTexturePath);

                        // Draw the border of the rhombus
                        g.DrawPath(myPen, rhombusTexturePath);

                        // Add the rhombus to the list of shapes
                        shapes.Add(new MyRhombusTextureBrush
                        {
                            startPoint = startPoint,
                            endPoint = e.Location,
                            Pen = myPen,
                            FillBrush = textureBrush
                        });
                    }
                    break;




                // Case 6.4: Rhombus_HatchBrush
                case 24:
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
                    shapes.Add(new MyRhombusHatchBrush
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        FillBrush = hatchBrus // Gán hatchBrush vào FillBrush của hình
                    });

                    break;

                // Case 6.5: Fill Rhombus
                case 25:
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
                //==================================================================================================================================================

                // Case 7: Circle
                case 26:
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

                // Case 7.1: Circle_BackwardDiagonal
                case 27:
                    // Tính đường kính của hình tròn
                    int diameterCircle = Math.Min(e.Location.X - startPoint.X, e.Location.Y - startPoint.Y); // Giả sử hình tròn nằm trong hình chữ nhật
                    int radiusCircle = diameterCircle / 2;

                    // Tính tọa độ x và y của hình tròn
                    int xLocCircle = startPoint.X + (e.Location.X - startPoint.X) / 2 - radiusCircle;
                    int yLocCircle = startPoint.Y + (e.Location.Y - startPoint.Y) / 2 - radiusCircle;

                    // Tạo đường dẫn cho hình tròn
                    GraphicsPath circlePath = new GraphicsPath();
                    circlePath.AddEllipse(new Rectangle(xLocCircle, yLocCircle, diameterCircle, diameterCircle));

                    // Chọn chế độ linear gradient mode là BackwardDiagonal
                    LinearGradientMode gradientModeCircle;
                    gradientModeCircle = LinearGradientMode.BackwardDiagonal;

                    // Tạo LinearGradientBrush với chế độ gradient được chọn
                    LinearGradientBrush linearGradientBrushCircle = new LinearGradientBrush(
                        new Rectangle(xLocCircle, yLocCircle, diameterCircle, diameterCircle), // Điểm bắt đầu và kích thước của hình tròn
                        FillColor, // Màu FillColor ở đầu
                        Color.White, // Màu trắng ở cuối
                        gradientModeCircle); // Chế độ gradient

                    // Vẽ hình tròn với đường viền
                    g.DrawEllipse(myPen, xLocCircle, yLocCircle, diameterCircle, diameterCircle);

                    // Tô màu bằng LinearGradientBrush
                    g.FillEllipse(linearGradientBrushCircle, xLocCircle, yLocCircle, diameterCircle, diameterCircle);

                    // Thêm hình tròn vào danh sách các hình được vẽ
                    shapes.Add(new MyCircleHorizontal
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        FillBrush = linearGradientBrushCircle // Gán LinearGradientBrush vào FillBrush của hình
                    });
                    break;

                // Case 7.2: Circle_PathGradientBrush
                case 28:
                    // Tính đường kính của hình tròn
                    int diameterCirclePath = Math.Min(e.Location.X - startPoint.X, e.Location.Y - startPoint.Y); // Giả sử hình tròn nằm trong hình chữ nhật
                    int radiusCirclePath = diameterCirclePath / 2;

                    // Tính tọa độ x và y của hình tròn
                    int xLocCirclePath = startPoint.X + (e.Location.X - startPoint.X) / 2 - radiusCirclePath;
                    int yLocCirclePath = startPoint.Y + (e.Location.Y - startPoint.Y) / 2 - radiusCirclePath;

                    // Tạo đường dẫn cho hình tròn
                    GraphicsPath circlePathBrush = new GraphicsPath();
                    circlePathBrush.AddEllipse(new Rectangle(xLocCirclePath, yLocCirclePath, diameterCirclePath, diameterCirclePath));

                    // Tạo PathGradientBrush từ đường dẫn của hình tròn
                    PathGradientBrush pathGradientBrushCircle = new PathGradientBrush(circlePathBrush);

                    // Thiết lập màu trung tâm cho PathGradientBrush
                    pathGradientBrushCircle.CenterColor = FillColor;

                    // Thiết lập màu xung quanh cho PathGradientBrush
                    pathGradientBrushCircle.SurroundColors = new Color[] { Color.White };

                    // Vẽ hình tròn với đường viền
                    g.DrawEllipse(myPen, xLocCirclePath, yLocCirclePath, diameterCirclePath, diameterCirclePath);

                    // Tô màu bằng PathGradientBrush
                    g.FillEllipse(pathGradientBrushCircle, xLocCirclePath, yLocCirclePath, diameterCirclePath, diameterCirclePath);

                    // Thêm hình tròn vào danh sách các hình được vẽ
                    shapes.Add(new MyCircle
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        FillBrush = pathGradientBrushCircle
                    });

                    break;

                // Case 7.3: Circle_TextureBrush
                case 29:
                    OpenFileDialog ofCircle = new OpenFileDialog();

                    ofCircle.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
                    if (ofCircle.ShowDialog() == DialogResult.OK)
                    {

                        // Load image đã chọn
                        Image selectedImage = Image.FromFile(ofCircle.FileName);

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

                // Case 7.4: Circle_HatchBrush
                case 30:
                    // Tính đường kính của hình tròn
                    int diameterCircleHB = Math.Min(e.Location.X - startPoint.X, e.Location.Y - startPoint.Y); // Giả sử hình tròn nằm trong hình chữ nhật
                    int radiusCircleHB = diameterCircleHB / 2;

                    // Tính tọa độ x và y của hình tròn
                    int xLocCircleHB = startPoint.X + (e.Location.X - startPoint.X) / 2 - radiusCircleHB;
                    int yLocCircleHB = startPoint.Y + (e.Location.Y - startPoint.Y) / 2 - radiusCircleHB;

                    // Tạo đường dẫn cho hình tròn
                    GraphicsPath circlePathHB = new GraphicsPath();
                    circlePathHB.AddEllipse(new Rectangle(xLocCircleHB, yLocCircleHB, diameterCircleHB, diameterCircleHB));

                    // Tạo HatchBrush
                    HatchBrush hatchBrushCircle = new HatchBrush(HatchStyle.Horizontal, FillColor, BorderColor);

                    // Vẽ hình tròn với đường viền
                    g.DrawEllipse(myPen, xLocCircleHB, yLocCircleHB, diameterCircleHB, diameterCircleHB);

                    // Tô màu bằng HatchBrush
                    g.FillEllipse(hatchBrushCircle, xLocCircleHB, yLocCircleHB, diameterCircleHB, diameterCircleHB);

                    // Thêm hình tròn vào danh sách các hình được vẽ
                    shapes.Add(new MyCircle
                    {
                        startPoint = startPoint,
                        endPoint = e.Location,
                        Pen = myPen,
                        FillBrush = hatchBrushCircle
                    });

                    break;

                // Case 7.5: Fill Circle
                case 31:
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

            }
        }

        private Point[] CalculateParallelogramPoints(Point startPoint, Point endPoint)
        {
            // Tính toán các điểm cho hình bản lề dựa trên điểm bắt đầu và kết thúc

            // Định nghĩa một mảng chứa 4 điểm
            Point[] parallelogramPoints = new Point[4];

            // Gán các điểm bắt đầu và kết thúc cho điểm 1 và 4 của hình bản lề
            parallelogramPoints[0] = startPoint;
            parallelogramPoints[3] = endPoint;

            // Tính toán các điểm còn lại dựa trên đường chéo của hình bản lề
            // Cách đơn giản là di chuyển một khoảng cố định từ startPoint và endPoint
            int width = Math.Abs(endPoint.X - startPoint.X);
            int height = Math.Abs(endPoint.Y - startPoint.Y);
            parallelogramPoints[1] = new Point(startPoint.X + width, startPoint.Y);
            parallelogramPoints[2] = new Point(endPoint.X + width, endPoint.Y);

            return parallelogramPoints;
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCase = cboType.SelectedIndex;

            // Tùy thuộc vào case được chọn, điều chỉnh tính năng hiển thị của các thành phần trong groupbox
            switch (selectedCase)
            {
                case 0: // Khi chọn case 0
                    groupBox3.Enabled = true;
                    label5.Enabled = true;
                    label6.Enabled = true;
                    label7.Enabled = true;
                    txtX.Enabled = true;
                    txtY.Enabled = true;
                    txtString.Enabled = true;
                    btnDraw.Enabled = true;
                    break;
                default: // Khi không chọn case nào
                    groupBox3.Enabled = false;
                    label5.Enabled = false;
                    label6.Enabled = false;
                    label7.Enabled = false;
                    txtX.Enabled = false;
                    txtY.Enabled = false;
                    txtString.Enabled = false;
                    btnDraw.Enabled = false;
                    break;
            }
        }

        //ngăn cho người dùng nhập vào combobox
        private void cboType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void FrmMain_ResizeEnd(object sender, EventArgs e)
        {

        }
        private void FrmMain_Resize(object sender, EventArgs e)
        {
            VeChuoi();
        }
        private void VeChuoi()
        {
            var g = panelKhungVe.CreateGraphics();
            g.DrawString(txtString.Text, new Font("Arial", 20), new SolidBrush(mauTo), int.Parse(txtX.Text), int.Parse(txtY.Text));
        }


        private int CalculateNewY(int oldY, int oldFormHeight, int newFormHeight)
        {
            // Tính toán lại vị trí Y dựa trên tỷ lệ giữa kích thước cũ và mới của form
            return (int)((double)oldY / oldFormHeight * newFormHeight);
        }

        private int CalculateNewX(int oldX, int oldFormWidth, int newFormWidth)
        {
            // Tính toán lại vị trí X dựa trên tỷ lệ giữa kích thước cũ và mới của form
            return (int)((double)oldX / oldFormWidth * newFormWidth);
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
            //cboBrushType.Visible = false;
            //lblBrushType.Visible = false;
            groupBox3.Enabled = false;
            label5.Enabled = false;
            label6.Enabled = false;
            label7.Enabled = false;
            txtX.Enabled = false;
            txtY.Enabled = false;
            txtString.Enabled = false;
            btnDraw.Enabled = false;
        }

        private void cboBrushType_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnDraw_Click(object sender, EventArgs e)
        {

        }

        private void btnColor_Click(object sender, EventArgs e)
        {

        }

        private void btnColor_Click_1(object sender, EventArgs e)
        {
            var cd = new ColorDialog();
            cd.FullOpen = true;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                BorderColor = cd.Color;
                btnBorderColor.BackColor = cd.Color;
            }
        }

        private void txtX_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDraw_Click_1(object sender, EventArgs e)
        {

        }

        private void btnStringColor_Click(object sender, EventArgs e)
        {
            var cdDialog = new ColorDialog();
            cdDialog.FullOpen = true;
            if (cdDialog.ShowDialog() == DialogResult.OK)
            {
                StringColor = cdDialog.Color;
                btnStringColor.BackColor = cdDialog.Color;
                mauTo = cdDialog.Color;
            }
        }
        Color mauTo = Color.Black;
        private void button2_Click(object sender, EventArgs e)
        {

            var g = panelKhungVe.CreateGraphics();
            g.DrawString(txtString.Text, new Font("Arial", 20), new SolidBrush(mauTo), int.Parse(txtX.Text), int.Parse(txtY.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AboutForm aboutFrom = new AboutForm();
            aboutFrom.ShowDialog();
        }
    }
}
