<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="Customers.aspx.cs" Inherits="site1_customer_Customers" %>

<%-- Add content controls here --%>
<asp:Content ID="Content5" ContentPlaceHolderID="details" Runat="Server">
     <div class="loginDisplay">
        <span class="glyphicon glyphicon-user"></span>&nbsp;<asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label> 
            <asp:Button ID="Submit" runat="server" class="btn btn-danger " 
            Height="35px" Text="Sign Out" 
                                Width="90px" onclick="Submit_Click"/>  
         </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="sideBarNav" runat="server">
   <div id="sidebar-wrapper">
       <ul class="sidebar-nav nav-pills nav-stacked" id="menu">
           <li ><a href="Home.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>
           <li><a href="Users.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Users</a></li>
           <li class="active"><a href="Customers.aspx"><i class="glyphicon glyphicon-cog"></i>&nbsp;Customers</a></li>
           <li><a href="Employee.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Employees</a></li>
           <li><a href="RegistrationPage.aspx"><i class="glyphicon glyphicon-list "></i>&nbsp;Register User</a></li>
           <li><a href="Reports.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Reports</a></li>
           <li><a href="AddOrder.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Order</a></li>
           <li><a href="Products.aspx"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Products</a></li>
           <li><a href="#"><i class="glyphicon glyphicon-time"></i>&nbsp;Real-time</a></li>
           <li><a href="#"><i class="glyphicon glyphicon-envelope"></i>&nbsp;Quick Email..</a></li>
        </ul>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    
        <div class="  main">
    <h1><strong>Customers</strong></h1>
<br />
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
       ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        OldValuesParameterFormatString="original_{0}" 
        SelectCommand="SELECT * FROM [Customers]">
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource2" AutoGenerateColumns="False" DataKeyNames="CustomerID" Height="63px" Width="724px" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="CustomerID" HeaderText="Customer" InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" />
            <asp:BoundField DataField="CustomerName" HeaderText="Name" SortExpression="CustomerName" />
            <asp:BoundField DataField="CustomerSurname" HeaderText="Surname" SortExpression="CustomerSurname" />
            <asp:BoundField DataField="CustomerCellNumber" HeaderText="CellNumber" SortExpression="CustomerCellNumber" />
            <asp:BoundField DataField="CustomerEmail" HeaderText="Email" SortExpression="CustomerEmail" />
            <asp:BoundField DataField="CustomerStreetName" HeaderText="StreetName" SortExpression="CustomerStreetName" />
            <asp:BoundField DataField="CustomerSuburb" HeaderText="Suburb" SortExpression="CustomerSuburb" />
            <asp:BoundField DataField="CustomerPostalCode" HeaderText="PostalCode" SortExpression="CustomerPostalCode" />
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
       </asp:GridView><br />
       <asp:Button ID="Register" runat="server" Height="32px" Text="Register New" 
            Width="126px" class="btn btn-success" 
            data-toggle="tooltip" data-placement="left" 
            title="Insert new tecnician to database" onclick="Register_Click"/>
   </div>
   
</asp:Content>


