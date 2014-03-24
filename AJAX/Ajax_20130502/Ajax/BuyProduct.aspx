<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyProduct.aspx.cs" Inherits="Login.BuyProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/send_request.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <title></title>
    <script type="text/javascript">

        $("document").ready(function () {
            $("#ProductName").blur(function () {
                if ($("#ProductName").val() != "") {
                    send_request("GetPrice.ashx?name=" + encodeURI($("#ProductName").val()));
                }
                else {
                    return;
                }
            })
        });
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
