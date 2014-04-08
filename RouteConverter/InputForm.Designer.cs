namespace RouteConverter
{
    partial class InputForm
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
            this.btnRunConversion = new System.Windows.Forms.Button();
            this.txtRouteName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLatCol = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtHeaderRows = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNameCol = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLonCol = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSpeedCol = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRunConversion
            // 
            this.btnRunConversion.Location = new System.Drawing.Point(279, 194);
            this.btnRunConversion.Name = "btnRunConversion";
            this.btnRunConversion.Size = new System.Drawing.Size(75, 23);
            this.btnRunConversion.TabIndex = 0;
            this.btnRunConversion.Text = "Save";
            this.btnRunConversion.UseVisualStyleBackColor = true;
            this.btnRunConversion.Click += new System.EventHandler(this.btnRunConversion_Click);
            // 
            // txtRouteName
            // 
            this.txtRouteName.Location = new System.Drawing.Point(85, 16);
            this.txtRouteName.Name = "txtRouteName";
            this.txtRouteName.Size = new System.Drawing.Size(288, 20);
            this.txtRouteName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Route Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Latitude Column";
            // 
            // txtLatCol
            // 
            this.txtLatCol.Location = new System.Drawing.Point(143, 23);
            this.txtLatCol.Name = "txtLatCol";
            this.txtLatCol.Size = new System.Drawing.Size(54, 20);
            this.txtLatCol.TabIndex = 4;
            this.txtLatCol.Text = "10";
            this.txtLatCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSpeedCol);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtHeaderRows);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNameCol);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtLonCol);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtLatCol);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 157);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Excel Sheet Parameters";
            // 
            // txtHeaderRows
            // 
            this.txtHeaderRows.Location = new System.Drawing.Point(143, 125);
            this.txtHeaderRows.Name = "txtHeaderRows";
            this.txtHeaderRows.Size = new System.Drawing.Size(54, 20);
            this.txtHeaderRows.TabIndex = 10;
            this.txtHeaderRows.Text = "1";
            this.txtHeaderRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Header Rows";
            // 
            // txtNameCol
            // 
            this.txtNameCol.Location = new System.Drawing.Point(143, 75);
            this.txtNameCol.Name = "txtNameCol";
            this.txtNameCol.Size = new System.Drawing.Size(54, 20);
            this.txtNameCol.TabIndex = 8;
            this.txtNameCol.Text = "1";
            this.txtNameCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Waypoint Name Column";
            // 
            // txtLonCol
            // 
            this.txtLonCol.Location = new System.Drawing.Point(143, 49);
            this.txtLonCol.Name = "txtLonCol";
            this.txtLonCol.Size = new System.Drawing.Size(54, 20);
            this.txtLonCol.TabIndex = 6;
            this.txtLonCol.Text = "11";
            this.txtLonCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Longitude Column";
            // 
            // txtSpeedCol
            // 
            this.txtSpeedCol.Location = new System.Drawing.Point(143, 99);
            this.txtSpeedCol.Name = "txtSpeedCol";
            this.txtSpeedCol.Size = new System.Drawing.Size(54, 20);
            this.txtSpeedCol.TabIndex = 12;
            this.txtSpeedCol.Text = "6";
            this.txtSpeedCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Speed Column";
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 229);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRouteName);
            this.Controls.Add(this.btnRunConversion);
            this.Name = "InputForm";
            this.Text = "InputForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRunConversion;
        private System.Windows.Forms.TextBox txtRouteName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLatCol;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNameCol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLonCol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHeaderRows;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSpeedCol;
        private System.Windows.Forms.Label label6;
    }
}