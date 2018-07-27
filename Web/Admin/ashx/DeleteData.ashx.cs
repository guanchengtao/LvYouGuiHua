using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDAU.ZHCZ.Web.Admin.ashx
{
    /// <summary>
    /// DeleteData 的摘要说明
    /// </summary>
    public class DeleteData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string str = context.Request["str"];
            string action = context.Request["action"];
            if(str.Substring(0,1)==",")
            {
                str = str.Substring(1, str.Length - 2);
            }
            else
            {
                str = str.Substring(0, str.Length - 1);
            }
            switch(action)
            {
                case "guihua": BLL.LvYouGuiHuaXinXi guihua = new BLL.LvYouGuiHuaXinXi();
                    guihua.DeleteList(str);
                    break;
                case "xinxi":
                    BLL.GongKaiXinXi gongKaiXinXi = new BLL.GongKaiXinXi();
                    gongKaiXinXi.DeleteList(str);
                    break;
                case "jingdian":
                    BLL.LvYouJingDianXinXi LvYouJingDianXinXi = new BLL.LvYouJingDianXinXi();
                    LvYouJingDianXinXi.DeleteList(str);
                    break;
                case "liuyan":
                    BLL.LiuYanBan liuYanBan = new BLL.LiuYanBan();
                    liuYanBan.DeleteList(str);
                    break;
       
            }

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