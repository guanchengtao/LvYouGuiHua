using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace SDAU.ZHCZ.Web.Admin.ashx
{
    /// <summary>
    /// GetlyghInfo 的摘要说明
    /// </summary>
    public class GetlyghInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string id = context.Request["id"].ToString();
            BLL.LvYouGuiHuaXinXi gongKaiXinXi = new BLL.LvYouGuiHuaXinXi();
            var data = gongKaiXinXi.GetModel(id);
            string jsondata = new JavaScriptSerializer().Serialize(data);
            context.Response.Write(jsondata);
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