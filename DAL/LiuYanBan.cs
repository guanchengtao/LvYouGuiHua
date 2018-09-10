using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace SDAU.ZHCZ.DAL
{
	/// <summary>
	/// 数据访问类:LiuYanBan
	/// </summary>
	public partial class LiuYanBan
	{
		public LiuYanBan()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("BianHao", "LiuYanBan"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string BiaoTi,int BianHao)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from LiuYanBan");
			strSql.Append(" where BiaoTi=@BiaoTi and BianHao=@BianHao ");
			SqlParameter[] parameters = {
					new SqlParameter("@BiaoTi", SqlDbType.NChar,20),
					new SqlParameter("@BianHao", SqlDbType.Int,4)			};
			parameters[0].Value = BiaoTi;
			parameters[1].Value = BianHao;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SDAU.ZHCZ.Model.LiuYanBan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into LiuYanBan(");
			strSql.Append("BiaoTi,NeiRong,LiuYanRen,EMail,DianHua,BiaoQing,LiuYanShiJian,HuiFuZhuangTai,HuiFuNeiRong,HuiFuShiJian,HuiFuRen,BeiZhu)");
			strSql.Append(" values (");
			strSql.Append("@BiaoTi,@NeiRong,@LiuYanRen,@EMail,@DianHua,@BiaoQing,@LiuYanShiJian,@HuiFuZhuangTai,@HuiFuNeiRong,@HuiFuShiJian,@HuiFuRen,@BeiZhu)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BiaoTi", SqlDbType.NChar,20),
					new SqlParameter("@NeiRong", SqlDbType.NVarChar,1000),
					new SqlParameter("@LiuYanRen", SqlDbType.NVarChar,12),
					new SqlParameter("@EMail", SqlDbType.NVarChar,20),
					new SqlParameter("@DianHua", SqlDbType.NVarChar,12),
					new SqlParameter("@BiaoQing", SqlDbType.VarBinary,-1),
					new SqlParameter("@LiuYanShiJian", SqlDbType.DateTime),
					new SqlParameter("@HuiFuZhuangTai", SqlDbType.NVarChar,10),
					new SqlParameter("@HuiFuNeiRong", SqlDbType.NVarChar,200),
					new SqlParameter("@HuiFuShiJian", SqlDbType.DateTime),
					new SqlParameter("@HuiFuRen", SqlDbType.NVarChar,12),
					new SqlParameter("@BeiZhu", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.BiaoTi;
			parameters[1].Value = model.NeiRong;
			parameters[2].Value = model.LiuYanRen;
			parameters[3].Value = model.EMail;
			parameters[4].Value = model.DianHua;
			parameters[5].Value = model.BiaoQing;
			parameters[6].Value = model.LiuYanShiJian;
			parameters[7].Value = model.HuiFuZhuangTai;
			parameters[8].Value = model.HuiFuNeiRong;
			parameters[9].Value = model.HuiFuShiJian;
			parameters[10].Value = model.HuiFuRen;
			parameters[11].Value = model.BeiZhu;

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
		public bool Update(SDAU.ZHCZ.Model.LiuYanBan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update LiuYanBan set ");
			strSql.Append("NeiRong=@NeiRong,");
			strSql.Append("LiuYanRen=@LiuYanRen,");
			strSql.Append("EMail=@EMail,");
			strSql.Append("DianHua=@DianHua,");
			strSql.Append("BiaoQing=@BiaoQing,");
			strSql.Append("LiuYanShiJian=@LiuYanShiJian,");
			strSql.Append("HuiFuZhuangTai=@HuiFuZhuangTai,");
			strSql.Append("HuiFuNeiRong=@HuiFuNeiRong,");
			strSql.Append("HuiFuShiJian=@HuiFuShiJian,");
			strSql.Append("HuiFuRen=@HuiFuRen,");
			strSql.Append("BeiZhu=@BeiZhu");
			strSql.Append(" where BianHao=@BianHao");
			SqlParameter[] parameters = {
					new SqlParameter("@NeiRong", SqlDbType.NVarChar,1000),
					new SqlParameter("@LiuYanRen", SqlDbType.NVarChar,12),
					new SqlParameter("@EMail", SqlDbType.NVarChar,20),
					new SqlParameter("@DianHua", SqlDbType.NVarChar,12),
					new SqlParameter("@BiaoQing", SqlDbType.VarBinary,-1),
					new SqlParameter("@LiuYanShiJian", SqlDbType.DateTime),
					new SqlParameter("@HuiFuZhuangTai", SqlDbType.NVarChar,10),
					new SqlParameter("@HuiFuNeiRong", SqlDbType.NVarChar,200),
					new SqlParameter("@HuiFuShiJian", SqlDbType.DateTime),
					new SqlParameter("@HuiFuRen", SqlDbType.NVarChar,12),
					new SqlParameter("@BeiZhu", SqlDbType.NVarChar,200),
					new SqlParameter("@BianHao", SqlDbType.Int,4),
					new SqlParameter("@BiaoTi", SqlDbType.NChar,20)};
			parameters[0].Value = model.NeiRong;
			parameters[1].Value = model.LiuYanRen;
			parameters[2].Value = model.EMail;
			parameters[3].Value = model.DianHua;
			parameters[4].Value = model.BiaoQing;
			parameters[5].Value = model.LiuYanShiJian;
			parameters[6].Value = model.HuiFuZhuangTai;
			parameters[7].Value = model.HuiFuNeiRong;
			parameters[8].Value = model.HuiFuShiJian;
			parameters[9].Value = model.HuiFuRen;
			parameters[10].Value = model.BeiZhu;
			parameters[11].Value = model.BianHao;
			parameters[12].Value = model.BiaoTi;

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
		public bool Delete(int BianHao)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LiuYanBan ");
			strSql.Append(" where BianHao=@BianHao");
			SqlParameter[] parameters = {
					new SqlParameter("@BianHao", SqlDbType.Int,4)
			};
			parameters[0].Value = BianHao;

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
		public bool Delete(string BiaoTi)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LiuYanBan ");
			strSql.Append(" where BiaoTi=@BiaoTi ");
			SqlParameter[] parameters = {
					new SqlParameter("@BiaoTi", SqlDbType.NChar,20)	};
			parameters[0].Value = BiaoTi;

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
		public bool DeleteList(string BianHaolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LiuYanBan ");
			strSql.Append(" where BianHao in ("+BianHaolist + ")  ");
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
		public SDAU.ZHCZ.Model.LiuYanBan GetModel(int BianHao)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 BianHao,BiaoTi,NeiRong,LiuYanRen,EMail,DianHua,BiaoQing,LiuYanShiJian,HuiFuZhuangTai,HuiFuNeiRong,HuiFuShiJian,HuiFuRen,BeiZhu from LiuYanBan ");
			strSql.Append(" where BianHao=@BianHao");
			SqlParameter[] parameters = {
					new SqlParameter("@BianHao", SqlDbType.Int,4)
			};
			parameters[0].Value = BianHao;

			SDAU.ZHCZ.Model.LiuYanBan model=new SDAU.ZHCZ.Model.LiuYanBan();
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
		public SDAU.ZHCZ.Model.LiuYanBan DataRowToModel(DataRow row)
		{
			SDAU.ZHCZ.Model.LiuYanBan model=new SDAU.ZHCZ.Model.LiuYanBan();
			if (row != null)
			{
				if(row["BianHao"]!=null && row["BianHao"].ToString()!="")
				{
					model.BianHao=int.Parse(row["BianHao"].ToString());
				}
				if(row["BiaoTi"]!=null)
				{
					model.BiaoTi=row["BiaoTi"].ToString();
				}
				if(row["NeiRong"]!=null)
				{
					model.NeiRong=row["NeiRong"].ToString();
				}
				if(row["LiuYanRen"]!=null)
				{
					model.LiuYanRen=row["LiuYanRen"].ToString();
				}
				if(row["EMail"]!=null)
				{
					model.EMail=row["EMail"].ToString();
				}
				if(row["DianHua"]!=null)
				{
					model.DianHua=row["DianHua"].ToString();
				}
				if(row["BiaoQing"]!=null && row["BiaoQing"].ToString()!="")
				{
					model.BiaoQing=(byte[])row["BiaoQing"];
				}
				if(row["LiuYanShiJian"]!=null && row["LiuYanShiJian"].ToString()!="")
				{
					model.LiuYanShiJian=DateTime.Parse(row["LiuYanShiJian"].ToString());
				}
				if(row["HuiFuZhuangTai"]!=null)
				{
					model.HuiFuZhuangTai=row["HuiFuZhuangTai"].ToString();
				}
				if(row["HuiFuNeiRong"]!=null)
				{
					model.HuiFuNeiRong=row["HuiFuNeiRong"].ToString();
				}
				if(row["HuiFuShiJian"]!=null && row["HuiFuShiJian"].ToString()!="")
				{
					model.HuiFuShiJian=DateTime.Parse(row["HuiFuShiJian"].ToString());
				}
				if(row["HuiFuRen"]!=null)
				{
					model.HuiFuRen=row["HuiFuRen"].ToString();
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
			strSql.Append("select BianHao,BiaoTi,NeiRong,LiuYanRen,EMail,DianHua,BiaoQing,LiuYanShiJian,HuiFuZhuangTai,HuiFuNeiRong,HuiFuShiJian,HuiFuRen,BeiZhu ");
			strSql.Append(" FROM LiuYanBan order by LiuYanShiJian desc ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			strSql.Append(" BianHao,BiaoTi,NeiRong,LiuYanRen,EMail,DianHua,BiaoQing,LiuYanShiJian,HuiFuZhuangTai,HuiFuNeiRong,HuiFuShiJian,HuiFuRen,BeiZhu ");
			strSql.Append(" FROM LiuYanBan ");
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
			strSql.Append("select count(1) FROM LiuYanBan ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                string strdate = strWhere;
           
                strSql.Append(" where HuiFuZhuangTai='"+strdate+"'");
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
				strSql.Append("order by T.BianHao desc");
			}
			strSql.Append(")AS Row, T.*  from LiuYanBan T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                //strSql.Append(" where NeiRong like '%" + strWhere + "%' ");
                strSql.Append(" where HuiFuZhuangTai='" + strWhere + "'");

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
			parameters[0].Value = "LiuYanBan";
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

