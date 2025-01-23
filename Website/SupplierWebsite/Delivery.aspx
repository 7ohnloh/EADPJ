<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Delivery.aspx.cs" Inherits="Delivery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        h1 {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <h1>Delivery Status</h1>
    <asp:gridview id="grdDelivery" runat="server" autogeneratecolumns="False">
        <Columns>
            <asp:BoundField DataField="DeliveryOrder_Id" HeaderText="Id" />
            <asp:BoundField DataField="Delivery_Date" HeaderText="Date" />
            <asp:BoundField DataField="Delivery_Address" HeaderText="Address" />
            <asp:BoundField DataField="Receive_Status" HeaderText="Status" />
            <asp:BoundField DataField="CompanyOrder_Id" HeaderText="CompanyOrder ID" />
        </Columns>

    </asp:gridview>

    <asp:button id="btnAddDelivery" runat="server" text="Add New Delivery" onclick="btnAddDelivery_Click"></asp:button>

    <!-- insert panel pnlNewRecord here-->
    <asp:panel id="pnlNewRecord" visible="false" cssclass="popupWindow" runat="server" style="margin-top: 0px">

            <!-- Delivery Number 
             <div class="deliveryLabel">
                <asp:Label ID="lblDeliveryOrder_Id" runat="server" Text="Delivery Number"></asp:Label>
            </div>
            <div class="deliveryText">
                <asp:TextBox ID="txtDeliveryOrder_Id"  Width="50px" runat="server"></asp:TextBox>
            </div>
            <div class="clear" />-->

             <!-- Date -->
             <div class="deliveryLabel">
                <asp:Label ID="lblDelivery_Date" runat="server" Text="Date"></asp:Label>
            </div>
            <div class="deliveryText">
                <asp:TextBox ID="txtDelivery_Date"  Width="50px" runat="server"></asp:TextBox>
            </div>
            <div class="clear" />

            
            
             <!-- Address -->
             <div class="deliveryLabel">
                <asp:Label ID="lblDelivery_Address" runat="server" Text="Address"></asp:Label>
            </div>
            <div class="deliveryText">
                <asp:TextBox ID="txtDelivery_Address" runat="server"></asp:TextBox>
            </div>
            <div class="clear" />
           
             <!-- status -->
            <div class="deliveryLabel">
                <asp:Label ID="lblDelivery_Status" runat="server" Text="Status"></asp:Label>
            </div>
            <div class="deliveryText">
                <asp:DropDownList ID="ddlStatusInsert" runat="server" >
                    
                </asp:DropDownList>
            </div>
            <div class="clear" /> 
             <!-- Compay Order Id -->
             <div class="deliveryLabel">
                <asp:Label ID="lblCompanyOrder_Id" runat="server" Text="Id"></asp:Label>
            </div>
            <div class="deliveryText">
                <asp:TextBox ID="txtCompanyOrder_Id"  Width="50px" runat="server"></asp:TextBox>
            </div>
            <div class="clear" />
              <br />
      <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />
          
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
          
   </asp:panel>
<asp:Label ID="lblResult" runat="server" Text=""></asp:Label>

</asp:Content>

