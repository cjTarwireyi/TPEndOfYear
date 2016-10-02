<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="Customers.aspx.cs" Inherits="site1_customer_Customers" %>

<%-- Add content controls here --%>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <form runat="server">
        <div class=" col-md-offset-2 main">
    <h1><strong>Customers</strong></h1>
<br />
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConflictDetection="CompareAllValues" 
       ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        DeleteCommand="DELETE FROM [Customers] WHERE [CustomerID] = @original_CustomerID AND (([CustomerName] = @original_CustomerName) OR ([CustomerName] IS NULL AND @original_CustomerName IS NULL)) AND (([CustomerSurname] = @original_CustomerSurname) OR ([CustomerSurname] IS NULL AND @original_CustomerSurname IS NULL)) AND (([CustomerCellNumber] = @original_CustomerCellNumber) OR ([CustomerCellNumber] IS NULL AND @original_CustomerCellNumber IS NULL)) AND (([CustomerStreetName] = @original_CustomerStreetName) OR ([CustomerStreetName] IS NULL AND @original_CustomerStreetName IS NULL)) AND (([CustomerSuburb] = @original_CustomerSuburb) OR ([CustomerSuburb] IS NULL AND @original_CustomerSuburb IS NULL)) AND (([CustomerPostalCode] = @original_CustomerPostalCode) OR ([CustomerPostalCode] IS NULL AND @original_CustomerPostalCode IS NULL))" 
        InsertCommand="INSERT INTO [Customers] ([CustomerName], [CustomerSurname], [CustomerCellNumber], [CustomerStreetName], [CustomerSuburb], [CustomerPostalCode]) VALUES (@CustomerName, @CustomerSurname, @CustomerCellNumber, @CustomerStreetName, @CustomerSuburb, @CustomerPostalCode)" 
        OldValuesParameterFormatString="original_{0}" 
        SelectCommand="SELECT * FROM [Customers]" 
        UpdateCommand="UPDATE [Customers] SET [CustomerName] = @CustomerName, [CustomerSurname] = @CustomerSurname, [CustomerCellNumber] = @CustomerCellNumber, [CustomerStreetName] = @CustomerStreetName, [CustomerSuburb] = @CustomerSuburb, [CustomerPostalCode] = @CustomerPostalCode WHERE [CustomerID] = @original_CustomerID AND (([CustomerName] = @original_CustomerName) OR ([CustomerName] IS NULL AND @original_CustomerName IS NULL)) AND (([CustomerSurname] = @original_CustomerSurname) OR ([CustomerSurname] IS NULL AND @original_CustomerSurname IS NULL)) AND (([CustomerCellNumber] = @original_CustomerCellNumber) OR ([CustomerCellNumber] IS NULL AND @original_CustomerCellNumber IS NULL)) AND (([CustomerStreetName] = @original_CustomerStreetName) OR ([CustomerStreetName] IS NULL AND @original_CustomerStreetName IS NULL)) AND (([CustomerSuburb] = @original_CustomerSuburb) OR ([CustomerSuburb] IS NULL AND @original_CustomerSuburb IS NULL)) AND (([CustomerPostalCode] = @original_CustomerPostalCode) OR ([CustomerPostalCode] IS NULL AND @original_CustomerPostalCode IS NULL))">
        <DeleteParameters>
            <asp:Parameter Name="original_CustomerID" Type="Int32" />
            <asp:Parameter Name="original_CustomerName" Type="String" />
            <asp:Parameter Name="original_CustomerSurname" Type="String" />
            <asp:Parameter Name="original_CustomerCellNumber" Type="String" />
            <asp:Parameter Name="original_CustomerStreetName" Type="String" />
            <asp:Parameter Name="original_CustomerSuburb" Type="String" />
            <asp:Parameter Name="original_CustomerPostalCode" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CustomerName" Type="String" />
            <asp:Parameter Name="CustomerSurname" Type="String" />
            <asp:Parameter Name="CustomerCellNumber" Type="String" />
            <asp:Parameter Name="CustomerStreetName" Type="String" />
            <asp:Parameter Name="CustomerSuburb" Type="String" />
            <asp:Parameter Name="CustomerPostalCode" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="CustomerName" Type="String" />
            <asp:Parameter Name="CustomerSurname" Type="String" />
            <asp:Parameter Name="CustomerCellNumber" Type="String" />
            <asp:Parameter Name="CustomerStreetName" Type="String" />
            <asp:Parameter Name="CustomerSuburb" Type="String" />
            <asp:Parameter Name="CustomerPostalCode" Type="String" />
            <asp:Parameter Name="original_CustomerID" Type="Int32" />
            <asp:Parameter Name="original_CustomerName" Type="String" />
            <asp:Parameter Name="original_CustomerSurname" Type="String" />
            <asp:Parameter Name="original_CustomerCellNumber" Type="String" />
            <asp:Parameter Name="original_CustomerStreetName" Type="String" />
            <asp:Parameter Name="original_CustomerSuburb" Type="String" />
            <asp:Parameter Name="original_CustomerPostalCode" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource2" AutoGenerateColumns="False" DataKeyNames="CustomerID" Height="107px" Width="703px" AllowSorting="True">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" />
            <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" SortExpression="CustomerName" />
            <asp:BoundField DataField="CustomerSurname" HeaderText="CustomerSurname" SortExpression="CustomerSurname" />
            <asp:BoundField DataField="CustomerCellNumber" HeaderText="CustomerCellNumber" SortExpression="CustomerCellNumber" />
            <asp:BoundField DataField="CustomerStreetName" HeaderText="CustomerStreetName" SortExpression="CustomerStreetName" />
            <asp:BoundField DataField="CustomerSuburb" HeaderText="CustomerSuburb" SortExpression="CustomerSuburb" />
            <asp:BoundField DataField="CustomerPostalCode" HeaderText="CustomerPostalCode" SortExpression="CustomerPostalCode" />
        </Columns>
        </asp:GridView>
            </div>
   </form>
</asp:Content>


