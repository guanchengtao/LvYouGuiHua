<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LvYouGuiHua_View.aspx.cs" Inherits="SDAU.ZHCZ.Web.Admin.aspx.LvYouGuiHua_View" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../bootstrap/css/bootstrap-responsive.css" rel="stylesheet" />
    <script src="../../js/jquery-1.10.2.js"></script>
    <script type="text/javascript">
             //unescape
        $(function () {
              var html = $("#Guihuatu").val();
            var text = unescape(html);
            $("#guihuatu").append(text);
        })
    </script>
    <title>详情</title> 
    <style type="text/css">
        .auto-style1 {
            width: 150px;
        }
        .auto-style3 {
            height: 200px;
        }
        td {
            border: solid #add9c0;
            border-width: 0px 1px 1px 0px;
        }

        table {
            border: solid #add9c0;
            border-width: 1px 0px 0px 1px;
        }

        .auto-style4 {
            width: 70px;
            text-align:center;
        }

        .auto-style5 {
            height: 198px;
               text-align:center;
        }
        .auto-style6 {
            height: 110px;
               text-align:center;
        }

        .auto-style7 {
            width: 126px
        }

    </style>

</head>
<body>
    <form id="form1" runat="server">      
          <input type="hidden" id="Guihuatu" name="Guihuatu" value="<%=model.GuiHuaTu %>" />              
             <div align="center">
            <h1>旅游规划信息展示表</h1>
        </div>
        <div align="center">
            
            <table style="height: 262px; width: 700px">
                <tr>
                    <td class="auto-style4">项目编号</td>
                    <td class="input-medium"><%=model.GHXMBianHao %></td>
                    <td class="auto-style4">项目名称</td>
                    <td class="auto-style1"><%=model.GHXMMingCheng %></td>
                </tr>
                <tr>
                    <td class="auto-style4">负责人</td>
                    <td class="input-medium"><%=model.FuZeRen%></td>
                      <td class="auto-style4">规划单位</td>
                    <td><%=model.GuiHuaDanWei%></td>
                </tr>
                <tr>
                    <td class="auto-style4">规划时间</td>
                    <td class="input-medium"><%=model.GuiHuaShiJian!=DateTime.Parse("2000-01-01")?model.GuiHuaShiJian.ToLongDateString():""%></td>
                    <td class="auto-style4">规划年限</td>
                    <td><%=model.GuiHuaNianXian==""?"":model.GuiHuaNianXian.Split('|')[0]+"——"+model.GuiHuaNianXian.Split('|')[1]%></td>
                </tr>     
                <tr>
                    <td class="auto-style4">规划范围</td>
                    <td class="input-medium"><%=model.GuiHuaFanWei%></td>   
                            <td class="auto-style4">规划面积</td>
                    <td><%=model.GuiHuaMianJi%></td>
                </tr>               
                <tr>
                    <td class="auto-style6">规划目标</td>
                    <td colspan="3">
                        <textarea  id="guihuamubiao" cols="20" rows="4" style="height:90px;width:600px;background-color:white;cursor:text" ><%=model.GuiHuaMuBiao %></textarea>
                        
                    </td>
                </tr>         
                <tr>
                    <td class="auto-style6">规划任务</td>
                    <td colspan="3" >   
                        <textarea  id="guihuarenwu" cols="20" rows="2" style="height:90px;width:600px;background-color:white;"  ><%=model.GuiHuaRenWu %></textarea>

                    </td>
                </tr>
                <tr style="height:50px">
                    <td class="auto-style5">规划项目介绍</td>
                    <td colspan="3"> 
                        <textarea  id="jeishao" cols="200" rows="20"  style="height:180px;width:600px;background-color:white;cursor:text" ><%=model.GHXMJieShao %></textarea>
                    </td>
                </tr>
                  <tr>
                    <td class="auto-style4">规划图</td>
                    <td colspan="4">
                        <div id="guihuatu" style="width: 100%; margin: 0 auto"></div></td>   
              
                </tr>
            </table>
        </div>
        <br/>
        <div align="center">
            <asp:Button ID="btnBack" class="btn btn-primary btn-lg" runat="server" Text="返回" OnClick="btnBack_Click"/>
        </div>
    </form>
</body>
</html>
