using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace SDAU.ZHCZ.DAL
{
    /// <summary>
    /// 数据访问类:GongKaiXinXi
    /// </summary>
    public partial class GongKaiXinXi
    {
        public GongKaiXinXi()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("BianHao", "GongKaiXinXi");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string BiaoTi, DateTime FaBuShiJian, string FaBuDanWei, int BianHao)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from GongKaiXinXi");
            strSql.Append(" where BiaoTi=@BiaoTi and FaBuShiJian=@FaBuShiJian and FaBuDanWei=@FaBuDanWei and BianHao=@BianHao ");
            SqlParameter[] parameters = {
                    new SqlParameter("@BiaoTi", SqlDbType.NVarChar,30),
                    new SqlParameter("@FaBuShiJian", SqlDbType.DateTime),
                    new SqlParameter("@FaBuDanWei", SqlDbType.NVarChar,20),
                    new SqlParameter("@BianHao", SqlDbType.Int,4)           };
            parameters[0].Value = BiaoTi;
            parameters[1].Value = FaBuShiJian;
            parameters[2].Value = FaBuDanWei;
            parameters[3].Value = BianHao;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SDAU.ZHCZ.Model.GongKaiXinXi model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GongKaiXinXi(");
            strSql.Append("BiaoTi,NeiRong,TuPian,LeiXing,FaBuShiJian,FaBuDanWei,ZuoZe,LiuLanCiShu,BeiZhu)");
            strSql.Append(" values (");
            strSql.Append("@BiaoTi,@NeiRong,@TuPian,@LeiXing,@FaBuShiJian,@FaBuDanWei,@ZuoZe,@LiuLanCiShu,@BeiZhu)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@BiaoTi", SqlDbType.NVarChar,30),
                    new SqlParameter("@NeiRong", SqlDbType.NVarChar,500000),
                    new SqlParameter("@TuPian", SqlDbType.Image),
                    new SqlParameter("@LeiXing", SqlDbType.NVarChar,20),
                    new SqlParameter("@FaBuShiJian", SqlDbType.DateTime),
                    new SqlParameter("@FaBuDanWei", SqlDbType.NVarChar,20),
                    new SqlParameter("@ZuoZe", SqlDbType.NVarChar,20),
                    new SqlParameter("@LiuLanCiShu", SqlDbType.Int,4),
                    new SqlParameter("@BeiZhu", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.BiaoTi;
            parameters[1].Value = model.NeiRong;
            parameters[2].Value = model.TuPian;
            parameters[3].Value = model.LeiXing;
            parameters[4].Value = model.FaBuShiJian;
            parameters[5].Value = model.FaBuDanWei;
            parameters[6].Value = model.ZuoZe;
            parameters[7].Value = model.LiuLanCiShu;
            parameters[8].Value = model.BeiZhu;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SDAU.ZHCZ.Model.GongKaiXinXi model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GongKaiXinXi set ");
            strSql.Append("NeiRong=@NeiRong,");
            strSql.Append("BiaoTi=@BiaoTi,");
            strSql.Append("TuPian=@TuPian,");
            strSql.Append("FaBuDanWei=@FaBuDanWei,");
            strSql.Append("LeiXing=@LeiXing,");
            strSql.Append("ZuoZe=@ZuoZe,");
            strSql.Append("LiuLanCiShu=@LiuLanCiShu,");
            strSql.Append("BeiZhu=@BeiZhu");
            strSql.Append(" where BianHao=@BianHao");
            SqlParameter[] parameters = {
                    new SqlParameter("@NeiRong", SqlDbType.NVarChar,500000),
                    new SqlParameter("@TuPian", SqlDbType.Image),
                    new SqlParameter("@LeiXing", SqlDbType.NVarChar,20),
                    new SqlParameter("@ZuoZe", SqlDbType.NVarChar,20),
                    new SqlParameter("@LiuLanCiShu", SqlDbType.Int,4),
                    new SqlParameter("@BeiZhu", SqlDbType.NVarChar,200),
                    new SqlParameter("@BianHao", SqlDbType.Int,4),
                    new SqlParameter("@BiaoTi", SqlDbType.NVarChar,30),
                    new SqlParameter("@FaBuShiJian", SqlDbType.DateTime),
                    new SqlParameter("@FaBuDanWei", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.NeiRong;
            parameters[1].Value = model.TuPian;
            parameters[2].Value = model.LeiXing;
            parameters[3].Value = model.ZuoZe;
            parameters[4].Value = model.LiuLanCiShu;
            parameters[5].Value = model.BeiZhu;
            parameters[6].Value = model.BianHao;
            parameters[7].Value = model.BiaoTi;
            parameters[8].Value = model.FaBuShiJian;
            parameters[9].Value = model.FaBuDanWei;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int BianHao)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from GongKaiXinXi ");
            strSql.Append(" where BianHao=@BianHao");
            SqlParameter[] parameters = {
                    new SqlParameter("@BianHao", SqlDbType.Int,4)
            };
            parameters[0].Value = BianHao;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string BiaoTi, DateTime FaBuShiJian, string FaBuDanWei, int BianHao)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from GongKaiXinXi ");
            strSql.Append(" where BiaoTi=@BiaoTi and FaBuShiJian=@FaBuShiJian and FaBuDanWei=@FaBuDanWei and BianHao=@BianHao ");
            SqlParameter[] parameters = {
                    new SqlParameter("@BiaoTi", SqlDbType.NVarChar,30),
                    new SqlParameter("@FaBuShiJian", SqlDbType.DateTime),
                    new SqlParameter("@FaBuDanWei", SqlDbType.NVarChar,20),
                    new SqlParameter("@BianHao", SqlDbType.Int,4)           };
            parameters[0].Value = BiaoTi;
            parameters[1].Value = FaBuShiJian;
            parameters[2].Value = FaBuDanWei;
            parameters[3].Value = BianHao;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string BianHaolist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from GongKaiXinXi ");
            strSql.Append(" where BianHao in (" + BianHaolist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SDAU.ZHCZ.Model.GongKaiXinXi GetModel(int BianHao)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BianHao,BiaoTi,NeiRong,TuPian,LeiXing,FaBuShiJian,FaBuDanWei,ZuoZe,LiuLanCiShu,BeiZhu from GongKaiXinXi ");
            strSql.Append(" where BianHao=@BianHao");
            SqlParameter[] parameters = {
                    new SqlParameter("@BianHao", SqlDbType.Int,4)
            };
            parameters[0].Value = BianHao;

            Model.GongKaiXinXi model = new SDAU.ZHCZ.Model.GongKaiXinXi();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SDAU.ZHCZ.Model.GongKaiXinXi DataRowToModel(DataRow row)
        {
            SDAU.ZHCZ.Model.GongKaiXinXi model = new SDAU.ZHCZ.Model.GongKaiXinXi();
            if (row != null)
            {
                if (row["BianHao"] != null && row["BianHao"].ToString() != "")
                {
                    model.BianHao = int.Parse(row["BianHao"].ToString());
                }
                if (row["BiaoTi"] != null)
                {
                    model.BiaoTi = row["BiaoTi"].ToString();
                }
                if (row["NeiRong"] != null)
                {
                    model.NeiRong = row["NeiRong"].ToString();
                }
                if (row["TuPian"] != null && row["TuPian"].ToString() != "")
                {
                    model.TuPian = (byte[])row["TuPian"];
                }
                if (row["LeiXing"] != null)
                {
                    model.LeiXing = row["LeiXing"].ToString();
                }
                if (row["FaBuShiJian"] != null && row["FaBuShiJian"].ToString() != "")
                {
                    model.FaBuShiJian = DateTime.Parse(row["FaBuShiJian"].ToString());
                }
                if (row["FaBuDanWei"] != null)
                {
                    model.FaBuDanWei = row["FaBuDanWei"].ToString();
                }
                if (row["ZuoZe"] != null)
                {
                    model.ZuoZe = row["ZuoZe"].ToString();
                }
                if (row["LiuLanCiShu"] != null && row["LiuLanCiShu"].ToString() != "")
                {
                    model.LiuLanCiShu = int.Parse(row["LiuLanCiShu"].ToString());
                }
                if (row["BeiZhu"] != null)
                {
                    model.BeiZhu = row["BeiZhu"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BianHao,BiaoTi,NeiRong,TuPian,LeiXing,FaBuShiJian,FaBuDanWei,ZuoZe,LiuLanCiShu,BeiZhu ");
            strSql.Append(" FROM GongKaiXinXi  order by FaBuShiJian desc");

    
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        //aspx/GetInfoId所调用的函数
        public DataSet GetList1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BianHao,BiaoTi,NeiRong,TuPian,LeiXing,FaBuShiJian,FaBuDanWei,ZuoZe,LiuLanCiShu,BeiZhu ");
            strSql.Append(" FROM GongKaiXinXi ");


            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" BianHao,BiaoTi,NeiRong,TuPian,LeiXing,FaBuShiJian,FaBuDanWei,ZuoZe,LiuLanCiShu,BeiZhu ");
            strSql.Append(" FROM GongKaiXinXi ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            //strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM GongKaiXinXi ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                string strtype = strWhere.Split('|')[0];
                string strdate = strWhere.Split('|')[1];
                switch (strtype)
                {
                    case "标题": strtype = "BiaoTi"; break;
                    case "发布人": strtype = "ZuoZe"; break;
                    case "类型": strtype = "LeiXing"; break;
                }
                strSql.Append(" where " + strtype + " like '%" + strdate + "%' ");
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }



        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.FaBuShiJian desc");
            }
            strSql.Append(")AS Row, T.*  from GongKaiXinXi T ");

            //At least one query condition  StrWhere!=null
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                string firsttype = strWhere.Split('|')[0];
                string secondtype = strWhere.Split('|')[1];
               switch(firsttype)
                {
                    case "标题":firsttype = "BiaoTi";break;
                    case "发布人": firsttype = "ZuoZe"; break;
                    case "类型": firsttype = "LeiXing"; break;
                }
              
                strSql.Append(" where "+firsttype+" like '%"+secondtype+"%' ");
                strSql.Append(" ) TT");
                strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
                return DbHelperSQL.Query(strSql.ToString());
            }         
            else   //strWhere==null Query all data
            {
                strSql.Append(" ) TT");
                strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
                return DbHelperSQL.Query(strSql.ToString());
            }
			
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "GongKaiXinXi";
			parameters[1].Value = "BianHao";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

