using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace SDAU.ZHCZ.DAL
{
	/// <summary>
	/// 数据访问类:LvYouGuiHuaXinXi
	/// </summary>
	public partial class LvYouGuiHuaXinXi
	{
		public LvYouGuiHuaXinXi()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string GHXMBianHao)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from LvYouGuiHuaXinXi");
			strSql.Append(" where GHXMBianHao=@GHXMBianHao  ");
			SqlParameter[] parameters = {
					new SqlParameter("@GHXMBianHao", SqlDbType.NChar,12)			};
			parameters[0].Value = GHXMBianHao;
			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(SDAU.ZHCZ.Model.LvYouGuiHuaXinXi model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into LvYouGuiHuaXinXi(");
			strSql.Append("GHXMBianHao,GHXMMingCheng,   GHXMJieShao,GuiHuaFanWei,GuiHuaMianJi,GuiHuaNianXian,GuiHuaMuBiao,GuiHuaRenWu,GuiHuaTu,GuiHuaShiJian,GuiHuaDanWei,FuZeRen,BeiZhu)");
			strSql.Append(" values (");
			strSql.Append("@GHXMBianHao,@GHXMMingCheng,@GHXMJieShao,@GuiHuaFanWei,@GuiHuaMianJi,@GuiHuaNianXian,@GuiHuaMuBiao,@GuiHuaRenWu,@GuiHuaTu,@GuiHuaShiJian,@GuiHuaDanWei,@FuZeRen,@BeiZhu)");
			SqlParameter[] parameters = {
					new SqlParameter("@GHXMBianHao", SqlDbType.NChar,12),
					new SqlParameter("@GHXMMingCheng", SqlDbType.NVarChar,50),
					new SqlParameter("@GHXMJieShao", SqlDbType.NVarChar,500),
					new SqlParameter("@GuiHuaFanWei", SqlDbType.NVarChar,50),
					new SqlParameter("@GuiHuaMianJi", SqlDbType.NVarChar,20),
					new SqlParameter("@GuiHuaNianXian", SqlDbType.NVarChar,50),
					new SqlParameter("@GuiHuaMuBiao", SqlDbType.NVarChar,300),
					new SqlParameter("@GuiHuaRenWu", SqlDbType.NVarChar,300),
                    new SqlParameter("@GuiHuaTu", SqlDbType.NVarChar,1000),
					new SqlParameter("@GuiHuaShiJian", SqlDbType.DateTime),
					new SqlParameter("@GuiHuaDanWei", SqlDbType.NVarChar,20),
					new SqlParameter("@FuZeRen", SqlDbType.NVarChar,20),
					new SqlParameter("@BeiZhu", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.GHXMBianHao;
			parameters[1].Value = model.GHXMMingCheng;
			parameters[2].Value = model.GHXMJieShao;
			parameters[3].Value = model.GuiHuaFanWei;
			parameters[4].Value = model.GuiHuaMianJi;
			parameters[5].Value = model.GuiHuaNianXian;
			parameters[6].Value = model.GuiHuaMuBiao;
			parameters[7].Value = model.GuiHuaRenWu;
			parameters[8].Value = model.GuiHuaTu;
			parameters[9].Value = model.GuiHuaShiJian;
			parameters[10].Value = model.GuiHuaDanWei;
			parameters[11].Value = model.FuZeRen;
			parameters[12].Value = model.BeiZhu;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(SDAU.ZHCZ.Model.LvYouGuiHuaXinXi model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update LvYouGuiHuaXinXi set ");
			strSql.Append("GHXMJieShao=@GHXMJieShao,");
			strSql.Append("GuiHuaFanWei=@GuiHuaFanWei,");
			strSql.Append("GuiHuaMianJi=@GuiHuaMianJi,");
			strSql.Append("GuiHuaNianXian=@GuiHuaNianXian,");
			strSql.Append("GuiHuaMuBiao=@GuiHuaMuBiao,");
			strSql.Append("GuiHuaRenWu=@GuiHuaRenWu,");
			strSql.Append("GuiHuaTu=@GuiHuaTu,");
			strSql.Append("FuZeRen=@FuZeRen,");
            strSql.Append("GuiHuaDanWei=@GuiHuaDanWei,");
            strSql.Append("GHXMMingCheng=@GHXMMingCheng,");
            strSql.Append("GuiHuaShiJian=@GuiHuaShiJian,");
            strSql.Append("BeiZhu=@BeiZhu");
            strSql.Append(" where GHXMBianHao=@GHXMBianHao ");
			SqlParameter[] parameters = {
					new SqlParameter("@GHXMJieShao", SqlDbType.NVarChar,500),
					new SqlParameter("@GuiHuaFanWei", SqlDbType.NVarChar,50),
					new SqlParameter("@GuiHuaMianJi", SqlDbType.NVarChar,20),
					new SqlParameter("@GuiHuaNianXian", SqlDbType.NVarChar,50),
					new SqlParameter("@GuiHuaMuBiao", SqlDbType.NVarChar,300),
					new SqlParameter("@GuiHuaRenWu", SqlDbType.NVarChar,300),
                    new SqlParameter("@GuiHuaTu", SqlDbType.NVarChar,1000),
					new SqlParameter("@FuZeRen", SqlDbType.NVarChar,20),            
                    new SqlParameter("@GHXMBianHao", SqlDbType.NChar,12),
					new SqlParameter("@GHXMMingCheng", SqlDbType.NVarChar,50),
					new SqlParameter("@GuiHuaShiJian", SqlDbType.DateTime),
					new SqlParameter("@GuiHuaDanWei", SqlDbType.NVarChar,20),
					new SqlParameter("@BeiZhu", SqlDbType.NVarChar,200),};
			parameters[0].Value = model.GHXMJieShao;
			parameters[1].Value = model.GuiHuaFanWei;
			parameters[2].Value = model.GuiHuaMianJi;
			parameters[3].Value = model.GuiHuaNianXian;
			parameters[4].Value = model.GuiHuaMuBiao;
			parameters[5].Value = model.GuiHuaRenWu;
			parameters[6].Value = model.GuiHuaTu;
			parameters[7].Value = model.FuZeRen;
			parameters[8].Value = model.GHXMBianHao;
			parameters[9].Value = model.GHXMMingCheng;
			parameters[10].Value = model.GuiHuaShiJian;
			parameters[11].Value = model.GuiHuaDanWei;
			parameters[12].Value = model.BeiZhu;


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
		public bool Delete(string GHXMBianHao)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LvYouGuiHuaXinXi ");
			strSql.Append(" where GHXMBianHao=@GHXMBianHao ");
			SqlParameter[] parameters = {
					new SqlParameter("@GHXMBianHao", SqlDbType.NChar,12)
								};
			parameters[0].Value = GHXMBianHao;
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
        /// <param name="BianHaolist"></param>
        /// <returns></returns>
        public bool DeleteList(string BianHaolist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LvYouGuiHuaXinXi ");
            strSql.Append(" where GHXMBianHao in (" + BianHaolist + ")  ");
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
        public SDAU.ZHCZ.Model.LvYouGuiHuaXinXi GetModel(string GHXMBianHao)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from LvYouGuiHuaXinXi ");
			strSql.Append(" where GHXMBianHao=@GHXMBianHao ");
			SqlParameter[] parameters = {
					new SqlParameter("@GHXMBianHao", SqlDbType.NChar,12)	};
			parameters[0].Value = GHXMBianHao;
            Model.LvYouGuiHuaXinXi model=new Model.LvYouGuiHuaXinXi();
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
		public SDAU.ZHCZ.Model.LvYouGuiHuaXinXi DataRowToModel(DataRow row)
		{
			SDAU.ZHCZ.Model.LvYouGuiHuaXinXi model=new SDAU.ZHCZ.Model.LvYouGuiHuaXinXi();
			if (row != null)
			{
				if(row["GHXMBianHao"]!=null)
				{
					model.GHXMBianHao=row["GHXMBianHao"].ToString();
				}
				if(row["GHXMMingCheng"]!=null)
				{
					model.GHXMMingCheng=row["GHXMMingCheng"].ToString();
				}
				if(row["GHXMJieShao"]!=null)
				{
					model.GHXMJieShao=row["GHXMJieShao"].ToString();
				}
				if(row["GuiHuaFanWei"]!=null)
				{
					model.GuiHuaFanWei=row["GuiHuaFanWei"].ToString();
				}
				if(row["GuiHuaMianJi"]!=null)
				{
					model.GuiHuaMianJi=row["GuiHuaMianJi"].ToString();
				}
				if(row["GuiHuaNianXian"]!=null)
				{
					model.GuiHuaNianXian=row["GuiHuaNianXian"].ToString();
				}
				if(row["GuiHuaMuBiao"]!=null)
				{
					model.GuiHuaMuBiao=row["GuiHuaMuBiao"].ToString();
				}
				if(row["GuiHuaRenWu"]!=null)
				{
					model.GuiHuaRenWu=row["GuiHuaRenWu"].ToString();
				}
				if(row["GuiHuaTu"]!=null && row["GuiHuaTu"].ToString()!="")
				{
                    model.GuiHuaTu = row["GuiHuaTu"].ToString();
                }
				if(row["GuiHuaShiJian"]!=null && row["GuiHuaShiJian"].ToString()!="")
				{
					model.GuiHuaShiJian=DateTime.Parse(row["GuiHuaShiJian"].ToString());
				}
				if(row["GuiHuaDanWei"]!=null)
				{
					model.GuiHuaDanWei=row["GuiHuaDanWei"].ToString();
				}
				if(row["FuZeRen"]!=null)
				{
					model.FuZeRen=row["FuZeRen"].ToString();
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
			strSql.Append("select GHXMBianHao,GHXMMingCheng,GHXMJieShao,GuiHuaFanWei,GuiHuaMianJi,GuiHuaNianXian,GuiHuaMuBiao,GuiHuaRenWu,GuiHuaTu,GuiHuaShiJian,GuiHuaDanWei,FuZeRen,BeiZhu ");
			strSql.Append(" FROM LvYouGuiHuaXinXi ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        public DataSet GetList1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select GHXMBianHao,GHXMMingCheng,GHXMJieShao,GuiHuaFanWei,GuiHuaMianJi,GuiHuaNianXian,GuiHuaMuBiao,GuiHuaRenWu,GuiHuaTu,GuiHuaShiJian,GuiHuaDanWei,FuZeRen,BeiZhu ");
            strSql.Append(" FROM LvYouGuiHuaXinXi order by BeiZhu asc ");
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
			strSql.Append(" GHXMBianHao,GHXMMingCheng,GHXMJieShao,GuiHuaFanWei,GuiHuaMianJi,GuiHuaNianXian,GuiHuaMuBiao,GuiHuaRenWu,GuiHuaTu,GuiHuaShiJian,GuiHuaDanWei,FuZeRen,BeiZhu ");
			strSql.Append(" FROM LvYouGuiHuaXinXi ");
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
			strSql.Append("select count(1) FROM LvYouGuiHuaXinXi ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                string strtype = strWhere.Split('|')[0];
                string strdate = strWhere.Split('|')[1];
                switch (strtype)
                {
                    case "项目编号": strtype = "GHXMBianHao"; break;
                    case "项目名称": strtype = "GHXMMingCheng"; break;
                    case "负责人": strtype = "FuZeRen"; break;
                    case "规划单位": strtype = "GuiHuaDanWei"; break;
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
				strSql.Append("order by T.BeiZhu desc");
			}
			strSql.Append(")AS Row, T.*  from LvYouGuiHuaXinXi T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                string firsttype = strWhere.Split('|')[0];
                string secondtype = strWhere.Split('|')[1];
                switch (firsttype)
                {
                    case "项目编号": firsttype = "GHXMBianHao"; break;
                    case "项目名称": firsttype = "GHXMMingCheng"; break;
                    case "负责人": firsttype = "FuZeRen"; break;
                    case "规划单位": firsttype = "GuiHuaDanWei"; break;
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
			parameters[0].Value = "LvYouGuiHuaXinXi";
			parameters[1].Value = "BeiZhu";
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

