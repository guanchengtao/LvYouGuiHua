using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using SDAU.ZHCZ.Model;
namespace SDAU.ZHCZ.BLL
{
	/// <summary>
	/// GongKaiXinXi
	/// </summary>
	public partial class GongKaiXinXi
	{
		private readonly SDAU.ZHCZ.DAL.GongKaiXinXi dal=new SDAU.ZHCZ.DAL.GongKaiXinXi();
		public GongKaiXinXi()
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
		public bool Exists(string BiaoTi,DateTime FaBuShiJian,string FaBuDanWei,int BianHao)
		{
			return dal.Exists(BiaoTi,FaBuShiJian,FaBuDanWei,BianHao);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(SDAU.ZHCZ.Model.GongKaiXinXi model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SDAU.ZHCZ.Model.GongKaiXinXi model)
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
		public bool Delete(string BiaoTi,DateTime FaBuShiJian,string FaBuDanWei,int BianHao)
		{
			
			return dal.Delete(BiaoTi,FaBuShiJian,FaBuDanWei,BianHao);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string BianHaolist)
		{
			return dal.DeleteList(BianHaolist);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SDAU.ZHCZ.Model.GongKaiXinXi GetModel(int BianHao)
		{
			
			return dal.GetModel(BianHao);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public SDAU.ZHCZ.Model.GongKaiXinXi GetModelByCache(int BianHao)
		{
			
			string CacheKey = "GongKaiXinXiModel-" + BianHao;
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
			return (SDAU.ZHCZ.Model.GongKaiXinXi)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        /// <summary>
        /// 获得数据列表     //aspx/GetInfoId所调用的函数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
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
		public List<SDAU.ZHCZ.Model.GongKaiXinXi> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SDAU.ZHCZ.Model.GongKaiXinXi> DataTableToList(DataTable dt)
		{
			List<SDAU.ZHCZ.Model.GongKaiXinXi> modelList = new List<SDAU.ZHCZ.Model.GongKaiXinXi>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				SDAU.ZHCZ.Model.GongKaiXinXi model;
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
                return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);  
           
		}
        /// <summary>
        /// 分页获取数据列表2
        /// </summary>
        public List<Model.GongKaiXinXi> GetListByPage1(string strWhere, string orderby, int startIndex, int endIndex)
        {
            DataSet ds = GetListByPage(strWhere, orderby, startIndex, endIndex);
            return DataTableToList(ds.Tables[0]);
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

