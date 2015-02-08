namespace YomiganaBalloon
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.enableCtrl = new System.Windows.Forms.CheckBox();
            this.hotKeys = new System.Windows.Forms.ComboBox();
            this.enableAlt = new System.Windows.Forms.CheckBox();
            this.enableShift = new System.Windows.Forms.CheckBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.balloonSecondBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.copyright = new System.Windows.Forms.Label();
            this.contextMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.balloonSecondBox)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "YomiganaBalloon";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.終了ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(101, 26);
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.終了ToolStripMenuItem.Text = "終了";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.終了ToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.enableCtrl);
            this.groupBox1.Controls.Add(this.hotKeys);
            this.groupBox1.Controls.Add(this.enableAlt);
            this.groupBox1.Controls.Add(this.enableShift);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 47);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ホットキー";
            // 
            // enableCtrl
            // 
            this.enableCtrl.AutoSize = true;
            this.enableCtrl.Location = new System.Drawing.Point(15, 18);
            this.enableCtrl.Name = "enableCtrl";
            this.enableCtrl.Size = new System.Drawing.Size(43, 16);
            this.enableCtrl.TabIndex = 4;
            this.enableCtrl.Text = "Ctrl";
            this.enableCtrl.UseVisualStyleBackColor = true;
            // 
            // hotKeys
            // 
            this.hotKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hotKeys.FormattingEnabled = true;
            this.hotKeys.Location = new System.Drawing.Point(163, 16);
            this.hotKeys.Name = "hotKeys";
            this.hotKeys.Size = new System.Drawing.Size(110, 20);
            this.hotKeys.TabIndex = 3;
            // 
            // enableAlt
            // 
            this.enableAlt.AutoSize = true;
            this.enableAlt.Location = new System.Drawing.Point(118, 18);
            this.enableAlt.Name = "enableAlt";
            this.enableAlt.Size = new System.Drawing.Size(39, 16);
            this.enableAlt.TabIndex = 1;
            this.enableAlt.Text = "Alt";
            this.enableAlt.UseVisualStyleBackColor = true;
            // 
            // enableShift
            // 
            this.enableShift.AutoSize = true;
            this.enableShift.Location = new System.Drawing.Point(64, 18);
            this.enableShift.Name = "enableShift";
            this.enableShift.Size = new System.Drawing.Size(48, 16);
            this.enableShift.TabIndex = 0;
            this.enableShift.Text = "Shift";
            this.enableShift.UseVisualStyleBackColor = true;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(216, 113);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 2;
            this.applyButton.Text = "適用";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.balloonSecondBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 41);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "その他";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "秒";
            // 
            // balloonSecondBox
            // 
            this.balloonSecondBox.Location = new System.Drawing.Point(196, 15);
            this.balloonSecondBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.balloonSecondBox.Name = "balloonSecondBox";
            this.balloonSecondBox.Size = new System.Drawing.Size(53, 19);
            this.balloonSecondBox.TabIndex = 2;
            this.balloonSecondBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "バルーンの表示時間";
            // 
            // copyright
            // 
            this.copyright.AutoSize = true;
            this.copyright.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.copyright.ForeColor = System.Drawing.Color.DarkGray;
            this.copyright.Location = new System.Drawing.Point(14, 115);
            this.copyright.Name = "copyright";
            this.copyright.Size = new System.Drawing.Size(148, 22);
            this.copyright.TabIndex = 4;
            this.copyright.Text = "Copyright © 2015\r\nsnakazawa All Rights Reserved.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 146);
            this.Controls.Add(this.copyright);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "YomiganaBalloon";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.balloonSecondBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox enableAlt;
        private System.Windows.Forms.CheckBox enableShift;
        private System.Windows.Forms.CheckBox enableCtrl;
        private System.Windows.Forms.ComboBox hotKeys;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown balloonSecondBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label copyright;
    }
}

