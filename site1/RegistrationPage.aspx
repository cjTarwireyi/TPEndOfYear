 <%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="RegistrationPage.aspx.cs" Inherits="RegistrationPage" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
    
</asp:Content>
 
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    
            

        
    <div class=" col-md-offset-4 main">
        <form runat="server">
        <div class="page-header" style="background-color:azure">
            <h3><asp:Label ID="lblTitle"  runat="server" ForeColor="Red" Text="User   Registration</"></asp:Label>
           </h3>

        </div>
            <div class="row">

            <div class="form-group  col-xs-6">
                <div class="input-group" id="Div1">
                    <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                    
                    <asp:DropDownList ID="userType" runat="server"  Height="35px" Width="290px"
                        class="form-control" placeholder="User Type"></asp:DropDownList>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="UserType Required !" ControlToValidate="userType" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
            </div>
            


        </div>
        <div class="row">

            <div class="form-group  col-xs-6">
                <div class="input-group" id="Div4">
                    <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                    <asp:TextBox ID="empNo" runat="server" Height="35px" Width="290px"
                        class="form-control" placeholder="Employee Number"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                    ErrorMessage="Employee Number Required!" ControlToValidate="empNo" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblErrorEmp" Visible="false" runat="server" ForeColor="Red" Text="invalid employee number"></asp:Label>
            </div>
            


        </div>
        <!----------------------------------------------new row-->
        <div class="row">
            <div class="form-group col-xs-6">
                <div class="input-group" id="Div2">
                    <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                    <asp:TextBox ID="Username" runat="server" Height="35px" Width="290px"
                        class="form-control" placeholder="User Name"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                    ErrorMessage="User Name Required!" ControlToValidate="Username" ForeColor="Red"></asp:RequiredFieldValidator>
                
                <br />
                <asp:Label ID="usernameError" Visible="false" runat="server" ForeColor="Red" Text="Username in use by another user"></asp:Label>
            </div>            
                 <!--           <div class="form-group">-->
            </div>
            <!----------------------------new row-->
             <div class="row" >
                <div class="form-group col-xs-6">
                    <div class="input-group" id="Div11" >
                        <span class="input-group-addon"><span Hidden class="glyphicon glyphicon-star"></span></span>
                        <asp:TextBox ID="oldPass" Enabled="false" runat="server" Height="35px" Width="290px"
                            class="form-control" TextMode="Password" placeholder="Old Password"></asp:TextBox>
                    </div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ErrorMessage="Password Required!" ControlToValidate="oldPass" ForeColor="Red"></asp:RequiredFieldValidator>
                     <asp:Label ID="oldPasWrong" Visible="false" runat="server" ForeColor="Red" Text="Your Old Password is wrong"></asp:Label>
            
                </div>

                
            </div>
            <!--------------------new row--->
             
            <div class="row">
                <div class="form-group col-xs-6">
                    <div class="input-group" id="Div10">
                        <span class="input-group-addon"><span class="glyphicon glyphicon-star"></span></span>
                        <asp:TextBox ID="pword" runat="server" Height="35px" Width="290px"
                            class="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                    </div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ErrorMessage="Password Required!" ControlToValidate="pword" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>

                
            </div>
             <div class="row">
            <div class="form-group col-xs-6">
                    <div class="input-group"id ="Div">
                        <span class="input-group-addon"><span class="glyphicon glyphicon-log-in"></span></span>
                        <asp:TextBox ID="Rpassword" runat="server" Height="35px" Width="290px"
                            class="form-control" TextMode="Password" placeholder="Confirm Password"></asp:TextBox>
                    </div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ErrorMessage="Retype Password Required!" ControlToValidate="Rpassword" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server"
                        ControlToCompare="pword" ControlToValidate="Rpassword"
                        ErrorMessage="Both Passwords Must Match" ForeColor="Red"></asp:CompareValidator>
                </div>
        </div>
        <!-------------------------------new row-->
        <hr />
        <div class="row">
            

            <!--<asp:CheckBox ID="CheckBox1" runat="server" Text="&nbsp;&nbsp;I agree to the "
                CausesValidation="True" />&nbsp;<a href=""><strong>terms.</strong></a>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Must Agree to terms"
                ClientValidationFunction="ValidateCheckBox" ForeColor="Red"></asp:CustomValidator>-->
            <div class="form-group col-xs-6">
            <asp:Button ID="Register" runat="server" Height="32px" Text="Save"
                Width="126px" class="btn btn-success" OnClick="Register_Click" />
             
                                <input id="Reset1" type="reset" value="Cancel" class="btn btn-primary" />
                                <!--<asp:SqlDataSource
                                    ID="SqlDataSource1" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:AdminBookingConnectionString %>"
                                    SelectCommand="SELECT * FROM [Technician]"></asp:SqlDataSource>-->
            </div>


             
        </div>
            </form>
    </div>
  <!--  <script type="text/javascript">
        function ValidateCheckBox(sender, args) {
            if (document.getElementById("<%=CheckBox1.ClientID %>").checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }
    </script>-->
        
</asp:Content>
