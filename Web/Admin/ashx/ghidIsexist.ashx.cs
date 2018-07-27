using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDAU.ZHCZ.Web.Admin.ashx
{
    /// <summary>
    /// ghidIsexist 的摘要说明
    /// </summary>
    public class ghidIsexist : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string bianhao = context.Request["bianhao"].ToString();
            BLL.LvYouGuiHuaXinXi lvYouGuiHuaXinXi = new BLL.LvYouGuiHuaXinXi();
           if (lvYouGuiHuaXinXi.Exists(bianhao))
            {
                context.Response.Write("notok");
            }
            else
            {
                context.Response.Write("Hello World");
            }
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