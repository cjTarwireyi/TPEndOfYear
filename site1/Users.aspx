<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="site1_Users" %>

<%-- Add content controls here --%>
 <asp:Content ID="Content5" ContentPlaceHolderID="details" Runat="Server">
     <div class="loginDisplay">
        <span class="glyphicon glyphicon-user"></span>&nbsp;<asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label> 
            <asp:Button ID="Submit" runat="server" class="btn btn-danger " 
            Height="35px" Text="Sign Out" 
                                Width="90px" onclick="Submit_Click"/>  
         </div>
</asp:Content>
  <asp:Content ID="Content2" ContentPlaceHolderID="sideBarNav" runat="server">
    <div id="sidebar-wrapper">
        <ul class="sidebar-nav nav-pills nav-stacked" id="menu">
            <li><a href="Home.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>
            <li  class="active"><a href="RegistrationPage.aspx"><i class="glyphicon glyphicon-list "></i>&nbsp;Register User</a></li>
            <li ><a href="Users.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Users</a></li>
            <li><a href="Customers.aspx"><i class="glyphicon glyphicon-cog"></i>&nbsp;Customers</a></li>
            <li><a href="Employee.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Employees</a></li>
            <li><a href="Reports.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Reports</a></li>
            <li><a href="Orders.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Order</a></li>
            <li><a href="Products.aspx"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Products</a></li>
            <li><a href="Purchase.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Purchase</a></li>
            <li><a href="#"><i class="glyphicon glyphicon-envelope"></i>&nbsp;Quick Email..</a></li>
        </ul>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <div class=" main" style="height:inherit">
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT a.userId, a.userName, a.pass, a.userTypeId, b.userTypeId AS Expr1, b.userTypeName, b.userTypeDescription FROM Users AS a INNER JOIN UserType AS b ON a.userTypeId = b.userTypeId"></asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server"  CellPadding="4" ForeColor="#333333" GridLines="None" Height="231px" Width="1003px" AutoGenerateColumns="False" DataKeyNames="userId,Expr1" DataSourceID="SqlDataSource1">
    <AlternatingRowStyle BackColor="White"  />
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
        <asp:BoundField DataField="userId" HeaderText="userId" SortExpression="userId" InsertVisible="False" ReadOnly="True" Visible="False" />
        <asp:BoundField DataField="userName" HeaderText="userName" SortExpression="userName" />
        <asp:BoundField DataField="pass" HeaderText="pass" SortExpression="pass" />
        <asp:BoundField DataField="userTypeId" HeaderText="userTypeId" SortExpression="userTypeId" Visible="False" />
        <asp:BoundField DataField="Expr1" HeaderText="Expr1" ReadOnly="True" SortExpression="Expr1" Visible="False" />
        <asp:BoundField DataField="userTypeName" HeaderText="userTypeName" SortExpression="userTypeName" />
        <asp:BoundField DataField="userTypeDescription" HeaderText="userTypeDescription" SortExpression="userTypeDescription" />
        <asp:TemplateField Visible="false">
            <ItemTemplate>
                <asp:Label ID="lblUserId" runat="server" Text='<%#Eval("userId") %>'></asp:Label>
                
            </ItemTemplate>
        </asp:TemplateField>
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
        
     <div class="row " >  
         <div class="col-lg-3">
         <asp:Button ID="Register" runat="server" Height="32px" Text="Register user" 
            Width="126px" class="btn btn-success" 
            data-toggle="tooltip" data-placement="left" 
            title="Insert new tecnician to database" onclick="Register_Click"/>&nbsp;&nbsp;
             </div>
         <div class="col-lg-3">
             <asp:Button ID="btnInactive" runat="server" Height="32px" Text="Update" 
            Width="130px" class="btn btn-info" 
            data-toggle="tooltip" data-placement="left" 
            title="Insert new tecnician to database" onclick="Update"/>
        </div>
         <div class="col-lg-3">
             <asp:Button ID="Button1" runat="server" Height="32px" Text="Remove User" 
            Width="145px" class="btn btn-danger" 
            data-toggle="tooltip" data-placement="left" 
            title="Insert new tecnician to database" onclick="RemoveUser"/>
             </div>
        </div>
        
        </div>
 </asp:Content>
