    <%@ Page Title="" Language="C#" MasterPageFile="AdminMaster.master" AutoEventWireup="true" CodeFile="Urunler.aspx.cs" Inherits="Urunler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainHolder" runat="Server">
     <asp:ScriptManager runat="server" ID="scrmngr"></asp:ScriptManager>
  <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
            <div class="box-header well">
                Ürünler Listesi
            </div>
            <div class="box-content">
                <div class="DataTables_Table_0_wrapper" role="grid">
                    <div class="row-fluid">
                    </div>
                    <asp:Repeater runat="server" ID="rptUrun" OnItemCommand="rptUrun_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-striped table-bordered bootstrap-datatable datatable dataTable" id="table">
                                <thead>
                                    <tr role="row">
                                        <th class="sorting" role="columnheader" style="width: 120px">Ürün Id</th>
                                        <th class="sorting" role="columnheader" style="width: 120px">Ürün Kod</th>
                                        <th class="sorting" role="columnheader" style="width: 120px">Ürün Ad</th>
                                        <th class="sorting" role="columnheader" style="width: 120px">Ürün Özellik</th>
                                        <th class="sorting" role="columnheader" style="width: 120px">Fiyat</th>
                                        <th class="sorting" role="columnheader" style="width: 120px">KDV</th>
                                        <th class="sorting" role="columnheader" style="width: 120px">Is Default</th>
                                        <th class="sorting" role="columnheader" style="min-width: 30%">İşlem</th>
                                    </tr>
                                </thead>
                                <tbody role="alert" aria-live="polite" aria-relevant="all">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="odd">
                                <td class="center"><%#Eval("urunId") %></td>
                                <td class="center"><%#Eval("urunKod") %></td>
                                <td class="center"><%#Eval("urunAd") %></td>
                                <td class="center"><%#Eval("urunOzellik") %></td>
                                <td class="center"><%#Eval("fiyat") %></td>
                                <td class="center"><%#Eval("kdv") %></td>
                                <td class="center"><%# Eval("isDefault").ToString() == "0" ? "Aktif" : "Aktif Değil"%></td>
                                <td>
                                    <asp:Button CssClass="btn btn-primary" Text="Düzenle" ID="BTN_UrunDuzenle" runat="server" CommandArgument='<%#Eval("urunId") %>' CommandName='UrunDuzenle' CausesValidation="false" Width="70" />
                                    <asp:Button CssClass="btn btn-danger" Text="Sil" ID="BTN_UrunSil" runat="server" CommandArgument='<%#Eval("urunId") %>' CommandName='UrunSil' CausesValidation="false" Width="70" />
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

