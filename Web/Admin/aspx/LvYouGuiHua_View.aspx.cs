using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDAU.ZHCZ.Web.Admin.aspx
{
    public partial class LvYouGuiHua_View : System.Web.UI.Page
    {
        public Model.LvYouGuiHuaXinXi model { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string id =Request["id"].ToString();
                BLL.LvYouGuiHuaXinXi lvYouGuiHuaXinXi = new BLL.LvYouGuiHuaXinXi();
                model = lvYouGuiHuaXinXi.GetModel(id);             
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("LvYouGuiHua_List.aspx");
        }
    }
}