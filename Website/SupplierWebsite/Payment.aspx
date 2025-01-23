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
        }

            .gridview td /* this applies to the Gridviews Data fileds */ {
                padding: 1px;
                text-align: center;
                width: 5%;
                border: solid 0px black;
                border-collapse: collapse;
            }

            .gridview th /* this applies to the Gridviews Headers */ {
                padding: 0px 0px;
                border-width: 0px;
                text-align: center;
            }

        .buttonCreate {
            background-color: white;
            color: black;
            font-size: 13px;
            font-weight: 400;
            letter-spacing: 2px;
            padding: 8px 17px;
            margin-right: 2px;
            margin-left: 2px;
            text-transform: uppercase;
            text-decoration: none;
            transition: all 0.4s ease-in-out;
            text-align: center;
            border-radius: 10px;
            border: 1px solid mediumpurple;
        }

            .buttonCreate:hover {
                background-color: mediumpurple;
                color: white;
            }

        .buttonDelete {
            background-color: white;
            color: black;
            font-size: 13px;
            font-weight: 400;
            letter-spacing: 2px;
            padding: 8px 17px;
            margin-right: 2px;
            margin-left: 2px;
            text-transform: uppercase;
            text-decoration: none;
            transition: all 0.4s ease-in-out;
            text-align: center;
            border-radius: 10px;
            border: 1px solid red;
        }

            .buttonDelete:hover {
                background-color: red;
                color: white;
            }

        .panel {
            position: fixed;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            min-width: 800px;
            min-height: 500px;
            background-color: lightgrey;
            font-size: 20px;
        }

        .ImageUpload {
            display: inline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <h1>Payment/Invoice</h1>
    <asp:Button ID="btnCreate" CssClass="buttonCreate" Height="50px" Width="291px" runat="server" Text="Add New Payment" OnClick="btnCreate_Click" />
    <!-- iso section -->
    <div class="iso-section wow fadeInUp" data-wow-delay="0.3s">
        <br />
        <br />

        <asp:GridView ID="grdPayment" CssClass="gridview" runat="server" AutoGenerateColumns="False" GridLines="Horizontal" HorizontalAlign="Center" Style="min-width: 800px; min-height: 200px;"
            DataKeyNames="Invoice_Id" OnRowCancelingEdit="grdPayment_RowCancelingEdit" OnRowDeleting="grdPayment_RowDeleting" OnRowEditing="grdPayment_RowEditing" OnRowUpdating="grdPayment_RowUpdating" OnRowCommand="grdPayment_RowCommand" OnSelectedIndexChanged="grdPayment_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Invoice_Id" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Company_Name" HeaderText="Issue To" ReadOnly="True" />
                <asp:BoundField DataField="Invoice_Date" HeaderText="Issue Date" ReadOnly="True" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:TemplateField HeaderText="Due Date">
                    <EditItemTemplate>
                        <asp:TextBox ID="tbInvoice_DueDate" runat="server" Text='<%# Bind("Invoice_DueDate", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblInvoice_DueDate" runat="server" Text='<%# Bind("Invoice_DueDate", "{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount">
                    <EditItemTemplate>
                        <asp:TextBox ID="tbInvoice_Amount" runat="server" Text='<%# Bind("Invoice_Amount") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblInvoice_Amount" runat="server" Text='<%# Bind("Invoice_Amount", "{0:C}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Subject">
                    <EditItemTemplate>
                        <asp:TextBox ID="tbInvoice_Subject" runat="server" Text='<%# Bind("Invoice_Subject") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblInvoice_Subject" runat="server" Text='<%# Bind("Invoice_Subject") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <EditItemTemplate>
                        <asp:TextBox ID="tbInvoice_Description" runat="server" Text='<%# Bind("Invoice_Description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblInvoice_Description" runat="server" Text='<%# Bind("Invoice_Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:BoundField DataField="PaymentStatus" HeaderText="Payment Status" />


                <asp:CommandField ShowEditButton="True" />


                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="javascript: return confirm('Confirm Delete?')"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:Button Text="Update status" runat="server" CssClass="gridviewSelect" CommandName="Select" CommandArgument='<%#Eval("Invoice_Id")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>

        </asp:GridView>
        <br />
        <br />

        <asp:Panel ID="CreatePanel" CssClass="panel" runat="server">
            <br />
            <br />
            ADD NEW PAYMENT
                <br />

            <asp:Label ID="lblIssueTo" runat="server" Text="Issue To"></asp:Label>
            <br />
            <asp:TextBox ID="tbIssueTo" runat="server"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="lblIssueDate" runat="server" Text="Issue Date (DD/MM/YYYY)"></asp:Label>
            <br />
            <asp:TextBox ID="tbIssueDate" runat="server"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="lblDueDate" runat="server" Text="Due Date (DD/MM/YYYY)"></asp:Label>
            <br />
            <asp:TextBox ID="tbDueDate" runat="server"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="lblAmount" runat="server" Text="Amount Due"></asp:Label>
            <br />
            <asp:TextBox ID="tbAmount" runat="server"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="lblSubject" runat="server" Text="Subject"></asp:Label>
            <br />
            <asp:TextBox ID="tbSubject" runat="server"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
            <br />
            <asp:TextBox ID="tbDescription" runat="server"></asp:TextBox>
            <br />
            <br />


            <asp:Button ID="btnCancel" data-filter="*" CssClass="buttonDelete" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            <asp:Button ID="btnInsert" data-filter="*" CssClass="buttonCreate" runat="server" Text="Insert" OnClick="btnInsert_Click" />
            <br />
            <br />
        </asp:Panel>

        <asp:Label ID="lbl_Error" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>

        <asp:GridView ID="grdPaymentStatus" CssClass="gridview" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grdPaymentStatus_SelectedIndexChanged" DataKeyNames="Payment_Id">
            <Columns>
                <asp:TemplateField HeaderText="Payment ID">
                    
                    <ItemTemplate>
                        <asp:Label ID="lblPaymentId" runat="server" Text='<%# Bind("Payment_Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    
                    <ItemTemplate>
                        <asp:Label ID="lblPaymentStatus" runat="server" Text='<%# Bind("Payment_Status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Invoice ID">
                    
                    <ItemTemplate>
                        <asp:Label ID="lblInvoiceId" runat="server" Text='<%# Bind("Invoice_Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowSelectButton="True"/>
            </Columns>
        </asp:GridView>

        <asp:Detailsview ID="DVPayment" runat="server" height="50px" width="125px"></asp:Detailsview>
        <asp:label ID="Label1" runat="server" text=""></asp:label>
        <asp:label ID="lblStatus" runat="server" text=""></asp:label>

        <!-- iso box section -->
        <div class="iso-box-section wow fadeInUp" data-wow-delay="1s">
            <div class="iso-box-wrapper col4-iso-box">
            </div>

        </div>

    </div>


</asp:Content>

