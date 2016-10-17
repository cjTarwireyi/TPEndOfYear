<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="Employee.aspx.cs" Inherits="site1_Employee" %>

<asp:Content ID="Content5" ContentPlaceHolderID="details" Runat="Server">
     <div class="loginDisplay">
        <span class="glyphicon glyphicon-user"></span>&nbsp;<asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label> 
            <asp:Button ID="Submit" runat="server" class="btn btn-danger " 
            Height="35px" Text="Sign Out" 
                                Width="90px" onclick="Submit_Click"/>  
         </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="sideBarNav" runat="server">
   <div id="sidebar-wrapper">
       <ul class="sidebar-nav nav-pills nav-stacked" id="menu">
           <li ><a href="Home.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>
           <li><a href="Users.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Users</a></li>
           <li><a href="Customers.aspx"><i class="glyphicon glyphicon-cog"></i>&nbsp;Customers</a></li>
           <li class="active"><a href="Employee.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Employees</a></li>
           <li><a href="RegistrationPage.aspx"><i class="glyphicon glyphicon-list "></i>&nbsp;Register User</a></li>
           <li><a href="Reports.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Reports</a></li>
           <li><a href="Orders.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Order</a></li>
           <li><a href="Products.aspx"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Products</a></li>
           <li><a href="#"><i class="glyphicon glyphicon-time"></i>&nbsp;Real-time</a></li>
           <li><a href="#"><i class="glyphicon glyphicon-envelope"></i>&nbsp;Quick Email..</a></li>
        </ul>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    
        <div class="  main">
            <h1><strong>Employees</strong></h1>
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Employees]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [Employees] WHERE [EmployeeID] = @original_EmployeeID AND (([EmployeeName] = @original_EmployeeName) OR ([EmployeeName] IS NULL AND @original_EmployeeName IS NULL)) AND (([EmployeeSurname] = @original_EmployeeSurname) OR ([EmployeeSurname] IS NULL AND @original_EmployeeSurname IS NULL)) AND (([EmployeeCellNumber] = @original_EmployeeCellNumber) OR ([EmployeeCellNumber] IS NULL AND @original_EmployeeCellNumber IS NULL)) AND (([EmployeeStreetName] = @original_EmployeeStreetName) OR ([EmployeeStreetName] IS NULL AND @original_EmployeeStreetName IS NULL)) AND (([EmployeeSuburb] = @original_EmployeeSuburb) OR ([EmployeeSuburb] IS NULL AND @original_EmployeeSuburb IS NULL)) AND (([EmployeePostalCode] = @original_EmployeePostalCode) OR ([EmployeePostalCode] IS NULL AND @original_EmployeePostalCode IS NULL)) AND (([DateHired] = @original_DateHired) OR ([DateHired] IS NULL AND @original_DateHired IS NULL))" InsertCommand="INSERT INTO [Employees] ([EmployeeName], [EmployeeSurname], [EmployeeCellNumber], [EmployeeStreetName], [EmployeeSuburb], [EmployeePostalCode], [DateHired]) VALUES (@EmployeeName, @EmployeeSurname, @EmployeeCellNumber, @EmployeeStreetName, @EmployeeSuburb, @EmployeePostalCode, @DateHired)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [Employees] SET [EmployeeName] = @EmployeeName, [EmployeeSurname] = @EmployeeSurname, [EmployeeCellNumber] = @EmployeeCellNumber, [EmployeeStreetName] = @EmployeeStreetName, [EmployeeSuburb] = @EmployeeSuburb, [EmployeePostalCode] = @EmployeePostalCode, [DateHired] = @DateHired WHERE [EmployeeID] = @original_EmployeeID AND (([EmployeeName] = @original_EmployeeName) OR ([EmployeeName] IS NULL AND @original_EmployeeName IS NULL)) AND (([EmployeeSurname] = @original_EmployeeSurname) OR ([EmployeeSurname] IS NULL AND @original_EmployeeSurname IS NULL)) AND (([EmployeeCellNumber] = @original_EmployeeCellNumber) OR ([EmployeeCellNumber] IS NULL AND @original_EmployeeCellNumber IS NULL)) AND (([EmployeeStreetName] = @original_EmployeeStreetName) OR ([EmployeeStreetName] IS NULL AND @original_EmployeeStreetName IS NULL)) AND (([EmployeeSuburb] = @original_EmployeeSuburb) OR ([EmployeeSuburb] IS NULL AND @original_EmployeeSuburb IS NULL)) AND (([EmployeePostalCode] = @original_EmployeePostalCode) OR ([EmployeePostalCode] IS NULL AND @original_EmployeePostalCode IS NULL)) AND (([DateHired] = @original_DateHired) OR ([DateHired] IS NULL AND @original_DateHired IS NULL))">
                <DeleteParameters>
                    <asp:Parameter Name="original_EmployeeID" Type="Int32" />
                    <asp:Parameter Name="original_EmployeeName" Type="String" />
                    <asp:Parameter Name="original_EmployeeSurname" Type="String" />
                    <asp:Parameter Name="original_EmployeeCellNumber" Type="String" />
                    <asp:Parameter Name="original_EmployeeStreetName" Type="String" />
                    <asp:Parameter Name="original_EmployeeSuburb" Type="String" />
                    <asp:Parameter Name="original_EmployeePostalCode" Type="String" />
                    <asp:Parameter Name="original_DateHired" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="EmployeeName" Type="String" />
                    <asp:Parameter Name="EmployeeSurname" Type="String" />
                    <asp:Parameter Name="EmployeeCellNumber" Type="String" />
                    <asp:Parameter Name="EmployeeStreetName" Type="String" />
                    <asp:Parameter Name="EmployeeSuburb" Type="String" />
                    <asp:Parameter Name="EmployeePostalCode" Type="String" />
                    <asp:Parameter Name="DateHired" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="EmployeeName" Type="String" />
                    <asp:Parameter Name="EmployeeSurname" Type="String" />
                    <asp:Parameter Name="EmployeeCellNumber" Type="String" />
                    <asp:Parameter Name="EmployeeStreetName" Type="String" />
                    <asp:Parameter Name="EmployeeSuburb" Type="String" />
                    <asp:Parameter Name="EmployeePostalCode" Type="String" />
                    <asp:Parameter Name="DateHired" Type="String" />
                    <asp:Parameter Name="original_EmployeeID" Type="Int32" />
                    <asp:Parameter Name="original_EmployeeName" Type="String" />
                    <asp:Parameter Name="original_EmployeeSurname" Type="String" />
                    <asp:Parameter Name="original_EmployeeCellNumber" Type="String" />
                    <asp:Parameter Name="original_EmployeeStreetName" Type="String" />
                    <asp:Parameter Name="original_EmployeeSuburb" Type="String" />
                    <asp:Parameter Name="original_EmployeePostalCode" Type="String" />
                    <asp:Parameter Name="original_DateHired" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" CellPadding="4" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="EmployeeID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" Width="792px" ForeColor="#333333">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="EmployeeID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="EmployeeID" />
                    <asp:BoundField DataField="EmployeeName" HeaderText="Name" SortExpression="EmployeeName" />
                    <asp:BoundField DataField="EmployeeSurname" HeaderText="Surname" SortExpression="EmployeeSurname" />
                    <asp:BoundField DataField="EmployeeCellNumber" HeaderText="CellNumber" SortExpression="EmployeeCellNumber" />
                    <asp:BoundField DataField="EmployeeStreetName" HeaderText="StreetName" SortExpression="EmployeeStreetName" />
                    <asp:BoundField DataField="EmployeeSuburb" HeaderText="Suburb" SortExpression="EmployeeSuburb" />
                    <asp:BoundField DataField="EmployeePostalCode" HeaderText="PostalCode" SortExpression="EmployeePostalCode" />
                    <asp:BoundField DataField="DateHired" HeaderText="DateHired" SortExpression="DateHired" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
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
