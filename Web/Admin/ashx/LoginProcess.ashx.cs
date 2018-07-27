using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace SDAU.ZHCZ.Web.Admin.ashx
{
    /// <summary>
    /// LoginProcess 的摘要说明
    /// </summary>
    public class LoginProcess : IHttpHandler,IRequiresSessionState
    {

        public string data { get; set; }
        public void ProcessRequest(HttpContext context)
        {
            //前台数据：
            // data: { loginname:loginname,password:password,code:code,tm:new Date().getTime()},
            string loginname = context.Request["loginname"].ToString();
           // string password = Common.GetStringMd5.GetStringMD5(context.Request["password"].ToString());
            string password = context.Request["password"].ToString();
            string code = context.Request["code"].ToString();
            //bool b = new BLL.UserLogin().UserInfo(loginname, password);
            if (loginname!="admin"||password!="admin")
            {
                data = "usererror";
            }
            else if (code != context.Session["ValidateCode"].ToString())
            {
                data = "codeerror";
            }
            else
            {
                data = "success";
            }
            //返回json字符串
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