namespace Pac_Man
{
    partial class GameScene
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScene));
            this.gameView = new System.Windows.Forms.PictureBox();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.scoreLabelInt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hScoreInt = new System.Windows.Forms.Label();
            this.life1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.upLabel = new System.Windows.Forms.Label();
            this.life2 = new System.Windows.Forms.PictureBox();
            this.life3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.readyTimer = new System.Windows.Forms.Timer(this.components);
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.playerTimer = new System.Windows.Forms.Timer(this.components);
            this.pacOpen = new System.Windows.Forms.PictureBox();
            this.pacClose = new System.Windows.Forms.PictureBox();
            this.oriPacOpen = new System.Windows.Forms.PictureBox();
            this.ghostRedImg = new System.Windows.Forms.PictureBox();
            this.ghostYellowImg = new System.Windows.Forms.PictureBox();
            this.ghostPinkImg = new System.Windows.Forms.PictureBox();
            this.ghostGreenImg = new System.Windows.Forms.PictureBox();
            this.ghostTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gameView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.life1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.life2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.life3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pacOpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pacClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oriPacOpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ghostRedImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ghostYellowImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ghostPinkImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ghostGreenImg)).BeginInit();
            this.SuspendLayout();
            // 
            // gameView
            // 
            this.gameView.Location = new System.Drawing.Point(88, 25);
            this.gameView.Name = "gameView";
            this.gameView.Size = new System.Drawing.Size(500, 250);
            this.gameView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gameView.TabIndex = 0;
            this.gameView.TabStop = false;
            this.gameView.Click += new System.EventHandler(this.gameView_Click);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Playbill", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(594, 79);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(111, 33);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "Game score";
            // 
            // scoreLabelInt
            // 
            this.scoreLabelInt.AutoSize = true;
            this.scoreLabelInt.Font = new System.Drawing.Font("Playbill", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scoreLabelInt.ForeColor = System.Drawing.Color.White;
            this.scoreLabelInt.Location = new System.Drawing.Point(639, 112);
            this.scoreLabelInt.Name = "scoreLabelInt";
            this.scoreLabelInt.Size = new System.Drawing.Size(23, 29);
            this.scoreLabelInt.TabIndex = 2;
            this.scoreLabelInt.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Playbill", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(594, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "High score";
            // 
            // hScoreInt
            // 
            this.hScoreInt.AutoSize = true;
            this.hScoreInt.Font = new System.Drawing.Font("Playbill", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hScoreInt.ForeColor = System.Drawing.Color.White;
            this.hScoreInt.Location = new System.Drawing.Point(639, 187);
            this.hScoreInt.Name = "hScoreInt";
            this.hScoreInt.Size = new System.Drawing.Size(23, 29);
            this.hScoreInt.TabIndex = 4;
            this.hScoreInt.Text = "0";
            this.hScoreInt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // life1
            // 
            this.life1.Image = global::Pac_Man.Resources.pacmanLive;
            this.life1.Location = new System.Drawing.Point(26, 75);
            this.life1.Name = "life1";
            this.life1.Size = new System.Drawing.Size(30, 30);
            this.life1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.life1.TabIndex = 5;
            this.life1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Playbill", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(42, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "UP";
            // 
            // upLabel
            // 
            this.upLabel.AutoSize = true;
            this.upLabel.Font = new System.Drawing.Font("Playbill", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.upLabel.ForeColor = System.Drawing.Color.White;
            this.upLabel.Location = new System.Drawing.Point(17, 29);
            this.upLabel.Name = "upLabel";
            this.upLabel.Size = new System.Drawing.Size(23, 29);
            this.upLabel.TabIndex = 9;
            this.upLabel.Text = "7";
            // 
            // life2
            // 
            this.life2.Image = global::Pac_Man.Resources.pacmanLive;
            this.life2.Location = new System.Drawing.Point(26, 111);
            this.life2.Name = "life2";
            this.life2.Size = new System.Drawing.Size(30, 30);
            this.life2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.life2.TabIndex = 10;
            this.life2.TabStop = false;
            // 
            // life3
            // 
            this.life3.Image = global::Pac_Man.Resources.pacmanLive;
            this.life3.Location = new System.Drawing.Point(26, 147);
            this.life3.Name = "life3";
            this.life3.Size = new System.Drawing.Size(30, 30);
            this.life3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.life3.TabIndex = 11;
            this.life3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Pac_Man.Resources.pacman;
            this.pictureBox1.Location = new System.Drawing.Point(565, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(10, 10);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // readyTimer
            // 
            this.readyTimer.Enabled = true;
            this.readyTimer.Interval = 1000;
            this.readyTimer.Tick += new System.EventHandler(this.readyTimer_Tick);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 200;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // playerTimer
            // 
            this.playerTimer.Interval = 400;
            this.playerTimer.Tick += new System.EventHandler(this.playerSoundTimer_Tick);
            // 
            // pacOpen
            // 
            this.pacOpen.Image = global::Pac_Man.Resources.pacman_open;
            this.pacOpen.Location = new System.Drawing.Point(33, 206);
            this.pacOpen.Name = "pacOpen";
            this.pacOpen.Size = new System.Drawing.Size(10, 10);
            this.pacOpen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pacOpen.TabIndex = 14;
            this.pacOpen.TabStop = false;
            // 
            // pacClose
            // 
            this.pacClose.Image = global::Pac_Man.Resources.pacman_close;
            this.pacClose.Location = new System.Drawing.Point(17, 206);
            this.pacClose.Name = "pacClose";
            this.pacClose.Size = new System.Drawing.Size(10, 10);
            this.pacClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pacClose.TabIndex = 15;
            this.pacClose.TabStop = false;
            // 
            // oriPacOpen
            // 
            this.oriPacOpen.Image = global::Pac_Man.Resources.pacman_open;
            this.oriPacOpen.Location = new System.Drawing.Point(1, 206);
            this.oriPacOpen.Name = "oriPacOpen";
            this.oriPacOpen.Size = new System.Drawing.Size(10, 10);
            this.oriPacOpen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.oriPacOpen.TabIndex = 16;
            this.oriPacOpen.TabStop = false;
            // 
            // ghostRedImg
            // 
            this.ghostRedImg.Image = global::Pac_Man.Resources.blueGhost;
            this.ghostRedImg.Location = new System.Drawing.Point(142, 85);
            this.ghostRedImg.Name = "ghostRedImg";
            this.ghostRedImg.Size = new System.Drawing.Size(10, 10);
            this.ghostRedImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ghostRedImg.TabIndex = 17;
            this.ghostRedImg.TabStop = false;
            this.ghostRedImg.Visible = false;
            // 
            // ghostYellowImg
            // 
            this.ghostYellowImg.Image = global::Pac_Man.Resources.blueGhost;
            this.ghostYellowImg.Location = new System.Drawing.Point(158, 85);
            this.ghostYellowImg.Name = "ghostYellowImg";
            this.ghostYellowImg.Size = new System.Drawing.Size(10, 10);
            this.ghostYellowImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ghostYellowImg.TabIndex = 18;
            this.ghostYellowImg.TabStop = false;
            this.ghostYellowImg.Visible = false;
            // 
            // ghostPinkImg
            // 
            this.ghostPinkImg.Image = global::Pac_Man.Resources.blueGhost;
            this.ghostPinkImg.Location = new System.Drawing.Point(174, 85);
            this.ghostPinkImg.Name = "ghostPinkImg";
            this.ghostPinkImg.Size = new System.Drawing.Size(10, 10);
            this.ghostPinkImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ghostPinkImg.TabIndex = 19;
            this.ghostPinkImg.TabStop = false;
            this.ghostPinkImg.Visible = false;
            // 
            // ghostGreenImg
            // 
            this.ghostGreenImg.Image = global::Pac_Man.Resources.blueGhost;
            this.ghostGreenImg.Location = new System.Drawing.Point(190, 85);
            this.ghostGreenImg.Name = "ghostGreenImg";
            this.ghostGreenImg.Size = new System.Drawing.Size(10, 10);
            this.ghostGreenImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ghostGreenImg.TabIndex = 20;
            this.ghostGreenImg.TabStop = false;
            this.ghostGreenImg.Visible = false;
            // 
            // ghostTimer
            // 
            this.ghostTimer.Interval = 300;
            this.ghostTimer.Tick += new System.EventHandler(this.ghostTimer_Tick);
            // 
            // GameScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(709, 300);
            this.Controls.Add(this.ghostGreenImg);
            this.Controls.Add(this.ghostPinkImg);
            this.Controls.Add(this.ghostYellowImg);
            this.Controls.Add(this.ghostRedImg);
            this.Controls.Add(this.oriPacOpen);
            this.Controls.Add(this.pacClose);
            this.Controls.Add(this.pacOpen);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.life3);
            this.Controls.Add(this.life2);
            this.Controls.Add(this.upLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.life1);
            this.Controls.Add(this.hScoreInt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.scoreLabelInt);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.gameView);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameScene";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameScene";
            this.Load += new System.EventHandler(this.GameScene_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameScene_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScene_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.gameView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.life1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.life2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.life3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pacOpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pacClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oriPacOpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ghostRedImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ghostYellowImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ghostPinkImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ghostGreenImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox gameView;
        private Label scoreLabel;
        private Label scoreLabelInt;
        private Label label2;
        private Label hScoreInt;
        private PictureBox life1;
        private Label label4;
        private Label upLabel;
        private PictureBox life2;
        private PictureBox life3;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer readyTimer;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer playerTimer;
        private PictureBox pacOpen;
        private PictureBox pacClose;
        private PictureBox oriPacOpen;
        private PictureBox ghostRedImg;
        private PictureBox ghostYellowImg;
        private PictureBox ghostPinkImg;
        private PictureBox ghostGreenImg;
        private System.Windows.Forms.Timer ghostTimer;
    }
}