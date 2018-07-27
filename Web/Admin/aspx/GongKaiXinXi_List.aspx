<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GongKaiXinXi_List.aspx.cs" Inherits="SDAU.ZHCZ.Web.Admin.aspx.GongKaiXinXi_List" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>公开信息</title>
    <link href="../../css/NavPager.css" rel="stylesheet" />
    <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" /> 
    <link href="../../bootstrap/css/bootstrap-responsive.css" rel="stylesheet" />
    <link href="../../js/Page/css/pagination.css" rel="stylesheet" />
    <script src="../../js/jquery-1.10.2.js"></script>
    <script src="../../bootstrap/js/bootstrap.js"></script>
    <script>
        $(function myfunction() {
                 $(".deletesingledate").click(function () {
            return confirm("您确认删除本条记录吗");
        })
        })
        //导出文件
          function FileOut() {
               $.post("../ashx/FileOut.ashx", {action:"xinxi"}, function (data) {     
                   window.location.href = data;
                });
        }
        //删除记录
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
                $.post("../ashx/DeleteData.ashx", { str: deletestr,action:"xinxi" }, function (date) {
                    if (date == "ok") {         
                        window.location.reload();                     
                    }
                })
            });
            $("#closedelete").click(function () {
                return;
            })             
        });//确认或取消删除         
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
    </script>   
    <style>
     #thead th{
      text-align:center;
  }
  #id_contacts_data td{
      text-align:center;
  }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="form-group" style="margin-top:15px;">
                <asp:Button ID="Button1" runat="server" Text="添加信息" class="btn btn-primary btn-lg" OnClick="Button1_Click" style="margin-left:10px" />     
              <input type="button" name="name" value="批量删除" class="btn btn-primary btn-lg" id="delete" data-toggle="modal" data-target="#myModal"/>
                &nbsp;&nbsp;&nbsp;        
                 <select id="select2" name="select" runat="server" style="margin-top: 11px; width: 100px;">
                             <option selected="selected">标题</option> 
                             <option>发布人</option>
                             <option>类型</option>
                         </select>
                <input style="margin-top: 11px" type="text"  name="condition" value="<%=PreSerach %>" />
                  <asp:Button ID="Serachwithcondition" class="btn btn-success" runat="server" Text="搜索" OnClick="Serachwithcondition_Click"   /> &nbsp;  <span>共找到<%=DataCount %>条数据</span>   
             &nbsp; &nbsp; &nbsp; 
            <a class="btn btn-primary btn-lg" id="out" href="#"  onclick="FileOut()">导出</a>  
                <asp:Button ID="filein" runat="server" Text="导入" class="btn btn-primary btn-lg"  style="margin-left:10px" OnClick="filein_Click"/> 
                <asp:FileUpload ID="FileUpload1" runat="server" BackColor="White" BorderColor="Aqua" BorderStyle="Solid" BorderWidth="1px" />    
            </div>
           
            <table class="table table-bordered  table-striped" >
                <thead id="thead">
                    <tr>
                        <th style="width:35px;">序号</th>
                        <th style="width:27px;">
                        <input type="checkbox" value="" id="cheakalldata" /></th>
                        <th style="width:250px;">标题</th>
                        <th>发布人</th>
                        <th>发布单位</th>
                        <th>类型</th>  
                        <th>发布时间</th>
                        <th style="width:400px">操作</th>
                    </tr>
                </thead>
                <tbody id="id_contacts_data">
                    <%
                        var count = 1;
                        foreach (var item in list)
                        {
                    %>
                    <tr class="resultTr">
                        <td><%=(pageindex-1)*5+(count++) %></td>
                        <td style="width:20px;">
                            <input  type="checkbox" name="checkbox" value="<%=item.BianHao %>" />
                        </td>
                     <td><%=item.BiaoTi %></td>
                        <td><%=item.ZuoZe %></td>   
                        <td><%=item.FaBuDanWei %></td>   
                        <td style="width:100px;"><%=item.LeiXing %></td>      
                        <td style="width:130px"><%=item.FaBuShiJian.ToShortDateString() %></td>
                        <td><a href="GongKaiXinXi_View.aspx?id=<%=item.BianHao %>">查看</a>&nbsp;&nbsp;<span style="color:cornflowerblue">|</span>
                           &nbsp;&nbsp;<a  href="GongKaiXinXi_Edit.aspx?id=<%=item.BianHao %>">编辑</a>&nbsp;&nbsp;<span style="color:cornflowerblue">|</span>
                              &nbsp;&nbsp;&nbsp;<a class="deletesingledate" <%--class="btn btn-primary btn-lg"--%> href="GongKaiXinXi_Delete.aspx?id=<%=item.BianHao %>">删除</a>
                        </td>
                    </tr>
                    <% } %>
                </tbody>
            </table>
     
            <div class="paginator" style="margin-left: 600px;">       <%=showinfo %>
                <%=Navstring %>
            
            </div>           
    <div id="page" style="margin-left:670px;"></div>
   
        </div>
        <%=outseccess %>
        
        <%--删除模态框--%>
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
	<div class="modal-dialog">
		<div class="modal-content">

			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal" 
						aria-hidden="true">×
				</button>
				<h4 class="modal-title" id="myModalLabel">
					提示
				</h4>
			</div>
			<div class="modal-body">
			您确认要删除所选中信息吗？
			</div>
			<div class="modal-footer">
				<button type="button" class="btn btn-default" 
						data-dismiss="modal" id="closedelete">不好意思，手抖了
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