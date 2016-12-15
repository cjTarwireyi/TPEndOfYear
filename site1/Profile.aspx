<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="site1_Profile" %>

<%-- Add content controls here --%>
<asp:Content ID="Content5" ContentPlaceHolderID="details" runat="Server">
    <div class="loginDisplay">
        <span class="glyphicon glyphicon-user"></span>&nbsp;<asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="Submit" runat="server" class="btn btn-danger "
            Height="35px" Text="Sign Out"
            Width="90px" OnClick="Submit_Click" />
    </div>
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



        .fieldset-auto-width {
            display: block;
            float: left;
            width: 50%;
            margin: 1em 0.7em 0.3em;
            padding: 0;
            -webkit-box-sizing: border-box; /* Safari/Chrome, other WebKit */
            -moz-box-sizing: border-box; /* Firefox, other Gecko */
            box-sizing: border-box;
            border: 2px groove;
        }

        .new-line-fieldset {
            display: block;
            float: left;
            width: 50%;
            margin: 1em 0.7em 0.3em;
            border: 2px groove;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="sideBarNav" runat="server">
    <div id="sidebar-wrapper">
        <asp:Panel ID="userPanel" runat="server">
            <ul class="sidebar-nav nav-pills nav-stacked" id="menu">
                <li><a href="Home.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>
                <li class="active"><a href="Profile.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;My Profile</a></li>
                <li><a href="Customers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Customers</a></li>
                <li><a href="Orders.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Orders</a></li>
                <li><a href="Products.aspx"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Products</a></li>
                <li><a href="Returns.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Item Returns</a></li>
                <li><a href="Purchase.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Purchase</a></li>
                <li><a href="Suppliers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Suppliers</a></li>
                
            </ul>
        </asp:Panel>
        <asp:Panel ID="AdminLinkPanel" runat="server">
            <ul class="sidebar-nav nav-pills nav-stacked" id="menu2">
                <li><a href="Home.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>
                <li class="active"><a href="Profile.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;My Profile</a></li>
                <li><a href="productAnalysis.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Reports</a></li>
                <li><a href="Orders.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Orders</a></li>
                <li><a href="Products.aspx"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Products</a></li>
                <li><a href="Returns.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Item Returns</a></li>
                <li><a href="Purchase.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Purchase</a></li>
                <li><a href="Users.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Users</a></li>
                <li><a href="Roles.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Roles</a></li>
                <li><a href="Customers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Customers</a></li>
                <li><a href="Employee.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Employees</a></li>
                <li><a href="Suppliers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Suppliers</a></li>
                <li><a href="TimeSheet.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;TimeSheet</a></li>
                <li><a href="RegistrationPage.aspx"><i class="glyphicon glyphicon-user "></i>&nbsp;Register User</a></li>
            </ul>
        </asp:Panel>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="My Profile">
        <fieldset class="fieldset-auto-width" style="width: 60%">
            <legend>Details</legend>
            <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtName" runat="server" CssClass="align"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblStreetName" runat="server" CssClass="alignlabel" Text="StreetName"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtAddress" runat="server" CssClass="alignAddress"></asp:TextBox>
            <br />
            <asp:Label ID="lblSurname" runat="server" Text="Surname"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtSurname" runat="server" CssClass="align"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblSuburb" runat="server" CssClass="alignlabel" Text="Surburb"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtSuburb" runat="server" CssClass="alignAddress"></asp:TextBox>
            <br />
            <asp:Label ID="lblCellnumber" runat="server" Text="CellNumber"></asp:Label>
            &nbsp;<asp:TextBox ID="txtCellNumber" runat="server" CssClass="align"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblPostalCode" runat="server" CssClass="alignlabel" Text="Postal Code"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="txtPostalCode" runat="server" CssClass="alignAddress"></asp:TextBox>
            <br />
            <asp:Label ID="lblDateHired" runat="server" Text="Date Hired"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtDateHired" runat="server" CssClass="align"></asp:TextBox><br />
        </fieldset>
        <fieldset class="fieldset-auto-width" style="width: 30%">
            <legend>Sign Details</legend>
            <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label><asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>&nbsp;<asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>&nbsp;&nbsp;</fieldset>

    </asp:Panel>
    <fieldset class="new-line-fieldset" style="width: 30%">
        <legend>Allocated Holidays</legend>
        <asp:Label ID="lblLeaveDays" runat="server" Text="Days Off Ex Public Holidays"></asp:Label>&nbsp;<asp:TextBox ID="txtLeaveDays" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblSickDays" runat="server" Text="Sick Leave"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtSickDays" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblReligiousDays" runat="server" Text="Religious Day"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtReligiousDays" runat="server"></asp:TextBox><br />
    </fieldset>
    <div style="position: absolute; bottom: 0; right: 0; margin-left: 0.7em; margin-right: 0.7em; margin-top: 1em;">
        &nbsp;&nbsp;&nbsp;&nbsp;
        <br /><br /><asp:Button ID="BtnSave" runat="server" Text="save" Width="74px" class="btn btn-primary" OnClick="BtnSave_Click" />
    </div>
</asp:Content>

