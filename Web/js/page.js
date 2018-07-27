
// pagecount  总页数
//currentpage  当前页码
//fn  获取分页数据的方法
function createPageBar(pagecount, currentpage, fn) {
    ld = fn;
    var pagestr = "";
    var breakpage = 9;
    var currentposition = 4;
    var breakspace = 2;
    var maxspace = 4;
    var prevnum = currentpage - currentposition;
    var nextnum = currentpage + currentposition;
    if (prevnum < 1) prevnum = 1;
    if (nextnum > pagecount) nextnum = pagecount;
    var i;
    i = currentpage - 1;
    pagestr += '<div>';

    pagestr += (currentpage == 1) ? '<a class="easyui-linkbutton"  href="javascript:void(0)">首页</a><a class="easyui-linkbutton" class="easyui-linkbutton" href="javascript:void(0)">&laquo; 上一页</a></li>' : '<a class="easyui-linkbutton" href="javascript:void(0)" onclick="getPage(1)">首页</a><a class="easyui-linkbutton" href="javascript:void(0)" onclick="getPage(' + i + ')">&laquo; 上一页</a>';

    if (prevnum - breakspace > maxspace) {
        for (i = 1; i <= breakspace; i++)
            pagestr += '<a class="easyui-linkbutton" href="javascript:void(0)" onclick="getPage(' + i + ')">' + i + '</a>';
        pagestr += '&hellip;';
        for (i = pagecount - breakpage + 1; i < prevnum; i++)
            pagestr += '<a class="easyui-linkbutton" href="javascript:void(0)" onclick="getPage(' + i + ')">' + i + '</a>';
    } else {
        for (i = 1; i < prevnum; i++)
            pagestr += '<a class="easyui-linkbutton" href="javascript:void(0)" onclick="getPage(' + i + ')">' + i + '</a>';
    }
    for (i = prevnum; i <= nextnum; i++) {
        pagestr += (currentpage == i) ? '' + i  : '<a class="easyui-linkbutton" href="javascript:void(0)" onclick="getPage(' + i + ')">' + i + '</a>';
    }
    if (pagecount - breakspace - nextnum + 1 > maxspace) {
        for (i = nextnum + 1; i <= breakpage; i++)
            pagestr += '<a class="easyui-linkbutton" href="javascript:void(0)" onclick="getPage(' + i + ')">' + i + '</a>';
        pagestr += '&hellip;';
        for (i = pagecount - breakspace + 1; i <= pagecount; i++)
            pagestr += '<a class="easyui-linkbutton" href="javascript:void(0)" onclick="getPage(' + i + ')">' + i + '</a>';
    } else {
        for (i = nextnum + 1; i <= pagecount; i++)
            pagestr += '<a class="easyui-linkbutton" href="javascript:void(0)" onclick="getPage(' + i + ')">' + i + '</a>';
    }
    i = currentpage + 1;
    pagestr += (currentpage == pagecount) ? '<a class="easyui-linkbutton" href="javascript:void(0)">下一页 &raquo;</a>' : '<a class="easyui-linkbutton" href="javascript:void(0)" onclick="getPage(' + i + ')">下一页 &raquo;</a>';
    pagestr += '<a class="easyui-linkbutton" href="javascript:void(0)" onclick="getPage(' + pagecount + ')">尾页</a></div>';

   
    return pagestr;
}
var ld;
function getPage(i, fn) {
    ld(i);
}