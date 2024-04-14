namespace DNC1921_Ass03_MyPaint
{
    partial class FrmMain : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            groupBox3 = new GroupBox();
            txtY = new TextBox();
            txtX = new TextBox();
            txtString = new TextBox();
            btnDraw = new Button();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            btnStringColor = new Button();
            label5 = new Label();
            btnSave = new Button();
            groupBox2 = new GroupBox();
            btnFillColor = new Button();
            label4 = new Label();
            groupBox1 = new GroupBox();
            nudBorderSize = new NumericUpDown();
            btnBorderColor = new Button();
            label3 = new Label();
            label2 = new Label();
            cboType = new ComboBox();
            label1 = new Label();
            panelKhungVe = new Panel();
            openFileDialog1 = new OpenFileDialog();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudBorderSize).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Controls.Add(groupBox3);
            splitContainer1.Panel1.Controls.Add(btnSave);
            splitContainer1.Panel1.Controls.Add(groupBox2);
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1.Controls.Add(cboType);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelKhungVe);
            splitContainer1.Size = new Size(938, 684);
            splitContainer1.SplitterDistance = 310;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtY);
            groupBox3.Controls.Add(txtX);
            groupBox3.Controls.Add(txtString);
            groupBox3.Controls.Add(btnDraw);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(btnStringColor);
            groupBox3.Controls.Add(label5);
            groupBox3.Font = new Font("Segoe UI", 12F);
            groupBox3.Location = new Point(8, 345);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(277, 234);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "Draw String (1)";
            // 
            // txtY
            // 
            txtY.Location = new Point(169, 87);
            txtY.Name = "txtY";
            txtY.Size = new Size(86, 34);
            txtY.TabIndex = 12;
            // 
            // txtX
            // 
            txtX.Location = new Point(48, 87);
            txtX.Name = "txtX";
            txtX.Size = new Size(86, 34);
            txtX.TabIndex = 11;
            // 
            // txtString
            // 
            txtString.Location = new Point(82, 135);
            txtString.Name = "txtString";
            txtString.Size = new Size(189, 34);
            txtString.TabIndex = 10;
            // 
            // btnDraw
            // 
            btnDraw.Location = new Point(82, 181);
            btnDraw.Name = "btnDraw";
            btnDraw.Size = new Size(103, 47);
            btnDraw.TabIndex = 9;
            btnDraw.Text = "Draw";
            btnDraw.UseVisualStyleBackColor = true;
            btnDraw.Click += button2_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 141);
            label8.Name = "label8";
            label8.Size = new Size(64, 28);
            label8.TabIndex = 7;
            label8.Text = "String";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(140, 90);
            label7.Name = "label7";
            label7.Size = new Size(23, 28);
            label7.TabIndex = 6;
            label7.Text = "Y";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 90);
            label6.Name = "label6";
            label6.Size = new Size(24, 28);
            label6.TabIndex = 5;
            label6.Text = "X";
            // 
            // btnStringColor
            // 
            btnStringColor.BackColor = SystemColors.WindowText;
            btnStringColor.FlatStyle = FlatStyle.Flat;
            btnStringColor.Location = new Point(94, 41);
            btnStringColor.Name = "btnStringColor";
            btnStringColor.Size = new Size(161, 29);
            btnStringColor.TabIndex = 4;
            btnStringColor.UseVisualStyleBackColor = false;
            btnStringColor.Click += btnStringColor_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 41);
            label5.Name = "label5";
            label5.Size = new Size(60, 28);
            label5.TabIndex = 4;
            label5.Text = "Color";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(18, 607);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 43);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save File";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnFillColor);
            groupBox2.Controls.Add(label4);
            groupBox2.Font = new Font("Segoe UI", 12F);
            groupBox2.Location = new Point(12, 229);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(277, 99);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Fill";
            // 
            // btnFillColor
            // 
            btnFillColor.BackColor = SystemColors.WindowText;
            btnFillColor.FlatStyle = FlatStyle.Flat;
            btnFillColor.Location = new Point(94, 41);
            btnFillColor.Name = "btnFillColor";
            btnFillColor.Size = new Size(161, 29);
            btnFillColor.TabIndex = 4;
            btnFillColor.UseVisualStyleBackColor = false;
            btnFillColor.Click += btnFillColor_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 41);
            label4.Name = "label4";
            label4.Size = new Size(60, 28);
            label4.TabIndex = 4;
            label4.Text = "Color";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(nudBorderSize);
            groupBox1.Controls.Add(btnBorderColor);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI", 12F);
            groupBox1.Location = new Point(12, 98);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(276, 125);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Border";
            // 
            // nudBorderSize
            // 
            nudBorderSize.Location = new Point(94, 73);
            nudBorderSize.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudBorderSize.Name = "nudBorderSize";
            nudBorderSize.Size = new Size(161, 34);
            nudBorderSize.TabIndex = 3;
            nudBorderSize.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnBorderColor
            // 
            btnBorderColor.BackColor = SystemColors.WindowText;
            btnBorderColor.FlatStyle = FlatStyle.Flat;
            btnBorderColor.Location = new Point(97, 29);
            btnBorderColor.Name = "btnBorderColor";
            btnBorderColor.Size = new Size(158, 29);
            btnBorderColor.TabIndex = 2;
            btnBorderColor.UseVisualStyleBackColor = false;
            btnBorderColor.Click += btnBorderColor_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 75);
            label3.Name = "label3";
            label3.Size = new Size(47, 28);
            label3.TabIndex = 1;
            label3.Text = "Size";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 33);
            label2.Name = "label2";
            label2.Size = new Size(60, 28);
            label2.TabIndex = 0;
            label2.Text = "Color";
            // 
            // cboType
            // 
            cboType.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboType.ForeColor = Color.Black;
            cboType.FormattingEnabled = true;
            cboType.Items.AddRange(new object[] { "1. String", "2. Line", "3. Rectangle", "3.1 Rectangle_Horizontal", "3.2 Rectangle_PathGradientBrush", "3.3 Rectangle_TextureBrush", "3.4 Rectangle_HatchBrush", "3.5 Fill Rectangle", "4. Ellipse", "4.1 Ellipse_Horizontal", "4.2 Ellipse_PathGradientBrush", "4.3 Ellipse_TextureBrush", "4.4 Ellipse_HatchBrush", "4.5 Fill Ellipse", "5. Parallelogram", "5.1 Parallelogram_Horizontal", "5.2 Parallelogram_PathGradientBrush", "5.3 Parallelogram_TextureBrush", "5.4 Parallelogram_HatchBrush", "5.5 Fill Parallelogram", "6. Rhombus", "6.1 Rhombus_Horizontal", "6.2 Rhombus_PathGradientBrush", "6.3 Rhombus_TextureBrush", "6.4 Rhombus_HatchBrush", "6.5 Fill Rhombus", "7. Circle", "7.1 Circle_Horizontal", "7.2 Circle_PathGradientBrush", "7.3 Circle_TextureBrush", "7.4 Circle_HatchBrush", "7.5 Fill Circle" });
            cboType.Location = new Point(12, 56);
            cboType.Name = "cboType";
            cboType.Size = new Size(273, 28);
            cboType.TabIndex = 5;
            cboType.SelectedIndexChanged += cboType_SelectedIndexChanged;
            cboType.KeyPress += cboType_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(16, 25);
            label1.Name = "label1";
            label1.Size = new Size(53, 28);
            label1.TabIndex = 4;
            label1.Text = "Type";
            // 
            // panelKhungVe
            // 
            panelKhungVe.BackColor = Color.White;
            panelKhungVe.BackgroundImageLayout = ImageLayout.None;
            panelKhungVe.Dock = DockStyle.Fill;
            panelKhungVe.ForeColor = SystemColors.ControlText;
            panelKhungVe.Location = new Point(0, 0);
            panelKhungVe.Name = "panelKhungVe";
            panelKhungVe.Size = new Size(624, 684);
            panelKhungVe.TabIndex = 0;
            panelKhungVe.Paint += panelKhungVe_Paint;
            panelKhungVe.MouseDown += panelKhungVe_MouseDown;
            panelKhungVe.MouseUp += panelKhungVe_MouseUp;
            panelKhungVe.Resize += FrmMain_ResizeEnd;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(155, 607);
            button1.Name = "button1";
            button1.Size = new Size(130, 43);
            button1.TabIndex = 9;
            button1.Text = "About";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(938, 684);
            Controls.Add(splitContainer1);
            Name = "FrmMain";
            Text = "My Paint";
            Load += FrmMain_Load;
            ResizeEnd += FrmMain_ResizeEnd;
            Resize += FrmMain_Resize;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudBorderSize).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private GroupBox groupBox2;
        private Button btnFillColor;
        private Label label4;
        private GroupBox groupBox1;
        private NumericUpDown nudBorderSize;
        private Button btnBorderColor;
        private Label label3;
        private Label label2;
        private ComboBox cboType;
        private Label label1;
        private Panel panelKhungVe;
        private OpenFileDialog openFileDialog1;
        private Button btnSave;
        private GroupBox groupBox3;
        private Button btnStringColor;
        private Label label5;
        private Button btnDraw;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox txtY;
        private TextBox txtX;
        private TextBox txtString;
        private Button button1;
    }
}
