<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="404.aspx.cs" Inherits="_404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" runat="Server">
    <div class="error-block blocky text-center">
        <div class="container">
            <h2>Aman<span class="color">!!!</span> Ha<span class="color">ta</span> 404<span class="color">!!!</span></h2>
            <p class="error-para">Üzgünüz, Aradığınız sayfa bulunamıyor. </p>
            <div class="sep-bor"></div>
            <a href="Default.aspx" class="btn btn-info">Sitemizde gezinmeye devam edeblirsiniz.</a>

            <div class="sep-bor"></div>
        </div>
    </div>
</asp:Content>

