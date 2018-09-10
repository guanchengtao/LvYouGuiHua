using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDAU.ZHCZ.Web.Admin.aspx
{
    public partial class LvYouGuiHuamap_Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request["id"].ToString();
            new BLL.LvYouGuiHuaXinXi().Delete(id);
            new BLL.LiuYanBan().Delete(id);
            Response.Redirect("../../map/NewMap_JingDian.html");
        }
    }
}