<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyProducts.aspx.cs" Inherits="Ajax.BuyProducts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <title></title>
    <script type="text/javascript">
    //未封装的ajax示例
        $(function () {
            $("#ProductName").blur(function () {

                var name = $("#ProductPrice").val();
                var xmlhttp = new ActiveXObject("Microsoft.XMLHTTP")//创建http对象
                if (!xmlhttp) {
                    alert("创建xmlHttp对象异常！");
                    return false;
                }
                xmlhttp.open("POST", "GetPrice.ashx?name=" + encodeURI($("#ProductName").val()), true);

                xmlhttp.onreadystatechange = function () {
                    if (xmlhttp.readyState == 4) {
                        if (xmlhttp.status == 200) {
                            var arrs = xmlhttp.responseText.split("|");
                            if (arrs[0] == "ok") {
                                $("#ProductPrice").val(arrs[1]+"元");
                            }
                            else if (arrs[0] == "none") {
                                alert("查无此这个商品");
                                $("#ProductPrice").val("");
                                $("#ProductName").val("");
                            }
                            else {
                                alert("Ajax出现异常");
                            }
                        }
                    }
                    return false
                } //onreadystatechange结束
                xmlhttp.send();
            }); //blur中的匿名函数结束
        }) 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="ProductName" runat="server"></asp:TextBox>
        <asp:TextBox ID="ProductPrice" runat="server" ReadOnly="true"></asp:TextBox>
    </div>
    </form>
</body>
</html>
