namespace VideoProcessing
{
    partial class VideoProcessing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hueGrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cannyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.featuresRadio = new System.Windows.Forms.RadioButton();
            this.binaryRadio = new System.Windows.Forms.RadioButton();
            this.laplacianRadio = new System.Windows.Forms.RadioButton();
            this.sobelRadio = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.hueGrayRadio = new System.Windows.Forms.RadioButton();
            this.grayRadio = new System.Windows.Forms.RadioButton();
            this.contourRadio = new System.Windows.Forms.RadioButton();
            this.cannyHierarchyRadio = new System.Windows.Forms.RadioButton();
            this.colorRadio = new System.Windows.Forms.RadioButton();
            this.gaussLabel = new System.Windows.Forms.Label();
            this.gaussTxt = new System.Windows.Forms.TextBox();
            this.thresh1Txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.thresh2Txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.binaryMaxTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.binaryMinTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.analyzeBttn = new System.Windows.Forms.Button();
            this.fpsLabel = new System.Windows.Forms.Label();
            this.txtPanel = new System.Windows.Forms.Panel();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.eigenVectorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.txtPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.imageBox1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox1.Location = new System.Drawing.Point(0, 24);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(615, 451);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoToolStripMenuItem,
            this.imageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(818, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem1,
            this.pauseToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.videoToolStripMenuItem.Text = "Video";
            // 
            // startToolStripMenuItem1
            // 
            this.startToolStripMenuItem1.Name = "startToolStripMenuItem1";
            this.startToolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
            this.startToolStripMenuItem1.Text = "Start";
            this.startToolStripMenuItem1.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.analyzeToolStripMenuItem,
            this.setModelToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // analyzeToolStripMenuItem
            // 
            this.analyzeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hueGrayToolStripMenuItem,
            this.cannyToolStripMenuItem,
            this.eigenVectorsToolStripMenuItem});
            this.analyzeToolStripMenuItem.Name = "analyzeToolStripMenuItem";
            this.analyzeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.analyzeToolStripMenuItem.Text = "Analyze";
            // 
            // hueGrayToolStripMenuItem
            // 
            this.hueGrayToolStripMenuItem.Name = "hueGrayToolStripMenuItem";
            this.hueGrayToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hueGrayToolStripMenuItem.Text = "Hue-Gray";
            this.hueGrayToolStripMenuItem.Click += new System.EventHandler(this.hueGrayToolStripMenuItem_Click);
            // 
            // cannyToolStripMenuItem
            // 
            this.cannyToolStripMenuItem.Name = "cannyToolStripMenuItem";
            this.cannyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cannyToolStripMenuItem.Text = "Canny";
            this.cannyToolStripMenuItem.Click += new System.EventHandler(this.cannyToolStripMenuItem_Click);
            // 
            // setModelToolStripMenuItem
            // 
            this.setModelToolStripMenuItem.Name = "setModelToolStripMenuItem";
            this.setModelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.setModelToolStripMenuItem.Text = "Set Model";
            this.setModelToolStripMenuItem.Click += new System.EventHandler(this.setModelToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.featuresRadio);
            this.groupBox1.Controls.Add(this.binaryRadio);
            this.groupBox1.Controls.Add(this.laplacianRadio);
            this.groupBox1.Controls.Add(this.sobelRadio);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.hueGrayRadio);
            this.groupBox1.Controls.Add(this.grayRadio);
            this.groupBox1.Controls.Add(this.contourRadio);
            this.groupBox1.Controls.Add(this.cannyHierarchyRadio);
            this.groupBox1.Controls.Add(this.colorRadio);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(621, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 251);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Video";
            // 
            // featuresRadio
            // 
            this.featuresRadio.AutoSize = true;
            this.featuresRadio.Location = new System.Drawing.Point(13, 224);
            this.featuresRadio.Name = "featuresRadio";
            this.featuresRadio.Size = new System.Drawing.Size(111, 17);
            this.featuresRadio.TabIndex = 23;
            this.featuresRadio.Text = "Features Tracking";
            this.featuresRadio.UseVisualStyleBackColor = true;
            this.featuresRadio.CheckedChanged += new System.EventHandler(this.VideoInputRadioBttn_CheckChanged);
            // 
            // binaryRadio
            // 
            this.binaryRadio.AutoSize = true;
            this.binaryRadio.Location = new System.Drawing.Point(13, 201);
            this.binaryRadio.Name = "binaryRadio";
            this.binaryRadio.Size = new System.Drawing.Size(54, 17);
            this.binaryRadio.TabIndex = 22;
            this.binaryRadio.Text = "Binary";
            this.binaryRadio.UseVisualStyleBackColor = true;
            this.binaryRadio.CheckedChanged += new System.EventHandler(this.VideoInputRadioBttn_CheckChanged);
            // 
            // laplacianRadio
            // 
            this.laplacianRadio.AutoSize = true;
            this.laplacianRadio.Location = new System.Drawing.Point(13, 178);
            this.laplacianRadio.Name = "laplacianRadio";
            this.laplacianRadio.Size = new System.Drawing.Size(71, 17);
            this.laplacianRadio.TabIndex = 21;
            this.laplacianRadio.Text = "Laplacian";
            this.laplacianRadio.UseVisualStyleBackColor = true;
            this.laplacianRadio.CheckedChanged += new System.EventHandler(this.VideoInputRadioBttn_CheckChanged);
            // 
            // sobelRadio
            // 
            this.sobelRadio.AutoSize = true;
            this.sobelRadio.Location = new System.Drawing.Point(13, 155);
            this.sobelRadio.Name = "sobelRadio";
            this.sobelRadio.Size = new System.Drawing.Size(52, 17);
            this.sobelRadio.TabIndex = 20;
            this.sobelRadio.Text = "Sobel";
            this.sobelRadio.UseVisualStyleBackColor = true;
            this.sobelRadio.CheckedChanged += new System.EventHandler(this.VideoInputRadioBttn_CheckChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(34, 110);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 17);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "Accumulate";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // hueGrayRadio
            // 
            this.hueGrayRadio.AutoSize = true;
            this.hueGrayRadio.Location = new System.Drawing.Point(13, 132);
            this.hueGrayRadio.Name = "hueGrayRadio";
            this.hueGrayRadio.Size = new System.Drawing.Size(73, 17);
            this.hueGrayRadio.TabIndex = 4;
            this.hueGrayRadio.Text = "Hue- Gray";
            this.hueGrayRadio.UseVisualStyleBackColor = true;
            this.hueGrayRadio.CheckedChanged += new System.EventHandler(this.VideoInputRadioBttn_CheckChanged);
            // 
            // grayRadio
            // 
            this.grayRadio.AutoSize = true;
            this.grayRadio.Location = new System.Drawing.Point(13, 43);
            this.grayRadio.Name = "grayRadio";
            this.grayRadio.Size = new System.Drawing.Size(77, 17);
            this.grayRadio.TabIndex = 3;
            this.grayRadio.Text = "Gray Scale";
            this.grayRadio.UseVisualStyleBackColor = true;
            this.grayRadio.CheckedChanged += new System.EventHandler(this.VideoInputRadioBttn_CheckChanged);
            // 
            // contourRadio
            // 
            this.contourRadio.AutoSize = true;
            this.contourRadio.Location = new System.Drawing.Point(13, 66);
            this.contourRadio.Name = "contourRadio";
            this.contourRadio.Size = new System.Drawing.Size(62, 17);
            this.contourRadio.TabIndex = 2;
            this.contourRadio.Text = "Contour";
            this.contourRadio.UseVisualStyleBackColor = true;
            this.contourRadio.CheckedChanged += new System.EventHandler(this.VideoInputRadioBttn_CheckChanged);
            // 
            // cannyHierarchyRadio
            // 
            this.cannyHierarchyRadio.AutoSize = true;
            this.cannyHierarchyRadio.Checked = true;
            this.cannyHierarchyRadio.Location = new System.Drawing.Point(13, 89);
            this.cannyHierarchyRadio.Name = "cannyHierarchyRadio";
            this.cannyHierarchyRadio.Size = new System.Drawing.Size(103, 17);
            this.cannyHierarchyRadio.TabIndex = 1;
            this.cannyHierarchyRadio.TabStop = true;
            this.cannyHierarchyRadio.Text = "Canny Hierarchy";
            this.cannyHierarchyRadio.UseVisualStyleBackColor = true;
            this.cannyHierarchyRadio.CheckedChanged += new System.EventHandler(this.VideoInputRadioBttn_CheckChanged);
            // 
            // colorRadio
            // 
            this.colorRadio.AutoSize = true;
            this.colorRadio.Location = new System.Drawing.Point(13, 20);
            this.colorRadio.Name = "colorRadio";
            this.colorRadio.Size = new System.Drawing.Size(49, 17);
            this.colorRadio.TabIndex = 0;
            this.colorRadio.Text = "Color";
            this.colorRadio.UseVisualStyleBackColor = true;
            this.colorRadio.CheckedChanged += new System.EventHandler(this.VideoInputRadioBttn_CheckChanged);
            // 
            // gaussLabel
            // 
            this.gaussLabel.AutoSize = true;
            this.gaussLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gaussLabel.Location = new System.Drawing.Point(8, 11);
            this.gaussLabel.Name = "gaussLabel";
            this.gaussLabel.Size = new System.Drawing.Size(37, 13);
            this.gaussLabel.TabIndex = 5;
            this.gaussLabel.Text = "Gauss";
            // 
            // gaussTxt
            // 
            this.gaussTxt.BackColor = System.Drawing.Color.LightSteelBlue;
            this.gaussTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gaussTxt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gaussTxt.Location = new System.Drawing.Point(80, 7);
            this.gaussTxt.Name = "gaussTxt";
            this.gaussTxt.Size = new System.Drawing.Size(100, 20);
            this.gaussTxt.TabIndex = 6;
            this.gaussTxt.Click += new System.EventHandler(this.txtBox_Click);
            // 
            // thresh1Txt
            // 
            this.thresh1Txt.BackColor = System.Drawing.Color.LightSteelBlue;
            this.thresh1Txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thresh1Txt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.thresh1Txt.Location = new System.Drawing.Point(80, 33);
            this.thresh1Txt.Name = "thresh1Txt";
            this.thresh1Txt.Size = new System.Drawing.Size(100, 20);
            this.thresh1Txt.TabIndex = 8;
            this.thresh1Txt.Click += new System.EventHandler(this.txtBox_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(8, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Thresh1";
            // 
            // thresh2Txt
            // 
            this.thresh2Txt.BackColor = System.Drawing.Color.LightSteelBlue;
            this.thresh2Txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thresh2Txt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.thresh2Txt.Location = new System.Drawing.Point(80, 59);
            this.thresh2Txt.Name = "thresh2Txt";
            this.thresh2Txt.Size = new System.Drawing.Size(100, 20);
            this.thresh2Txt.TabIndex = 10;
            this.thresh2Txt.Click += new System.EventHandler(this.txtBox_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(8, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Thresh2";
            // 
            // binaryMaxTxt
            // 
            this.binaryMaxTxt.BackColor = System.Drawing.Color.LightSteelBlue;
            this.binaryMaxTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.binaryMaxTxt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.binaryMaxTxt.Location = new System.Drawing.Point(80, 111);
            this.binaryMaxTxt.Name = "binaryMaxTxt";
            this.binaryMaxTxt.Size = new System.Drawing.Size(100, 20);
            this.binaryMaxTxt.TabIndex = 14;
            this.binaryMaxTxt.Click += new System.EventHandler(this.txtBox_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(8, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Binary Max";
            // 
            // binaryMinTxt
            // 
            this.binaryMinTxt.BackColor = System.Drawing.Color.LightSteelBlue;
            this.binaryMinTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.binaryMinTxt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.binaryMinTxt.Location = new System.Drawing.Point(80, 85);
            this.binaryMinTxt.Name = "binaryMinTxt";
            this.binaryMinTxt.Size = new System.Drawing.Size(100, 20);
            this.binaryMinTxt.TabIndex = 12;
            this.binaryMinTxt.Click += new System.EventHandler(this.txtBox_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(8, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Binary Min";
            // 
            // analyzeBttn
            // 
            this.analyzeBttn.Location = new System.Drawing.Point(124, 136);
            this.analyzeBttn.Name = "analyzeBttn";
            this.analyzeBttn.Size = new System.Drawing.Size(56, 23);
            this.analyzeBttn.TabIndex = 17;
            this.analyzeBttn.Text = "Analyze";
            this.analyzeBttn.UseVisualStyleBackColor = true;
            this.analyzeBttn.Click += new System.EventHandler(this.analyzeBttn_Click);
            // 
            // fpsLabel
            // 
            this.fpsLabel.BackColor = System.Drawing.Color.Black;
            this.fpsLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fpsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.fpsLabel.Location = new System.Drawing.Point(12, 448);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(56, 23);
            this.fpsLabel.TabIndex = 18;
            // 
            // txtPanel
            // 
            this.txtPanel.Controls.Add(this.thresh2Txt);
            this.txtPanel.Controls.Add(this.gaussLabel);
            this.txtPanel.Controls.Add(this.analyzeBttn);
            this.txtPanel.Controls.Add(this.gaussTxt);
            this.txtPanel.Controls.Add(this.binaryMaxTxt);
            this.txtPanel.Controls.Add(this.label2);
            this.txtPanel.Controls.Add(this.label5);
            this.txtPanel.Controls.Add(this.thresh1Txt);
            this.txtPanel.Controls.Add(this.binaryMinTxt);
            this.txtPanel.Controls.Add(this.label3);
            this.txtPanel.Controls.Add(this.label6);
            this.txtPanel.Location = new System.Drawing.Point(621, 304);
            this.txtPanel.Name = "txtPanel";
            this.txtPanel.Size = new System.Drawing.Size(191, 167);
            this.txtPanel.TabIndex = 19;
            // 
            // imageBox2
            // 
            this.imageBox2.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox2.Location = new System.Drawing.Point(468, 40);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(131, 95);
            this.imageBox2.TabIndex = 2;
            this.imageBox2.TabStop = false;
            // 
            // eigenVectorsToolStripMenuItem
            // 
            this.eigenVectorsToolStripMenuItem.Name = "eigenVectorsToolStripMenuItem";
            this.eigenVectorsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eigenVectorsToolStripMenuItem.Text = "EigenVectors";
            this.eigenVectorsToolStripMenuItem.Click += new System.EventHandler(this.eigenVectorsToolStripMenuItem_Click);
            // 
            // VideoProcessing
            // 
            this.AcceptButton = this.analyzeBttn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(818, 475);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.txtPanel);
            this.Controls.Add(this.fpsLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VideoProcessing";
            this.Text = "Video Processing";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.txtPanel.ResumeLayout(false);
            this.txtPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton hueGrayRadio;
        private System.Windows.Forms.RadioButton grayRadio;
        private System.Windows.Forms.RadioButton contourRadio;
        private System.Windows.Forms.RadioButton cannyHierarchyRadio;
        private System.Windows.Forms.RadioButton colorRadio;
        private System.Windows.Forms.Label gaussLabel;
        private System.Windows.Forms.TextBox gaussTxt;
        private System.Windows.Forms.TextBox thresh1Txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox thresh2Txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox binaryMaxTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox binaryMinTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button analyzeBttn;
        private System.Windows.Forms.Label fpsLabel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analyzeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hueGrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cannyToolStripMenuItem;
        private System.Windows.Forms.RadioButton laplacianRadio;
        private System.Windows.Forms.RadioButton sobelRadio;
        private System.Windows.Forms.RadioButton binaryRadio;
        private System.Windows.Forms.Panel txtPanel;
        private System.Windows.Forms.RadioButton featuresRadio;
        private System.Windows.Forms.ToolStripMenuItem setModelToolStripMenuItem;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.ToolStripMenuItem eigenVectorsToolStripMenuItem;
    }
}

