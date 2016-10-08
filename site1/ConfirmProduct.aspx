<%@ Page Title="" Language="C#" MasterPageFile="~/site1/AccessMaster.master" AutoEventWireup="true" CodeFile="ConfirmProduct.aspx.cs" Inherits="site1_ConfirmProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <form id="form1" runat="server">
        <div class="page-header">
                <h3><strong>Confirm</strong>Product</h3>                     
		</div>
        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="lblPrice" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="lblQuantity" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="lblTime" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="lblSupplierID" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="btnAdd" runat="server" Height="32px" Text="Add" 
            Width="126px" class="btn btn-success" onclick="btnAdd_Click"/>
     </form>
</asp:Content>

