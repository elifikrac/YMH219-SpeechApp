namespace SpeechApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            statusTimer = new System.Windows.Forms.Timer(components);
            lblActive = new System.Windows.Forms.Label();
            lblTtsTitle = new System.Windows.Forms.Label();
            txtTts = new System.Windows.Forms.TextBox();
            btnSpeak = new System.Windows.Forms.Button();
            btnPause = new System.Windows.Forms.Button();
            btnStop = new System.Windows.Forms.Button();
            btnClearTts = new System.Windows.Forms.Button();
            lblTtsStatus = new System.Windows.Forms.Label();
            lblSttTitle = new System.Windows.Forms.Label();
            txtStt = new System.Windows.Forms.TextBox();
            btnListen = new System.Windows.Forms.Button();
            btnStopListen = new System.Windows.Forms.Button();
            btnClearStt = new System.Windows.Forms.Button();
            lblSttStatus = new System.Windows.Forms.Label();
            SuspendLayout();
            //
            // lblActive
            //
            lblActive.BackColor = System.Drawing.Color.DimGray;
            lblActive.ForeColor = System.Drawing.Color.White;
            lblActive.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblActive.Location = new System.Drawing.Point(12, 12);
            lblActive.Name = "lblActive";
            lblActive.Size = new System.Drawing.Size(676, 32);
            lblActive.Text = "Aktif işlem: Yok";
            //
            // lblTtsTitle
            //
            lblTtsTitle.AutoSize = true;
            lblTtsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblTtsTitle.Location = new System.Drawing.Point(12, 58);
            lblTtsTitle.Name = "lblTtsTitle";
            lblTtsTitle.Text = "METİN OKUMA (Text-to-Speech)";
            //
            // txtTts
            //
            txtTts.Multiline = true;
            txtTts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtTts.Location = new System.Drawing.Point(12, 82);
            txtTts.Name = "txtTts";
            txtTts.Size = new System.Drawing.Size(676, 110);
            txtTts.TabIndex = 2;
            txtTts.Text = "Merhaba, bu metin Text-to-Speech ile okunmaktadır.";
            //
            // btnSpeak
            //
            btnSpeak.Location = new System.Drawing.Point(12, 200);
            btnSpeak.Name = "btnSpeak";
            btnSpeak.Size = new System.Drawing.Size(120, 32);
            btnSpeak.TabIndex = 3;
            btnSpeak.Text = "Oku (Başlat)";
            btnSpeak.UseVisualStyleBackColor = true;
            btnSpeak.Click += new System.EventHandler(btnSpeak_Click);
            //
            // btnPause
            //
            btnPause.Location = new System.Drawing.Point(138, 200);
            btnPause.Name = "btnPause";
            btnPause.Size = new System.Drawing.Size(120, 32);
            btnPause.TabIndex = 4;
            btnPause.Text = "Duraklat";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += new System.EventHandler(btnPause_Click);
            //
            // btnStop
            //
            btnStop.Location = new System.Drawing.Point(264, 200);
            btnStop.Name = "btnStop";
            btnStop.Size = new System.Drawing.Size(120, 32);
            btnStop.TabIndex = 5;
            btnStop.Text = "Durdur";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += new System.EventHandler(btnStop_Click);
            //
            // btnClearTts
            //
            btnClearTts.Location = new System.Drawing.Point(390, 200);
            btnClearTts.Name = "btnClearTts";
            btnClearTts.Size = new System.Drawing.Size(120, 32);
            btnClearTts.TabIndex = 6;
            btnClearTts.Text = "Temizle";
            btnClearTts.UseVisualStyleBackColor = true;
            btnClearTts.Click += new System.EventHandler(btnClearTts_Click);
            //
            // lblTtsStatus
            //
            lblTtsStatus.AutoSize = true;
            lblTtsStatus.Location = new System.Drawing.Point(520, 208);
            lblTtsStatus.Name = "lblTtsStatus";
            lblTtsStatus.Text = "Okuma: Beklemede";
            //
            // lblSttTitle
            //
            lblSttTitle.AutoSize = true;
            lblSttTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblSttTitle.Location = new System.Drawing.Point(12, 258);
            lblSttTitle.Name = "lblSttTitle";
            lblSttTitle.Text = "KONUŞMA TANIMA (Speech-to-Text)";
            //
            // txtStt
            //
            txtStt.Multiline = true;
            txtStt.ReadOnly = true;
            txtStt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtStt.BackColor = System.Drawing.Color.White;
            txtStt.Location = new System.Drawing.Point(12, 282);
            txtStt.Name = "txtStt";
            txtStt.Size = new System.Drawing.Size(676, 190);
            txtStt.TabIndex = 9;
            //
            // btnListen
            //
            btnListen.Location = new System.Drawing.Point(12, 482);
            btnListen.Name = "btnListen";
            btnListen.Size = new System.Drawing.Size(150, 32);
            btnListen.TabIndex = 10;
            btnListen.Text = "Dinlemeyi Başlat";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += new System.EventHandler(btnListen_Click);
            //
            // btnStopListen
            //
            btnStopListen.Location = new System.Drawing.Point(168, 482);
            btnStopListen.Name = "btnStopListen";
            btnStopListen.Size = new System.Drawing.Size(150, 32);
            btnStopListen.TabIndex = 11;
            btnStopListen.Text = "Dinlemeyi Durdur";
            btnStopListen.UseVisualStyleBackColor = true;
            btnStopListen.Click += new System.EventHandler(btnStopListen_Click);
            //
            // btnClearStt
            //
            btnClearStt.Location = new System.Drawing.Point(324, 482);
            btnClearStt.Name = "btnClearStt";
            btnClearStt.Size = new System.Drawing.Size(120, 32);
            btnClearStt.TabIndex = 12;
            btnClearStt.Text = "Temizle";
            btnClearStt.UseVisualStyleBackColor = true;
            btnClearStt.Click += new System.EventHandler(btnClearStt_Click);
            //
            // lblSttStatus
            //
            lblSttStatus.AutoSize = true;
            lblSttStatus.Location = new System.Drawing.Point(455, 490);
            lblSttStatus.Name = "lblSttStatus";
            lblSttStatus.Text = "Tanıma: Beklemede";
            //
            // statusTimer
            //
            statusTimer.Interval = 200;
            statusTimer.Tick += new System.EventHandler(statusTimer_Tick);
            //
            // Form1
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(700, 540);
            Controls.Add(lblActive);
            Controls.Add(lblTtsTitle);
            Controls.Add(txtTts);
            Controls.Add(btnSpeak);
            Controls.Add(btnPause);
            Controls.Add(btnStop);
            Controls.Add(btnClearTts);
            Controls.Add(lblTtsStatus);
            Controls.Add(lblSttTitle);
            Controls.Add(txtStt);
            Controls.Add(btnListen);
            Controls.Add(btnStopListen);
            Controls.Add(btnClearStt);
            Controls.Add(lblSttStatus);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "YMH219 - Speech-to-Text / Text-to-Speech";
            FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form1_FormClosing);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.Label lblTtsTitle;
        private System.Windows.Forms.TextBox txtTts;
        private System.Windows.Forms.Button btnSpeak;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnClearTts;
        private System.Windows.Forms.Label lblTtsStatus;
        private System.Windows.Forms.Label lblSttTitle;
        private System.Windows.Forms.TextBox txtStt;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.Button btnStopListen;
        private System.Windows.Forms.Button btnClearStt;
        private System.Windows.Forms.Label lblSttStatus;
        private System.Windows.Forms.Timer statusTimer;
    }
}