<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GongKaiXinXi_Edit.aspx.cs" Inherits="SDAU.ZHCZ.Web.Admin.aspx.GongKaiXinXi_Edit" ValidateRequest="false"  %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../utf8-net/ueditor.config.js"></script>
    <script src="../../utf8-net/ueditor.all.min.js"></script>
    <script src="../../utf8-net/lang/zh-cn/zh-cn.js"></script>
    <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../utf8-net/UEditerFunction.js"></script>
    <script src="../../js/jquery-1.10.2.js"></script>
</head>
<body>
    <form id="form1" runat="server" style="margin:20px 0 0 20px">
        <table>
            <tr>
                <td> <div class="input-group">
  <span class="input-group-addon" id="basic-addon1">标题：</span></div></td> <td> 
      <asp:TextBox ID="biaoti" runat="server" class="form-control" placeholder="" aria-describedby="basic-addon1" Text="<% %>"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="biaoti" ErrorMessage="*标题不能为空"></asp:RequiredFieldValidator>
  </td>
            </tr>
                <tr>
                <td>
          <div class="input-group">
  <span class="input-group-addon" id="basic-addon2">发布人：</span></div></td> <td>
  <input type="text" class="form-control" placeholder="" aria-describedby="basic-addon1"name="faburen" value="<%=model.ZuoZe %>"/></td>
            </tr>
                <tr>
                <td> <div class="input-group">
  <span class="input-group-addon" id="basic-addon5">发布单位：</span></div></td> <td>              
  <input type="text" class="form-control" placeholder="" aria-describedby="basic-addon1" name="fabudanwei" value="<%=model.FaBuDanWei %>"/></td>
            </tr>
                <tr>
                <td> <div class="input-group">
  <span class="input-group-addon" id="basic-addon3">发布信息类型：</span></div></td> <td>  <select name="select">
                    <option><%=model.LeiXing %></option>
  <option>新闻</option>
  <option>公告</option>
  <option>政策法规</option>
  <option>通报</option>

</select></td>
            </tr>
        </table>
     

      
  <span class="input-group-addon" id="basic-addon4">内容：</span>
         <asp:TextBox ID="txtEditorContents" name="txtEditorContents" runat="server" TextMode="MultiLine" Height="380px" Width="900px" ClientIDMode="Static" ></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="返回" class="btn btn-default" OnClick="Button2_Click" />
        <asp:Button ID="Button1" runat="server" Text="提交" class="btn btn-primary" OnClick="Button1_Click" />
        <input type="hidden" name="mytext" id="mytext" value="<%=model.NeiRong %>" />
    </form>
     <script type="text/javascript">
         $(function () {

             setTimeout(function () {
                 var html1 = $("#mytext").val();
                 var html = unescape(html1);
                 UE.getEditor('txtEditorContents').execCommand('insertHtml', html);
             }, 500);
             $("#Button1").click(function () {
                 $("#mytext").val(escape(UE.getEditor('txtEditorContents').getContent()));
             });
         });
    </script>
</body>
</html>
