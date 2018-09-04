<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LvYouJingDian_Add.aspx.cs" Inherits="SDAU.ZHCZ.Web.Admin.aspx.LvYouJingDian_Add" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
                var textPlus = UE.getEditor('txtEditorContents').getContent();
              
                var imgReg = /<img.*?(?:>|\/>)/gi;
                var srcReg = /src=[\'\"]?([^\'\"]*)[\'\"]?/i;
                var arr = textPlus.match(imgReg);
                var src = arr[0].match(srcReg);
          
                 $("#JDTuPian").val(escape(src[0]));
                $("#JDJieShao").val(escape(textPlus));
            });
            $("#calcelLink").click(function () {
                window.location.href = "LvYouJingDian_List.aspx";
            })

           
        })
    </script>
</head>
<body>

    <form id="form1" runat="server" style="margin:10px 0 0 10px">
        <table>
            <tr>
                <td>
                    <div class="input-group">

                        <span class="input-group-addon" id="basic-addon1">景点名称：</span>
                    </div>
                </td>
                <td>
                    <asp:TextBox ID="mingcheng" runat="server" class="form-control" placeholder="" aria-describedby="basic-addon1"></asp:TextBox>
                    <span style="color: red">*必填</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="mingcheng" ErrorMessage="景点名称不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="input-group">
                        <span class="input-group-addon" id="basic-addon2">景点位置：</span>
                    </div>
                </td>
                <td>
                    <input type="text" class="form-control" placeholder="" aria-describedby="basic-addon1" name="JDWeiZhi" /></td>
            </tr>
            <tr>
                <td>
                    <div class="input-group">
                        <span class="input-group-addon" id="basic-addon5">经纬度：</span>
                    </div>
                </td>
                <td>
                    <asp:TextBox ID="jingdu" class="form-control" placeholder="" aria-describedby="basic-addon1" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="weidu" class="form-control" placeholder="" aria-describedby="basic-addon1" runat="server"></asp:TextBox>
                 </td>
            </tr>
        </table>
        <span class="input-group-addon" id="basic-addon4">景点介绍：</span>
        <asp:TextBox ID="txtEditorContents" name="txtEditorContents" runat="server" TextMode="MultiLine" Height="350px" Width="900px" ClientIDMode="Static"></asp:TextBox>
        <input type="button" id="calcelLink" name="name" value="返回" class="btn  btn-default" style="margin-left: 300px;" />
        &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp; &nbsp;  &nbsp;  &nbsp;  &nbsp; 
        <asp:Button ID="btnSub" runat="server" class="btn  btn-primary" Text="提交" OnClick="btnSub_Click"/>
        
        <input type="hidden" name="JDJieShao" id="JDJieShao" value="" />
             <input type="hidden" name="JDTuPian" id="JDTuPian" value="" />
    </form>
</body>
</html>
