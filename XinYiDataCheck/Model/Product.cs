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

        private bool _isGZTable = false;           // 是否在UF估值信息维护表中


        public Product(string clientID, string clientName, List<string> stockAccount_xy, List<string> stockAccount_uf, List<string> fundAccount_xy, List<string> fundAccount_uf, bool isGZTable)
        {
            _clientID = clientID;
            _clientName = clientName;
            _stockAccount_xy = stockAccount_xy;
            _stockAccount_uf = stockAccount_uf;
            _fundAccount_xy = fundAccount_xy;
            _fundAccount_uf = fundAccount_uf;
            _isGZTable = isGZTable;
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

                foreach (string tmpStkAcc in StockAccount_UF)
                {
                    if (!StockAccount_XY.Contains(tmpStkAcc))
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

                foreach (string tmFdAcc in FundAccount_UF)
                {
                    if (!FundAccount_XY.Contains(tmFdAcc))
                        return false;
                }

                return true;
            }
        }


        // 是否在UF信用估值账户信息登记表中有
        public bool IsGZTable
        {
            get { return _isGZTable; }
            set { _isGZTable = value; }
        }


        /// <summary>
        /// 80结尾是否在信用估值账号登记表中
        /// </summary>
        public bool IsGzTableOK
        {
            get
            {
                foreach (string tmp in FundAccount_UF)
                {
                    if (tmp.Length == 14 && tmp.EndsWith("80"))
                        if (IsGZTable == false)
                            return false;
                }

                return true;
            }
        }


        // 是否通过检查
        public bool IsOK
        {
            get
            {
                if (IsStockAccountOK && IsFundAccountOK && IsGzTableOK)
                    return true;
                else
                    return false;
            }
        }


        #endregion


    }
}
