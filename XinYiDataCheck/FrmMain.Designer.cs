namespace XinYiDataCheck
{
    partial class FrmMain
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
            this.lvProduct = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbBranchNo_UF = new System.Windows.Forms.TextBox();
            this.tbBranchNo_XY = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbXyCheck = new System.Windows.Forms.CheckBox();
            this.lbFundAccount_UF = new System.Windows.Forms.ListBox();
            this.lbFundAccount_XY = new System.Windows.Forms.ListBox();
            this.lbStockAccount_UF = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbStockAccount_XY = new System.Windows.Forms.ListBox();
            this.cbShowErrorOnly = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbResult = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvProduct
            // 
            this.lvProduct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvProduct.FullRowSelect = true;
            this.lvProduct.GridLines = true;
            this.lvProduct.Location = new System.Drawing.Point(12, 30);
            this.lvProduct.Name = "lvProduct";
            this.lvProduct.Size = new System.Drawing.Size(535, 227);
            this.lvProduct.TabIndex = 0;
            this.lvProduct.UseCompatibleStateImageBehavior = false;
            this.lvProduct.View = System.Windows.Forms.View.Details;
            this.lvProduct.SelectedIndexChanged += new System.EventHandler(this.lvProduct_SelectedIndexChanged);
            this.lvProduct.DoubleClick += new System.EventHandler(this.lvProduct_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "产品代码(客户号)";
            this.columnHeader2.Width = 153;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "信托产品名称";
            this.columnHeader3.Width = 208;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "数据是否一致";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "产品列表:";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(472, 273);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "检查";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbBranchNo_UF);
            this.groupBox1.Controls.Add(this.tbBranchNo_XY);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbXyCheck);
            this.groupBox1.Controls.Add(this.lbFundAccount_UF);
            this.groupBox1.Controls.Add(this.lbFundAccount_XY);
            this.groupBox1.Controls.Add(this.lbStockAccount_UF);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbStockAccount_XY);
            this.groupBox1.Location = new System.Drawing.Point(569, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 252);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "详细信息:";
            // 
            // tbBranchNo_UF
            // 
            this.tbBranchNo_UF.Location = new System.Drawing.Point(144, 213);
            this.tbBranchNo_UF.Name = "tbBranchNo_UF";
            this.tbBranchNo_UF.ReadOnly = true;
            this.tbBranchNo_UF.Size = new System.Drawing.Size(104, 21);
            this.tbBranchNo_UF.TabIndex = 12;
            // 
            // tbBranchNo_XY
            // 
            this.tbBranchNo_XY.Location = new System.Drawing.Point(18, 212);
            this.tbBranchNo_XY.Name = "tbBranchNo_XY";
            this.tbBranchNo_XY.ReadOnly = true;
            this.tbBranchNo_XY.Size = new System.Drawing.Size(107, 21);
            this.tbBranchNo_XY.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(142, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 12);
            this.label9.TabIndex = 10;
            this.label9.Text = "UF营业部号:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "新意营业部号:";
            // 
            // cbXyCheck
            // 
            this.cbXyCheck.AutoSize = true;
            this.cbXyCheck.Enabled = false;
            this.cbXyCheck.Location = new System.Drawing.Point(18, 175);
            this.cbXyCheck.Name = "cbXyCheck";
            this.cbXyCheck.Size = new System.Drawing.Size(120, 16);
            this.cbXyCheck.TabIndex = 8;
            this.cbXyCheck.Text = "两融柜台文件检查";
            this.cbXyCheck.UseVisualStyleBackColor = true;
            // 
            // lbFundAccount_UF
            // 
            this.lbFundAccount_UF.FormattingEnabled = true;
            this.lbFundAccount_UF.ItemHeight = 12;
            this.lbFundAccount_UF.Location = new System.Drawing.Point(144, 117);
            this.lbFundAccount_UF.Name = "lbFundAccount_UF";
            this.lbFundAccount_UF.Size = new System.Drawing.Size(104, 52);
            this.lbFundAccount_UF.TabIndex = 7;
            // 
            // lbFundAccount_XY
            // 
            this.lbFundAccount_XY.FormattingEnabled = true;
            this.lbFundAccount_XY.ItemHeight = 12;
            this.lbFundAccount_XY.Location = new System.Drawing.Point(18, 117);
            this.lbFundAccount_XY.Name = "lbFundAccount_XY";
            this.lbFundAccount_XY.Size = new System.Drawing.Size(107, 52);
            this.lbFundAccount_XY.TabIndex = 6;
            // 
            // lbStockAccount_UF
            // 
            this.lbStockAccount_UF.FormattingEnabled = true;
            this.lbStockAccount_UF.ItemHeight = 12;
            this.lbStockAccount_UF.Location = new System.Drawing.Point(144, 36);
            this.lbStockAccount_UF.Name = "lbStockAccount_UF";
            this.lbStockAccount_UF.Size = new System.Drawing.Size(104, 52);
            this.lbStockAccount_UF.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "UF资金账号:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "新意资金账号:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "UF股东号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "新意股东号:";
            // 
            // lbStockAccount_XY
            // 
            this.lbStockAccount_XY.FormattingEnabled = true;
            this.lbStockAccount_XY.ItemHeight = 12;
            this.lbStockAccount_XY.Location = new System.Drawing.Point(18, 36);
            this.lbStockAccount_XY.Name = "lbStockAccount_XY";
            this.lbStockAccount_XY.Size = new System.Drawing.Size(107, 52);
            this.lbStockAccount_XY.TabIndex = 0;
            // 
            // cbShowErrorOnly
            // 
            this.cbShowErrorOnly.AutoSize = true;
            this.cbShowErrorOnly.Location = new System.Drawing.Point(12, 273);
            this.cbShowErrorOnly.Name = "cbShowErrorOnly";
            this.cbShowErrorOnly.Size = new System.Drawing.Size(84, 16);
            this.cbShowErrorOnly.TabIndex = 4;
            this.cbShowErrorOnly.Text = "只显示异常";
            this.cbShowErrorOnly.UseVisualStyleBackColor = true;
            this.cbShowErrorOnly.CheckedChanged += new System.EventHandler(this.cbShowErrorOnly_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "是否检查通过:";
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbResult.Location = new System.Drawing.Point(417, 275);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(31, 14);
            this.lbResult.TabIndex = 6;
            this.lbResult.Text = "N/A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(567, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(299, 48);
            this.label7.TabIndex = 7;
            this.label7.Text = "*本程序检查新意与UF股东号、资金账号不一致的情况。\r\n*中登业务每日16点截止，请16点后运行。\r\n*新意1个产品可能对应多个UF客户号，目前新意配置\r\n在扩展" +
    "编码中进行配对。";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 344);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbShowErrorOnly);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvProduct);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "新意分仓数据检查";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvProduct;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbFundAccount_UF;
        private System.Windows.Forms.ListBox lbFundAccount_XY;
        private System.Windows.Forms.ListBox lbStockAccount_UF;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbStockAccount_XY;
        private System.Windows.Forms.CheckBox cbShowErrorOnly;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbXyCheck;
        private System.Windows.Forms.TextBox tbBranchNo_UF;
        private System.Windows.Forms.TextBox tbBranchNo_XY;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}

