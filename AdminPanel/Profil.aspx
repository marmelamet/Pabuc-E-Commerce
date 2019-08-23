<%@ Page Title="" Language="C#" MasterPageFile="AdminMaster.master" AutoEventWireup="true" CodeFile="Profil.aspx.cs" Inherits="Profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainHolder" Runat="Server">
       <asp:ScriptManager runat="server" ID="scrmngr"></asp:ScriptManager>
       <asp:UpdatePanel runat="server" ID="uppnl1" OnPreRender="uppnl1_PreRender">
        <ContentTemplate>
            <div class="row-fluid sortable ui-sortable" style="float: left; width: 380px">
                <div class="box span12">
                    <div class="box-header well">
                        Giriş Bilgileri
                    </div>
                    <div class="box-content" style="width:500px">
                        <table class="control-group">
                            <asp:UpdatePanel runat="server" ID="pnlKullanici">
                                <ContentTemplate>
                                    <tr>
                                        <td>
                                            <label class="control-label" for="focusedInput">Kullanıcı Ad :</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEPosta" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <a>
                                                <asp:LinkButton ID="lbtnPass" runat="server" Text="Şifre Değiştir" OnClick="lbtnPass_Click"></asp:LinkButton></a>
                                        </td>
                                    </tr>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel runat="server" ID="pnlSifre">
                                <ContentTemplate>
                                    <tr>
                                        <td>
                                            <label class="control-label" for="focusedInput">Eski Şifre :</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEskiSifre" runat="server" CssClass="input-xlarge focused" TextMode="Password"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label class="control-label" for="focusedInput">Yeni Şifre :</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtYeniSifre1" runat="server" CssClass="input-xlarge focused" TextMode="Password"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label class="control-label" for="focusedInput">Şifre Tekrarı :</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtYeniSifre2" runat="server" CssClass="input-xlarge focused" TextMode="Password"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button Text="Onayla" ID="btnSifreDegis" OnClick="btnSifreDegis_Click" runat="server" CssClass="btn btn-primary" />
                                        </td>
                                        <td>
                                            <a>
                                                <asp:LinkButton ID="lbtnGirisBilgi" runat="server" Text="Giriş Bilgileri" OnClick="lbtnGirisBilgi_Click" CausesValidation="false"></asp:LinkButton></a>
                                        </td>
                                    </tr>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </table>

                    </div>
                </div>
            </div>
            <div class="row-fluid sortable ui-sortable" style="width: 380px; float: left; margin-left: 20px">
                <div class="box span12">
                    <div class="box-header well">
                        Kişisel Bilgiler
                    </div>
                    <div class="box-content">
                        <table class="control-group">
                            <tr>
                                <td>
                                    <label class="control-label" for="focusedInput">Ad :</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAd" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="control-label" for="focusedInput">Soyad :</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSoyad" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button Text="Güncelle" ID="BTN_Kaydet" runat="server" CssClass="btn btn-primary" OnClick="BTN_Kaydet_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

