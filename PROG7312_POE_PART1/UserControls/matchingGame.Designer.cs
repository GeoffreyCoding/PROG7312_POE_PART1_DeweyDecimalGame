namespace PROG7312_POE_PART1.UserControls
{
    partial class matchingGame
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
            this.btn_StartGame = new System.Windows.Forms.Button();
            this.btn_OrderGame = new System.Windows.Forms.Button();
            this.lb_ScoreToBeat = new System.Windows.Forms.Label();
            this.lb_FastestTime = new System.Windows.Forms.Label();
            this.lb_GameTime = new System.Windows.Forms.Label();
            this.pb_GameProgression = new System.Windows.Forms.ProgressBar();
            this.pnlDescription6 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlDescription2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlDescription4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlDescription3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlDescription7 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlDescription5 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlDescription1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlQuestion3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlQuestion2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlQuestion1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlQuestion4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlDescription6.SuspendLayout();
            this.pnlDescription2.SuspendLayout();
            this.pnlDescription4.SuspendLayout();
            this.pnlDescription3.SuspendLayout();
            this.pnlDescription7.SuspendLayout();
            this.pnlDescription5.SuspendLayout();
            this.pnlDescription1.SuspendLayout();
            this.pnlQuestion3.SuspendLayout();
            this.pnlQuestion2.SuspendLayout();
            this.pnlQuestion1.SuspendLayout();
            this.pnlQuestion4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_StartGame
            // 
            this.btn_StartGame.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_StartGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_StartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StartGame.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_StartGame.Location = new System.Drawing.Point(847, 577);
            this.btn_StartGame.Margin = new System.Windows.Forms.Padding(4);
            this.btn_StartGame.Name = "btn_StartGame";
            this.btn_StartGame.Size = new System.Drawing.Size(208, 43);
            this.btn_StartGame.TabIndex = 35;
            this.btn_StartGame.Text = "Start Game!";
            this.btn_StartGame.UseVisualStyleBackColor = false;
            this.btn_StartGame.Click += new System.EventHandler(this.btn_StartGame_Click);
            this.btn_StartGame.MouseHover += new System.EventHandler(this.btn_MatchingGame_MouseHover);
            // 
            // btn_OrderGame
            // 
            this.btn_OrderGame.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_OrderGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_OrderGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OrderGame.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_OrderGame.Location = new System.Drawing.Point(1085, 577);
            this.btn_OrderGame.Margin = new System.Windows.Forms.Padding(4);
            this.btn_OrderGame.Name = "btn_OrderGame";
            this.btn_OrderGame.Size = new System.Drawing.Size(208, 43);
            this.btn_OrderGame.TabIndex = 34;
            this.btn_OrderGame.Text = "Back to Menu";
            this.btn_OrderGame.UseVisualStyleBackColor = false;
            this.btn_OrderGame.Click += new System.EventHandler(this.btn_OrderGame_Click);
            this.btn_OrderGame.MouseHover += new System.EventHandler(this.btn_MatchingGame_MouseHover);
            // 
            // lb_ScoreToBeat
            // 
            this.lb_ScoreToBeat.AutoSize = true;
            this.lb_ScoreToBeat.BackColor = System.Drawing.SystemColors.Control;
            this.lb_ScoreToBeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ScoreToBeat.ForeColor = System.Drawing.Color.DarkRed;
            this.lb_ScoreToBeat.Image = global::PROG7312_POE_PART1.Properties.Resources.labelBackground;
            this.lb_ScoreToBeat.Location = new System.Drawing.Point(33, 578);
            this.lb_ScoreToBeat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ScoreToBeat.Name = "lb_ScoreToBeat";
            this.lb_ScoreToBeat.Size = new System.Drawing.Size(179, 31);
            this.lb_ScoreToBeat.TabIndex = 33;
            this.lb_ScoreToBeat.Text = "score to beat!";
            // 
            // lb_FastestTime
            // 
            this.lb_FastestTime.AutoSize = true;
            this.lb_FastestTime.BackColor = System.Drawing.SystemColors.Control;
            this.lb_FastestTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_FastestTime.ForeColor = System.Drawing.Color.DarkRed;
            this.lb_FastestTime.Image = global::PROG7312_POE_PART1.Properties.Resources.labelBackground;
            this.lb_FastestTime.Location = new System.Drawing.Point(280, 578);
            this.lb_FastestTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_FastestTime.Name = "lb_FastestTime";
            this.lb_FastestTime.Size = new System.Drawing.Size(104, 31);
            this.lb_FastestTime.TabIndex = 32;
            this.lb_FastestTime.Text = "000000";
            // 
            // lb_GameTime
            // 
            this.lb_GameTime.AutoSize = true;
            this.lb_GameTime.BackColor = System.Drawing.SystemColors.Control;
            this.lb_GameTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_GameTime.ForeColor = System.Drawing.Color.DarkRed;
            this.lb_GameTime.Image = global::PROG7312_POE_PART1.Properties.Resources.labelBackground;
            this.lb_GameTime.Location = new System.Drawing.Point(1133, 22);
            this.lb_GameTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_GameTime.Name = "lb_GameTime";
            this.lb_GameTime.Size = new System.Drawing.Size(120, 31);
            this.lb_GameTime.TabIndex = 31;
            this.lb_GameTime.Text = "00:00:00";
            // 
            // pb_GameProgression
            // 
            this.pb_GameProgression.Location = new System.Drawing.Point(41, 22);
            this.pb_GameProgression.Margin = new System.Windows.Forms.Padding(4);
            this.pb_GameProgression.Name = "pb_GameProgression";
            this.pb_GameProgression.Size = new System.Drawing.Size(956, 31);
            this.pb_GameProgression.TabIndex = 30;
            // 
            // pnlDescription6
            // 
            this.pnlDescription6.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlDescription6.Controls.Add(this.label10);
            this.pnlDescription6.Location = new System.Drawing.Point(643, 431);
            this.pnlDescription6.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDescription6.Name = "pnlDescription6";
            this.pnlDescription6.Size = new System.Drawing.Size(299, 60);
            this.pnlDescription6.TabIndex = 43;
            this.pnlDescription6.Tag = "answer";
            this.pnlDescription6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.descriptionPanel_MouseDown);
            this.pnlDescription6.MouseHover += new System.EventHandler(this.btn_MatchingGame_MouseHover);
            this.pnlDescription6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.descriptionPanel_MouseMove);
            this.pnlDescription6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.descriptionPanel_MouseUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(16, 18);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 32);
            this.label10.TabIndex = 1;
            this.label10.Text = "label10";
            // 
            // pnlDescription2
            // 
            this.pnlDescription2.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlDescription2.Controls.Add(this.label6);
            this.pnlDescription2.Location = new System.Drawing.Point(643, 161);
            this.pnlDescription2.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDescription2.Name = "pnlDescription2";
            this.pnlDescription2.Size = new System.Drawing.Size(299, 60);
            this.pnlDescription2.TabIndex = 43;
            this.pnlDescription2.Tag = "answer";
            this.pnlDescription2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.descriptionPanel_MouseDown);
            this.pnlDescription2.MouseHover += new System.EventHandler(this.btn_MatchingGame_MouseHover);
            this.pnlDescription2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.descriptionPanel_MouseMove);
            this.pnlDescription2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.descriptionPanel_MouseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(16, 13);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 32);
            this.label6.TabIndex = 1;
            this.label6.Text = "label6";
            // 
            // pnlDescription4
            // 
            this.pnlDescription4.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlDescription4.Controls.Add(this.label8);
            this.pnlDescription4.Location = new System.Drawing.Point(643, 295);
            this.pnlDescription4.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDescription4.Name = "pnlDescription4";
            this.pnlDescription4.Size = new System.Drawing.Size(299, 60);
            this.pnlDescription4.TabIndex = 43;
            this.pnlDescription4.Tag = "answer";
            this.pnlDescription4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.descriptionPanel_MouseDown);
            this.pnlDescription4.MouseHover += new System.EventHandler(this.btn_MatchingGame_MouseHover);
            this.pnlDescription4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.descriptionPanel_MouseMove);
            this.pnlDescription4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.descriptionPanel_MouseUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(16, 11);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 32);
            this.label8.TabIndex = 1;
            this.label8.Text = "label8";
            // 
            // pnlDescription3
            // 
            this.pnlDescription3.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlDescription3.Controls.Add(this.label7);
            this.pnlDescription3.Location = new System.Drawing.Point(643, 228);
            this.pnlDescription3.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDescription3.Name = "pnlDescription3";
            this.pnlDescription3.Size = new System.Drawing.Size(299, 60);
            this.pnlDescription3.TabIndex = 43;
            this.pnlDescription3.Tag = "answer";
            this.pnlDescription3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.descriptionPanel_MouseDown);
            this.pnlDescription3.MouseHover += new System.EventHandler(this.btn_MatchingGame_MouseHover);
            this.pnlDescription3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.descriptionPanel_MouseMove);
            this.pnlDescription3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.descriptionPanel_MouseUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(16, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 32);
            this.label7.TabIndex = 1;
            this.label7.Text = "label7";
            // 
            // pnlDescription7
            // 
            this.pnlDescription7.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlDescription7.Controls.Add(this.label11);
            this.pnlDescription7.Location = new System.Drawing.Point(643, 498);
            this.pnlDescription7.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDescription7.Name = "pnlDescription7";
            this.pnlDescription7.Size = new System.Drawing.Size(299, 60);
            this.pnlDescription7.TabIndex = 43;
            this.pnlDescription7.Tag = "answer";
            this.pnlDescription7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.descriptionPanel_MouseDown);
            this.pnlDescription7.MouseHover += new System.EventHandler(this.btn_MatchingGame_MouseHover);
            this.pnlDescription7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.descriptionPanel_MouseMove);
            this.pnlDescription7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.descriptionPanel_MouseUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(16, 14);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 32);
            this.label11.TabIndex = 1;
            this.label11.Text = "label11";
            // 
            // pnlDescription5
            // 
            this.pnlDescription5.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlDescription5.Controls.Add(this.label9);
            this.pnlDescription5.Location = new System.Drawing.Point(643, 363);
            this.pnlDescription5.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDescription5.Name = "pnlDescription5";
            this.pnlDescription5.Size = new System.Drawing.Size(299, 60);
            this.pnlDescription5.TabIndex = 43;
            this.pnlDescription5.Tag = "answer";
            this.pnlDescription5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.descriptionPanel_MouseDown);
            this.pnlDescription5.MouseHover += new System.EventHandler(this.btn_MatchingGame_MouseHover);
            this.pnlDescription5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.descriptionPanel_MouseMove);
            this.pnlDescription5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.descriptionPanel_MouseUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(16, 17);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 32);
            this.label9.TabIndex = 1;
            this.label9.Text = "label9";
            // 
            // pnlDescription1
            // 
            this.pnlDescription1.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlDescription1.Controls.Add(this.label5);
            this.pnlDescription1.Location = new System.Drawing.Point(643, 94);
            this.pnlDescription1.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDescription1.Name = "pnlDescription1";
            this.pnlDescription1.Size = new System.Drawing.Size(299, 60);
            this.pnlDescription1.TabIndex = 43;
            this.pnlDescription1.Tag = "answer";
            this.pnlDescription1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.descriptionPanel_MouseDown);
            this.pnlDescription1.MouseHover += new System.EventHandler(this.btn_MatchingGame_MouseHover);
            this.pnlDescription1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.descriptionPanel_MouseMove);
            this.pnlDescription1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.descriptionPanel_MouseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(15, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 32);
            this.label5.TabIndex = 1;
            this.label5.Text = "label5";
            // 
            // pnlQuestion3
            // 
            this.pnlQuestion3.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlQuestion3.Controls.Add(this.label3);
            this.pnlQuestion3.Location = new System.Drawing.Point(41, 363);
            this.pnlQuestion3.Margin = new System.Windows.Forms.Padding(4);
            this.pnlQuestion3.Name = "pnlQuestion3";
            this.pnlQuestion3.Size = new System.Drawing.Size(296, 60);
            this.pnlQuestion3.TabIndex = 44;
            this.pnlQuestion3.Tag = "target";
            this.pnlQuestion3.MouseHover += new System.EventHandler(this.btn_MatchingGame_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 32);
            this.label3.TabIndex = 1;
            this.label3.Text = "label3";
            // 
            // pnlQuestion2
            // 
            this.pnlQuestion2.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlQuestion2.Controls.Add(this.label2);
            this.pnlQuestion2.Location = new System.Drawing.Point(41, 228);
            this.pnlQuestion2.Margin = new System.Windows.Forms.Padding(4);
            this.pnlQuestion2.Name = "pnlQuestion2";
            this.pnlQuestion2.Size = new System.Drawing.Size(296, 60);
            this.pnlQuestion2.TabIndex = 45;
            this.pnlQuestion2.Tag = "target";
            this.pnlQuestion2.MouseHover += new System.EventHandler(this.btn_MatchingGame_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // pnlQuestion1
            // 
            this.pnlQuestion1.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlQuestion1.Controls.Add(this.label1);
            this.pnlQuestion1.Location = new System.Drawing.Point(41, 94);
            this.pnlQuestion1.Margin = new System.Windows.Forms.Padding(4);
            this.pnlQuestion1.Name = "pnlQuestion1";
            this.pnlQuestion1.Size = new System.Drawing.Size(296, 60);
            this.pnlQuestion1.TabIndex = 46;
            this.pnlQuestion1.Tag = "target";
            this.pnlQuestion1.MouseHover += new System.EventHandler(this.btn_MatchingGame_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // pnlQuestion4
            // 
            this.pnlQuestion4.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlQuestion4.Controls.Add(this.label4);
            this.pnlQuestion4.Location = new System.Drawing.Point(39, 498);
            this.pnlQuestion4.Margin = new System.Windows.Forms.Padding(4);
            this.pnlQuestion4.Name = "pnlQuestion4";
            this.pnlQuestion4.Size = new System.Drawing.Size(298, 60);
            this.pnlQuestion4.TabIndex = 47;
            this.pnlQuestion4.Tag = "target";
            this.pnlQuestion4.MouseHover += new System.EventHandler(this.btn_MatchingGame_MouseHover);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(21, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 32);
            this.label4.TabIndex = 1;
            this.label4.Text = "label4";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // matchingGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PROG7312_POE_PART1.Properties.Resources.orderGameBackground;
            this.Controls.Add(this.pnlQuestion4);
            this.Controls.Add(this.pnlQuestion3);
            this.Controls.Add(this.pnlDescription4);
            this.Controls.Add(this.pnlQuestion2);
            this.Controls.Add(this.pnlDescription7);
            this.Controls.Add(this.pnlQuestion1);
            this.Controls.Add(this.pnlDescription5);
            this.Controls.Add(this.pnlDescription3);
            this.Controls.Add(this.pnlDescription2);
            this.Controls.Add(this.pnlDescription1);
            this.Controls.Add(this.pnlDescription6);
            this.Controls.Add(this.btn_StartGame);
            this.Controls.Add(this.btn_OrderGame);
            this.Controls.Add(this.lb_ScoreToBeat);
            this.Controls.Add(this.lb_FastestTime);
            this.Controls.Add(this.lb_GameTime);
            this.Controls.Add(this.pb_GameProgression);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1335, 631);
            this.MinimumSize = new System.Drawing.Size(1335, 631);
            this.Name = "matchingGame";
            this.Size = new System.Drawing.Size(1335, 631);
            this.pnlDescription6.ResumeLayout(false);
            this.pnlDescription6.PerformLayout();
            this.pnlDescription2.ResumeLayout(false);
            this.pnlDescription2.PerformLayout();
            this.pnlDescription4.ResumeLayout(false);
            this.pnlDescription4.PerformLayout();
            this.pnlDescription3.ResumeLayout(false);
            this.pnlDescription3.PerformLayout();
            this.pnlDescription7.ResumeLayout(false);
            this.pnlDescription7.PerformLayout();
            this.pnlDescription5.ResumeLayout(false);
            this.pnlDescription5.PerformLayout();
            this.pnlDescription1.ResumeLayout(false);
            this.pnlDescription1.PerformLayout();
            this.pnlQuestion3.ResumeLayout(false);
            this.pnlQuestion3.PerformLayout();
            this.pnlQuestion2.ResumeLayout(false);
            this.pnlQuestion2.PerformLayout();
            this.pnlQuestion1.ResumeLayout(false);
            this.pnlQuestion1.PerformLayout();
            this.pnlQuestion4.ResumeLayout(false);
            this.pnlQuestion4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_StartGame;
        private System.Windows.Forms.Button btn_OrderGame;
        private System.Windows.Forms.Label lb_ScoreToBeat;
        private System.Windows.Forms.Label lb_FastestTime;
        private System.Windows.Forms.Label lb_GameTime;
        private System.Windows.Forms.ProgressBar pb_GameProgression;
        private System.Windows.Forms.Panel pnlDescription6;
        private System.Windows.Forms.Panel pnlDescription2;
        private System.Windows.Forms.Panel pnlDescription4;
        private System.Windows.Forms.Panel pnlDescription3;
        private System.Windows.Forms.Panel pnlDescription7;
        private System.Windows.Forms.Panel pnlDescription5;
        private System.Windows.Forms.Panel pnlDescription1;
        private System.Windows.Forms.Panel pnlQuestion3;
        private System.Windows.Forms.Panel pnlQuestion2;
        private System.Windows.Forms.Panel pnlQuestion1;
        private System.Windows.Forms.Panel pnlQuestion4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
    }
}
