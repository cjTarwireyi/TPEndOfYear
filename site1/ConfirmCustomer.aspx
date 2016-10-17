<%@ Page Title="" Language="C#" MasterPageFile="~/site1/AccessMaster.master" AutoEventWireup="true" CodeFile="ConfirmCustomer.aspx.cs" Inherits="site1_ConfirmCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <form id="form1" runat="server">
        <div class="page-header">
              <h3><strong>Confirm</strong>Customer</h3>                     
		</div>
        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="lblSurname" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="lblCellNumber" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="lblSurbub" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="lblStreet" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="lblPostalCode" runat="server" Text="Label"></asp:Label><br />

        <asp:Button ID="Register" runat="server" Height="32px" Text="Register" 
            Width="126px" class="btn btn-success" onclick="Register_Click" />
     </form>
</asp:Content>

