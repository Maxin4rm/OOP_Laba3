namespace WindowsFormsApp1
{
    partial class FormAddElem
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelsPanel = new System.Windows.Forms.Panel();
            this.typeLabel = new System.Windows.Forms.Label();
            this.fieldsPanel = new System.Windows.Forms.Panel();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addButton = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.labelsPanel.SuspendLayout();
            this.fieldsPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelsPanel);
            this.panel2.Controls.Add(this.fieldsPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(715, 736);
            this.panel2.TabIndex = 9;
            // 
            // labelsPanel
            // 
            this.labelsPanel.Controls.Add(this.typeLabel);
            this.labelsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelsPanel.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelsPanel.Location = new System.Drawing.Point(0, 0);
            this.labelsPanel.Name = "labelsPanel";
            this.labelsPanel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.labelsPanel.Size = new System.Drawing.Size(254, 736);
            this.labelsPanel.TabIndex = 5;
            // 
            // typeLabel
            // 
            this.typeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.typeLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typeLabel.Location = new System.Drawing.Point(0, 10);
            this.typeLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(254, 36);
            this.typeLabel.TabIndex = 3;
            this.typeLabel.Text = "Type";
            this.typeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // fieldsPanel
            // 
            this.fieldsPanel.Controls.Add(this.typeComboBox);
            this.fieldsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.fieldsPanel.Location = new System.Drawing.Point(281, 0);
            this.fieldsPanel.Name = "fieldsPanel";
            this.fieldsPanel.Size = new System.Drawing.Size(434, 736);
            this.fieldsPanel.TabIndex = 6;
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "PassengerCar",
            "Truck",
            "Bus",
            "FreightTrain",
            "PassengerTrain"});
            this.typeComboBox.Location = new System.Drawing.Point(0, 0);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(407, 33);
            this.typeComboBox.TabIndex = 0;
            this.typeComboBox.SelectedValueChanged += new System.EventHandler(this.typeComboBox_SelectedValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.addButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 736);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(500, 2, 2, 2);
            this.panel1.Size = new System.Drawing.Size(715, 51);
            this.panel1.TabIndex = 8;
            // 
            // addButton
            // 
            this.addButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.addButton.Enabled = false;
            this.addButton.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.Location = new System.Drawing.Point(500, -2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(213, 51);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Visible = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // FormAddElem
            // 
            this.ClientSize = new System.Drawing.Size(715, 787);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormAddElem";
            this.Load += new System.EventHandler(this.AddForm_Load);
            this.panel2.ResumeLayout(false);
            this.labelsPanel.ResumeLayout(false);
            this.fieldsPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel labelsPanel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Panel fieldsPanel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addButton;

        #endregion
    }
}