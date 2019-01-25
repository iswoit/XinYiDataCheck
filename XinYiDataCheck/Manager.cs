using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.OracleClient;

namespace XinYiDataCheck
{
    public class Manager
    {
        private DBLink _dbLink_xy;
        private DBLink _dbLink_uf;
        private ProductList _productList = new ProductList();
        private bool _checkYYB;

        public DBLink DBLink_XY
        {
            get { return _dbLink_xy; }
        }

        public DBLink DBLink_UF
        {
            get { return _dbLink_uf; }
        }

        public ProductList ProductList
        {
            get { return _productList; }
            set { _productList = value; }
        }




        /// <summary>
        /// 构造函数：取appconfig配置
        /// </summary>
        public Manager()
        {
            GetDBLink();

            // 20190125：禁止检查营业部
            string conf_yyb = ConfigurationManager.AppSettings["yyb"];
            if (conf_yyb != null && string.Equals(conf_yyb.Trim(), "0", StringComparison.CurrentCultureIgnoreCase))
                _checkYYB = false;
            else
                _checkYYB = true;
        }


        /// <summary>
        /// 获取新意和UF的数据连接对象
        /// </summary>
        private void GetDBLink()
        {
            string xyIP = ConfigurationManager.AppSettings["xyIP"].Trim();
            string xyPort = ConfigurationManager.AppSettings["xyPort"].Trim();
            string xyService = ConfigurationManager.AppSettings["xyService"].Trim();
            string xyUserName = ConfigurationManager.AppSettings["xyUserName"].Trim();
            string xyPassword = ConfigurationManager.AppSettings["xyPassword"].Trim();
            _dbLink_xy = new DBLink(ip: xyIP, port: xyPort, service: xyService, userName: xyUserName, password: xyPassword);


            string ufIP = ConfigurationManager.AppSettings["ufIP"].Trim();
            string ufPort = ConfigurationManager.AppSettings["ufPort"].Trim();
            string ufService = ConfigurationManager.AppSettings["ufService"].Trim();
            string ufUserName = ConfigurationManager.AppSettings["ufUserName"].Trim();
            string ufPassword = ConfigurationManager.AppSettings["ufPassword"].Trim();
            _dbLink_uf = new DBLink(ip: ufIP, port: ufPort, service: ufService, userName: ufUserName, password: ufPassword);
        }


        /// <summary>
        /// 获取新意产品信息
        /// </summary>
        public void LoadProductInfo()
        {
            _productList = ProductStorage.ReadProductList(DBLink_XY, DBLink_UF, _checkYYB);
        }



    }
}
