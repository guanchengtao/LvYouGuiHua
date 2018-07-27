using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace SDAU.ZHCZ.DAL
{
	/// <summary>
	/// 数据访问类:YouQingLianJie
	/// </summary>
	public partial class YouQingLianJie
	{
		public YouQingLianJie()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("BianHao", "YouQingLianJie"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int BianHao)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from YouQingLianJie");
			strSql.Append(" where BianHao=@BianHao");
			SqlParameter[] parameters = {
					new SqlParameter("@BianHao", SqlDbType.Int,4)
			};
			parameters[0].Value = BianHao;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SDAU.ZHCZ.Model.YouQingLianJie model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into YouQingLianJie(");
			strSql.Append("WZMingCheng,DiZhi)");
			strSql.Append(" values (");
			strSql.Append("@WZMingCheng,@DiZhi)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@WZMingCheng", SqlDbType.NVarChar,20),
					new SqlParameter("@DiZhi", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.WZMingCheng;
			parameters[1].Value = model.DiZhi;

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
		public bool Update(SDAU.ZHCZ.Model.YouQingLianJie model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update YouQingLianJie set ");
			strSql.Append("WZMingCheng=@WZMingCheng,");
			strSql.Append("DiZhi=@DiZhi");
			strSql.Append(" where BianHao=@BianHao");
			SqlParameter[] parameters = {
					new SqlParameter("@WZMingCheng", SqlDbType.NVarChar,20),
					new SqlParameter("@DiZhi", SqlDbType.NVarChar,30),
					new SqlParameter("@BianHao", SqlDbType.Int,4)};
			parameters[0].Value = model.WZMingCheng;
			parameters[1].Value = model.DiZhi;
			parameters[2].Value = model.BianHao;

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
			strSql.Append("delete from YouQingLianJie ");
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string BianHaolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from YouQingLianJie ");
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
		public SDAU.ZHCZ.Model.YouQingLianJie GetModel(int BianHao)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 BianHao,WZMingCheng,DiZhi from YouQingLianJie ");
			strSql.Append(" where BianHao=@BianHao");
			SqlParameter[] parameters = {
					new SqlParameter("@BianHao", SqlDbType.Int,4)
			};
			parameters[0].Value = BianHao;

			SDAU.ZHCZ.Model.YouQingLianJie model=new SDAU.ZHCZ.Model.YouQingLianJie();
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
		public SDAU.ZHCZ.Model.YouQingLianJie DataRowToModel(DataRow row)
		{
			SDAU.ZHCZ.Model.YouQingLianJie model=new SDAU.ZHCZ.Model.YouQingLianJie();
			if (row != null)
			{
				if(row["BianHao"]!=null && row["BianHao"].ToString()!="")
				{
					model.BianHao=int.Parse(row["BianHao"].ToString());
				}
				if(row["WZMingCheng"]!=null)
				{
					model.WZMingCheng=row["WZMingCheng"].ToString();
				}
				if(row["DiZhi"]!=null)
				{
					model.DiZhi=row["DiZhi"].ToString();
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
			strSql.Append("select BianHao,WZMingCheng,DiZhi ");
			strSql.Append(" FROM YouQingLianJie ");
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
			strSql.Append(" BianHao,WZMingCheng,DiZhi ");
			strSql.Append(" FROM YouQingLianJie ");
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
			strSql.Append("select count(1) FROM YouQingLianJie ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			strSql.Append(")AS Row, T.*  from YouQingLianJie T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
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
			parameters[0].Value = "YouQingLianJie";
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

