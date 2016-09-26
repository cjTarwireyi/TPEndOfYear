<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="RegistrationPage.aspx.cs" Inherits="RegistrationPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Registration
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <form id="form1" runat="server">
             
    						<div class="page-header">
  							<h3><strong>Booking</strong>Admin</h3>
                               
						</div>
                        <div class="form-group">
    								<div class="input-group" id="Div4">
  									<span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
  									<asp:TextBox ID="Username" runat="server" Height="35px" Width="290px" 
                                            class="form-control" placeholder="Username"></asp:TextBox>
                                  </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                        ErrorMessage="Username Required!" ControlToValidate="Username" ForeColor="Red"></asp:RequiredFieldValidator>
  							        <br />
  							</div>
  							<div class="form-group">
    								<div class="input-group" id="Name">
  									<span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
  									<asp:TextBox ID="FullName" runat="server" Height="35px" Width="290px" 
                                            class="form-control" placeholder="Name"></asp:TextBox>
                                  </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ErrorMessage="Name Required!" ControlToValidate="FullName" ForeColor="Red"></asp:RequiredFieldValidator>
  							        <br />
  							</div>
                            <div class="form-group">
    								<div class="input-group" id="Div2">
  									<span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
  									<asp:TextBox ID="Surname" runat="server" Height="35px" Width="290px" 
                                            class="form-control" placeholder="Surname"></asp:TextBox>
                                  </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                        ErrorMessage="Surname Required!" ControlToValidate="Surname" ForeColor="Red"></asp:RequiredFieldValidator>
  							        <br />
  							</div>
                            <div class="form-group">
    								<div class="input-group" id="Div3">
  									<span class="input-group-addon"><span class="glyphicon glyphicon-phone"></span></span>
  									<asp:TextBox ID="Phone" runat="server" Height="35px" Width="290px" 
                                            class="form-control" placeholder="Phone Number e.g (072)111-2223"></asp:TextBox>
                                  </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                        ErrorMessage="Phone Number Required!" ControlToValidate="Phone" ForeColor="Red"></asp:RequiredFieldValidator>
  							        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                        ControlToValidate="Phone" ErrorMessage="Invalid Phone Number e.g (072)111-2223" ForeColor="Red" 
                                        ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
  							        <br />
  							</div>
                            <div class="form-group">
    								<div class="input-group" id="Div1">
  									<span class="input-group-addon"><span class="glyphicon glyphicon-envelope"></span></span>
  									<asp:TextBox ID="Email" runat="server" Height="35px" Width="290px" 
                                            class="form-control" placeholder="Email"></asp:TextBox>
                                        
                                  </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ErrorMessage="Email Required!" ControlToValidate="Email" ForeColor="Red"></asp:RequiredFieldValidator>
  							        <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                            ControlToValidate="Email" ErrorMessage="Please enter valid email address" 
                                            ForeColor="Red" 
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
  							</div>
                            
  							<div class="form-group">
    								<div class="input-group">
  									<span class="input-group-addon"><span class="glyphicon glyphicon-star">
                                        </span></span>
  									<asp:TextBox ID="password" runat="server" Height="35px" Width="290px" 
                                            class="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
								</div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ErrorMessage="Password Required!" ControlToValidate="password" ForeColor="Red"></asp:RequiredFieldValidator>
  							</div>

                            <div class="form-group">
    								<div class="input-group">
  									<span class="input-group-addon"><span class="glyphicon glyphicon-log-in">
                                        </span></span>
  									<asp:TextBox ID="Rpassword" runat="server" Height="35px" Width="290px" 
                                            class="form-control" TextMode="Password" placeholder="Confirm Password"></asp:TextBox>
								</div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                            ErrorMessage="Retype Password Required!" ControlToValidate="Rpassword" ForeColor="Red"></asp:RequiredFieldValidator>
  							        <br />
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                        ControlToCompare="password" ControlToValidate="Rpassword" 
                                        ErrorMessage="Both Passwords Must Match" ForeColor="Red"></asp:CompareValidator>
  							</div>
  							<hr />                                                    
  							<p>
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="&nbsp;&nbsp;I agree to the " 
                                    CausesValidation="True" />&nbsp;<a href=""><strong>terms.</strong></a> 
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Must Agree to terms" 
                                ClientValidationFunction = "ValidateCheckBox" ForeColor="Red"></asp:CustomValidator>
                                    <br />
                                <asp:Button ID="Register" runat="server" Height="32px" Text="Register" 
                                    Width="126px" class="btn btn-success" onclick="Register_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <input id="Reset1" type="reset" value="Start Over" class="btn btn-primary"/><asp:SqlDataSource 
                                    ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:AdminBookingConnectionString %>" 
                                    SelectCommand="SELECT * FROM [Technician]"></asp:SqlDataSource>
                                <br/></p>
						</form>

                <a href="#">I forgot my password</a><br/>
                <a href="LoginPage.aspx" class="text-center">I already have a membership</a>

    <script type = "text/javascript">
        function ValidateCheckBox(sender, args) {
            if (document.getElementById("<%=CheckBox1.ClientID %>").checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }
    </script>
</asp:Content>