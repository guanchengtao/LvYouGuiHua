using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SDAU.ZHCZ.Common
{
    public static class GetStringMd5
    {
        public static string GetStringMD5(string msg)
        {
            using (MD5 md5 = MD5.Create())
            {

                byte[] buffer = Encoding.Default.GetBytes(msg);
                byte[] md5buffer = md5.ComputeHash(buffer);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < md5buffer.Length; i++)
                {
                    sb.Append(md5buffer[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
