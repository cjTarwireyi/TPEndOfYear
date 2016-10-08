<%@ Page Title="" Language="C#" MasterPageFile="~/site1/AccessMaster.master" AutoEventWireup="true" CodeFile="ConfirmSupplier.aspx.cs" Inherits="site1_ConfirmSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <form id="form1" runat="server">
        <div class="page-header">
            <h3><strong>Add</strong>Supplier</h3>
        </div>
        <asp:Label ID="lblSupplierName" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="lblSupplierSurname" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="lblCellNumber" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="lblSurbub" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="lblStreet" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="lblPostalCode" runat="server" Text="Label"></asp:Label><br />

        <asp:Button ID="btnAdd" runat="server" Height="32px" Text="Confirm"
            Width="126px" class="btn btn-success" OnClick="btnAdd_Click" />
    </form>
</asp:Content>

