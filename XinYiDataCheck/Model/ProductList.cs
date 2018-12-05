using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace XinYiDataCheck
{
    public class ProductList : Collection<Product>
    {
        /// <summary>
        /// 是否所有都检查通过
        /// </summary>
        public bool IsAllOK
        {
            get
            {
                foreach (Product product in this)
                {
                    if (!product.IsOK)
                        return false;
                }

                return true;
            }
        }
    }
}
