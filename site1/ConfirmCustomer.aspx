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
                <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label><br />
                <asp:Label ID="lblSurname" runat="server" Text="Label"></asp:Label><br />
                <asp:Label ID="lblCellNumber" runat="server" Text="Label"></asp:Label><br />
                <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label><br />
                <asp:Label ID="lblSurbub" runat="server" Text="Label"></asp:Label><br />
                <asp:Label ID="lblStreet" runat="server" Text="Label"></asp:Label><br />
                <asp:Label ID="lblPostalCode" runat="server" Text="Label"></asp:Label><br />
                <asp:Button ID="Register" runat="server" Height="32px" Text="Register"
                    Width="126px" class="btn btn-success" OnClick="Register_Click" data-toggle="modal" data-target="#myModal" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <!-- Modal-->
        <div id="myModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Creating Account</h4>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <progresstemplate>
                                     <img src="images/load.gif" style="left:25%; position: relative;" />
                                </progresstemplate>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <h3 align="center">Please wait...</h3>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

