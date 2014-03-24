<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxPost.aspx.cs" Inherits="Ajax.AjaxPost" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <title></title>
    <script type="text/javascript">
        $(function () {
            $("#name").blur(function () {
                var name = $("#name").val();
                alert(name);
                $.post("GetPrice.ashx?name=" + encodeURI(name), function (data, text) {
                    if (text == "success") {
                        alert("服务端传过来的数据：" + data)
                        if (data == "none") {
                            alert("无数据");
                        }
                        else if (data == "ok") {
                            alert("取到了数据");
                        }
                        else alert("出现异常");
                    }
                    else {
                        alert("ajax数据操作出现异常");
                    }
                });
            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="text"  id="name"/>
    <br />
    <input type="text" id="price" />
    </div>
    </form>
</body>
</html>
