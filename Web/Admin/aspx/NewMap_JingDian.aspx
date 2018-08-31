<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewMap_JingDian.aspx.cs" Inherits="SDAU.ZHCZ.Web.Admin.aspx.NewMap_JingDian" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>地图</title>
    <script src="../../map/jsAPI/jquery/jquery-3.3.1.min.js"></script>
    <link href="../../map/css/index.css" rel="stylesheet" />
    <link href="../../map/jsAPI/newmap.css" rel="stylesheet" />
    <script src="../../map/jsAPI/NewMap.js"></script>
    <script src="../../map/jsAPI/NExtWMTSLayer.js"></script>
    <script src="../../js/map2.js"></script>
    <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../bootstrap/css/bootstrap-responsive.css" rel="stylesheet" />
    <script src="../../bootstrap/js/bootstrap.js"></script>
    <script type="text/javascript">
        $(function () {
            //$("#initMap").click(function () {
            //    location.reload();
            //    $("#jingweidu").val("");
            //})
            //$("#Add").click(function () {
            //    window.location.href = "LvYouJingDian_Add.aspx?jwdu=" + $("#jingweidu").val();
            //})
        })
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <div class="form-group" style="margin-top: 15px;">
                    <input type="button" class="btn btn-primary btn-lg" style="margin-left: 10px;" name="initMap" value="刷新地图" id="initMap" />
                    <select id="select2" name="select" runat="server" style="margin-top: 11px; width: 100px;">
                        <option selected="selected">景点名称</option>
                        <option>位置</option>
                    </select>
                    <input style="margin-top: 11px" type="text" name="condition" value="" />
                    <asp:Button ID="Serachwithcondition" class="btn btn-success" runat="server" Text="搜索" />
                    &nbsp; &nbsp; &nbsp;                                 
                    <span>当前坐标点如下：</span>
                    <input type="text" name="jingweidu" value="" id="jingweidu" />
                    <input type="button" class="btn btn-primary btn-lg" style="margin-left: 10px" name="name" value="添加景点" id="Add" />
                </div>
            </div>
        </div>
    <div id="map-canvas" style="top: 32px; height: 100%; -webkit-transition: all 0.5s ease-in-out; transition: all 0.5s ease-in-out;"></div>        
    </form>
</body>
</html>



