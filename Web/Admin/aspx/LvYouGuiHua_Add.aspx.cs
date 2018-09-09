using SDAU.ZHCZ.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDAU.ZHCZ.Web.Admin.aspx
{
    public partial class LvYouGuiHua_Add : System.Web.UI.Page
    {
        LvYouGuiHuaXinXi LvYouGuiHuaXinXi = new LvYouGuiHuaXinXi();
        public string jingdu { get; set; }
        public string  weidu { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["jwdu"] != null)
            {
                string jwdu = Request["jwdu"].Trim().ToString();
                if (jwdu.Length == 0)
                {
                    Context.Response.Redirect("../../map/NewMap_JingDian.html");
                }
                else
                {
                    jingdu = jwdu.Split(',')[0].Substring(0, 10);
                    weidu = jwdu.Split(',')[1].Substring(0, 9);
                }

            }
            else
            {
                Context.Response.Redirect("../../map/NewMap_JingDian.html");
            }
        }
        protected void btnSub_Click(object sender, EventArgs e)
        {

            Model.LvYouGuiHuaXinXi model = new Model.LvYouGuiHuaXinXi();
            model.GHXMBianHao = xiangmubianhao.Text;
            if (LvYouGuiHuaXinXi.Exists(xiangmubianhao.Text))
            {
                return;
            }
            model.GHXMMingCheng = xiangmumigncheng.Text;
            model.FuZeRen = Request["fuzeren"];
            model.GuiHuaDanWei = Request["guihuadanwei"];
            model.GuiHuaFanWei = Request["guihuafanwei"];
            model.GuiHuaMianJi = Request["guihuamianji"];
            model.GuiHuaMuBiao = Request["mubiao"];
            model.GuiHuaRenWu = Request["renwu"];
            model.GHXMJieShao = Request["jieshao"];
            if (Request["shijian"].Length == 0)
             model.GuiHuaShiJian = DateTime.Parse("2000-01-01");
            else
            {
                model.GuiHuaShiJian =DateTime.Parse(Request["shijian"]);
            }
            model.BeiZhu = DateTime.Now.ToLocalTime().ToString();
            string kaishi = kaishishijian.Text;
            string jieshu = jieshushijian.Text;
            if(kaishi.Length==0||jieshu.Length==0)
            {
                model.GuiHuaNianXian ="";
            }
            else
            {
                //kaishi = kaishi.Substring(0, kaishi.Length - 3);
                //jieshu = jieshu.Substring(0, jieshu.Length - 3);
                model.GuiHuaNianXian = kaishi + "|" + jieshu;
            }
            model.GuiHuaTu = Request["mytext"];
            model.JingDu = jingdu;
            model.WeiDu = weidu;
            bool b=  LvYouGuiHuaXinXi.Add(model);
            if(b)
            {
                Response.Redirect("/Admin/html/Success.html?id=guihua");
            }
        }

        protected void btncal_Click(object sender, EventArgs e)
        {
                Response.Redirect("LvYouGuiHua_List.aspx");        
        }
    }

}