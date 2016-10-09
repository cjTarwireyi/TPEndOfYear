<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="site1_Users" %>

<%-- Add content controls here --%>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <div class=" col-md-offset-2 main">
    <form runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT a.userId, a.userName, a.pass, a.userTypeId, b.userTypeId AS Expr1, b.userTypeName, b.userTypeDescription FROM Users AS a INNER JOIN UserType AS b ON a.userTypeId = b.userTypeId"></asp:SqlDataSource>
<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="231px" Width="1003px" AutoGenerateColumns="False" DataKeyNames="userId,Expr1" DataSourceID="SqlDataSource1">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
        <asp:BoundField DataField="userName" HeaderText="User Name" SortExpression="userName" />
        <asp:BoundField DataField="userTypeName" HeaderText="User Type " SortExpression="userTypeName" />
        <asp:BoundField DataField="userTypeDescription" HeaderText="Description" SortExpression="userTypeDescription" />
    </Columns>
    <EditRowStyle BackColor="#2461BF" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#EFF3FB" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F5F7FB" />
    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
    <SortedDescendingCellStyle BackColor="#E9EBEF" />
    <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>

       <asp:Button ID="Register" runat="server" Height="32px" Text="Register user" 
            Width="126px" class="btn btn-success" 
            data-toggle="tooltip" data-placement="left" 
            title="Insert new tecnician to database" onclick="Register_Click"/>&nbsp;&nbsp;
             <asp:Button ID="btnInactive" runat="server" Height="32px" Text="Update" 
            Width="130px" class="btn btn-info" 
            data-toggle="tooltip" data-placement="left" 
            title="Insert new tecnician to database" onclick="InactiveRecords"/>
        </form>
        </div>
 </asp:Content>
