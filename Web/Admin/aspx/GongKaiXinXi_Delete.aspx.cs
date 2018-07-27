using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDAU.ZHCZ.Web.Admin.aspx
{
    public partial class GongKaiXinXi_Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new BLL.GongKaiXinXi().Delete(Int32.Parse( Request["id"]));
            Context.Response.Redirect("GongKaiXinXi_List.aspx");
        }
    }
}