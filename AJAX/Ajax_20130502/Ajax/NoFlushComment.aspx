<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoFlushComment.aspx.cs" Inherits="Ajax.NoFlushComment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <title></title>
    <script type="text/javascript">
        $("#submit").click(function () {
            var content = $("#commcontent").val();
            $.ajax(
            
            )
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <textarea rows="10" cols="40" id="commcontent">
    </textarea><br />
    <input  type="button" value="提交" id="submit"/>
    </div>
    </form>
</body>
</html>
