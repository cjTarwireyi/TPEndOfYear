<%@ Page Title="" Language="C#" MasterPageFile="~/site1/AccessMaster.master" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>


<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
      
   <div class="myContainer" >
     
    <div class="form-signin ">
           <h2 class="form-signin-heading">Please sign in</h2>
        <form runat="server" defaultfocus="username">
        <div class="form-group">

            <div class="input-group" id="Username">
                 
                <asp:TextBox ID="txtUsername" class="form-control"  runat="server" Height="35px" Width="290px"
                     placeholder="Username"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ErrorMessage="Username Required!" ControlToValidate="txtUsername" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        </div>

        <div class="form-group">
            <div class="input-group">
                  
                <asp:TextBox ID="txtPassword" runat="server" Height="35px" Width="290px"
                    class="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ErrorMessage="Password Required!" ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator>
         
        </div>
            <div class="col-lg-offset-4">
    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label><br />
         
    </div>

<div class="col-lg-offset-1">

        <asp:Button ID="Submit" runat="server" class="btn btn-primary " Height="35px" Text="Sign In"
            Width="101px" OnClick="Submit_Click" />
    </div>
        <p>
            <br />
        </p>
        


        
            </form>
    </div>
        
          </div>

     <!--
    <div class="myContainer   "   >
     
    <section id="loginform" >
    <div >
      <div id="box">
  <div class="container">
    <div class="row">
      <div class="col-sm-4 col-sm-offset-6">
        <h2 class="text-center">LOGIN.</h2>
        <form role="form">
    <div class="form-group">
      <label for="exampleInputEmail1">Email address</label>
      <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Enter email"/>
    </div>
    <div class="form-group">
      <label for="exampleInputPassword1">Password</label>
      <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password"/>
    </div>

    <div class="checkbox">
      <label>
        <input type="checkbox"/> Remember me
      </label>
    </div>
    <button type="submit" class="btn btn-default">Submit</button>
  </form>
      </div>
    </div>
  </div>
  </div></div>

</section>
</div>-->
</asp:Content>
