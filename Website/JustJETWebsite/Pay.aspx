<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Pay.aspx.cs" Inherits="Pay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .h2 {
            font-weight: bold;
        }

        .radio {
            text-align: center;
            font-size: 20px;
            padding-right: 150px;
            float: left;
        }

            .radio td {
                position: relative;
                padding: 1px;
                text-align: center;
                width: 20%;
            }

            .radio tr {
                text-align: center;
            }

        #table {
            text-align: center;
            margin-left: auto;
            margin-right: auto;
            font-size: 20px;
            width: 100%;
        }

        .paymentDiv {
            width: 700px;
        }

        .buttonCreate {
            background-color: white;
            color: black;
            font-size: 15px;
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
            float: left;
        }

            .buttonCreate:hover {
                background-color: mediumpurple;
                color: white;
            }

        .column {
            float: left;
            width: 50%;
            padding: 10px;
            min-height: 900px;
        }

        .column1 {
            float: left;
            width: 50%;
            padding: 10px;
            height: 300px;
        }

        .buttonConfirm {
            background-color: white;
            color: black;
            font-size: 15px;
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

            .buttonConfirm:hover {
                background-color: lawngreen;
                color: white;
            }

        #ContactDetailsDiv {
            float: left;
            padding-bottom: 50px;
        }

        .CreditCardDiv {
            float: left;
        }

        .buttonPaymentMethod {
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
            border: 1px solid #666;
        }

            .buttonPaymentMethod:hover {
                background-color: #666;
                color: white;
            }

            .buttonPaymentMethod:active {
                background-color: #666;
                color: white;
            }

        .auto-style2 {
            float: left;
            width: 425px;
        }

        .auto-style3 {
            width: 367px;
        }

        .auto-style4 {
            float: left;
            width: 367px;
        }

        .auto-style5 {
            width: 367px;
            height: 34px;
        }

        .auto-style6 {
            height: 34px;
        }

        .auto-style7 {
            width: 603px;
        }

        .modalBackground
        {
            background-color: black;
            filter: alpha(opacity=90) !important;
            opacity: 0.6 !important;
            z-index: 20;
        }
        .modalpopup{
            padding: 20px 0px 24px 10px;
            position: relative;
            width: 450px;
            height: 400px;
            background-color: white;
            border: 1px solid black;
            border-radius: 10px;
        }
    </style>

    <script type="text/javascript" src="js/jquery-1.9.1.min.js"></script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">



    <div class="column">
        <!--Contact Details-->
        <div id="ContactDetailsDiv" style="font-size: 22px;">
            <h1>Shipping Address</h1>
            
            <asp:Label ID="lblName" runat="server" Text="Company Name:" Style="float: left;"></asp:Label>
            <br />
            <asp:TextBox ID="txtName" runat="server" Style="float: left;"></asp:TextBox>

            <br />
            <br />

            <asp:Label ID="lblDeliveryAddress" runat="server" Text="Delivery Address:" Style="float: left;"></asp:Label>
            <br />
            <asp:TextBox ID="txtDeliveryAddress" runat="server" Style="float: left;"></asp:TextBox>

            <br />
            <br />

            <asp:Label ID="lblEmail" runat="server" Text="Email:" Style="float: left;"></asp:Label>
            <br />
            <asp:TextBox ID="txtEmail" runat="server" Style="float: left;"></asp:TextBox>

            <br />
            <br />
            <asp:Button ID="btnConfirm" data-filter="*" CssClass="buttonConfirm" runat="server" Text="Confirm?" OnClick="btnConfirm_Click" />
        </div>
        <br />
        <br />
        <br />
        
        </div>


    <!--Order Summary -->

    <div class="column1">
        <div class="OrderSummaryDiv" style="font-size: 20px;">
            <h1>Order Summary</h1>
            <br />
            <asp:Label ID="lblTotal" runat="server" Text="Total Amount" Style="float: left;"></asp:Label>
            <asp:Label ID="lblTotalContent" runat="server" Text="$$$" Style="float: right;"></asp:Label>
            <br />
            <br />

            <asp:Label ID="lblDiscount" runat="server" Text="Discount" Style="float: left;"></asp:Label>
            <asp:Label ID="lblDiscountContent" runat="server" Text="$$$" Style="float: right;"></asp:Label>
            <br />
            <br />

            <asp:Label ID="lblDeliveryFee" runat="server" Text="Delivery Fee" Style="float: left;"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="(Free Shipping above $300)" Style="float: left;"></asp:Label>
            <asp:Label ID="lblDeliveryFeeContent" runat="server" Text="$$$" Style="float: right;"></asp:Label>
            <br />
            <br />

            <asp:Label ID="lblInterestFee" runat="server" Text="Interest Fee" Style="float: left;"></asp:Label><br />
            <asp:Label ID="Label1" runat="server" Text="(Late Payment)" Style="float: left;"></asp:Label>
            <asp:Label ID="lblInterestFeeContent" runat="server" Text="$$$" Style="float: right;"></asp:Label>
            <br />
            <br />

            <asp:Label ID="lblFinalTotal" runat="server" Text="Final Total Amount" Style="float: left; font-weight: bold"></asp:Label>
            <asp:Label ID="lblFinalTotalContent" runat="server" Text="$$$" Style="float: right; font-weight: bold"></asp:Label>
            <br />
            <br />

        </div>




        <br />
        <br />


    </div>

    <asp:Label ID="lblCompanyName" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblOTPEmail" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblOTP" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblErr" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblInvoiceId" runat="server" Text="" Visible="false"></asp:Label>

    

</asp:Content>

