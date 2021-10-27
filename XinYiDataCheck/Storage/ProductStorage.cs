using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;

namespace XinYiDataCheck
{
    public class ProductStorage
    {

        /// <summary>
        /// 读取产品信息列表
        /// </summary>
        /// <param name="dbLink_xy"></param>
        /// <param name="dbLink_uf"></param>
        /// <returns></returns>
        public static ProductList ReadProductList(DBLink dbLink_xy, DBLink dbLink_uf, bool checkYYB)
        {
            ProductList productList = new ProductList();    // 产品列表


            string connString_xy = string.Format(@"User ID={0};Password={1};Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS = (PROTOCOL = TCP)(HOST = {2})(PORT = {3}))) (CONNECT_DATA = (SERVICE_NAME = {4})))",
                dbLink_xy.UserName,
                dbLink_xy.Password,
                dbLink_xy.IP,
                dbLink_xy.Port,
                dbLink_xy.Service);

            string connString_uf = string.Format(@"User ID={0};Password={1};Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS = (PROTOCOL = TCP)(HOST = {2})(PORT = {3}))) (CONNECT_DATA = (SERVICE_NAME = {4})))",
                dbLink_uf.UserName,
                dbLink_uf.Password,
                dbLink_uf.IP,
                dbLink_uf.Port,
                dbLink_uf.Service);

            using (OracleConnection cn_uf = new OracleConnection(connString_uf))
            {
                cn_uf.Open();

                using (OracleConnection cn_xy = new OracleConnection(connString_xy))
                {
                    cn_xy.Open();
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = cn_xy;

                        cmd.CommandText = @"select * from EA_CTMS.BS_TRUST_PRODUCT_INFO where IS_CLEANUP='0' and product_type not in ('0','82','262') order by PRODUCT_CODE asc";
                        using (OracleDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                // 读新意基础信息
                                string clientID = dr["PRODUCT_CODE"].ToString().Trim();
                                string extendCode = dr["EXTEND_CODE"].ToString().Trim();        // 扩展代码，这里用于多个客户号
                                string clientName = string.Empty;
                                if (!Convert.IsDBNull(dr["PRODUCT_NAME"]))
                                    clientName = dr["PRODUCT_NAME"].ToString().Trim();

                                List<string> stockAccount_xy = new List<string>();
                                List<string> fundAccount_xy = new List<string>();
                                List<string> stockAccount_uf = new List<string>();
                                List<string> fundAccount_uf = new List<string>();
                                string branchNo_xy = string.Empty;
                                // 读新意股东号、资金账号
                                try
                                {
                                    stockAccount_xy = ReadProductStockAccount_XY(clientID, cn_xy);
                                    fundAccount_xy = ReadProductFundAccount_XY(clientID, cn_xy);
                                    branchNo_xy = string.Empty;

                                    // 读柜台股东号、资金账号
                                    stockAccount_uf = ReadProductStockAccount_UF(clientID, cn_uf);
                                    fundAccount_uf = ReadProductFundAccount_UF(clientID, cn_uf);
                                    // 20190411-如果新意的扩展编码维护了与客户号不一样的，追加
                                    if (!string.IsNullOrEmpty(extendCode) && !string.Equals(clientID, extendCode, StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        string[] clientID_ext = extendCode.Split(new char[] { ',', '|', ' ', ';', '；', '，' });
                                        foreach (string tmp in clientID_ext)
                                        {
                                            List<string> tmp_stockAccount_uf = ReadProductStockAccount_UF(tmp.Trim(), cn_uf);
                                            foreach (string tmp_sa in tmp_stockAccount_uf)
                                            {
                                                if (!stockAccount_uf.Contains(tmp_sa.Trim()))
                                                    stockAccount_uf.Add(tmp_sa.Trim());
                                            }

                                            List<string> tmp_fundAccount_uf = ReadProductFundAccount_UF(tmp.Trim(), cn_uf);
                                            foreach (string tmp_fa in tmp_fundAccount_uf)
                                            {
                                                if (!fundAccount_uf.Contains(tmp_fa.Trim()))
                                                    fundAccount_uf.Add(tmp_fa.Trim());
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception(clientID + "异常： " + ex.Message);
                                }




                                string branchNo_uf = string.Empty;       // uf营业部号
                                bool isGzTable = IsGZTable(clientID, cn_uf);                        // 信用估值账户登记表是否已登记



                                Product tmpPrd = new Product(clientID: clientID,
                                    clientName: clientName,
                                    stockAccount_xy: stockAccount_xy,
                                    stockAccount_uf: stockAccount_uf,
                                    fundAccount_xy: fundAccount_xy,
                                    fundAccount_uf: fundAccount_uf,
                                    isGZTable: isGzTable,
                                    branchNo_xy: branchNo_xy,
                                    branchNo_uf: branchNo_uf,
                                    checkYYB: checkYYB
                                    );

                                productList.Add(tmpPrd);
                            }
                        }//eod dr
                    }//eof cmd
                }//eof cn_xy

            }//eof cn_uf
            return productList;
        }



        /// <summary>
        /// 读取新意系统股东号
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="cn_xy"></param>
        /// <returns></returns>
        private static List<string> ReadProductStockAccount_XY(string clientID, OracleConnection cn_xy)
        {
            List<string> stkAcc_xy = new List<string>();

            string query = string.Format("select distinct INV_ACC from EA_CTMS.BS_TRUST_INV_INFO where Product_Code='{0}'", clientID);
            using (OracleCommand cmd = new OracleCommand(query, cn_xy))
            {
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        // 获取产品基本信息
                        string stkAcc = dr["INV_ACC"].ToString();

                        stkAcc_xy.Add(stkAcc);
                    }//eof while
                }//eof dr
            }//eof cmd

            return stkAcc_xy;
        }

