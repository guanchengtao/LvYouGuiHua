using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDAU.ZHCZ.Web.Admin.aspx
{
    public partial class VerifyCode : Page
    {
        public static string HZ;
        /// <summary>
        /// 验证码的最大长度
        /// </summary>
        public int MaxLength
        {
            get { return 10; }

        }
        /// <summary>
        /// 验证码的最小长度
        /// </summary>
        public int MinLength
        {
            get { return 1; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] str = CreateValidateNumber(4);
            string strcode = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                strcode += str[i];

            }
            CreateCheckCodeImage(str);
            HZ = strcode;
            Session["ValidateCode"] = HZ;
            Response.Write(HZ);
            //验证码存入session
  
        }
        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="length">指定验证码的长度</param>
        /// <returns>验证码</returns>
        public string[] CreateValidateNumber(int length)

        {
            //string Vchar = "1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,p" +
            string Vchar = "0,1,2,3,4,5,6,7,8,9";
            //",q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,P,Q" +
            //",R,S,T,U,V,W,X,Y,Z";

            string[] VcArray = Vchar.Split(new Char[] { ',' });//拆分成数组
            string[] num = new string[length];

            int temp = -1;//记录上次随机数值，尽量避避免生产几个一样的随机数

            Random rand = new Random();

            //采用一个简单的算法以保证生成随机数的不同

            for (int i = 1; i < length + 1; i++)

            {

                if (temp != -1)

                {

                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));

                }
                int t = rand.Next(VcArray.Length - 1);
                if (temp != -1 && temp == t)
                {
                    return CreateValidateNumber(length);



                }

                temp = t;
                num[i - 1] = VcArray[t];
                //num.SetValue(VcArray[t]);
                //VNum += VcArray[t];

            }
            return num;
        }

        private void CreateCheckCodeImage(string[] checkCode)
        {
            if (checkCode == null || checkCode.Length <= 0)
                return;
            System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 32.5)), 60);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器

                Random random = new Random();

                //清空图片背景色

                g.Clear(Color.White);

                //定义颜色

                Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };

                //画图片的背景噪音线
                for (int i = 0; i < 25; i++)

                {
                    int cindex = random.Next(7);
                    int findex = random.Next(5);
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);

                    // g.DrawLine(new Pen(c[cindex]), x1, y1, x2, y2);
                }
                //定义字体
                string[] f = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };

                for (int k = 0; k <= checkCode.Length - 1; k++)
                {
                    int cindex = random.Next(7);
                    int findex = random.Next(5);
                    Font drawFont = new Font(f[findex], 26, (System.Drawing.FontStyle.Bold));
                    SolidBrush drawBrush = new SolidBrush(c[cindex]);
                    float x = 5.0F;
                    float y = 0.0F;
                    float width = 42.0F;
                    float height = 48.0F;
                    int sjx = random.Next(10);
                    int sjy = random.Next(image.Height - (int)height);

                    RectangleF drawRect = new RectangleF(x + sjx + (k * 25), y + sjy, width, height);
                    StringFormat drawFormat = new StringFormat();
                    drawFormat.Alignment = StringAlignment.Center;
                    g.DrawString(checkCode[k], drawFont, drawBrush, drawRect, drawFormat);
                }
                //画图片的前景噪音点
                for (int i = 0; i < 500; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);

                    image.SetPixel(x, y, Color.FromArgb(random.Next()));

                }

                int cindex1 = random.Next(7);

                //画图片的边框线

                g.DrawRectangle(new Pen(c[cindex1]), 0, 0, image.Width - 1, image.Height - 1);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                Response.ClearContent();
                Response.ContentType = "image/Gif";
                Response.BinaryWrite(ms.ToArray());

            }

            finally

            {

                g.Dispose();

                image.Dispose();

            }

        }

    }

}