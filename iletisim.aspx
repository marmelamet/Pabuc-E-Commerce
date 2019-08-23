<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="iletisim.aspx.cs" Inherits="iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" runat="Server">
    <!-- Page content -->

    <div class="contactus ">
        <!-- Google maps -->
        <div class="gmap">
            <!-- Google Maps. Replace the below iframe with your Google Maps embed code -->

            <iframe src="https://www.google.com.tr/maps/place/F%C4%B1rat+%C3%9Cniversitesi,+Teknoloji+Fak%C3%BCltesi/@38.6808473,39.1950213,18z/data=!4m8!1m2!2m1!1zZsSxcmF0IMO8bml2ZXJzaXRlc2k!3m4!1s0x4076c0453873446b:0x8944e73c644c7182!8m2!3d38.6812756!4d39.1960826" height="400" style="border:0"></iframe>
        </div>

        <div class="container">
            <div class="row">
                <div class="col-md-6 col-sm-7">
                    <div class="cwell">
                        <!-- Contact form -->
                        <h5>İletişim Formu</h5>


                        <div class="form-group">
                            <asp:Label ID="lbl_ad" runat="server" Text="Adınız"></asp:Label>
                            <asp:TextBox ID="txt_ad" runat="server" CssClass="form-control" placeholder="Adınızı Giriniz"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="req_ad" runat="server" ErrorMessage="Bu alan boş geçilemez" ControlToValidate="txt_ad" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                           <asp:Label ID="lbl_mail" runat="server" Text="Mail Adresiniz"></asp:Label>
                            <asp:TextBox ID="txt_mail" runat="server" CssClass="form-control" placeholder="Emailinizi Giriniz"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="req_mail" runat="server" ErrorMessage="Bu alan boş geçilemez" ControlToValidate="txt_mail" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                           <asp:Label ID="lbl_mesaj" runat="server" Text="Mesajınız"></asp:Label>
                            <asp:TextBox ID="txt_mesaj" runat="server" CssClass="form-control" placeholder="Mesajınızı Giriniz" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="req_mesaj" runat="server" ErrorMessage="Bu alan boş geçilemez" ControlToValidate="txt_mesaj" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                        
                        
                        <asp:Button ID="btn_gonder" runat="server" Text="Gönder" CssClass="btn btn-info" />                        
                        <asp:Button ID="btn_temizle" runat="server" Text="Temizle" CssClass="btn btn-default" />


                    </div>
                </div>
                <div class="col-md-6 col-sm-5">
                    <div class="cwell">
                        <!-- Address section -->
                        <h5>Adres</h5>
                        <div class="address">
                            <address>
                                <!-- Company name -->
                                <h6>Pabuç</h6>
                                <!-- Address -->
                                Elazığ
                                <br />
                                <!-- Phone number -->
                                <abbr title="Telefon Numarası">T:</abbr>
                                <a href="tel:+9000000000">+90 000 000 00 00</a>
                            </address>

                            <address>
                                <!-- Name -->
                                <h6>E Mail</h6>
                                <!-- Email -->
                                <a href="mailto:pabuc@pabuc.com">pabuc@pabuc.com</a>
                            </address>

                        </div>
                    </div>
                </div>
            </div>
            <div class="blocky"></div>

        </div>
    </div>
</asp:Content>

