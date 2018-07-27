using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SDAU.ZHCZ.Web.Admin.ashx
{
    /// <summary>
    /// GetInfoId 的摘要说明
    /// </summary>
    public class GetInfoId : IHttpHandler
    {
        public DataSet Dt { get; set; }
        public void ProcessRequest(HttpContext context)
        {
            //当添加成功后，用户点击查看信息，获得刚添加进去的ID
            context.Response.ContentType = "text/plain";
            string type = context.Request["type"];
            switch (type)
            {
                case "guihua":
                    BLL.LvYouGuiHuaXinXi guihua = new BLL.LvYouGuiHuaXinXi();
                    Dt = guihua.GetList1("");
                    break;
                case "gongkaixinxi":
                    BLL.GongKaiXinXi gongKaiXinXi = new BLL.GongKaiXinXi();
                    Dt = gongKaiXinXi.GetList1("");
                    break;
                case "jingdian":
                    BLL.LvYouJingDianXinXi tt = new BLL.LvYouJingDianXinXi();
                    Dt = tt.GetList1("");
                    break;
                    //可拓展
                    //。。。。。

            }
            int rowIndex = Dt.Tables[0].Rows.Count;
            string id=Dt.Tables[0].Rows[rowIndex-1][0].ToString();
            context.Response.Write(id);
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