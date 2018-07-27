using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace SDAU.ZHCZ.Web.Admin.ashx
{
    /// <summary>
    /// FileOut 的摘要说明
    /// </summary>
    public class FileOut : IHttpHandler
    {
        public string savepath { get; set; }
        public void ProcessRequest(HttpContext context)
        {

            string type = context.Request["action"];
            switch(type)
            {
                case "xinxi":
                    string dir = "/ExcelFile/FileOut/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                    Directory.CreateDirectory(Path.GetDirectoryName(context.Server.MapPath(dir)));
                     savepath = dir + "公开信息.xls";
                    using (SqlDataReader reader = DAL.DBUtility.SqlHelper.ExecuteReader(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"], CommandType.Text, "select * from GongKaiXinXi", null))
                    {
                        if (reader.HasRows)
                        {
                            IWorkbook wk = new HSSFWorkbook();
                            ISheet sheet = wk.CreateSheet();
                            sheet.SetColumnWidth(0, 12 * 256);
                            sheet.SetColumnWidth(1, 20 * 256);
                            sheet.SetColumnWidth(3, 20 * 256);
                            int rowindex = 0;
                            IRow row;
                            row = sheet.CreateRow(rowindex);
                            //设置表头
                            row.CreateCell(0).SetCellValue("标题");
                            row.CreateCell(1).SetCellValue("内容(已加密)");
                            row.CreateCell(2).SetCellValue("类型");
                            row.CreateCell(3).SetCellValue("发布时间");
                            row.CreateCell(4).SetCellValue("发布单位");
                            row.CreateCell(5).SetCellValue("发布人");
                            row.CreateCell(6).SetCellValue("浏览次数");
                            row.CreateCell(7).SetCellValue("备注");
                            rowindex++;
                            //读取每一条数据
                            while (reader.Read())
                            {
                                //"BiaoTi,NeiRong,TuPian,LeiXing,FaBuShiJian,FaBuDanWei,ZuoZe,LiuLanCiShu,BeiZhu)");
                                string BiaoTi = reader.GetString(1);
                                string NeiRong = reader.GetString(2);
                                string LeiXing = reader.GetString(4);
                                //判断是否为空，是空的话就返回null
                                //DateTime? FaBuShiJian = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4);
                                DateTime FaBuShiJian = reader.GetDateTime(5);
                                string FaBuDanWei = reader.GetString(6);
                                string ZuoZe = reader.GetString(7);
                                int LiuLanCiShu = reader.GetInt32(8);
                                string BeiZhu = reader.GetString(9);
                                row = sheet.CreateRow(rowindex);
                                rowindex++;
                                //向行中创建单元格
                                row.CreateCell(0).SetCellValue(BiaoTi);
                                row.CreateCell(1).SetCellValue(NeiRong ?? " ");
                                row.CreateCell(2).SetCellValue(LeiXing);
                                ICell shijian = row.CreateCell(3);
                                //如果单元格为空，插入空白值

                                //日期单独设置格式
                                shijian.SetCellValue(FaBuShiJian);
                                //创建一个单元格格式对象
                                ICellStyle cellStyle = wk.CreateCellStyle();
                                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("m/d/yy h:mm");
                                shijian.CellStyle = cellStyle;
                                row.CreateCell(4).SetCellValue(FaBuDanWei);
                                row.CreateCell(5).SetCellValue(ZuoZe);
                                row.CreateCell(6).SetCellValue(LiuLanCiShu);
                                row.CreateCell(7).SetCellValue(BeiZhu);
                            }
                            using (FileStream Fwrite = File.OpenWrite(HttpContext.Current.Server.MapPath(savepath)))
                            {
                                wk.Write(Fwrite);
                            }
                        }
                    }              
                    break;
                case "guihua":
                    string dir1 = "/ExcelFile/FileOut/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                    Directory.CreateDirectory(Path.GetDirectoryName(context.Server.MapPath(dir1)));
                    savepath = dir1 + "旅游规划信息.xls";
                    using (SqlDataReader reader = DAL.DBUtility.SqlHelper.ExecuteReader(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"], CommandType.Text, "select * from LvYouGuiHuaXinXi", null))
                    {
                        if (reader.HasRows)
                        {
                            IWorkbook wk = new HSSFWorkbook();
                            ISheet sheet = wk.CreateSheet();
                            sheet.SetColumnWidth(0, 12 * 256);
                            sheet.SetColumnWidth(1, 20 * 256);
                            sheet.SetColumnWidth(3, 20 * 256);
                            int rowindex = 0;
                            IRow row;
                            row = sheet.CreateRow(rowindex);
                            //设置表头
                            row.CreateCell(0).SetCellValue("项目编号");
                            row.CreateCell(1).SetCellValue("项目名称");
                            row.CreateCell(2).SetCellValue("项目介绍");
                            row.CreateCell(3).SetCellValue("规划范围");
                            row.CreateCell(4).SetCellValue("规划面积");
                            row.CreateCell(5).SetCellValue("规划年限");
                            row.CreateCell(6).SetCellValue("规划目标");
                            row.CreateCell(7).SetCellValue("规划任务");
                            row.CreateCell(8).SetCellValue("规划时间");
                            row.CreateCell(9).SetCellValue("规划单位");
                            row.CreateCell(10).SetCellValue("负责人");
                            row.CreateCell(11).SetCellValue("备注");
                            row.CreateCell(12).SetCellValue("规划图");
                            rowindex++;
                            //读取每一条数据
                            while (reader.Read())
                            {
                                //GHXMBianHao, GHXMMingCheng, GHXMJieShao, GuiHuaFanWei,
                                //GuiHuaMianJi, GuiHuaNianXian, GuiHuaMuBiao, GuiHuaRenWu, 
                                //GuiHuaShiJian, GuiHuaDanWei, FuZeRen, BeiZhu, GuiHuaTu
                                string GHXMBianHao = reader.GetString(0);
                                string GHXMMingCheng = reader.GetString(1);
                                string GHXMJieShao = reader.GetString(2);
                                string GuiHuaFanWei = reader.GetString(3);
                                string GuiHuaMianJi = reader.GetString(4);
                                string GuiHuaNianXian = reader.GetString(5);
                                string GuiHuaMuBiao = reader.GetString(6);
                                string GuiHuaRenWu = reader.GetString(7);
                                DateTime GuiHuaShiJian = reader.GetDateTime(8);
                                string GuiHuaDanWei = reader.GetString(9);
                                string FuZeRen = reader.GetString(10);
                                string BeiZhu = reader.GetString(11);
                                string GuiHuaTu = reader.GetString(12);

                                row = sheet.CreateRow(rowindex);
                                rowindex++;
                                //向行中创建单元格
                                //GHXMBianHao, GHXMMingCheng, GHXMJieShao, GuiHuaFanWei,
                                //GuiHuaMianJi, GuiHuaNianXian, GuiHuaMuBiao, GuiHuaRenWu, 
                                //GuiHuaShiJian, GuiHuaDanWei, FuZeRen, BeiZhu, GuiHuaTu
                                row.CreateCell(0).SetCellValue(GHXMBianHao);
                                row.CreateCell(1).SetCellValue(GHXMMingCheng);
                                row.CreateCell(2).SetCellValue(GHXMJieShao??" ");
                                row.CreateCell(3).SetCellValue(GuiHuaFanWei??" ");
                                row.CreateCell(4).SetCellValue(GuiHuaMianJi??" ");
                                row.CreateCell(5).SetCellValue(GuiHuaNianXian??" ");
                                row.CreateCell(6).SetCellValue(GuiHuaMuBiao??" ");
                                row.CreateCell(7).SetCellValue(GuiHuaRenWu??" ");                  
                                ICell shijian = row.CreateCell(8);
                                //如果单元格为空，插入空白值

                                //日期单独设置格式
                                shijian.SetCellValue(GuiHuaShiJian);
                                //创建一个单元格格式对象
                                ICellStyle cellStyle = wk.CreateCellStyle();
                                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("m/d/yy h:mm");
                                shijian.CellStyle = cellStyle;
                                row.CreateCell(9).SetCellValue(GuiHuaDanWei??" ");
                                row.CreateCell(10).SetCellValue(FuZeRen??" ");
                                row.CreateCell(11).SetCellValue(BeiZhu??" ");
                                row.CreateCell(12).SetCellValue(GuiHuaTu??"");
                          
                            }
                            using (FileStream Fwrite = File.OpenWrite(HttpContext.Current.Server.MapPath(savepath)))
                            {
                                wk.Write(Fwrite);
                            }
                        }
                    }

                    break;
            }

            context.Response.Write(savepath);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}