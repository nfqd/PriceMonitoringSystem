using System;

namespace PriceMonitoringSystem
{
    class JM
    {
        /// <summary>
        /// 字符转换ASCII码
        /// </summary>
        /// <param name="character">字符</param>
        /// <returns></returns>
        public static int Asc(string character)
        {
            if (character.Length == 1)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                int intAsciiCode = (int)asciiEncoding.GetBytes(character)[0];
                return (intAsciiCode);
            }
            else
            {
                throw new Exception("Character is not valid.");
            }
        }
        /// <summary>
        /// 将ASCII码转换成字符
        /// </summary>
        /// <param name="asciiCode">ASCII码</param>
        /// <returns></returns>
        public static string Chr(int asciiCode)
        {
            if (asciiCode >= 0 && asciiCode <= 255)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                byte[] byteArray = new byte[] { (byte)asciiCode };
                string strCharacter = asciiEncoding.GetString(byteArray);
                return (strCharacter);
            }
            else
            {
                throw new Exception("ASCII Code is not valid.");
            }
        }

        /// <summary>
        /// 加密算法
        /// </summary>
        /// <param name="as_s">明文</param>
        /// <returns>密文</returns>
        public static string Encryption(string as_s)
        {
            string ls_rst = "";    //返回结果
            string ls_asc;         //明文按字符（单字节）的ascii码
            string ls_asc_1;       //ls_asc的按字符（单字节）加1
            string ls_asc_rnt;     //ls_asc_1的按字符（单字节）倒排序
            string ls_asc_rnt_1;   //ls_asc_rnt的按字符（单字节）加1
            string ls_asc_segment; //ls_asc_rnt_1的按3字符（单字节）分段
            string ls_hex_segment; //ls_asc_segment的十六进制
            string ls_fmt;         //单字节字符的ascii码转换成字符串的格式
            string ls_separator;   //段与段的分隔符
            long ll_l_segment;   //一段所含的明文字符个数
            long ll_l_asc_s;     //一段所含的密文的字符个数
            long ll_segment;     //ls_asc_segment的分段个数
            long ll_l;           //ls_asc_segment的字符个数
            long i;              //循环变量

            ls_fmt = "000";
            ls_separator = "g";
            ll_l_segment = 3;

            ll_l_asc_s = ls_fmt.Length * ll_l_segment;

            if (as_s != null || as_s != "")
            {   //明文按字符（单字节）的ascii码
                ls_asc = "";
                for (i = 0; i < as_s.Length; i++)
                {
                    ls_asc = ls_asc + Asc(as_s.Substring((int)i, 1)).ToString(ls_fmt);
                }

                //ls_asc的按字符（单字节）加1
                ls_asc_1 = "";
                for (i = 0; i < ls_asc.Length; i = i + 3)
                {
                    ls_asc_1 += (long.Parse(ls_asc.Substring((int)i, 3)) + 1).ToString(ls_fmt).Trim();
                }
                //ls_asc_1的按字符（单字节）倒排序
                ls_asc_rnt = "";
                for (i = ls_asc_1.Length - 1; i >= 0; i--)
                {
                    ls_asc_rnt += ls_asc_1.Substring((int)i, 1);
                }
                //ls_asc_rnt的按字符（单字节）加1
                ls_asc_rnt_1 = "";
                for (i = 0; i < ls_asc_rnt.Length; i = i + 3)
                {
                    ls_asc_rnt_1 += (long.Parse(ls_asc_rnt.Substring((int)i, 3)) + 1).ToString(ls_fmt);
                }
                //求段数
                ll_l = ls_asc_rnt_1.Length;

                if (ll_l % ll_l_asc_s > 0)
                {
                    ll_segment = ll_l / ll_l_asc_s + 1;
                }
                else
                {
                    ll_segment = ll_l / ll_l_asc_s;
                }
                ls_rst = "";
                for (i = 0; i < ll_segment; i++)
                {
                    if (i != ll_segment - 1)
                    {
                        if (ll_l_asc_s > ls_asc_rnt_1.Length)
                        {
                            ls_asc_segment = ls_asc_rnt_1.Substring((int)(ll_l_asc_s * i), (int)ls_asc_rnt_1.Length);
                        }
                        else
                        {
                            ls_asc_segment = ls_asc_rnt_1.Substring((int)(ll_l_asc_s * i), (int)ll_l_asc_s);
                        }
                        ls_hex_segment = Convert.ToString(long.Parse(ls_asc_segment), 16) + ls_separator;
                    }
                    else
                    {
                        if (ll_l_asc_s > ls_asc_rnt_1.Length)
                        {
                            ls_asc_segment = ls_asc_rnt_1.Substring((int)(ll_l_asc_s * i), (int)ls_asc_rnt_1.Length);
                        }
                        else
                        {
                            ls_asc_segment = ls_asc_rnt_1.Substring((int)(ll_l_asc_s * i), (int)(ls_asc_rnt_1.Length - ll_l_asc_s * i));
                        }
                        ls_hex_segment = Convert.ToString(long.Parse(ls_asc_segment), 16) + ls_separator + Convert.ToString(ls_asc_segment.Length / ls_fmt.Length).Trim();
                    }
                    ls_rst += ls_hex_segment;
                }
            }
            return ls_rst;
        }
        /// <summary>
        /// 解密算法
        /// </summary>
        /// <param name="as_s">密文</param>
        /// <returns>明文</returns>
        public static string Decryption(string as_s)
        {
            string ls_rst = "";           //返回结果
            string ls_hex_segment_r = ""; //未转换的十六进制密文
            string ls_hex_segment_l = ""; //最左边的一节十六进制密文
            string ls_asc = "";          //十进制密文
            string ls_asc_segment = ""; //十进制密文（一段）
            string ls_asc_rnt_1 = "";     //ls_asc的按字符（单字节）减1
            string ls_asc_rnt = "";       //ls_asc_rnt_1的按字符（单字节）反序
            string ls_asc_1 = "";         //ls_asc_rnt的按字符（单字节）减1
            string ls_fmt = "";           //单字节字符的ascii吗转换成字符串的格式
            string ls_separator = "";    //段与段的分隔符
            long ll_n;            //末节的字符个数
            long i;                //循环变量

            ls_fmt = "000";
            ls_separator = "g";

            if (as_s != "" && as_s != null)
            {
                ls_hex_segment_r = as_s;
                ls_asc = "";
            }

            while (true)
            {
                if (ls_hex_segment_r.IndexOf(ls_separator) > 0)
                {
                    ls_hex_segment_l = ls_hex_segment_r.Substring(0, ls_hex_segment_r.IndexOf(ls_separator));
                    ls_hex_segment_r = ls_hex_segment_r.Substring(ls_hex_segment_r.IndexOf(ls_separator) + 1, ls_hex_segment_r.Length - ls_hex_segment_r.IndexOf(ls_separator) - 1);

                    if (ls_hex_segment_r.IndexOf(ls_separator) > 0)
                    {
                        ls_asc_segment = Convert.ToInt64(ls_hex_segment_l, 16).ToString(ls_fmt + ls_fmt + ls_fmt);
                    }
                    else
                    {
                        ll_n = Convert.ToInt64(ls_hex_segment_r.Substring(ls_hex_segment_r.Length - 1, 1));
                        switch (ll_n)
                        {
                            case 3:
                                ls_asc_segment = Convert.ToInt32(ls_hex_segment_l, 16).ToString(ls_fmt + ls_fmt + ls_fmt);
                                break;
                            case 2:
                                ls_asc_segment = Convert.ToInt32(ls_hex_segment_l, 16).ToString(ls_fmt + ls_fmt);
                                break;
                            case 1:
                                ls_asc_segment = Convert.ToInt32(ls_hex_segment_l, 16).ToString(ls_fmt);
                                break;
                        }
                    }
                    ls_asc += ls_asc_segment;
                }
                else
                {
                    break;
                }
            }
            ls_asc_rnt_1 = "";
            for (i = 0; i < ls_asc.Length; i += 3)
            {
                ls_asc_rnt_1 += (Convert.ToUInt64(ls_asc.Substring((int)i, 3)) - 1).ToString(ls_fmt);
            }

            ls_asc_rnt = "";
            for (i = ls_asc_rnt_1.Length - 1; i >= 0; i--)
            {
                ls_asc_rnt += ls_asc_rnt_1.Substring((int)i, 1);
            }
            ls_asc_1 = "";
            for (i = 0; i < ls_asc_rnt.Length; i += 3)
            {
                ls_asc_1 += (Convert.ToUInt64(ls_asc_rnt.Substring((int)i, 3)) - 1).ToString(ls_fmt);
            }
            ls_rst = "";
            for (i = 0; i < ls_asc_1.Length; i += 3)
            {
                ls_rst += Chr(Convert.ToInt32(ls_asc_1.Substring((int)i, 3)));
            }
            return ls_rst;
        }
    }
}
