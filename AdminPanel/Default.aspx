<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="ckeditor.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:TextBox ID="editor_en" CssClass="ckeditor" TextMode="MultiLine" runat="server"  ></asp:TextBox>
    </div>
    </form>
</body>
</html>
