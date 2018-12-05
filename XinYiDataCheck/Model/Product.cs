using System;
using System.Collections.Generic;
using System.Text;

namespace XinYiDataCheck
{
    public class Product
    {
        // 基础信息
        private string _clientID;                   // 客户号
        private string _clientName;                 // 客户名称
        private List<string> _stockAccount_xy;      // 股东号列表_新意
        private List<string> _stockAccount_uf;      // 股东号列表_uf
        private List<string> _fundAccount_xy;       // 资金账号列表_新意
        private List<string> _fundAccount_uf;       // 资金账号列表_uf


        // 检查标记信息
        private bool _isChecked = false;            // 是否检查过




        public Product(string clientID, string clientName, List<string> stockAccount_xy, List<string> stockAccount_uf, List<string> fundAccount_xy, List<string> fundAccount_uf)
        {
            _clientID = clientID;
            _clientName = clientName;
            _stockAccount_xy = stockAccount_xy;
            _stockAccount_uf = stockAccount_uf;
            _fundAccount_xy = fundAccount_xy;
            _fundAccount_uf = fundAccount_uf;
        }



        #region 属性

        // 客户号
        public string ClientID
        {
            get { return _clientID; }
            set { _clientID = value; }
        }

        // 客户名称
        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value; }
        }

        // 新意股东号列表
        public List<string> StockAccount_XY
        {
            get { return _stockAccount_xy; }
            set { _stockAccount_xy = value; }
        }

        // UF股东号列表
        public List<string> StockAccount_UF
        {
            get { return _stockAccount_uf; }
            set { _stockAccount_uf = value; }
        }

        // 新意资金账号列表
        public List<string> FundAccount_XY
        {
            get { return _fundAccount_xy; }
            set { _fundAccount_xy = value; }
        }

        // UF资金账号
        public List<string> FundAccount_UF
        {
            get { return _fundAccount_uf; }
            set { _fundAccount_uf = value; }
        }


        // 股东号检查通过
        public bool IsStockAccountOK
        {
            get
            {

                foreach (string tmpStkAcc in StockAccount_XY)
                {
                    if (!StockAccount_UF.Contains(tmpStkAcc))
                        return false;
                }

                return true;
            }
        }

        // 资金账号检查通过
        public bool IsFundAccountOK
        {
            get
            {

                foreach (string tmFdAcc in FundAccount_XY)
                {
                    if (!FundAccount_UF.Contains(tmFdAcc))
                        return false;
                }

                return true;
            }
        }

        // 是否完成检查
        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; }
        }

        // 是否通过检查
        public bool IsOK
        {
            get
            {

                if (IsStockAccountOK && IsFundAccountOK)
                    return true;
                else
                    return false;
            }
        }


        #endregion


    }
}
