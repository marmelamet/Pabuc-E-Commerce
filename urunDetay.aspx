<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="urunDetay.aspx.cs" Inherits="urunDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" runat="Server">
    <!-- Page title -->
    <div class="page-title">
        <div class="container">
            <h2> Ürün Detay <small></small></h2>
            <hr />
        </div>
    </div>
    <!-- Page title -->
    <!-- Page content -->

    <div class="shop-items">
        <div class="container">

            <div class="row">

                <div class="col-md-9 col-md-push-3">


                    <div class="single-item">
                        <div class="row">
                            <div class="col-md-4 col-xs-5">

                                <div class="item-image">
                                    <img class="zoom" src="img/items/ND0001.jpg" data-zoom-image="img/items/ND0001.jpg" />
                                </div>


                            </div>
                            <div class="col-md-5 col-xs-7">
                                <!-- Title -->
                                <h4>
                                    <asp:Label ID="lblUrunAd1" runat="server"><%#Eval("urunAd").ToString()%></asp:Label></h4>
                                <h5><strong>Satış Fiyatı : ₺<asp:Label ID="lblKdvDahil" runat="server"><%#Eval("kdvDahil").ToString()%></asp:Label></strong></h5>
                                <p>
                                    <strong>Ayakkabı Numarası</strong> :
                                    <asp:DropDownList ID="ddl_ayakkabi_no" runat="server"></asp:DropDownList>
                                </p>
                                <p><strong>Stok Durumu</strong> : Mevcut</p>
                                <br />
                                <div class="form-group">
                                    <!-- Dropdown menu -->
                                    <select class="form-control">
                                        <option>Adet</option>
                                        <option>1</option>
                                        <option>2</option>
                                        <option>3</option>
                                        <option>4</option>
                                    </select>
                                </div>
                                <!-- Quantity and add to cart button -->

                                <div class="input-group">
                                    <span class="input-group-btn">
                                        <asp:Button ID="btn_hemen_al" CssClass="btn btn-info" runat="server" Text="Hemen Satın Al" />
                                    </span>
                                </div>
                                <!-- /input-group -->

                                <!-- Add to wish list -->
                                <a href="#">+ Sepete Ekle</a>

                                <!-- Share button -->
                                <%--diğer resimlerin bulunduğu yer--%>
                                <div id="gal1" class="si-link">
                                    <%--repetaer buraya gelecek...--%>
                                    <a href="#" class="active" data-image="img/items/ND0001.jpg" data-zoom-image="img/items/ND0001.jpg">
                                        <img id="img2" src="img/items/ND0001.jpg" />
                                    </a>
                                    <%--repetaer buraya gelecek...--%>
                                    <a href="#" data-image="UrunResim/21720151326184.jpg" data-zoom-image="UrunResim/21720151326184.jpg">
                                        <img id="img_01" src="UrunResim/21720151326184.jpg" />
                                    </a>
                                    <a href="#" data-image="UrunResim/21720151327116.jpg" data-zoom-image="UrunResim/21720151327116.jpg">
                                        <img id="img1" src="UrunResim/21720151327116.jpg" />
                                    </a>
                                    
                                </div>

                                <%--diğer resimlerin bulunduğu yer--%>
                            </div>
                        </div>
                    </div>

                    <br />
                    <br />

                    <!-- Description, specs and review -->

                    <ul id="myTab" class="nav nav-tabs">
                        <!-- Use uniqe name for "href" in below anchor tags -->
                        <li class="active"><a href="#tab1" data-toggle="tab">Ürün Bilgisi</a></li>
                        <li><a href="#tab2" data-toggle="tab">Özellikler</a></li>
                    </ul>

                    <!-- Tab Content -->
                    <div id="myTabContent" class="tab-content">
                        <!-- Description -->
                        <div class="tab-pane fade in active" id="tab1">
                            <h5><strong>
                                <asp:Label ID="lblUrunAd2" runat="server"><%#Eval("urunAd").ToString()%></asp:Label></strong></h5>
                            <p></p>
                        </div>

                        <!-- Sepcs -->
                        <div class="tab-pane fade" id="tab2">

                            <h5><strong>Ürün Özellikleri:</strong></h5>
                            <asp:Repeater ID="rptUrunler" runat="server">
                                <ItemTemplate>
                                    <table class="table table-striped">
                                        <tbody>
                                            <tr>
                                                <td><strong>Kategorisi</strong></td>
                                                <td><%#Eval("kategoriAd").ToString()%></td>
                                            </tr>
                                            <tr>
                                                <td><strong>Adı</strong></td>
                                                <td><%#Eval("urunAd").ToString()%></td>
                                            </tr>
                                            <tr>
                                                <td><strong>Numara</strong></td>
                                                <td><%#Eval("numara").ToString()%></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>


                <div class="col-md-3 col-md-pull-9">
                    <div class="sidey">
                        <ul class="nav">
                            <li><a href="Default.aspx"><i class="fa fa-home"></i>&nbsp; Anasayfa</a></li>
                            <li><a href="klasik.aspx"><i class="fa  fa-stylish2"></i>&nbsp; Klasik</a></li>
                            <li><a href="sporAyakkabi.aspx"><i class="fa fa-formal"></i>&nbsp; Spor Ayakkabı</a></li>
                            <li><a href="outdoor.aspx"><i class="fa fa-bags"></i>&nbsp; Outdoor</a></li>
                           <%-- <li><a href="carsiPazar.aspx"><i class="fa fa-sell2"></i>&nbsp; Çarşı - Pazar</a></li>--%>
                        </ul>
                    </div>


                </div>
            </div>

            <div class="sep-bor"></div>
        </div>
    </div>
</asp:Content>

