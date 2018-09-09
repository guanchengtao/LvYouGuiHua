<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LiuYanBan_View.aspx.cs" Inherits="SDAU.ZHCZ.Web.Admin.aspx.LiuYanBan_View" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../bootstrap/css/bootstrap-responsive.css" rel="stylesheet" />
    <link href="../../js/Page/css/pagination.css" rel="stylesheet" />

    <script src="../../js/jquery-3.3.1.min.js"></script>
    <script src="../../bootstrap/js/bootstrap.js"></script>
    <script>
        $(function () {
       
            $("#huifu").click(function () {
                var huifu = $("#huifucontent").val();
                if (huifu.length == 0) {
                    alert("回复内容不能为空！");
                    return;
                }
            })
        })
    </script>

</head>
    
<body>
    <form id="form1" runat="server">
         <div class="input-group" style="margin-top:5px">
               <span class="label label-info" style="font-size:16px;font-weight:600">评论时间:</span>
               <span class="input-group-addon" id="basic-addon3"><%=model.LiuYanShiJian %></span>               
</div>
         <div class="input-group" style="margin-top:5px">
               <span class="label label-info" style="font-size:16px;font-weight:600">评论内容：</span><hr />
              <textarea style="height:100px;width:400px"><%=model.NeiRong %></textarea>              
</div>
                 <div class="input-group" style="margin-top:5px">
               <span class="label label-info" style="font-size:16px;font-weight:600">回复内容：</span><hr />
              <textarea name="huifuneirong" id="huifucontent" style="height:100px;width:400px"><%=model.HuiFuNeiRong %></textarea>              
</div>  
            <asp:Button ID="huifu" class="btn btn-success" runat="server" Text="回复" OnClick="huifu_Click" />
            <asp:Button ID="back" class="btn btn-success" runat="server" Text="返回" OnClick="back_Click" />
    </form>
</body>
</html>
