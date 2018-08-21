using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace SDAU.ZHCZ.Web.Admin.ashx
{
    /// <summary>
    /// GetlyjdInfo 的摘要说明
    /// </summary>
    public class GetlyjdInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string sid = context.Request["id"].ToString();
            int id = Int32.Parse(sid);
            BLL.LvYouJingDianXinXi gongKaiXinXi = new BLL.LvYouJingDianXinXi();
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