namespace RedisApplication
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.featureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonSetValue = new System.Windows.Forms.Button();
            this.buttonClearValue = new System.Windows.Forms.Button();
            this.textBoxSetValue = new System.Windows.Forms.TextBox();
            this.textBoxSetKey = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.featureToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.toolStripSeparator1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.connectToolStripMenuItem.Text = "Connect";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // featureToolStripMenuItem
            // 
            this.featureToolStripMenuItem.Name = "featureToolStripMenuItem";
            this.featureToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.featureToolStripMenuItem.Text = "Feature";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.textBoxSetValue);
            this.groupBox1.Controls.Add(this.textBoxSetKey);
            this.groupBox1.Location = new System.Drawing.Point(13, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 142);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Value";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonSetValue);
            this.groupBox2.Controls.Add(this.buttonClearValue);
            this.groupBox2.Location = new System.Drawing.Point(62, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 77);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action";
            // 
            // buttonSetValue
            // 
            this.buttonSetValue.Location = new System.Drawing.Point(6, 21);
            this.buttonSetValue.Name = "buttonSetValue";
            this.buttonSetValue.Size = new System.Drawing.Size(113, 43);
            this.buttonSetValue.TabIndex = 2;
            this.buttonSetValue.Text = "Execute";
            this.buttonSetValue.UseVisualStyleBackColor = true;
            this.buttonSetValue.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonClearValue
            // 
            this.buttonClearValue.Location = new System.Drawing.Point(125, 21);
            this.buttonClearValue.Name = "buttonClearValue";
            this.buttonClearValue.Size = new System.Drawing.Size(113, 43);
            this.buttonClearValue.TabIndex = 3;
            this.buttonClearValue.Text = "Clear";
            this.buttonClearValue.UseVisualStyleBackColor = true;
            this.buttonClearValue.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxSetValue
            // 
            this.textBoxSetValue.Location = new System.Drawing.Point(200, 22);
            this.textBoxSetValue.Name = "textBoxSetValue";
            this.textBoxSetValue.Size = new System.Drawing.Size(187, 22);
            this.textBoxSetValue.TabIndex = 1;
            this.textBoxSetValue.Text = "<Value>";
            // 
            // textBoxSetKey
            // 
            this.textBoxSetKey.Location = new System.Drawing.Point(7, 22);
            this.textBoxSetKey.Name = "textBoxSetKey";
            this.textBoxSetKey.Size = new System.Drawing.Size(187, 22);
            this.textBoxSetKey.TabIndex = 0;
            this.textBoxSetKey.Text = "<Key>";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Remote Dictionary Server (Redis)";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem featureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSetValue;
        private System.Windows.Forms.Button buttonClearValue;
        private System.Windows.Forms.TextBox textBoxSetValue;
        private System.Windows.Forms.TextBox textBoxSetKey;
    }
}

