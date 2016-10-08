<%@ Page Title="" Language="C#" MasterPageFile="~/site1/AccessMaster.master" AutoEventWireup="true" CodeFile="AddCustomer.aspx.cs" Inherits="site1_AddCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <form id="form1" runat="server">
        <div class="page-header">
            <h3><strong>Add</strong>Customer</h3>
        </div>
        <div class="form-group">
            <div class="input-group" id="Name">
                <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                <asp:TextBox ID="txtName" runat="server" Height="35px" Width="290px"
                    class="form-control" placeholder="Name"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ErrorMessage="Name Required!" ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        </div>
        <div class="form-group">
            <div class="input-group" id="Div2">
                <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                <asp:TextBox ID="txtSurname" runat="server" Height="35px" Width="290px"
                    class="form-control" placeholder="Surname"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                ErrorMessage="Surname Required!" ControlToValidate="txtSurname" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        </div>
        <div class="form-group">
            <div class="input-group" id="Div3">
                <span class="input-group-addon"><span class="glyphicon glyphicon-phone"></span></span>
                <asp:TextBox ID="txtCellNumber" runat="server" Height="35px" Width="290px"
                    class="form-control" placeholder="Phone Number e.g (072)111-2223"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                ErrorMessage="Phone Number Required!" ControlToValidate="txtCellNumber" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                ControlToValidate="txtCellNumber" ErrorMessage="Invalid Phone Number e.g (072)111-2223" ForeColor="Red"
                ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
            <br />
        </div>
        <div class="form-group">
            <div class="input-group" id="Div1">
                <span class="input-group-addon"><span class="fa fa-road"></span></span>
                <asp:TextBox ID="txtStreetName" runat="server" Height="35px" Width="290px"
                    class="form-control" placeholder="Street Name"></asp:TextBox>

            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                ErrorMessage="Street name Required!" ControlToValidate="txtStreetName" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        </div>

        <div class="form-group">
            <div class="input-group">
                <span class="input-group-addon"><span class="fa fa-home"></span></span>
                <asp:TextBox ID="txtSuburb" runat="server" Height="35px" Width="290px"
                    class="form-control" placeholder="Street name"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                ErrorMessage="Suburb Required!" ControlToValidate="txtSuburb" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        </div>


        <div class="form-group">
            <div class="input-group">
                <span class="input-group-addon"><span class="fa fa-home"></span></span>

                <asp:TextBox ID="txtPostalCode" runat="server" Height="35px" Width="290px"
                    class="form-control" placeholder="Postal Code "></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                ErrorMessage="Postal code Required!" ControlToValidate="txtPostalCode" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        </div>
        <hr />
        <p>
            <br />
            <asp:Button ID="btnAdd" runat="server" Height="32px" Text="Register"
                Width="126px" class="btn btn-success" OnClick="btnAdd_Click" />
    </form>
</asp:Content>

