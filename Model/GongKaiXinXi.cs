using System;
namespace SDAU.ZHCZ.Model
{
	/// <summary>
	/// GongKaiXinXi:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class GongKaiXinXi
	{
		public GongKaiXinXi()
		{}
		#region Model
		private int _bianhao;
		private string _biaoti;
		private string _neirong;
		private byte[] _tupian;
		private string _leixing;
		private DateTime _fabushijian;
		private string _fabudanwei;
		private string _zuoze;
		private int? _liulancishu;
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
		public byte[] TuPian
		{
			set{ _tupian=value;}
			get{return _tupian;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LeiXing
		{
			set{ _leixing=value;}
			get{return _leixing;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime FaBuShiJian
		{
			set{ _fabushijian=value;}
			get{return _fabushijian;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FaBuDanWei
		{
			set{ _fabudanwei=value;}
			get{return _fabudanwei;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ZuoZe
		{
			set{ _zuoze=value;}
			get{return _zuoze;}
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
		public string BeiZhu
		{
			set{ _beizhu=value;}
			get{return _beizhu;}
		}
		#endregion Model

	}
}

