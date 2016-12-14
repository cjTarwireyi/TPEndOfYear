<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="Employee.aspx.cs" Inherits="site1_Employee" %>

<asp:Content ID="Content5" ContentPlaceHolderID="details" runat="Server">
    <div class="loginDisplay">
        <span class="glyphicon glyphicon-user"></span>&nbsp;<asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="Submit" runat="server" class="btn btn-danger "
            Height="35px" Text="Sign Out"
            Width="90px" OnClick="Submit_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">

    <title></title>
    <style type="text/css">
        .cssPager td {
            padding-left: 4px;
            padding-right: 4px;
        }

        .align {
            position: absolute;
            left: 150px;
            width: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="sideBarNav" runat="server">
    <div id="sidebar-wrapper">
        <asp:Panel ID="userPanel" runat="server">
            <ul class="sidebar-nav nav-pills nav-stacked" id="menu">
                <li><a href="Home.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>
                <li><a href="Profile.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;My Profile</a></li>
                <li><a href="Customers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Customers</a></li>
                <li><a href="Orders.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Orders</a></li>
                <li><a href="Products.aspx"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Products</a></li>
                <li><a href="Returns.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Item Returns</a></li>
                <li><a href="Purchase.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Purchase</a></li>
                <li><a href="Suppliers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Suppliers</a></li>
            </ul>
        </asp:Panel>
        <asp:Panel ID="AdminLinkPanel" runat="server">
            <ul class="sidebar-nav nav-pills nav-stacked" id="menu2">
                <li><a href="Home.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>
                <li><a href="Profile.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;My Profile</a></li>
                <li><a href="productAnalysis.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Reports</a></li>
                <li><a href="Orders.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Orders</a></li>
                <li><a href="Products.aspx"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Products</a></li>
                <li><a href="Returns.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Item Returns</a></li>
                <li><a href="Purchase.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Purchase</a></li>
                <li><a href="Users.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Users</a></li>
                <li><a href="Roles.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Roles</a></li>
                <li><a href="Customers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Customers</a></li>
                <li class="active"><a href="Employee.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Employees</a></li>
                <li><a href="Suppliers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Suppliers</a></li>
                <li><a href="TimeSheet.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;TimeSheet</a></li>
                <li><a href="RegistrationPage.aspx"><i class="glyphicon glyphicon-user "></i>&nbsp;Register User</a></li>
            </ul>
        </asp:Panel>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="  main">
        <h1 align="center"><strong>Employees</strong></h1>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="topCorner">
                    <asp:TextBox ID="txtSearch" AutoPostBack="true" runat="server" Type="Integer" placeholder="Enter OrderID" Width="131px" OnTextChanged="dgrvData_Filter"></asp:TextBox><asp:Button ID="btnSearch" runat="server" Text="Search" Height="23px" Width="63px" OnClick="btnSearch_Click" /><br />
                </div>

                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" CellPadding="4" AutoGenerateColumns="False" DataKeyNames="EmployeeID" AllowPaging="true" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" Height="175px" Width="1080px" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" GridLines="Horizontal" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <PagerStyle CssClass="cssPager" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="EmployeeID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="EmployeeID" />
                        <asp:BoundField DataField="EmployeeName" HeaderText="Name" SortExpression="EmployeeName" />
                        <asp:BoundField DataField="EmployeeSurname" HeaderText="Surname" SortExpression="EmployeeSurname" />
                        <asp:BoundField DataField="EmployeeCellNumber" HeaderText="CellNumber" SortExpression="EmployeeCellNumber" />
                        <asp:BoundField DataField="EmployeeStreetName" HeaderText="StreetName" SortExpression="EmployeeStreetName" />
                        <asp:BoundField DataField="EmployeeSuburb" HeaderText="Suburb" SortExpression="EmployeeSuburb" />
                        <asp:BoundField DataField="EmployeePostalCode" HeaderText="PostalCode" SortExpression="EmployeePostalCode" />
                        <asp:BoundField DataField="DateHired" HeaderText="DateHired" SortExpression="DateHired" />
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
                <br />
                <asp:Button ID="Register" runat="server" Height="32px" Text="Register New"
                    Width="126px" class="btn btn-success"
                    data-toggle="tooltip" data-placement="left"
                    title="Insert new tecnician to database" OnClick="Register_Click" /><br />
                <br />

                <asp:Button ID="btnSetDays" runat="server" Height="32px" Text="Set Days Off"
                    Width="126px" class="btn btn-primary"
                    OnClick="btnSetDays_Click" data-toggle="modal" data-target="#myModal" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>


    <div id="myModal" class="modal fade" role="dialog" data-backdrop="false">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button><br />
                    <h4 class="modal-title" align="center">Employee Allocated Leave</h4>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div align="center">
                                <asp:Label ID="lblID" runat="server" Text="No Employee Selected"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="Label2" runat="server" Text="Allocated Leave Days: "></asp:Label><asp:TextBox ID="txtLeaveDays" runat="server" CssClass="align"></asp:TextBox><br />
                                <br />
                                <asp:Label ID="Label3" runat="server" Text="Sick Days: "></asp:Label><asp:TextBox ID="txtSickDays" runat="server" CssClass="align"></asp:TextBox><br />
                                <br />
                                <asp:Label ID="Label4" runat="server" Text="Religious Days:: "></asp:Label><asp:TextBox ID="txtReligiousDays" runat="server" CssClass="align"></asp:TextBox>
                            </div>
                            <div align="center">
                                <asp:Button ID="btnHolidays" runat="server" Text="Set Holidays" OnClick="btnHolidays_Click" /><br />
                                <asp:Label ID="lblAppproved" runat="server" Text="Approved" Visible="false"></asp:Label>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
