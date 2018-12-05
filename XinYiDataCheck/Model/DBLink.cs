using System;
using System.Collections.Generic;
using System.Text;

namespace XinYiDataCheck
{
    public class DBLink
    {
        private string _ip;
        private string _port;
        private string _service;
        private string _userName;
        private string _password;


        #region 属性
        public string IP
        {
            get { return _ip; }
        }

        public string Port
        {
            get { return _port; }
        }

        public string Service
        {
            get { return _service; }
        }

        public string UserName
        {
            get { return _userName; }
        }

        public string Password
        {
            get { return _password; }
        }
        #endregion



        public DBLink(string ip, string port, string service, string userName, string password)
        {
            _ip = ip;
            _port = port;
            _service = service;
            _userName = userName;
            _password = password;
        }
    }
}
