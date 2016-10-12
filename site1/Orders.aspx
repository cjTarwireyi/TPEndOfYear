<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="site1_Orders" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <form runat="server">
        <div class=" col-md-offset-2 main">
            <h1><strong>Monthly</strong>Orders</h1>
            Year<br />
            <asp:TextBox ID="TextBox1" runat="server" Height="16px" Width="83px"></asp:TextBox><br />
            <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="128px">
                <asp:ListItem>January</asp:ListItem>
                <asp:ListItem>February</asp:ListItem>
                <asp:ListItem>March</asp:ListItem>
                <asp:ListItem>April</asp:ListItem>
                <asp:ListItem>May</asp:ListItem>
                <asp:ListItem>June</asp:ListItem>
                <asp:ListItem>July</asp:ListItem>
                <asp:ListItem>August</asp:ListItem>
                <asp:ListItem>September</asp:ListItem>
                <asp:ListItem>October</asp:ListItem>
                <asp:ListItem>November</asp:ListItem>
                <asp:ListItem>December</asp:ListItem>
            </asp:DropDownList><br /><br />
            <asp:Panel ID="Panel1" runat="server" Width="807px" BackColor="#CCCCCC">
                   <asp:RadioButton ID="RadioButton1" runat="server" Text="Paid" /><br />
                   <asp:RadioButton ID="RadioButton2" runat="server"  Text="Outstanding" />
                <asp:GridView ID="GridView1" runat="server" Width="797px"></asp:GridView>
            </asp:Panel>
        </div>
    </form>
</asp:Content>
