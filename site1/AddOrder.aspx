<%--<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="AddOrder.aspx.cs" Inherits="site1_AddOrder" %>--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="AddOrder.aspx.cs" Inherits="site1_AddOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
    
</asp:Content>
 
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    
            <div class=" col-md-offset-4 main">

        
    <div class="container">
         <form runat="server">
             <asp:ScriptManager ID="ScriptManager1" runat="server">
                 </asp:ScriptManager>
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                  <ContentTemplate>

  <h2>Add Ordder</h2>
  <!-- Trigger the modal with a button -->
  <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Add Order</button>
                         <asp:Label  ID="lbl" Text="ssss" runat="server"></asp:Label>
  <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">

    <div class="modal-dialog">
    
      <!-- Modal content-->

      <div class="modal-content">

        <div class="modal-header">
           
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Add Order</h4>
                   

        </div>
        <div class="modal-body">
           
    <div class="form-group">
      <label for="productCode">Product Code:</label>
      <input type="text" class="form-control" id="productCode" placeholder="Enter product Code">
    </div>
    <div class="form-group">
      <label for="custId">Customer Id:</label>
      <input type="text" class="form-control" id="custId" placeholder="Enter Customer ID">
    </div>
     
     
  

        <div class="modal-footer">
          <asp:Button type="button" runat="server" class="btn btn-default" data-dismiss="modal" Text="Close"/>
        </div>
          
                    </div>
      </div>
      
    </div>
  </div>
                      <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Orderdbcontext" EntityTypeName="" TableName="Controls">
                      </asp:LinqDataSource>
                      </ContentTemplate>

                  </asp:UpdatePanel>
                 
  </form>
</div>
          
      </div>  
</asp:Content>