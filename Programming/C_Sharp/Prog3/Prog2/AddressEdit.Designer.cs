namespace Prog2
{
    partial class AddressEditForm
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
            this.addressListView = new System.Windows.Forms.ListView();
            this.editButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.nameFilterLabel = new System.Windows.Forms.Label();
            this.filterTxt = new System.Windows.Forms.TextBox();
            this.radioBtnPanel = new System.Windows.Forms.Panel();
            this.addressRadioBtn = new System.Windows.Forms.RadioButton();
            this.zipRadioBtn = new System.Windows.Forms.RadioButton();
            this.stateRadioBtn = new System.Windows.Forms.RadioButton();
            this.nameRadioBtn = new System.Windows.Forms.RadioButton();
            this.cityRadioBtn = new System.Windows.Forms.RadioButton();
            this.radioBtnPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // addressListView
            // 
            this.addressListView.BackColor = System.Drawing.SystemColors.Window;
            this.addressListView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addressListView.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressListView.FullRowSelect = true;
            this.addressListView.GridLines = true;
            this.addressListView.Location = new System.Drawing.Point(0, 49);
            this.addressListView.Margin = new System.Windows.Forms.Padding(4);
            this.addressListView.MultiSelect = false;
            this.addressListView.Name = "addressListView";
            this.addressListView.Size = new System.Drawing.Size(853, 297);
            this.addressListView.TabIndex = 0;
            this.addressListView.UseCompatibleStateImageBehavior = false;
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.editButton.Location = new System.Drawing.Point(636, 361);
            this.editButton.Margin = new System.Windows.Forms.Padding(4);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(97, 28);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Edit Address";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelButton.Location = new System.Drawing.Point(741, 361);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // nameFilterLabel
            // 
            this.nameFilterLabel.AutoSize = true;
            this.nameFilterLabel.Location = new System.Drawing.Point(515, 18);
            this.nameFilterLabel.Name = "nameFilterLabel";
            this.nameFilterLabel.Size = new System.Drawing.Size(39, 17);
            this.nameFilterLabel.TabIndex = 3;
            this.nameFilterLabel.Text = "Filter";
            // 
            // filterTxt
            // 
            this.filterTxt.Location = new System.Drawing.Point(560, 15);
            this.filterTxt.Name = "filterTxt";
            this.filterTxt.Size = new System.Drawing.Size(254, 22);
            this.filterTxt.TabIndex = 4;
            this.filterTxt.TextChanged += new System.EventHandler(this.FilterTxt_TextChanged);
            // 
            // radioBtnPanel
            // 
            this.radioBtnPanel.Controls.Add(this.addressRadioBtn);
            this.radioBtnPanel.Controls.Add(this.zipRadioBtn);
            this.radioBtnPanel.Controls.Add(this.stateRadioBtn);
            this.radioBtnPanel.Controls.Add(this.nameRadioBtn);
            this.radioBtnPanel.Controls.Add(this.cityRadioBtn);
            this.radioBtnPanel.Location = new System.Drawing.Point(22, 12);
            this.radioBtnPanel.Name = "radioBtnPanel";
            this.radioBtnPanel.Size = new System.Drawing.Size(487, 30);
            this.radioBtnPanel.TabIndex = 5;
            // 
            // addressRadioBtn
            // 
            this.addressRadioBtn.Location = new System.Drawing.Point(101, 1);
            this.addressRadioBtn.Name = "addressRadioBtn";
            this.addressRadioBtn.Size = new System.Drawing.Size(95, 26);
            this.addressRadioBtn.TabIndex = 4;
            this.addressRadioBtn.Text = "Address";
            this.addressRadioBtn.UseVisualStyleBackColor = true;
            this.addressRadioBtn.CheckedChanged += new System.EventHandler(this.FilterRadioBtn_CheckedChanged);
            // 
            // zipRadioBtn
            // 
            this.zipRadioBtn.Location = new System.Drawing.Point(387, 1);
            this.zipRadioBtn.Name = "zipRadioBtn";
            this.zipRadioBtn.Size = new System.Drawing.Size(95, 26);
            this.zipRadioBtn.TabIndex = 3;
            this.zipRadioBtn.Text = "ZipCode";
            this.zipRadioBtn.UseVisualStyleBackColor = true;
            this.zipRadioBtn.CheckedChanged += new System.EventHandler(this.FilterRadioBtn_CheckedChanged);
            // 
            // stateRadioBtn
            // 
            this.stateRadioBtn.Location = new System.Drawing.Point(292, 1);
            this.stateRadioBtn.Name = "stateRadioBtn";
            this.stateRadioBtn.Size = new System.Drawing.Size(89, 26);
            this.stateRadioBtn.TabIndex = 2;
            this.stateRadioBtn.Text = "State";
            this.stateRadioBtn.UseVisualStyleBackColor = true;
            this.stateRadioBtn.CheckedChanged += new System.EventHandler(this.FilterRadioBtn_CheckedChanged);
            // 
            // nameRadioBtn
            // 
            this.nameRadioBtn.Location = new System.Drawing.Point(3, 1);
            this.nameRadioBtn.Name = "nameRadioBtn";
            this.nameRadioBtn.Size = new System.Drawing.Size(92, 26);
            this.nameRadioBtn.TabIndex = 1;
            this.nameRadioBtn.Text = "Name";
            this.nameRadioBtn.UseVisualStyleBackColor = true;
            this.nameRadioBtn.CheckedChanged += new System.EventHandler(this.FilterRadioBtn_CheckedChanged);
            // 
            // cityRadioBtn
            // 
            this.cityRadioBtn.Location = new System.Drawing.Point(209, 1);
            this.cityRadioBtn.Name = "cityRadioBtn";
            this.cityRadioBtn.Size = new System.Drawing.Size(77, 26);
            this.cityRadioBtn.TabIndex = 0;
            this.cityRadioBtn.Text = "City";
            this.cityRadioBtn.UseVisualStyleBackColor = true;
            this.cityRadioBtn.CheckedChanged += new System.EventHandler(this.FilterRadioBtn_CheckedChanged);
            // 
            // AddressEditForm
            // 
            this.AcceptButton = this.editButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(854, 402);
            this.Controls.Add(this.radioBtnPanel);
            this.Controls.Add(this.filterTxt);
            this.Controls.Add(this.nameFilterLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addressListView);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddressEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddressEdit";
            this.Load += new System.EventHandler(this.AddressEditForm_Load);
            this.radioBtnPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ListView addressListView;
        private System.Windows.Forms.Label nameFilterLabel;
        private System.Windows.Forms.TextBox filterTxt;
        private System.Windows.Forms.Panel radioBtnPanel;
        private System.Windows.Forms.RadioButton nameRadioBtn;
        private System.Windows.Forms.RadioButton cityRadioBtn;
        private System.Windows.Forms.RadioButton addressRadioBtn;
        private System.Windows.Forms.RadioButton zipRadioBtn;
        private System.Windows.Forms.RadioButton stateRadioBtn;
    }
}