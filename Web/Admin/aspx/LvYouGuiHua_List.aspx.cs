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
    public partial class LvYouGuiHua_List : System.Web.UI.Page
    {
        public List<Model.LvYouGuiHuaXinXi> list { get; set; }
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
                BLL.LvYouGuiHuaXinXi mainService = new BLL.LvYouGuiHuaXinXi();
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
            Context.Response.Redirect("LvYouGuiHua_Add.aspx");
        }

    
        protected void Serachwithcondition_Click(object sender, EventArgs e)
        {
            BLL.LvYouGuiHuaXinXi mainService = new BLL.LvYouGuiHuaXinXi();
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
                    //读取每行
                    IRow row = sheet.GetRow(i);
                    string GHXMBianHao = row.GetCell(0).StringCellValue ?? "";
                    string GHXMMingCheng = row.GetCell(1).StringCellValue ?? "";
                    string GHXMJieShao = row.GetCell(2).StringCellValue ?? "";
                   
                    string GuiHuaFanWei = row.GetCell(3).StringCellValue ?? "";
                    string GuiHuaMianJi = row.GetCell(4).StringCellValue ?? "";
                    string GuiHuaNianXian = row.GetCell(5).StringCellValue ?? "";
                    string GuiHuaMuBiao = row.GetCell(6).StringCellValue ?? "";

                    string GuiHuaRenWu = row.GetCell(7).StringCellValue ?? "";
                    DateTime GuiHuaShiJian = row.GetCell(8).DateCellValue;
                    string GuiHuaDanWei = row.GetCell(9).StringCellValue ?? "";
                    string FuZeRen = row.GetCell(10).StringCellValue ?? "";
                    string Beizhu = row.GetCell(11).StringCellValue ?? "";
                    string GuiHuaTu = row.GetCell(12).StringCellValue ?? "";
                    SqlParameter[] ps = new SqlParameter[]
                    {                       
                    new SqlParameter("@GHXMBianHao", GHXMBianHao),
                    new SqlParameter("@GHXMMingCheng", GHXMMingCheng),
                    new SqlParameter("@GHXMJieShao", GHXMJieShao),
                    new SqlParameter("@GuiHuaFanWei",GuiHuaFanWei),
                    new SqlParameter("@GuiHuaMianJi",GuiHuaMianJi),
                    new SqlParameter("@GuiHuaNianXian",GuiHuaNianXian),
                    new SqlParameter("@GuiHuaMuBiao",GuiHuaMuBiao),
                    new SqlParameter("@GuiHuaRenWu",GuiHuaRenWu),
                    new SqlParameter("@GuiHuaTu",GuiHuaTu),
                    new SqlParameter("@GuiHuaShiJian",GuiHuaShiJian),
                    new SqlParameter("@GuiHuaDanWei",GuiHuaDanWei),
                    new SqlParameter("@FuZeRen",FuZeRen),
                    new SqlParameter("@BeiZhu",Beizhu)
                };
                    //执行插入操作
                    Common.SqlHelper.EXNQWithoutParameter(InsertSql(), CommandType.Text, ps);
                }
            }
            outseccess = "<script>alert('导入excel文件成功');" +
                  " window.location.href='LvYouGuiHua_List.aspx'</script>";
        }

        public static string InsertSql()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LvYouGuiHuaXinXi(");
            strSql.Append("GHXMBianHao,GHXMMingCheng,GHXMJieShao,GuiHuaFanWei,GuiHuaMianJi,GuiHuaNianXian,GuiHuaMuBiao,GuiHuaRenWu,GuiHuaTu,GuiHuaShiJian,GuiHuaDanWei,FuZeRen,BeiZhu)");
            strSql.Append(" values (");
            strSql.Append("@GHXMBianHao,@GHXMMingCheng,@GHXMJieShao,@GuiHuaFanWei,@GuiHuaMianJi,@GuiHuaNianXian,@GuiHuaMuBiao,@GuiHuaRenWu,@GuiHuaTu,@GuiHuaShiJian,@GuiHuaDanWei,@FuZeRen,@BeiZhu)");
            return strSql.ToString();
        }

    }
}