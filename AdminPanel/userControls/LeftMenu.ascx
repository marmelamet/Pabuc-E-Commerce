<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftMenu.ascx.cs" Inherits="LeftMenu" %>
<div class="span2 main-menu-span">
    <div class="well nav-collapse sidebar-nav">
        <ul class="nav nav-tabs nav-stacked main-menu">
           <%-- <li class="nav-header hidden-tablet">Sabit Sayfalar</li>
            <li><a class="ajax-link" href="KullaniciSozlesmesi.aspx"><i class="icon-list-alt"></i><span class="hidden-tablet">Kullanıcı Sözleşmesi</span></a></li>
            <li><a class="ajax-link" href="OdemeTeslimat.aspx"><i class="icon-list-alt"></i><span class="hidden-tablet">Ödeme ve Teslimat</span></a></li>
            <li><a class="ajax-link" href="GizlilikGuvenlik.aspx"><i class="icon-list-alt"></i><span class="hidden-tablet">Gizlilik ve Güvenlik</span></a></li>
            <li><a class="ajax-link" href="DegisimIade.aspx"><i class="icon-list-alt"></i><span class="hidden-tablet">Değişim ve İade</span></a></li>
            <li><a class="ajax-link" href="Iletisim.aspx"><i class="icon-list-alt"></i><span class="hidden-tablet">İletişim</span></a></li>--%>
             <li class="nav-header hidden-tablet">Slider</li>
            <li><a class="ajax-link" href="SliderEkleme.aspx"><i class="icon-list-alt"></i><span class="hidden-tablet">Slider Ekleme</span></a></li>
            <li><a class="ajax-link" href="Slider.aspx"><i class="icon-list-alt"></i><span class="hidden-tablet">Slider Listele</span></a></li>
            <li class="nav-header hidden-tablet">Kategoriler</li>
            <li><a class="ajax-link" href="KategoriEkleme.aspx"><i class="icon-list-alt"></i><span class="hidden-tablet">Kategori Ekleme</span></a></li>
            <li><a class="ajax-link" href="Kategoriler.aspx"><i class="icon-search"></i><span class="hidden-tablet">Kategori Listesi</span></a></li>
            <li class="nav-header hidden-tablet">Ürünler</li>
            <li><a class="ajax-link" href="UrunEkleme.aspx"><i class="icon-list-alt"></i><span class="hidden-tablet">Ürün Ekleme</span></a></li>
            <li><a class="ajax-link" href="Urunler.aspx"><i class="icon-search"></i><span class="hidden-tablet">Ürün Listesi</span></a></li>
             <li class="nav-header hidden-tablet">Öne Çıkan Ürünler</li>
            <li><a class="ajax-link" href="OneCikanUrunEkleme.aspx"><i class="icon-list-alt"></i><span class="hidden-tablet">Öne Çıkan Ürün Ekleme</span></a></li>
            <li><a class="ajax-link" href="OneCikanUrunler.aspx"><i class="icon-search"></i><span class="hidden-tablet">Öne Çıkan Ürünlerin Listesi</span></a></li>
            <asp:Panel ID="pnlAdmin" runat="server" Visible="false" CssClass="nav nav-tabs nav-stacked main-menu">
                <li class="nav-header hidden-tablet">Kullanıcılar</li>
                <li><a class="ajax-link" href="KullaniciEkleme.aspx"><i class="icon-list-alt"></i><span class="hidden-tablet">Kullanıcı Ekleme</span></a></li>
                <li><a class="ajax-link" href="Kullanicilar.aspx"><i class="icon-user"></i><span class="hidden-tablet">Kullanıcı Listesi</span></a></li>
            </asp:Panel>
            <li class="nav-header hidden-tablet">Siparişler</li>
            <li><a class="ajax-link" href="SiparisListesi.aspx"><i class="icon-shopping-cart"></i><span class="hidden-tablet">Siparişler</span></a></li>
            <%--<li class="nav-header hidden-tablet">Kargo</li>
            <li><a class="ajax-link" href="KargoEkleme.aspx"><i class="icon-shopping-cart"></i><span class="hidden-tablet">Kargo Ekleme</span></a></li>
            <li><a class="ajax-link" href="Kargolar.aspx"><i class="icon-shopping-cart"></i><span class="hidden-tablet">Kargo Listesi  </span></a></li>--%>
        </ul>
    </div>
</div>
