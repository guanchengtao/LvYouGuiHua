<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Map_JingDian.aspx.cs" Inherits="SDAU.ZHCZ.Web.Admin.aspx.Map_JingDian" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>地图</title>
    <link href="../../css/NavPager.css" rel="stylesheet" />
    <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../bootstrap/css/bootstrap-responsive.css" rel="stylesheet" />
    <link href="../../js/Page/css/pagination.css" rel="stylesheet" />
    <script src="../../js/jquery-1.10.2.js"></script>
    <script src="../../bootstrap/js/bootstrap.js"></script>
    <script src="http://libs.baidu.com/jquery/1.9.0/jquery.js"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=IFiIC3WAxhVibbv4QC7BueDep037yHyL"></script>
    <style>
        #allmap {
            height: 600px;
            width: 100%;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#initMap").click(function () {
                location.reload();
                $("#jingweidu").val("");
            })
            $("#Add").click(function () {
                window.location.href = "LvYouJingDian_Add.aspx?jwdu=" + $("#jingweidu").val();
            })

        })
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <div class="form-group" style="margin-top: 15px;">
                      <input type="button" class="btn btn-primary btn-lg" style="margin-left:10px;" name="initMap" value="刷新地图" id="initMap" />
                    <select id="select2" name="select" runat="server" style="margin-top: 11px; width: 100px;">
                        <option selected="selected">景点名称</option>
                        <option>位置</option>
                    </select>
                    <input style="margin-top: 11px" type="text" name="condition" value="" />
                    <asp:Button ID="Serachwithcondition" class="btn btn-success" runat="server" Text="搜索" />

                    &nbsp; &nbsp; &nbsp;  
                    
              
    

                    <span>当前坐标点如下：</span>
                    <input type="text" name="jingweidu" value="" id="jingweidu" />
                    <input type="button" class="btn btn-primary btn-lg" style="margin-left:10px" name="name" value="添加景点" id="Add" />
                  
                </div>
            </div>
        </div>
        <div id="allmap"></div>
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
<script type="text/javascript">
    // 百度地图API功能
    map = new BMap.Map("allmap",
        {
            mapType: BMAP_NORMAL_MAP,
            enableMapClick: false//禁止百度自身的InfoWindow
        });
    map.enableScrollWheelZoom(false);   //放大缩小
    // map.disableDragging();     //禁止拖拽
    //click--点击事件获取经纬度

    //设置地图中心点和级别
    map.centerAndZoom(new BMap.Point(116.342268, 37.175545), 15);
    $.getJSON("../ashx/JingDianList.ashx", {}, function (data) {
        var gisdata = data.jingdianList;
        $.each(gisdata, function (index, n) {
            gisdata[index].JDJieShao = unescape(gisdata[index].JDJieShao);
            gisdata[index].JDJieShao = gisdata[index].JDJieShao.substring(-1, 60) + "...<a href='LvYouJingDian_View.aspx?id=" + gisdata[index].JDBianHao + "'>查看详情</a>"; 
            gisdata[index].TuPian = unescape(gisdata[index].TuPian);
        });
        var data_info = [];
        var i = 0;
        //自定义数组数存储每个景点的信息
        while (i < data.jingdianCount) {
            data_info.unshift(
                [gisdata[i].JingDu, gisdata[i].WeiDu, gisdata[i].JDMingCheng, gisdata[i].JDBianHao, "<h4 style='margin:0 0 3px 0;padding:0.2em 0'>" + gisdata[i].JDMingCheng + "</h4><img style='float:right;margin:1px' width='150' height='110' title='' id='imgDemo'"+ gisdata[i].TuPian + "' /><p style='margin:0;line-height:1.5;font-size:13px;text-indent:2em'>" + gisdata[i].JDJieShao + "</p >"]
             
            );
            i++;
        }
        var opts = {
            width: 350,
            height: 160,
            title: "", // 信息窗口标题
            enableMessage: true//设置允许信息窗发送短息
        };
        for (var i = 0; i < data_info.length; i++) {
            var marker = new BMap.Marker(new BMap.Point(data_info[i][0], data_info[i][1]));  // 创建标注

            var JDMingCheng = data_info[i][2];
            var JDBianHao = data_info[i][3];
            var content = data_info[i][4];//获取内容
            map.addOverlay(marker); // 将标注添加到地图中
            marker.setAnimation(BMAP_ANIMATION_BOUNCE);//设置标注跳动动画

            addClickHandler(content, marker, opts);
            RightClickHandler(JDBianHao, JDMingCheng, marker);//右键单击marker出现右键菜单事件

        }
    });

    function RightClickHandler(JDBianHao, JDMingCheng, marker) {
        var removeMarker = function (e, ee, marker) {//右键删除站点
            if (confirm("要删除景点 " + JDMingCheng + " 吗？")) {
                if (true) {
                    $.post("../ashx/DeleteData.ashx", { str: JDBianHao + ",", action: "jingdian" }, function (date) {
                        if (date == "ok") {
                          alert("删除景点" + JDMingCheng + "成功！");
                            map.removeOverlay(marker);
                            window.location.reload();
                        }
                    })

                }
            }
        };
        var updateMarker = function (marker) {//右键更新站名
          window.location.href = "LvYouJingDian_Edit.aspx?id=" + JDBianHao;

        };
        var markerMenu = new BMap.ContextMenu();
        markerMenu.addItem(new BMap.MenuItem('删除景点', removeMarker.bind(marker)));
        markerMenu.addItem(new BMap.MenuItem('修改景点', updateMarker.bind(marker)));
        marker.addContextMenu(markerMenu);//给标记添加右键菜单
    }
    //左击事件，调用openInfo
    function addClickHandler(content, marker, opts) {
        marker.addEventListener("click", function (e) {
            openInfo(content, e, opts);
           
        }
        );
    }
    //打开信息窗口
    function openInfo(content, e, opts) {
        var p = e.target;
        var point = new BMap.Point(p.getPosition().lng, p.getPosition().lat);
        var infoWindow = new BMap.InfoWindow(content, opts);  // 创建信息窗口对象 
        map.openInfoWindow(infoWindow, point); //开启信息窗口
  
    }







    //点击显示经纬度
    map.addEventListener("click", function (e) {
        var jingdu_value = e.point.lng;
        var weidu_value = e.point.lat;

        $("#jingweidu").val(jingdu_value + "," + weidu_value);
    });



</script>


