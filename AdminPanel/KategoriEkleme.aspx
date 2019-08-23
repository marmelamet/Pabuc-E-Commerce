<%@ Page Title="" Language="C#" MasterPageFile="AdminMaster.master" AutoEventWireup="true" CodeFile="KategoriEkleme.aspx.cs" Inherits="KategoriEkleme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainHolder" Runat="Server">
      <asp:ScriptManager runat="server" ID="scrmngr"></asp:ScriptManager>
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
            <div class="box-header well">
                Kategori  Ekleme
            </div>
            <div class="box-content">
                <table class="control-group">
                    <tr>
                        <td>
                            <label class="control-label" for="focusedInput">Kategori Ad :</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAd" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ControlToValidate="txtAd" ValidationGroup="g1"></asp:RequiredFieldValidator>
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

