using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDAU.ZHCZ.Web.Admin.aspx
{
    public partial class LvYouJingDian_List : System.Web.UI.Page
    {
        public List<Model.LvYouJingDianXinXi> list { get; set; }
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
            int pageSize = 5;
            BLL.LvYouJingDianXinXi mainService = new BLL.LvYouJingDianXinXi();
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
            BLL.LvYouJingDianXinXi mainService = new BLL.LvYouJingDianXinXi();
            string firsttype = select2.Items[select2.SelectedIndex].Value;
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
                string combinestr = firsttype + "|" + secondtype;
                pageSize = 1000;
                var ds = mainService.GetListByPage(combinestr, " ", (pageIndex - 1) * pageSize + 1, pageSize * pageIndex);
                list = mainService.DataTableToList(ds.Tables[0]);
                allCount = mainService.GetRecordCount(combinestr);
                DataCount = allCount;
                if (DataCount == 0) showinfo = "没有数据！";
                PageCount = 1;
                PreSerach = secondtype;
                Navstring = Common.LaomaPager.ShowPageNavigate(pageSize, pageIndex, allCount);

            }
        }

        protected void filein_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile == false)//HasFile用来检查FileUpload是否有指定文件
            {
                Response.Write("<script>alert('请您选择Excel文件')</script> ");
                return;//当无文件时,返回
            }
            string IsXls = Path.GetExtension(FileUpload1.FileName);
            if (IsXls != ".xls")
            {
                Response.Write("<script>alert('文件格式不正确，请重新选择！')</script>");
                return;//当选择的不是Excel文件时,返回
            }
            string filename = FileUpload1.FileName;//获取Execle文件名  DateTime日期函数
            //建立新的文件夹
            string dir = "/ExcelFile/FileIn/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
            Directory.CreateDirectory(Path.GetDirectoryName(Server.MapPath(dir)));
            string savePath = Server.MapPath(dir + filename);//Server.MapPath 获得虚拟服务器相对路径
            FileUpload1.SaveAs(savePath);                        //SaveAs 将上传的文件内容保存在服务器
            using (FileStream fsread = File.OpenRead(savePath))
            {
                IWorkbook wk = new HSSFWorkbook(fsread);
                ISheet sheet = wk.GetSheetAt(0);
                for (int i = 1; i <= sheet.LastRowNum; i++)
                {
                    //, JDMingCheng, JDJieShao, JDWeiZhi, JingDu, WeiDu, LiuLanCiShu, FBShiJian, BeiZhu, 
                    IRow row = sheet.GetRow(i);
                    int JDBianHao =Convert.ToInt32(row.GetCell(0).NumericCellValue);
                    string JDMingCheng = row.GetCell(1).StringCellValue ?? "";
                    string JDJieShao = row.GetCell(2).StringCellValue ?? "";

                    string JDWeiZhi = row.GetCell(3).StringCellValue ?? "";
                    string JingDu = row.GetCell(4).StringCellValue ?? "";
                    string WeiDu = row.GetCell(5).StringCellValue ?? "";
                    int Liulancishu = Convert.ToInt32(row.GetCell(6).NumericCellValue);
                    int LiuLanCiShu = Liulancishu== 0?0: Liulancishu;
                    DateTime FBShiJian = row.GetCell(7).DateCellValue;
                    string BeiZhu = row.GetCell(8).StringCellValue ?? "";
                    SqlParameter[] ps = new SqlParameter[]
                    {
                    new SqlParameter("@JDBianHao", JDBianHao),
                    new SqlParameter("@JDMingCheng", JDMingCheng),
                    new SqlParameter("@JDJieShao", JDJieShao),
                    new SqlParameter("@JDWeiZhi",JDWeiZhi),
                    new SqlParameter("@JingDu",JingDu),
                    new SqlParameter("@WeiDu",WeiDu),
                    new SqlParameter("@LiuLanCiShu",LiuLanCiShu),
                    new SqlParameter("@FBShiJian",FBShiJian), 
                    new SqlParameter("@BeiZhu",BeiZhu)
                };
                    //执行插入操作
                    Common.SqlHelper.EXNQWithoutParameter(InsertSql(), CommandType.Text, ps);
                }
            }
            outseccess = "<script>alert('导入excel文件成功');" +
                  " window.location.href='LvYouJingDian_List.aspx'</script>";

        }

        protected void Add_Click(object sender, EventArgs e)
        {
            Context.Response.Redirect("LvYouJingDian_Add.aspx");
        }
        public static string InsertSql()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LvYouJingDianXinXi(");
            strSql.Append("JDMingCheng, JDJieShao, JDWeiZhi, JingDu, WeiDu, LiuLanCiShu, FBShiJian, BeiZhu)");
            strSql.Append(" values (");
            strSql.Append("@JDMingCheng,@JDJieShao,@JDWeiZhi,@JingDu,@WeiDu, @LiuLanCiShu,@FBShiJian,@BeiZhu)");
            return strSql.ToString();
        }
    }
}