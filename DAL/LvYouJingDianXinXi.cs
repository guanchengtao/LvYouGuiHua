using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace SDAU.ZHCZ.DAL
{
	/// <summary>
	/// 数据访问类:LvYouJingDianXinXi
	/// </summary>
	public partial class LvYouJingDianXinXi
	{
		public LvYouJingDianXinXi()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("JDBianHao", "LvYouJingDianXinXi"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string JDMingCheng,int JDBianHao)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from LvYouJingDianXinXi");
			strSql.Append(" where JDMingCheng=@JDMingCheng and JDBianHao=@JDBianHao ");
			SqlParameter[] parameters = {
					new SqlParameter("@JDMingCheng", SqlDbType.NVarChar,50),
					new SqlParameter("@JDBianHao", SqlDbType.Int,4)			};
			parameters[0].Value = JDMingCheng;
			parameters[1].Value = JDBianHao;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SDAU.ZHCZ.Model.LvYouJingDianXinXi model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into LvYouJingDianXinXi(");
			strSql.Append("JDMingCheng,JDJieShao,JDWeiZhi,JingDu,WeiDu,TuPian,LiuLanCiShu,FBShiJian,BeiZhu)");
			strSql.Append(" values (");
			strSql.Append("@JDMingCheng,@JDJieShao,@JDWeiZhi,@JingDu,@WeiDu,@TuPian,@LiuLanCiShu,@FBShiJian,@BeiZhu)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@JDMingCheng", SqlDbType.NVarChar,50),
					new SqlParameter("@JDJieShao", SqlDbType.NVarChar,3900),
					new SqlParameter("@JDWeiZhi", SqlDbType.NVarChar,50),
					new SqlParameter("@JingDu", SqlDbType.NVarChar,10),
					new SqlParameter("@WeiDu", SqlDbType.NVarChar,10),
                    new SqlParameter("@TuPian", SqlDbType.NVarChar,1000),
                    new SqlParameter("@LiuLanCiShu", SqlDbType.Int,4),
					new SqlParameter("@FBShiJian", SqlDbType.DateTime),
					new SqlParameter("@BeiZhu", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.JDMingCheng;
			parameters[1].Value = model.JDJieShao;
			parameters[2].Value = model.JDWeiZhi;
			parameters[3].Value = model.JingDu;
			parameters[4].Value = model.WeiDu;
			parameters[5].Value = model.TuPian;
			parameters[6].Value = model.LiuLanCiShu;
			parameters[7].Value = model.FBShiJian;
			parameters[8].Value = model.BeiZhu;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(SDAU.ZHCZ.Model.LvYouJingDianXinXi model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update LvYouJingDianXinXi set ");
			strSql.Append("JDJieShao=@JDJieShao,");
			strSql.Append("JDWeiZhi=@JDWeiZhi,");
			strSql.Append("JingDu=@JingDu,");
			strSql.Append("WeiDu=@WeiDu,");
			strSql.Append("TuPian=@TuPian,");
			strSql.Append("LiuLanCiShu=@LiuLanCiShu,");
			strSql.Append("FBShiJian=@FBShiJian,");
			strSql.Append("BeiZhu=@BeiZhu");
			strSql.Append(" where JDBianHao=@JDBianHao");
			SqlParameter[] parameters = {
					new SqlParameter("@JDJieShao", SqlDbType.NVarChar,3900),
					new SqlParameter("@JDWeiZhi", SqlDbType.NVarChar,50),
					new SqlParameter("@JingDu", SqlDbType.NVarChar,10),
					new SqlParameter("@WeiDu", SqlDbType.NVarChar,10),
                   new SqlParameter("@TuPian", SqlDbType.NVarChar,1000),
                    new SqlParameter("@LiuLanCiShu", SqlDbType.Int,4),
					new SqlParameter("@FBShiJian", SqlDbType.DateTime),
					new SqlParameter("@BeiZhu", SqlDbType.NVarChar,200),
					new SqlParameter("@JDBianHao", SqlDbType.Int,4),
					new SqlParameter("@JDMingCheng", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.JDJieShao;
			parameters[1].Value = model.JDWeiZhi;
			parameters[2].Value = model.JingDu;
			parameters[3].Value = model.WeiDu;
			parameters[4].Value = model.TuPian;
			parameters[5].Value = model.LiuLanCiShu;
			parameters[6].Value = model.FBShiJian;
			parameters[7].Value = model.BeiZhu;
			parameters[8].Value = model.JDBianHao;
			parameters[9].Value = model.JDMingCheng;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int JDBianHao)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LvYouJingDianXinXi ");
			strSql.Append(" where JDBianHao=@JDBianHao");
			SqlParameter[] parameters = {
					new SqlParameter("@JDBianHao", SqlDbType.Int,4)
			};
			parameters[0].Value = JDBianHao;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(string JDMingCheng,int JDBianHao)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LvYouJingDianXinXi ");
			strSql.Append(" where JDMingCheng=@JDMingCheng and JDBianHao=@JDBianHao ");
			SqlParameter[] parameters = {
					new SqlParameter("@JDMingCheng", SqlDbType.NVarChar,50),
					new SqlParameter("@JDBianHao", SqlDbType.Int,4)			};
			parameters[0].Value = JDMingCheng;
			parameters[1].Value = JDBianHao;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string JDBianHaolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LvYouJingDianXinXi ");
			strSql.Append(" where JDBianHao in ("+JDBianHaolist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public SDAU.ZHCZ.Model.LvYouJingDianXinXi GetModel(int JDBianHao)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 JDBianHao,JDMingCheng,JDJieShao,JDWeiZhi,JingDu,WeiDu,TuPian,LiuLanCiShu,FBShiJian,BeiZhu from LvYouJingDianXinXi ");
			strSql.Append(" where JDBianHao=@JDBianHao");
			SqlParameter[] parameters = {
					new SqlParameter("@JDBianHao", SqlDbType.Int,4)
			};
			parameters[0].Value = JDBianHao;

			SDAU.ZHCZ.Model.LvYouJingDianXinXi model=new SDAU.ZHCZ.Model.LvYouJingDianXinXi();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public SDAU.ZHCZ.Model.LvYouJingDianXinXi DataRowToModel(DataRow row)
		{
			SDAU.ZHCZ.Model.LvYouJingDianXinXi model=new SDAU.ZHCZ.Model.LvYouJingDianXinXi();
			if (row != null)
			{
				if(row["JDBianHao"]!=null && row["JDBianHao"].ToString()!="")
				{
					model.JDBianHao=int.Parse(row["JDBianHao"].ToString());
				}
				if(row["JDMingCheng"]!=null)
				{
					model.JDMingCheng=row["JDMingCheng"].ToString();
				}
				if(row["JDJieShao"]!=null)
				{
					model.JDJieShao=row["JDJieShao"].ToString();
				}
				if(row["JDWeiZhi"]!=null)
				{
					model.JDWeiZhi=row["JDWeiZhi"].ToString();
				}
				if(row["JingDu"]!=null)
				{
					model.JingDu=row["JingDu"].ToString();
				}
				if(row["WeiDu"]!=null)
				{
					model.WeiDu=row["WeiDu"].ToString();
				}
				if(row["TuPian"]!=null && row["TuPian"].ToString()!="")
				{
					model.TuPian=row["TuPian"].ToString();
				}
				if(row["LiuLanCiShu"]!=null && row["LiuLanCiShu"].ToString()!="")
				{
					model.LiuLanCiShu=int.Parse(row["LiuLanCiShu"].ToString());
				}
				if(row["FBShiJian"]!=null && row["FBShiJian"].ToString()!="")
				{
					model.FBShiJian=DateTime.Parse(row["FBShiJian"].ToString());
				}
				if(row["BeiZhu"]!=null)
				{
					model.BeiZhu=row["BeiZhu"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select JDBianHao,JDMingCheng,JDJieShao,JDWeiZhi,JingDu,WeiDu,TuPian,LiuLanCiShu,FBShiJian,BeiZhu ");
			strSql.Append(" FROM LvYouJingDianXinXi ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        public DataSet GetList1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select JDBianHao,JDMingCheng,JDJieShao,JDWeiZhi,JingDu,WeiDu,TuPian,LiuLanCiShu,FBShiJian,BeiZhu ");
            strSql.Append(" FROM LvYouJingDianXinXi order by FBShiJian asc  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" JDBianHao,JDMingCheng,JDJieShao,JDWeiZhi,JingDu,WeiDu,TuPian,LiuLanCiShu,FBShiJian,BeiZhu ");
			strSql.Append(" FROM LvYouJingDianXinXi ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM LvYouJingDianXinXi ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                string strtype = strWhere.Split('|')[0];
                string strdate = strWhere.Split('|')[1];
                switch (strtype)
                {
                    case "景点名称": strtype = "JDMingCheng"; break;
                    case "位置": strtype = "JDWeiZhi"; break;

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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.JDBianHao desc");
			}
			strSql.Append(")AS Row, T.*  from LvYouJingDianXinXi T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                string firsttype = strWhere.Split('|')[0];
                string secondtype = strWhere.Split('|')[1];
                switch (firsttype)
                {
                    case "景点名称": firsttype = "JDMingCheng"; break;
                    case "位置": firsttype = "JDWeiZhi"; break;
                }

                strSql.Append(" where " + firsttype + " like '%" + secondtype + "%' ");
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
			parameters[0].Value = "LvYouJingDianXinXi";
			parameters[1].Value = "JDBianHao";
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

