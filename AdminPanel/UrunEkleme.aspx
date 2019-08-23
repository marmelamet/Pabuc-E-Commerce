<%@ Page Title="" Language="C#" MasterPageFile="AdminMaster.master" AutoEventWireup="true" CodeFile="UrunEkleme.aspx.cs" Inherits="UrunEkleme" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="ckeditor.js"></script>
    <script src="js/jquery.fileupload.js"></script>
    <script src="js/jquery.fileupload-ui.js"></script>
    <script src="js/jquery.iframe-transport.js"></script>
  <script src="http://code.jquery.com/jquery-1.11.1.min.js"></script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainHolder" runat="Server">
    <asp:ScriptManager runat="server" ID="scrmngr"></asp:ScriptManager>
    <%--<asp:UpdatePanel runat="server" ID="uppnl1" OnPreRender="uppnl1_PreRender">
        <ContentTemplate>--%>
    <div class="row-fluid sortable ui-sortable" style="float: left; width: 1000px">
        <div class="box span12">
            <div class="box-header well">
                Ürün Ekleme
            </div>
            <div class="box-content">
                <table class="control-group">
                      <tr>
                        <td>
                            <label class="control-label" for="focusedInput">Kategori Ad :</label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dllKategori" runat="server" Style="width: 280px" CssClass="selectError3"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                ControlToValidate="dllKategori" ValidationGroup="g1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label class="control-label" for="focusedInput">Kod :</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtKod" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ControlToValidate="txtKod" ValidationGroup="g1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label class="control-label" for="focusedInput">Ürün Ad :</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAd" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                ControlToValidate="txtAd" ValidationGroup="g1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <label class="control-label" for="focusedInput">Ürün Açıklama :</label>
                        </td>
                        <td>
                         <%--   <fck:FCKeditor ID="fckOzellik" runat="server" BasePath="~/fckeditor/"
                                Height="500" Width="900">
                            </fck:FCKeditor>--%>
                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                ControlToValidate="fckOzellik" ValidationGroup="g1"></asp:RequiredFieldValidator>--%>
                              <asp:TextBox ID="fckOzellik" CssClass="ckeditor" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px">
                            <label class="control-label" for="focusedInput">Fiyat :</label>
                        </td>
                        <td style="padding-top: 10px;">
                            <asp:TextBox ID="txtFiyat" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                ControlToValidate="txtFiyat" ValidationGroup="g1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px">
                            <label class="control-label" for="focusedInput">KDV :  %</label>
                        </td>
                        <td style="padding-top: 10px;">
                           
                            <asp:TextBox ID="txtKdv" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                ControlToValidate="txtKdv" ValidationGroup="g1"></asp:RequiredFieldValidator>
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
   <div class="row-fluid sortable ui-sortable" style="float: left; width: 500px;">
        <div class="box span12">
            <div class="box-header well">
                Ürün Detay Ekleme
            </div>
            <div class="box-content">
                <table class="control-group">
                    <tr>
                        <td>
                            <label class="control-label" for="focusedInput">Numara :</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNumara" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label class="control-label" for="focusedInput">Adet :</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAdet" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                                ControlToValidate="txtAdet" ValidationGroup="g2"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="float:right;margin-right:56px;">
                            <asp:Button Text="Ekle" ID="btnDetay" runat="server" CssClass="btn btn-primary" ValidationGroup="g2" OnClick="btnDetay_Click" />
                        </td>
                    </tr>
                     <tr style="color: #317EAC">
                        <td>Not:</td>
                        <td>
                            <span>Ürün detayı kaydetmek için önce ürünü kaydetmelisiniz.</span>
                        </td>
                    </tr>
                </table>
            </div>
        </div>

    </div>
    <div class="row-fluid sortable ui-sortable" style="float: left; width: 500px;">
        <div class="box span12">
            <div class="box-header well">
                Ürün Resim Ekleme
            </div>
            <div class="box-content">
                <table class="control-group">
                    <tr>
                        <td>
                            <label class="control-label" for="focusedInput">Resim Ad :</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtResim" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                ControlToValidate="txtResim" ValidationGroup="g3"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label class="control-label" for="focusedInput">Resim :</label>
                        </td>
                        <td>
                            <asp:FileUpload ID="filepicture" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*"
                                ControlToValidate="filepicture" ValidationGroup="g3"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="float:right;margin-right:135px;">
                            <asp:Button Text="Ekle" ID="btnResim" runat="server" CssClass="btn btn-primary" ValidationGroup="g3" OnClick="btnResim_Click" />
                        </td>
                    </tr>
                     <tr style="color: #317EAC">
                        <td>Not:</td>
                        <td>
                            <span>Resmi kaydetmek için önce ürünü kaydetmelisiniz ve resimi 175px x 140px boyutlarında kaydediniz.</span>
                        </td>
                    </tr>
                </table>
            </div>
        </div>

    </div>
    <asp:HiddenField ID="hidUrunId" runat="server" Value="0" />
</asp:Content>




