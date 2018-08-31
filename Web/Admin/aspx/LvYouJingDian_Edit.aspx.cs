using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDAU.ZHCZ.Web.Admin.aspx
{
    public partial class LvYouJingDian_Edit : System.Web.UI.Page
    {
        public Model.LvYouJingDianXinXi Model { get; set; }
        BLL.LvYouJingDianXinXi JingDian = new BLL.LvYouJingDianXinXi();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {        
                int id = Int32.Parse(Request["id"]);
                Model = JingDian.GetModel(id);
                biaoti.Text = Model.JDMingCheng;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(Request["id"]);
            Model.LvYouJingDianXinXi model1 = JingDian.GetModel(id);
            model1.JDJieShao = Request["mytext"];
            model1.JDMingCheng = biaoti.Text;
            model1.JDWeiZhi = Request["JDWeiZhi"];
            model1.JingDu = Request["JingDu"];
            model1.WeiDu = Request["WeiDu"];
            JingDian.Update(model1);
            Context.Response.Redirect("LvYouJingDian_List.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {


            if (Request.UrlReferrer.LocalPath.Trim() != "/LvYouJingDian_List.aspx")
            { Context.Response.Redirect("LvYouJingDian_List.aspx"); }
            else
            {
                Response.Redirect("../../map/NewMap_JingDian.html");
            }
        }
    }
}