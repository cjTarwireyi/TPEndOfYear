<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="site1_Orders" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="/Scripts/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="/Scripts/bootstrap.js"></script>

    <script type="text/javascript" src="/Scripts/bootstrap.min.js"></script>
    <title></title>
    <style type="text/css">
        .cssPager td {
            padding-left: 4px;
            padding-right: 4px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="details" runat="Server">
    <div class="loginDisplay">
        <span class="glyphicon glyphicon-user"></span>&nbsp;<asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="Submit" runat="server" class="btn btn-danger "
            Height="35px" Text="Sign Out"
            Width="90px" OnClick="Submit_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="sideBarNav" runat="server">
    <div id="sidebar-wrapper">
        <ul class="sidebar-nav nav-pills nav-stacked" id="menu">
            <li><a href="Home.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>
            <asp:Panel ID="AdminLinkPanel" runat="server">
            <li><a href="Users.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Users</a></li>
            <li><a href="Customers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Customers</a></li>
            <li><a href="Employee.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Employees</a></li>
            <li><a href="Suppliers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Suppliers</a></li>
            <li><a href="RegistrationPage.aspx"><i class="glyphicon glyphicon-user "></i>&nbsp;Register User</a></li>
                </asp:Panel>
            <li><a href="Reports.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Reports</a></li>
            <li class="active"><a href="Orders.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Orders</a></li>
            <li><a href="Products.aspx"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Products</a></li>
            <li><a href="Purchase.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Purchase</a></li>
            <li><a href="#"><i class="glyphicon glyphicon-envelope"></i>&nbsp;Quick Email..</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <div class="  main">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="topCorner">
                    <asp:TextBox ID="txtSearch" AutoPostBack="true" runat="server" placeholder="Enter OrderID" Width="131px" onkeypress="__doPostBack(this.name,'OnKeyPress');" OnTextChanged="dgrvData_Filter"></asp:TextBox><asp:Button ID="btnSearch" runat="server" Text="Search" Height="23px" Width="63px" OnClick="btnSearch_Click" />
                </div>
                <h1><strong>Monthly</strong>Orders</h1>
                Year<br />
                <asp:TextBox ID="txtYear" runat="server" Height="18px" Width="83px" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"></asp:TextBox><br />
                <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="128px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" OnTextChanged="DropDownList1_TextChanged">
                    <asp:ListItem Value="01">January</asp:ListItem>
                    <asp:ListItem Value="02">February</asp:ListItem>
                    <asp:ListItem Value="03">March</asp:ListItem>
                    <asp:ListItem Value="04">April</asp:ListItem>
                    <asp:ListItem Value="05">May</asp:ListItem>
                    <asp:ListItem Value="06">June</asp:ListItem>
                    <asp:ListItem Value="07">July</asp:ListItem>
                    <asp:ListItem Value="08">August</asp:ListItem>
                    <asp:ListItem Value="09">September</asp:ListItem>
                    <asp:ListItem Value="10">October</asp:ListItem>
                    <asp:ListItem Value="11">November</asp:ListItem>
                    <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList><br />
                <br />
                <asp:Panel ID="Panel1" runat="server" Width="807px">
                    <asp:RadioButton ID="RadioButton1" runat="server" Value="True" Text="Paid" AutoPostBack="True" GroupName="status" OnCheckedChanged="RadioButton1_CheckedChanged" /><br />
                    <asp:RadioButton ID="RadioButton2" runat="server" Value="False" Text="Outstanding" AutoPostBack="True" GroupName="status" Checked="True" OnCheckedChanged="RadioButton2_CheckedChanged" />
                    <asp:GridView ID="GridView1" runat="server" Width="1337px" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="orderId" ForeColor="#333333" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging1" Height="280px">
                        <PagerStyle CssClass="cssPager" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="orderId" HeaderText="orderId" InsertVisible="False" ReadOnly="True" SortExpression="orderId" />
                            <asp:BoundField DataField="custId" HeaderText="custId" SortExpression="custId" />
                            <asp:CheckBoxField DataField="payed" HeaderText="payed" SortExpression="payed" />
                            <asp:BoundField DataField="amount" HeaderText="amount" SortExpression="amount" />
                            <asp:BoundField DataField="orderDate" HeaderText="orderDate" SortExpression="orderDate" />
                            <asp:BoundField DataField="employeeId" HeaderText="employeeId" SortExpression="employeeId" />
                            <asp:BoundField DataField="orderCode" HeaderText="orderCode" SortExpression="orderCode" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <br />
                    <asp:Button ID="btnAdd" ValidationGroup="Group1" runat="server" Height="32px" Text="Update Order"
                        Width="126px" class="btn btn-primary" OnClick="btnAdd_Click" />
                    &nbsp;&nbsp;<asp:Button ID="btnViewOrder" ValidationGroup="Group1" runat="server" Height="32px" Text="View Orders"
                        Width="126px" class="btn btn-primary" OnClick="btnViewOrder_Click" data-toggle="modal" data-target="#myModal" />
                    <div class="modal-dialog">
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!-- Modal -->
    <%--<div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Customer Puchased Items</h4>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" Width="450px">
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>--%>
    <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>

    <div id="myModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Modal Header</h4>
      </div>
      <div class="modal-body">
        <p>Some text in the modal.</p>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>
</asp:Content>
