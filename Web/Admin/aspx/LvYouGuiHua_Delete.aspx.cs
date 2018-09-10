using System;

namespace SDAU.ZHCZ.Web.Admin.aspx
{
    public partial class LvYouGuiHua_Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id =Request["id"].ToString();
            new BLL.LvYouGuiHuaXinXi().Delete(id);

            new BLL.LiuYanBan().Delete(id);
            Response.Redirect("LvYouGuiHua_List.aspx");
        }
    }
}