﻿using System.Data;
using System.IO;
using System.Text;
using System.Web;

namespace Nikita.Core
{
    /// <summary>
    /// 导出CSV格式数据
    /// </summary>
    public class BaseExportCSV
    {
        #region public static StringBuilder GetCSVFormatData(DataTable dataTable) 通过DataTable获得CSV格式数据

        /// <summary>
        /// 通过DataTable获得CSV格式数据
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>CSV字符串数据</returns>
        public static StringBuilder GetCSVFormatData(DataTable dataTable)
        {
            StringBuilder stringBuilder = new StringBuilder();
            // 写出表头
            foreach (DataColumn dataColumn in dataTable.Columns)
            {
                stringBuilder.Append(dataColumn.ColumnName + ",");
            }
            stringBuilder.Append("\n");
            // 写出数据
            foreach (DataRowView dataRowView in dataTable.DefaultView)
            {
                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    stringBuilder.Append(dataRowView[dataColumn.ColumnName] + ",");
                }
                stringBuilder.Append("\n");
            }
            return stringBuilder;
        }

        #endregion public static StringBuilder GetCSVFormatData(DataTable dataTable) 通过DataTable获得CSV格式数据

        #region public static StringBuilder GetCSVFormatData(DataSet dataSet) 通过DataSet获得CSV格式数据

        /// <summary>
        /// 通过DataSet获得CSV格式数据
        /// </summary>
        /// <param name="dataSet">数据权限</param>
        /// <returns>CSV字符串数据</returns>
        public static StringBuilder GetCSVFormatData(DataSet dataSet)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataTable dataTable in dataSet.Tables)
            {
                stringBuilder.Append(GetCSVFormatData(dataTable));
            }
            return stringBuilder;
        }

        #endregion public static StringBuilder GetCSVFormatData(DataSet dataSet) 通过DataSet获得CSV格式数据

        #region public static void ExportCSV(DataTable dataTable, string fileName) 导出CSV格式文件

        /// <summary>
        /// 导出CSV格式文件
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fileName">文件名</param>
        public static void ExportCSV(DataTable dataTable, string fileName)
        {
            var streamWriter = new StreamWriter(fileName, false, Encoding.GetEncoding("utf-8"));

            streamWriter.WriteLine(GetCSVFormatData(dataTable).ToString());
            streamWriter.Flush();
            streamWriter.Close();
        }

        #endregion public static void ExportCSV(DataTable dataTable, string fileName) 导出CSV格式文件

        #region public static void ExportCSV(DataSet dataSet, string fileName) 导出CSV格式文件

        /// <summary>
        /// 导出CSV格式文件
        /// </summary>
        /// <param name="dataSet">数据权限</param>
        /// <param name="fileName">文件名</param>
        public static void ExportCSV(DataSet dataSet, string fileName)
        {
            var streamWriter = new StreamWriter(fileName, false, Encoding.GetEncoding("utf-8"));
            streamWriter.WriteLine(GetCSVFormatData(dataSet).ToString());
            streamWriter.Flush();
            streamWriter.Close();
        }

        #endregion public static void ExportCSV(DataSet dataSet, string fileName) 导出CSV格式文件

        #region public static void GetResponseCSV(DataTable dataTable, string fileName) 在浏览器中获得CSV格式文件

        /// <summary>
        /// 在浏览器中获得CSV格式文件
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fileName">输出文件名</param>
        public static void GetResponseCSV(DataTable dataTable, string fileName)
        {
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            HttpContext.Current.Response.AppendHeader("Content-disposition", "attachment;filename=" + fileName);
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.Write(GetCSVFormatData(dataTable).ToString());
            HttpContext.Current.Response.End();
        }

        #endregion public static void GetResponseCSV(DataTable dataTable, string fileName) 在浏览器中获得CSV格式文件

        #region public static void GetResponseCSV(DataSet dataSet, string fileName) 在浏览器中获得CSV格式文件

        /// <summary>
        /// 在浏览器中获得CSV格式文件
        /// </summary>
        /// <param name="dataSet">数据权限</param>
        /// <param name="fileName">输出文件名</param>
        public static void GetResponseCSV(DataSet dataSet, string fileName)
        {
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            HttpContext.Current.Response.AppendHeader("Content-disposition", "attachment;filename=" + fileName);
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.Write(GetCSVFormatData(dataSet).ToString());
            HttpContext.Current.Response.End();
        }

        #endregion public static void GetResponseCSV(DataSet dataSet, string fileName) 在浏览器中获得CSV格式文件
    }
}