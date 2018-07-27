<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GongKaiXinXi_View.aspx.cs" Inherits="SDAU.ZHCZ.Web.Admin.aspx.GongKaiXinXi_View" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../js/jquery-1.10.2.js"></script>
    <link href="../../bootstrap/css/bootstrap.css" rel="stylesheet" />
        <script type="text/javascript">
        //unescape
        $(function () {
            var html = $("#NeiRong").val();
            var text = unescape(html);
            $("#spNeiRong").append(text);
        })
    </script>
    <style type="text/css">
        .label label-info{
            font-size:large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="margin:20px 0 0 20px">
        <input type="hidden" id="NeiRong" name="NeiRong" value="<%=model.NeiRong %>" />              
          <div class="input-group" style="margin-top:5px">
             <span class="label label-info">标题:</span>
            <span class="input-group-addon" id="basic-addon1" style="font-size:16px;font-weight:600"><%=model.BiaoTi %></span>
</div>
               <div class="input-group" style="margin-top:5px">
               <span class="label label-info">发布人:</span>
               <span class="input-group-addon" id="basic-addon2" style="font-size:16px;font-weight:600"><%=model.ZuoZe %></span>
                
</div>
           <div class="input-group" style="margin-top:5px;margin-bottom:5px;">
      <span class="label label-info">发布单位:</span>
 <span class="input-group-addon" id="basic-addon3" style="font-size:16px;font-weight:600"><%=model.FaBuDanWei %></span>
</div>
               <div class="input-group" style="margin-bottom:5px">
               <span class="label label-info">发布类型:</span>
               <span class="input-group-addon" id="basic-addon5" style="font-size:16px;font-weight:600"><%=model.LeiXing %></span>          
</div>     
                <span class="label label-info">内容：</span>
  <hr style="height: 1px; color: skyblue;" />
            <div id="spNeiRong" style="border: 1px skyblue solid; width: 80%; margin: 0 auto">
            </div>
           <div class="input-group">
  <span class="input-group-addon" id="basic-addon6">
      注：该信息发布于</span>&nbsp;<span>  <%=model.FaBuShiJian %></span>
             <asp:Button ID="Button1" runat="server" class="btn btn-default" Text="返回" OnClick="Button1_Click" /> 
</div>
    </form>
</body>
</html>
