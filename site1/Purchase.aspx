<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="Purchase.aspx.cs" Inherits="site1_Purchase" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="details" runat="Server">
    <div class="loginDisplay">
        <span class="glyphicon glyphicon-user"></span>&nbsp;<asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="Submit" runat="server" class="btn btn-danger "
            Height="35px" Text="Sign Out"
            Width="90px" OnClick="Logout" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="sideBarNav" runat="server">
    <div id="sidebar-wrapper">
        <asp:Panel ID="userPanel" runat="server">
            <ul class="sidebar-nav nav-pills nav-stacked" id="menu">
                <li><a href="Home.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>
                <li><a href="Customers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Customers</a></li>
                <li><a href="Orders.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Orders</a></li>
                <li><a href="Products.aspx"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Products</a></li>
                <li><a href="Returns.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Item Returns</a></li>
                <li class="active"><a href="Purchase.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Purchase</a></li>
                <li><a href="Suppliers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Suppliers</a></li>
            </ul>
        </asp:Panel>
        <asp:Panel ID="AdminLinkPanel" runat="server">
            <ul class="sidebar-nav nav-pills nav-stacked" id="menu2">
                <li><a href="Home.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>
                <li ><a href="productAnalysis.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Reports</a></li>
                <li><a href="Orders.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Orders</a></li>
                <li><a href="Products.aspx"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Products</a></li>
                <li><a href="Returns.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Item Returns</a></li>
                <li class="active"><a href="Purchase.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Purchase</a></li>
                <li><a href="Users.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Users</a></li>
                <li><a href="Roles.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Roles</a></li>
                <li><a href="Customers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Customers</a></li>
                <li><a href="Employee.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Employees</a></li>
                <li><a href="Suppliers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Suppliers</a></li>
                <li><a href="TimeSheet.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;TimeSheet</a></li>
                <li><a href="RegistrationPage.aspx"><i class="glyphicon glyphicon-user "></i>&nbsp;Register User</a></li>
            </ul>
        </asp:Panel>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main row">
        <h1><strong>Purchase</strong>Order</h1>
        <br />
        <div class="col-lg-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon"><span class="fa fa-cubes"></span></span>
                            <%--  --%>
                            <asp:DropDownList ID="custList" runat="server" Height="35px" Width="290px"
                                class="form-control" placeholder="Customer">
                            </asp:DropDownList>

                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ErrorMessage="Customer Required!" ValidationGroup="Group1" ControlToValidate="custList" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="custError" Visible="false" runat="server" ForeColor="Red" Text="invalid Customer Code"></asp:Label>
                    </div>

                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon"><span class="fa fa-cubes"></span></span>
                            <asp:TextBox ID="txtProductID" runat="server" Width="290px"
                                class="form-control" placeholder="Product Code " OnTextChanged="txtProductID_TextChanged"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ValidationGroup="Group1" ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="ProductID Required!" ControlToValidate="txtProductID" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lblErrorProd" Visible="false" runat="server" ForeColor="Red" Text="invalid Product Code"></asp:Label>
                    </div>
                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon"><span class="fa fa-cubes"></span></span>
                            <asp:TextBox ID="txtQuantiy" runat="server" Height="35px" Width="290px"
                                class="form-control" placeholder="Quantity" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ErrorMessage="Quantity Required!" ValidationGroup="Group1" ControlToValidate="txtQuantiy" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                    </div>
                    <asp:Button ID="btnAdd" ValidationGroup="Group1" runat="server" Height="32px" Text="Add"
                        Width="126px" class="btn btn-success" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnSubmit" runat="server" Height="32px" Text="Submit"
                        Width="126px" class="btn btn-success" OnClick="Submit_Click" />

                    <asp:Button ID="btnCancel" runat="server" Height="32px" Text="Cancel Order"
                        Width="126px" class="btn btn-danger" OnClick="Cancel_Click" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="col-lg-6">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView runat="server" ID="GridView1" ShowHeaderWhenEmpty="True" align="right" CellPadding="4" ForeColor="#333333" Width="557px" AutoGenerateColumns="False" OnRowDataBound="OnRowDataBound" OnRowDeleting="GridView1_RowDeleting">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField HeaderText="ProductCode" DataField="ProductCode" />
                                <asp:BoundField HeaderText="Product" DataField="Product" />
                                <asp:BoundField HeaderText="Price" DataField="Price" />
                                <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>

                        </div>
                      <asp:Label ID="totalAmt" runat="server" Text=""></asp:Label><asp:Label ID="grandTotal" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
