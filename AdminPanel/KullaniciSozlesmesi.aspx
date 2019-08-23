<%@ Page Title="" Language="C#" MasterPageFile="AdminMaster.master" AutoEventWireup="true" CodeFile="KullaniciSozlesmesi.aspx.cs" Inherits="KullaniciSozlesmesi" ValidateRequest="false" %>

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
                Kullanıcı Sözleşmesi
            </div>
            <div class="box-content">
                <table class="control-group">
                    <tr>
                        <td style="vertical-align: top">
                            <label class="control-label" for="focusedInput">Kullanıcı Sözleşmesi :</label>
                        </td>
                        <td>
                            <asp:TextBox ID="fckOzellik" CssClass="ckeditor" TextMode="MultiLine" runat="server"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                ControlToValidate="fckOzellik" ValidationGroup="g1"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="float: right; margin-right: 8px;">
                            <asp:Button Text="Kaydet" ID="BTN_Kaydet" runat="server" CssClass="btn btn-primary"  OnClick="BTN_Kaydet_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

</asp:Content>

