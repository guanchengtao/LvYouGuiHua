/** 
* 在iframe中调用，在父窗口中出提示框(herf方式不用调父窗口)
*/
$.extend({ show_warning: function (strTitle, strMsg) {
    $.messager.show({
        title: strTitle,
        width: 300,
        height: 100,
        msg: strMsg,
        closable: true,
        showType: 'slide',
        style: {
            right: '',
            top: document.body.scrollTop + document.documentElement.scrollTop,
            bottom: ''
        }
    });
}
});

/** 
* 弹框
*/
$.extend({ show_alert: function (strTitle, strMsg) {
    $.messager.alert(strTitle, strMsg);
}
});

/**
* @author 孙宇
* 
* @requires jQuery,EasyUI
* 
* 扩展validatebox，添加验证两次密码功能
*/
$.extend($.fn.validatebox.defaults.rules, {
    eqPwd: {
        validator: function (value, param) {
            return value == $(param[0]).val();
        },
        message: '密码不一致！'
    }
});

/**
* @author 风骑士
* 
* @requires jQuery,EasyUI
* 
* 初始化datagrid toolbar
*/
getToolBar = function (data) {
    if (data.toolbar != undefined && data.toolbar != '') {
        var toolbar = [];
        $.each(data.toolbar, function (index, row) {
            var handler = row.handler;
            row.handler = function () { eval(handler); };
            toolbar.push(row);
        });
       
        return toolbar;
    } else {
        return [];
    }
}

/**
* @author 孙宇
*
* 接收一个以逗号分割的字符串，返回List，list里每一项都是一个字符串（做编辑功能的时候 传入id 然后自动勾选combo系列组件）
*
* @returns list
*/
stringToList = function (value) {
    if (value != undefined && value != '') {
        var values = [];
        var t = value.split(',');
        for (var i = 0; i < t.length; i++) {
            values.push('' + t[i]); /* 避免将ID当成数字 */
        }
        return values;
    } else {
        return [];
    }
};



//牛亮亮老师部分
function ajaxGet(url, data, fnsuccess, fnerror) {
    $.ajax({
        type: "get",
        url: url,
        data: data,
        dataType: "json",
        success: fnsuccess,
        error: fnerror
    })
}

function changeDateFormat(cellval) {
    var date = new Date(parseInt(cellval.replace("/Date(", "").replace(")/", ""), 10));
    var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
    var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
    var hour = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
    var minute = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
    var second = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();
    //return date.getFullYear() + "-" + month + "-" + currentDate + " " + hour + ":" + minute + ":" + second;
    return date.getFullYear() + "-" + month + "-" + currentDate;
}
//改变信息管理的内容显示
function changeTextFormat(cellval) {
    return "...";
}
//改变类别名称显示
function ChangeMingChengFormatter(cellval) {
    if (cellval!=null) {
        return cellval.MingCheng;
    } else {
        return '无';
    }
}

//改变会议管理的会议室名称显示
function ChangeDepartmentMingChengFormatter(cellval) {
    return cellval.DepartmentName;
}
function changeName(cellval) {
    if (cellval!=null) {
        return cellval.HuZhuXingMing;
    } else {
        return '无';
    }
    //return '1';
}
function changeNumber(cellval) {
    return cellval.MingCheng;
}
function returnId(cellval) {
    return cellval.Id;
}
function ChangeGenderFormatter(cellval) {
    return cellval == true ? "男" : "女";
}
function ChangeGenderFormatter2(cellval){
    return cellval == "男" ? true : false;
}
function ChangeXingMingFormatter(cellval) {
    return cellval.XingMing;
}

function ShowImage(cellval) {
    if (cellval==true) {
        return '<img src="/admin/themes/icon/chk_checked.gif" alt="在职" />';
    } else {
        return '<img src="/admin/themes/icon/delete.gif" alt="离职" />';
    }
}
function getUrlParam(strings) {
    var obj = {};
    if (strings.indexOf("?") != -1) {
        var strings = strings.substr(strings.indexOf("?") + 1);
        var strs = strings.split("&");
        for (var i = 0; i < strs.length; i++) {
            var tempArr = strs[i].split("=");
            obj[tempArr[0]] = unescape(tempArr[1]);
        }
    }
    return obj;
}
function showTable(id) {

    var tableid = id;		//表格的id
    var overcolor = '#E4F6FF';	//鼠标经过颜色 B7DBFF #eecc00 F2F2FF
    var color1 = '#FFFFFF';		//第一种颜色
    var color2 = '#F8F8F8';		//第二种颜色
    var tablename = document.getElementById(tableid)
    var tr = tablename.getElementsByTagName("tr")
    for (var i = 1 ; i < tr.length; i++) {
        tr[i].onmouseover = function () {
            this.style.backgroundColor = overcolor;
        }
        tr[i].onmouseout = function () {
            if (this.rowIndex % 2 == 0) {
                this.style.backgroundColor = color1;
            } else {
                this.style.backgroundColor = color2;
            }
        }
        if (i % 2 == 0) {
            // tr[i].className = "color1";
            tr[i].style.backgroundColor = color1;
        } else {
            //tr[i].className = "color2";
            tr[i].style.backgroundColor = color2;
        }
    }
}
function DingWei(cellval) {
    return '<a href="javascript:void(0)" onclick="GetInfo(' + cellval + ')" class="easyui-linkbutton">定位</a>'
}
