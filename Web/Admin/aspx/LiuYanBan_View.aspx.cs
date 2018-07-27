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
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Int32.Parse(Request["id"]);
            model = new BLL.LiuYanBan().GetModel(id);
        }
    }
}