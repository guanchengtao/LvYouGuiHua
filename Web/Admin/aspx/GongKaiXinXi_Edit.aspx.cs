using System;
using System.Web.UI;

namespace SDAU.ZHCZ.Web.Admin.aspx
{
    public partial class GongKaiXinXi_Edit : Page
    {
        public Model.GongKaiXinXi model { get; set; }
        BLL.GongKaiXinXi gongKaiXinXi = new BLL.GongKaiXinXi();
 
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {
                int id = Int32.Parse(Request["id"]);
                model = gongKaiXinXi.GetModel(id);
                biaoti.Text = model.BiaoTi;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(Request["id"]);
                Model.GongKaiXinXi model1 = gongKaiXinXi.GetModel(id);
                model1.NeiRong = Request["mytext"];
                model1.BiaoTi = biaoti.Text;
                model1.LeiXing = Request.Params.Get("select");
                model1.FaBuDanWei = Request["fabudanwei"];
                model1.ZuoZe = Request["faburen"];
                gongKaiXinXi.Update(model1);
                Context.Response.Redirect("GongKaiXinXi_List.aspx");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Context.Response.Redirect("GongKaiXinXi_List.aspx");
        }
    }
}