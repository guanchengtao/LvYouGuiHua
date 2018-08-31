using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDAU.ZHCZ.Web.Admin.aspx
{
    public partial class LvYouJingDianmap_Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Int32.Parse(Request["id"]);
            new BLL.LvYouJingDianXinXi().Delete(id);
            Response.Redirect("../../map/NewMap_JingDian.html");
        }
    }
}