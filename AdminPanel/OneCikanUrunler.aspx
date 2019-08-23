<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.master" AutoEventWireup="true" CodeFile="OneCikanUrunler.aspx.cs" Inherits="AdminPanel_OneCikanUrunler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainHolder" Runat="Server">
       <asp:ScriptManager runat="server" ID="scrmngr"></asp:ScriptManager>
  <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
            <div class="box-header well">
                Öne Çıkan Ürünlerin Listesi
            </div>
            <div class="box-content">
                <div class="DataTables_Table_0_wrapper" role="grid">
                    <div class="row-fluid">
                    </div>
                    <asp:Repeater runat="server" ID="rptGorsel" OnItemCommand="rptGorsel_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-striped table-bordered bootstrap-datatable datatable dataTable" id="table">
                                <thead>
                                    <tr role="row">
                                        <th class="sorting" role="columnheader" style="width: 120px">Gorsel Id</th>
                                        <th class="sorting" role="columnheader" style="width: 120px">Kategori Ad</th>
                                        <th class="sorting" role="columnheader" style="width: 120px">Ürün Ad</th>
                                        <th class="sorting" role="columnheader" style="width: 120px">Açıklama</th>
                                        <th class="sorting" role="columnheader" style="width: 120px">Resim</th>
                                        <th class="sorting" role="columnheader" style="width: 120px">Is Default</th>
                                        <th class="sorting" role="columnheader" style="min-width: 30%">İşlem</th>
                                    </tr>
                                </thead>
                                <tbody role="alert" aria-live="polite" aria-relevant="all">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="odd">
                                <td class="center"><%#Eval("oneCikanUrunId") %></td>
                                <td class="center"><%#Eval("kategoriAd") %></td>
                                <td class="center"><%#Eval("urunAd") %></td>
                                <td class="center"><%#Eval("aciklama") %></td>
                                <td class="center"><img src='<%#Eval("resim").ToString()%>' alt="" class="img-responsive" /></td>
                                <td class="center"><%# Eval("isDefault").ToString() == "0" ? "Aktif" : "Aktif Değil"%></td>
                                <td>
                                    <asp:Button CssClass="btn btn-primary" Text="Düzenle" ID="BTN_GorselDuzenle" runat="server" CommandArgument='<%#Eval("oneCikanUrunId") %>' CommandName='GorselDuzenle' CausesValidation="false" Width="70" />
                                    <asp:Button CssClass="btn btn-danger" Text="Sil" ID="BTN_GorselSil" runat="server" CommandArgument='<%#Eval("oneCikanUrunId") %>' CommandName='GorselSil' CausesValidation="false" Width="70" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:HiddenField ID="hidDurum" runat="server" Value="0" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

