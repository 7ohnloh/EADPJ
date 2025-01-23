<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PayMethod.aspx.cs" Inherits="PayMethod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .h2 {
            font-weight: bold;
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

        .modalBackground {
            background-color: black;
            filter: alpha(opacity=90) !important;
            opacity: 0.6 !important;
            z-index: 20;
        }

        .modalpopup {
            padding: 20px 0px 24px 10px;
            position: relative;
            width: 450px;
            height: 400px;
            background-color: white;
            border: 1px solid black;
            border-radius: 10px;
        }

        .auto-style2 {
            width: 591px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <!--Payment Options-->
    <div class="column">


        <div id="PaymentOptionDiv" runat="server" style="font-size: 18px; float: left;">
            <table>
                <tr>
                    <td>
                        <h1 style="float: left;">PAYMENT</h1>
                    </td>
                </tr>
                <tr>
                    <td style="padding-bottom: 10px;">
                        <asp:Label ID="lblPaymentText" runat="server" Text="Click on your payment choice" Style="float: left; font-style: italic; font-size: 15px;"></asp:Label>
                    </td>
                </tr>
                <tr>

                    <td>
                        <asp:Button ID="btnPaypal" class="btn" CssClass="buttonPaymentMethod" runat="server" Text="Paypal" Style="float: left;" OnClick="btnPaypal_Click" />
                        <asp:Button ID="btnCreditCard" class="btn active" CssClass="buttonPaymentMethod" runat="server" Text="Credit Card" OnClick="btnCreditCard_Click" Style="float: left;" />
                        <asp:Button ID="btniBanking" class="btn" CssClass="buttonPaymentMethod" runat="server" Text="iBanking" Style="float: left;" />
                    </td>

                </tr>
            </table>

            <br />
        </div>


        <asp:Label ID="lblAmountDue" runat="server" Text=""></asp:Label>

        <!-- CREDIT CARD -->

        <div id="CreditCardDiv" runat="server">
            <div style="font-size: 20px;" class="auto-style2">
                <br />
                <br />
                
                <table class="auto-style2">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblCreditDetails" runat="server" Text="Enter Credit Card Details" Style="font-weight: bold; font-size: 20px; float: left;"></asp:Label>

                            &nbsp;

                        </td>

                    </tr>
                    <tr>
                        <td style="padding-bottom: 30px; float: left;" class="auto-style4 ">
                            <i class="fa fa-cc-mastercard" style="font-size: 35px; color: #0a3a82"></i>
                            <i class="fa fa-cc-visa" style="font-size: 35px; color: #0157a2"></i>
                            <i class="fa fa-cc-amex" style="font-size: 35px; color: #007bc1"></i>
                        </td>

                    </tr>
                    <tr>
                        <td style="padding-bottom: 10px;" class="auto-style5">

                            <i class="fa fa-user" style="font-size: 25px; float: left; padding-right: 10px;"></i>&nbsp;&nbsp;&nbsp; 	
                                <asp:TextBox ID="txtCardHolder" runat="server" placeholder="Card Holder" Width="216px" Style="float: left;"></asp:TextBox></td>

                        <td style="padding-bottom: 10px;" class="auto-style6">&nbsp;<asp:RequiredFieldValidator runat="server" ErrorMessage="*Please enter card holder's name" ID="rfv_txtCardHolder" ControlToValidate="txtCardHolder" ForeColor="Red" Style="font-size: 17px;"></asp:RequiredFieldValidator>

                        </td>

                    </tr>
                    <tr>

                        <td style="padding-bottom: 10px;" class="auto-style3">
                            <i class="fa fa-credit-card" style="font-size: 25px; float: left; padding-right: 10px;"></i>&nbsp;&nbsp;&nbsp; 	
                                <asp:TextBox ID="txtCreditCardNum" TextMode="Password" runat="server" Width="197px" placeholder="Credit Card Number" CssClass="CreditCardDiv"></asp:TextBox>

                            <input id="cbShowHidePassword" type="checkbox" onclick="ShowHidePassword();" />
                            <label for='cbShowHidePassword' style="font-size: 15px;">Show</label>

                            <script src="http://code.jquery.com/jquery-1.11.3.js" type="text/javascript"></script>
                            <script type="text/javascript">
                                function ShowHidePassword() {
                                    var txt = $('#<%=txtCreditCardNum.ClientID%>');
                                    if (txt.prop("type") == "password") {
                                        txt.prop("type", "text");
                                        $("label[for='cbShowHidePassword']").text("Hide");
                                    }
                                    else {
                                        txt.prop("type", "password");
                                        $("label[for='cbShowHidePassword']").text("Show");
                                    }
                                }
                            </script>
                        </td>
                        <td style="padding-bottom: 10px;">

                            <asp:RegularExpressionValidator ID="rev_txtCreditCardNum" runat="server" ControlToValidate="txtCreditCardNum" ErrorMessage="*Please enter only 16 digits" ValidationExpression="^\d{16}$" ForeColor="Red" Style="font-size: 17px;"></asp:RegularExpressionValidator>
                            <br />
                            <asp:CompareValidator ID="cv_txtCreditCardNum" runat="server" ControlToValidate="txtCreditCardNum" ErrorMessage="*Only numeric integer allowed" ForeColor="Red" Operator="DataTypeCheck" Type="Integer" Style="font-size: 17px;"></asp:CompareValidator>

                        </td>
                    </tr>
                    <tr>
                        <td style="padding-bottom: 10px;" class="auto-style3">
                            <i class="fa fa-lock" style="font-size: 25px; float: left; padding-right: 10px;"></i>&nbsp;&nbsp;&nbsp; 	
                                
                            <asp:TextBox ID="txtSecurityCode" TextMode="Password" runat="server" placeholder="Security Code" Style="float: left;"></asp:TextBox>
                            <input id="cShowHidePassword" type="checkbox" onclick="ShowHidePassword2();" />
                            <label for='cShowHidePassword' style="font-size: 15px;">Show</label>
                            <script src="http://code.jquery.com/jquery-1.11.3.js" type="text/javascript"></script>
                            <script type="text/javascript">
                                function ShowHidePassword2() {
                                    var txt = $('#<%=txtSecurityCode.ClientID%>');
                                    if (txt.prop("type") == "password") {
                                        txt.prop("type", "text");
                                        $("label[for='cShowHidePassword']").text("Hide");
                                    }
                                    else {
                                        txt.prop("type", "password");
                                        $("label[for='cShowHidePassword']").text("Show");
                                    }
                                }
                            </script>

                        </td>
                        <td style="padding-bottom: 10px;">

                            <asp:RegularExpressionValidator ID="rev_txtSecurityCode" runat="server" ControlToValidate="txtSecurityCode" ErrorMessage="*Please enter only 3 digits" ForeColor="Red" ValidationExpression="^\d{3}$" Style="font-size: 17px;"></asp:RegularExpressionValidator>
                            <br />
                            <asp:CompareValidator ID="cv_txtSecurityCode" runat="server" ControlToValidate="txtSecurityCode" ErrorMessage="*Only numeric integer allowed" ForeColor="Red" Operator="DataTypeCheck" Type="Integer" Style="font-size: 17px;"></asp:CompareValidator>

                        </td>
                    </tr>

                    <tr>
                        <td class="auto-style3" style="padding-bottom: 20px">
                            <asp:Label ID="lblExpiration" runat="server" Text=" Expiration:" class="fa fa-calendar" Style="float: left; font-size: 22px;"></asp:Label>
                            &nbsp;&nbsp;&nbsp; 	
                            <asp:DropDownList ID="ddlMonth" runat="server" Style="margin-left: 5px; font-size: 22px;" CssClass="CreditCardDiv" Width="127px">
                                <asp:ListItem>January</asp:ListItem>
                                <asp:ListItem>February</asp:ListItem>
                                <asp:ListItem>March</asp:ListItem>
                                <asp:ListItem>April</asp:ListItem>
                                <asp:ListItem>May</asp:ListItem>
                                <asp:ListItem>June</asp:ListItem>
                                <asp:ListItem>July</asp:ListItem>
                                <asp:ListItem>August</asp:ListItem>
                                <asp:ListItem>September</asp:ListItem>
                                <asp:ListItem>October</asp:ListItem>
                                <asp:ListItem>November</asp:ListItem>
                                <asp:ListItem>December</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlYear" runat="server" Style="float: left; font-size: 22px;">
                                <asp:ListItem>2020</asp:ListItem>
                                <asp:ListItem>2021</asp:ListItem>
                                <asp:ListItem>2022</asp:ListItem>
                                <asp:ListItem>2023</asp:ListItem>
                                <asp:ListItem>2024</asp:ListItem>
                                <asp:ListItem>2025</asp:ListItem>
                                <asp:ListItem>2026</asp:ListItem>
                                <asp:ListItem>2027</asp:ListItem>
                                <asp:ListItem>2028</asp:ListItem>
                                <asp:ListItem>2029</asp:ListItem>
                                <asp:ListItem>2030</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                    </tr>
                    
                        

                </table>

            </div>

            <br />
            <br />
            <asp:Button ID="btnPay" CssClass="buttonCreate" Height="50px" Width="250px" runat="server" Text="Proceed With Payment" OnClick="btnPay_Click" />
            
            <br />
            <div>

                
            </div>
        </div>

    </div>
    <!-- iBanking -->
    <div id="iBankingDiv" runat="server" style="display: none;">
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
    </div>
    <asp:Label ID="lblOTP" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblOTPEmail" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblErr" runat="server" Text=""></asp:Label>
</asp:Content>

