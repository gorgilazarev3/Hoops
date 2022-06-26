namespace Hoops
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.timerShootingBall = new System.Windows.Forms.Timer(this.components);
            this.pbPower = new System.Windows.Forms.ProgressBar();
            this.timerPower = new System.Windows.Forms.Timer(this.components);
            this.pbBall = new System.Windows.Forms.PictureBox();
            this.pbFullCourt = new System.Windows.Forms.PictureBox();
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            this.timerPlayerAnimation = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbBall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFullCourt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // timerShootingBall
            // 
            this.timerShootingBall.Interval = 16;
            this.timerShootingBall.Tick += new System.EventHandler(this.timerShootingBall_Tick);
            // 
            // pbPower
            // 
            this.pbPower.Enabled = false;
            this.pbPower.Location = new System.Drawing.Point(12, 541);
            this.pbPower.Maximum = 101;
            this.pbPower.Name = "pbPower";
            this.pbPower.Size = new System.Drawing.Size(100, 23);
            this.pbPower.Step = 1;
            this.pbPower.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbPower.TabIndex = 3;
            this.pbPower.Visible = false;
            // 
            // timerPower
            // 
            this.timerPower.Interval = 2;
            this.timerPower.Tick += new System.EventHandler(this.timerPower_Tick);
            // 
            // pbBall
            // 
            this.pbBall.BackColor = System.Drawing.Color.Transparent;
            this.pbBall.Image = global::Hoops.Properties.Resources.basketball;
            this.pbBall.Location = new System.Drawing.Point(16, 26);
            this.pbBall.Name = "pbBall";
            this.pbBall.Size = new System.Drawing.Size(45, 45);
            this.pbBall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBall.TabIndex = 2;
            this.pbBall.TabStop = false;
            // 
            // pbFullCourt
            // 
            this.pbFullCourt.BackColor = System.Drawing.Color.Transparent;
            this.pbFullCourt.Image = global::Hoops.Properties.Resources.basketball_court_timed_mode;
            this.pbFullCourt.Location = new System.Drawing.Point(0, -1);
            this.pbFullCourt.Name = "pbFullCourt";
            this.pbFullCourt.Size = new System.Drawing.Size(1084, 818);
            this.pbFullCourt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFullCourt.TabIndex = 0;
            this.pbFullCourt.TabStop = false;
            this.pbFullCourt.Paint += new System.Windows.Forms.PaintEventHandler(this.pbFullCourt_Paint);
            this.pbFullCourt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbFullCourt_MouseClick);
            this.pbFullCourt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbFullCourt_MouseMove);
            // 
            // pbPlayer
            // 
            this.pbPlayer.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayer.Location = new System.Drawing.Point(352, 557);
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.Size = new System.Drawing.Size(79, 167);
            this.pbPlayer.TabIndex = 4;
            this.pbPlayer.TabStop = false;
            this.pbPlayer.Visible = false;
            // 
            // timerPlayerAnimation
            // 
            this.timerPlayerAnimation.Interval = 10;
            this.timerPlayerAnimation.Tick += new System.EventHandler(this.timerPlayerAnimation_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1083, 815);
            this.Controls.Add(this.pbPlayer);
            this.Controls.Add(this.pbPower);
            this.Controls.Add(this.pbBall);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbFullCourt);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hoops";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pbBall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFullCourt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbBall;
        private System.Windows.Forms.Timer timerShootingBall;
        private System.Windows.Forms.ProgressBar pbPower;
        private System.Windows.Forms.Timer timerPower;
        private System.Windows.Forms.PictureBox pbFullCourt;
        private System.Windows.Forms.PictureBox pbPlayer;
        private System.Windows.Forms.Timer timerPlayerAnimation;
    }
}

