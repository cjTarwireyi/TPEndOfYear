<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="site1_Orders" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <form runat="server">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="Procedure" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="date" PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="TextBox1" Name="year" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="RadioButton1" Name="status" PropertyName="Checked" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
        <div class=" col-md-offset-2 main">
            <h1><strong>Monthly</strong>Orders</h1>
            Year<br />
            <asp:TextBox ID="TextBox1" runat="server" Height="18px" Width="83px" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged" ></asp:TextBox><br />
            <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="128px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
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
            </asp:DropDownList><br /><br />
            <asp:Panel ID="Panel1" runat="server" Width="807px">
                   <asp:RadioButton ID="RadioButton1" runat="server" Value="True" Text="Paid" AutoPostBack="True" GroupName="status" /><br />
                   <asp:RadioButton ID="RadioButton2" runat="server"  Value="False" Text="Outstanding" AutoPostBack="True" GroupName="status" Checked="True" />
                <asp:GridView ID="GridView1" runat="server" Width="797px" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="orderId" DataSourceID="SqlDataSource1" ForeColor="#333333">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="orderId" HeaderText="OrderNumber" InsertVisible="False" ReadOnly="True" SortExpression="orderId" />
                        <asp:BoundField DataField="custId" HeaderText="Customer" SortExpression="custId" />
                        <asp:CheckBoxField DataField="payed" HeaderText="Status" SortExpression="payed" />
                        <asp:BoundField DataField="amount" HeaderText="Amount" SortExpression="amount" />
                        <asp:BoundField DataField="orderDate" HeaderText="Date" SortExpression="orderDate" />
                        <asp:BoundField DataField="employeeId" HeaderText="Employee" SortExpression="employeeId" />
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
            </asp:Panel>
        </div>
    </form>
</asp:Content>
