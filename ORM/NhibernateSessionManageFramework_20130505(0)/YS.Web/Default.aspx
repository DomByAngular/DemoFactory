<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YS.Web.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    
        <asp:Repeater ID="Repeater1" runat="server" >
            
                <ItemTemplate>
               <tr>
                   <td><%#Eval("ID") %></td>
                   <td><%#Eval("Name")%></td>
                   <td><%#Eval("Sex") %></td>
               </tr>
            </ItemTemplate>      
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
