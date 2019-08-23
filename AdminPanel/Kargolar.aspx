<%@ Page Title="" Language="C#" MasterPageFile="AdminMaster.master" AutoEventWireup="true" CodeFile="Kargolar.aspx.cs" Inherits="Kargolar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainHolder" Runat="Server">
         <asp:ScriptManager runat="server" ID="scrmngr"></asp:ScriptManager>
  <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
            <div class="box-header well">
                Kargo Listesi
            </div>
            <div class="box-content">
                <div class="DataTables_Table_0_wrapper" role="grid">
                    <div class="row-fluid">
                    </div>
                    <asp:Repeater runat="server" ID="rptKargo" OnItemCommand="rptKargo_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-striped table-bordered bootstrap-datatable datatable dataTable" id="table">
                                <thead>
                                    <tr role="row">
                                        <th class="sorting" role="columnheader" style="width: 120px">Kargo Id</th>
                                        <th class="sorting" role="columnheader" style="width: 120px">Kargo Firması</th>
                                        <th class="sorting" role="columnheader" style="width: 120px">Fiyat</th>
                                        <th class="sorting" role="columnheader" style="width: 120px">KDV</th>
                                        <th class="sorting" role="columnheader" style="min-width: 30%">İşlem</th>
                                    </tr>
                                </thead>
                                <tbody role="alert" aria-live="polite" aria-relevant="all">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="odd">
                                <td class="center"><%#Eval("_id") %></td>
                                <td class="center"><%#Eval("kargoFirmasi") %></td>
                                <td class="center"><%#Eval("kargotutari") %></td>
                                <td class="center"><%#Eval("kdv") %></td>
                                <td>
                                    <asp:Button CssClass="btn btn-primary" Text="Düzenle" ID="BTN_KargoDuzenle" runat="server" CommandArgument='<%#Eval("_id") %>' CommandName='KargoDuzenle' CausesValidation="false" Width="70" />
                                    <asp:Button CssClass="btn btn-danger" Text="Sil" ID="BTN_KargoSil" runat="server" CommandArgument='<%#Eval("_id") %>' CommandName='KargoSil' CausesValidation="false" Width="70" />
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

