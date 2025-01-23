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

        .buttonUpdate {
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
            border: 1px solid greenyellow;
        }

            .buttonUpdate:hover {
                background-color: greenyellow;
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
            background-color: gray;
            font-size: 20px;
            font-weight: bold;
        }

        .ImageUpload {
            display: inline;
        }
        .auto-style2 {
            position: fixed;
            top: -28000%;
            left: 49%;
            transform: translate(-50%, -50%);
            min-width: 800px;
            min-height: 500px;
            font-size: 20px;
            font-weight: bold;
            border-radius: 4px;
            -webkit-box-shadow: 0 1px 1px rgba(0, 0, 0, .05);
            box-shadow: 0 1px 1px rgba(0, 0, 0, .05);
            border: 1px solid transparent;
            margin-bottom: 20px;
            background-color: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <h1>Product Catalog</h1>

    <!-- iso box section -->
    <div class="iso-box-section wow fadeInUp" data-wow-delay="1s">
        <div class="iso-box-wrapper col4-iso-box">
            <asp:Button ID="btnCreate" CssClass="buttonCreate" Height="50px" Width="291px" runat="server" Text="Add New Products" OnClick="btnCreate_Click" />
            <br />
            <br />
            <asp:GridView ID="grdCatalog" CssClass="gridview" runat="server" AutoGenerateColumns="False" GridLines="Horizontal" HorizontalAlign="Center" Style="min-width: 800px; min-height: 200px;" 
                DataKeyNames="Product_Id" OnRowCancelingEdit="grdCatalog_RowCancelingEdit" OnRowEditing="grdCatalog_RowEditing" OnRowDeleting="grdCatalog_RowDeleting" OnRowUpdating="grdCatalog_RowUpdating" AllowPaging="True" OnPageIndexChanging="grdCatalog_PageIndexChanging" PageSize="1">
                <Columns>
                    <asp:BoundField DataField="Product_Id" HeaderText="Product ID" ReadOnly ="True"/>
                    <asp:TemplateField HeaderText="Name">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Product_Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("Product_Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDesc" runat="server" Text='<%# Bind("Product_Desc") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDesc" runat="server" Text='<%# Bind("Product_Desc") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtImage" runat="server" Text='<%# Eval("Product_Image") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Image ID="lblImage" runat="server" ImageUrl='<%# Eval("Product_Image", "~/images/{0}") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("Product_Price") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Product_Price", "{0:C}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Stock">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtStock" runat="server" Text='<%# Bind("Product_Stocklevel") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblStock" runat="server" Text='<%# Bind("Product_Stocklevel") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick ="javascript: return confirm('Confirm Delete?')"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
            <br />
            <br />
            

            <asp:Panel ID="CreatePanel" CssClass="auto-style2" runat="server">
                <br />
                <br />
                <br />
                ADD NEW PRODUCT
                <br />
                <asp:Label ID="lbl_Name" runat="server" Text="Name:"></asp:Label>
                <br />
                <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                <br />
                <br />


                <asp:Label ID="lbl_Desc" runat="server" Text="Description:"></asp:Label>
                <br />
                <asp:TextBox ID="tbDesc" runat="server"></asp:TextBox>
                <br />
                <br />


                <asp:Label ID="lbl_Image" runat="server" Text="Image:"></asp:Label>
                <br />
                <div class="ImageUpload">
                    <asp:FileUpload ID="ImageUpload" runat="server" Style="display: inline;" />
                </div>
                <br />
                <br />


                <asp:Label ID="lbl_Price" runat="server" Text="Price:"></asp:Label>
                <br />
                <asp:TextBox ID="tbPrice" runat="server"></asp:TextBox>
                <br />
                <br />


                <asp:Label ID="lbl_Stock" runat="server" Text="Stock Level:"></asp:Label>
                <br />
                <asp:TextBox ID="tbStock" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Button ID="btnCancel" data-filter="*" CssClass="buttonDelete" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                <asp:Button ID="btnInsert" data-filter="*" CssClass="buttonCreate" runat="server" Text="Insert" OnClick="btnInsert_Click"/>

                <br />
                <br />
            </asp:Panel>

            <asp:label ID="lbl_Error" runat="server" text=""></asp:label>
        </div>
    </div>



</asp:Content>

