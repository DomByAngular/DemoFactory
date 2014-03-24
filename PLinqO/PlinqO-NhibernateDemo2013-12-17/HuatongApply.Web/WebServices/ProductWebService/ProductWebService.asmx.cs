using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using CYSBasicSystemUI.Models;

namespace HuaTongSystem.WebServices.ProductWebService
{
    /// <summary>
    /// ProductWebService1 的摘要说明
    /// </summary>
    [ScriptService]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class ProductWebService : System.Web.Services.WebService
    {
        //protected SystemFacade systemFacade { get; set; }

        [ScriptMethod]
        [WebMethod]
        public object GetProducts(string order, int page, int rows, string sort)
        {
            //查询所有数据
            var productList = new List<Product>
            {
                new Product{Productid="FI-SW-01",Productname="Koi",Unitcost=10.00,Status="P",Listprice=36.50,Attr1="Large",Itemid="EST-1"},
                new Product{Productid="K9-DL-01",Productname="Dalmation",Unitcost=12.00,Status="P",Listprice=18.50,Attr1="Spotted Adult Female",Itemid="EST-10"},
                new Product{Productid="RP-SN-01",Productname="Rattlesnake",Unitcost=12.00,Status="P",Listprice=38.50,Attr1="Venomless",Itemid="EST-11"},
	            new Product{Productid="RP-SN-01",Productname="Rattlesnake",Unitcost=12.00,Status="P",Listprice=26.50,Attr1="Rattleless",Itemid="EST-12"},
	            new Product{Productid="RP-LI-02",Productname="Iguana",Unitcost=12.00,Status="P",Listprice=35.50,Attr1="Green Adult",Itemid="EST-13"},
	            new Product{Productid="FL-DSH-01",Productname="Manx",Unitcost=12.00,Status="P",Listprice=158.50,Attr1="Tailless",Itemid="EST-14"},
	            new Product{Productid="FL-DSH-01",Productname="Manx",Unitcost=12.00,Status="P",Listprice=83.50,Attr1="With tail",Itemid="EST-15"},
	            new Product{Productid="FL-DLH-02",Productname="Persian",Unitcost=12.00,Status="P",Listprice=23.50,Attr1="Adult Female",Itemid="EST-16"},
	            new Product{Productid="FL-DLH-02",Productname="Persian",Unitcost=12.00,Status="P",Listprice=89.50,Attr1="Adult Male",Itemid="EST-17"},
	            new Product{Productid="AV-CB-01",Productname="Amazon Parrot",Unitcost=92.00,Status="P",Listprice=63.50,Attr1="Adult Male",Itemid="EST-18"}
            };

            if (order == "asc")
            {
                productList = (from m in productList
                          orderby m.Itemid ascending 
                          select m).ToList<Product>();
            }
            else
            {
                productList = (from m in productList
                               orderby m.Itemid descending
                          select m).ToList<Product>();
            }

            var obj = new { total = 20, rows = productList };
            return obj;
        }

        [ScriptMethod]
        [WebMethod]
        public Product GetOneProduct(string pItemid)
        {
            //查询一条数据
            var productList = new List<Product>
            {
                new Product{Productid="FI-SW-01",Productname="Koi",Unitcost=10.00,Status="P",Listprice=36.50,Attr1="Large",Itemid="EST-1"},
                new Product{Productid="K9-DL-01",Productname="Dalmation",Unitcost=12.00,Status="P",Listprice=18.50,Attr1="Spotted Adult Female",Itemid="EST-10"},
                new Product{Productid="RP-SN-01",Productname="Rattlesnake",Unitcost=12.00,Status="P",Listprice=38.50,Attr1="Venomless",Itemid="EST-11"},
	            new Product{Productid="RP-SN-01",Productname="Rattlesnake",Unitcost=12.00,Status="P",Listprice=26.50,Attr1="Rattleless",Itemid="EST-12"},
	            new Product{Productid="RP-LI-02",Productname="Iguana",Unitcost=12.00,Status="P",Listprice=35.50,Attr1="Green Adult",Itemid="EST-13"},
	            new Product{Productid="FL-DSH-01",Productname="Manx",Unitcost=12.00,Status="P",Listprice=158.50,Attr1="Tailless",Itemid="EST-14"},
	            new Product{Productid="FL-DSH-01",Productname="Manx",Unitcost=12.00,Status="P",Listprice=83.50,Attr1="With tail",Itemid="EST-15"},
	            new Product{Productid="FL-DLH-02",Productname="Persian",Unitcost=12.00,Status="P",Listprice=23.50,Attr1="Adult Female",Itemid="EST-16"},
	            new Product{Productid="FL-DLH-02",Productname="Persian",Unitcost=12.00,Status="P",Listprice=89.50,Attr1="Adult Male",Itemid="EST-17"},
	            new Product{Productid="AV-CB-01",Productname="Amazon Parrot",Unitcost=92.00,Status="P",Listprice=63.50,Attr1="Adult Male",Itemid="EST-18"}
            };

            var product = productList.Find(p => p.Itemid == pItemid);

            return product;
        }

        [ScriptMethod]
        [WebMethod]
        public bool AddProduct(Product pProduct)
        {
            //itemid为空时则新增
            if (string.IsNullOrEmpty(pProduct.Itemid))
            {
                
            }

            return true;
        }


        [ScriptMethod]
        [WebMethod]
        public bool UpdateProduct(Product pProduct)
        {
            //itemid不为空时则修改
            if (!string.IsNullOrEmpty(pProduct.Itemid))
            {

            }

            return true;
        }

        [ScriptMethod]
        [WebMethod]
        public bool DeleteProducts(string pIds)
        {
            //批量删除

            return true;
        }

        [ScriptMethod]
        [WebMethod]
        public object GetOrdersJosn(string pItemid)
        {
            var orderList = new[]{
                new {OrderId="1001",Quantity="1",UnitPrice=10.00,Itemid="EST-1"},
                new {OrderId="1003",Quantity="3",UnitPrice=12.00,Itemid="EST-10"},
                new {OrderId="1002",Quantity="2",UnitPrice=12.00,Itemid="EST-1"},
	            new {OrderId="1004",Quantity="4",UnitPrice=12.00,Itemid="EST-12"},
	            new {OrderId="1006",Quantity="2",UnitPrice=12.00,Itemid="EST-13"},
	            new {OrderId="1005",Quantity="3",UnitPrice=12.00,Itemid="EST-12"},
	            new {OrderId="1007",Quantity="4",UnitPrice=12.00,Itemid="EST-15"},
	            new {OrderId="1010",Quantity="6",UnitPrice=12.00,Itemid="EST-16"},
	            new {OrderId="1008",Quantity="8",UnitPrice=12.00,Itemid="EST-15"},
	            new {OrderId="1009",Quantity="2 Parrot",UnitPrice=92.00,Itemid="EST-15"}
            };
            var list = orderList.ToList();
            var orders = list.FindAll(p => p.Itemid == pItemid);
            var obj = new { rows = orders };

            return obj;
        }

        [ScriptMethod]
        [WebMethod]
        public object GetJson(string order, int page, int rows, string sort)
        {
            var ary = new[]{
                new {productid="FI-SW-01",productname="Koi",unitcost=10.00,status="P",listprice=36.50,attr1="Large",itemid="EST-1"},
                new {productid="K9-DL-01",productname="Dalmation",unitcost=12.00,status="P",listprice=18.50,attr1="Spotted Adult Female",itemid="EST-10"},
                new {productid="RP-SN-01",productname="Rattlesnake",unitcost=12.00,status="P",listprice=38.50,attr1="Venomless",itemid="EST-11"},
	            new {productid="RP-SN-01",productname="Rattlesnake",unitcost=12.00,status="P",listprice=26.50,attr1="Rattleless",itemid="EST-12"},
	            new {productid="RP-LI-02",productname="Iguana",unitcost=12.00,status="P",listprice=35.50,attr1="Green Adult",itemid="EST-13"},
	            new {productid="FL-DSH-01",productname="Manx",unitcost=12.00,status="P",listprice=158.50,attr1="Tailless",itemid="EST-14"},
	            new {productid="FL-DSH-01",productname="Manx",unitcost=12.00,status="P",listprice=83.50,attr1="With tail",itemid="EST-15"},
	            new {productid="FL-DLH-02",productname="Persian",unitcost=12.00,status="P",listprice=23.50,attr1="Adult Female",itemid="EST-16"},
	            new {productid="FL-DLH-02",productname="Persian",unitcost=12.00,status="P",listprice=89.50,attr1="Adult Male",itemid="EST-17"},
	            new {productid="AV-CB-01",productname="Amazon Parrot",unitcost=92.00,status="P",listprice=63.50,attr1="Adult Male",itemid="EST-18"}
            };
            if (order == "asc")
            {
                Array.Sort(ary, delegate(object obj1, object obj2)
                {
                    if (GetPropertyType(obj1, sort) == "Double")
                    {
                        return GetPropertyDoubleValue(obj1, sort) > GetPropertyDoubleValue(obj2, sort) ? 1 : -1;
                    }
                    else
                    {
                        return GetPropertyStringValue(obj1, sort).CompareTo(GetPropertyStringValue(obj2, sort));
                    }
                });
            }
            else
            {
                Array.Sort(ary, delegate(object obj1, object obj2)
                {
                    if (GetPropertyType(obj1, sort) == "Double")
                    {
                        return GetPropertyDoubleValue(obj2, sort) > GetPropertyDoubleValue(obj1, sort) ? 1 : -1;
                    }
                    else
                    {
                        return GetPropertyStringValue(obj2, sort).CompareTo(GetPropertyStringValue(obj1, sort));
                    }
                });
            }
            var obj = new { total = 28, rows = ary };
            return obj;
        }

        private string GetPropertyType(object o, string name)
        {
            return o.GetType().GetProperty(name).GetValue(o, null).GetType().Name;
        }

        private double GetPropertyDoubleValue(object o, string name)
        {
            return double.Parse(o.GetType().GetProperty(name).GetValue(o, null).ToString());
        }

        private string GetPropertyStringValue(object o, string name)
        {
            return o.GetType().GetProperty(name).GetValue(o, null).ToString();
        }
    }
}
