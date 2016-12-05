<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="Roles.aspx.cs" Inherits="site1_Roles" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="sideBarNav" runat="server">
    <div id="sidebar-wrapper">
        <ul class="sidebar-nav nav-pills nav-stacked" id="menu">
            <li><a href="Home.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>
            <asp:Panel ID="AdminLinkPanel" runat="server">
            <li><a href="Users.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Users</a></li>
            <li><a href="Customers.aspx"><i class="glyphicon glyphicon-cog"></i>&nbsp;Customers</a></li>
            <li><a href="Employee.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Employees</a></li>
            <li><a href="Suppliers.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Suppliers</a></li>
            <li><a href="RegistrationPage.aspx"><i class="glyphicon glyphicon-list "></i>&nbsp;Register User</a></li>
            </asp:Panel>
                <li><a href="Reports.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Reports</a></li>
            <li><a href="Orders.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Orders</a></li>
            <li><a href="Products.aspx"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Products</a></li>
            <li class="active"><a href="Purchase.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Purchase</a></li>
            <li><a href="#"><i class="glyphicon glyphicon-envelope"></i>&nbsp;Quick Email..</a></li>
        </ul>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main row">
        <h1><strong>Roles</strong></h1>
        <br />
        <div class="col-lg-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    

                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon"><span class="fa fa-cubes"></span></span>
                            <asp:TextBox ID="txtRole"   runat="server" Width="290px"
                                class="form-control" placeholder="Role Title " ></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ValidationGroup="Group1" ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="Role  Title Required!" ControlToValidate="txtRole" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="lblErrorProd" Visible="false" runat="server" ForeColor="Red" Text="invalid Product Code"></asp:Label>
                    </div>
                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon"><span class="fa fa-cubes"></span></span>
                            <asp:Textbox ID="txtDescription" TextMode="multiline" Columns="50" Rows="5" runat="server" Height="100px" Width="290px"
                                class="form-control" placeholder="Quantity" MaxLength="50" ></asp:Textbox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ErrorMessage="Quantity Required!" ValidationGroup="Group1" ControlToValidate="txtDescription" ForeColor="Red"></asp:RequiredFieldValidator>
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
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="roleId" Height="190px" Width="1080px" AllowSorting="True" AllowPaging="true" GridLines="Vertical" OnRowDeleting="GridView1_RowDeleting" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowUpdated="GridView1_RowUpdated">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField HeaderText="Role Title" DataField="RoleName" />
                                <asp:BoundField HeaderText="Description" DataField="RoleDescription" />
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
                                        </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
