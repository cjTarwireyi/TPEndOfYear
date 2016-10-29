<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

 

 
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
            <li class="active"><a href="Home.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>
            <li><a href="Users.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Users</a></li>
            <li><a href="Customers.aspx"><i class="glyphicon glyphicon-cog"></i>&nbsp;Customers</a></li>
            <li><a href="Employee.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Employees</a></li>
            <li><a href="RegistrationPage.aspx"><i class="glyphicon glyphicon-list "></i>&nbsp;Register User</a></li>
            <li><a href="Reports.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Reports</a></li>
            <li><a href="Orders.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Order</a></li>
            <li><a href="Products.aspx"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Products</a></li>
            <li ><a href="Purchase.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Purchase</a></li>
            <li><a href="#"><i class="glyphicon glyphicon-envelope"></i>&nbsp;Quick Email..</a></li>
        </ul>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <div class="  main">
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

          <div class="row placeholders">
            <div class="col-xs-6 col-sm-3 placeholder">
              <img src="images/Su16_NABD_FB_AirJordanV_Lateral_V1_native_1600.jpg" width="200" height="200" class="img-responsive" alt="Generic placeholder thumbnail">
              <h4>Labe<asp:ImageMap ID="ImageMap1" runat="server"></asp:ImageMap>l</h4>
              <span class="text-muted">Something else</span>
            </div>
            <div class="col-xs-6 col-sm-3 placeholder">
              <img src="images/Su16_NABD_FB_AirJordanV_Lateral_V1_native_1600.jpg" width="200" height="200" class="img-responsive" alt="Generic placeholder thumbnail">
              <h4>Label</h4>
              <span class="text-muted">Something else</span>
            </div>
            <div class="col-xs-6 col-sm-3 placeholder">
              <img src="images/Su16_NABD_FB_AirJordanV_Lateral_V1_native_1600.jpg" width="200" height="200" class="img-responsive" alt="Generic placeholder thumbnail">
              <h4>Label</h4>
              <span class="text-muted">Something else</span>
            </div>
            <div class="col-xs-6 col-sm-3 placeholder">
              <img src="images/Su16_NABD_FB_AirJordanV_Lateral_V1_native_1600.jpg" width="200" height="200" class="img-responsive" alt="Generic placeholder thumbnail">
              <h4>Label</h4>
              <span class="text-muted">Something else</span>
            </div>
          </div>
           
           
           <!-- Jumbotron -->
      <div class="jumbotron" >
        <h1 ">Dreams!</h1>
        <p class="lead">All men dream, but not equally. Those who dream by night in the dusty recesses of their minds, 
            wake in the day to find that it was vanity: but the dreamers of the day are dangerous men,
             for they may act on their dreams with open eyes, to make them possible. T. E. Lawrence 
 </p>
        <p><a class="btn btn-lg btn-success" href="#" role="button">Get started today</a></p>
      </div>
        </div>
 </asp:Content>