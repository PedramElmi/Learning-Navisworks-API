
namespace LearningNavisworksAPI.AddinDockPane
{
    partial class UCUpdate
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
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.CheckBoxAutoUpdate = new System.Windows.Forms.CheckBox();
            this.CheckBoxPause = new System.Windows.Forms.CheckBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.ButtonClearLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonUpdate.Enabled = false;
            this.ButtonUpdate.Location = new System.Drawing.Point(0, 0);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(185, 23);
            this.ButtonUpdate.TabIndex = 0;
            this.ButtonUpdate.Text = "Update";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonUpdate_MouseUp);
            // 
            // CheckBoxAutoUpdate
            // 
            this.CheckBoxAutoUpdate.AutoSize = true;
            this.CheckBoxAutoUpdate.Location = new System.Drawing.Point(3, 35);
            this.CheckBoxAutoUpdate.Name = "CheckBoxAutoUpdate";
            this.CheckBoxAutoUpdate.Size = new System.Drawing.Size(86, 17);
            this.CheckBoxAutoUpdate.TabIndex = 1;
            this.CheckBoxAutoUpdate.Text = "Auto Update";
            this.CheckBoxAutoUpdate.UseVisualStyleBackColor = true;
            // 
            // CheckBoxPause
            // 
            this.CheckBoxPause.AutoSize = true;
            this.CheckBoxPause.Location = new System.Drawing.Point(3, 58);
            this.CheckBoxPause.Name = "CheckBoxPause";
            this.CheckBoxPause.Size = new System.Drawing.Size(56, 17);
            this.CheckBoxPause.TabIndex = 2;
            this.CheckBoxPause.Text = "Pause";
            this.CheckBoxPause.UseVisualStyleBackColor = true;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxLog.Location = new System.Drawing.Point(0, 107);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(185, 191);
            this.textBoxLog.TabIndex = 3;
            this.textBoxLog.Text = "Monitoring Models...";
            // 
            // ButtonClearLog
            // 
            this.ButtonClearLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonClearLog.Location = new System.Drawing.Point(0, 84);
            this.ButtonClearLog.Name = "ButtonClearLog";
            this.ButtonClearLog.Size = new System.Drawing.Size(185, 23);
            this.ButtonClearLog.TabIndex = 4;
            this.ButtonClearLog.Text = "Clear Log";
            this.ButtonClearLog.UseVisualStyleBackColor = true;
            // 
            // UCUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ButtonClearLog);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.CheckBoxPause);
            this.Controls.Add(this.CheckBoxAutoUpdate);
            this.Controls.Add(this.ButtonUpdate);
            this.Name = "UCUpdate";
            this.Size = new System.Drawing.Size(185, 298);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonUpdate;
        private System.Windows.Forms.CheckBox CheckBoxAutoUpdate;
        private System.Windows.Forms.CheckBox CheckBoxPause;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button ButtonClearLog;
    }
}
