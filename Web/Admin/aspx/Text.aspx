<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Text.aspx.cs" Inherits="SDAU.ZHCZ.Web.Admin.aspx.Text" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../js/jquery-1.10.2.js"></script>
    <script src="../../js/jquery-1.10.2.js"></script>
    <script src="../../utf8-net/ueditor.config.uploadimg.js"></script>
    <script src="../../utf8-net/ueditor.all.min.js"></script>
    <script src="../../utf8-net/lang/zh-cn/zh-cn.js"></script>
    <script src="../../utf8-net/UEditerFunction.js"></script>
    <script type="text/javascript">
      
    </script>
</head>
<body>
    <form id="form1" runat="server">
          
         <asp:TextBox ID="txtEditorContents" name="txtEditorContents" runat="server" TextMode="MultiLine" Width="900px" ClientIDMode="Static" ></asp:TextBox>
    </form>
</body>
</html>
