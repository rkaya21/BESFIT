namespace Protein_Mağazası
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ilerleme = new Bunifu.UI.WinForms.BunifuProgressBar();
            this.bunifuPictureBox1 = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(211, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(237, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "BESFIT YÖNETİM SİSTEMİ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(276, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "VERSİON 1.0";
            // 
            // ilerleme
            // 
            this.ilerleme.AllowAnimations = false;
            this.ilerleme.Animation = 0;
            this.ilerleme.AnimationSpeed = 220;
            this.ilerleme.AnimationStep = 10;
            this.ilerleme.BackColor = System.Drawing.Color.DarkOrange;
            this.ilerleme.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ilerleme.BackgroundImage")));
            this.ilerleme.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.ilerleme.BorderRadius = 9;
            this.ilerleme.BorderThickness = 1;
            this.ilerleme.Location = new System.Drawing.Point(0, 282);
            this.ilerleme.Maximum = 100;
            this.ilerleme.MaximumValue = 100;
            this.ilerleme.Minimum = 0;
            this.ilerleme.MinimumValue = 0;
            this.ilerleme.Name = "ilerleme";
            this.ilerleme.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ilerleme.ProgressBackColor = System.Drawing.Color.DarkOrange;
            this.ilerleme.ProgressColorLeft = System.Drawing.Color.DodgerBlue;
            this.ilerleme.ProgressColorRight = System.Drawing.Color.DodgerBlue;
            this.ilerleme.Size = new System.Drawing.Size(704, 13);
            this.ilerleme.TabIndex = 16;
            this.ilerleme.Value = 50;
            this.ilerleme.ValueByTransition = 50;
            // 
            // bunifuPictureBox1
            // 
            this.bunifuPictureBox1.AllowFocused = false;
            this.bunifuPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuPictureBox1.AutoSizeHeight = true;
            this.bunifuPictureBox1.BorderRadius = 81;
            this.bunifuPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuPictureBox1.Image")));
            this.bunifuPictureBox1.IsCircle = true;
            this.bunifuPictureBox1.Location = new System.Drawing.Point(256, 77);
            this.bunifuPictureBox1.Name = "bunifuPictureBox1";
            this.bunifuPictureBox1.Size = new System.Drawing.Size(162, 162);
            this.bunifuPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuPictureBox1.TabIndex = 17;
            this.bunifuPictureBox1.TabStop = false;
            this.bunifuPictureBox1.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(704, 295);
            this.Controls.Add(this.bunifuPictureBox1);
            this.Controls.Add(this.ilerleme);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.Load += new System.EventHandler(this.Splash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuProgressBar ilerleme;
        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox1;
        private System.Windows.Forms.Timer timer1;
    }
}