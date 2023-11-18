namespace PROG7312_POE_PART1.UserControls
{
    partial class findingCallNumbers
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(findingCallNumbers));
            this.topPanel1 = new System.Windows.Forms.Panel();
            this.lb_TopPanel1 = new System.Windows.Forms.Label();
            this.topPanel2 = new System.Windows.Forms.Panel();
            this.lb_TopPanel2 = new System.Windows.Forms.Label();
            this.bottomPanel1 = new System.Windows.Forms.Panel();
            this.lb_BottomPanel1 = new System.Windows.Forms.Label();
            this.topPanel3 = new System.Windows.Forms.Panel();
            this.lb_TopPanel3 = new System.Windows.Forms.Label();
            this.topPanel4 = new System.Windows.Forms.Panel();
            this.lbTopPanel4 = new System.Windows.Forms.Label();
            this.btn_StartGame = new System.Windows.Forms.Button();
            this.btn_OrderGame = new System.Windows.Forms.Button();
            this.lb_ScoreToBeat = new System.Windows.Forms.Label();
            this.lbCurrentScore = new System.Windows.Forms.Label();
            this.lbl_RWScoreToBeat = new System.Windows.Forms.Label();
            this.lb_FastestTime = new System.Windows.Forms.Label();
            this.lb_GameTime = new System.Windows.Forms.Label();
            this.pb_GameProgression = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.topPanel1.SuspendLayout();
            this.topPanel2.SuspendLayout();
            this.bottomPanel1.SuspendLayout();
            this.topPanel3.SuspendLayout();
            this.topPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel1
            // 
            this.topPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("topPanel1.BackgroundImage")));
            this.topPanel1.Controls.Add(this.lb_TopPanel1);
            this.topPanel1.Location = new System.Drawing.Point(43, 128);
            this.topPanel1.Name = "topPanel1";
            this.topPanel1.Size = new System.Drawing.Size(252, 73);
            this.topPanel1.TabIndex = 0;
            this.topPanel1.Tag = "target";
            // 
            // lb_TopPanel1
            // 
            this.lb_TopPanel1.AutoSize = true;
            this.lb_TopPanel1.BackColor = System.Drawing.Color.Transparent;
            this.lb_TopPanel1.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TopPanel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lb_TopPanel1.Location = new System.Drawing.Point(14, 31);
            this.lb_TopPanel1.Name = "lb_TopPanel1";
            this.lb_TopPanel1.Size = new System.Drawing.Size(51, 22);
            this.lb_TopPanel1.TabIndex = 0;
            this.lb_TopPanel1.Text = "label1";
            // 
            // topPanel2
            // 
            this.topPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("topPanel2.BackgroundImage")));
            this.topPanel2.Controls.Add(this.lb_TopPanel2);
            this.topPanel2.Location = new System.Drawing.Point(249, 247);
            this.topPanel2.Name = "topPanel2";
            this.topPanel2.Size = new System.Drawing.Size(246, 73);
            this.topPanel2.TabIndex = 1;
            this.topPanel2.Tag = "target";
            // 
            // lb_TopPanel2
            // 
            this.lb_TopPanel2.AutoSize = true;
            this.lb_TopPanel2.BackColor = System.Drawing.Color.Transparent;
            this.lb_TopPanel2.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TopPanel2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lb_TopPanel2.Location = new System.Drawing.Point(30, 31);
            this.lb_TopPanel2.Name = "lb_TopPanel2";
            this.lb_TopPanel2.Size = new System.Drawing.Size(51, 22);
            this.lb_TopPanel2.TabIndex = 0;
            this.lb_TopPanel2.Text = "label2";
            // 
            // bottomPanel1
            // 
            this.bottomPanel1.BackgroundImage = global::PROG7312_POE_PART1.Properties.Resources.brownBook;
            this.bottomPanel1.Controls.Add(this.lb_BottomPanel1);
            this.bottomPanel1.Location = new System.Drawing.Point(373, 340);
            this.bottomPanel1.Name = "bottomPanel1";
            this.bottomPanel1.Size = new System.Drawing.Size(255, 100);
            this.bottomPanel1.TabIndex = 2;
            this.bottomPanel1.Tag = "draggable";
            this.bottomPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GenericPanel_MouseDown);
            this.bottomPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GenericPanel_MouseMove);
            this.bottomPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GenericPanel_MouseUp);
            // 
            // lb_BottomPanel1
            // 
            this.lb_BottomPanel1.AutoSize = true;
            this.lb_BottomPanel1.BackColor = System.Drawing.Color.Transparent;
            this.lb_BottomPanel1.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_BottomPanel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lb_BottomPanel1.Location = new System.Drawing.Point(9, 47);
            this.lb_BottomPanel1.Name = "lb_BottomPanel1";
            this.lb_BottomPanel1.Size = new System.Drawing.Size(51, 22);
            this.lb_BottomPanel1.TabIndex = 2;
            this.lb_BottomPanel1.Text = "label4";
            // 
            // topPanel3
            // 
            this.topPanel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("topPanel3.BackgroundImage")));
            this.topPanel3.Controls.Add(this.lb_TopPanel3);
            this.topPanel3.Location = new System.Drawing.Point(480, 129);
            this.topPanel3.Name = "topPanel3";
            this.topPanel3.Size = new System.Drawing.Size(253, 73);
            this.topPanel3.TabIndex = 3;
            this.topPanel3.Tag = "target";
            // 
            // lb_TopPanel3
            // 
            this.lb_TopPanel3.AutoSize = true;
            this.lb_TopPanel3.BackColor = System.Drawing.Color.Transparent;
            this.lb_TopPanel3.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TopPanel3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lb_TopPanel3.Location = new System.Drawing.Point(12, 23);
            this.lb_TopPanel3.Name = "lb_TopPanel3";
            this.lb_TopPanel3.Size = new System.Drawing.Size(51, 22);
            this.lb_TopPanel3.TabIndex = 1;
            this.lb_TopPanel3.Text = "label3";
            // 
            // topPanel4
            // 
            this.topPanel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("topPanel4.BackgroundImage")));
            this.topPanel4.Controls.Add(this.lbTopPanel4);
            this.topPanel4.Location = new System.Drawing.Point(680, 242);
            this.topPanel4.Name = "topPanel4";
            this.topPanel4.Size = new System.Drawing.Size(236, 73);
            this.topPanel4.TabIndex = 4;
            this.topPanel4.Tag = "target";
            // 
            // lbTopPanel4
            // 
            this.lbTopPanel4.AutoSize = true;
            this.lbTopPanel4.BackColor = System.Drawing.Color.Transparent;
            this.lbTopPanel4.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTopPanel4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbTopPanel4.Location = new System.Drawing.Point(19, 31);
            this.lbTopPanel4.Name = "lbTopPanel4";
            this.lbTopPanel4.Size = new System.Drawing.Size(51, 22);
            this.lbTopPanel4.TabIndex = 1;
            this.lbTopPanel4.Text = "label4";
            // 
            // btn_StartGame
            // 
            this.btn_StartGame.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_StartGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_StartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StartGame.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_StartGame.Location = new System.Drawing.Point(560, 477);
            this.btn_StartGame.Margin = new System.Windows.Forms.Padding(4);
            this.btn_StartGame.Name = "btn_StartGame";
            this.btn_StartGame.Size = new System.Drawing.Size(208, 43);
            this.btn_StartGame.TabIndex = 37;
            this.btn_StartGame.Text = "Start Game!";
            this.btn_StartGame.UseVisualStyleBackColor = false;
            this.btn_StartGame.Click += new System.EventHandler(this.btn_StartGame_Click);
            // 
            // btn_OrderGame
            // 
            this.btn_OrderGame.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_OrderGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_OrderGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OrderGame.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_OrderGame.Location = new System.Drawing.Point(798, 476);
            this.btn_OrderGame.Margin = new System.Windows.Forms.Padding(4);
            this.btn_OrderGame.Name = "btn_OrderGame";
            this.btn_OrderGame.Size = new System.Drawing.Size(208, 43);
            this.btn_OrderGame.TabIndex = 36;
            this.btn_OrderGame.Text = "Back to Menu";
            this.btn_OrderGame.UseVisualStyleBackColor = false;
            this.btn_OrderGame.Click += new System.EventHandler(this.btn_OrderGame_Click);
            // 
            // lb_ScoreToBeat
            // 
            this.lb_ScoreToBeat.AutoSize = true;
            this.lb_ScoreToBeat.BackColor = System.Drawing.Color.Transparent;
            this.lb_ScoreToBeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ScoreToBeat.ForeColor = System.Drawing.Color.DarkRed;
            this.lb_ScoreToBeat.Location = new System.Drawing.Point(37, 465);
            this.lb_ScoreToBeat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ScoreToBeat.Name = "lb_ScoreToBeat";
            this.lb_ScoreToBeat.Size = new System.Drawing.Size(179, 31);
            this.lb_ScoreToBeat.TabIndex = 39;
            this.lb_ScoreToBeat.Text = "score to beat!";
            this.lb_ScoreToBeat.Click += new System.EventHandler(this.lb_ScoreToBeat_Click);
            // 
            // lbCurrentScore
            // 
            this.lbCurrentScore.AutoSize = true;
            this.lbCurrentScore.BackColor = System.Drawing.Color.Transparent;
            this.lbCurrentScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentScore.ForeColor = System.Drawing.Color.DarkRed;
            this.lbCurrentScore.Location = new System.Drawing.Point(229, 78);
            this.lbCurrentScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCurrentScore.Name = "lbCurrentScore";
            this.lbCurrentScore.Size = new System.Drawing.Size(351, 31);
            this.lbCurrentScore.TabIndex = 40;
            this.lbCurrentScore.Text = "Score || Right : 0 | Wrong : 0";
            // 
            // lbl_RWScoreToBeat
            // 
            this.lbl_RWScoreToBeat.AutoSize = true;
            this.lbl_RWScoreToBeat.BackColor = System.Drawing.Color.Transparent;
            this.lbl_RWScoreToBeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RWScoreToBeat.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_RWScoreToBeat.Location = new System.Drawing.Point(243, 515);
            this.lbl_RWScoreToBeat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_RWScoreToBeat.Name = "lbl_RWScoreToBeat";
            this.lbl_RWScoreToBeat.Size = new System.Drawing.Size(252, 31);
            this.lbl_RWScoreToBeat.TabIndex = 41;
            this.lbl_RWScoreToBeat.Text = "Right : 0 | Wrong : 0";
            this.lbl_RWScoreToBeat.Click += new System.EventHandler(this.label1_Click);
            // 
            // lb_FastestTime
            // 
            this.lb_FastestTime.AutoSize = true;
            this.lb_FastestTime.BackColor = System.Drawing.Color.Transparent;
            this.lb_FastestTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_FastestTime.ForeColor = System.Drawing.Color.DarkRed;
            this.lb_FastestTime.Location = new System.Drawing.Point(245, 465);
            this.lb_FastestTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_FastestTime.Name = "lb_FastestTime";
            this.lb_FastestTime.Size = new System.Drawing.Size(104, 31);
            this.lb_FastestTime.TabIndex = 38;
            this.lb_FastestTime.Text = "000000";
            // 
            // lb_GameTime
            // 
            this.lb_GameTime.AutoSize = true;
            this.lb_GameTime.BackColor = System.Drawing.Color.Transparent;
            this.lb_GameTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_GameTime.ForeColor = System.Drawing.Color.DarkRed;
            this.lb_GameTime.Image = global::PROG7312_POE_PART1.Properties.Resources.labelBackground;
            this.lb_GameTime.Location = new System.Drawing.Point(1095, 12);
            this.lb_GameTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_GameTime.Name = "lb_GameTime";
            this.lb_GameTime.Size = new System.Drawing.Size(120, 31);
            this.lb_GameTime.TabIndex = 43;
            this.lb_GameTime.Text = "00:00:00";
            // 
            // pb_GameProgression
            // 
            this.pb_GameProgression.Location = new System.Drawing.Point(4, 14);
            this.pb_GameProgression.Margin = new System.Windows.Forms.Padding(4);
            this.pb_GameProgression.Name = "pb_GameProgression";
            this.pb_GameProgression.Size = new System.Drawing.Size(956, 31);
            this.pb_GameProgression.TabIndex = 42;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // findingCallNumbers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PROG7312_POE_PART1.Properties.Resources.orderGameBackground;
            this.Controls.Add(this.lb_GameTime);
            this.Controls.Add(this.lbCurrentScore);
            this.Controls.Add(this.pb_GameProgression);
            this.Controls.Add(this.lbl_RWScoreToBeat);
            this.Controls.Add(this.lb_ScoreToBeat);
            this.Controls.Add(this.lb_FastestTime);
            this.Controls.Add(this.btn_StartGame);
            this.Controls.Add(this.topPanel4);
            this.Controls.Add(this.btn_OrderGame);
            this.Controls.Add(this.topPanel3);
            this.Controls.Add(this.bottomPanel1);
            this.Controls.Add(this.topPanel2);
            this.Controls.Add(this.topPanel1);
            this.MaximumSize = new System.Drawing.Size(1335, 631);
            this.MinimumSize = new System.Drawing.Size(1335, 631);
            this.Name = "findingCallNumbers";
            this.Size = new System.Drawing.Size(1335, 631);
            this.topPanel1.ResumeLayout(false);
            this.topPanel1.PerformLayout();
            this.topPanel2.ResumeLayout(false);
            this.topPanel2.PerformLayout();
            this.bottomPanel1.ResumeLayout(false);
            this.bottomPanel1.PerformLayout();
            this.topPanel3.ResumeLayout(false);
            this.topPanel3.PerformLayout();
            this.topPanel4.ResumeLayout(false);
            this.topPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topPanel1;
        private System.Windows.Forms.Label lb_TopPanel1;
        private System.Windows.Forms.Panel topPanel2;
        private System.Windows.Forms.Label lb_TopPanel2;
        private System.Windows.Forms.Panel bottomPanel1;
        private System.Windows.Forms.Label lb_BottomPanel1;
        private System.Windows.Forms.Panel topPanel3;
        private System.Windows.Forms.Label lb_TopPanel3;
        private System.Windows.Forms.Panel topPanel4;
        private System.Windows.Forms.Label lbTopPanel4;
        private System.Windows.Forms.Button btn_StartGame;
        private System.Windows.Forms.Button btn_OrderGame;
        private System.Windows.Forms.Label lb_ScoreToBeat;
        private System.Windows.Forms.Label lbCurrentScore;
        private System.Windows.Forms.Label lbl_RWScoreToBeat;
        private System.Windows.Forms.Label lb_FastestTime;
        private System.Windows.Forms.Label lb_GameTime;
        private System.Windows.Forms.ProgressBar pb_GameProgression;
        private System.Windows.Forms.Timer timer1;
    }
}
