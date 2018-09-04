using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDAU.ZHCZ.Web.Admin.aspx
{
    public partial class LiuYanBan_List : System.Web.UI.Page
    {
        public List<Model.LiuYanBan> list { get; set; }
        public int PageCount { get; set; }
        public string Navstring { get; set; }
        public int pageindex { set; get; }
        public int DataCount { get; set; }
        public string showinfo { get; set; }
        public string PreSerach { get; set; }
        public string outseccess { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            pageindex = pageIndex;
            int pageSize = 8;
            BLL.LiuYanBan mainService = new BLL.LiuYanBan();
            var ds = mainService.GetListByPage(string.Empty, " ", (pageIndex - 1) * pageSize + 1, pageSize * pageIndex);
            //取当前页的数据
            list = mainService.DataTableToList(ds.Tables[0]);
            //设置一共多少页
            var allCount = mainService.GetRecordCount(string.Empty);
            DataCount = allCount;
            PageCount = Math.Max((allCount + pageSize - 1) / pageSize, 1);
            //生成 分页的标签
            Navstring = Common.LaomaPager.ShowPageNavigate(pageSize, pageIndex, allCount);
        }

        protected void Serachwithcondition_Click(object sender, EventArgs e)
        {
            BLL.LiuYanBan mainService = new BLL.LiuYanBan();
            string secondtype = Request["condition"];//根据name属性获取
            if (secondtype == "")
            {
                int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
                pageindex = pageIndex;
                int pageSize = 5;
                var ds = mainService.GetListByPage(string.Empty, " ", (pageIndex - 1) * pageSize + 1, pageSize * pageIndex);
                list = mainService.DataTableToList(ds.Tables[0]);
                var allCount = mainService.GetRecordCount(string.Empty);
                DataCount = allCount;
                PageCount = Math.Max((allCount + pageSize - 1) / pageSize, 1);
                Navstring = Common.LaomaPager.ShowPageNavigate(pageSize, pageIndex, allCount);
            }
            else
            {
                int pageIndex = 1;
                pageindex = pageIndex;
                int allCount = 0;
                int pageSize = 0;
                pageSize = 1000;
                var ds = mainService.GetListByPage(secondtype, " ", (pageIndex - 1) * pageSize + 1, pageSize * pageIndex);
                list = mainService.DataTableToList(ds.Tables[0]);
                allCount = mainService.GetRecordCount(secondtype);
                DataCount = allCount;
                if (DataCount == 0) showinfo = "没有数据！";
                PageCount = 1;
                PreSerach = secondtype;
                Navstring = Common.LaomaPager.ShowPageNavigate(pageSize, pageIndex, allCount);
            }
        }
    }
}