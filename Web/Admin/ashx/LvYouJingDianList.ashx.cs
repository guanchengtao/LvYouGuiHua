using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace SDAU.ZHCZ.Web.Admin.ashx
{
    /// <summary>
    /// LvYouJingDianList 的摘要说明
    /// </summary>
    public class LvYouJingDianList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
           context.Response.AppendHeader("Content-type", "application/json");
            BLL.LvYouJingDianXinXi model = new BLL.LvYouJingDianXinXi();
            var list = model.GetModelList("");
            string jsonstr = new JavaScriptSerializer().Serialize(list);
            context.Response.Write(jsonstr);
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