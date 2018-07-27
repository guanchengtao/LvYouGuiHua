using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDAU.ZHCZ.Web.Admin.ashx
{
    /// <summary>
    /// HandlerPage 的摘要说明
    /// </summary>
    public class HandlerPage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            BLL.GongKaiXinXi mainBLL = new BLL.GongKaiXinXi();
            int currPage = int.Parse(context.Request["currPage"] ?? "1");
            int pageSize = int.Parse(context.Request["pageSize"] ?? "5");
            string tar = context.Request["select"].ToString();
            if (tar == "全部") tar = string.Empty;
            List<Model.GongKaiXinXi> datalist = mainBLL.GetListByPage1(tar, string.Empty, (currPage - 1) * pageSize + 1, currPage * pageSize);
            int totalPage;
            int zongTiaoShu = mainBLL.GetRecordCount(string.Empty);
            if (zongTiaoShu % pageSize == 0)
            {
                totalPage = zongTiaoShu / pageSize;
            }
            else
            {
                totalPage = zongTiaoShu / pageSize + 1;
            }
            System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string str = javaScriptSerializer.Serialize(new { datalist=datalist, totalPage=totalPage });
            context.Response.Write(str);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}