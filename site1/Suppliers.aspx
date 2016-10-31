<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="Suppliers.aspx.cs" Inherits="site1_Suppliers" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>

 <asp:Content ID="Content5" ContentPlaceHolderID="details" Runat="Server">
     <div class="loginDisplay">
        <span class="glyphicon glyphicon-user"></span>&nbsp;<asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label> 
            <asp:Button ID="Submit" runat="server" class="btn btn-danger " 
            Height="35px" Text="Sign Out" 
                                Width="90px" onclick="Submit_Click"/>  
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
            <li  ><a href="RegistrationPage.aspx"><i class="glyphicon glyphicon-user "></i>&nbsp;Register User</a></li>
            <li><a href="Reports.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Reports</a></li>
            <li><a href="Orders.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Orders</a></li>
            <li><a href="Products.aspx"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Products</a></li>
            <li><a href="Purchase.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Purchase</a></li>
            <li><a href="#"><i class="glyphicon glyphicon-envelope"></i>&nbsp;Quick Email..</a></li>
        </ul>
    </div>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    
            <div class=" main" style="height:inherit">
            <h1><strong>Suppliers</strong></h1><br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Suppliers] WHERE [SupplierID] = @original_SupplierID AND (([SupplierName] = @original_SupplierName) OR ([SupplierName] IS NULL AND @original_SupplierName IS NULL)) AND (([SupplierSurname] = @original_SupplierSurname) OR ([SupplierSurname] IS NULL AND @original_SupplierSurname IS NULL)) AND (([SupplierCellNumber] = @original_SupplierCellNumber) OR ([SupplierCellNumber] IS NULL AND @original_SupplierCellNumber IS NULL)) AND (([SupplierStreetName] = @original_SupplierStreetName) OR ([SupplierStreetName] IS NULL AND @original_SupplierStreetName IS NULL)) AND (([SupplierSuburb] = @original_SupplierSuburb) OR ([SupplierSuburb] IS NULL AND @original_SupplierSuburb IS NULL)) AND (([SupplierPostalCode] = @original_SupplierPostalCode) OR ([SupplierPostalCode] IS NULL AND @original_SupplierPostalCode IS NULL))" InsertCommand="INSERT INTO [Suppliers] ([SupplierName], [SupplierSurname], [SupplierCellNumber], [SupplierStreetName], [SupplierSuburb], [SupplierPostalCode]) VALUES (@SupplierName, @SupplierSurname, @SupplierCellNumber, @SupplierStreetName, @SupplierSuburb, @SupplierPostalCode)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Suppliers]" UpdateCommand="UPDATE [Suppliers] SET [SupplierName] = @SupplierName, [SupplierSurname] = @SupplierSurname, [SupplierCellNumber] = @SupplierCellNumber, [SupplierStreetName] = @SupplierStreetName, [SupplierSuburb] = @SupplierSuburb, [SupplierPostalCode] = @SupplierPostalCode WHERE [SupplierID] = @original_SupplierID AND (([SupplierName] = @original_SupplierName) OR ([SupplierName] IS NULL AND @original_SupplierName IS NULL)) AND (([SupplierSurname] = @original_SupplierSurname) OR ([SupplierSurname] IS NULL AND @original_SupplierSurname IS NULL)) AND (([SupplierCellNumber] = @original_SupplierCellNumber) OR ([SupplierCellNumber] IS NULL AND @original_SupplierCellNumber IS NULL)) AND (([SupplierStreetName] = @original_SupplierStreetName) OR ([SupplierStreetName] IS NULL AND @original_SupplierStreetName IS NULL)) AND (([SupplierSuburb] = @original_SupplierSuburb) OR ([SupplierSuburb] IS NULL AND @original_SupplierSuburb IS NULL)) AND (([SupplierPostalCode] = @original_SupplierPostalCode) OR ([SupplierPostalCode] IS NULL AND @original_SupplierPostalCode IS NULL))">
                <DeleteParameters>
                    <asp:Parameter Name="original_SupplierID" Type="Int32" />
                    <asp:Parameter Name="original_SupplierName" Type="String" />
                    <asp:Parameter Name="original_SupplierSurname" Type="String" />
                    <asp:Parameter Name="original_SupplierCellNumber" Type="String" />
                    <asp:Parameter Name="original_SupplierStreetName" Type="String" />
                    <asp:Parameter Name="original_SupplierSuburb" Type="String" />
                    <asp:Parameter Name="original_SupplierPostalCode" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="SupplierName" Type="String" />
                    <asp:Parameter Name="SupplierSurname" Type="String" />
                    <asp:Parameter Name="SupplierCellNumber" Type="String" />
                    <asp:Parameter Name="SupplierStreetName" Type="String" />
                    <asp:Parameter Name="SupplierSuburb" Type="String" />
                    <asp:Parameter Name="SupplierPostalCode" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="SupplierName" Type="String" />
                    <asp:Parameter Name="SupplierSurname" Type="String" />
                    <asp:Parameter Name="SupplierCellNumber" Type="String" />
                    <asp:Parameter Name="SupplierStreetName" Type="String" />
                    <asp:Parameter Name="SupplierSuburb" Type="String" />
                    <asp:Parameter Name="SupplierPostalCode" Type="String" />
                    <asp:Parameter Name="original_SupplierID" Type="Int32" />
                    <asp:Parameter Name="original_SupplierName" Type="String" />
                    <asp:Parameter Name="original_SupplierSurname" Type="String" />
                    <asp:Parameter Name="original_SupplierCellNumber" Type="String" />
                    <asp:Parameter Name="original_SupplierStreetName" Type="String" />
                    <asp:Parameter Name="original_SupplierSuburb" Type="String" />
                    <asp:Parameter Name="original_SupplierPostalCode" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="SupplierID" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" Width="797px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="SupplierID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="SupplierID" />
                    <asp:BoundField DataField="SupplierName" HeaderText="Name" SortExpression="SupplierName" />
                    <asp:BoundField DataField="SupplierSurname" HeaderText="Surname" SortExpression="SupplierSurname" />
                    <asp:BoundField DataField="SupplierCellNumber" HeaderText="CellNumber" SortExpression="SupplierCellNumber" />
                    <asp:BoundField DataField="SupplierStreetName" HeaderText="StreetNumber" SortExpression="SupplierStreetName" />
                    <asp:BoundField DataField="SupplierSuburb" HeaderText="Suburb" SortExpression="SupplierSuburb" />
                    <asp:BoundField DataField="SupplierPostalCode" HeaderText="PostalCode" SortExpression="SupplierPostalCode" />
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
            </asp:GridView><br />
            <asp:Button ID="Register" runat="server" Height="32px" Text="Register New" 
            Width="126px" class="btn btn-success" 
            data-toggle="tooltip" data-placement="left" 
            title="Insert new tecnician to database" onclick="Register_Click"/>
        </div>
   
</asp:Content>
