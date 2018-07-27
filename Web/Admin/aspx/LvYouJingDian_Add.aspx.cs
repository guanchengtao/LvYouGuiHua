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

        }
        protected void btnSub_Click(object sender, EventArgs e)
        {
            Model.LvYouJingDianXinXi model = new Model.LvYouJingDianXinXi()
            {
                JDMingCheng = mingcheng.Text.ToString(),
                JDWeiZhi = Request["JDWeiZhi"],
                JingDu = Request["jingdu"],
                WeiDu = Request["weidu"],
                JDJieShao = Request["JDJieShao"],
                FBShiJian = DateTime.Now.ToLocalTime(),
                LiuLanCiShu = 0,
                BeiZhu=""
            };
            JingDianXinXi.Add(model);
                Context.Response.Redirect("/Admin/html/Success.html?id=jingdian");
        }
    }
}