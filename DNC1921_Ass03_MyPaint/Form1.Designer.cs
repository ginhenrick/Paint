﻿namespace DNC1921_Ass03_MyPaint
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
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(groupBox2);
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1.Controls.Add(cboType);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelKhungVe);
            splitContainer1.Size = new Size(834, 476);
            splitContainer1.SplitterDistance = 277;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnFillColor);
            groupBox2.Controls.Add(label4);
            groupBox2.Font = new Font("Segoe UI", 12F);
            groupBox2.Location = new Point(12, 229);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(250, 99);
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
            btnFillColor.Size = new Size(94, 29);
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
            groupBox1.Size = new Size(250, 125);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Border";
            // 
            // nudBorderSize
            // 
            nudBorderSize.Location = new Point(94, 73);
            nudBorderSize.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudBorderSize.Name = "nudBorderSize";
            nudBorderSize.Size = new Size(97, 34);
            nudBorderSize.TabIndex = 3;
            nudBorderSize.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnBorderColor
            // 
            btnBorderColor.BackColor = SystemColors.WindowText;
            btnBorderColor.FlatStyle = FlatStyle.Flat;
            btnBorderColor.Location = new Point(97, 29);
            btnBorderColor.Name = "btnBorderColor";
            btnBorderColor.Size = new Size(94, 29);
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
            cboType.Font = new Font("Segoe UI", 12F);
            cboType.ForeColor = Color.Black;
            cboType.FormattingEnabled = true;
            cboType.Items.AddRange(new object[] { "Text", "Line", "Rectangle", "Fill Rectangle", "Ellipse", "Fill Ellipse", "Parallelogram", "Fill Parallelogram", "Rhombus", "Fill Rhombus", "Circle", "Fill Circle" });
            cboType.Location = new Point(16, 56);
            cboType.Name = "cboType";
            cboType.Size = new Size(236, 36);
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
            panelKhungVe.Dock = DockStyle.Fill;
            panelKhungVe.Location = new Point(0, 0);
            panelKhungVe.Name = "panelKhungVe";
            panelKhungVe.Size = new Size(553, 476);
            panelKhungVe.TabIndex = 0;
            panelKhungVe.MouseDown += panelKhungVe_MouseDown;
            panelKhungVe.MouseUp += panelKhungVe_MouseUp;
            panelKhungVe.Resize += FrmMain_ResizeEnd;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 476);
            Controls.Add(splitContainer1);
            Name = "FrmMain";
            Text = "My Paint";
            ResizeEnd += FrmMain_ResizeEnd;
            Resize += FrmMain_Resize;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
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
    }
}
