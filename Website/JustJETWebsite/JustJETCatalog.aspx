<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="JustJETCatalog.aspx.cs" Inherits="JustJETCatalog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        h1 {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <h1>JustJET's Catalog</h1>
    <div class="col-md-12 col-sm-12">

        <!-- iso section -->
        <div class="iso-section wow fadeInUp" data-wow-delay="0.3s">

            <ul class="filter-wrapper clearfix">
                <li><a href="#" data-filter="*" class="selected opc-main-bg">All</a></li>
                <li><a href="#" class="opc-main-bg" data-filter=".graphic">Birthday</a></li>
                <li><a href="#" class="opc-main-bg" data-filter=".template">Festive</a></li>
                <li><a href="#" class="opc-main-bg" data-filter=".photoshop">Wedding</a></li>
                <li><a href="#" class="opc-main-bg" data-filter=".branding">Customise</a></li>
            </ul>

            <!-- iso box section -->
            <div class="iso-box-section wow fadeInUp" data-wow-delay="1s">
                <div class="iso-box-wrapper col4-iso-box">

                    
                </div>
            </div>

        </div>

    </div>
</asp:Content>

