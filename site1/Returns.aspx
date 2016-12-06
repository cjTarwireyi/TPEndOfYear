<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="Returns.aspx.cs" Inherits="site1_Returns" %>

<asp:Content ID="Content5" ContentPlaceHolderID="details" runat="Server">
    <div class="loginDisplay">
        <span class="glyphicon glyphicon-user"></span>&nbsp;<asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="Submit" runat="server" class="btn btn-danger "
            Height="35px" Text="Sign Out"
            Width="90px" />
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="sideBarNav" runat="server">
    <div id="sidebar-wrapper">
        <ul class="sidebar-nav nav-pills nav-stacked" id="menu">
            <li><a href="Home.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>
            <asp:Panel ID="AdminLinkPanel" runat="server">
                <li><a href="Users.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Users</a></li>
                <li class="active"><a href="Customers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Customers</a></li>
                <li><a href="Employee.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Employees</a></li>
                <li><a href="Suppliers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Suppliers</a></li>
                <li><a href="RegistrationPage.aspx"><i class="glyphicon glyphicon-user "></i>&nbsp;Register User</a></li>
            </asp:Panel>
            <li><a href="Reports.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Reports</a></li>
            <li><a href="Orders.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Orders</a></li>
            <li><a href="Products.aspx"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Products</a></li>
            <li><a href="Purchase.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Purchase</a></li>
            <li><a href="#"><i class="glyphicon glyphicon-envelope"></i>&nbsp;Quick Email..</a></li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <div>
        <h1 align="center"><strong>Returns</strong></h1>
        <br />
        <div style="width: 480px; margin: 0 auto;">
            <div class="form-group">
                <div class="input-group">
                    <span class="input-group-addon"><span class="fa fa-cubes"></span></span>
                    <asp:TextBox ID="txtOrderNumber" runat="server" Width="290px"
                        class="form-control" placeholder="Order Number"></asp:TextBox>
                    <asp:Label ID="lblQuantity" runat="server"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ValidationGroup="Group1" ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="OrderNumber Required!" ControlToValidate="txtOrderNumber" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblErrorProd" Visible="false" runat="server" ForeColor="Red" Text="invalid Product Code"></asp:Label>
            </div>
            <div class="form-group">
                <div class="input-group">
                    <span class="input-group-addon"><span class="fa fa-cubes"></span></span>
                    <asp:TextBox ID="txtCustomerNumber" runat="server" Height="35px" Width="290px"
                        class="form-control" placeholder="Custoemr Number" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ErrorMessage="Quantity Required!" ValidationGroup="Group1" ControlToValidate="txtCustomerNumber" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
            </div>
            <asp:Button ID="btnSearchOrder" ValidationGroup="Group1" runat="server" Height="32px" Text="Add"
                Width="126px" class="btn btn-success" />
        </div>
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>

</asp:Content>
