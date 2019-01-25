using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace BLL.Commons
{
    public static class ParseMD5
    {
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] data = md5.ComputeHash(buffer);
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
