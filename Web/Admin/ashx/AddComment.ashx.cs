using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDAU.ZHCZ.Web.Admin.ashx
{
    /// <summary>
    /// AddComment 的摘要说明
    /// </summary>
    public class AddComment : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string comment = context.Request["comment"];
            BLL.LiuYanBan liuYanBan = new BLL.LiuYanBan();
            Model.LiuYanBan model = new Model.LiuYanBan()
            {
                LiuYanShiJian = DateTime.Now,
                NeiRong = comment,

            };

            liuYanBan.Add(model);
            context.Response.Write("ok");
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