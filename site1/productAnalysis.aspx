﻿<%@ Page Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="productAnalysis.aspx.cs" Inherits="site1_productAnalysis" %>


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
        <ul class="sidebar-nav nav-pills nav-stacked" id="menu">
            <li><a href="Home.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>
            <li><a href="Users.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Users</a></li>
            <li><a href="Customers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Customers</a></li>
            <li><a href="Employee.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Employees</a></li>
            <li class="active"><a href="Suppliers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Suppliers</a></li>
            <li><a href="RegistrationPage.aspx"><i class="glyphicon glyphicon-user "></i>&nbsp;Register User</a></li>
            <li><a href="Reports.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Reports</a></li>
            <li><a href="Orders.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Orders</a></li>
            <li><a href="Products.aspx"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Products</a></li>
            <li><a href="Purchase.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Purchase</a></li>
            <li><a href="Returns.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Item Returns</a></li>
            <li><a href="#"><i class="glyphicon glyphicon-envelope"></i>&nbsp;Quick Email..</a></li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <h1 align="center"><strong>Generate Reports</strong></h1>
    <div style="width: 290px; margin: 0 auto;">
        <asp:DropDownList ID="ddlReportType" runat="server" Height="29px" Width="237px" AutoPostBack="True" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged">
            <asp:ListItem>Most Sold Poducts</asp:ListItem>
            <asp:ListItem>Most Returned Products</asp:ListItem>
            <asp:ListItem>Top 5 Best Customers</asp:ListItem>
        </asp:DropDownList><br />
        <br />
    </div>
    <div style="width: 600px; margin: 0 auto;">
        <asp:GridView ID="GridView1" runat="server" Width="569px"></asp:GridView>

    </div>
    <div style=" vertical-align: bottom; margin: 0 auto;">
        <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" />
    </div>
</asp:Content>