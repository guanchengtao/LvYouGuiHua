using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using SDAU.ZHCZ.Model;
namespace SDAU.ZHCZ.BLL
{
	/// <summary>
	/// LvYouGuiHuaXinXi
	/// </summary>
	public partial class LvYouGuiHuaXinXi
	{
		private readonly SDAU.ZHCZ.DAL.LvYouGuiHuaXinXi dal=new SDAU.ZHCZ.DAL.LvYouGuiHuaXinXi();
		public LvYouGuiHuaXinXi()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string GHXMBianHao)
		{
			return dal.Exists(GHXMBianHao);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(SDAU.ZHCZ.Model.LvYouGuiHuaXinXi model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SDAU.ZHCZ.Model.LvYouGuiHuaXinXi model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string GHXMBianHao)
		{
			
			return dal.Delete(GHXMBianHao);
		}
        public bool DeleteList(string BianHaolist)
        {
            return dal.DeleteList(BianHaolist);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SDAU.ZHCZ.Model.LvYouGuiHuaXinXi GetModel(string GHXMBianHao)
		{
			
			return dal.GetModel(GHXMBianHao);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		//public SDAU.ZHCZ.Model.LvYouGuiHuaXinXi GetModelByCache(string GHXMBianHao,string GHXMMingCheng,DateTime GuiHuaShiJian,string GuiHuaDanWei,string BeiZhu)
		//{
			
		//	string CacheKey = "LvYouGuiHuaXinXiModel-" + GHXMBianHao+GHXMMingCheng+GuiHuaShiJian+GuiHuaDanWei+BeiZhu;
		//	object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
		//	if (objModel == null)
		//	{
		//		try
		//		{
		//			objModel = dal.GetModel(GHXMBianHao,GHXMMingCheng,GuiHuaShiJian,GuiHuaDanWei,BeiZhu);
		//			if (objModel != null)
		//			{
		//				int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
		//				Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
		//			}
		//		}
		//		catch{}
		//	}
		//	return (SDAU.ZHCZ.Model.LvYouGuiHuaXinXi)objModel;
		//}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        public DataSet GetList1(string strWhere)
        {
            return dal.GetList1(strWhere);
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
		public List<SDAU.ZHCZ.Model.LvYouGuiHuaXinXi> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList1(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SDAU.ZHCZ.Model.LvYouGuiHuaXinXi> DataTableToList(DataTable dt)
		{
			List<SDAU.ZHCZ.Model.LvYouGuiHuaXinXi> modelList = new List<SDAU.ZHCZ.Model.LvYouGuiHuaXinXi>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SDAU.ZHCZ.Model.LvYouGuiHuaXinXi model;
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