        /// <summary>
        /// 读取新意资金账号
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="cn_xy"></param>
        /// <returns></returns>
        private static List<string> ReadProductFundAccount_XY(string clientID, OracleConnection cn_xy)
        {
            List<string> fundAcc_xy = new List<string>();

            string query = string.Format("select distinct FUND_ACC from EA_CTMS.BS_TRUST_FUND_ACC_INFO where Product_Code='{0}'", clientID);
            using (OracleCommand cmd = new OracleCommand(query, cn_xy))
            {
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        // 获取产品基本信息
                        string fundAcc = dr["FUND_ACC"].ToString();

                        fundAcc_xy.Add(fundAcc);
                    }//eof while
                }//eof dr
            }//eof cmd

            return fundAcc_xy;
        }


        /// <summary>
        /// 读取UF股东号
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="cn_uf"></param>
        /// <returns></returns>
        private static List<string> ReadProductStockAccount_UF(string clientID, OracleConnection cn_uf)
        {
            List<string> stkAccList = new List<string>();

            string query = string.Format("select distinct stock_account from hs_asset.stockholder where client_id='{0}'", clientID);
            using (OracleCommand cmd = new OracleCommand(query, cn_uf))
            {
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        // 获取产品基本信息
                        string stkAcc = dr["stock_account"].ToString();

                        stkAccList.Add(stkAcc);
                    }//eof while
                }//eof dr
            }//eof cmd

            return stkAccList;
        }


        /// <summary>
        /// 读取UF资金账号
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="cn_uf"></param>
        /// <returns></returns>
        private static List<string> ReadProductFundAccount_UF(string clientID, OracleConnection cn_uf)
        {
            List<string> fundAccList = new List<string>();

            string query = string.Format("select distinct fund_account from hs_asset.fundaccount where client_id='{0}'", clientID);
            using (OracleCommand cmd = new OracleCommand(query, cn_uf))
            {
                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        // 获取产品基本信息
                        string fundAcc = dr["fund_account"].ToString();

                        fundAccList.Add(fundAcc);
                    }//eof while
                }//eof dr
            }//eof cmd

            return fundAccList;
        }


        /// <summary>
        /// 是否在信用估值账户登记表中存在
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="cn_uf"></param>
        /// <returns></returns>
        private static bool IsGZTable(string clientID, OracleConnection cn_uf)
        {
            bool bReturn = false;

            string query = string.Format("select count(1) from hs_asset.CRDTVALACCOUNT where client_id='{0}'", clientID);
            using (OracleCommand cmd = new OracleCommand(query, cn_uf))
            {
                object obj = cmd.ExecuteOracleScalar();
                int val = 0;
                if (!int.TryParse(obj.ToString(), out val))
                    val = 0;

                if (val == 0)
                    bReturn = false;
                else
                    bReturn = true;


            }//eof cmd

            return bReturn;
        }


        private static string ReadProductBranchNo_UF(string clientID, OracleConnection cn_uf)
        {
            string strReturn = string.Empty;

            string query = string.Format("select branch_no from hs_asset.client where client_id='{0}'", clientID);
            using (OracleCommand cmd = new OracleCommand(query, cn_uf))
            {
                object obj = cmd.ExecuteOracleScalar();
                if (!Convert.IsDBNull(obj))
                    strReturn = obj.ToString().Trim();
            }//eof cmd

            return strReturn;
        }


    }
}
