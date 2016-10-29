<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="ErrorPage.aspx.cs" Inherits="site1_ErrorPage" %>

<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <p style="text-align: center;">
            Sorry, an error has occurred while processing your request. Please contact the administrator
                for help. </br> We apologize for the inconvenience.
        </p>
        <div style="width: 90%; margin: 0px 15px 20px 5%; float: left; font-size: 12px; height: 200px;
            background: #f6f5f5; border: 1px solid #d4d4d2; border-top: 1px solid #f6f5f5;">
            <asp:Panel ID="Panel1" ScrollBars="Vertical" Height="180px" Width="100%" runat="server">
                <asp:UpdatePanel ID="pnlUpdateErrorDetails" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErrorDetails" runat="server" Height="100%" Width="100%"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
