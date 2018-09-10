using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using SDAU.ZHCZ.Model;
namespace SDAU.ZHCZ.BLL
{
	/// <summary>
	/// LiuYanBan
	/// </summary>
	public partial class LiuYanBan
	{
		private readonly SDAU.ZHCZ.DAL.LiuYanBan dal=new SDAU.ZHCZ.DAL.LiuYanBan();
		public LiuYanBan()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string BiaoTi,int BianHao)
		{
			return dal.Exists(BiaoTi,BianHao);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(SDAU.ZHCZ.Model.LiuYanBan model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SDAU.ZHCZ.Model.LiuYanBan model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int BianHao)
		{
			
			return dal.Delete(BianHao);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string BiaoTi)
		{
			
			return dal.Delete(BiaoTi);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string BianHaolist )
		{
			return dal.DeleteList(BianHaolist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SDAU.ZHCZ.Model.LiuYanBan GetModel(int BianHao)
		{
			
			return dal.GetModel(BianHao);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public SDAU.ZHCZ.Model.LiuYanBan GetModelByCache(int BianHao)
		{
			
			string CacheKey = "LiuYanBanModel-" + BianHao;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(BianHao);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (SDAU.ZHCZ.Model.LiuYanBan)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SDAU.ZHCZ.Model.LiuYanBan> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SDAU.ZHCZ.Model.LiuYanBan> DataTableToList(DataTable dt)
		{
			List<SDAU.ZHCZ.Model.LiuYanBan> modelList = new List<SDAU.ZHCZ.Model.LiuYanBan>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SDAU.ZHCZ.Model.LiuYanBan model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

