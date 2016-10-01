<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>



 
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">

    
        <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

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

