<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" runat="Server">

    <!-- Carousel starts --><div id="carousel-example-generic" class="carousel slide" style="background-color:#dddddd !important">
        <!-- Indicators -->
                <!-- Wrapper for slides -->
        <div class="carousel-inner">
            <asp:Repeater ID="rptSlider" runat="server">
                <ItemTemplate>
                    <!-- Item -->
                    <div class="item animated fadeInRight">
                        <a href='urunDetay.aspx?p=<%#Eval("urunId").ToString()%>'>
                            <img src='UFile/<%#Eval("slider").ToString()%>' alt="" class="img-responsive" /></a>
                        <div class="carousel-caption">
                            <h2 class="animated fadeInLeftBig"><%#Eval("urunAd").ToString()%></h2>
                            <p class="animated fadeInRightBig"><%#Eval("sliderAciklama").ToString()%></p>
                            <a href='urunDetay.aspx?p=<%#Eval("urunId").ToString()%>' class="animated fadeInLeftBig btn btn-info btn-lg">Satın Al ₺ <%# Convert.ToDecimal(Eval("sliderFiyat")).ToString("N2") %> </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <!-- Controls -->
            <a class="left carousel-control" href="#carousel-example-generic" data-slide="prev">
                <span class="icon-prev"></span>
            </a>
            <a class="right carousel-control" href="#carousel-example-generic" data-slide="next">
                <span class="icon-next"></span>
            </a>
        </div>
        <ol class="carousel-indicators">
        <% for (int i = 0; i < rptSlider.Items.Count; i++)
            { %>
            <li data-target="#carousel-example-generic" data-slide-to="0" <%= (i==0?"class='active'":"") %>></li>
        <%} %>
            </ol>
        
    </div>
    <!-- carousel ends -->

    <!-- Hero starts -->

    <!-- Hero ends -->

    <!-- Items List starts -->
    <asp:UpdatePanel runat="server" ID="up2">
        <ContentTemplate>
            <div class="shop-items blocky" style="background-color:#dddddd !important">
                <div class="container">

                    <div class="row">
                        <!-- Item #1 -->
                        <asp:Repeater ID="rptUrunler" runat="server" OnItemCommand="rptUrunler_ItemCommand">
                            <ItemTemplate>
                                <div class="col-md-3 col-sm-6 col-xs-12">
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
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <!-- Items List ends -->
    <!-- Recent posts Starts -->
    <%--<div class="recent-posts blocky">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <!-- Section title -->
                    <div class="section-title">
                        <h4><i class="fa fa-desktop color"></i>&nbsp;Öne Çıkan Ürünler</h4>
                    </div>

                    <div id="item-carousel" class="carousel slide" data-ride="carousel">
                        <!-- Wrapper for slides -->
                        <div class="carousel-inner">


                            <div class="item">
                                <div class="row">
                                    <asp:Repeater ID="rptOneCikanUrunler" runat="server">
                                        <ItemTemplate>

                                            <div class="col-md-3 col-sm-6">
                                                <!-- single item -->
                                                <div class="s-item">
                                                    <!-- Image link -->
                                                    <a href='urunDetay.aspx?p=<%#Eval("urunId").ToString()%>'>
                                                        <img src='OneCikanUrunGorsel/<%#Eval("resim").ToString()%>' alt="" class="img-responsive" /></a>
                                                    <!-- portfolio caption -->
                                                    <div class="s-caption">
                                                        <!-- heading and paragraph -->
                                                        <h4><%#Eval("urunAd").ToString()%></h4>
                                                        <p><%#Eval("aciklama").ToString()%></p>
                                                    </div>
                                                </div>
                                            </div>


                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>

                            </div>



                        </div>

                        <!-- Controls -->
                        <a class="left c-control" href="#item-carousel" data-slide="prev">
                            <i class="fa fa-chevron-left"></i>
                        </a>
                        <a class="right c-control" href="#item-carousel" data-slide="next">
                            <i class="fa fa-chevron-right"></i>
                        </a>

                    </div>



                </div>

            </div>
        </div>
    </div>--%>


    <!-- Recent posts Ends -->
</asp:Content>

