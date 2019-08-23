<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="odeme.aspx.cs" Inherits="odeme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" runat="Server">
    <!-- Page title -->
    <div class="page-title">
        <div class="container">
            <h2>Sepetim <%--<small>Subtext for header</small>--%></h2>
            <hr />
        </div>
    </div>
    <!-- Page title -->
    <!-- Page content -->

    <div class="view-cart">
        <div class="container">
            <div class="row">
                <div class="col-md-5">
                    <h4>Sepetteki Ürünler</h4>

                    <hr />
                    <asp:Repeater runat="server" ID="rptBasket">
                        <HeaderTemplate>
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                        <th>Ürün Ad</th>
                                        <th>Adet</th>
                                        <th>Fiyat</th>
                                        <th>KDV (%)</th>
                                        <th>Toplam
                                            <br />
                                            Fiyat
                                            <br />
                                            (KDV Dahil)</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("urunAd") %></td>
                                        <td><%# Eval("adet") %></td>
                                        <td><%# Convert.ToInt32(Eval("fiyat")) %></td>
                                        <td><%# Convert.ToInt32(Eval("kdv")) %></td>
                                        <td><%# Convert.ToInt32(Eval("hesaplanmisFiyat")) %></td>
                                    </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                                </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <!-- Table -->
                    <%--<table class="table table-striped">
                        <thead>
                            <tr>
                                <th>Ürün Ad</th>
                                <th>Adet</th>
                                <th>Fiyat</th>
                                <th>KDV (%)</th>
                                <th>Toplam
                                    <br />
                                    Fiyat
                                    <br />
                                    (KDV Dahil)</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <!-- Index -->
                                <!-- Product  name -->
                                <td><a href="#">Topuklu1</a></td>
                                <!-- Product image -->
                                <!-- Quantity with refresh and remove button -->
                                <!-- Unit price -->
                                <td>1</td>
                                <td>₺150</td>
                                <!-- Total cost -->
                                <td>18</td>
                                <td>₺300</td>
                            </tr>
                            <tr>
                                <td><a href="single-item.html">Topuksuz</a></td>
                                <td>1</td>
                                <td>₺150</td>
                                <td>18</td>
                                <td>₺150</td>
                            </tr>
                            <tr>
                                <td><a href="#">Topuklu2</a></td>
                                <td>1</td>
                                <td>₺250</td>
                                <td>18</td>
                                <td>₺250</td>
                            </tr>
                            <tr>
                                <td><a href="#">Topuklu3</a></td>
                                <td>1</td>
                                <td>₺450</td>
                                <td>18</td>
                                <td>₺450</td>
                            </tr>
                            <tr>
                                <td><a href="#">Topuklu4</a></td>
                                <td>1</td>
                                <td>₺150</td>
                                <td>18</td>
                                <td>₺300</td>
                            </tr>
                            <tr>
                                <th></th>
                                <th>&nbsp;</th>
                                <th>&nbsp;</th>
                                <th>Total</th>
                                <th>₺2405</th>
                            </tr>
                        </tbody>
                    </table>--%>

                    <div class="sep-bor"></div>
                </div>
                <div class="col-md-7">
                    <h4>Bilgi Girişi</h4>

                    <hr />
                    <div class="form-horizontal">
                        <div class="form-group">

                            <asp:Label ID="lbl_tc_kimlik_no" runat="server" Text="TC Kimlik No" CssClass="col-md-3 control-label"></asp:Label>
                            <div class="col-md-5">
                                <asp:TextBox ID="txt_tc_kimlik_no" runat="server" CssClass="form-control" placeholder="TC Kimlik No"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator CssClass="text-danger" ID="req_tc_kimlik_no" runat="server" ErrorMessage="Bu alan boş geçilemez" ControlToValidate="txt_tc_kimlik_no"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lbl_ad" runat="server" Text="Ad" CssClass="col-md-3 control-label"></asp:Label>
                            <div class="col-md-5">
                                <asp:TextBox ID="txt_ad" runat="server" CssClass="form-control" placeholder="Ad"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="req_ad" runat="server" ErrorMessage="Bu alan boş geçilemez" ControlToValidate="txt_ad" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lbl_soyad" runat="server" Text="Soyad" CssClass="col-md-3 control-label"></asp:Label>
                            <div class="col-md-5">
                                <asp:TextBox ID="txt_soyad" runat="server" CssClass="form-control" placeholder="Soyad"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator CssClass="text-danger" ID="req_soyad" runat="server" ErrorMessage="Bu alan boş geçilemez" ControlToValidate="txt_soyad"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lbl_tel" runat="server" Text="Telefon" CssClass="col-md-3 control-label"></asp:Label>
                            <div class="col-md-5">
                                <asp:TextBox ID="txt_tel" runat="server" CssClass="form-control" placeholder="Telefon"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator CssClass="text-danger" ID="req_tel" runat="server" ErrorMessage="Bu alan boş geçilemez" ControlToValidate="txt_tel"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lbl_il" runat="server" Text="İl" CssClass="col-md-3 control-label"></asp:Label>
                            <div class="col-md-5">
                                <asp:DropDownList ID="ddl_il" runat="server" CssClass="form-control" DataSourceID="SqlDataSource1" DataTextField="sehir" DataValueField="sehir">
                                    <asp:ListItem>İl Seçiniz</asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PabucConnectionString %>" SelectCommand="SELECT [sehir] FROM [sehir] ORDER BY [plakaKodu]"></asp:SqlDataSource>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lbl_ilce" runat="server" Text="İlçe" CssClass="col-md-3 control-label"></asp:Label>
                            <div class="col-md-5">
                                <asp:DropDownList ID="ddl_ilce" runat="server" CssClass="form-control" DataSourceID="SqlDataSource2" DataTextField="ilce" DataValueField="ilce">
                                    <asp:ListItem>İlçe Seçiniz</asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PabucConnectionString %>" SelectCommand="SELECT [ilce] FROM [ilce] where sehirId=ddl_il.SelectedItem.Value ORDER BY [ilce]"></asp:SqlDataSource>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lbl_adres" runat="server" Text="Adres" CssClass="col-md-3 control-label"></asp:Label>
                            <div class="col-md-5">
                                <asp:TextBox ID="txt_adres" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Adres"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator CssClass="text-danger" ID="req_adres" runat="server" ErrorMessage="Bu alan boş geçilemez" ControlToValidate="txt_adres"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lbl_mail" runat="server" Text="Email" CssClass="col-md-3 control-label"></asp:Label>
                            <div class="col-md-5">
                                <asp:TextBox ID="txt_email" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator CssClass="text-danger" ID="req_mail" runat="server" ErrorMessage="Bu alan boş geçilemez" ControlToValidate="txt_email"></asp:RequiredFieldValidator>
                        </div>
                        <hr />
                        <div class="form-group">
                            <div class="col-md-offset-3 col-md-9">

                                <asp:Button ID="btn_odeme_yap" runat="server" Text="Ödeme Yap" CssClass="btn btn-danger" OnClick="btn_odeme_yap_Click" />
                                <a href="Default.aspx" class="btn btn-info btn-success">Alışverişe devam et</a>

                            </div>
                        </div>
                    </div>
                    <div class="blocky"></div>

                </div>

            </div>
        </div>
    </div>


</asp:Content>

