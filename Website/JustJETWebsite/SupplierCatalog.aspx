<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SupplierCatalog.aspx.cs" Inherits="SupplierCatalog" %>

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

            .button {
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
            }

            .button:hover {
                background-color: black;
                color: white;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <h1>Supplier's Catalog</h1>

    <!-- iso section -->
    <div class="iso-section wow fadeInUp" data-wow-delay="0.3s">

        <ul class="filter-wrapper clearfix">

            <asp:Button ID="btnRetrieveSupplierCatalog" data-filter="*" CssClass="button" runat="server" Text="Retrieve Catalog" OnClick="btnRetrieveSupplierCatalog_Click" />
        </ul>

        <!-- iso box section -->
        <div class="iso-box-section wow fadeInUp" data-wow-delay="1s">
            <div class="iso-box-wrapper col4-iso-box">
                <asp:GridView ID="grdSupplier" CssClass="gridview" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Product_Id" HeaderText="Product ID" />
                        <asp:BoundField DataField="Product_Name" HeaderText="Name" />
                        <asp:BoundField DataField="Product_Desc" HeaderText="Description" />
                        <asp:ImageField DataImageUrlField="Product_Image" DataImageUrlFormatString="~/images/{0}" HeaderText="Image">
                        </asp:ImageField>
                        <asp:BoundField DataField="Product_Price" DataFormatString="{0:C}" HeaderText="Price" />
                        <asp:BoundField DataField="Product_Stocklevel" HeaderText="Stock" />
                    </Columns>

                </asp:GridView>
            </div>
        </div>

    </div>
</asp:Content>

