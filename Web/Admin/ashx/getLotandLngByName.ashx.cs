using SDAU.ZHCZ.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace SDAU.ZHCZ.Web.Admin.ashx
{
    /// <summary>
    /// getLotandLngByName 的摘要说明
    /// </summary>
    public class getLotandLngByName : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string name = context.Request["jingdianname"].ToString();
            LvYouJingDianXinXi lvYouJingDianXinXi = new LvYouJingDianXinXi();
           var data= lvYouJingDianXinXi.GetModel(name);
            if(data==null)
            {
                LvYouGuiHuaXinXi lvYouGuiHuaList = new LvYouGuiHuaXinXi();
               var  data1 = lvYouGuiHuaList.GetModel1(name);
                string jsondata = new JavaScriptSerializer().Serialize(data1);
                context.Response.Write(jsondata);
            }
            else
            {
                string jsondata = new JavaScriptSerializer().Serialize(data);
                context.Response.Write(jsondata);
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