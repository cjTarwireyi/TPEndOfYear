<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="pages_Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Books
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="details" Runat="Server">
    <div class="loginDisplay">
        <span class="glyphicon glyphicon-user"></span>&nbsp;<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="Submit" runat="server" class="btn btn-danger " 
            Height="35px" Text="Sign Out" 
                                Width="90px" onclick="Submit_Click"/>  
         </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sideBarNav" Runat="Server">
<div id="sidebar-wrapper">
       <ul class="sidebar-nav nav-pills nav-stacked" id="menu">
           <li><a href="../AdminDashboard.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>
           <li><a href="Staff.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Employees</a></li>
           <li><a href="Parts.aspx"><i class="glyphicon glyphicon-cog"></i>&nbsp;Parts</a></li>
           <li><a href="Customers.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Customer Record</a></li>
           <li><a href="Services.aspx"><i class="glyphicon glyphicon-list "></i>&nbsp;Services</a></li>
           <li><a href="Reports.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Reports</a></li>
           <li class="active"><a href="Books.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Books</a></li>
           <li><a href="#"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Tools</a></li>
           <li><a href="#"><i class="glyphicon glyphicon-time"></i>&nbsp;Real-time</a></li>
           <li><a href="#"><i class="glyphicon glyphicon-envelope"></i>&nbsp;Quick Email..</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="content" Runat="Server">
<h1>books page</h1>
</asp:Content>

