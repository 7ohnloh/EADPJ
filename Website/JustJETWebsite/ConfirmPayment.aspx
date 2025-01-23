<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConfirmPayment.aspx.cs" Inherits="ConfirmPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .ConfirmPaymentDiv {
            margin: auto;
            width: 40%;
            padding: 10px;
            font-size: 25px;
        }

        .buttonOk {
            background-color: white;
            color: black;
            font-size: 20px;
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
            border: 1px solid lawngreen;
            float: left;
        }

            .buttonOk:hover {
                background-color: lawngreen;
                color: white;
            }
        .buttonOTP {
            background-color: white;
            color: black;
            font-size: 12px;
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
            border: 1px solid deepskyblue;

        }

            .buttonOTP:hover {
                background-color: deepskyblue;
                color: white;
            }

            .buttonOTP:active {
                background-color: deepskyblue;
                color: white;
            }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <h1>Confirm Your Payment</h1>
    <div class="ConfirmPaymentDiv">
        <asp:Label ID="lblCardNum" runat="server" Text="Card Number: " Style="float: left;"></asp:Label>
        <asp:Label ID="lblCardNumContent" runat="server" Text="xxx" Style="float: right;"></asp:Label>
        <br />

        <asp:Label ID="lblExpiryDate" runat="server" Text="Expiry Date:" Style="float: left;"></asp:Label>
        <asp:Label ID="lblExpiryDateContent" runat="server" Text="xxx" Style="float: right;"></asp:Label>
        <br />

        <asp:Label ID="lblCardHolder" runat="server" Text="Name on Card: " Style="float: left;"></asp:Label>
        <asp:Label ID="lblCardHolderContent" runat="server" Text="xxx" Style="float: right;"></asp:Label>
        <br />

        <asp:Label ID="lblBillingAddress" runat="server" Text="Billing Address: " Style="float: left;"></asp:Label>
        <asp:Label ID="lblBillingAddressContent" runat="server" Text="xxx" Style="float: right;"></asp:Label>
        <br />

        <asp:Label ID="lblTotalAmount" runat="server" Text="Total Amount: " Style="float: left;"></asp:Label>
        <asp:Label ID="lblTotalAmountContent" runat="server" Text="xxx" Style="float: right;"></asp:Label>
        <br />

        <asp:Label ID="lblConfirmationEmail" runat="server" Text="Email: " Style="float: left;"></asp:Label>
        <asp:Label ID="lblConfirmationEmailContent" runat="server" Text="xxx" Style="float: right;"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="In order to confirm, an OTP (One Time Password) has been sent to your email. Please enter the your OTP below." style="float:left"></asp:Label><br />
        <asp:Label ID="lblotpcode" runat="server" Text="OTP:" Style="float: left;"></asp:Label><asp:TextBox ID="txtOTP" runat="server"></asp:TextBox>
        <br />
        <asp:RegularExpressionValidator ID="rev_OTP" runat="server" ControlToValidate="txtOTP" ErrorMessage="*Please enter only 6 digits" ValidationExpression="^\d{6}$" ForeColor="Red" Style="font-size: 17px;"></asp:RegularExpressionValidator>
        <br />
        <asp:CompareValidator ID="cv_OTP" runat="server" ControlToValidate="txtOTP" ErrorMessage="*Only numeric integer allowed" ForeColor="Red" Operator="DataTypeCheck" Type="Integer" Style="font-size: 17px;"></asp:CompareValidator>



        <asp:Button ID="btnOk" CssClass="buttonOk" Height="50px" Width="100px" runat="server" Text="Ok" OnClick="btnOk_Click" />
    </div>

    <asp:Label ID="lblInvoiceId" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblErr" runat="server" Text=""></asp:Label>
</asp:Content>

