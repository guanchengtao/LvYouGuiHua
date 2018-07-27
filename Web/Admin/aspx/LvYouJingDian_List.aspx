<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LvYouJingDian_List.aspx.cs" Inherits="SDAU.ZHCZ.Web.Admin.aspx.LvYouJingDian_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>旅游景点信息</title>
    <link href="../../css/NavPager.css" rel="stylesheet" />
    <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../bootstrap/css/bootstrap-responsive.css" rel="stylesheet" />
    <link href="../../js/Page/css/pagination.css" rel="stylesheet" />
    <script src="../../js/jquery-1.10.2.js"></script>
    <script src="../../bootstrap/js/bootstrap.js"></script>
    <script type="text/javascript">
        //全选和反选
        $(function () {
            $("#cheakalldata").click(function () {
                if ($(this).is(':checked')) {
                    var ck = document.getElementsByName("checkbox");
                    for (var i = 0; i < ck.length; i++) {
                        var c = ck[i];//得到一个checkbox
                        c.checked = true;
                    }
                }
                else {
                    $(':input[type=checkbox]').removeAttr("checked");
                }

            })
        })

        //导出文件
        function FileOut() {
            $.post("../ashx/FileOut.ashx", { action: "jingdian" }, function (data) {
                window.location.href = data;
            });
        }
        //删除记录
        $(function () {
            $(".deletesingledate").click(function () {
                return confirm("您确认删除本条记录吗");
            })
        })
        $(function () {
            $(':input[type=checkbox]').removeAttr("checked");
            $("#confirmdelete").click(function () {
                var deletestr = "";
                //获取所有的checkbox
                var ck = $(':input[type=checkbox]');
                ck.each(function () {
                    if ($(this).is(':checked')) {
                        //拼接ID 
                        deletestr += $(this).val() + ",";
                    }
                })
                $.post("../ashx/DeleteData.ashx", { str: deletestr, action: "jingdian" }, function (date) {
                    if (date == "ok") {
                        window.location.reload();
                    }
                })
            });
            $("#closedelete").click(function () {
                return;
            })
        });//确认或取消删除        
    </script>
    <style>
        #thead th {
            text-align: center;
        }

        #id_contacts_data td {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <div class="form-group" style="margin-top: 15px;">
                    <asp:Button ID="Add" runat="server" Text="添加" class="btn btn-primary btn-lg"  Style="margin-left: 10px" OnClick="Add_Click" />
                    <input type="button" name="name" value="批量删除" class="btn btn-primary btn-lg" id="delete" data-toggle="modal" data-target="#myModal" />
                    &nbsp;          &nbsp;          &nbsp;        
            
                       <select id="select2" name="select" runat="server" style="margin-top: 11px; width: 100px;">
                           <option selected="selected">景点名称</option>
                           <option>位置</option>
                       </select>
                    <input style="margin-top: 11px" type="text" name="condition" value="<%=PreSerach %>" />
                    <asp:Button ID="Serachwithcondition" class="btn btn-success" runat="server" Text="搜索" OnClick="Serachwithcondition_Click" />
                    &nbsp; &nbsp; &nbsp;                  
                    <span>共找到<%=DataCount %>条数据</span>
                    &nbsp; &nbsp; &nbsp;  
                       <a class="btn btn-primary btn-lg" id="out" href="#" onclick="FileOut()">导出</a>
                    <asp:Button ID="filein" runat="server" Text="导入" class="btn btn-primary btn-lg" Style="margin-left: 10px" OnClick="filein_Click" />
                    <asp:FileUpload ID="FileUpload1" runat="server" BackColor="White" BorderColor="Aqua" BorderStyle="Solid" BorderWidth="1px" />
                </div>
                <table class="table table-bordered  table-striped">
                    <thead id="thead">
                        <tr>
                            <th>序号</th>
                            <th>
                                <input type="checkbox" value="" id="cheakalldata" /></th>
                            <th>景点名称</th>
                            <th>位置</th>
                            <th>经度</th>
                            <th>纬度</th>
                            <th>浏览次数</th>
                            <th>发布时间</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody id="id_contacts_data">
                        <%
                            var count = 1;
                            foreach (var item in list)
                            {
                        %>
                        <tr>
                            <td style="width: 30px"><%=(pageindex-1)*5+(count++) %></td>
                            <td style="width: 20px;">
                                <input type="checkbox" name="checkbox" value="<%=item.JDBianHao %>" />
                            </td>
                            <td><%=item.JDMingCheng %></td>
                            <td><%=item.JDWeiZhi %></td>
                                  <td><%=item.JingDu %></td>
                            <td><%=item.WeiDu %></td>
                            <td><%=item.LiuLanCiShu %></td>
                            <td><%=item.FBShiJian %></td>

                            <td><a href="LvYouGuiHua_View.aspx?id=<%=item.JDBianHao %>">查看</a>
                                &nbsp;&nbsp;<span style="color: cornflowerblue">|</span>&nbsp;&nbsp;<a href="LvYouGuiHua_Edit.aspx?id=<%=item.JDBianHao %>">编辑</a>
                                &nbsp;&nbsp;<span style="color: cornflowerblue">|</span>&nbsp;&nbsp;<a class="deletesingledate" href="LvYouGuiHua_Delete.aspx?id=<%=item.JDBianHao %>">删除</a>
                            </td>
                        </tr>
                        <% } %>
                    </tbody>
                </table>
                <div class="paginator" style="margin-left: 600px;">
                    <%=Navstring %>
                </div>
                <div id="page" style="margin-left: 670px;"></div>
            </div>
            <%=outseccess %>
        </div>

        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">

                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"
                            aria-hidden="true">
                            ×
                        </button>
                        <h4 class="modal-title" id="myModalLabel">提示
                        </h4>
                    </div>
                    <div class="modal-body">
                        您确认要删除所选中信息吗？
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default"
                            data-dismiss="modal" id="closedelete">
                            不好意思，手抖了
                        </button>
                        <button type="button" class="btn btn-primary" data-dismiss="modal" id="confirmdelete">
                            确认删除
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

