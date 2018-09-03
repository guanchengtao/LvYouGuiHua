using SDAU.ZHCZ.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace SDAU.ZHCZ.Web.Admin.ashx
{
    /// <summary>
    /// GetCommentList 的摘要说明
    /// </summary>
    public class GetCommentList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            LiuYanBan gongKaiXinXi = new LiuYanBan();
            var list1 = gongKaiXinXi.GetModelList("");
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