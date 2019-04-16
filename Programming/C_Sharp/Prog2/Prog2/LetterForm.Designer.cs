namespace Prog2
{
    partial class LetterForm
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
            this.components = new System.ComponentModel.Container();
            this.originAddressComboBox = new System.Windows.Forms.ComboBox();
            this.destAddressComboBox = new System.Windows.Forms.ComboBox();
            this.fixedCostTextBox = new System.Windows.Forms.TextBox();
            this.originAddressLabel = new System.Windows.Forms.Label();
            this.destAddressLabel = new System.Windows.Forms.Label();
            this.fixedCostLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.LetterErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LetterErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // originAddressComboBox
            // 
            this.originAddressComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.originAddressComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.originAddressComboBox.FormattingEnabled = true;
            this.originAddressComboBox.Location = new System.Drawing.Point(125, 22);
            this.originAddressComboBox.Name = "originAddressComboBox";
            this.originAddressComboBox.Size = new System.Drawing.Size(100, 21);
            this.originAddressComboBox.TabIndex = 5;
            this.originAddressComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.InputFeild_Validating);
            this.originAddressComboBox.Validated += new System.EventHandler(this.InputFeild_Validated);
            // 
            // destAddressComboBox
            // 
            this.destAddressComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destAddressComboBox.FormattingEnabled = true;
            this.destAddressComboBox.Location = new System.Drawing.Point(125, 49);
            this.destAddressComboBox.Name = "destAddressComboBox";
            this.destAddressComboBox.Size = new System.Drawing.Size(100, 21);
            this.destAddressComboBox.TabIndex = 6;
            this.destAddressComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.InputFeild_Validating);
            this.destAddressComboBox.Validated += new System.EventHandler(this.InputFeild_Validated);
            // 
            // fixedCostTextBox
            // 
            this.fixedCostTextBox.Location = new System.Drawing.Point(125, 77);
            this.fixedCostTextBox.Name = "fixedCostTextBox";
            this.fixedCostTextBox.Size = new System.Drawing.Size(100, 20);
            this.fixedCostTextBox.TabIndex = 7;
            this.fixedCostTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.InputFeild_Validating);
            this.fixedCostTextBox.Validated += new System.EventHandler(this.InputFeild_Validated);
            // 
            // originAddressLabel
            // 
            this.originAddressLabel.AutoSize = true;
            this.originAddressLabel.Location = new System.Drawing.Point(44, 25);
            this.originAddressLabel.Name = "originAddressLabel";
            this.originAddressLabel.Size = new System.Drawing.Size(75, 13);
            this.originAddressLabel.TabIndex = 8;
            this.originAddressLabel.Text = "Origin Address";
            // 
            // destAddressLabel
            // 
            this.destAddressLabel.AutoSize = true;
            this.destAddressLabel.Location = new System.Drawing.Point(18, 52);
            this.destAddressLabel.Name = "destAddressLabel";
            this.destAddressLabel.Size = new System.Drawing.Size(101, 13);
            this.destAddressLabel.TabIndex = 9;
            this.destAddressLabel.Text = "Destination Address";
            // 
            // fixedCostLabel
            // 
            this.fixedCostLabel.AutoSize = true;
            this.fixedCostLabel.Location = new System.Drawing.Point(63, 80);
            this.fixedCostLabel.Name = "fixedCostLabel";
            this.fixedCostLabel.Size = new System.Drawing.Size(56, 13);
            this.fixedCostLabel.TabIndex = 10;
            this.fixedCostLabel.Text = "Fixed Cost";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(76, 120);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 11;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(169, 119);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click_1);
            // 
            // LetterErrorProvider
            // 
            this.LetterErrorProvider.ContainerControl = this;
            // 
            // LetterForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 164);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.fixedCostLabel);
            this.Controls.Add(this.destAddressLabel);
            this.Controls.Add(this.originAddressLabel);
            this.Controls.Add(this.fixedCostTextBox);
            this.Controls.Add(this.destAddressComboBox);
            this.Controls.Add(this.originAddressComboBox);
            this.Name = "LetterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LetterForm";
            this.Load += new System.EventHandler(this.LetterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LetterErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox originAddressComboBox;
        private System.Windows.Forms.ComboBox destAddressComboBox;
        private System.Windows.Forms.TextBox fixedCostTextBox;
        private System.Windows.Forms.Label originAddressLabel;
        private System.Windows.Forms.Label destAddressLabel;
        private System.Windows.Forms.Label fixedCostLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ErrorProvider LetterErrorProvider;
    }
}