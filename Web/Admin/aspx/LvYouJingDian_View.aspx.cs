using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDAU.ZHCZ.Web.Admin.aspx
{
    public partial class LvYouJingDian_View : System.Web.UI.Page
    {
        public Model.LvYouJingDianXinXi model { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Int32.Parse(Request["id"]);
            BLL.LvYouJingDianXinXi lvYouJingDian = new BLL.LvYouJingDianXinXi();
            model = lvYouJingDian.GetModel(id);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Context.Response.Redirect("LvYouJingDian_List.aspx");
        }
    }
}