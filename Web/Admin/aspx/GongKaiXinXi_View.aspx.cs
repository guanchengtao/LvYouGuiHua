using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDAU.ZHCZ.Web.Admin.aspx
{
    public partial class GongKaiXinXi_View : System.Web.UI.Page
    {
        public Model.GongKaiXinXi model { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.GongKaiXinXi gongKaiXinXi = new BLL.GongKaiXinXi();
             model =gongKaiXinXi.GetModel(Int32.Parse(Request["id"]));
            //TimeSpan sp = DateTime.Now - model.FaBuShiJian;
            //DateTime dt=DateTime.Now + sp;
            //if (sp.TotalMinutes >= 1 && sp.TotalHours <= 72)
            //{
            //    Context.Response.Write(dt);
            //}
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Context.Response.Redirect("GongKaiXinXi_List.aspx");
        }
    }
}