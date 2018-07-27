<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GongKaiXinXi_Add.aspx.cs" Inherits="SDAU.ZHCZ.Web.Admin.aspx.GongKaiXinXi_Add" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../js/jquery-1.10.2.js"></script>
    <script src="../../utf8-net/ueditor.config.js"></script>
    <script src="../../utf8-net/ueditor.all.min.js"></script>
    <script src="../../utf8-net/lang/zh-cn/zh-cn.js"></script>
    <script src="../../utf8-net/UEditerFunction.js"></script>
    <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
           <script>
               $(function () {
              $("#btnSub").click(function () {
              $("#mytext").val(escape(UE.getEditor('txtEditorContents').getContent()));
                   });              
               })
              
    </script>
</head>
<body>
 
    <form id="form1" runat="server">
        <table>
            <tr>
                <td> <div class="input-group">
  <span class="input-group-addon" id="basic-addon1">标题：</span></div>
                </td>
                <td>
                    <asp:TextBox ID="biaoti" runat="server" class="form-control" placeholder="" aria-describedby="basic-addon1"></asp:TextBox>
                    <span style="color:red">*必填</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="biaoti" ErrorMessage="标题不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr> <tr>
                <td> <div class="input-group">
  <span class="input-group-addon" id="basic-addon2">发布人：</span></div></td>     <td><input type="text" class="form-control" placeholder="" aria-describedby="basic-addon1"name="faburen"/></td>
            </tr>
            <tr>
                <td>   <div class="input-group">
  <span class="input-group-addon" id="basic-addon5">发布单位：</span></div></td>     <td><input type="text" class="form-control" placeholder="" aria-describedby="basic-addon1" name="fabudanwei"/></td>
            </tr> <tr>
                <td> <div class="input-group">
  <span class="input-group-addon" id="basic-addon3">发布信息类型：</span></div></td>     <td> <select name="select">
  <option>新闻</option>
  <option>公告</option>
  <option>政策法规</option>
  <option>通报</option>
</select></td>
            </tr>
        </table>
  <span class="input-group-addon" id="basic-addon4">内容：</span>
         <asp:TextBox ID="txtEditorContents" name="txtEditorContents" runat="server" TextMode="MultiLine" Height="380px" Width="900px" ClientIDMode="Static" ></asp:TextBox>
  <asp:Button ID="btncal" runat="server" class="btn  btn-default" Text="返回" OnClick="btncal_Click" style="margin-left:300px;"/>  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp; &nbsp;  &nbsp;  &nbsp;  &nbsp; 
        <asp:Button ID="btnSub" runat="server" class="btn  btn-primary" Text="提交" OnClick="Button1_Click" />
      
        <input type="hidden" name="mytext" id="mytext" value="" />
    </form>
</body>
</html>
