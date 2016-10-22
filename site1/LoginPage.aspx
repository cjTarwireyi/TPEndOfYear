<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>


<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
      <div class="myContainer col-lg-offset-3  " style="background-image:url(pexels-photo-39716.jpeg)">
     
    <div class="   form-signin ">
           <h2 class="form-signin-heading">Please sign in</h2>
        <div class="form-group">

            <div class="input-group" id="Username">
                 
                <asp:TextBox ID="username" class="form-control" runat="server" Height="35px" Width="290px"
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
 

        <asp:Button ID="Submit" runat="server" class="btn btn-primary " Height="35px" Text="Sign In"
            Width="101px" OnClick="Submit_Click" />
        <p>
            <br />
        </p>
        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>


        <a href="#">I forgot my password</a><br />
        <a href="RegistrationPage.aspx" class="text-center">Register a new membership</a>
    </div>
        
          </div>
</asp:Content>
