<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="Purchase.aspx.cs" Inherits="site1_Purchase" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <form runat="server">
        <div class=" col-md-offset-2 main">
            <h1><strong>Purchase</strong>Order</h1>
            <br />

            <div class="form-group">
                <div class="input-group">
                    <span class="input-group-addon"><span class="fa fa-cubes"></span></span>
                    <asp:TextBox ID="txtCustomerID" runat="server" Height="35px" Width="290px"
                        class="form-control" placeholder="CustomerID" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ErrorMessage="CustomerID Required!" ControlToValidate="txtCustomerID" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
            </div>

            <div class="form-group">
                <div class="input-group">
                    <span class="input-group-addon"><span class="fa fa-cubes"></span></span>
                    <asp:TextBox ID="txtProductID" runat="server" Width="290px"
                        class="form-control" placeholder="Product Code" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" OnTextChanged="txtProductID_TextChanged"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="ProductID Required!" ControlToValidate="txtProductID" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnAdd" runat="server" Height="32px" Text="Add"
                        Width="126px" class="btn btn-success" OnClick="btnAdd_Click" />
                    <asp:GridView runat="server" ID="GridView1" ShowHeaderWhenEmpty="True" align="right" CellPadding="4" ForeColor="#333333" Width="557px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField HeaderText="ProductCode" DataField="ProductCode" />
                            <asp:BoundField HeaderText="Product" DataField="Product" />
                            <asp:BoundField HeaderText="Price" DataField="Price" />
                            <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
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
                </ContentTemplate>
            </asp:UpdatePanel>
    </form>
</asp:Content>
