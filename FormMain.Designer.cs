namespace eventBit.Apps.Example.AttendeeSSOToken
{
    partial class FormMain
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
            if ( disposing && (components != null) )
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBoxReadme = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.v1ProtocolControl1 = new eventBit.Apps.Example.AttendeeSSOToken.v1ProtocolControl();
            this.textBoxHelp = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.textBoxHelp);
            this.splitContainer2.Size = new System.Drawing.Size(909, 580);
            this.splitContainer2.SplitterDistance = 485;
            this.splitContainer2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(909, 485);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxReadme);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(901, 459);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Introduction";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBoxReadme
            // 
            this.textBoxReadme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxReadme.Location = new System.Drawing.Point(3, 3);
            this.textBoxReadme.Multiline = true;
            this.textBoxReadme.Name = "textBoxReadme";
            this.textBoxReadme.ReadOnly = true;
            this.textBoxReadme.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxReadme.Size = new System.Drawing.Size(895, 453);
            this.textBoxReadme.TabIndex = 0;
            this.textBoxReadme.Tag = "Displays the built-in project \"README\" file.";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.v1ProtocolControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(901, 459);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "v1 Protocol";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // v1ProtocolControl1
            // 
            this.v1ProtocolControl1.AutoScroll = true;
            this.v1ProtocolControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.v1ProtocolControl1.Location = new System.Drawing.Point(3, 3);
            this.v1ProtocolControl1.Name = "v1ProtocolControl1";
            this.v1ProtocolControl1.Size = new System.Drawing.Size(895, 453);
            this.v1ProtocolControl1.TabIndex = 0;
            // 
            // textBoxHelp
            // 
            this.textBoxHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxHelp.Location = new System.Drawing.Point(0, 0);
            this.textBoxHelp.Multiline = true;
            this.textBoxHelp.Name = "textBoxHelp";
            this.textBoxHelp.ReadOnly = true;
            this.textBoxHelp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxHelp.Size = new System.Drawing.Size(909, 91);
            this.textBoxHelp.TabIndex = 0;
            this.textBoxHelp.Text = "Select a textbox above to see an explanation here.";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 580);
            this.Controls.Add(this.splitContainer2);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormMain";
            this.Text = "eventBit Attendee SSO Token Example / Reference Implementation";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox textBoxHelp;
        private v1ProtocolControl v1ProtocolControl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxReadme;
    }
}

