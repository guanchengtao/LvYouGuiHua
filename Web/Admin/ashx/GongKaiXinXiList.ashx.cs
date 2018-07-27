using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace SDAU.ZHCZ.Web.Admin.ashx
{
    /// <summary>
    /// GongKaiXinXiList 的摘要说明
    /// </summary>
    public class GongKaiXinXiList : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            BLL.GongKaiXinXi gongKaiXinXi = new BLL.GongKaiXinXi();
            var list = gongKaiXinXi.GetModelList("");
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