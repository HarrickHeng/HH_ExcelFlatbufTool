using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Text;
using System.Xml.Linq;

namespace HH_ExcelFlatbufTool
{
    public sealed class Config
    {
        /// <summary>
        /// Flat工具目录
        /// </summary>
        public static string FlatcPath = "";

        /// <summary>
        /// 原始表格路径
        /// </summary>
        public static string SourceExcelPath = "";

        /// <summary>
        /// 客户端输出bytes文件路径
        /// </summary>
        public static string ClientOutBytesFilePath;

        /// <summary>
        /// 客户端输出c#文件路径
        /// </summary>
        public static string ClientOutCSharpFilePath;

        /// <summary>
        /// 客户端输出lua文件路径
        /// </summary>
        public static string ClientOutLuaFilePath;

        /// <summary>
        /// 服务器输出bytes文件路径
        /// </summary>
        public static string ServerOutBytesFilePath;

        /// <summary>
        /// 服务器输出c#文件路径
        /// </summary>
        public static string ServerOutCSharpFilePath;

        /// <summary>
        /// 系统表
        /// </summary>
        public static List<SysTable> SysTables;

        /// <summary>
        /// CSharp名单
        /// </summary>
        public static List<TableListItem> CSharpTableList;

        /// <summary>
        /// lua名单
        /// </summary>
        public static List<TableListItem> LuaTableList;

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Config.xml";

            XDocument doc = XDocument.Load(path);
            FlatcPath = doc.Root.Element("FlatcPath").Value;
            SourceExcelPath = doc.Root.Element("SourceExcelPath").Value;

            ClientOutBytesFilePath = doc.Root.Element("ClientOutBytesFilePath").Value;
            ClientOutCSharpFilePath = doc.Root.Element("ClientOutCSharpFilePath").Value;
            ClientOutLuaFilePath = doc.Root.Element("ClientOutLuaFilePath").Value;

            ServerOutBytesFilePath = doc.Root.Element("ServerOutBytesFilePath").Value;
            ServerOutCSharpFilePath = doc.Root.Element("ServerOutCSharpFilePath").Value;

            SysTables = new List<SysTable>();

            IEnumerable<XElement> lst = doc.Root.Element("SysTable").Elements("Item");
            foreach (XElement item in lst)
            {
                SysTables.Add(new SysTable()
                {
                    TableName = item.Attribute("TableName").Value,
                    ClientCSharpFilePath = item.Element("ClientCSharpFilePath").Value.Replace("\\","/"),
                    ClientLuaFilePath = item.Element("ClientLuaFilePath").Value.Replace("\\", "/"),
                    ServerCSharpFilePath = item.Element("ServerCSharpFilePath").Value.Replace("\\", "/")
                });
            }

            CSharpTableList = new List<TableListItem>();
            IEnumerable<XElement> lstCSharpTableList = doc.Root.Element("CSharpTableList").Elements("Item");
            foreach (XElement item in lstCSharpTableList)
            {
                TableListItem listItem = new TableListItem();
                listItem.TableName = item.Attribute("Name").Value;
                CSharpTableList.Add(listItem);
            }

            LuaTableList = new List<TableListItem>();
            IEnumerable<XElement> lstLuaTableList = doc.Root.Element("LuaTableList").Elements("Item");
            foreach (XElement item in lstLuaTableList)
            {
                TableListItem listItem = new TableListItem();
                listItem.TableName = item.Attribute("Name").Value;
                listItem.LoadType = int.Parse(item.Attribute("LoadType").Value);
                LuaTableList.Add(listItem);
            }
        }

        public class SysTable
        {
            public string TableName;
            public string ClientCSharpFilePath;
            public string ClientLuaFilePath;
            public string ServerCSharpFilePath;
        }
    }
    public class TableListItem
    {
        public string TableName;
        public int LoadType;
    }
}