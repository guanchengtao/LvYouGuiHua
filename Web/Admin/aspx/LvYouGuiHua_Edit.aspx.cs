using SDAU.ZHCZ.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDAU.ZHCZ.Web.Admin.aspx
{
    public partial class LvYouGuiHua_Edit : System.Web.UI.Page
    {
        public Model.LvYouGuiHuaXinXi model { get; set; }
        LvYouGuiHuaXinXi LvYouGuiHuaXinXi = new LvYouGuiHuaXinXi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                this.xiangmumigncheng.Focus();
                string id =Request["id"];
                model = new BLL.LvYouGuiHuaXinXi().GetModel(id);
                xiangmubianhao1.Text = model.GHXMBianHao;
                xiangmumigncheng.Text = model.GHXMMingCheng;
                #region 处理规划时间
                if (model.GuiHuaShiJian == DateTime.Parse("2000-01-01"))
                {
                    shijian1.Text = "yyyy-mm-dd";
                }
                else
                {
                    string date = model.GuiHuaShiJian.ToShortDateString();
                    string year = date.Split('/')[0];
                    string month = date.Split('/')[1];
                    if (month.Length == 1)
                    {
                        month = "0" + month;
                    }
                    string day = date.Split('/')[2];
                    if (day.Length == 1)
                    {
                        day = "0" + day;
                    }
                    shijian1.Text = year + "-" + month + "-" + day;
                }
                #endregion
               if(model.GuiHuaNianXian=="")
                {
                    kaishishijian.Text = "yyyy-mm-dd";
                    jieshushijian.Text = "yyyy-mm-dd";
                }
                else
                {
                    kaishishijian.Text = model.GuiHuaNianXian.Split('|')[0];
                    jieshushijian.Text = model.GuiHuaNianXian.Split('|')[1];
                }

            }
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            string id = Request["id"];
            Model.LvYouGuiHuaXinXi guihua = LvYouGuiHuaXinXi.GetModel(id);
            guihua.GHXMMingCheng = xiangmumigncheng.Text;
            guihua.FuZeRen = Request["fuzeren"];
            guihua.GuiHuaDanWei = Request["guihuadanwei"];
            guihua.GuiHuaFanWei = Request["guihuafanwei"];
            guihua.GuiHuaMianJi = Request["guihuamianji"];
            guihua.GuiHuaMuBiao = Request["mubiao"];
            guihua.GuiHuaRenWu = Request["renwu"];
            guihua.GHXMJieShao = Request["jieshao"];
            if (Request["shijian1"].Length == 0)
                guihua.GuiHuaShiJian = DateTime.Parse("2000-01-01");
            else
            {
                guihua.GuiHuaShiJian = DateTime.Parse(Request["shijian1"]);
            }
            guihua.BeiZhu = DateTime.Now.ToLocalTime().ToString();
            string kaishi = kaishishijian.Text;
            string jieshu = jieshushijian.Text;
            if (kaishi.Length == 0 || jieshu.Length == 0)
            {
                guihua.GuiHuaNianXian = "";
            }
            else
            {
                guihua.GuiHuaNianXian = kaishi + "|" + jieshu;
            }
            guihua.GuiHuaTu = Request["mytext"];
            bool b = LvYouGuiHuaXinXi.Update(guihua);
            if(b)
            {
                Response.Redirect("LvYouGuiHua_List.aspx");
            }
            else
            {
                Response.Write("notok");
                
            }
        }

        protected void btncal_Click(object sender, EventArgs e)
        {
            Response.Redirect("LvYouGuiHua_List.aspx");
        }
    }
}