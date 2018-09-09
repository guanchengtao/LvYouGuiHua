<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="LvYouGuiHua_Add.aspx.cs"
    Inherits="SDAU.ZHCZ.Web.Admin.aspx.LvYouGuiHua_Add"
    ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../js/jquery-1.10.2.js"></script>
    <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../bootstrap/css/bootstrap-responsive.css" rel="stylesheet" />
    <script src="../../utf8-net/ueditor.config.uploadimg.js"></script>
    <script src="../../utf8-net/ueditor.all.min.js"></script>
    <script src="../../utf8-net/lang/zh-cn/zh-cn.js"></script>
    <script src="../../utf8-net/UEditerFunction.js"></script>
    <script type="text/javascript">
        $(function () {
            var id = $("#xiangmubianhao").val();
            $("#xiangmubianhao").val("");
              $("#xiangmumigncheng").val("");
            $("#btnSub").click(function () {
            $("#mytext").val(escape(UE.getEditor('txtEditorContents').getContent()));
                var begin = $("#kaishishijian").val();
                var end = $("#jieshushijian").val();
                var xiangmubianhao  = $("#xiangmubianhao").val();
                var xiangmumingcheng = $("#xiangmumigncheng").val();
                if (xiangmumingcheng == "" || xiangmubianhao=="") {
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
            $.post("../ashx/ghidIsexist.ashx", { bianhao: id }, function (data) {
                if (data == "notok") {
                    alert("项目编号重复，请重新输入！");
                    return false;
                }
            })
        })
        //判断起止时间的合理性
        function GetDateDiff(startDate, endDate) {
            var startTime = new Date(Date.parse(startDate.replace(/-/g, "/"))).getTime();
            var endTime = new Date(Date.parse(endDate.replace(/-/g, "/"))).getTime();
            var dates = (endTime - startTime) / (1000 * 60 * 60 * 24);
            return dates;
        }
    </script>
  
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
                        <asp:TextBox ID="xiangmubianhao" runat="server"></asp:TextBox>
                    </td>
                    <td class="biaotou">项目名称:</td>
                    <td>
                        <asp:TextBox ID="xiangmumigncheng" runat="server"></asp:TextBox><%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="xiangmumigncheng" runat="server" ErrorMessage="*项目名称不能为空"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td class="biaotou">负责人:</td>
                    <td>
                        <input type="text" name="fuzeren" value=" " />
                    </td>
                    <td class="biaotou">规划单位:</td>
                    <td>
                        <input type="text" name="guihuadanwei" value="" />
                    </td>
                </tr>
                <tr>
                    <td class="biaotou">规划面积:</td>
                    <td>
                        <input type="text" name="guihuamianji" value=" " />
                    </td>
                    <td class="biaotou">规划范围:</td>
                    <td>
                        <input type="text" name="guihuafanwei" value="" />
                    </td>
                </tr>

                <tr>
                    <td class="biaotou">规划时间：
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="shijian" runat="server" TextMode="Date"></asp:TextBox>
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
                        <textarea id="mubiao" name="mubiao" style="height: 100px; width: 785px;"></textarea>
                    </td>
                </tr>
                <tr>
                    <td class="biaotou">规划任务:</td>
                    <td colspan="3">
                        <textarea id="renwu" name="renwu" style="height: 100px; width: 785px;"></textarea>
                    </td>
                </tr>
                <tr>
                    <td class="biaotou">规划项目介绍:</td>
                    <td colspan="3">                     
                          <textarea id="jieshao" name="jieshao" style="height: 100px; width: 785px;"></textarea>  
                    </td>
                </tr>
                 <tr>
                    <td class="biaotou">规划图:</td>
                    <td colspan="3">                                       
                      <asp:TextBox ID="txtEditorContents" name="txtEditorContents" runat="server" TextMode="MultiLine" Height="380px" Width="800px" ClientIDMode="Static"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Button ID="btncal" runat="server" class="btn  btn-default" Text="返回" Style="margin-left: 300px; height: 28px;" OnClick="btncal_Click" />
        &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp; &nbsp;  &nbsp;  &nbsp;  &nbsp; 
        <asp:Button ID="btnSub" runat="server" class="btn  btn-primary" Text="提交" OnClick="btnSub_Click" />
        <input type="hidden" name="mytext" id="mytext" value="" />
    </form>
</body>
</html>
