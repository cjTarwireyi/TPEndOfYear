<%@ Page Title="" Language="C#" MasterPageFile="~/site1/AccessMaster.master" AutoEventWireup="true" CodeFile="EmployeeConfirm.aspx.cs" Inherits="site1_EmployeeConfirm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
     <form id="form1" runat="server">

    <h2><strong>Confirm</strong>Employees</h2>
    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="lblSurname" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="lblCellNumber" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="lblSurbub" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="lblStreet" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="lblPostalCode" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Button ID="btnConfirm"   class="btn-success" runat="server" Text="Confirm" onclick="btnConfirm_Click" 
            />
    </form>
    
</asp:Content>

