using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDAU.ZHCZ.Web.Admin.aspx
{
    public partial class LiuYanBan_View : System.Web.UI.Page
    {

        public Model.LiuYanBan model { get; set; }
        BLL.LiuYanBan LiuYanBan = new BLL.LiuYanBan();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Int32.Parse(Request["id"]);
            model = new BLL.LiuYanBan().GetModel(id);
        }

        protected void huifu_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(Request["id"]);
            Model.LiuYanBan mdoel = LiuYanBan.GetModel(id);
            mdoel.HuiFuNeiRong = Request["huifuneirong"].ToString();
            mdoel.HuiFuShiJian = DateTime.Now;
            mdoel.HuiFuZhuangTai = "已回复";
            new BLL.LiuYanBan().Update(mdoel);
            Response.Redirect("LiuYanBan_List.aspx");
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("LiuYanBan_List.aspx");
        }
    }
}