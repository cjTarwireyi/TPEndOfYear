﻿<%@ Page Title="" Language="C#" MasterPageFile="~/site1/MasterPage.master" AutoEventWireup="true" CodeFile="TimeSheet.aspx.cs" Inherits="TimeSheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="Server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="details" runat="Server">
    <div class="loginDisplay">
        <span class="glyphicon glyphicon-user"></span>&nbsp;<asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="Submit" runat="server" class="btn btn-danger "
            Height="35px" Text="Sign Out"
            Width="90px" OnClick="Logout" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="sideBarNav" runat="server">
   <div id="sidebar-wrapper">
        <asp:Panel ID="userPanel" runat="server">
            <ul class="sidebar-nav nav-pills nav-stacked" id="menu">
                <li><a href="Home.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>
                <li><a href="Profile.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;My Profile</a></li>
                <li><a href="productAnalysis.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Reports</a></li>
                <li><a href="Orders.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Orders</a></li>
                <li><a href="Products.aspx"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Products</a></li>
                <li><a href="Returns.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Item Returns</a></li>
                <li><a href="Purchase.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Purchase</a></li>
            </ul>
        </asp:Panel>
        <asp:Panel ID="AdminLinkPanel" runat="server">
            <ul class="sidebar-nav nav-pills nav-stacked" id="menu2">
                <li><a href="Home.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp;Home</a></li>
                <li><a href="Profile.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;My Profile</a></li>
                <li ><a href="productAnalysis.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Reports</a></li>
                <li><a href="Orders.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Orders</a></li>
                <li><a href="Products.aspx"><i class="glyphicon glyphicon-briefcase"></i>&nbsp;Products</a></li>
                <li><a href="Returns.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Item Returns</a></li>
                <li><a href="Purchase.aspx"><i class="glyphicon glyphicon-time"></i>&nbsp;Purchase</a></li>
                <li><a href="Users.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Users</a></li>
                <li><a href="Roles.aspx"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;Roles</a></li>
                <li><a href="Customers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Customers</a></li>
                <li><a href="Employee.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Employees</a></li>
                <li><a href="Suppliers.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;Suppliers</a></li>
                <li class="active"><a href="TimeSheet.aspx"><i class="glyphicon glyphicon-user"></i>&nbsp;TimeSheet</a></li>
                <li><a href="RegistrationPage.aspx"><i class="glyphicon glyphicon-user "></i>&nbsp;Register User</a></li>
            </ul>
        </asp:Panel>
    </div>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main row col-lg-offset-0">
        <h1><strong>TimeSheet</strong></h1>
        <br />
        <div class="col-lg-6 col-lg-offset-0">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>

                    <div class="form-group">
                        Employee
                        <div class="input-group">
                            <span class="input-group-addon"><span class="fa fa-cubes"></span></span>
                            
                            <asp:DropDownList ID="empList" runat="server"  Height="35px" Width="290px"
                                class="form-control" placeholder="Customer">
                            </asp:DropDownList><br/>                  

                        </div>
 
                        <asp:Label ID="Label1" Visible="false" runat="server" ForeColor="Red" Text="invalid Product Code"></asp:Label>
                    </div>
                    


                    <div class="form-group">
                         Date
                        <div class="input-group">
                            <span class="input-group-addon"><span class="fa fa-cubes"></span></span>
                           
                             <input type="date"  class="form-control" id="tdate" style="width:200px" name="tdate"/><br />
                        </div>
                           </div>
                    

                     <div class="form-group">
                        Timein
                        <div class="input-group">
                            <span class="input-group-addon"><span class="fa fa-cubes"></span></span>
                                                        
                            <input type="time" name="timein" id="timein" class="form-control" style="width:200px"><br/>
                           
                              
                        </div>
                         </div>

                     <div class="form-group">
                        TimeOut
                        <div class="input-group">
                            <span class="input-group-addon"><span class="fa fa-cubes"></span></span>
                                                        
                            <input type="time" name="timeout" id="timeout" class="form-control" style="width:200px"><br/>
                           
                              
                        </div>
                         </div>
                      
                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon"><span class="fa fa-cubes"></span></span>
                            <asp:TextBox ID="txtComents" TextMode="multiline" Columns="50" Rows="5" runat="server" Height="100px" Width="290px"
                                class="form-control" placeholder="Comments" MaxLength="50"></asp:TextBox>
                        </div>
                        <br />

                        <asp:Button ID="btnAdd" ValidationGroup="Group1" runat="server" Height="32px" Text="Add"
                            Width="126px" class="btn btn-success" OnClick="btnAdd_Click" />
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-lg-6 col-lg-offset-0">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" Height="190px" Width="500px" AllowSorting="True" AllowPaging="True" GridLines="None" OnRowDeleting="GridView1_RowDeleting" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowUpdated="GridView1_RowUpdated" CellPadding="4" ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="Id" InsertVisible="False" ReadOnly="True" Visible="False" />
                            <asp:BoundField DataField="empName" HeaderText="Employee" />
                            <asp:BoundField DataField="DateWorked" HeaderText="Date Worked" />
                            <asp:BoundField HeaderText="Time In" DataField="TimeIn" />

                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TimeOut" HeaderText="Time Out" />
                            <asp:BoundField DataField="Comments" HeaderText="Comments" />
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


                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </div>
</asp:Content>
