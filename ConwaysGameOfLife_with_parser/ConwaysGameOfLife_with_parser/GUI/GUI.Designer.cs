namespace ConwaysGameOfLife_with_parser.GUI
{
    partial class GUI
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
            this.pbRenderer = new System.Windows.Forms.PictureBox();
            this.cntrlBox = new System.Windows.Forms.GroupBox();
            this.run_bttn = new System.Windows.Forms.Button();
            this.add_btn = new System.Windows.Forms.Button();
            this.interval_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.generation_lb = new System.Windows.Forms.Label();
            this.btn_eddit = new System.Windows.Forms.Button();
            this.rst_button = new System.Windows.Forms.Button();
            this.tb_width = new System.Windows.Forms.TextBox();
            this.tb_height = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbRenderer)).BeginInit();
            this.cntrlBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbRenderer
            // 
            this.pbRenderer.BackColor = System.Drawing.SystemColors.ControlText;
            this.pbRenderer.Location = new System.Drawing.Point(262, 23);
            this.pbRenderer.Name = "pbRenderer";
            this.pbRenderer.Size = new System.Drawing.Size(1060, 726);
            this.pbRenderer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbRenderer.TabIndex = 1;
            this.pbRenderer.TabStop = false;
            this.pbRenderer.Paint += new System.Windows.Forms.PaintEventHandler(this.pbRenderer_Paint);
            // 
            // cntrlBox
            // 
            this.cntrlBox.Controls.Add(this.label3);
            this.cntrlBox.Controls.Add(this.label2);
            this.cntrlBox.Controls.Add(this.tb_height);
            this.cntrlBox.Controls.Add(this.tb_width);
            this.cntrlBox.Controls.Add(this.rst_button);
            this.cntrlBox.Controls.Add(this.run_bttn);
            this.cntrlBox.Controls.Add(this.add_btn);
            this.cntrlBox.Controls.Add(this.interval_tb);
            this.cntrlBox.Controls.Add(this.label1);
            this.cntrlBox.Controls.Add(this.generation_lb);
            this.cntrlBox.Controls.Add(this.btn_eddit);
            this.cntrlBox.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cntrlBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cntrlBox.Location = new System.Drawing.Point(12, 12);
            this.cntrlBox.Name = "cntrlBox";
            this.cntrlBox.Size = new System.Drawing.Size(249, 737);
            this.cntrlBox.TabIndex = 2;
            this.cntrlBox.TabStop = false;
            this.cntrlBox.Text = "Controls";
            // 
            // run_bttn
            // 
            this.run_bttn.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.run_bttn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.run_bttn.Location = new System.Drawing.Point(34, 151);
            this.run_bttn.Name = "run_bttn";
            this.run_bttn.Size = new System.Drawing.Size(160, 29);
            this.run_bttn.TabIndex = 6;
            this.run_bttn.Text = "Run...";
            this.run_bttn.UseVisualStyleBackColor = true;
            this.run_bttn.Click += new System.EventHandler(this.run_bttn_Click);
            // 
            // add_btn
            // 
            this.add_btn.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.add_btn.Location = new System.Drawing.Point(34, 116);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(160, 29);
            this.add_btn.TabIndex = 5;
            this.add_btn.Text = "Add pattern";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // interval_tb
            // 
            this.interval_tb.BackColor = System.Drawing.SystemColors.ControlDark;
            this.interval_tb.Location = new System.Drawing.Point(132, 63);
            this.interval_tb.Name = "interval_tb";
            this.interval_tb.Size = new System.Drawing.Size(43, 29);
            this.interval_tb.TabIndex = 4;
            this.interval_tb.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Interval:";
            // 
            // generation_lb
            // 
            this.generation_lb.AutoSize = true;
            this.generation_lb.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generation_lb.Location = new System.Drawing.Point(6, 45);
            this.generation_lb.Name = "generation_lb";
            this.generation_lb.Size = new System.Drawing.Size(139, 15);
            this.generation_lb.TabIndex = 2;
            this.generation_lb.Text = "Generation: ";
            // 
            // btn_eddit
            // 
            this.btn_eddit.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eddit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_eddit.Location = new System.Drawing.Point(181, 63);
            this.btn_eddit.Name = "btn_eddit";
            this.btn_eddit.Size = new System.Drawing.Size(63, 29);
            this.btn_eddit.TabIndex = 0;
            this.btn_eddit.Text = "Edit";
            this.btn_eddit.UseVisualStyleBackColor = true;
            this.btn_eddit.Click += new System.EventHandler(this.btn_eddit_Click);
            // 
            // rst_button
            // 
            this.rst_button.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rst_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rst_button.Location = new System.Drawing.Point(151, 210);
            this.rst_button.Name = "rst_button";
            this.rst_button.Size = new System.Drawing.Size(92, 64);
            this.rst_button.TabIndex = 7;
            this.rst_button.Text = "Restart...";
            this.rst_button.UseVisualStyleBackColor = true;
            this.rst_button.Click += new System.EventHandler(this.rst_button_Click);
            // 
            // tb_width
            // 
            this.tb_width.Location = new System.Drawing.Point(99, 210);
            this.tb_width.Name = "tb_width";
            this.tb_width.Size = new System.Drawing.Size(46, 29);
            this.tb_width.TabIndex = 8;
            this.tb_width.Text = "55";
            // 
            // tb_height
            // 
            this.tb_height.Location = new System.Drawing.Point(99, 245);
            this.tb_height.Name = "tb_height";
            this.tb_height.Size = new System.Drawing.Size(46, 29);
            this.tb_height.TabIndex = 9;
            this.tb_height.Text = "55";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Width:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Height:";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1334, 761);
            this.Controls.Add(this.cntrlBox);
            this.Controls.Add(this.pbRenderer);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GUI";
            this.Text = "GUI";
            this.Load += new System.EventHandler(this.GUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbRenderer)).EndInit();
            this.cntrlBox.ResumeLayout(false);
            this.cntrlBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRenderer;
        private System.Windows.Forms.GroupBox cntrlBox;
        private System.Windows.Forms.Button run_bttn;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.TextBox interval_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_eddit;
        public System.Windows.Forms.Label generation_lb;
        private System.Windows.Forms.Button rst_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_height;
        private System.Windows.Forms.TextBox tb_width;

    }
}