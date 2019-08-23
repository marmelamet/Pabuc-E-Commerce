<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="OneCikanUrunDuzenleme.aspx.cs" Inherits="OneCikanUrunDuzenleme" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script src="ckeditor.js"></script>
    <script src="js/jquery.fileupload.js"></script>
    <script src="js/jquery.fileupload-ui.js"></script>
    <script src="js/jquery.iframe-transport.js"></script>
    <script src="http://code.jquery.com/jquery-1.11.1.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainHolder" Runat="Server">
     <asp:ScriptManager runat="server" ID="scrmngr"></asp:ScriptManager>
    <%--<asp:UpdatePanel runat="server" ID="uppnl1" OnPreRender="uppnl1_PreRender">
        <ContentTemplate>--%>
    <div class="row-fluid sortable ui-sortable" style="float: left; width: 1000px">
        <div class="box span12">
            <div class="box-header well">
                Slider Ekleme
            </div>
            <div class="box-content">
                <table class="control-group">
                    <tr>
                        <td>
                            <label class="control-label" for="focusedInput">Kategori Ad :</label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dllKategori" runat="server" Style="width: 280px" CssClass="selectError3" OnSelectedIndexChanged="dllKategori_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                ControlToValidate="dllKategori" ValidationGroup="g1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label class="control-label" for="focusedInput">Ürün Ad :</label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dllUrun" runat="server" Style="width: 280px" CssClass="selectError3"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ControlToValidate="dllUrun" ValidationGroup="g1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td style="vertical-align: top">
                            <label class="control-label" for="focusedInput">Açıklama :</label>
                        </td>
                        <td>
                            <asp:TextBox ID="fckOzellik" CssClass="ckeditor" TextMode="MultiLine" runat="server"></asp:TextBox>
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
                        <td style="float: right; margin-right: 8px;">
                            <asp:Button Text="Kaydet" ID="BTN_Kaydet" runat="server" CssClass="btn btn-primary" ValidationGroup="g1" OnClick="BTN_Kaydet_Click" />
                        </td>
                    </tr>
                    <tr style="color: #317EAC">
                        <td>Not:</td>
                        <td>
                            <span>Resimi 175px x 140px boyutlarında kaydediniz.</span>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>


    <asp:HiddenField ID="hidUrunId" runat="server" Value="0" />
</asp:Content>

