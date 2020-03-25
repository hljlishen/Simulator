namespace SimView
{
    partial class ControlPanel
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
            this.ppi_pb = new System.Windows.Forms.PictureBox();
            this.disRate_tb = new System.Windows.Forms.TextBox();
            this.azRate_tb = new System.Windows.Forms.TextBox();
            this.dis_tb = new System.Windows.Forms.TextBox();
            this.az_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.x_rb = new System.Windows.Forms.RadioButton();
            this.y_rb = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.channel_tb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.randomPulse_tb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.modulation15_tb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.modulation135_tb = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.responsePower_tb = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.responseRate_tb = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.identifyCode_tb = new System.Windows.Forms.TextBox();
            this.confirm_btn = new System.Windows.Forms.Button();
            this.responsePower_tkb = new System.Windows.Forms.TrackBar();
            this.hint_lab = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ppi_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.responsePower_tkb)).BeginInit();
            this.SuspendLayout();
            // 
            // ppi_pb
            // 
            this.ppi_pb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppi_pb.Location = new System.Drawing.Point(284, 120);
            this.ppi_pb.Name = "ppi_pb";
            this.ppi_pb.Size = new System.Drawing.Size(788, 600);
            this.ppi_pb.TabIndex = 1;
            this.ppi_pb.TabStop = false;
            // 
            // disRate_tb
            // 
            this.disRate_tb.Location = new System.Drawing.Point(808, 33);
            this.disRate_tb.Name = "disRate_tb";
            this.disRate_tb.Size = new System.Drawing.Size(225, 25);
            this.disRate_tb.TabIndex = 2;
            // 
            // azRate_tb
            // 
            this.azRate_tb.Location = new System.Drawing.Point(808, 78);
            this.azRate_tb.Name = "azRate_tb";
            this.azRate_tb.Size = new System.Drawing.Size(225, 25);
            this.azRate_tb.TabIndex = 2;
            // 
            // dis_tb
            // 
            this.dis_tb.Location = new System.Drawing.Point(395, 33);
            this.dis_tb.Name = "dis_tb";
            this.dis_tb.Size = new System.Drawing.Size(225, 25);
            this.dis_tb.TabIndex = 2;
            this.dis_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dis_tb_KeyPress);
            // 
            // az_tb
            // 
            this.az_tb.Location = new System.Drawing.Point(394, 78);
            this.az_tb.Name = "az_tb";
            this.az_tb.Size = new System.Drawing.Size(225, 25);
            this.az_tb.TabIndex = 2;
            this.az_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Az_tb_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(340, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "距离";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(340, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "方位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(702, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "距离变化率";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(702, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "方位变化率";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(54, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "编码方式";
            // 
            // x_rb
            // 
            this.x_rb.AutoSize = true;
            this.x_rb.Checked = true;
            this.x_rb.Location = new System.Drawing.Point(146, 36);
            this.x_rb.Name = "x_rb";
            this.x_rb.Size = new System.Drawing.Size(36, 19);
            this.x_rb.TabIndex = 4;
            this.x_rb.TabStop = true;
            this.x_rb.Text = "X";
            this.x_rb.UseVisualStyleBackColor = true;
            // 
            // y_rb
            // 
            this.y_rb.AutoSize = true;
            this.y_rb.Location = new System.Drawing.Point(210, 36);
            this.y_rb.Name = "y_rb";
            this.y_rb.Size = new System.Drawing.Size(36, 19);
            this.y_rb.TabIndex = 4;
            this.y_rb.Text = "Y";
            this.y_rb.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(70, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "波道号";
            // 
            // channel_tb
            // 
            this.channel_tb.Location = new System.Drawing.Point(146, 78);
            this.channel_tb.Name = "channel_tb";
            this.channel_tb.Size = new System.Drawing.Size(100, 25);
            this.channel_tb.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(22, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "随机填充脉冲";
            // 
            // randomPulse_tb
            // 
            this.randomPulse_tb.Location = new System.Drawing.Point(146, 141);
            this.randomPulse_tb.Name = "randomPulse_tb";
            this.randomPulse_tb.Size = new System.Drawing.Size(100, 25);
            this.randomPulse_tb.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(38, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "15Hz调制度";
            // 
            // modulation15_tb
            // 
            this.modulation15_tb.Location = new System.Drawing.Point(146, 203);
            this.modulation15_tb.Name = "modulation15_tb";
            this.modulation15_tb.Size = new System.Drawing.Size(100, 25);
            this.modulation15_tb.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(30, 274);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "135Hz调制度";
            // 
            // modulation135_tb
            // 
            this.modulation135_tb.Location = new System.Drawing.Point(146, 271);
            this.modulation135_tb.Name = "modulation135_tb";
            this.modulation135_tb.Size = new System.Drawing.Size(100, 25);
            this.modulation135_tb.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(54, 345);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 15);
            this.label10.TabIndex = 3;
            this.label10.Text = "应答功率";
            // 
            // responsePower_tb
            // 
            this.responsePower_tb.Location = new System.Drawing.Point(146, 342);
            this.responsePower_tb.Name = "responsePower_tb";
            this.responsePower_tb.Size = new System.Drawing.Size(100, 25);
            this.responsePower_tb.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(54, 477);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 15);
            this.label11.TabIndex = 3;
            this.label11.Text = "应答概率";
            // 
            // responseRate_tb
            // 
            this.responseRate_tb.Location = new System.Drawing.Point(146, 474);
            this.responseRate_tb.Name = "responseRate_tb";
            this.responseRate_tb.Size = new System.Drawing.Size(100, 25);
            this.responseRate_tb.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(70, 553);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "识别码";
            // 
            // identifyCode_tb
            // 
            this.identifyCode_tb.Location = new System.Drawing.Point(146, 550);
            this.identifyCode_tb.Name = "identifyCode_tb";
            this.identifyCode_tb.Size = new System.Drawing.Size(100, 25);
            this.identifyCode_tb.TabIndex = 5;
            // 
            // confirm_btn
            // 
            this.confirm_btn.Location = new System.Drawing.Point(57, 633);
            this.confirm_btn.Name = "confirm_btn";
            this.confirm_btn.Size = new System.Drawing.Size(157, 59);
            this.confirm_btn.TabIndex = 6;
            this.confirm_btn.Text = "设置参数";
            this.confirm_btn.UseVisualStyleBackColor = true;
            this.confirm_btn.Click += new System.EventHandler(this.Confirm_btn_Click);
            // 
            // responsePower_tkb
            // 
            this.responsePower_tkb.Location = new System.Drawing.Point(12, 387);
            this.responsePower_tkb.Minimum = -90;
            this.responsePower_tkb.Name = "responsePower_tkb";
            this.responsePower_tkb.Size = new System.Drawing.Size(266, 56);
            this.responsePower_tkb.TabIndex = 7;
            this.responsePower_tkb.ValueChanged += new System.EventHandler(this.TrackBar1_ValueChanged);
            // 
            // hint_lab
            // 
            this.hint_lab.AutoSize = true;
            this.hint_lab.ForeColor = System.Drawing.Color.Red;
            this.hint_lab.Location = new System.Drawing.Point(57, 704);
            this.hint_lab.Name = "hint_lab";
            this.hint_lab.Size = new System.Drawing.Size(0, 15);
            this.hint_lab.TabIndex = 8;
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 732);
            this.Controls.Add(this.hint_lab);
            this.Controls.Add(this.responsePower_tkb);
            this.Controls.Add(this.confirm_btn);
            this.Controls.Add(this.identifyCode_tb);
            this.Controls.Add(this.responseRate_tb);
            this.Controls.Add(this.responsePower_tb);
            this.Controls.Add(this.modulation135_tb);
            this.Controls.Add(this.modulation15_tb);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.randomPulse_tb);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.channel_tb);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.y_rb);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.x_rb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.az_tb);
            this.Controls.Add(this.dis_tb);
            this.Controls.Add(this.azRate_tb);
            this.Controls.Add(this.disRate_tb);
            this.Controls.Add(this.ppi_pb);
            this.Name = "ControlPanel";
            this.Text = "ControlPanel";
            this.Load += new System.EventHandler(this.ControlPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ppi_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.responsePower_tkb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ppi_pb;
        private System.Windows.Forms.TextBox disRate_tb;
        private System.Windows.Forms.TextBox azRate_tb;
        private System.Windows.Forms.TextBox dis_tb;
        private System.Windows.Forms.TextBox az_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton x_rb;
        private System.Windows.Forms.RadioButton y_rb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox channel_tb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox randomPulse_tb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox modulation15_tb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox modulation135_tb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox responsePower_tb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox responseRate_tb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox identifyCode_tb;
        private System.Windows.Forms.Button confirm_btn;
        private System.Windows.Forms.TrackBar responsePower_tkb;
        private System.Windows.Forms.Label hint_lab;
    }
}