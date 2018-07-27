using System;
namespace SDAU.ZHCZ.Model
{
	/// <summary>
	/// YouQingLianJie:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class YouQingLianJie
	{
		public YouQingLianJie()
		{}
		#region Model
		private int _bianhao;
		private string _wzmingcheng;
		private string _dizhi;
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
		public string WZMingCheng
		{
			set{ _wzmingcheng=value;}
			get{return _wzmingcheng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DiZhi
		{
			set{ _dizhi=value;}
			get{return _dizhi;}
		}
		#endregion Model

	}
}

