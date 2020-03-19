namespace PPI
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.range_tb = new System.Windows.Forms.TextBox();
            this.range_btn = new System.Windows.Forms.Button();
            this.markerCount_tb = new System.Windows.Forms.TextBox();
            this.markerCount_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1005, 719);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // range_tb
            // 
            this.range_tb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.range_tb.Location = new System.Drawing.Point(1044, 53);
            this.range_tb.Name = "range_tb";
            this.range_tb.Size = new System.Drawing.Size(195, 28);
            this.range_tb.TabIndex = 1;
            this.range_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.range_tb_KeyPress);
            // 
            // range_btn
            // 
            this.range_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.range_btn.Location = new System.Drawing.Point(1115, 100);
            this.range_btn.Name = "range_btn";
            this.range_btn.Size = new System.Drawing.Size(124, 41);
            this.range_btn.TabIndex = 2;
            this.range_btn.Text = "设置量程";
            this.range_btn.UseVisualStyleBackColor = true;
            this.range_btn.Click += new System.EventHandler(this.range_btn_Click);
            // 
            // markerCount_tb
            // 
            this.markerCount_tb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.markerCount_tb.Location = new System.Drawing.Point(1044, 217);
            this.markerCount_tb.Name = "markerCount_tb";
            this.markerCount_tb.Size = new System.Drawing.Size(195, 28);
            this.markerCount_tb.TabIndex = 3;
            this.markerCount_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.markerCount_tb_KeyPress);
            // 
            // markerCount_btn
            // 
            this.markerCount_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.markerCount_btn.Location = new System.Drawing.Point(1115, 282);
            this.markerCount_btn.Name = "markerCount_btn";
            this.markerCount_btn.Size = new System.Drawing.Size(124, 41);
            this.markerCount_btn.TabIndex = 2;
            this.markerCount_btn.Text = "设置标尺数";
            this.markerCount_btn.UseVisualStyleBackColor = true;
            this.markerCount_btn.Click += new System.EventHandler(this.markerCount_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 744);
            this.Controls.Add(this.markerCount_tb);
            this.Controls.Add(this.markerCount_btn);
            this.Controls.Add(this.range_btn);
            this.Controls.Add(this.range_tb);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox range_tb;
        private System.Windows.Forms.Button range_btn;
        private System.Windows.Forms.TextBox markerCount_tb;
        private System.Windows.Forms.Button markerCount_btn;
    }
}

