using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDAU.ZHCZ.Web.Admin.aspx
{
    public partial class LvYouJingDian_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.LvYouJingDianXinXi lvYouJingDianXinXi = new BLL.LvYouJingDianXinXi();



            lvYouJingDianXinXi.Add(new Model.LvYouJingDianXinXi()
            {
                JDMingCheng = "s",
                JDJieShao = "sss",
                JingDu = "1",
                WeiDu = "2",
                JDWeiZhi = "3",
                LiuLanCiShu = 1,
                FBShiJian = DateTime.Now,
                BeiZhu = "111",
                TuPian ="image"
            });
        }
    }
}