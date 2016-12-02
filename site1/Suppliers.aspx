<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="Suppliers.aspx.cs" Inherits="site1_Suppliers" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="details" runat="Server">
    <div class="loginDisplay">
        <span class="glyphicon glyphicon-user"></span>&nbsp;<asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="Submit" runat="server" class="btn btn-danger "
            Height="35px" Text="Sign Out"
            Width="90px" OnClick="Submit_Click" />
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="sideBarNav" runat="server">
    <div id="sidebar-wrapper">
        <ul class="sidebar-nav nav-pills nav-stacked" id="menu">
            <li><a href="Home.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>

            <li><a href="Users.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Users</a></li>
            <li><a href="Customers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Customers</a></li>
            <li><a href="Employee.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Employees</a></li>
            <li class="active"><a href="Suppliers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Suppliers</a></li>
            <li><a href="RegistrationPage.aspx"><i class="glyphicon glyphicon-user "></i>&nbsp;Register User</a></li>
            <li><a href="Reports.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Reports</a></li>
            <li><a href="Orders.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Orders</a></li>
            <li><a href="Products.aspx"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Products</a></li>
            <li><a href="Purchase.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Purchase</a></li>
            <li><a href="#"><i class="glyphicon glyphicon-envelope"></i>&nbsp;Quick Email..</a></li>
        </ul>
    </div>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <div>
        <h1><strong>Suppliers</strong></h1>
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="SupplierID" AllowPaging="True" GridLines="Vertical" Height="100px" Width="1337px" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AllowSorting="True" CellPadding="4" ForeColor="#333333">
                    <PagerStyle CssClass="cssPager" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="SupplierID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="SupplierID" />
                        <asp:BoundField DataField="SupplierName" HeaderText="Name" SortExpression="SupplierName" />
                        <asp:BoundField DataField="SupplierSurname" HeaderText="Surname" SortExpression="SupplierSurname" />
                        <asp:BoundField DataField="SupplierCellNumber" HeaderText="CellNumber" SortExpression="SupplierCellNumber" />
                        <asp:BoundField DataField="SupplierStreetName" HeaderText="StreetNumber" SortExpression="SupplierStreetName" />
                        <asp:BoundField DataField="SupplierSuburb" HeaderText="Suburb" SortExpression="SupplierSuburb" />
                        <asp:BoundField DataField="SupplierPostalCode" HeaderText="PostalCode" SortExpression="SupplierPostalCode" />
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
                <div style="height: 66px">
                <br /><br /><asp:Button ID="Register" runat="server" Height="32px" Text="Register New"
                    Width="126px" class="btn btn-success"
                    data-toggle="tooltip" data-placement="left"
                    title="Insert new tecnician to database" OnClick="Register_Click" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
