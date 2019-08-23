<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="sporAyakkabi.aspx.cs" Inherits="sporAyakkabi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" runat="Server">
    <!-- Page title -->
    <div class="page-title">
        <div class="container">
            <h2>Spor Ayakkabı <small></small></h2>
            <hr />
        </div>
    </div>
    <!-- Page title -->

    <!-- Page content -->

    <div class="shop-items">
        <div class="container">
            <div class="row">
                <div class="col-md-3 hidden-xs">
                    <div class="sidey">
                        <ul class="nav">
                            <li><a href="Default.aspx">Anasayfa</a></li>
                            <li><a href="klasik.aspx">Klasik</a></li>
                            <li><a href="sporAyakkabi.aspx">Spor Ayakkabı</a></li>
                            <li><a href="outdoor.aspx">Outdoor</a></li>
                            <%--<li><a href="carsiPazar.aspx"><i class="fa fa-sell2"></i>&nbsp; Çarşı - Pazar</a></li>--%>
                        </ul>
                    </div>
                </div>
                <div class="col-md-9">


                    <!-- Items List starts -->

                    <div class="row">
                        <asp:Repeater ID="rptUrunler" runat="server" OnItemCommand="rptUrunler_ItemCommand">
                            <ItemTemplate>
                                <!-- Item #1 -->
                                <div class="col-md-4 col-sm-6 col-xs-12">
                                    <div class="item">
                                        <!-- Use the below link to put HOT icon -->
                                        <%--<div class="item-icon"><span>HOT</span></div>--%>
                                        <!-- Item image -->
                                        <div class="item-image">
                                            <a href='urunDetay.aspx?p=<%#Eval("urunId").ToString()%>'>
                                                <img src='UrunResim/<%#Eval("resim").ToString()%>' alt="" class="img-responsive" /></a>
                                        </div>
                                        <!-- Item details -->
                                        <div class="item-details">
                                            <!-- Name -->
                                            <h5><%#Eval("urunAd").ToString()%></h5>
                                            <div class="clearfix"></div>
                                            <!-- Para. Note more than 2 lines. -->
                                            <div style="overflow: hidden; height: 50px;"><%#Eval("urunOzellik").ToString()%> </div>
                                            <hr />
                                            <!-- Price -->
                                            <div class="item-price pull-left" style="width: 80px"><%# Convert.ToDecimal(Eval("kdvDahil")).ToString("N2") %> TL₺</div>
                                            <!-- Add to cart -->
                                            <div class="pull-right">
                                                <asp:Button CommandArgument='<%# Eval("urunId") %>' runat="server" CssClass="btn btn-danger btn-sm" ID="cmdAddToBasket" Text="Sepete Ekle" />
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <!-- Item #2 -->

                    </div>


                    <!-- Items List ends -->
                </div>
                <div class="col-md-3 hidden-md hidden-lg hidden-sm">
                    <div class="sidey">
                        <ul class="nav">
                            <li><a href="Default.aspx">Anasayfa</a></li>
                            <li><a href="klasik.aspx">Klasik</a></li>
                            <li><a href="sporAyakkabi.aspx">Spor Ayakkabı</a></li>
                            <li><a href="outdoor.aspx">Outdoor</a></li>
                            <%--<li><a href="carsiPazar.aspx"><i class="fa fa-sell2"></i>&nbsp; Çarşı - Pazar</a></li>--%>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <div class="sep-bor"></div>
    </div>

</asp:Content>

