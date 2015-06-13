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
            ((System.ComponentModel.ISupportInitialize)(this.pbRenderer)).BeginInit();
            this.SuspendLayout();
            // 
            // pbRenderer
            // 
            this.pbRenderer.BackColor = System.Drawing.SystemColors.ControlText;
            this.pbRenderer.Location = new System.Drawing.Point(256, 23);
            this.pbRenderer.Name = "pbRenderer";
            this.pbRenderer.Size = new System.Drawing.Size(1066, 726);
            this.pbRenderer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbRenderer.TabIndex = 1;
            this.pbRenderer.TabStop = false;
            this.pbRenderer.Paint += new System.Windows.Forms.PaintEventHandler(this.pbRenderer_Paint);
            // 
            // cntrlBox
            // 
            this.cntrlBox.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cntrlBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cntrlBox.Location = new System.Drawing.Point(12, 12);
            this.cntrlBox.Name = "cntrlBox";
            this.cntrlBox.Size = new System.Drawing.Size(238, 737);
            this.cntrlBox.TabIndex = 2;
            this.cntrlBox.TabStop = false;
            this.cntrlBox.Text = "Controls";
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRenderer;
        private System.Windows.Forms.GroupBox cntrlBox;

    }
}