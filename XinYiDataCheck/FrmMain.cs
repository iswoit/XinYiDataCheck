using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XinYiDataCheck
{
    public partial class FrmMain : Form
    {
        private Manager _manager;

        public Manager Manager
        {
            get { return _manager; }
            set { _manager = value; }
        }




        public FrmMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 主窗体Load事件：读取新意数据库的内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            Manager = new Manager();


        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                Manager.LoadProductInfo();
                DisplayProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void DisplayProductList()
        {

            lvProduct.Items.Clear();
            lvProduct.BeginUpdate();
            int idx = 0;    // 计数器
            foreach (Product product in Manager.ProductList)
            {
                if (cbShowErrorOnly.Checked && product.IsOK == true)
                {
                    continue;
                }

                ListViewItem lvi = new ListViewItem((++idx).ToString());
                lvi.SubItems.Add(product.ClientID);
                lvi.SubItems.Add(product.ClientName);
                lvi.SubItems.Add(product.IsOK ? "√" : "×");

                lvi.Tag = product;
                //lvi.Checked = true;

                if (product.IsOK)
                    lvi.BackColor = SystemColors.Window;
                else
                    lvi.BackColor = Color.Pink;

                lvProduct.Items.Add(lvi);
            }

            //lvProductList.Columns[0].Width = -1;
            //lvProductList.Columns[1].Width = -1;
            //lvProductList.Columns[2].Width = -1;
            //lvProductList.Columns[3].Width = -1;
            //lvProductList.Columns[4].Width = -1;
            //lvProductList.Columns[5].Width = -1;

            lvProduct.EndUpdate();


            if (Manager.ProductList.IsAllOK)
            {
                lbResult.Text = "是";
                lbResult.ForeColor = Color.Green;
            }
            else
            {
                lbResult.Text = "否";
                lbResult.ForeColor = Color.Red;
            }

        }

        private void lvProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvProduct.SelectedItems.Count <= 0)
                return;

            ListViewItem lvi = lvProduct.SelectedItems[0];
            if (lvi != null)
            {
                Product product = (Product)lvi.Tag;

                // 新意股东号
                lbStockAccount_XY.Items.Clear();
                foreach (string tmp in product.StockAccount_XY)
                    lbStockAccount_XY.Items.Add(tmp);

                // UF股东号
                lbStockAccount_UF.Items.Clear();
                foreach (string tmp in product.StockAccount_UF)
                    lbStockAccount_UF.Items.Add(tmp);

                // 新意资金账号
                lbFundAccount_XY.Items.Clear();
                foreach (string tmp in product.FundAccount_XY)
                    lbFundAccount_XY.Items.Add(tmp);

                // UF资金账号
                lbFundAccount_UF.Items.Clear();
                foreach (string tmp in product.FundAccount_UF)
                    lbFundAccount_UF.Items.Add(tmp);


                cbXyCheck.Checked = product.IsGzTableOK;


                tbBranchNo_XY.Text = product.BranchNo_XY;
                tbBranchNo_UF.Text = product.BranchNo_UF;

            }
        }

        private void cbShowErrorOnly_CheckedChanged(object sender, EventArgs e)
        {
            DisplayProductList();
        }

        private void lvProduct_DoubleClick(object sender, EventArgs e)
        {
            if (lvProduct.SelectedItems.Count <= 0)
                return;

            ListViewItem lvi = lvProduct.SelectedItems[0];
            if (lvi != null)
            {
                Product product = (Product)lvi.Tag;

                Clipboard.SetDataObject(product.ClientID);

            }
        }
    }
}
