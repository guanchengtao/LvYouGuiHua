using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace SDAU.ZHCZ.Web.Admin.ashx
{
    /// <summary>
    /// JingDianList 的摘要说明
    /// </summary>
    public class JingDianList : IHttpHandler
    {

        public List<Model.LvYouJingDianXinXi> list { get; set; }
        public void ProcessRequest(HttpContext context)
        {
 
            BLL.LvYouJingDianXinXi mainService = new BLL.LvYouJingDianXinXi();
           list = mainService.GetModelList("");
           int count=list.Count();
            var jsonstr1 = new {jingdianList = list,jingdianCount=count};
            string jsonstr = new JavaScriptSerializer().Serialize(jsonstr1);
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