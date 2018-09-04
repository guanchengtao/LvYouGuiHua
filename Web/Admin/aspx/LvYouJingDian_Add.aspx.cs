using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDAU.ZHCZ.Web.Admin.aspx
{
    public partial class LvYouJingDian_Add : System.Web.UI.Page
    {
        BLL.LvYouJingDianXinXi JingDianXinXi = new BLL.LvYouJingDianXinXi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["jwdu"] != null)
            {
                string jwdu = Request["jwdu"].Trim().ToString();
                if (jwdu.Length == 0)
                {
                    Context.Response.Redirect("../../map/NewMap_JingDian.html");
                }
                else
                {
                    jingdu.Text = jwdu.Split(',')[0].Substring(0,10);
                    weidu.Text = jwdu.Split(',')[1].Substring(0,9);
                }

            }
            else
            {
                Context.Response.Redirect("../../map/NewMap_JingDian.html");
            }

        }
        protected void btnSub_Click(object sender, EventArgs e)
        {
           
            Model.LvYouJingDianXinXi model = new Model.LvYouJingDianXinXi()
            {
                JDMingCheng = mingcheng.Text.ToString(),
                JDWeiZhi = Request["JDWeiZhi"],
                JingDu = jingdu.Text,
                WeiDu = weidu.Text,
                JDJieShao = Request["JDJieShao"],
                TuPian=Request["JDTuPian"],
                FBShiJian = DateTime.Now.ToLocalTime(),
                LiuLanCiShu = 0,
                BeiZhu=""
            };
            JingDianXinXi.Add(model);
                Context.Response.Redirect("/Admin/html/Success.html?id=jingdian");
        }
    }
}