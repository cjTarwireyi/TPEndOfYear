<%@ Page Title="" Language="C#" MasterPageFile="~/site1/AccessMaster.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="site1_AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <form id="form1" runat="server">
        <div class="page-header">
            <h3><strong>Add</strong>Product</h3>
        </div>
        <div class="form-group">
            <div class="input-group">
                <span class="input-group-addon"><span class="fa fa-info"></span></span>
                <asp:TextBox ID="txtName" runat="server" Height="35px" Width="290px"
                    class="form-control" placeholder="Product Name"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ErrorMessage="Product Name Required!" ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        </div>

        <div class="form-group">
            <div class="input-group" id="Name">
                <span class="input-group-addon"><span class="fa fa-info"></span></span>
                <asp:TextBox ID="txtDescription" runat="server" Height="35px" Width="290px"
                    class="form-control" placeholder="Description"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ErrorMessage="Equipment description Required!" ControlToValidate="txtDescription" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        </div>

        <div class="form-group">
            <div class="input-group" >
                <span class="input-group-addon"><span class="fa fa-cubes"></span></span>
                <asp:TextBox ID="txtPrice" runat="server" Height="35px" Width="290px"
                    class="form-control" placeholder="Price" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                ErrorMessage="Price Required!" ControlToValidate="txtPrice" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        </div>

        <div class="form-group">
            <div class="input-group" id="Div2">
                <span class="input-group-addon"><span class="fa fa-cubes"></span></span>
                <asp:TextBox ID="txtQuantity" runat="server" Height="35px" Width="290px"
                    class="form-control" placeholder="Quantity" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                ErrorMessage="Quantity Required!" ControlToValidate="txtQuantity" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        </div>
        <div class="form-group">
            <div class="input-group" id="Div3">
                <span class="input-group-addon"><span class="fa fa-users"></span></span>
                <asp:DropDownList ID="txtSupplierID" runat="server" Height="30px"
                    Width="132px">
                </asp:DropDownList>
                <asp:Label ID="Label1" runat="server" Text="Supplier ID"></asp:Label>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                ErrorMessage="Supplier ID Required!" ControlToValidate="txtSupplierID" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtSupplierID" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
            <br />
        </div>
        <hr />
        <p>
            <br />
            <asp:Button ID="btnAdd" runat="server" Height="35px" Text="Register"
                Width="290px" class="btn btn-success" OnClick="btnAdd_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;              
             <br />
        </p>
    </form>
</asp:Content>

