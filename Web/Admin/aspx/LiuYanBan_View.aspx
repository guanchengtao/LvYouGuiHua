<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LiuYanBan_View.aspx.cs" Inherits="SDAU.ZHCZ.Web.Admin.aspx.LiuYanBan_View" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
  <%--  <script src="../../js/jquery-1.10.2.js"></script>
    <script type="text/javascript">
        $(function () {
            var neirong = $("#mytext").val();
            $("#spNeiRong").html(neirong);
        })
    </script>--%>
</head>
    
<body>
    <form id="form1" runat="server">
         <div class="input-group" style="margin-top:5px">
               <span class="label label-info" style="font-size:16px;font-weight:600">标题:</span>
               <span class="input-group-addon" id="basic-addon2"><%=model.BiaoTi %></span>               
</div>
         <div class="input-group" style="margin-top:5px">
               <span class="label label-info" style="font-size:16px;font-weight:600">评论时间:</span>
               <span class="input-group-addon" id="basic-addon3"><%=model.LiuYanShiJian %></span>               
</div>
         <div class="input-group" style="margin-top:5px">
               <span class="label label-info" style="font-size:16px;font-weight:600">评论内容：</span><hr />
              <textarea style="height:300px;width:500px"><%=model.NeiRong %></textarea>              
</div>
    
      
     
    </form>
</body>
</html>
