<%@ Page Language="C#" AutoEventWireup="true"    ValidateRequest="false" CodeBehind="LvYouGuiHua_Edit.aspx.cs" Inherits="SDAU.ZHCZ.Web.Admin.aspx.LvYouGuiHua_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>编辑</title>
     <script src="../../js/jquery-1.10.2.js"></script>
    <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../bootstrap/css/bootstrap-responsive.css" rel="stylesheet" />
    <script src="../../utf8-net/ueditor.config.uploadimg.js"></script>
    <script src="../../utf8-net/ueditor.all.min.js"></script>
    <script src="../../utf8-net/lang/zh-cn/zh-cn.js"></script>
    <script src="../../utf8-net/UEditerFunction.js"></script>
      <style type="text/css">
        td {
            border: solid #add9c0;
            border-width: 0px 1px 1px 0px;
            padding-top: 10px;
        }

        table {
            border: solid #add9c0;
            border-width: 1px 0px 0px 1px;
        }

        .biaotou {
            text-align: center;
        }
    </style>
       <script type="text/javascript">
           $(function () {    
               var myInput = document.getElementById("txtEditorContents");
if (myInput == document.activeElement) {
    //document.body.scrollTop = document.documentElement.scrollTop = 0;
    alert("sss");
}
                  
             setTimeout(function () {
                 var html1 = $("#mytext").val();
                 var html = unescape(html1);
                 UE.getEditor('txtEditorContents').execCommand('insertHtml', html);
             }, 500);            
            var id = $("#xiangmubianhao1").val();
            $("#btnSub").click(function () {                 
                $("#mytext").val(escape(UE.getEditor('txtEditorContents').getContent()));
                var begin = $("#kaishishijian").val();
                var end = $("#jieshushijian").val();
                var xiangmubianhao = $("#xiangmubianhao1").html();
                var xiangmumingcheng = $("#xiangmumigncheng").val();
                if (xiangmubianhao == "" || xiangmumingcheng=="") {
                    alert("项目编号和项目名称不能为空！");
                              //回到页面顶部
                    document.body.scrollTop = document.documentElement.scrollTop = 0;
                       return false;   
                }
                if (GetDateDiff(begin, end) < 1) {
                    alert("项目年限输入无效，请重新输入！！");
                    return false;
                }

            })
            //这里不需要改变项目编号
            //$.post("../ashx/ghidIsexist.ashx", { bianhao: id }, function (data) {
            //    if (data == "notok") {
            //        alert("项目编号重复，请重新输入！");
            //        return false;
            //    }
            //})
        })
        //判断起止时间的合理性
        function GetDateDiff(startDate, endDate) {
            var startTime = new Date(Date.parse(startDate.replace(/-/g, "/"))).getTime();
            var endTime = new Date(Date.parse(endDate.replace(/-/g, "/"))).getTime();
            var dates = (endTime - startTime) / (1000 * 60 * 60 * 24);
            return dates;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
      <div align="center">
            <h1>旅游规划信息登记表</h1>
        </div>
        <div align="center">
            <table>
                <tr>
                    <td class="biaotou">项目编号:</td>
                    <td>
                        <asp:Label ID="xiangmubianhao1" runat="server" Text="Label"></asp:Label>
              
                    </td>
                    <td class="biaotou">项目名称:</td>
                    <td>
                        <asp:TextBox ID="xiangmumigncheng" runat="server"></asp:TextBox>                      
                    </td>
                </tr>
                <tr>
                    <td class="biaotou">负责人:</td>
                    <td>
                        <input type="text" name="fuzeren" value="<%=model.FuZeRen %>" />
                    </td>
                    <td class="biaotou">规划单位:</td>
                    <td>
                        <input type="text" name="guihuadanwei" value="<%=model.GuiHuaDanWei %>" />
                    </td>
                </tr>
                <tr>
                    <td class="biaotou">规划面积:</td>
                    <td>
                        <input type="text" name="guihuamianji" value="<%=model.GuiHuaMianJi %>" />
                    </td>
                    <td class="biaotou">规划范围:</td>
                    <td>
                        <input type="text" name="guihuafanwei" value="<%=model.GuiHuaFanWei %>" />
                    </td>
                </tr>
                <tr>
                    <td class="biaotou">规划时间：
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="shijian1" runat="server" TextMode="date"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>

                    <td class="biaotou">项目年限:</td>
                    <td colspan="3">起始时间：
                        <asp:TextBox ID="kaishishijian" runat="server" TextMode="Date"></asp:TextBox>
                        &nbsp; &nbsp;    &nbsp; 结束时间：
                        <asp:TextBox ID="jieshushijian" runat="server" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="biaotou">规划目标:</td>
                    <td colspan="3">
                        <textarea id="mubiao" name="mubiao" style="height: 100px; width: 785px;"><%=model.GuiHuaMuBiao %></textarea>
                    </td>
                </tr>
                <tr>
                    <td class="biaotou">规划任务:</td>
                    <td colspan="3">
                        <textarea id="renwu" name="renwu" style="height: 100px; width: 785px;"><%=model.GuiHuaRenWu %></textarea>
                    </td>
                </tr>
                <tr>
                    <td class="biaotou">规划项目介绍:</td>
                    <td colspan="3">                     
                          <textarea id="jieshao" name="jieshao" style="height: 100px; width: 785px;"><%=model.GHXMJieShao %></textarea>  
                    </td>
                </tr>
                 <tr>
                    <td class="biaotou">规划图:</td>
                    <td colspan="3">                                       
                      <asp:TextBox ID="txtEditorContents" name="txtEditorContents" runat="server" TextMode="MultiLine" Width="800px" ClientIDMode="Static"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Button ID="btncal" runat="server" class="btn  btn-default" Text="返回" Style="margin-left: 300px; height: 28px;" OnClick="btncal_Click" />
        &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp; &nbsp;  &nbsp;  &nbsp;  &nbsp; 
        <asp:Button ID="btnSub" runat="server" class="btn  btn-primary" Text="提交" OnClick="btnSub_Click" />
     
        <input type="hidden" name="mytext" id="mytext" value="<%=model.GuiHuaTu %>" />
    </form>
</body>
</html>
