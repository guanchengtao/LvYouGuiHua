using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace SDAU.ZHCZ.Web.Admin.ashx
{
    /// <summary>
    /// LvYouGuiHuaList 的摘要说明
    /// </summary>
    public class LvYouGuiHuaList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            BLL.LvYouGuiHuaXinXi model = new BLL.LvYouGuiHuaXinXi();
            var list1 = model.GetModelList("");
            int count = list1.Count();
            var data = new { list = list1, Count = count };
            string jsonstr = new JavaScriptSerializer().Serialize(data);
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