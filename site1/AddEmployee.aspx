<%@ Page Title="" Language="C#" MasterPageFile="~/site1/AccessMaster.master" AutoEventWireup="true" CodeFile="AddEmployee.aspx.cs" Inherits="site1_AddEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <form id="form1" runat="server">

        <div class="page-header">
            <h3><strong>Register</strong>Employee</h3>
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
                <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-road"></i></span>
                    <asp:TextBox ID="txtStreet" runat="server" Height="35px" Width="290px"
                        class="form-control" placeholder="Street name"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                    ErrorMessage="Street name Required!" ControlToValidate="txtStreet" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
            </div>


            <div class="form-group">
                <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-home"></i></span>

                    <asp:TextBox ID="txtPostalCode" runat="server" Height="35px" Width="290px"
                        class="form-control" placeholder="Postal Code "></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                    ErrorMessage="Postal code Required!" ControlToValidate="txtStreet" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
            </div>
            <div class="form-group">
                <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-home"></i></span>

                    <asp:TextBox ID="txtSuburb" runat="server" Height="35px" Width="290px"
                        class="form-control" placeholder="Suburb "></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                    ErrorMessage="Suburb Required!" ControlToValidate="txtSuburb" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
            </div>
            <hr />
            <p>

                <asp:Button ID="Register" runat="server" Height="32px" Text="Register"
                    Width="126px" class="btn btn-success" OnClick="Register_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
    </form>

</asp:Content>

