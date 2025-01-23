<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PurchaseOrder.aspx.cs" Inherits="PurchaseOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        h1{
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
    <h1>Purchase Order</h1>

    <!-- iso section -->
        <div class="iso-section wow fadeInUp" data-wow-delay="0.3s">

            <ul class="filter-wrapper clearfix">
                <li><a href="#" data-filter="*" class="selected opc-main-bg">Latest</a></li>
                <li><a href="#" class="opc-main-bg" data-filter=".graphic">Earliest</a></li>
                <li><a href="#" class="opc-main-bg" data-filter=".graphic">Create Purchase Order</a></li>
            </ul>

            <!-- iso box section -->
            <div class="iso-box-section wow fadeInUp" data-wow-delay="1s">
                <div class="iso-box-wrapper col4-iso-box">

                    
                </div>
            </div>

        </div>
</asp:Content>

