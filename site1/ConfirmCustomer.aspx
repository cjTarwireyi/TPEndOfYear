<%@ Page Title="" Language="C#" MasterPageFile="~/site1/AccessMaster.master" AutoEventWireup="true" CodeFile="ConfirmCustomer.aspx.cs" Inherits="site1_ConfirmCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="page-header">
            <h3><strong>Confirm</strong>Customer</h3>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="progress" runat="server" DisplayAfter="300" DynamicLayout="false">
                    <ProgressTemplate>
                        <div style="position: absolute; z-index: 10; left: expression((this.offsetParent.clientWidth/2)-(this.clientWidth/2)+this.offsetParent.scrollLeft); top: expression((this.offsetParent.clientHeight/2)-(this.clientHeight/2)+this.offsetParent.scrollTop);">
                            <img src="images/load.gif" style="top: 50%; left:160%; position: relative;" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label><br />
                <asp:Label ID="lblSurname" runat="server" Text="Label"></asp:Label><br />
                <asp:Label ID="lblCellNumber" runat="server" Text="Label"></asp:Label><br />
                <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label><br />
                <asp:Label ID="lblSurbub" runat="server" Text="Label"></asp:Label><br />
                <asp:Label ID="lblStreet" runat="server" Text="Label"></asp:Label><br />
                <asp:Label ID="lblPostalCode" runat="server" Text="Label"></asp:Label><br />

                <asp:Button ID="Register" runat="server" Height="32px" Text="Register"
                    Width="126px" class="btn btn-success" OnClick="Register_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</asp:Content>

