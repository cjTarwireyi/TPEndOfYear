<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="InactiveProducts.aspx.cs" Inherits="site1_InactiveProducts" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Scripts/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="/Scripts/bootstrap.js"></script>

    <script type="text/javascript" src="/Scripts/bootstrap.min.js"></script>
    <title></title>
    <style type="text/css">
        .cssPager td {
            padding-left: 4px;
            padding-right: 4px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="details" runat="Server">
    <div class="loginDisplay">
        <span class="glyphicon glyphicon-user"></span>&nbsp;<asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="Submit" runat="server" class="btn btn-danger "
            Height="35px" Text="Sign Out"
            Width="90px" OnClick="Submit_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="sideBarNav" runat="server">
    <div id="sidebar-wrapper">
        <asp:Panel ID="userPanel" runat="server">
            <ul class="sidebar-nav nav-pills nav-stacked" id="menu">
                <li><a href="Home.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>
                <li><a href="Profile.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;My Profile</a></li>
                <li><a href="productAnalysis.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Reports</a></li>
                <li><a href="Orders.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Orders</a></li>
                <li><a href="Products.aspx"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Products</a></li>
                <li><a href="Returns.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Item Returns</a></li>
                <li><a href="Purchase.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Purchase</a></li>
            </ul>
        </asp:Panel>
        <asp:Panel ID="AdminLinkPanel" runat="server">
            <ul class="sidebar-nav nav-pills nav-stacked" id="menu2">
                <li><a href="Home.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>
                <li><a href="Profile.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;My Profile</a></li>
                <li><a href="productAnalysis.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Reports</a></li>
                <li><a href="Orders.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Orders</a></li>
                <li class="active"><a href="Products.aspx"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Products</a></li>
                <li><a href="Returns.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Item Returns</a></li>
                <li><a href="Purchase.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Purchase</a></li>
                <li><a href="Users.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Users</a></li>
                <li><a href="Roles.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Roles</a></li>
                <li><a href="Customers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Customers</a></li>
                <li><a href="Employee.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Employees</a></li>
                <li><a href="Suppliers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Suppliers</a></li>
                <li><a href="RegistrationPage.aspx"><i class="glyphicon glyphicon-user "></i>&nbsp;Register User</a></li>
            </ul>
        </asp:Panel>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <div class="main">
        <h1 align="center"><strong>Inactive</strong>Records</h1>
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="topCorner">
                    <asp:TextBox ID="txtSearch" AutoPostBack="true" runat="server" Type="Integer" placeholder="Enter Product ID" Width="131px" OnTextChanged="dgrvData_Filter"></asp:TextBox><asp:Button ID="btnSearch" runat="server" Text="Search" Height="23px" Width="63px" OnClick="btnSearch_Click" /><br />
                </div>
                <%--<asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="Id" Height="100px" Width="1337px" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" GridLines="None">--%>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" Height="45px" Width="1080px" AllowSorting="True" AllowPaging="true" GridLines="Vertical" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <PagerStyle CssClass="cssPager" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                        <asp:BoundField DataField="ProductDescription" HeaderText="ProductDescription" SortExpression="ProductDescription" />
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                        <asp:BoundField DataField="DateArrived" HeaderText="DateArrived" SortExpression="DateArrived" />
                        <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" SortExpression="SupplierID" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:Button ID="Active" runat="server" Height="32px" Text="Activate Product"
            Width="126px" class="btn btn-success"
            data-toggle="tooltip" data-placement="left"
            title="Insert new tecnician to database" OnClick="Active_Click" />&nbsp;&nbsp;
            <asp:Button ID="btnProducts" runat="server" Height="32px" Text="Active Products"
                Width="126px" class="btn btn-success"
                data-toggle="tooltip" data-placement="left"
                title="Insert new tecnician to database" OnClick="btnProducts_Click" />
    </div>
</asp:Content>

