using System;

namespace SDAU.ZHCZ.Web.Admin.aspx
{
    public partial class LvYouGuiHua_Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new BLL.LvYouGuiHuaXinXi().Delete(Request["id"]);
            Response.Redirect("LvYouGuiHua_List.aspx");
        }
    }
}