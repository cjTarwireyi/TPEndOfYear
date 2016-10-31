<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="site1_Products" %>

<%-- Add content controls here --%>
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
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    
        <div class="  main">
             <h1><strong>Products</strong></h1>
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Products] WHERE [Id] = @original_Id AND (([ProductName] = @original_ProductName) OR ([ProductName] IS NULL AND @original_ProductName IS NULL)) AND (([ProductDescription] = @original_ProductDescription) OR ([ProductDescription] IS NULL AND @original_ProductDescription IS NULL)) AND (([Price] = @original_Price) OR ([Price] IS NULL AND @original_Price IS NULL)) AND (([Quantity] = @original_Quantity) OR ([Quantity] IS NULL AND @original_Quantity IS NULL)) AND (([DateArrived] = @original_DateArrived) OR ([DateArrived] IS NULL AND @original_DateArrived IS NULL)) AND (([SupplierID] = @original_SupplierID) OR ([SupplierID] IS NULL AND @original_SupplierID IS NULL))" InsertCommand="INSERT INTO [Products] ([ProductName], [ProductDescription], [Price], [Quantity], [DateArrived], [SupplierID]) VALUES (@ProductName, @ProductDescription, @Price, @Quantity, @DateArrived, @SupplierID)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [Id], [ProductName], [ProductDescription], [Price], [Quantity], [DateArrived], [SupplierID] FROM [Products] WHERE ([Active] &lt;&gt; @Active)" UpdateCommand="UPDATE [Products] SET [ProductName] = @ProductName, [ProductDescription] = @ProductDescription, [Price] = @Price, [Quantity] = @Quantity, [DateArrived] = @DateArrived, [SupplierID] = @SupplierID WHERE [Id] = @original_Id AND (([ProductName] = @original_ProductName) OR ([ProductName] IS NULL AND @original_ProductName IS NULL)) AND (([ProductDescription] = @original_ProductDescription) OR ([ProductDescription] IS NULL AND @original_ProductDescription IS NULL)) AND (([Price] = @original_Price) OR ([Price] IS NULL AND @original_Price IS NULL)) AND (([Quantity] = @original_Quantity) OR ([Quantity] IS NULL AND @original_Quantity IS NULL)) AND (([DateArrived] = @original_DateArrived) OR ([DateArrived] IS NULL AND @original_DateArrived IS NULL)) AND (([SupplierID] = @original_SupplierID) OR ([SupplierID] IS NULL AND @original_SupplierID IS NULL))">
                <DeleteParameters>
                    <asp:Parameter Name="original_Id" Type="Int32" />
                    <asp:Parameter Name="original_ProductName" Type="String" />
                    <asp:Parameter Name="original_ProductDescription" Type="String" />
                    <asp:Parameter Name="original_Price" Type="Double" />
                    <asp:Parameter Name="original_Quantity" Type="Int32" />
                    <asp:Parameter Name="original_DateArrived" Type="DateTime" />
                    <asp:Parameter Name="original_SupplierID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="ProductName" Type="String" />
                    <asp:Parameter Name="ProductDescription" Type="String" />
                    <asp:Parameter Name="Price" Type="Double" />
                    <asp:Parameter Name="Quantity" Type="Int32" />
                    <asp:Parameter Name="DateArrived" Type="DateTime" />
                    <asp:Parameter Name="SupplierID" Type="Int32" />
                </InsertParameters>
                <SelectParameters>
                    <asp:Parameter DefaultValue="False" Name="Active" Type="Boolean" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="ProductName" Type="String" />
                    <asp:Parameter Name="ProductDescription" Type="String" />
                    <asp:Parameter Name="Price" Type="Double" />
                    <asp:Parameter Name="Quantity" Type="Int32" />
                    <asp:Parameter Name="DateArrived" Type="DateTime" />
                    <asp:Parameter Name="SupplierID" Type="Int32" />
                    <asp:Parameter Name="original_Id" Type="Int32" />
                    <asp:Parameter Name="original_ProductName" Type="String" />
                    <asp:Parameter Name="original_ProductDescription" Type="String" />
                    <asp:Parameter Name="original_Price" Type="Double" />
                    <asp:Parameter Name="original_Quantity" Type="Int32" />
                    <asp:Parameter Name="original_DateArrived" Type="DateTime" />
                    <asp:Parameter Name="original_SupplierID" Type="Int32" />
                </UpdateParameters>
             </asp:SqlDataSource>
            <asp:GridView ID="gridView1" runat="server" AutoGenerateColumns="False"  CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource1" Align="Center" ForeColor="#333333" Width="785px" AllowSorting="True" Height="72px" HorizontalAlign="Justify">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" InsertVisible="False" />
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                    <asp:BoundField DataField="ProductDescription" HeaderText="ProductDescription" SortExpression="ProductDescription" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                    <asp:BoundField DataField="DateArrived" HeaderText="DateArrived" SortExpression="DateArrived" ReadOnly="True" />
                    <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" SortExpression="SupplierID" />
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
             <asp:Button ID="Register" runat="server" Height="32px" Text="Add Product" 
            Width="126px" class="btn btn-success" 
            data-toggle="tooltip" data-placement="left" 
            title="Insert new tecnician to database" onclick="Register_Click"/>&nbsp;&nbsp;
             <asp:Button ID="btnInactive" runat="server" Height="32px" Text="Inactive Products" 
            Width="145px" class="btn btn-warning" 
            data-toggle="tooltip" data-placement="left" 
            title="Insert new tecnician to database" onclick="InactiveRecords"/>&nbsp;&nbsp;
             <asp:Button ID="btnDeactivate" runat="server" Height="32px" Text="Deactivate Product" 
            Width="155px" class="btn btn-danger" 
            data-toggle="tooltip" data-placement="left" 
            title="Insert new tecnician to database" OnClick="btnDeactivate_Click" />
        </div>
    </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="sideBarNav" runat="server">
    <div id="sidebar-wrapper">
        <ul class="sidebar-nav nav-pills nav-stacked" id="menu">
            <li><a href="Home.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>
            <li><a href="Users.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Users</a></li>
            <li><a href="Customers.aspx"><i class="glyphicon glyphicon-cog"></i>&nbsp;Customers</a></li>
            <li><a href="Employee.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Employees</a></li>
            <li><a href="RegistrationPage.aspx"><i class="glyphicon glyphicon-list "></i>&nbsp;Register User</a></li>
            <li><a href="Reports.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Reports</a></li>
            <li><a href="Orders.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Orders</a></li>
            <li class="active"><a href="Products.aspx"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Products</a></li>
            <li ><a href="Purchase.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Purchase</a></li>
            <li><a href="#"><i class="glyphicon glyphicon-envelope"></i>&nbsp;Quick Email..</a></li>
        </ul>
    </div>

</asp:Content>
