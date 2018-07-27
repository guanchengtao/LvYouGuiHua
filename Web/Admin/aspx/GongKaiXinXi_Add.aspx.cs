using System;

namespace SDAU.ZHCZ.Web.Admin.aspx
{
    public partial class GongKaiXinXi_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BLL.GongKaiXinXi gongKaiXinXi = new BLL.GongKaiXinXi();
            Model.GongKaiXinXi model = new Model.GongKaiXinXi
            {
                NeiRong = Request["mytext"],
                BiaoTi = this.biaoti.Text,
                LeiXing = Request.Params.Get("select"),
                FaBuDanWei = Request["fabudanwei"],
                ZuoZe = Request["faburen"],
                FaBuShiJian = DateTime.Now,
                LiuLanCiShu = 0,
                BeiZhu = ""
            };
            gongKaiXinXi.Add(model);
            Context.Response.Redirect("/Admin/html/Success.html?id=gongkaixinxi");
        }

        protected void btncal_Click(object sender, EventArgs e)
        {
            Context.Response.Redirect("GongKaiXinXi_List.aspx");
        }
    }
}