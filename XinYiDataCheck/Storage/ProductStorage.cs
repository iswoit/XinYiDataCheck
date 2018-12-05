﻿using System;
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
        public static ProductList ReadProductList(DBLink dbLink_xy, DBLink dbLink_uf)
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

                        cmd.CommandText = @"select * from EA_CTMS.BS_TRUST_PRODUCT_INFO where IS_CLEANUP='0'";
                        using (OracleDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                // 读新意基础信息
                                string clientID = dr["PRODUCT_CODE"].ToString().Trim();
                                string clientName = string.Empty;
                                if (!Convert.IsDBNull(dr["PRODUCT_NAME"]))
                                    clientName = dr["PRODUCT_NAME"].ToString().Trim();

                                // 读新意股东号、资金账号
                                List<string> stockAccount_xy = ReadProductStockAccount_XY(clientID, cn_xy);
                                List<string> fundAccount_xy = ReadProductFundAccount_XY(clientID, cn_xy);

                                // 读柜台股东号、
                                List<string> stockAccount_uf = ReadProductStockAccount_UF(clientID, cn_uf);
                                List<string> fundAccount_uf = ReadProductFundAccount_UF(clientID, cn_uf);

                                Product tmpPrd = new Product(clientID: clientID,
                                    clientName: clientName,
                                    stockAccount_xy: stockAccount_xy,
                                    stockAccount_uf: stockAccount_uf,
                                    fundAccount_xy: fundAccount_xy,
                                    fundAccount_uf: fundAccount_uf);

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


    }
}