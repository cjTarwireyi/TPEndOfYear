<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="Staff.aspx.cs" Inherits="pages_Staff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Staff
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="details" Runat="Server">
    <div class="loginDisplay">
            <span class="glyphicon glyphicon-user"></span>&nbsp;<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="Submit" runat="server" class="btn btn-danger " Height="35px" Text="Sign Out" 
                                Width="90px" onclick="Submit_Click"/>  
         </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sideBarNav" Runat="Server">
    <div id="sidebar-wrapper">
       <ul class="sidebar-nav nav-pills nav-stacked" id="menu">
           <li><a href="../AdminDashboard.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>
           <li class="active"><a href="Staff.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Employees</a></li>
           <li><a href="Parts.aspx">
           <i class="glyphicon glyphicon-cog"></i>&nbsp;Parts</a></li>
           <li><a href="Customers.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Customer Record</a></li>
           <li><a href="Services.aspx"><i class="glyphicon glyphicon-list "></i>&nbsp;Services</a></li>
           <li><a href="Reports.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Reports</a></li>
           <li><a href="Books.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Books</a></li>
           <li><a href="#"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Tools</a></li>
           <li><a href="#"><i class="glyphicon glyphicon-time"></i>&nbsp;Real-time</a></li>
           <li><a href="#"><i class="glyphicon glyphicon-envelope"></i>&nbsp;Quick Email..</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="content" Runat="Server">
<h1>technician page</h1>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdminBookingConnectionString %>" 
        SelectCommand="SELECT [techID], [techName], [techContact], [techEmail] FROM [Technician]" 
        DeleteCommand="DELETE FROM [Technician] WHERE [techID] = @techID" 
        InsertCommand="INSERT INTO [Technician] ([techName], [techContact], [techEmail]) VALUES (@techName, @techContact, @techEmail)" 
        
        UpdateCommand="UPDATE [Technician] SET [techName] = @techName, [techContact] = @techContact, [techEmail] = @techEmail WHERE [techID] = @techID">
        <DeleteParameters>
            <asp:Parameter Name="techID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="techName" Type="String" />
            <asp:Parameter Name="techContact" Type="String" />
            <asp:Parameter Name="techEmail" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="techName" Type="String" />
            <asp:Parameter Name="techContact" Type="String" />
            <asp:Parameter Name="techEmail" Type="String" />
            <asp:Parameter Name="techID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <div style="width: 835px">
    <asp:GridView ID="GridView1" runat="server" 
                   AllowSorting="True" DataSourceID="SqlDataSource1" Width="837px" Height="224px" 
            AutoGenerateColumns="False" DataKeyNames="techID" ShowFooter="True" 
            onrowdatabound="GridView1_RowDataBound" CellPadding="4" 
            ForeColor="#333333" GridLines="None">
                   <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                   <Columns>
                       <asp:TemplateField ShowHeader="False">
                           <ItemTemplate>
                               <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                   CommandName="Delete" Text="Delete"></asp:LinkButton>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:BoundField DataField="techID" HeaderText="TechID" InsertVisible="False" 
                           ReadOnly="True" SortExpression="techID" />
                       <asp:BoundField DataField="techName" HeaderText="TechName" 
                           SortExpression="techName" />
                       <asp:BoundField DataField="techContact" HeaderText="TechContact" 
                           SortExpression="techContact" />
                       <asp:BoundField DataField="techEmail" HeaderText="TechEmail" 
                           SortExpression="techEmail" />
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
    <div>
    <br />
        <asp:Button ID="Register" runat="server" Height="32px" Text="Register New" Width="126px" class="btn btn-success" 
        data-toggle="tooltip" data-placement="left" title="Insert new tecnician to database"/>
        
  
    </div>
</asp:Content>

