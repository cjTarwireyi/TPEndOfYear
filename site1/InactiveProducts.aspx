<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="InactiveProducts.aspx.cs" Inherits="site1_InactiveProducts" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <form runat="server">
        <div class=" col-md-offset-2 main">
            <h1><strong>&nbsp;Inactive</strong>Records</h1>
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Products] WHERE [Id] = @original_Id AND (([ProductName] = @original_ProductName) OR ([ProductName] IS NULL AND @original_ProductName IS NULL)) AND (([ProductDescription] = @original_ProductDescription) OR ([ProductDescription] IS NULL AND @original_ProductDescription IS NULL)) AND (([Price] = @original_Price) OR ([Price] IS NULL AND @original_Price IS NULL)) AND (([Quantity] = @original_Quantity) OR ([Quantity] IS NULL AND @original_Quantity IS NULL)) AND (([Active] = @original_Active) OR ([Active] IS NULL AND @original_Active IS NULL)) AND (([DateArrived] = @original_DateArrived) OR ([DateArrived] IS NULL AND @original_DateArrived IS NULL)) AND (([SupplierID] = @original_SupplierID) OR ([SupplierID] IS NULL AND @original_SupplierID IS NULL))" InsertCommand="INSERT INTO [Products] ([ProductName], [ProductDescription], [Price], [Quantity], [Active], [DateArrived], [SupplierID]) VALUES (@ProductName, @ProductDescription, @Price, @Quantity, @Active, @DateArrived, @SupplierID)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Products] WHERE ([Active] = @Active)" UpdateCommand="UPDATE [Products] SET [ProductName] = @ProductName, [ProductDescription] = @ProductDescription, [Price] = @Price, [Quantity] = @Quantity, [Active] = @Active, [DateArrived] = @DateArrived, [SupplierID] = @SupplierID WHERE [Id] = @original_Id AND (([ProductName] = @original_ProductName) OR ([ProductName] IS NULL AND @original_ProductName IS NULL)) AND (([ProductDescription] = @original_ProductDescription) OR ([ProductDescription] IS NULL AND @original_ProductDescription IS NULL)) AND (([Price] = @original_Price) OR ([Price] IS NULL AND @original_Price IS NULL)) AND (([Quantity] = @original_Quantity) OR ([Quantity] IS NULL AND @original_Quantity IS NULL)) AND (([Active] = @original_Active) OR ([Active] IS NULL AND @original_Active IS NULL)) AND (([DateArrived] = @original_DateArrived) OR ([DateArrived] IS NULL AND @original_DateArrived IS NULL)) AND (([SupplierID] = @original_SupplierID) OR ([SupplierID] IS NULL AND @original_SupplierID IS NULL))">
                <DeleteParameters>
                    <asp:Parameter Name="original_Id" Type="Int32" />
                    <asp:Parameter Name="original_ProductName" Type="String" />
                    <asp:Parameter Name="original_ProductDescription" Type="String" />
                    <asp:Parameter Name="original_Price" Type="Double" />
                    <asp:Parameter Name="original_Quantity" Type="Int32" />
                    <asp:Parameter Name="original_Active" Type="Boolean" />
                    <asp:Parameter Name="original_DateArrived" Type="DateTime" />
                    <asp:Parameter Name="original_SupplierID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="ProductName" Type="String" />
                    <asp:Parameter Name="ProductDescription" Type="String" />
                    <asp:Parameter Name="Price" Type="Double" />
                    <asp:Parameter Name="Quantity" Type="Int32" />
                    <asp:Parameter Name="Active" Type="Boolean" />
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
                    <asp:Parameter Name="Active" Type="Boolean" />
                    <asp:Parameter Name="DateArrived" Type="DateTime" />
                    <asp:Parameter Name="SupplierID" Type="Int32" />
                    <asp:Parameter Name="original_Id" Type="Int32" />
                    <asp:Parameter Name="original_ProductName" Type="String" />
                    <asp:Parameter Name="original_ProductDescription" Type="String" />
                    <asp:Parameter Name="original_Price" Type="Double" />
                    <asp:Parameter Name="original_Quantity" Type="Int32" />
                    <asp:Parameter Name="original_Active" Type="Boolean" />
                    <asp:Parameter Name="original_DateArrived" Type="DateTime" />
                    <asp:Parameter Name="original_SupplierID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource1" Width="798px">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                            <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                            <asp:BoundField DataField="ProductDescription" HeaderText="ProductDescription" SortExpression="ProductDescription" />
                            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                            <asp:BoundField DataField="DateArrived" HeaderText="DateArrived" SortExpression="DateArrived" />
                            <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" SortExpression="SupplierID" />
                        </Columns>
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel><br />
            <asp:Button ID="Active" runat="server" Height="32px" Text="Activate Product"
                Width="126px" class="btn btn-success"
                data-toggle="tooltip" data-placement="left"
                title="Insert new tecnician to database" OnClick="Active_Click" />&nbsp;&nbsp;
            <asp:Button ID="btnProducts" runat="server" Height="32px" Text="Active Products"
                Width="126px" class="btn btn-success"
                data-toggle="tooltip" data-placement="left"
                title="Insert new tecnician to database" OnClick="btnProducts_Click" />
        </div>
    </form>
</asp:Content>

