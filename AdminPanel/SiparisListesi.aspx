<%@ Page Title="" Language="C#" MasterPageFile="AdminMaster.master" AutoEventWireup="true" CodeFile="SiparisListesi.aspx.cs" Inherits="SiparisListesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        #popupBack {
            background-color: #000;
            position: fixed;
            width: 100%;
            height: 100%;
            left: 0px;
            top: 0px;
            display: none;
            z-index: 10;
            opacity: 0.8;
            filter: alpha(opacity=80);
        }

        #popcloser {
            display: none;
            background-color: transparent;
            width: 24px;
            height: 24px;
            z-index: 12;
            color: #000;
            font-size: 20px;
            font-weight: bold;
            position: fixed;
            margin-left: -10px;
            margin-top: 3px;
        }

        #popupcontent {
            background-color: #fff;
            width: 450px;
            height: 300px;
            position: fixed;
            border: 3px solid LightGray;
            padding: 10px;
            display: none;
            z-index: 11;
        }

            #popupcontent #banner {
                width: 500px;
                height: 400px;
                overflow: hidden;
                margin: auto;
            }

                #popupcontent #banner #content {
                    height: 400px;
                    min-width: 900px;
                    position: relative;
                }

                    #popupcontent #banner #content div {
                        width: 300px;
                        float: left;
                    }
    </style>
    
    <script>
        $(document).ready(function () {
            oTable = $('#example').dataTable({
                "order": [[0, "desc"]],
                paging: true,
                searching:true
            });
            
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainHolder" runat="Server">
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
            <div class="box-header well">
                Sipariş Listesi
            </div>
            <div class="box-content">
                <div class="DataTables_Table_0_wrapper" role="grid">
                    <div class="row-fluid">
                    </div>
                    <asp:Repeater runat="server" ID="rptSiparislist">
                        <HeaderTemplate>
                            <table class="table table-striped table-bordered bootstrap-datatable dataTable" id="example">
                                <thead>
                                    <tr role="row">
                                        <th class="sorting" role="columnheader">Sipariş Id</th>
                                        <th class="sorting" role="columnheader">TC</th>
                                        <th class="sorting" role="columnheader">Ad</th>
                                        <th class="sorting" role="columnheader">Soyad</th>
                                        <th class="sorting" role="columnheader">Telefon</th>
                                        <th class="sorting" role="columnheader">İl</th>
                                        <th class="sorting" role="columnheader">İlçe</th>
                                        <th class="sorting" role="columnheader">Adres</th>
                                        <th class="sorting" role="columnheader">Email</th>
                                        <th class="sorting" role="columnheader">Ödeme Durumu</th>
                                        <th class="sorting" role="columnheader">İşlem Tarihi</th>
                                    </tr>
                                </thead>
                                <tbody role="alert" aria-live="polite" aria-relevant="all">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="odd">
                                <td class="sorting" role="columnheader"><%# Eval("siparisId") %></td>
                                <td class="sorting" role="columnheader"><%# Eval("tc") %></td>
                                <td class="sorting" role="columnheader"><%# Eval("ad") %></td>
                                <td class="sorting" role="columnheader"><%# Eval("soyad") %></td>
                                <td class="sorting" role="columnheader"><%# Eval("telefon") %></td>
                                <td class="sorting" role="columnheader"><%# Eval("sehir") %></td>
                                <td class="sorting" role="columnheader"><%# Eval("ilce") %></td>
                                <td class="sorting" role="columnheader"><%# Eval("adres") %></td>
                                <td class="sorting" role="columnheader"><%# Eval("email") %></td>
                                <td class="center"><%# Eval("odendiMi")%></td>
                                <td><%#DateTime.Parse(Eval("islemTarihi").ToString()).ToShortDateString()%></td>
                              
                                    
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
<%--    <div id="popupBack">&nbsp;</div>
    <div id="popupcontent">
        <div id="banner">
            <div id="content" style="font-size: 15px;">
               <asp:Repeater runat="server" ID="rptSiparisUrunler">
                        <HeaderTemplate>
                            <table class="table table-striped table-bordered bootstrap-datatable datatable dataTable">
                                <thead>
                                    <tr role="row">
                                        <th class="sorting" role="columnheader">Urun Ad</th>
                                        <th class="sorting" role="columnheader">Adet</th>
                                        <th class="sorting" role="columnheader">Hesaplanmış Fiyat</th>
                                    </tr>
                                </thead>
                                <tbody role="alert" aria-live="polite" aria-relevant="all">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="odd">
                                <td class="sorting" role="columnheader"><%# Eval("urunAd") %></td>
                                <td class="sorting" role="columnheader"><%# Eval("adet") %></td>
                                <td class="sorting" role="columnheader"><%# Eval("hesaplanmisFiyat") %></td>       
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                        </table>
                        </FooterTemplate>
                    </asp:Repeater> 
                
            </div>
        </div>
        <div id="popcloser">
            <img src="img/closer.jpg" alt="" /></div>
        </div>--%>
</asp:Content>

