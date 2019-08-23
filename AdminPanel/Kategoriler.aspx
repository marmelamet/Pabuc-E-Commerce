<%@ Page Title="" Language="C#" MasterPageFile="AdminMaster.master" AutoEventWireup="true" CodeFile="Kategoriler.aspx.cs" Inherits="Kategoriler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
        $(document).ready(function () {
            oTable = $('#example').dataTable({
                "order": [[0, "desc"]],
                paging: true,
                searching: true
            });

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainHolder" Runat="Server">
        <asp:ScriptManager runat="server" ID="scrmngr"></asp:ScriptManager>
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
            <div class="box-header well">
                Kategoriler
            </div>
            <div class="box-content">
                <div class="DataTables_Table_0_wrapper" role="grid">
                    <div class="row-fluid">
                    </div>
                    <asp:Repeater runat="server" ID="rptKategori" OnItemCommand="rptKategori_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-striped table-bordered bootstrap-datatable dataTable" id="example">
                                <thead>
                                    <tr role="row">
                                        <th class="sorting" role="columnheader" style="width: 120px">Kategori Id</th>
                                        <th class="sorting" role="columnheader" style="width: 120px">Kategori Ad</th>
                                        <th class="sorting" role="columnheader" style="width: 120px">IsDefault</th>
                                        <th class="sorting" role="columnheader" style="width: 120px">İşlem</th>
                                    </tr>
                                </thead>
                                <tbody role="alert" aria-live="polite" aria-relevant="all">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="odd">
                                <td class="center"><%#Eval("kategoriId") %></td>
                                <td class="center"><%#Eval("kategoriAd") %></td>
                                <td class="center"><%# Eval("isDefault").ToString() == "0" ? "Aktif" : "Aktif Değil"%></td>
                                <td style="min-width: 130px">

                                    <asp:Button CssClass="btn btn-primary" Text="Düzenle" ID="BTN_KategoriDuzenle" runat="server" CommandArgument='<%#Eval("kategoriId") %>' CommandName='KategoriDuzenle' CausesValidation="false" Width="70" />
                                    <asp:Button CssClass="btn btn-danger" Text="Sil" ID="BTN_KategoriSil" runat="server" CommandArgument='<%# Eval("kategoriId") %>' CommandName="KategoriSil" CausesValidation="false" Width="40" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

