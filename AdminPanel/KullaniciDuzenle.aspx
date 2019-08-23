<%@ Page Title="" Language="C#" MasterPageFile="AdminMaster.master" AutoEventWireup="true" CodeFile="KullaniciDuzenle.aspx.cs" Inherits="KullaniciDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainHolder" Runat="Server">
       <asp:ScriptManager runat="server" ID="scrmngr"></asp:ScriptManager>
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
            <div class="box-header well">
                Kullanıcı Düzenle
            </div>
            <div class="box-content">
                <table class="control-group">
                    <tr>
                        <td>
                            <label class="control-label" for="focusedInput">Ad :</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAd" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ControlToValidate="txtAd" ValidationGroup="g1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label class="control-label" for="focusedInput">Soyad :</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSoyad" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                ControlToValidate="txtSoyad" ValidationGroup="g1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label class="control-label" for="focusedInput">Kullanıcı Ad :</label>
                        </td>
                        <td>
                           <asp:TextBox ID="txtKullanici" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                ControlToValidate="txtKullanici" ValidationGroup="g1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label class="control-label" for="focusedInput">Şifre :</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSifre" runat="server" CssClass="input-xlarge focused" TextMode="SingleLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                ControlToValidate="txtSifre" ValidationGroup="g1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                         <tr>
                            <td>
                                <label class="control-label" for="focusedInput">Kullanıcı Tipi :</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTip" runat="server" CssClass="selectError3" Style="width: 280px;" OnSelectedIndexChanged="dbType_SelectedIndexChanged">
                                    <asp:ListItem Value="-1" Text="Seçiniz"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Admin"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Personel"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" InitialValue="-1" ControlToValidate="ddlTip"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    <tr>
                        <td></td>
                        <td style="float: right; margin-right: 8px;">
                            <asp:Button Text="Kaydet" ID="BTN_Kaydet" runat="server" CssClass="btn btn-primary" ValidationGroup="g1" OnClick="BTN_Kaydet_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

