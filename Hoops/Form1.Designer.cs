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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.timerShootingBall = new System.Windows.Forms.Timer(this.components);
            this.pbPower = new System.Windows.Forms.ProgressBar();
            this.timerPower = new System.Windows.Forms.Timer(this.components);
            this.timerPlayerAnimation = new System.Windows.Forms.Timer(this.components);
            this.lblScoreboard = new System.Windows.Forms.Label();
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.timerTimeLeft = new System.Windows.Forms.Timer(this.components);
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            this.pbBall = new System.Windows.Forms.PictureBox();
            this.pbFullCourt = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pbLogoMenu = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbStartGame = new System.Windows.Forms.PictureBox();
            this.pbExitGame = new System.Windows.Forms.PictureBox();
            this.btnTimed = new System.Windows.Forms.PictureBox();
            this.btnFreestyle = new System.Windows.Forms.PictureBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFullCourt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStartGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExitGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTimed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFreestyle)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 113);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "lblDebug";
            this.label1.Visible = false;
            // 
            // timerShootingBall
            // 
            this.timerShootingBall.Interval = 16;
            this.timerShootingBall.Tick += new System.EventHandler(this.timerShootingBall_Tick);
            // 
            // pbPower
            // 
            this.pbPower.Enabled = false;
            this.pbPower.Location = new System.Drawing.Point(16, 666);
            this.pbPower.Margin = new System.Windows.Forms.Padding(4);
            this.pbPower.Maximum = 101;
            this.pbPower.Name = "pbPower";
            this.pbPower.Size = new System.Drawing.Size(133, 28);
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
            // timerPlayerAnimation
            // 
            this.timerPlayerAnimation.Interval = 60;
            this.timerPlayerAnimation.Tick += new System.EventHandler(this.timerPlayerAnimation_Tick);
            // 
            // lblScoreboard
            // 
            this.lblScoreboard.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblScoreboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScoreboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreboard.ForeColor = System.Drawing.Color.Brown;
            this.lblScoreboard.Location = new System.Drawing.Point(219, 292);
            this.lblScoreboard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScoreboard.Name = "lblScoreboard";
            this.lblScoreboard.Size = new System.Drawing.Size(169, 56);
            this.lblScoreboard.TabIndex = 5;
            this.lblScoreboard.Text = "0";
            this.lblScoreboard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblTimeLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTimeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeLeft.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblTimeLeft.Location = new System.Drawing.Point(49, 292);
            this.lblTimeLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(169, 56);
            this.lblTimeLeft.TabIndex = 6;
            this.lblTimeLeft.Text = "0";
            this.lblTimeLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerTimeLeft
            // 
            this.timerTimeLeft.Interval = 1000;
            this.timerTimeLeft.Tick += new System.EventHandler(this.timerTimeLeft_Tick);
            // 
            // pbPlayer
            // 
            this.pbPlayer.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayer.Location = new System.Drawing.Point(469, 686);
            this.pbPlayer.Margin = new System.Windows.Forms.Padding(4);
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.Size = new System.Drawing.Size(105, 206);
            this.pbPlayer.TabIndex = 4;
            this.pbPlayer.TabStop = false;
            this.pbPlayer.Visible = false;
            // 
            // pbBall
            // 
            this.pbBall.BackColor = System.Drawing.Color.Transparent;
            this.pbBall.Image = global::Hoops.Properties.Resources.basketball;
            this.pbBall.Location = new System.Drawing.Point(21, 32);
            this.pbBall.Margin = new System.Windows.Forms.Padding(4);
            this.pbBall.Name = "pbBall";
            this.pbBall.Size = new System.Drawing.Size(60, 55);
            this.pbBall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBall.TabIndex = 2;
            this.pbBall.TabStop = false;
            // 
            // pbFullCourt
            // 
            this.pbFullCourt.BackColor = System.Drawing.Color.Transparent;
            this.pbFullCourt.Image = global::Hoops.Properties.Resources.basketball_court_timed_mode;
            this.pbFullCourt.Location = new System.Drawing.Point(0, -1);
            this.pbFullCourt.Margin = new System.Windows.Forms.Padding(4);
            this.pbFullCourt.Name = "pbFullCourt";
            this.pbFullCourt.Size = new System.Drawing.Size(1445, 1007);
            this.pbFullCourt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFullCourt.TabIndex = 0;
            this.pbFullCourt.TabStop = false;
            this.pbFullCourt.Paint += new System.Windows.Forms.PaintEventHandler(this.pbFullCourt_Paint);
            this.pbFullCourt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbFullCourt_MouseClick);
            this.pbFullCourt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbFullCourt_MouseMove);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // pbLogoMenu
            // 
            this.pbLogoMenu.Image = global::Hoops.Properties.Resources.icon;
            this.pbLogoMenu.Location = new System.Drawing.Point(593, 49);
            this.pbLogoMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbLogoMenu.Name = "pbLogoMenu";
            this.pbLogoMenu.Size = new System.Drawing.Size(259, 222);
            this.pbLogoMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogoMenu.TabIndex = 0;
            this.pbLogoMenu.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Hoops.Properties.Resources.hoops_logo_text;
            this.pictureBox1.Location = new System.Drawing.Point(441, 293);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(595, 197);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pbStartGame
            // 
            this.pbStartGame.Image = global::Hoops.Properties.Resources.btn_start_game;
            this.pbStartGame.Location = new System.Drawing.Point(373, 496);
            this.pbStartGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbStartGame.Name = "pbStartGame";
            this.pbStartGame.Size = new System.Drawing.Size(772, 254);
            this.pbStartGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStartGame.TabIndex = 2;
            this.pbStartGame.TabStop = false;
            this.pbStartGame.Click += new System.EventHandler(this.pbStartGame_Click);
            // 
            // pbExitGame
            // 
            this.pbExitGame.Image = global::Hoops.Properties.Resources.btn_exit;
            this.pbExitGame.Location = new System.Drawing.Point(219, 727);
            this.pbExitGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbExitGame.Name = "pbExitGame";
            this.pbExitGame.Size = new System.Drawing.Size(772, 254);
            this.pbExitGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbExitGame.TabIndex = 3;
            this.pbExitGame.TabStop = false;
            this.pbExitGame.Click += new System.EventHandler(this.pbExitGame_Click);
            // 
            // btnTimed
            // 
            this.btnTimed.Image = global::Hoops.Properties.Resources.timed_mode_text;
            this.btnTimed.Location = new System.Drawing.Point(219, 565);
            this.btnTimed.Name = "btnTimed";
            this.btnTimed.Size = new System.Drawing.Size(444, 292);
            this.btnTimed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnTimed.TabIndex = 4;
            this.btnTimed.TabStop = false;
            this.btnTimed.Visible = false;
            this.btnTimed.Click += new System.EventHandler(this.btnTimed_Click);
            // 
            // btnFreestyle
            // 
            this.btnFreestyle.Image = global::Hoops.Properties.Resources.freestyle_mode_text;
            this.btnFreestyle.Location = new System.Drawing.Point(770, 482);
            this.btnFreestyle.Name = "btnFreestyle";
            this.btnFreestyle.Size = new System.Drawing.Size(541, 494);
            this.btnFreestyle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnFreestyle.TabIndex = 5;
            this.btnFreestyle.TabStop = false;
            this.btnFreestyle.Visible = false;
            this.btnFreestyle.Click += new System.EventHandler(this.btnFreestyle_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pnlMenu.Controls.Add(this.btnFreestyle);
            this.pnlMenu.Controls.Add(this.btnTimed);
            this.pnlMenu.Controls.Add(this.pbExitGame);
            this.pnlMenu.Controls.Add(this.pbStartGame);
            this.pnlMenu.Controls.Add(this.pictureBox1);
            this.pnlMenu.Controls.Add(this.pbLogoMenu);
            this.pnlMenu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pnlMenu.Location = new System.Drawing.Point(0, -1);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1445, 1007);
            this.pnlMenu.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1444, 1007);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.lblTimeLeft);
            this.Controls.Add(this.lblScoreboard);
            this.Controls.Add(this.pbPlayer);
            this.Controls.Add(this.pbPower);
            this.Controls.Add(this.pbBall);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbFullCourt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Hoops";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFullCourt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStartGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExitGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTimed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFreestyle)).EndInit();
            this.pnlMenu.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblScoreboard;
        private System.Windows.Forms.Label lblTimeLeft;
        private System.Windows.Forms.Timer timerTimeLeft;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pbLogoMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbStartGame;
        private System.Windows.Forms.PictureBox pbExitGame;
        private System.Windows.Forms.PictureBox btnTimed;
        private System.Windows.Forms.PictureBox btnFreestyle;
        private System.Windows.Forms.Panel pnlMenu;
    }
}

