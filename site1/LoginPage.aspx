<%@ Page Title="" Language="C#" MasterPageFile="~/site1/AccessMaster.master" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>


<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
      <div class="myContainer   " style="background-image:url(pexels-photo-39716.jpeg); border: 3px solid silver;">
     
    <div class="   form-signin ">
           <h2 class="form-signin-heading">Please sign in</h2>
        <form runat="server" defaultfocus="username">
        <div class="form-group">

            <div class="input-group" id="Username">
                 
                <asp:TextBox ID="username" class="form-control"  runat="server" Height="35px" Width="290px"
                     placeholder="Username"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ErrorMessage="Username Required!" ControlToValidate="username" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        </div>

        <div class="form-group">
            <div class="input-group">
                  
                <asp:TextBox ID="password" runat="server" Height="35px" Width="290px"
                    class="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ErrorMessage="Password Required!" ControlToValidate="password" ForeColor="Red"></asp:RequiredFieldValidator>
         
        </div>
            <div class="col-lg-offset-4">
    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label><br />
         
    </div>

<div class="col-lg-offset-4">

        <asp:Button ID="Submit" runat="server" class="btn btn-primary " Height="35px" Text="Sign In"
            Width="101px" OnClick="Submit_Click" />
    </div>
        <p>
            <br />
        </p>
        


        <!--<a href="#">I forgot my password</a><br />
        <a href="RegistrationPage.aspx" class="text-center">Register a new membership</a>-->
            </form>
    </div>
        
          </div>
</asp:Content>
