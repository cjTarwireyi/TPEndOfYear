<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/site1/AccessMaster.master" CodeFile="AddBrand.aspx.cs" Inherits="site1_AddBrand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
    <form id="form1" runat="server">
        <div class="page-header">
            <asp:Label runat="server" ID="lblHeader" style="color:white; font-size:x-large"
                class="control-label"></asp:Label>
        </div>
        <div class="row">
            <div class="form-group">
                <div class="col-sm-4">
                    <asp:label ID="lblName" runat="server" style="color:white; font-size:large">Name: </asp:label>
                </div>
                <div class="col-sm-8">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="glyphicon glyphicon-pencil"></span></span>
                        <asp:TextBox runat="server" ID="txtName" Height="35px" Width="290"
                            placeHolder="Brand Name" class="form-control" ></asp:TextBox>
                    </div>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorName" 
                        ErrorMessage="This Field Is Required!" ControlToValidate="txtName"
                        ForColor="Yellow"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-group">
                <div class="col-sm-4">
                    <asp:Label runat="server" ID="lblDescription" style="color:white; font-size:large">Description: </asp:Label>
                </div>
                <div class="col-sm-8">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="glyphicon glyphicon-comment"></span></span>
                        <asp:TextBox runat="server" ID="txtDescription" Height="35px" Width="290"
                            placeHolder="Brand Description"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-6">
                <asp:Button runat="server" ID="btnAdd" class="btn btn-success"
                     Height="35px" Width="126px" Text="Add"/>
            </div>
            <div class="col-sm-6">
                <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-danger"
                     Height="35px" Width="126px" Text="Cancel"/>
            </div>
        </div>
    </form>
</asp:Content>
