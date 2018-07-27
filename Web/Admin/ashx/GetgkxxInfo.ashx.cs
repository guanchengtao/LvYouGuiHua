using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace SDAU.ZHCZ.Web.Admin.ashx
{
    /// <summary>
    /// GetgkxxInfo 的摘要说明
    /// </summary>
    public class GetgkxxInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id = Int32.Parse(context.Request["id"]);
            BLL.GongKaiXinXi gongKaiXinXi = new BLL.GongKaiXinXi();
           var data= gongKaiXinXi.GetModel(id);
            string jsondata= new JavaScriptSerializer().Serialize(data);
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