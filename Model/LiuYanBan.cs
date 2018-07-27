using System;
namespace SDAU.ZHCZ.Model
{
	/// <summary>
	/// LiuYanBan:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LiuYanBan
	{
		public LiuYanBan()
		{}
		#region Model
		private int _bianhao;
		private string _biaoti;
		private string _neirong;
		private string _liuyanren;
		private string _email;
		private string _dianhua;
		private byte[] _biaoqing;
		private DateTime? _liuyanshijian;
		private string _huifuzhuangtai;
		private string _huifuneirong;
		private DateTime? _huifushijian;
		private string _huifuren;
		private string _beizhu;
		/// <summary>
		/// 
		/// </summary>
		public int BianHao
		{
			set{ _bianhao=value;}
			get{return _bianhao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BiaoTi
		{
			set{ _biaoti=value;}
			get{return _biaoti;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NeiRong
		{
			set{ _neirong=value;}
			get{return _neirong;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LiuYanRen
		{
			set{ _liuyanren=value;}
			get{return _liuyanren;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EMail
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DianHua
		{
			set{ _dianhua=value;}
			get{return _dianhua;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] BiaoQing
		{
			set{ _biaoqing=value;}
			get{return _biaoqing;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LiuYanShiJian
		{
			set{ _liuyanshijian=value;}
			get{return _liuyanshijian;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HuiFuZhuangTai
		{
			set{ _huifuzhuangtai=value;}
			get{return _huifuzhuangtai;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HuiFuNeiRong
		{
			set{ _huifuneirong=value;}
			get{return _huifuneirong;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? HuiFuShiJian
		{
			set{ _huifushijian=value;}
			get{return _huifushijian;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HuiFuRen
		{
			set{ _huifuren=value;}
			get{return _huifuren;}
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

