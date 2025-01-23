<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        h1 {
            font-weight: bold;
        }

        .gridview {
            text-align: center;
            margin-left: auto;
            margin-right: auto;
            font-size: 20px;
            width: 100%;
        }



            .gridview td /* this applies to the Gridviews Data fileds */ {
                padding: 1px;
                text-align: center;
                width: 3%;
                border: solid 0px black;
                border-collapse: collapse;
            }

            .gridview th /* this applies to the Gridviews Headers */ {
                padding: 0px 0px;
                border-width: 0px;
                text-align: center;
            }

        .panelSelect {
            border: 2px solid #A127FF;
            color: #A127FF;
            background-color: lightgray;
            font-style: normal;
            text-align: center;
            padding: 5px;
            border-radius: 10px;
            font-weight: bold;
        }

        .gridviewSelect {
            border: 0.1px #A127FF;
            color: #A127FF;
            font-style: normal;
            text-align: center;
            background-color: white;
            border-radius: 10px;
            font-weight: bold;
        }

        .catLabel {
            float: left;
            width: 200px;
            padding: 5px;
            text-align: center;
        }

        .catAmount {
            float: right;
            width: 400px;
            padding-right: 100px;
            text-align: center;
        }

        .catButton {
            margin-left: auto;
            margin-right: auto;
            text-align: center;
        }

        .clear {
            clear: both;
        }

        .detailsview {
            position: fixed;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            min-width: 800px;
            min-height: 500px;
            background-color: lightgrey;
            font-size: 20px;
        }

        .auto-style4 {
            margin-top: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <h1>Payment/Invoice</h1>

    <!-- iso section -->
    <div class="iso-section wow fadeInUp" data-wow-delay="0.3s">

        <ul class="filter-wrapper clearfix">
            <li><a href="#" data-filter="*" class="selected opc-main-bg">Retrieve Invoice</a></li>
        </ul>
    </div>

    <asp:GridView ID="grdPayment" CssClass="gridview" runat="server" AutoGenerateColumns="False" DataKeyNames="Invoice_Id" GridLines="None" HorizontalAlign="Center" OnRowCommand="grdPayment_RowCommand" OnSelectedIndexChanged="grdPayment_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Invoice_Id" HeaderText="Invoice ID" />
            <asp:BoundField DataField="Invoice_Date" HeaderText="Issue Date" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField DataField="Invoice_DueDate" HeaderText="Due Date" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField DataField="Invoice_Amount" HeaderText="Payment Due" DataFormatString="{0:C}" />
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:Button Text="View Invoice" runat="server" CssClass="gridviewSelect" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div id="detailsview" visible="false">
        <asp:DetailsView ID="DetailsViewInvoice" CssClass="detailsview" runat="server" Height="50px" Width="291px" AutoGenerateRows="False" GridLines="None" OnItemCommand="DetailsViewInvoice_ItemCommand">
            
            <Fields>
                <asp:BoundField DataField="Invoice_Id" HeaderText="Invoice ID" />
                <asp:BoundField DataField="Company_Name" HeaderText="Issue To" />
                <asp:BoundField DataField="Invoice_Date" HeaderText="Issue Date" DataFormatString="{0:dd/MM/yyyy}"/>
                <asp:BoundField DataField="Invoice_DueDate" HeaderText="Due Date" DataFormatString="{0:dd/MM/yyyy}"/>
                <asp:BoundField DataField="Invoice_Amount" HeaderText="Amount Due" />
                <asp:BoundField DataField="Invoice_Subject" HeaderText="Subject" />
                <asp:BoundField DataField="Invoice_Description" HeaderText="Description" />
            </Fields>
            <FooterTemplate>
                <div>
                    <asp:Button ID="btnCancel" runat="server" CssClass="panelSelect" Text="Close" OnClick="btnCancel_Click"/>
                    <asp:Button ID="btnPayment" runat="server" CssClass="panelSelect" Text="Make Payment" OnClick="btnPayment_Click" CommandName ="MakePayment"/>
                </div>
            </FooterTemplate>
        </asp:DetailsView>

    </div>

    <asp:Label ID="lblInvoiceId" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblCompanyName" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblInvoiceDate" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblInvoiceDueDate" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblInvoiceAmount" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblInvoiceSubject" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblInvoiceDescription" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblPaymentId" runat="server" Text=""></asp:Label>
    <!-- iso box section -->
    <div class="iso-box-section wow fadeInUp" data-wow-delay="1s">
        <div class="iso-box-wrapper col4-iso-box">
        </div>
    </div>

</asp:Content>

