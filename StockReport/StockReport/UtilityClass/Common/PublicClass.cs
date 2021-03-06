﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace UtilityClass
{
    public class PublicClass
    {
        /// <summary>
        /// 若时间是此时间，则表示时间失效
        ///   此处尽量在空数据时设置好，运行期间不宜改动。
        ///   测试发现此项经常报 Bug 原因为控件或数据库不接受此值
        /// </summary>
        public static readonly string NullTime = "1111-11-11";

        /// <summary>
        /// 默认情况下出现在treeView1 第一项
        /// </summary>
        public static readonly string SHOWALL = "显示全部";

        /// <summary>
        /// 获得一个首行为空的 DataTable
        /// </summary>
        public static DataTable GetDataTable(DataView dv, params string[] dtColumns)
        {
            DataTable dt = dv.ToTable(true, dtColumns);
            dt.Rows.InsertAt(dt.NewRow(), 0);
            return dt;
        }

        // 设置表的列标题用
        public static void SetDgvTitle(DataGridView dgvBase, string[] strTitle)
        {
            SetDgvTitle(dgvBase, strTitle, false);
        }

        public static void SetDgvTitle(DataGridView dgvBase, string[] strTitle, bool isVisible)
        {
            foreach (string str in strTitle)
            {
                string[] temp = str.Split(',');
                dgvBase.Columns[temp[0]].HeaderText = temp[1];
            }
            // 调整列宽
            dgvBase.AutoResizeColumns();
            // 隐藏英文标题
            if (!isVisible)
                foreach (DataGridViewColumn dc in dgvBase.Columns)
                    if (dc.HeaderText == dc.Name)
                        dc.Visible = false;
        }

        /// <summary>
        /// 弹窗专用
        /// </summary>
        public static void Show(IWin32Window owner, string text)
        {
            Show(owner, text, "提示");
        }

        public static void Show(IWin32Window owner, string text, string title)
        {
            MessageBox.Show(owner, text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowErr(IWin32Window owner, string text)
        {
            Show(owner, text, "提示");
        }

        public static void ShowErr(IWin32Window owner, string text, string title)
        {
            MessageBox.Show(owner, text, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool MsgBox(IWin32Window owner, string text)
        {
            return MsgBox(owner, text, "提示");
        }

        public static bool MsgBox(IWin32Window owner, string text, string title)
        {
            return MessageBox.Show(owner, text, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static object CreateObject(string frmName)
        {
            return Assembly.Load("StockReport").CreateInstance("WinForm." + frmName);
        }

        public static object CreateObject(string frmName, params object[] args)
        {
            Assembly ass = Assembly.Load("StockReport");
            Type type = ass.GetType("WinForm." + frmName);
            return Activator.CreateInstance(type, args);
        }

        /// <summary>
        /// 首行为空
        /// </summary>
        public static DataTable FirstEmpty(DataTable dt)
        {
            dt.Rows.InsertAt(dt.NewRow(), 0);
            return dt;
        }

        // 判断字符串是否为空
        public static bool IsNullOrEmpty(string str)
        {
            return string.IsNullOrEmpty(str.Replace("System.Data.DataRowView", "").Trim());
        }

        public static bool IsNullOrEmpty(object var)
        {
            if (var != null)
                return IsNullOrEmpty(var.ToString());
            return false;
        }

        // 判断字符串是否为 decimal
        public static bool IsDecimal(string str)
        {
            try
            {
                Convert.ToDecimal(str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsDecimal(object var)
        {
            if (var != null)
                return IsDecimal(var.ToString());
            return false;
        }

        // 判断字符串是否为 Int32
        public static bool IsInt32(string str)
        {
            try
            {
                Convert.ToInt32(str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsInt32(object var)
        {
            if (var != null)
                return IsInt32(var.ToString());
            return false;
        }

        public static int ToInt32(object var)
        {
            if (var != null)
                return ToInt32(var.ToString());
            return 0;
        }

        public static int ToInt32(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;
            else
            {
                try
                {
                    return Convert.ToInt32(str);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public static bool ToBoolean(object var)
        {
            if (var != null)
            {
                try
                {
                    return Convert.ToBoolean(var);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public static decimal ToDecimal(object var)
        {
            if (var != null)
                return ToDecimal(var.ToString());
            return 0;
        }

        public static decimal ToDecimal(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;
            else
            {
                try
                {
                    return Convert.ToDecimal(str);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public static double ToDouble(object var)
        {
            if (var != null)
                return ToDouble(var.ToString());
            return 0;
        }

        public static double ToDouble(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;
            else
            {
                try
                {
                    return Convert.ToDouble(str);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// .Replace("'", "''")
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        public static string ToString(object var)
        {
            if (var != null)
                return var.ToString();
            return string.Empty;
        }

        public static DateTime ToDateTime(object var)
        {
            if (var != null)
                return ToDateTime(var.ToString());
            return DateTime.Today;
        }

        public static DateTime ToDateTime(string str)
        {
            if (string.IsNullOrEmpty(str))
                return DateTime.Today;
            try
            {
                return Convert.ToDateTime(str);
            }
            catch (Exception)
            {
                return DateTime.Today;
            }
        }

        #region EnCode 加密
        const string KEY_64 = "269up9og";//注意了，是8个字符，64位 --
        const string IV_64 = "r4tupn0k";//可以和上面的不一致 但是一定要是8位

        /// <summary>
        /// MD5 加密
        /// </summary>
        /// <param name="encryptString">需加密字符</param>
        /// <returns>返回加密结果</returns>
        internal static string MD5(string encryptString)
        {
            byte[] result = Encoding.Default.GetBytes(encryptString);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");
        }

        /// <summary>
        /// EnCode 加密
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns></returns>
        internal static string EncryptDES(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }
        #endregion

        #region DecryptDES 解密
        /// <summary>
        /// DeCode 解密
        /// </summary>
        /// <param name="str">要解密的字符串</param>
        /// <returns></returns>
        internal static string DecryptDES(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);
            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return data;
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }
        #endregion

    }
}
