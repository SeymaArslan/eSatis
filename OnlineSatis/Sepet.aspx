<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sepet.aspx.cs" Inherits="Sepet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="Sil">
                    <ItemTemplate>
                        <a href="sepettencikar.aspx?ItemNo=<%#Eval("ItemNo") %>">Sil</a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Adet">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox1" Text=<%#Eval("Adet") %> runat="server" Height="23px" Width="58px"></asp:TextBox>
                        <a href="guncelle.aspx">Güncelle</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    
    </div>
    Toplam :&nbsp;
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
