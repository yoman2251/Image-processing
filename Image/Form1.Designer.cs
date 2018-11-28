namespace Image
{
    partial class mainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SourcePictureBox = new System.Windows.Forms.PictureBox();
            this.OutputPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.grayButton = new System.Windows.Forms.Button();
            this.binarizationButton = new System.Windows.Forms.Button();
            this.negativeButton = new System.Windows.Forms.Button();
            this.reliefButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.liveButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.horizontalButton = new System.Windows.Forms.Button();
            this.verticalButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.smoothedBox = new System.Windows.Forms.PictureBox();
            this.faceDetectionBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SourcePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smoothedBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.faceDetectionBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SourcePictureBox
            // 
            this.SourcePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SourcePictureBox.Location = new System.Drawing.Point(15, 95);
            this.SourcePictureBox.Name = "SourcePictureBox";
            this.SourcePictureBox.Size = new System.Drawing.Size(370, 300);
            this.SourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SourcePictureBox.TabIndex = 0;
            this.SourcePictureBox.TabStop = false;
            this.SourcePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SourcePictureBox_MouseDown);
            this.SourcePictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SourcePictureBox_MouseUp);
            // 
            // OutputPictureBox
            // 
            this.OutputPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.OutputPictureBox.Location = new System.Drawing.Point(404, 95);
            this.OutputPictureBox.Name = "OutputPictureBox";
            this.OutputPictureBox.Size = new System.Drawing.Size(370, 300);
            this.OutputPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OutputPictureBox.TabIndex = 2;
            this.OutputPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Captured Image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(401, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output Image";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // grayButton
            // 
            this.grayButton.Enabled = false;
            this.grayButton.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grayButton.Location = new System.Drawing.Point(494, 59);
            this.grayButton.Name = "grayButton";
            this.grayButton.Size = new System.Drawing.Size(52, 23);
            this.grayButton.TabIndex = 18;
            this.grayButton.Text = "灰階";
            this.grayButton.UseVisualStyleBackColor = true;
            this.grayButton.Click += new System.EventHandler(this.grayButton_Click);
            // 
            // binarizationButton
            // 
            this.binarizationButton.Enabled = false;
            this.binarizationButton.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.binarizationButton.Location = new System.Drawing.Point(570, 59);
            this.binarizationButton.Name = "binarizationButton";
            this.binarizationButton.Size = new System.Drawing.Size(49, 23);
            this.binarizationButton.TabIndex = 19;
            this.binarizationButton.Text = "二值化";
            this.binarizationButton.UseVisualStyleBackColor = true;
            this.binarizationButton.Click += new System.EventHandler(this.binarizationButton_Click);
            // 
            // negativeButton
            // 
            this.negativeButton.Enabled = false;
            this.negativeButton.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.negativeButton.Location = new System.Drawing.Point(722, 59);
            this.negativeButton.Name = "negativeButton";
            this.negativeButton.Size = new System.Drawing.Size(52, 23);
            this.negativeButton.TabIndex = 20;
            this.negativeButton.Text = "負片";
            this.negativeButton.UseVisualStyleBackColor = true;
            this.negativeButton.Click += new System.EventHandler(this.negativeButton_Click);
            // 
            // reliefButton
            // 
            this.reliefButton.Enabled = false;
            this.reliefButton.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.reliefButton.Location = new System.Drawing.Point(646, 59);
            this.reliefButton.Name = "reliefButton";
            this.reliefButton.Size = new System.Drawing.Size(48, 23);
            this.reliefButton.TabIndex = 23;
            this.reliefButton.Text = "浮雕";
            this.reliefButton.UseVisualStyleBackColor = true;
            this.reliefButton.Click += new System.EventHandler(this.reliefButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.exitButton.Location = new System.Drawing.Point(442, 12);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(76, 33);
            this.exitButton.TabIndex = 25;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // liveButton
            // 
            this.liveButton.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.liveButton.Location = new System.Drawing.Point(15, 12);
            this.liveButton.Name = "liveButton";
            this.liveButton.Size = new System.Drawing.Size(85, 33);
            this.liveButton.TabIndex = 26;
            this.liveButton.Text = "Start";
            this.liveButton.UseVisualStyleBackColor = true;
            this.liveButton.Click += new System.EventHandler(this.liveButton_Click);
            // 
            // timer
            // 
            this.timer.Interval = 60;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // horizontalButton
            // 
            this.horizontalButton.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.horizontalButton.Location = new System.Drawing.Point(133, 12);
            this.horizontalButton.Name = "horizontalButton";
            this.horizontalButton.Size = new System.Drawing.Size(119, 33);
            this.horizontalButton.TabIndex = 29;
            this.horizontalButton.Text = "Flip Horizontal";
            this.horizontalButton.UseVisualStyleBackColor = true;
            this.horizontalButton.Click += new System.EventHandler(this.horizontal_Click);
            // 
            // verticalButton
            // 
            this.verticalButton.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.verticalButton.Location = new System.Drawing.Point(284, 12);
            this.verticalButton.Name = "verticalButton";
            this.verticalButton.Size = new System.Drawing.Size(119, 33);
            this.verticalButton.TabIndex = 30;
            this.verticalButton.Text = "Flip Vertical";
            this.verticalButton.UseVisualStyleBackColor = true;
            this.verticalButton.Click += new System.EventHandler(this.verticalButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 417);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "Smoothed Grayscale";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(401, 417);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "Face Detection";
            // 
            // smoothedBox
            // 
            this.smoothedBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.smoothedBox.Location = new System.Drawing.Point(15, 449);
            this.smoothedBox.Name = "smoothedBox";
            this.smoothedBox.Size = new System.Drawing.Size(370, 300);
            this.smoothedBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.smoothedBox.TabIndex = 33;
            this.smoothedBox.TabStop = false;
            // 
            // faceDetectionBox
            // 
            this.faceDetectionBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.faceDetectionBox.Location = new System.Drawing.Point(404, 449);
            this.faceDetectionBox.Name = "faceDetectionBox";
            this.faceDetectionBox.Size = new System.Drawing.Size(370, 300);
            this.faceDetectionBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.faceDetectionBox.TabIndex = 34;
            this.faceDetectionBox.TabStop = false;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(865, 817);
            this.Controls.Add(this.faceDetectionBox);
            this.Controls.Add(this.smoothedBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.verticalButton);
            this.Controls.Add(this.horizontalButton);
            this.Controls.Add(this.liveButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.reliefButton);
            this.Controls.Add(this.negativeButton);
            this.Controls.Add(this.binarizationButton);
            this.Controls.Add(this.grayButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutputPictureBox);
            this.Controls.Add(this.SourcePictureBox);
            this.Name = "mainForm";
            this.Text = "數位影像處理";
            ((System.ComponentModel.ISupportInitialize)(this.SourcePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smoothedBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.faceDetectionBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox SourcePictureBox;
        private System.Windows.Forms.PictureBox OutputPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button grayButton;
        private System.Windows.Forms.Button binarizationButton;
        private System.Windows.Forms.Button negativeButton;
        private System.Windows.Forms.Button reliefButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button liveButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button horizontalButton;
        private System.Windows.Forms.Button verticalButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox smoothedBox;
        private System.Windows.Forms.PictureBox faceDetectionBox;
    }
}

