using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web;

namespace SDAU.ZHCZ.Web.Admin.aspx
{
    public partial class GongKaiXinXi_List : System.Web.UI.Page
    {
        public List<Model.GongKaiXinXi> list { get; set; }
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
            BLL.GongKaiXinXi mainService = new BLL.GongKaiXinXi();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Context.Response.Redirect("GongKaiXinXi_Add.aspx");
        }

        protected void Serachwithcondition_Click(object sender, EventArgs e)
        {
            BLL.GongKaiXinXi mainService = new BLL.GongKaiXinXi();
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
            string savePath = Server.MapPath(dir+filename);//Server.MapPath 获得虚拟服务器相对路径
            FileUpload1.SaveAs(savePath);                        //SaveAs 将上传的文件内容保存在服务器
                using (FileStream fsread = File.OpenRead(savePath))
                {
                    IWorkbook wk = new HSSFWorkbook(fsread);
                    ISheet sheet = wk.GetSheetAt(0);
                    for (int i = 1; i <= sheet.LastRowNum; i++)
                    {
                        //读取每行
                        IRow row = sheet.GetRow(i);
                        string BiaoTi = row.GetCell(0).StringCellValue ?? "";
                        string NeiRong = row.GetCell(1).StringCellValue ?? "";
                        string LeiXing = row.GetCell(2).StringCellValue ?? "";
                        DateTime FaBuShiJian = row.GetCell(3).DateCellValue;
                        string FaBuDanWei = row.GetCell(4).StringCellValue ?? "";
                        string ZuoZe = row.GetCell(5).StringCellValue ?? "";
                        int LiuLanCiShu = (int)(row.GetCell(6).NumericCellValue);
                        string Beizhu = row.GetCell(7).StringCellValue ?? "";
                        SqlParameter[] ps = new SqlParameter[]
                        {
                        new SqlParameter("@BiaoTi",BiaoTi),
                        new SqlParameter("@NeiRong",NeiRong),
                        new SqlParameter("@LeiXing",LeiXing),
                        new SqlParameter("@FaBuShiJian",FaBuShiJian),
                            new SqlParameter("@FaBuDanWei",FaBuDanWei),
                            new SqlParameter("@ZuoZe",ZuoZe),
                            new SqlParameter("@LiuLanCiShu",LiuLanCiShu),
                            new SqlParameter("@Beizhu",Beizhu),
                        };
                        //执行插入操作
                        Common.SqlHelper.EXNQWithoutParameter(InsertSql(), CommandType.Text, ps);
                    }
                }
                outseccess = "<script>alert('导入excel文件成功');" +
                      " window.location.href='GongKaiXinXi_List.aspx'</script>";
            }
        public static string InsertSql()
        {
            return "insert into GongKaiXinXi(BiaoTi,NeiRong,LeiXing,FaBuShiJian,FaBuDanWei,ZuoZe,LiuLanCiShu,BeiZhu) values(@BiaoTi,@NeiRong,@LeiXing,@FaBuShiJian,@FaBuDanWei,@ZuoZe,@LiuLanCiShu,@BeiZhu)";
        }

   
    }
}