<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 426px;
        }
        .style2
        {
            width: 396px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="style2">
                Hoşgeldin <%=Session["isim"] %><%=Session["soyisim"] %>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    <asp:Panel ID="Panel1" runat="server">
                    <a href="kayit.aspx">Kayıt</a>
                    <a href="login.aspx">Giriş</a>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    <asp:Panel ID="Panel2" runat="server">
                    
                    <a href="sepet.aspx">Sepet</a> 
                    <a href="logout.aspx">Çıkış</a>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                    UrunAdi: <%#Eval("UrunAdi") %> 
                    Fiyati:<%#Eval("Fiyati") %><a href="SepeteAt.aspx?UrunID=<%#Eval("UrunID") %>">Sepete At</a><br /><hr />
                    </ItemTemplate>
                    </asp:Repeater>
                </td>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
