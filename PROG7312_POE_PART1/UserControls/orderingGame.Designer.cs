namespace PROG7312_POE_PART1.UserControls
{
    partial class orderingGame
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
            this.pb_GameProgression = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lb_GameTime = new System.Windows.Forms.Label();
            this.lb_FastestTime = new System.Windows.Forms.Label();
            this.lb_ScoreToBeat = new System.Windows.Forms.Label();
            this.btn_OrderGame = new System.Windows.Forms.Button();
            this.pn_TopBook1 = new System.Windows.Forms.Panel();
            this.pn_TopBook2 = new System.Windows.Forms.Panel();
            this.pn_TopBook4 = new System.Windows.Forms.Panel();
            this.pn_TopBook3 = new System.Windows.Forms.Panel();
            this.pn_TopBook5 = new System.Windows.Forms.Panel();
            this.pn_BottomBook1 = new System.Windows.Forms.Panel();
            this.pn_BottomBook2 = new System.Windows.Forms.Panel();
            this.btn_StartGame = new System.Windows.Forms.Button();
            this.lb_BottomBook1 = new System.Windows.Forms.Label();
            this.lb_TopBook1 = new System.Windows.Forms.Label();
            this.pn_TopBook1.SuspendLayout();
            this.pn_BottomBook1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_GameProgression
            // 
            this.pb_GameProgression.Location = new System.Drawing.Point(14, 15);
            this.pb_GameProgression.Name = "pb_GameProgression";
            this.pb_GameProgression.Size = new System.Drawing.Size(717, 25);
            this.pb_GameProgression.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // lb_GameTime
            // 
            this.lb_GameTime.AutoSize = true;
            this.lb_GameTime.BackColor = System.Drawing.SystemColors.Control;
            this.lb_GameTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_GameTime.ForeColor = System.Drawing.Color.DarkRed;
            this.lb_GameTime.Image = global::PROG7312_POE_PART1.Properties.Resources.labelBackground;
            this.lb_GameTime.Location = new System.Drawing.Point(833, 15);
            this.lb_GameTime.Name = "lb_GameTime";
            this.lb_GameTime.Size = new System.Drawing.Size(96, 25);
            this.lb_GameTime.TabIndex = 1;
            this.lb_GameTime.Text = "00:00:00";
            // 
            // lb_FastestTime
            // 
            this.lb_FastestTime.AutoSize = true;
            this.lb_FastestTime.BackColor = System.Drawing.SystemColors.Control;
            this.lb_FastestTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_FastestTime.ForeColor = System.Drawing.Color.DarkRed;
            this.lb_FastestTime.Image = global::PROG7312_POE_PART1.Properties.Resources.labelBackground;
            this.lb_FastestTime.Location = new System.Drawing.Point(176, 473);
            this.lb_FastestTime.Name = "lb_FastestTime";
            this.lb_FastestTime.Size = new System.Drawing.Size(96, 25);
            this.lb_FastestTime.TabIndex = 2;
            this.lb_FastestTime.Text = "00:00:00";
            // 
            // lb_ScoreToBeat
            // 
            this.lb_ScoreToBeat.AutoSize = true;
            this.lb_ScoreToBeat.BackColor = System.Drawing.SystemColors.Control;
            this.lb_ScoreToBeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ScoreToBeat.ForeColor = System.Drawing.Color.DarkRed;
            this.lb_ScoreToBeat.Image = global::PROG7312_POE_PART1.Properties.Resources.labelBackground;
            this.lb_ScoreToBeat.Location = new System.Drawing.Point(14, 473);
            this.lb_ScoreToBeat.Name = "lb_ScoreToBeat";
            this.lb_ScoreToBeat.Size = new System.Drawing.Size(143, 25);
            this.lb_ScoreToBeat.TabIndex = 3;
            this.lb_ScoreToBeat.Text = "score to beat!";
            // 
            // btn_OrderGame
            // 
            this.btn_OrderGame.BackgroundImage = global::PROG7312_POE_PART1.Properties.Resources.mainMenuBtnBackgrounds;
            this.btn_OrderGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_OrderGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OrderGame.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_OrderGame.Location = new System.Drawing.Point(795, 463);
            this.btn_OrderGame.Name = "btn_OrderGame";
            this.btn_OrderGame.Size = new System.Drawing.Size(156, 35);
            this.btn_OrderGame.TabIndex = 23;
            this.btn_OrderGame.Text = "Back to Menu";
            this.btn_OrderGame.UseVisualStyleBackColor = true;
            this.btn_OrderGame.Click += new System.EventHandler(this.btn_OrderGame_Click);
            this.btn_OrderGame.MouseHover += new System.EventHandler(this.btn_OrderGame_MouseHover);
            // 
            // pn_TopBook1
            // 
            this.pn_TopBook1.Controls.Add(this.lb_TopBook1);
            this.pn_TopBook1.Location = new System.Drawing.Point(19, 70);
            this.pn_TopBook1.MaximumSize = new System.Drawing.Size(64, 132);
            this.pn_TopBook1.MinimumSize = new System.Drawing.Size(64, 132);
            this.pn_TopBook1.Name = "pn_TopBook1";
            this.pn_TopBook1.Size = new System.Drawing.Size(64, 132);
            this.pn_TopBook1.TabIndex = 24;
            this.pn_TopBook1.Tag = "target";
            // 
            // pn_TopBook2
            // 
            this.pn_TopBook2.Location = new System.Drawing.Point(93, 70);
            this.pn_TopBook2.MaximumSize = new System.Drawing.Size(64, 132);
            this.pn_TopBook2.MinimumSize = new System.Drawing.Size(64, 132);
            this.pn_TopBook2.Name = "pn_TopBook2";
            this.pn_TopBook2.Size = new System.Drawing.Size(64, 132);
            this.pn_TopBook2.TabIndex = 25;
            this.pn_TopBook2.Tag = "target";
            // 
            // pn_TopBook4
            // 
            this.pn_TopBook4.Location = new System.Drawing.Point(239, 70);
            this.pn_TopBook4.MaximumSize = new System.Drawing.Size(64, 132);
            this.pn_TopBook4.MinimumSize = new System.Drawing.Size(64, 132);
            this.pn_TopBook4.Name = "pn_TopBook4";
            this.pn_TopBook4.Size = new System.Drawing.Size(64, 132);
            this.pn_TopBook4.TabIndex = 27;
            this.pn_TopBook4.Tag = "target";
            // 
            // pn_TopBook3
            // 
            this.pn_TopBook3.Location = new System.Drawing.Point(166, 70);
            this.pn_TopBook3.MaximumSize = new System.Drawing.Size(64, 132);
            this.pn_TopBook3.MinimumSize = new System.Drawing.Size(64, 132);
            this.pn_TopBook3.Name = "pn_TopBook3";
            this.pn_TopBook3.Size = new System.Drawing.Size(64, 132);
            this.pn_TopBook3.TabIndex = 26;
            this.pn_TopBook3.Tag = "target";
            // 
            // pn_TopBook5
            // 
            this.pn_TopBook5.Location = new System.Drawing.Point(309, 70);
            this.pn_TopBook5.MaximumSize = new System.Drawing.Size(64, 132);
            this.pn_TopBook5.MinimumSize = new System.Drawing.Size(64, 132);
            this.pn_TopBook5.Name = "pn_TopBook5";
            this.pn_TopBook5.Size = new System.Drawing.Size(64, 132);
            this.pn_TopBook5.TabIndex = 28;
            this.pn_TopBook5.Tag = "target";
            // 
            // pn_BottomBook1
            // 
            this.pn_BottomBook1.BackgroundImage = global::PROG7312_POE_PART1.Properties.Resources.greenBook3;
            this.pn_BottomBook1.Controls.Add(this.lb_BottomBook1);
            this.pn_BottomBook1.Location = new System.Drawing.Point(19, 266);
            this.pn_BottomBook1.MaximumSize = new System.Drawing.Size(64, 132);
            this.pn_BottomBook1.MinimumSize = new System.Drawing.Size(64, 132);
            this.pn_BottomBook1.Name = "pn_BottomBook1";
            this.pn_BottomBook1.Size = new System.Drawing.Size(64, 132);
            this.pn_BottomBook1.TabIndex = 25;
            this.pn_BottomBook1.Tag = "draggable";
            // 
            // pn_BottomBook2
            // 
            this.pn_BottomBook2.BackgroundImage = global::PROG7312_POE_PART1.Properties.Resources.brownBook;
            this.pn_BottomBook2.Location = new System.Drawing.Point(93, 266);
            this.pn_BottomBook2.MaximumSize = new System.Drawing.Size(64, 132);
            this.pn_BottomBook2.MinimumSize = new System.Drawing.Size(64, 132);
            this.pn_BottomBook2.Name = "pn_BottomBook2";
            this.pn_BottomBook2.Size = new System.Drawing.Size(64, 132);
            this.pn_BottomBook2.TabIndex = 26;
            this.pn_BottomBook2.Tag = "draggable";
            // 
            // btn_StartGame
            // 
            this.btn_StartGame.BackgroundImage = global::PROG7312_POE_PART1.Properties.Resources.mainMenuBtnBackgrounds;
            this.btn_StartGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_StartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StartGame.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_StartGame.Location = new System.Drawing.Point(575, 463);
            this.btn_StartGame.Name = "btn_StartGame";
            this.btn_StartGame.Size = new System.Drawing.Size(156, 35);
            this.btn_StartGame.TabIndex = 29;
            this.btn_StartGame.Text = "Start Game!";
            this.btn_StartGame.UseVisualStyleBackColor = true;
            this.btn_StartGame.Click += new System.EventHandler(this.btn_StartGame_Click);
            this.btn_StartGame.MouseHover += new System.EventHandler(this.btn_OrderGame_MouseHover);
            // 
            // lb_BottomBook1
            // 
            this.lb_BottomBook1.AutoSize = true;
            this.lb_BottomBook1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_BottomBook1.Location = new System.Drawing.Point(7, 103);
            this.lb_BottomBook1.Name = "lb_BottomBook1";
            this.lb_BottomBook1.Size = new System.Drawing.Size(52, 16);
            this.lb_BottomBook1.TabIndex = 0;
            this.lb_BottomBook1.Text = "001.234";
            // 
            // lb_TopBook1
            // 
            this.lb_TopBook1.AutoSize = true;
            this.lb_TopBook1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TopBook1.Location = new System.Drawing.Point(7, 97);
            this.lb_TopBook1.Name = "lb_TopBook1";
            this.lb_TopBook1.Size = new System.Drawing.Size(52, 16);
            this.lb_TopBook1.TabIndex = 1;
            this.lb_TopBook1.Text = "000.000";
            // 
            // orderingGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PROG7312_POE_PART1.Properties.Resources.orderGameBackground;
            this.Controls.Add(this.btn_StartGame);
            this.Controls.Add(this.pn_BottomBook2);
            this.Controls.Add(this.pn_BottomBook1);
            this.Controls.Add(this.pn_TopBook5);
            this.Controls.Add(this.pn_TopBook4);
            this.Controls.Add(this.pn_TopBook3);
            this.Controls.Add(this.pn_TopBook2);
            this.Controls.Add(this.pn_TopBook1);
            this.Controls.Add(this.btn_OrderGame);
            this.Controls.Add(this.lb_ScoreToBeat);
            this.Controls.Add(this.lb_FastestTime);
            this.Controls.Add(this.lb_GameTime);
            this.Controls.Add(this.pb_GameProgression);
            this.MaximumSize = new System.Drawing.Size(1001, 513);
            this.MinimumSize = new System.Drawing.Size(1001, 513);
            this.Name = "orderingGame";
            this.Size = new System.Drawing.Size(1001, 513);
            this.pn_TopBook1.ResumeLayout(false);
            this.pn_TopBook1.PerformLayout();
            this.pn_BottomBook1.ResumeLayout(false);
            this.pn_BottomBook1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pb_GameProgression;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lb_GameTime;
        private System.Windows.Forms.Label lb_FastestTime;
        private System.Windows.Forms.Label lb_ScoreToBeat;
        private System.Windows.Forms.Button btn_OrderGame;
        private System.Windows.Forms.Panel pn_TopBook1;
        private System.Windows.Forms.Panel pn_TopBook2;
        private System.Windows.Forms.Panel pn_TopBook4;
        private System.Windows.Forms.Panel pn_TopBook3;
        private System.Windows.Forms.Panel pn_TopBook5;
        private System.Windows.Forms.Panel pn_BottomBook1;
        private System.Windows.Forms.Panel pn_BottomBook2;
        private System.Windows.Forms.Button btn_StartGame;
        private System.Windows.Forms.Label lb_BottomBook1;
        private System.Windows.Forms.Label lb_TopBook1;
    }
}
