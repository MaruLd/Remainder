
namespace Reminder
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numSecond = new System.Windows.Forms.NumericUpDown();
            this.numMinute = new System.Windows.Forms.NumericUpDown();
            this.numHour = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveMsg = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.songPlayingLabel = new System.Windows.Forms.Label();
            this.btnPlaySong = new System.Windows.Forms.Button();
            this.btnStopSong = new System.Windows.Forms.Button();
            this.numLoop = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRemind = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.setupModesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remindToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excerciseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoop)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.ForestGreen;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStart.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.Black;
            this.btnStart.Location = new System.Drawing.Point(7, 168);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(55, 24);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 218);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(184, 53);
            this.textBox1.TabIndex = 1;
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Sylfaen", 36F);
            this.TimeLabel.Location = new System.Drawing.Point(47, 56);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(195, 62);
            this.TimeLabel.TabIndex = 3;
            this.TimeLabel.Text = "00:00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.Location = new System.Drawing.Point(69, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Minute";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.Location = new System.Drawing.Point(133, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Second";
            // 
            // numSecond
            // 
            this.numSecond.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.numSecond.Location = new System.Drawing.Point(134, 134);
            this.numSecond.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numSecond.Name = "numSecond";
            this.numSecond.Size = new System.Drawing.Size(55, 27);
            this.numSecond.TabIndex = 5;
            // 
            // numMinute
            // 
            this.numMinute.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.numMinute.Location = new System.Drawing.Point(69, 134);
            this.numMinute.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numMinute.Name = "numMinute";
            this.numMinute.Size = new System.Drawing.Size(55, 27);
            this.numMinute.TabIndex = 7;
            // 
            // numHour
            // 
            this.numHour.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.numHour.Location = new System.Drawing.Point(7, 134);
            this.numHour.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numHour.Name = "numHour";
            this.numHour.Size = new System.Drawing.Size(55, 27);
            this.numHour.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label3.Location = new System.Drawing.Point(7, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hour";
            // 
            // btnSaveMsg
            // 
            this.btnSaveMsg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveMsg.Location = new System.Drawing.Point(198, 246);
            this.btnSaveMsg.Name = "btnSaveMsg";
            this.btnSaveMsg.Size = new System.Drawing.Size(57, 24);
            this.btnSaveMsg.TabIndex = 13;
            this.btnSaveMsg.Text = "Save";
            this.btnSaveMsg.UseVisualStyleBackColor = true;
            this.btnSaveMsg.Click += new System.EventHandler(this.btnSaveMsg_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label4.Location = new System.Drawing.Point(8, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Message:";
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Location = new System.Drawing.Point(198, 218);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(57, 24);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSet
            // 
            this.btnSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSet.Location = new System.Drawing.Point(134, 168);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(55, 24);
            this.btnSet.TabIndex = 18;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStop.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnStop.Location = new System.Drawing.Point(69, 168);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(55, 24);
            this.btnStop.TabIndex = 15;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(8, 355);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(248, 21);
            this.comboBox1.TabIndex = 19; 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Goldenrod;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(136, 400);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(27, 24);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnSongChoose_Click);
            // 
            // songPlayingLabel
            // 
            this.songPlayingLabel.AutoSize = true;
            this.songPlayingLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.songPlayingLabel.Location = new System.Drawing.Point(7, 34);
            this.songPlayingLabel.Name = "songPlayingLabel";
            this.songPlayingLabel.Size = new System.Drawing.Size(68, 17);
            this.songPlayingLabel.TabIndex = 21;
            this.songPlayingLabel.Text = "[No Song]";
            // 
            // btnPlaySong
            // 
            this.btnPlaySong.BackColor = System.Drawing.Color.ForestGreen;
            this.btnPlaySong.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlaySong.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnPlaySong.ForeColor = System.Drawing.Color.Black;
            this.btnPlaySong.Location = new System.Drawing.Point(8, 400);
            this.btnPlaySong.Name = "btnPlaySong";
            this.btnPlaySong.Size = new System.Drawing.Size(55, 24);
            this.btnPlaySong.TabIndex = 22;
            this.btnPlaySong.Text = "Play";
            this.btnPlaySong.UseMnemonic = false;
            this.btnPlaySong.UseVisualStyleBackColor = false;
            this.btnPlaySong.Click += new System.EventHandler(this.btnPlaySong_Click);
            // 
            // btnStopSong
            // 
            this.btnStopSong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStopSong.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStopSong.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnStopSong.Location = new System.Drawing.Point(70, 400);
            this.btnStopSong.Name = "btnStopSong";
            this.btnStopSong.Size = new System.Drawing.Size(55, 24);
            this.btnStopSong.TabIndex = 23;
            this.btnStopSong.Text = "Stop";
            this.btnStopSong.UseVisualStyleBackColor = false;
            this.btnStopSong.Click += new System.EventHandler(this.btnStopSong_Click);
            // 
            // numLoop
            // 
            this.numLoop.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.numLoop.Location = new System.Drawing.Point(197, 133);
            this.numLoop.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numLoop.Name = "numLoop";
            this.numLoop.Size = new System.Drawing.Size(55, 27);
            this.numLoop.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label5.Location = new System.Drawing.Point(197, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "Loop";
            // 
            // btnRemind
            // 
            this.btnRemind.BackColor = System.Drawing.Color.White;
            this.btnRemind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemind.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnRemind.Location = new System.Drawing.Point(197, 168);
            this.btnRemind.Name = "btnRemind";
            this.btnRemind.Size = new System.Drawing.Size(55, 24);
            this.btnRemind.TabIndex = 26;
            this.btnRemind.Text = "Remind to stand";
            this.btnRemind.UseVisualStyleBackColor = false;
            this.btnRemind.Click += new System.EventHandler(this.btnRemind_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupModesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(262, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // setupModesToolStripMenuItem
            // 
            this.setupModesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remindToolStripMenuItem,
            this.relaxToolStripMenuItem,
            this.studyToolStripMenuItem,
            this.excerciseToolStripMenuItem});
            this.setupModesToolStripMenuItem.Name = "setupModesToolStripMenuItem";
            this.setupModesToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.setupModesToolStripMenuItem.Text = "Setup Modes";
            // 
            // remindToolStripMenuItem
            // 
            this.remindToolStripMenuItem.Name = "remindToolStripMenuItem";
            this.remindToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.remindToolStripMenuItem.Text = "Remind";
            // 
            // relaxToolStripMenuItem
            // 
            this.relaxToolStripMenuItem.Name = "relaxToolStripMenuItem";
            this.relaxToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.relaxToolStripMenuItem.Text = "Relax";
            // 
            // studyToolStripMenuItem
            // 
            this.studyToolStripMenuItem.Name = "studyToolStripMenuItem";
            this.studyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.studyToolStripMenuItem.Text = "Study";
            // 
            // excerciseToolStripMenuItem
            // 
            this.excerciseToolStripMenuItem.Name = "excerciseToolStripMenuItem";
            this.excerciseToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.excerciseToolStripMenuItem.Text = "Excercise";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 382);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(248, 10);
            this.progressBar1.TabIndex = 28;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(8, 280);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(247, 69);
            this.listBox1.TabIndex = 29;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Goldenrod;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemove.Font = new System.Drawing.Font("UD Digi Kyokasho NK-B", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRemove.Location = new System.Drawing.Point(169, 400);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(27, 24);
            this.btnRemove.TabIndex = 30;
            this.btnRemove.Text = "-";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(262, 431);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnRemind);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numLoop);
            this.Controls.Add(this.btnStopSong);
            this.Controls.Add(this.btnPlaySong);
            this.Controls.Add(this.songPlayingLabel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSaveMsg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numHour);
            this.Controls.Add(this.numMinute);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numSecond);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Reminder";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLoop)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numSecond;
        private System.Windows.Forms.NumericUpDown numMinute;
        private System.Windows.Forms.NumericUpDown numHour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveMsg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label songPlaying;
        private System.Windows.Forms.Button btnPlaySong;
        private System.Windows.Forms.Button btnStopSong;
        private System.Windows.Forms.Label songPlayingLabel;
        private System.Windows.Forms.NumericUpDown numLoop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRemind;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setupModesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remindToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excerciseToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnRemove;
    }
}

