namespace FinanceManagement1._0.TienIch
{
    partial class Exchange
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
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.cmbSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_exChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold);
            this.txtInput.Location = new System.Drawing.Point(37, 78);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(246, 61);
            this.txtInput.TabIndex = 1;
            this.txtInput.Text = "Nhập VNĐ";
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold);
            this.txtResult.Location = new System.Drawing.Point(566, 78);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(246, 61);
            this.txtResult.TabIndex = 2;
            this.txtResult.Text = "Kết Quả";
            // 
            // cmbSelect
            // 
            this.cmbSelect.FormattingEnabled = true;
            this.cmbSelect.Items.AddRange(new object[] {
            "USD",
            "EUR",
            "JPY",
            "KRW",
            "SGD",
            "AUD",
            "CAN"});
            this.cmbSelect.Location = new System.Drawing.Point(330, 96);
            this.cmbSelect.Name = "cmbSelect";
            this.cmbSelect.Size = new System.Drawing.Size(192, 24);
            this.cmbSelect.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(235, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 33);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chuyển VND sang Ngoại Tệ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(351, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Chọn Ngoại Tệ";
            // 
            // btn_exChange
            // 
            this.btn_exChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(183)))), ((int)(((byte)(112)))));
            this.btn_exChange.FlatAppearance.BorderSize = 0;
            this.btn_exChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exChange.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exChange.ForeColor = System.Drawing.Color.White;
            this.btn_exChange.Image = global::FinanceManagement1._0.Properties.Resources.exchange_20px1;
            this.btn_exChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exChange.Location = new System.Drawing.Point(330, 151);
            this.btn_exChange.Name = "btn_exChange";
            this.btn_exChange.Size = new System.Drawing.Size(192, 57);
            this.btn_exChange.TabIndex = 0;
            this.btn_exChange.Text = " Exchange";
            this.btn_exChange.UseVisualStyleBackColor = false;
            this.btn_exChange.Click += new System.EventHandler(this.btn_exChange_Click);
            // 
            // Exchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 242);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSelect);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btn_exChange);
            this.Name = "Exchange";
            this.Text = "Exchange";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_exChange;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.ComboBox cmbSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}