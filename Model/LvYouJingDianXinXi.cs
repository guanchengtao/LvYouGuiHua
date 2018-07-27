using System;
namespace SDAU.ZHCZ.Model
{
	/// <summary>
	/// LvYouJingDianXinXi:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LvYouJingDianXinXi
	{
		public LvYouJingDianXinXi()
		{}
		#region Model
		private int _jdbianhao;
		private string _jdmingcheng;
		private string _jdjieshao;
		private string _jdweizhi;
		private string _jingdu;
		private string _weidu;
		private string _tupian;
		private int? _liulancishu;
		private DateTime? _fbshijian;
		private string _beizhu;
		/// <summary>
		/// 
		/// </summary>
		public int JDBianHao
		{
			set{ _jdbianhao=value;}
			get{return _jdbianhao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JDMingCheng
		{
			set{ _jdmingcheng=value;}
			get{return _jdmingcheng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JDJieShao
		{
			set{ _jdjieshao=value;}
			get{return _jdjieshao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JDWeiZhi
		{
			set{ _jdweizhi=value;}
			get{return _jdweizhi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JingDu
		{
			set{ _jingdu=value;}
			get{return _jingdu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WeiDu
		{
			set{ _weidu=value;}
			get{return _weidu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TuPian
		{
			set{ _tupian=value;}
			get{return _tupian;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LiuLanCiShu
		{
			set{ _liulancishu=value;}
			get{return _liulancishu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? FBShiJian
		{
			set{ _fbshijian=value;}
			get{return _fbshijian;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BeiZhu
		{
			set{ _beizhu=value;}
			get{return _beizhu;}
		}
		#endregion Model

	}
}

