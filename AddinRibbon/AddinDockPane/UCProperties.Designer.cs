
namespace LearningNavisworksAPI.AddinDockPane
{
    partial class UCProperties
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCategoryName = new System.Windows.Forms.TextBox();
            this.textBoxPropertyName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPropertyValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonFind = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelCountResult = new System.Windows.Forms.Label();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.checkBoxPause = new System.Windows.Forms.CheckBox();
            this.buttonCreateSavedSet = new System.Windows.Forms.Button();
            this.buttonCreateSavedSearch = new System.Windows.Forms.Button();
            this.buttonSaveXmlData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Category Name:";
            // 
            // textBoxCategoryName
            // 
            this.textBoxCategoryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCategoryName.Location = new System.Drawing.Point(92, 8);
            this.textBoxCategoryName.Name = "textBoxCategoryName";
            this.textBoxCategoryName.Size = new System.Drawing.Size(191, 20);
            this.textBoxCategoryName.TabIndex = 2;
            // 
            // textBoxPropertyName
            // 
            this.textBoxPropertyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPropertyName.Location = new System.Drawing.Point(92, 34);
            this.textBoxPropertyName.Name = "textBoxPropertyName";
            this.textBoxPropertyName.Size = new System.Drawing.Size(191, 20);
            this.textBoxPropertyName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Property Name:";
            // 
            // textBoxPropertyValue
            // 
            this.textBoxPropertyValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPropertyValue.Location = new System.Drawing.Point(92, 60);
            this.textBoxPropertyValue.Name = "textBoxPropertyValue";
            this.textBoxPropertyValue.Size = new System.Drawing.Size(191, 20);
            this.textBoxPropertyValue.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Property Value:";
            // 
            // buttonFind
            // 
            this.buttonFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFind.Location = new System.Drawing.Point(92, 86);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(191, 23);
            this.buttonFind.TabIndex = 7;
            this.buttonFind.Text = "Find";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Count";
            // 
            // labelCountResult
            // 
            this.labelCountResult.AutoSize = true;
            this.labelCountResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCountResult.Location = new System.Drawing.Point(49, 89);
            this.labelCountResult.Name = "labelCountResult";
            this.labelCountResult.Size = new System.Drawing.Size(23, 16);
            this.labelCountResult.TabIndex = 9;
            this.labelCountResult.Text = "---";
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutput.Location = new System.Drawing.Point(0, 210);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOutput.Size = new System.Drawing.Size(366, 355);
            this.textBoxOutput.TabIndex = 0;
            this.textBoxOutput.WordWrap = false;
            // 
            // checkBoxPause
            // 
            this.checkBoxPause.AutoSize = true;
            this.checkBoxPause.Checked = true;
            this.checkBoxPause.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPause.Location = new System.Drawing.Point(6, 187);
            this.checkBoxPause.Name = "checkBoxPause";
            this.checkBoxPause.Size = new System.Drawing.Size(56, 17);
            this.checkBoxPause.TabIndex = 10;
            this.checkBoxPause.Text = "Pause";
            this.checkBoxPause.UseVisualStyleBackColor = true;
            // 
            // buttonCreateSavedSet
            // 
            this.buttonCreateSavedSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateSavedSet.Location = new System.Drawing.Point(289, 8);
            this.buttonCreateSavedSet.Name = "buttonCreateSavedSet";
            this.buttonCreateSavedSet.Size = new System.Drawing.Size(74, 49);
            this.buttonCreateSavedSet.TabIndex = 11;
            this.buttonCreateSavedSet.Text = "Create Saved Set";
            this.buttonCreateSavedSet.UseVisualStyleBackColor = true;
            this.buttonCreateSavedSet.Click += new System.EventHandler(this.buttonCreateSavedSet_Click);
            // 
            // buttonCreateSavedSearch
            // 
            this.buttonCreateSavedSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateSavedSearch.Location = new System.Drawing.Point(289, 60);
            this.buttonCreateSavedSearch.Name = "buttonCreateSavedSearch";
            this.buttonCreateSavedSearch.Size = new System.Drawing.Size(74, 49);
            this.buttonCreateSavedSearch.TabIndex = 12;
            this.buttonCreateSavedSearch.Text = "Create Saved Search";
            this.buttonCreateSavedSearch.UseVisualStyleBackColor = true;
            this.buttonCreateSavedSearch.Click += new System.EventHandler(this.buttonCreateSavedSearch_Click);
            // 
            // buttonSaveXmlData
            // 
            this.buttonSaveXmlData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveXmlData.Location = new System.Drawing.Point(273, 127);
            this.buttonSaveXmlData.Name = "buttonSaveXmlData";
            this.buttonSaveXmlData.Size = new System.Drawing.Size(90, 77);
            this.buttonSaveXmlData.TabIndex = 13;
            this.buttonSaveXmlData.Text = "Save Xml Data (On Test)";
            this.buttonSaveXmlData.UseVisualStyleBackColor = true;
            this.buttonSaveXmlData.Click += new System.EventHandler(this.buttonSaveXmlData_Click);
            // 
            // UCProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.buttonSaveXmlData);
            this.Controls.Add(this.buttonCreateSavedSearch);
            this.Controls.Add(this.buttonCreateSavedSet);
            this.Controls.Add(this.checkBoxPause);
            this.Controls.Add(this.labelCountResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.textBoxPropertyValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPropertyName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCategoryName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxOutput);
            this.Name = "UCProperties";
            this.Size = new System.Drawing.Size(366, 565);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCategoryName;
        private System.Windows.Forms.TextBox textBoxPropertyName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPropertyValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelCountResult;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.CheckBox checkBoxPause;
        private System.Windows.Forms.Button buttonCreateSavedSet;
        private System.Windows.Forms.Button buttonCreateSavedSearch;
        private System.Windows.Forms.Button buttonSaveXmlData;
    }
}
