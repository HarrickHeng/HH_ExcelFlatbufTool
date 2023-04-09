using FlatBuffers;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace HH_ExcelFlatbufTool
{
    class Program
    {
        private static string userInfo = string.Empty;

        static void Main(string[] args)
        {
            Config.Init();
            CurrTableHead = new DataTableHead();
            CurrTableHead.TableHeadDataList = new List<DataTableHeadData>();

            ReadFiles(Config.SourceExcelPath);

            DataTableDefine();
            CreateSysTable();

            CreateTableHead();
            Console.WriteLine("全部生成完毕");
            Console.ReadLine();
        }

        #region ReadFiles
        public static List<string> ReadFiles(string path)
        {
            string[] arr = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            List<string> lst = new List<string>();

            int len = arr.Length;
            for (int i = 0; i < len; i++)
            {
                string filePath = arr[i];
                FileInfo file = new FileInfo(filePath);
                if (file.Name.IndexOf("~$") > -1)
                {
                    continue;
                }
                if (file.Extension.Equals(".xls") || file.Extension.Equals(".xlsx"))
                {
                    ReadData(file.FullName, file.Name.Substring(0, file.Name.LastIndexOf('.')));
                }
            }

            return lst;
        }

        /// <summary>
        /// 将excel文件内容读取到DataTable数据表中
        /// </summary>
        /// <param name="fileName">文件完整路径名</param>
        /// <param name="sheetName">指定读取excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名：true=是，false=否</param>
        /// <returns>DataTable数据表</returns>
        public static DataTable ReadExcelToDataTable(string fileName, string sheetName = null, bool isFirstRowColumn = true)
        {
            //定义要返回的datatable对象
            DataTable data = new DataTable();
            //excel工作表
            ISheet sheet = null;
            //数据开始行(排除标题行)
            int startRow = 0;

            try
            {
                if (!File.Exists(fileName))
                {
                    return null;
                }
                //根据指定路径读取文件
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                //根据文件流创建excel数据结构
                IWorkbook workbook = WorkbookFactory.Create(fs);
                //IWorkbook workbook = new HSSFWorkbook(fs);
                //如果有指定工作表名称
                if (!string.IsNullOrEmpty(sheetName))
                {
                    sheet = workbook.GetSheet(sheetName);
                    //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    if (sheet == null)
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    //如果没有指定的sheetName，则尝试获取第一个sheet
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    //一行最后一个cell的编号 即总的列数
                    int cellCount = firstRow.LastCellNum;
                    //如果第一行是标题列名
                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }
                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;

                    //禁止加入数据
                    bool notAddToData;

                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null

                        notAddToData = false;

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                            {
                                //如果是公式Cell 
                                //则仅读取其Cell单元格的显示值 而不是读取公式
                                if (row.GetCell(j).CellType == CellType.Formula)
                                {
                                    row.GetCell(j).SetCellType(CellType.String);
                                    dataRow[j] = row.GetCell(j).StringCellValue;
                                }
                                else
                                {
                                    dataRow[j] = row.GetCell(j).ToString();
                                }

                                if (j == row.FirstCellNum)
                                {
                                    //判断是否包含#
                                    if (dataRow[j].ToString().Trim().StartsWith("#"))
                                    {
                                        notAddToData = true;
                                        break;
                                    }
                                }
                            }
                        }

                        if (notAddToData)
                        {
                            //如果这一行包含# 则不会加入数据表
                            continue;
                        }


                        data.Rows.Add(dataRow);
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private static void ReadData(string filePath, string fileName)
        {

            if (string.IsNullOrEmpty(filePath)) return;

            //把表格复制一下
            string newPath = filePath + ".temp";

            File.Copy(filePath, newPath, true);

            string tableName = "Sheet1";
            DataTable dt = ReadExcelToDataTable(newPath, tableName);

            File.Delete(newPath);

            if (fileName.Equals("DTSys_Localization", StringComparison.CurrentCultureIgnoreCase))
            {
                //多语言表 单独处理
                CreateLocalization(fileName, dt);
            }
            else
            {
                CreateData(fileName, dt);
            }
        }
        #endregion

        /// <summary>
        /// 每个表的数据
        /// </summary>
        private static Dictionary<string, DataTable> DataTableDic = new Dictionary<string, DataTable>();

        /// <summary>
        /// 每个表的表头
        /// </summary>
        private static Dictionary<string, string[,]> TableHeadDic = new Dictionary<string, string[,]>();

        private static Dictionary<string, List<DataTableHeadData>> TablesData = new Dictionary<string, List<DataTableHeadData>>();


        #region 创建普通表

        private static void CreateData(string fileName, DataTable dt)
        {
            List<DataTableHeadData> listCurrTableData = new List<DataTableHeadData>();
            TablesData[fileName] = listCurrTableData;

            #region 表头
            DataTableDic[fileName] = dt;
            string[,] tableHeadArr = null;

            int rows = dt.Rows.Count;
            int columns = dt.Columns.Count;

            tableHeadArr = new string[columns, 3];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i < 3)
                    {
                        tableHeadArr[j, i] = dt.Rows[i][j].ToString().Trim();
                    }
                }
            }

            //把表头存储起来 后面用来生成元表
            TableHeadDic[fileName] = tableHeadArr;

            //========================
            DataTableHeadData tableHeadData = new DataTableHeadData();
            tableHeadData.TableName = fileName;
            string[,] dataArr = tableHeadArr;

            tableHeadData.TableFieldDataList = new List<DataTableFieldData>();
            for (int i = 0; i < dataArr.GetLength(0); i++)
            {
                DataTableFieldData tableFieldData = new DataTableFieldData();

                //检查字段是否为列表字段
                string fieldName = dataArr[i, 0];

                if (fieldName.IndexOf("_") > 0)
                {
                    string[] listField = fieldName.Split('_');
                    if (listField.Length == 2)
                    {
                        int index = 0;
                        if (int.TryParse(listField[1], out index))
                        {
                            //如果是数字 说明是列表字段
                            //检查这个字段是否已经存在
                            if (tableHeadData.TableFieldDataList.Find((DataTableFieldData data) =>
                            {
                                return data.FieldName == listField[0];
                            }) == null)
                            {
                                tableFieldData.FieldName = listField[0];
                                tableFieldData.FieldType = dataArr[i, 1].ToLower();
                                tableFieldData.IsListField = true;

                                if (tableFieldData.FieldType != "0")
                                {
                                    tableHeadData.TableFieldDataList.Add(tableFieldData);
                                }
                            }
                            continue;
                        }
                    }
                }

                tableFieldData.FieldName = fieldName;
                tableFieldData.FieldType = dataArr[i, 1].ToLower();

                if (tableFieldData.FieldType != "0")
                {
                    tableHeadData.TableFieldDataList.Add(tableFieldData);
                }
            }

            CurrTableHead.TableHeadDataList.Add(tableHeadData);
            #endregion

            #region 把表格数据赋值到通用实体上

            for (int i = 3; i < rows; i++)
            {
                DataTableHeadData _DataTableHeadData = new DataTableHeadData();
                _DataTableHeadData.TableFieldDataList = new List<DataTableFieldData>();

                listCurrTableData.Add(_DataTableHeadData);
                //第一次循环 找出string类型字段
                for (int j = 0; j < tableHeadArr.GetLength(0); j++)
                {
                    string fieldName = tableHeadArr[j, 0];

                    #region 计算字段的名字
                    //计算字段的名字
                    if (fieldName.IndexOf("_") > 0)
                    {
                        string[] listField = fieldName.Split('_');
                        if (listField.Length == 2)
                        {
                            int index = 0;
                            if (int.TryParse(listField[1], out index))
                            {
                                fieldName = listField[0];
                            }
                        }
                    }
                    #endregion

                    DataTableFieldData currData = tableHeadData.TableFieldDataList.Find((DataTableFieldData data) =>
                    {
                        return data.FieldName == fieldName;
                    });

                    string value = dt.Rows[i][j].ToString().Trim();

                    if (currData != null)
                    {
                        //一定要再次查找
                        DataTableFieldData data = _DataTableHeadData.TableFieldDataList.Find((DataTableFieldData data) =>
                        {
                            return data.FieldName == fieldName;
                        });
                        if (data == null)
                        {
                            data = new DataTableFieldData();
                            data.FieldName = currData.FieldName;
                            data.FieldType = currData.FieldType;
                            data.IsListField = currData.IsListField;

                            if (data.FieldType != "0")
                            {
                                _DataTableHeadData.TableFieldDataList.Add(data);
                            }
                        }
                        data.FieldValues.Add(value);
                    }
                }
            }

            #endregion

            #region 生成表格文件
            FlatBufferBuilder builder = new FlatBufferBuilder(1);

            //每行的Offset
            Dictionary<int, int> m_Offset = new Dictionary<int, int>();

            //列表上string类型字段的Offset
            Dictionary<int, StringOffset> m_ColumnStringOffset = new Dictionary<int, StringOffset>();

            //列表上 字段类型字段的Offset
            Dictionary<int, VectorOffset> m_ColumnVectorOffset = new Dictionary<int, VectorOffset>();
            //========================================================================
            //行数
            for (int i = 0; i < listCurrTableData.Count; i++)
            {
                m_ColumnStringOffset.Clear();
                m_ColumnVectorOffset.Clear();

                DataTableHeadData _dataTableHeadData = listCurrTableData[i];
                int lenField = _dataTableHeadData.TableFieldDataList.Count;

                //拿出string类型的
                for (int j = lenField - 1; j >= 0; j--)
                {
                    DataTableFieldData _fieldData = _dataTableHeadData.TableFieldDataList[j];

                    if (_fieldData.FieldType.ToLower() == "int_1"
                        || _fieldData.FieldType.ToLower() == "float_1"
                        || _fieldData.FieldType.ToLower() == "string_1"
                        )
                    {
                        _fieldData.IsListField = true;
                    }

                    //如果不是传统的数组字段
                    if (_fieldData.IsListField == false)
                    {
                        if (_fieldData.FieldType.ToLower() == "string")
                        {
                            m_ColumnStringOffset[j] = builder.CreateString(_fieldData.FieldValues[0]);
                        }
                    }
                    else
                    {
                        string type = _fieldData.FieldType.ToLower();

                        List<string> lstValue = _fieldData.FieldValues;

                        //收集字符串类型的
                        Dictionary<int, StringOffset> _TempColumnStringOffset = new Dictionary<int, StringOffset>();
                        for (int m = _fieldData.FieldValues.Count - 1; m >= 0; m--)
                        {
                            if (type == "string")
                            {
                                _TempColumnStringOffset[m] = builder.CreateString(_fieldData.FieldValues[m]);
                            }
                        }

                        if (type == "string_1")
                        {
                            type = "string";
                            string[] arr = _fieldData.FieldValues[0].Split(":");
                            lstValue = new List<string>();
                            foreach (var s in arr)
                            {
                                lstValue.Add(s);
                            }
                        }
                        else if (type == "float_1")
                        {
                            type = "float";
                            string[] arr = _fieldData.FieldValues[0].Split(":");
                            lstValue = new List<string>();
                            foreach (var s in arr)
                            {
                                lstValue.Add(s);
                            }
                        }
                        else if (type == "int_1")
                        {
                            type = "int";
                            string[] arr = _fieldData.FieldValues[0].Split(":");
                            lstValue = new List<string>();
                            foreach (var s in arr)
                            {
                                lstValue.Add(s);
                            }
                        }

                        //列表类型字段
                        builder.StartVector(4, lstValue.Count, 4);
                        for (int m = lstValue.Count - 1; m >= 0; m--)
                        {
                            string value = lstValue[m];
                            #region 设置字段值
                            switch (type)
                            {
                                case "bool":
                                    bool b = (string.IsNullOrEmpty(value) || value == "假") ? false : (value == "真" ? true : bool.Parse(value));
                                    builder.AddBool(b);
                                    break;
                                case "float":
                                    {
                                        float.TryParse(value, out float v);
                                        builder.AddFloat(v);
                                    }
                                    break;
                                case "double":
                                    {
                                        double.TryParse(value, out double v);
                                        builder.AddDouble(v);
                                    }
                                    break;
                                case "sbyte":
                                    {
                                        sbyte.TryParse(value, out sbyte v);
                                        builder.AddSbyte(v);
                                    }
                                    break;
                                case "byte":
                                    {
                                        byte.TryParse(value, out byte v);
                                        builder.AddByte(v);
                                    }
                                    break;
                                case "short":
                                    {
                                        short.TryParse(value, out short v);
                                        builder.AddShort(v);
                                    }
                                    break;
                                case "ushort":
                                    {
                                        ushort.TryParse(value, out ushort v);
                                        builder.AddUshort(v);
                                    }
                                    break;
                                case "int":
                                    {
                                        int.TryParse(value, out int v);
                                        builder.AddInt(v);
                                    }
                                    break;
                                case "uint":
                                    {
                                        uint.TryParse(value, out uint v);
                                        builder.AddUint(v);
                                    }
                                    break;
                                case "ulong":
                                    {
                                        ulong.TryParse(value, out ulong v);
                                        builder.AddUlong(v);
                                    }
                                    break;
                                case "long":
                                    {
                                        long.TryParse(value, out long v);
                                        builder.AddLong(v);
                                    }
                                    break;
                                default:
                                    builder.AddOffset(_TempColumnStringOffset[m].Value);
                                    break;
                            }
                            #endregion
                        }

                        m_ColumnVectorOffset[j] = builder.EndVector();
                    }
                }

                //写入字段数量
                builder.StartTable(lenField);

                //写入值
                for (int j = lenField - 1; j >= 0; j--)
                {
                    DataTableFieldData _fieldData = _dataTableHeadData.TableFieldDataList[j];

                    if (_fieldData.IsListField == false)
                    {
                        string type = _fieldData.FieldType.ToLower();
                        string value = _fieldData.FieldValues[0];

                        #region 设置字段值
                        switch (type)
                        {
                            case "bool":
                                bool b = (string.IsNullOrEmpty(value) || value == "假") ? false : (value == "真" ? true : bool.Parse(value));
                                builder.AddBool(j, b, false);
                                break;
                            case "float":
                                {
                                    float.TryParse(value, out float v);
                                    builder.AddFloat(j, v, 0);
                                }
                                break;
                            case "double":
                                {
                                    double.TryParse(value, out double v);
                                    builder.AddDouble(j, v, 0);
                                }
                                break;
                            case "sbyte":
                                {
                                    sbyte.TryParse(value, out sbyte v);
                                    builder.AddSbyte(j, v, 0);
                                }
                                break;
                            case "byte":
                                {
                                    byte.TryParse(value, out byte v);
                                    builder.AddByte(j, v, 0);
                                }
                                break;
                            case "short":
                                {
                                    short.TryParse(value, out short v);
                                    builder.AddShort(j, v, 0);
                                }
                                break;
                            case "ushort":
                                {
                                    ushort.TryParse(value, out ushort v);
                                    builder.AddUshort(j, v, 0);
                                }
                                break;
                            case "int":
                                {
                                    int.TryParse(value, out int v);
                                    builder.AddInt(j, v, 0);
                                }
                                break;
                            case "uint":
                                {
                                    uint.TryParse(value, out uint v);
                                    builder.AddUint(j, v, 0);
                                }
                                break;
                            case "ulong":
                                {
                                    ulong.TryParse(value, out ulong v);
                                    builder.AddUlong(j, v, 0);
                                }
                                break;
                            case "long":
                                {
                                    long.TryParse(value, out long v);
                                    builder.AddLong(j, v, 0);
                                }
                                break;
                            default:
                                builder.AddOffset(j, m_ColumnStringOffset[j].Value, 0);
                                break;
                        }
                        #endregion
                    }
                    else
                    {
                        //列表类型的字段
                        builder.AddOffset(j, m_ColumnVectorOffset[j].Value, 0);
                    }
                }

                int rowOffset = builder.EndTable();
                m_Offset[i] = rowOffset;
            }


            builder.StartVector(4, listCurrTableData.Count, 4);
            for (int i = listCurrTableData.Count - 1; i >= 0; i--)
            {
                builder.AddOffset(m_Offset[i]);
            }
            var offset = builder.EndVector();
            //=================得到偏移

            builder.StartTable(1);
            builder.AddOffset(0, offset.Value, 0);
            int eab = builder.EndTable(); //获得结束为止
            builder.Finish(eab);
            byte[] buffer = builder.SizedByteArray();

            buffer = ZlibHelper.CompressBytes(buffer);
            //------------------
            //写入文件
            //------------------
            {
                if (Config.CSharpTableList.Find((TableListItem item) => item.TableName == fileName) != null)
                {
                    if (!Directory.Exists(Config.ClientOutBytesFilePath))
                    {
                        Directory.CreateDirectory(Config.ClientOutBytesFilePath);
                    }
                    FileStream fs = new FileStream(string.Format("{0}/{1}", Config.ClientOutBytesFilePath, fileName + ".bytes"), FileMode.Create);
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();

                    Console.WriteLine("客户端表格=>" + fileName + " 生成bytes文件完毕");
                }
            }

            {
                if (!string.IsNullOrEmpty(Config.ServerOutBytesFilePath))
                {
                    if (!Directory.Exists(Config.ServerOutBytesFilePath))
                    {
                        Directory.CreateDirectory(Config.ServerOutBytesFilePath);
                    }
                    FileStream fs = new FileStream(string.Format("{0}/{1}", Config.ServerOutBytesFilePath, fileName + ".bytes"), FileMode.Create);
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();

                    Console.WriteLine("服务器端表格=>" + fileName + " 生成bytes文件完毕");
                }
            }
            #endregion

            CreateClientLuaEntity(fileName, tableHeadArr, dt);
            Console.WriteLine("客户端表格=>" + fileName + " CreateClientLuaEntity Complete");

            CreateClientLuaDBModel(fileName, tableHeadArr);
            Console.WriteLine("客户端表格=>" + fileName + " CreateClientLuaDBModel Complete");

            CreateClientCSharpExt(fileName, tableHeadArr);
            Console.WriteLine("客户端表格=>" + fileName + " CreateClientCSharpExt Complete");

            CreateServerCSharpExt(fileName, tableHeadArr);
            Console.WriteLine("服务器表格=>" + fileName + " CreateServerCSharpExt Complete");
        }

        private static void CreateClientCSharpExt(string fileName, string[,] dataArr)
        {
            DataTableHeadData currTable =
CurrTableHead.TableHeadDataList.Find((DataTableHeadData data) => { return data.TableName == fileName; });

            List<DataTableFieldData> lstFields = currTable.TableFieldDataList;

            StringBuilder sbr = new StringBuilder();
            //=======================CreateClientCSharpExt
            sbr.AppendFormat("using FlatBuffers;\r\n");
            sbr.AppendFormat("using System.Collections.Generic;\r\n");
            sbr.AppendFormat("using HHFramework;\r\n");
            sbr.AppendFormat("using HHFramework.DataTable;\r\n");
            sbr.AppendFormat("\r\n");
            sbr.AppendFormat("/// <summary>\r\n");
            sbr.AppendFormat("/// Create By HHFramework HH_ExcelFlatbufTool{0}\r\n", userInfo.Trim());
            sbr.AppendFormat("/// </summary>\r\n");
            sbr.AppendFormat("public static partial class {0}ListExt\r\n", fileName);
            sbr.AppendFormat("{{\r\n");
            sbr.AppendFormat("    private static Dictionary<int, {0}?> mDic = new Dictionary<int, {0}?>();\r\n", fileName);
            sbr.AppendFormat("    private static List<{0}> mList = new List<{0}>();\r\n", fileName);
            sbr.AppendFormat("\r\n");
            sbr.AppendFormat("    #region LoadData 加载数据表数据\r\n");
            sbr.AppendFormat("    /// <summary>\r\n");
            sbr.AppendFormat("    /// 加载数据表数据\r\n");
            sbr.AppendFormat("    /// </summary>\r\n");
            sbr.AppendFormat("    public static void LoadData(this {0}List {1}List)\r\n", fileName, fileName.ToLower());
            sbr.AppendFormat("    {{\r\n");
            sbr.AppendFormat("        GameEntry.DataTable.TotalTableCount++;\r\n");
            sbr.AppendFormat("\r\n");
            sbr.AppendFormat("        //1.拿到这个表格的buffer\r\n");
            sbr.AppendFormat("        GameEntry.DataTable.GetDataTableBuffer(DataTableDefine.{0}Name, (byte[] buffer) =>\r\n", fileName);
            sbr.AppendFormat("        {{\r\n");
            sbr.AppendFormat("            //2.加载数据 并 把数据初始化到字典\r\n");
            sbr.AppendFormat("            Init({0}List.GetRootAs{0}List(new ByteBuffer(buffer)));\r\n", fileName);
            sbr.AppendFormat("        }});\r\n");
            sbr.AppendFormat("    }}\r\n");
            sbr.AppendFormat("    #endregion\r\n");
            sbr.AppendFormat("\r\n");
            sbr.AppendFormat("    /// <summary>\r\n");
            sbr.AppendFormat("    /// 初始化到字典\r\n");
            sbr.AppendFormat("    /// </summary>\r\n");
            sbr.AppendFormat("    public static void Init({0}List {1}List)\r\n", fileName, fileName.ToLower());
            sbr.AppendFormat("    {{\r\n");
            sbr.AppendFormat("        System.Threading.Tasks.Task.Run(() => {{\r\n");
            sbr.AppendFormat("            int len = {0}List.{1}sLength;\r\n", fileName.ToLower(), fileName.Replace("_", ""));
            sbr.AppendFormat("            for (int j = 0; j < len; j++)\r\n");
            sbr.AppendFormat("            {{\r\n");
            sbr.AppendFormat("                {0} ? {1} = {1}List.{2}s(j);\r\n", fileName, fileName.ToLower(), fileName.Replace("_", ""));
            sbr.AppendFormat("                if ({0} != null)\r\n", fileName.ToLower());
            sbr.AppendFormat("                {{\r\n");
            sbr.AppendFormat("                    mList.Add({0}.Value);\r\n", fileName.ToLower());
            sbr.AppendFormat("                    mDic[{0}.Value.Id] = {0};\r\n", fileName.ToLower());
            sbr.AppendFormat("                }}\r\n");
            sbr.AppendFormat("            }}\r\n");
            sbr.AppendFormat("\r\n");
            sbr.AppendFormat("            //3.派发单个表加载完毕事件\r\n");
            sbr.AppendFormat("            GameEntry.DataTable.AddToAlreadyLoadTable(DataTableDefine.{0}Name, DataTableDefine.{0}Version);\r\n", fileName);
            sbr.AppendFormat("            GameEntry.Event.CommonEvent.Dispatch(SysEventId.LoadOneDataTableComplete, DataTableDefine.{0}Name);\r\n", fileName);
            sbr.AppendFormat("        }});\r\n");
            sbr.AppendFormat("    }}\r\n");
            sbr.AppendFormat("\r\n");
            sbr.AppendFormat("    /// <summary>\r\n");
            sbr.AppendFormat("    /// 获取数据实体\r\n");
            sbr.AppendFormat("    /// </summary>\r\n");
            sbr.AppendFormat("    /// <param name=\"id\"></param>\r\n");
            sbr.AppendFormat("    /// <returns></returns>\r\n");
            sbr.AppendFormat("    public static {0}? GetEntity(this {0}List {1}List, int id)\r\n", fileName, fileName.ToLower());
            sbr.AppendFormat("    {{\r\n");
            sbr.AppendFormat("        {0} ? {1};\r\n", fileName, fileName.ToLower());
            sbr.AppendFormat("        mDic.TryGetValue(id, out {0});\r\n", fileName.ToLower());
            sbr.AppendFormat("        return {0};\r\n", fileName.ToLower());
            sbr.AppendFormat("    }}\r\n");
            sbr.AppendFormat("\r\n");

            sbr.AppendFormat("    /// <summary>\r\n");
            sbr.AppendFormat("    /// 获取数据实体值\r\n");
            sbr.AppendFormat("    /// </summary>\r\n");
            sbr.AppendFormat("    /// <param name=\"id\"></param>\r\n");
            sbr.AppendFormat("    /// <returns></returns>\r\n");
            sbr.AppendFormat("    public static {0} GetEntityValue(this {0}List {1}List, int id)\r\n", fileName, fileName.ToLower());
            sbr.AppendFormat("    {{\r\n");
            sbr.AppendFormat("        {0} ? {1} = {1}List.GetEntity(id);\r\n", fileName, fileName.ToLower());
            sbr.AppendFormat("        if ({0} != null)\r\n", fileName.ToLower());
            sbr.AppendFormat("        {{\r\n");
            sbr.AppendFormat("            return {0}.Value;\r\n", fileName.ToLower());
            sbr.AppendFormat("        }}\r\n");
            sbr.AppendFormat("        return default;\r\n");
            sbr.AppendFormat("    }}\r\n");
            sbr.AppendFormat("\r\n");
            sbr.AppendFormat("    /// <summary>\r\n");
            sbr.AppendFormat("    /// 获取列表\r\n");
            sbr.AppendFormat("    /// </summary>\r\n");
            sbr.AppendFormat("    /// <returns></returns>\r\n");
            sbr.AppendFormat("    public static List<{0}> GetList(this {0}List {1}List)\r\n", fileName, fileName.ToLower());
            sbr.AppendFormat("    {{\r\n");
            sbr.AppendFormat("        return mList;\r\n");
            sbr.AppendFormat("    }}\r\n");
            sbr.AppendFormat("}}");
            if (Config.CSharpTableList.Find((TableListItem item) => item.TableName == fileName) != null)
            {
                string path = string.Format("{0}/{1}ListExt.cs", Config.ClientOutCSharpFilePath, fileName);
                if (!Directory.Exists(Config.ClientOutCSharpFilePath))
                {
                    Directory.CreateDirectory(Config.ClientOutCSharpFilePath);
                }
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(sbr.ToString());
                    }
                }
            }
        }

        private static void CreateServerCSharpExt(string fileName, string[,] dataArr)
        {
            StringBuilder sbr = new StringBuilder();
            //=======================CreateClientCSharpExt
            sbr.AppendFormat("using FlatBuffers;\r\n");
            sbr.AppendFormat("using System.Collections.Generic;\r\n");
            sbr.AppendFormat("using HHServer.Core.Utils;\r\n");
            sbr.AppendFormat("using HHServer.Common.Managers;\r\n");
            sbr.AppendFormat("\r\n");
            sbr.AppendFormat("namespace HHFramework.DataTable\r\n");
            sbr.AppendFormat("{{\r\n");
            sbr.AppendFormat("/// <summary>\r\n");
            sbr.AppendFormat("/// Create By HH_ExcelFlatbufTool {0}\r\n", userInfo.Trim());
            sbr.AppendFormat("/// </summary>\r\n");
            sbr.AppendFormat("    public static partial class {0}ListExt\r\n", fileName);
            sbr.AppendFormat("    {{\r\n");
            sbr.AppendFormat("        private static Dictionary<int, {0}?> mDic = new Dictionary<int, {0}?>();\r\n", fileName);
            sbr.AppendFormat("        private static List<{0}> mList = new List<{0}>();\r\n", fileName);
            sbr.AppendFormat("\r\n");
            sbr.AppendFormat("        #region LoadData 加载数据表数据\r\n");
            sbr.AppendFormat("        /// <summary>\r\n");
            sbr.AppendFormat("        /// 加载数据表数据\r\n");
            sbr.AppendFormat("        /// </summary>\r\n");
            sbr.AppendFormat("        public static void LoadData(this {0}List {1}List)\r\n", fileName, fileName.ToLower());
            sbr.AppendFormat("        {{\r\n");
            sbr.AppendFormat("            byte[] buffer = HHIOUtil.GetBuffer(ServerConfig.DataTablePath + \"/{0}.bytes\", true);\r\n", fileName);
            sbr.AppendFormat("            Init({0}List.GetRootAs{0}List(new ByteBuffer(buffer)));\r\n", fileName);
            sbr.AppendFormat("        }}\r\n");
            sbr.AppendFormat("        #endregion\r\n");
            sbr.AppendFormat("\r\n");
            sbr.AppendFormat("        /// <summary>\r\n");
            sbr.AppendFormat("        /// 初始化到字典\r\n");
            sbr.AppendFormat("        /// </summary>\r\n");
            sbr.AppendFormat("        public static void Init({0}List {1}List)\r\n", fileName, fileName.ToLower());
            sbr.AppendFormat("        {{\r\n");
            sbr.AppendFormat("            int len = {0}List.{1}sLength;\r\n", fileName.ToLower(), fileName.Replace("_", ""));
            sbr.AppendFormat("            for (int j = 0; j < len; j++)\r\n");
            sbr.AppendFormat("            {{\r\n");
            sbr.AppendFormat("                {0} ? {1} = {1}List.{2}s(j);\r\n", fileName, fileName.ToLower(), fileName.Replace("_", ""));
            sbr.AppendFormat("                if ({0} != null)\r\n", fileName.ToLower());
            sbr.AppendFormat("                {{\r\n");
            sbr.AppendFormat("                    mList.Add({0}.Value);\r\n", fileName.ToLower());
            sbr.AppendFormat("                    mDic[{0}.Value.Id] = {0};\r\n", fileName.ToLower());
            sbr.AppendFormat("                }}\r\n");
            sbr.AppendFormat("            }}\r\n");
            sbr.AppendFormat("        }}\r\n");
            sbr.AppendFormat("\r\n");
            sbr.AppendFormat("        /// <summary>\r\n");
            sbr.AppendFormat("        /// 获取数据实体\r\n");
            sbr.AppendFormat("        /// </summary>\r\n");
            sbr.AppendFormat("        /// <param name=\"id\"></param>\r\n");
            sbr.AppendFormat("        /// <returns></returns>\r\n");
            sbr.AppendFormat("        public static {0}? GetEntity(this {0}List {1}List, int id)\r\n", fileName, fileName.ToLower());
            sbr.AppendFormat("        {{\r\n");
            sbr.AppendFormat("            {0} ? {1};\r\n", fileName, fileName.ToLower());
            sbr.AppendFormat("            mDic.TryGetValue(id, out {0});\r\n", fileName.ToLower());
            sbr.AppendFormat("            return {0};\r\n", fileName.ToLower());
            sbr.AppendFormat("        }}\r\n");
            sbr.AppendFormat("\r\n");

            sbr.AppendFormat("        /// <summary>\r\n");
            sbr.AppendFormat("        /// 获取数据实体值\r\n");
            sbr.AppendFormat("        /// </summary>\r\n");
            sbr.AppendFormat("        /// <param name=\"id\"></param>\r\n");
            sbr.AppendFormat("        /// <returns></returns>\r\n");
            sbr.AppendFormat("        public static {0} GetEntityValue(this {0}List {1}List, int id)\r\n", fileName, fileName.ToLower());
            sbr.AppendFormat("        {{\r\n");
            sbr.AppendFormat("            {0} ? {1} = {1}List.GetEntity(id);\r\n", fileName, fileName.ToLower());
            sbr.AppendFormat("            if ({0} != null)\r\n", fileName.ToLower());
            sbr.AppendFormat("            {{\r\n");
            sbr.AppendFormat("                return {0}.Value;\r\n", fileName.ToLower());
            sbr.AppendFormat("            }}\r\n");
            sbr.AppendFormat("            return default;\r\n");
            sbr.AppendFormat("        }}\r\n");
            sbr.AppendFormat("\r\n");
            sbr.AppendFormat("        /// <summary>\r\n");
            sbr.AppendFormat("        /// 获取列表\r\n");
            sbr.AppendFormat("        /// </summary>\r\n");
            sbr.AppendFormat("        /// <returns></returns>\r\n");
            sbr.AppendFormat("        public static List<{0}> GetList(this {0}List {1}List)\r\n", fileName, fileName.ToLower());
            sbr.AppendFormat("        {{\r\n");
            sbr.AppendFormat("            return mList;\r\n");
            sbr.AppendFormat("        }}\r\n");
            sbr.AppendFormat("    }}\r\n");
            sbr.AppendFormat("}}");
            if (Config.CSharpTableList.Find((TableListItem item) => item.TableName == fileName) != null)
            {
                if (!string.IsNullOrEmpty(Config.ServerOutCSharpFilePath))
                {
                    if (!Directory.Exists(Config.ServerOutCSharpFilePath))
                    {
                        Directory.CreateDirectory(Config.ServerOutCSharpFilePath);
                    }

                    string path = string.Format("{0}/{1}ListExt.cs", Config.ServerOutCSharpFilePath, fileName);

                    if (!Directory.Exists(Config.ServerOutCSharpFilePath))
                    {
                        Directory.CreateDirectory(Config.ServerOutCSharpFilePath);
                    }
                    if (!File.Exists(path))
                    {
                        using (FileStream fs = new FileStream(path, FileMode.Create))
                        {
                            using (StreamWriter sw = new StreamWriter(fs))
                            {
                                sw.Write(sbr.ToString());
                            }
                        }
                    }
                }
            }
        }

        #region Lua
        /// <summary>
        /// 创建客户端Lua实体
        /// </summary>
        private static void CreateClientLuaEntity(string fileName, string[,] dataArr, DataTable dt)
        {
            if (dataArr == null) return;

            StringBuilder sbr = new StringBuilder();
            //=======================创建Lua的实体
            sbr.Clear();
            sbr.AppendFormat("-- Create By HH_ExcelFlatbufTool\r\n");
            sbr.AppendFormat("{0}Entity = {{ ", fileName);

            DataTableHeadData currTable =
            CurrTableHead.TableHeadDataList.Find((DataTableHeadData data) => { return data.TableName == fileName; });

            List<DataTableFieldData> lstFields = currTable.TableFieldDataList;
            for (int i = 0; i < lstFields.Count; i++)
            {
                DataTableFieldData fieldData = lstFields[i];

                if (i == lstFields.Count - 1)
                {
                    if (fieldData.IsListField)
                    {
                        sbr.AppendFormat("{0} = {{}}", fieldData.FieldName);
                    }
                    else if (fieldData.FieldType.ToLower() == "string")
                    {
                        sbr.AppendFormat("{0} = \"\"", fieldData.FieldName);
                    }
                    else if (fieldData.FieldType.ToLower() == "int_1")
                    {
                        sbr.AppendFormat("{0} = {{}}", fieldData.FieldName);
                    }
                    else if (fieldData.FieldType.ToLower() == "int_2")
                    {
                        sbr.AppendFormat("{0} = {{{{}},{{}}}}", fieldData.FieldName);
                    }
                    else if (fieldData.FieldType.ToLower() == "float_1")
                    {
                        sbr.AppendFormat("{0} = {{}}", fieldData.FieldName);
                    }
                    else if (fieldData.FieldType.ToLower() == "float_2")
                    {
                        sbr.AppendFormat("{0} = {{{{}},{{}}}}", fieldData.FieldName);
                    }
                    else if (fieldData.FieldType.ToLower() == "string_1")
                    {
                        sbr.AppendFormat("{0} = {{}}", fieldData.FieldName);
                    }
                    else if (fieldData.FieldType.ToLower() == "string_2")
                    {
                        sbr.AppendFormat("{0} = {{{{}},{{}}}}", fieldData.FieldName);
                    }
                    else
                    {
                        sbr.AppendFormat("{0} = 0", fieldData.FieldName);
                    }
                }
                else
                {
                    if (fieldData.IsListField)
                    {
                        sbr.AppendFormat("{0} = {{}}, ", fieldData.FieldName);
                    }
                    else if (fieldData.FieldType.ToLower() == "string")
                    {
                        sbr.AppendFormat("{0} = \"\", ", fieldData.FieldName);
                    }
                    else if (fieldData.FieldType.ToLower() == "int_1")
                    {
                        sbr.AppendFormat("{0} = {{}}, ", fieldData.FieldName);
                    }
                    else if (fieldData.FieldType.ToLower() == "int_2")
                    {
                        sbr.AppendFormat("{0} = {{{{}},{{}}}}, ", fieldData.FieldName);
                    }
                    else if (fieldData.FieldType.ToLower() == "float_1")
                    {
                        sbr.AppendFormat("{0} = {{}}, ", fieldData.FieldName);
                    }
                    else if (fieldData.FieldType.ToLower() == "float_2")
                    {
                        sbr.AppendFormat("{0} = {{{{}},{{}}}}, ", fieldData.FieldName);
                    }
                    else
                    {
                        sbr.AppendFormat("{0} = 0, ", fieldData.FieldName);
                    }
                }
            }
            sbr.Append(" }\r\n");

            sbr.Append("\r\n");
            sbr.AppendFormat("{0}Entity.__index = {0}Entity\r\n", fileName);
            sbr.Append("\r\n");
            sbr.AppendFormat("function {0}Entity.New(", fileName);

            for (int i = 0; i < lstFields.Count; i++)
            {
                DataTableFieldData fieldData = lstFields[i];

                if (i == lstFields.Count - 1)
                {
                    sbr.AppendFormat("{0}", fieldData.FieldName);
                }
                else
                {
                    sbr.AppendFormat("{0}, ", fieldData.FieldName);
                }
            }
            sbr.Append(")\r\n");
            sbr.Append("    local self = { }\r\n");
            sbr.Append("");
            sbr.AppendFormat("    setmetatable(self, {0}Entity)\r\n", fileName);
            sbr.Append("\r\n");
            for (int i = 0; i < lstFields.Count; i++)
            {
                DataTableFieldData fieldData = lstFields[i];
                sbr.AppendFormat("    self.{0} = {0}\r\n", fieldData.FieldName);
            }
            sbr.Append("\r\n");
            sbr.Append("    return self\r\n");
            sbr.Append("end\r\n");
            sbr.Append("\r\n");
            sbr.AppendFormat("function {0}Entity.NewFromArrItem(item)\r\n", fileName);
            sbr.Append("    local self = { }\r\n");
            sbr.Append("");
            sbr.AppendFormat("    setmetatable(self, {0}Entity)\r\n", fileName);
            sbr.Append("\r\n");
            for (int i = 0; i < lstFields.Count; i++)
            {
                DataTableFieldData fieldData = lstFields[i];
                sbr.AppendFormat("    self.{0} = item[{1}]\r\n", fieldData.FieldName, i + 1);
            }
            sbr.Append("\r\n");
            sbr.Append("    return self\r\n");
            sbr.Append("end\r\n");
            sbr.Append("\r\n");
            sbr.AppendFormat("local arr =\r\n");
            sbr.AppendFormat("{{\r\n");
            sbr.AppendFormat("    ByIdx = {{\r\n");

            //数据
            List<DataTableHeadData> lst = TablesData[fileName];

            string str = string.Empty;
            int reduceCount = 0;

            for (int i = 0; i < lst.Count; i++)
            {
                bool needContinue = false;
                DataTableHeadData dataTableHeadData = lst[i];
                for (int j = 0; j < dataTableHeadData.TableFieldDataList.Count; j++)
                {
                    DataTableFieldData dataTableFieldData = dataTableHeadData.TableFieldDataList[j];
                    if (dataTableFieldData.FieldName == "id")
                    {
                        //这里判断id是否为空
                        string value = dataTableFieldData.FieldValues[0];
                        if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(value.Trim()))
                        {
                            needContinue = true;
                        }
                    }
                }

                if (needContinue)
                {
                    reduceCount++;
                    continue;
                }


                str += "        {";
                for (int j = 0; j < dataTableHeadData.TableFieldDataList.Count; j++)
                {
                    DataTableFieldData dataTableFieldData = dataTableHeadData.TableFieldDataList[j];


                    if (dataTableFieldData.FieldType.ToLower() == "int_1"
    || dataTableFieldData.FieldType.ToLower() == "float_1"
    || dataTableFieldData.FieldType.ToLower() == "string_1"
    )
                    {
                        dataTableFieldData.IsListField = false;
                    }

                    if (dataTableFieldData.IsListField)
                    {
                        string strInner = string.Empty;
                        for (int m = 0; m < dataTableFieldData.FieldValues.Count; m++)
                        {
                            if (dataTableFieldData.FieldType.ToLower() == "string")
                            {
                                strInner += string.Format("\"{0}\", ", dataTableFieldData.FieldValues[m]);
                            }
                            else
                            {
                                strInner += string.Format("{0}, ", dataTableFieldData.FieldValues[m]);
                            }
                        }

                        strInner = strInner.TrimEnd(new char[] { ',', ' ' });
                        str += string.Format("{{{0}}}, ", strInner);
                    }
                    else
                    {
                        string type = dataTableFieldData.FieldType;
                        string value = dataTableFieldData.FieldValues[0];

                        switch (type.ToLower())
                        {
                            case "int":
                                int realValueint = 0;
                                double.TryParse(value, out var realValuedouble2);
                                realValueint = (int)Math.Round(realValuedouble2);
                                str += string.Format("{0}, ", realValueint);
                                break;
                            case "long":
                                long realValuelong = 0;
                                double.TryParse(value, out var realValuedouble3);
                                realValuelong = (long)Math.Round(realValuedouble3);
                                str += string.Format("{0}, ", realValuelong);
                                break;
                            case "short":
                                short realValueshort = 0;
                                double.TryParse(value, out var realValuedouble4);
                                realValueshort = (short)Math.Round(realValuedouble4);
                                str += string.Format("{0}, ", realValueshort);
                                break;
                            case "float":
                                float.TryParse(value, out var realValuefloat);
                                str += string.Format("{0}, ", realValuefloat);
                                break;
                            case "byte":
                                int realValuebyte = 0;
                                double.TryParse(value, out var realValuedouble5);
                                realValuebyte = (int)Math.Round(realValuedouble5);
                                str += string.Format("{0}, ", realValuebyte);
                                break;
                            case "double":
                                double.TryParse(value, out var realValuedouble);
                                str += string.Format("{0}, ", realValuedouble);
                                break;
                            case "bool":
                                bool b = (string.IsNullOrEmpty(value) || value == "假")
                                    ? false
                                    : (value == "真" ? true : bool.Parse(value));
                                str += string.Format("{0}, ", b);
                                break;
                            case "int_1":
                                {
                                    //一纬数据拆解
                                    string[] arr = value.Split(":");
                                    str += "{";
                                    foreach (var item in arr)
                                    {
                                        int itemValue = 0;
                                        int.TryParse(item, out itemValue);
                                        str += string.Format("{0},", itemValue);
                                    }

                                    str = str.TrimEnd(',');
                                    str += "}, ";
                                }
                                break;
                            case "int_2":
                                {
                                    if (string.IsNullOrEmpty(value))
                                    {
                                        str += "{},";
                                    }
                                    else
                                    {
                                        //二维数据拆解
                                        string[] arr1 = value.Split(",");
                                        str += "{";

                                        foreach (var item1 in arr1)
                                        {
                                            str += "{";
                                            string[] arr2 = item1.Split(":");
                                            foreach (var item2 in arr2)
                                            {
                                                int itemValue = 0;
                                                int.TryParse(item2, out itemValue);
                                                str += string.Format("{0},", itemValue);
                                            }

                                            str = str.TrimEnd(',');
                                            str += "},";
                                        }

                                        str = str.TrimEnd(',');
                                        str += "}, ";
                                    }
                                }
                                break;
                            case "float_1":
                                {
                                    //一纬数据拆解
                                    string[] arr = value.Split(":");
                                    str += "{";
                                    foreach (var item in arr)
                                    {
                                        float itemValue = 0;
                                        float.TryParse(item, out itemValue);
                                        str += string.Format("{0},", itemValue);
                                    }

                                    str = str.TrimEnd(',');
                                    str += "}, ";
                                }
                                break;
                            case "float_2":
                                {
                                    if (string.IsNullOrEmpty(value))
                                    {
                                        str += "{},";
                                    }
                                    else
                                    {
                                        //二维数据拆解
                                        string[] arr1 = value.Split(",");
                                        str += "{";

                                        foreach (var item1 in arr1)
                                        {
                                            str += "{";
                                            string[] arr2 = item1.Split(":");
                                            foreach (var item2 in arr2)
                                            {
                                                float itemValue = 0;
                                                float.TryParse(item2, out itemValue);
                                                str += string.Format("{0},", itemValue);
                                            }

                                            str = str.TrimEnd(',');
                                            str += "},";
                                        }

                                        str = str.TrimEnd(',');
                                        str += "}, ";
                                    }
                                }
                                break;

                            case "string_1":
                                {
                                    //一纬数据拆解
                                    string[] arr = value.Split(":");
                                    str += "{";
                                    foreach (var item in arr)
                                    {
                                        str += string.Format("\"{0}\",", item);
                                    }

                                    str = str.TrimEnd(',');
                                    str += "}";
                                }
                                break;
                            case "string_2":
                                {
                                    //二维数据拆解
                                    string[] arr1 = value.Split(",");
                                    str += "{";

                                    foreach (var item1 in arr1)
                                    {
                                        str += "{";
                                        string[] arr2 = item1.Split(":");
                                        foreach (var item2 in arr2)
                                        {
                                            str += string.Format("\"{0}\",", item2);
                                        }

                                        str = str.TrimEnd(',');
                                        str += "},";
                                    }

                                    str = str.TrimEnd(',');
                                    str += "}";
                                }
                                break;
                            default:
                                str += string.Format("\"{0}\", ", value);
                                break;
                        }
                    }
                }

                str = str.TrimEnd(new char[] { ',', ' ' });
                str += "},\r\n";
            }

            sbr.AppendFormat("{0}\r\n", str.TrimEnd(new char[] { ',', '\r', '\n' }));
            sbr.AppendFormat("    }},\r\n");
            sbr.AppendFormat("    Len = {0}\r\n", lst.Count);
            sbr.AppendFormat("}}\r\n");
            sbr.Append("\r\n");
            sbr.AppendFormat("function {0}Entity.GetArr()\r\n", fileName);
            sbr.AppendFormat("    return arr\r\n");
            sbr.AppendFormat("end");


            if (Config.LuaTableList.Find((TableListItem item) => item.TableName == fileName) != null)
            {
                if (!Directory.Exists(Config.ClientOutLuaFilePath))
                {
                    Directory.CreateDirectory(Config.ClientOutLuaFilePath);
                }
                using (FileStream fs = new FileStream(string.Format("{0}/{1}Entity.bytes", Config.ClientOutLuaFilePath, fileName), FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(sbr.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 创建客户端数据管理类
        /// </summary>
        private static void CreateClientLuaDBModel(string fileName, string[,] dataArr)
        {
            if (dataArr == null) return;

            StringBuilder sbr = new StringBuilder();
            //===============生成lua的DBModel
            TableListItem tableListItem = Config.LuaTableList.Find((TableListItem item) => item.TableName == fileName);
            if (tableListItem == null)
            {
                return;
            }

            DataTableHeadData currTable =
CurrTableHead.TableHeadDataList.Find((DataTableHeadData data) => { return data.TableName == fileName; });

            List<DataTableFieldData> lstFields = currTable.TableFieldDataList;

            sbr.Clear();

            sbr.AppendFormat("-- Create By HH_ExcelFlatbufTool\r\n");
            sbr.AppendFormat("{0}DBModel = {{ }}\r\n", fileName);
            sbr.Append("\r\n");
            sbr.AppendFormat("local this = {0}DBModel\r\n", fileName);
            sbr.Append("\r\n");
            sbr.AppendFormat("local {0}Table = {{ }}; --定义表格\r\n", fileName.ToLower());
            sbr.AppendFormat("local {0}TableDic = {{ }}; --定义表格字典\r\n", fileName.ToLower());
            sbr.Append("\r\n");
            sbr.AppendFormat("local dataTableName = \"{0}\"\r\n", fileName);
            sbr.AppendFormat("local currColumns = {0}\r\n", lstFields.Count);
            sbr.AppendFormat("local isAlreadyLoadTableInCSharp = false\r\n");
            sbr.AppendFormat("local lastUseTime = 0\r\n");
            sbr.AppendFormat("local loadType = {0}; --读取方式0=从lua文件读取 1=从c#已有数据加载\r\n", tableListItem.LoadType);
            sbr.Append("\r\n");
            sbr.AppendFormat("function {0}DBModel.LoadList()\r\n", fileName);
            sbr.AppendFormat("    if (loadType == 0) then\r\n");
            sbr.AppendFormat("        local arr = {0}Entity.GetArr()\r\n", fileName);
            sbr.AppendFormat("        for i = 1, arr.Len do\r\n");
            sbr.AppendFormat("            local item = arr.ByIdx[i]; --拿到索引数据\r\n");
            sbr.AppendFormat("            local {0}Entity = {1}Entity.NewFromArrItem(item)\r\n", fileName.ToLower(), fileName);
            sbr.AppendFormat("            {0}Table[#{0}Table + 1] = {0}Entity\r\n", fileName.ToLower());
            sbr.AppendFormat("            {0}TableDic[{0}Entity.Id] = {0}Entity\r\n", fileName.ToLower());
            sbr.AppendFormat("        end\r\n");
            sbr.AppendFormat("        GameInit.LoadOneTableComplete()\r\n");
            sbr.AppendFormat("    else\r\n");
            sbr.AppendFormat("        --检查这个表在c#中是否已经加载\r\n");
            sbr.AppendFormat("        if (GameEntry.DataTable:CheckAlreadyLoadTable(dataTableName, currColumns)) then\r\n");
            sbr.AppendFormat("            isAlreadyLoadTableInCSharp = true\r\n");
            sbr.AppendFormat("            GameInit.LoadOneTableComplete()\r\n");
            sbr.AppendFormat("        else\r\n");
            sbr.AppendFormat("            print(\"table load fail\"..dataTableName)\r\n");
            sbr.AppendFormat("            GameInit.LoadOneTableComplete()\r\n");
            sbr.AppendFormat("        end\r\n");
            sbr.AppendFormat("    end\r\n");
            sbr.AppendFormat("end\r\n");
            sbr.Append("\r\n");
            sbr.AppendFormat("function {0}DBModel.GetList()\r\n", fileName);
            sbr.AppendFormat("    --如果和c#不一致 说明自己会加载\r\n");
            sbr.AppendFormat("    if (isAlreadyLoadTableInCSharp == false) then\r\n");
            sbr.AppendFormat("        return {0}Table\r\n", fileName.ToLower());
            sbr.AppendFormat("    end\r\n");
            sbr.AppendFormat("\r\n");
            sbr.AppendFormat("    lastUseTime = Time.time\r\n");
            sbr.AppendFormat("    --循环c#的表\r\n");
            sbr.AppendFormat("    local lstCSharp = GameEntry.DataTable.{0}List:GetList()\r\n", fileName);
            sbr.AppendFormat("    local len = lstCSharp.Count - 1\r\n");
            sbr.AppendFormat("    local {0}EntityCSharp = nil\r\n", fileName.ToLower());
            sbr.AppendFormat("    local {0}Entity = nil\r\n", fileName.ToLower());
            sbr.AppendFormat("\r\n");
            sbr.AppendFormat("    for i = 0, len, 1 do\r\n");
            sbr.AppendFormat("        {0}EntityCSharp = lstCSharp[i]\r\n", fileName.ToLower());
            sbr.AppendFormat("        {0}Entity = this.GetEntityFromCSharp({0}EntityCSharp.Id, {0}EntityCSharp)\r\n", fileName.ToLower());
            sbr.AppendFormat("        this.AddToTable({0}Entity)\r\n", fileName.ToLower());
            sbr.AppendFormat("    end\r\n");

            sbr.AppendFormat("    lstCSharp = nil\r\n");
            sbr.AppendFormat("    len = nil\r\n");
            sbr.AppendFormat("    {0}EntityCSharp = nil\r\n", fileName.ToLower());
            sbr.AppendFormat("    {0}Entity = nil\r\n", fileName.ToLower());
            sbr.AppendFormat("\r\n");
            sbr.AppendFormat("    return {0}Table\r\n", fileName.ToLower());
            sbr.AppendFormat("end\r\n");

            sbr.Append("\r\n");
            sbr.AppendFormat("function {0}DBModel.GetEntity(id)\r\n", fileName);
            sbr.AppendFormat("    local ret = this.GetEntityInner(id)\r\n");
            sbr.AppendFormat("    lastUseTime = Time.time\r\n");
            sbr.AppendFormat("\r\n");
            sbr.AppendFormat("    --如果在lua中存在 或者和c#不一致 直接返回\r\n");
            sbr.AppendFormat("    if (ret ~= nil or isAlreadyLoadTableInCSharp == false) then\r\n");
            sbr.AppendFormat("        return ret\r\n");
            sbr.AppendFormat("    end\r\n");
            sbr.AppendFormat("\r\n");
            sbr.AppendFormat("    --去c#中查询\r\n");
            sbr.AppendFormat("    ret = this.GetEntityFromCSharp(id)\r\n");
            sbr.AppendFormat("    if (ret ~= nil) then\r\n");
            sbr.AppendFormat("        this.AddToTable(ret)\r\n");
            sbr.AppendFormat("    end\r\n");
            sbr.AppendFormat("    return ret\r\n");
            sbr.AppendFormat("end\r\n");
            sbr.Append("\r\n");
            sbr.AppendFormat("function {0}DBModel.GetEntityInner(id)\r\n", fileName);
            sbr.AppendFormat("    return {0}TableDic[id]\r\n", fileName.ToLower());
            sbr.AppendFormat("end\r\n");
            sbr.Append("\r\n");
            sbr.AppendFormat("function {0}DBModel.AddToTable(entity)\r\n", fileName);
            sbr.AppendFormat("    if (this.GetEntityInner(entity.Id) == nil) then\r\n");
            sbr.AppendFormat("        {0}Table[#{0}Table + 1] = entity\r\n", fileName.ToLower());
            sbr.AppendFormat("        {0}TableDic[entity.Id] = entity\r\n", fileName.ToLower());
            sbr.AppendFormat("    end\r\n");
            sbr.AppendFormat("end\r\n");
            sbr.Append("\r\n");
            sbr.AppendFormat("function {0}DBModel.GetEntityFromCSharp(id, cSharpEntity)\r\n", fileName);
            sbr.AppendFormat("    local {0}EntityCSharp = (cSharpEntity ~= nil and cSharpEntity or GameEntry.DataTable.{1}List:GetEntityValue(id))\r\n", fileName.ToLower(), fileName);
            sbr.AppendFormat("    if ({0}EntityCSharp == nil) then\r\n", fileName.ToLower());
            sbr.AppendFormat("        return nil\r\n");
            sbr.AppendFormat("    end\r\n");
            sbr.AppendFormat("\r\n");
            sbr.AppendFormat("    local {0}Entity = nil\r\n", fileName.ToLower());
            sbr.AppendFormat("    if(cSharpEntity ~= nil) then\r\n");
            sbr.AppendFormat("        --说明是通过循环列表时候获取单个对象\r\n");
            sbr.AppendFormat("        {0}Entity = this.GetEntityInner(id)\r\n", fileName.ToLower());
            sbr.AppendFormat("        if({0}Entity ~= nil) then\r\n", fileName.ToLower());
            sbr.AppendFormat("            return {0}Entity\r\n", fileName.ToLower());
            sbr.AppendFormat("        end\r\n");
            sbr.AppendFormat("    end\r\n");
            sbr.AppendFormat("\r\n");

            for (int i = 0; i < lstFields.Count; i++)
            {
                DataTableFieldData fieldData = lstFields[i];
                if (fieldData.IsListField)
                {
                    string strListField = string.Empty;
                    strListField += string.Format("    local {0} = {{}}\r\n", fieldData.FieldName);
                    strListField += string.Format("    local len = {1}EntityCSharp.{0}Length - 1\r\n", fieldData.FieldName, fileName.ToLower());
                    strListField += string.Format("    for i = 0, len, 1 do\r\n");
                    strListField += string.Format("        {0}[#{0}+1] = {1}EntityCSharp:{0}(i)\r\n", fieldData.FieldName, fileName.ToLower());
                    strListField += string.Format("    end\r\n");

                    sbr.AppendFormat("{0}\r\n", strListField);
                }
            }

            sbr.AppendFormat("    {0}Entity = {1}Entity.New(\r\n", fileName.ToLower(), fileName);

            string str = "";
            for (int i = 0; i < lstFields.Count; i++)
            {
                DataTableFieldData fieldData = lstFields[i];
                if (fieldData.IsListField)
                {
                    str += string.Format("        {0},\r\n", fieldData.FieldName);
                }
                else
                {
                    str += string.Format("        {1}EntityCSharp.{0},\r\n", fieldData.FieldName, fileName.ToLower());
                }
            }
            str = str.TrimEnd(',', '\r', '\n');
            sbr.AppendFormat("{0}\r\n", str);
            sbr.Append("        )\r\n");
            sbr.AppendFormat("    {0}EntityCSharp = nil\r\n", fileName.ToLower());

            for (int i = 0; i < lstFields.Count; i++)
            {
                DataTableFieldData fieldData = lstFields[i];
                if (fieldData.IsListField)
                {
                    sbr.AppendFormat("    {0} = nil\r\n", fieldData.FieldName);
                }
            }

            sbr.AppendFormat("    return {0}Entity\r\n", fileName.ToLower());
            sbr.AppendFormat("end\r\n");
            sbr.Append("\r\n");
            sbr.AppendFormat("function {0}DBModel.CheckGC()\r\n", fileName);
            sbr.AppendFormat("    if (isAlreadyLoadTableInCSharp and Time.time > lastUseTime + GameEntry.Lua.LuaDataTableLife and #{0}Table > 0) then\r\n", fileName.ToLower());
            sbr.AppendFormat("        {0}Table = {{ }}\r\n", fileName.ToLower());
            sbr.AppendFormat("        {0}TableDic = {{ }}\r\n", fileName.ToLower());
            sbr.AppendFormat("    end\r\n");
            sbr.AppendFormat("end");

            using (FileStream fs = new FileStream(string.Format("{0}/{1}DBModel.bytes", Config.ClientOutLuaFilePath, fileName), FileMode.Create))
            {
                if (!Directory.Exists(Config.ClientOutLuaFilePath))
                {
                    Directory.CreateDirectory(Config.ClientOutLuaFilePath);
                }
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(sbr.ToString());
                }
            }
        }
        #endregion

        private static void DataTableDefine()
        {
            StringBuilder sbr = new StringBuilder();

            sbr.Append("public sealed class DataTableDefine\r\n");
            sbr.Append("{\r\n");

            foreach (DataTableHeadData dataTableHeadData in CurrTableHead.TableHeadDataList)
            {
                if (Config.CSharpTableList.Find((TableListItem item) => item.TableName == dataTableHeadData.TableName) != null)
                {
                    sbr.AppendFormat("    public const string {0}Name = \"{0}\";\r\n", dataTableHeadData.TableName);
                    sbr.AppendFormat("    public const int {0}Version = {1};\r\n", dataTableHeadData.TableName, dataTableHeadData.TableFieldDataList.Count);
                }
            }
            sbr.Append("}");
            string path = string.Format("{0}/DataTableDefine.cs", Config.ClientOutCSharpFilePath);
            if (!Directory.Exists(Config.ClientOutCSharpFilePath))
            {
                Directory.CreateDirectory(Config.ClientOutCSharpFilePath);
            }
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(sbr.ToString());
                }
            }
        }

        #endregion

        #region 创建多语言表
        private static void CreateLocalization(string fileName, DataTable dt)
        {
            //try
            //{
            if (Directory.Exists(Config.ClientOutBytesFilePath + "/Localization"))
            {
                Directory.Delete(Config.ClientOutBytesFilePath + "/Localization", true);
            }
            Directory.CreateDirectory(Config.ClientOutBytesFilePath + "/Localization");

            int rows = dt.Rows.Count;
            int columns = dt.Columns.Count;

            int newcolumns = columns - 3; //减去前三列 后面表示有多少种语言

            int currKeyColumn = 2; //当前的Key列
            int currValueColumn = 3; //当前的值列

            string[,] tableHeadArr = new string[columns, 3];

            while (newcolumns > 0)
            {
                newcolumns--;

                FlatBufferBuilder builder = new FlatBufferBuilder(1);
                Dictionary<int, int> m_Offset = new Dictionary<int, int>();
                Dictionary<int, StringOffset> m_ColumnStringOffset = new Dictionary<int, StringOffset>();

                for (int i = 0; i < rows; i++)
                {


                    m_ColumnStringOffset.Clear();

                    string key = string.Empty;
                    string value = string.Empty;

                    for (int j = 0; j < columns; j++)
                    {
                        if (i < 3)
                        {
                            tableHeadArr[j, i] = dt.Rows[i][j].ToString().Trim();
                        }
                        else
                        {
                            if (j == currKeyColumn)
                            {
                                key = dt.Rows[i][j].ToString().Trim();
                            }
                            else if (j == currValueColumn)
                            {
                                value = dt.Rows[i][j].ToString().Trim();
                            }
                        }
                    }

                    StringOffset keyOffset = builder.CreateString(key);
                    StringOffset valueOffset = builder.CreateString(value);

                    builder.StartTable(2);
                    builder.AddOffset(1, valueOffset.Value, 0);
                    builder.AddOffset(0, keyOffset.Value, 0);
                    int rowOffset = builder.EndTable();
                    m_Offset[i - 3] = rowOffset;

                }
                builder.StartVector(4, rows - 3, 4);
                for (int i = rows - 4; i >= 0; i--)
                {
                    builder.AddOffset(m_Offset[i]);
                }
                var offset = builder.EndVector();

                builder.StartTable(1);
                builder.AddOffset(0, offset.Value, 0);
                int eab = builder.EndTable(); //获得结束为止
                builder.Finish(eab);
                byte[] buffer = builder.SizedByteArray();
                buffer = ZlibHelper.CompressBytes(buffer);

                //------------------
                //写入文件
                //------------------
                if (!Directory.Exists(Config.ClientOutBytesFilePath))
                {
                    Directory.CreateDirectory(Config.ClientOutBytesFilePath);
                }
                FileStream fs = new FileStream(string.Format("{0}/Localization/{1}", Config.ClientOutBytesFilePath, tableHeadArr[currValueColumn, 0] + ".bytes"), FileMode.Create);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();

                currValueColumn++;
            }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("表格=>" + fileName + " 处理失败:" + ex.Message);
            //}
        }
        #endregion

        /// <summary>
        /// 创建系统配置表
        /// </summary>
        private static void CreateSysConfig(Config.SysTable sysTable)
        {
            DataTable dt = null;
            DataTableDic.TryGetValue(sysTable.TableName, out dt);
            if (dt == null)
            {
                Console.WriteLine("配置表=>" + sysTable.TableName + " 不存在");
                return;
            }

            int rows = dt.Rows.Count;
            int columns = dt.Columns.Count;
            if (columns < 5)
            {
                Console.WriteLine("配置表=>" + sysTable.TableName + " 不符合规范");
                return;
            }

            if (dt.Columns[0].ColumnName != "Id"
                || dt.Columns[1].ColumnName != "Desc"
                || dt.Columns[2].ColumnName != "Name"
                || dt.Columns[3].ColumnName != "Type"
                || dt.Columns[4].ColumnName != "Value"
            )
            {
                Console.WriteLine("配置表=>" + sysTable.TableName + " 不符合规范");
                return;
            }



            //客户端c#
            string clientCsharpFileName = sysTable.ClientCSharpFilePath.Replace("\\", "/").Substring(sysTable.ClientCSharpFilePath.LastIndexOf("/") + 1
                ).Replace(".cs", "");

            StringBuilder sbrClientCsharp = new StringBuilder();

            sbrClientCsharp.AppendFormat("public class {0}\r\n", clientCsharpFileName);
            sbrClientCsharp.Append("{\r\n");

            //服务器c#
            string serverCsharpFileName = sysTable.ServerCSharpFilePath.Substring(sysTable.ServerCSharpFilePath.LastIndexOf("/") + 1
                ).Replace(".cs", "");

            StringBuilder sbrServerCsharp = new StringBuilder();

            sbrServerCsharp.AppendFormat("public class {0}\r\n", serverCsharpFileName);
            sbrServerCsharp.Append("{\r\n");


            //客户端lua
            string clientLuaFileName = sysTable.ClientLuaFilePath.Substring(sysTable.ClientLuaFilePath.LastIndexOf("/") + 1
    ).Replace(".bytes", "");
            StringBuilder sbrClientLua = new StringBuilder();

            sbrClientLua.AppendFormat("{0} = {{\r\n", clientLuaFileName);
            sbrClientLua.Append("\r\n");

            for (int i = 3; i < rows; i++)
            {
                // string id = dt.Rows[i][0].ToString();-
                string desc = dt.Rows[i][1].ToString();
                string name = dt.Rows[i][2].ToString();
                string type = dt.Rows[i][3].ToString();
                string value = dt.Rows[i][4].ToString();

                //客户端c#
                sbrClientCsharp.Append("    /// <summary>\r\n");
                sbrClientCsharp.AppendFormat("    /// {0}\r\n", desc);
                sbrClientCsharp.Append("    /// </summary>\r\n");
                sbrClientCsharp.AppendFormat(
                    type != null && type.Equals("string", StringComparison.CurrentCultureIgnoreCase)
                        ? "    public const {0} {1} = \"{2}\";\r\n"
                        : "    public const {0} {1} = {2};\r\n", type, name, value);

                sbrClientCsharp.Append("\r\n");

                //服务器c#
                sbrServerCsharp.Append("    /// <summary>\r\n");
                sbrServerCsharp.AppendFormat("    /// {0}\r\n", desc);
                sbrServerCsharp.Append("    /// </summary>\r\n");
                sbrServerCsharp.AppendFormat(
                    type != null && type.Equals("string", StringComparison.CurrentCultureIgnoreCase)
                        ? "    public const {0} {1} = \"{2}\";\r\n"
                        : "    public const {0} {1} = {2};\r\n", type, name, value);
                sbrServerCsharp.Append("\r\n");

                //客户端lua
                sbrClientLua.AppendFormat("    --{0}\r\n", desc);
                if (type != null && type.Equals("string", StringComparison.CurrentCultureIgnoreCase))
                {
                    sbrClientLua.AppendFormat("    {0} = \"{1}\",\r\n", name, value);
                }
                else
                {
                    sbrClientLua.AppendFormat("    {0} = {1},\r\n", name, value);
                }

                sbrClientLua.Append("\r\n");
            }

            //客户端c#
            sbrClientCsharp.Append("}");

            //服务器c#
            sbrServerCsharp.Append("}");

            //客户端lua
            sbrClientLua.Append("}");

            //客户端c#
            if (!string.IsNullOrEmpty(sysTable.ClientCSharpFilePath))
            {
                string clientCsharpFileFoler = sysTable.ClientCSharpFilePath.Substring(0, sysTable.ClientCSharpFilePath.LastIndexOf("/"));
                if (!Directory.Exists(clientCsharpFileFoler))
                {
                    Directory.CreateDirectory(clientCsharpFileFoler);
                }
                using (FileStream fs = new FileStream(sysTable.ClientCSharpFilePath, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(sbrClientCsharp.ToString());
                    }
                }
            }

            //服务器c#
            if (!string.IsNullOrEmpty(sysTable.ServerCSharpFilePath))
            {
                string serverCsharpFileFoler = sysTable.ServerCSharpFilePath.Substring(0, sysTable.ServerCSharpFilePath.LastIndexOf("/"));
                if (!Directory.Exists(serverCsharpFileFoler))
                {
                    Directory.CreateDirectory(serverCsharpFileFoler);
                }
                using (FileStream fs = new FileStream(sysTable.ServerCSharpFilePath, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(sbrServerCsharp.ToString());
                    }
                }
            }

            //客户端lua
            if (!string.IsNullOrEmpty(sysTable.ClientLuaFilePath))
            {
                string clientLuaFileFoler = sysTable.ClientLuaFilePath.Substring(0, sysTable.ClientLuaFilePath.LastIndexOf("/"));
                if (!Directory.Exists(clientLuaFileFoler))
                {
                    Directory.CreateDirectory(clientLuaFileFoler);
                }
                using (FileStream fs = new FileStream(sysTable.ClientLuaFilePath, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(sbrClientLua.ToString());
                    }
                }
            }

            Console.WriteLine("配置表=>" + sysTable.TableName + " 处理完毕");
        }

        #region CreateSysTable 创建提供表代码
        /// <summary>
        /// 创建提供表代码
        /// </summary>
        private static void CreateSysTable()
        {
            List<Config.SysTable> lst = Config.SysTables;
            int len = lst.Count;
            for (int i = 0; i < len; i++)
            {
                Console.WriteLine("配置表 TableName=>" + lst[i].TableName + " 处理中");
                if (lst[i].TableName.Equals("DTSys_Config", StringComparison.CurrentCultureIgnoreCase))
                {
                    CreateSysConfig(lst[i]);
                }
                else
                {
                    CreateSysTable(lst[i]);
                }
            }
        }

        private static void CreateSysTable(Config.SysTable sysTable)
        {
            DataTable dt = null;
            DataTableDic.TryGetValue(sysTable.TableName, out dt);
            if (dt == null)
            {
                Console.WriteLine("系统表=>" + sysTable.TableName + " 不符合规范");
                return;
            }

            int rows = dt.Rows.Count;
            int columns = dt.Columns.Count;
            if (columns < 3)
            {
                Console.WriteLine("系统表=>" + sysTable.TableName + " 不符合规范");
                return;
            }
            if (dt.Columns[0].ColumnName != "Id"
                || dt.Columns[1].ColumnName != "Desc"
                || dt.Columns[2].ColumnName != "Name"
                )
            {
                Console.WriteLine("系统表=>" + sysTable.TableName + " 不符合规范");
                return;
            }

            //客户端c#
            string clientCsharpFileName = sysTable.ClientCSharpFilePath.Substring(sysTable.ClientCSharpFilePath.LastIndexOf("/") + 1
                ).Replace(".cs", "");

            StringBuilder sbrClientCsharp = new StringBuilder();

            sbrClientCsharp.AppendFormat("public class {0}\r\n", clientCsharpFileName);
            sbrClientCsharp.Append("{\r\n");

            //服务器c#
            string serverCsharpFileName = sysTable.ServerCSharpFilePath.Substring(sysTable.ServerCSharpFilePath.LastIndexOf("/") + 1
                ).Replace(".cs", "");

            StringBuilder sbrServerCsharp = new StringBuilder();

            sbrServerCsharp.AppendFormat("public class {0}\r\n", serverCsharpFileName);
            sbrServerCsharp.Append("{\r\n");


            //客户端lua
            string clientLuaFileName = sysTable.ClientLuaFilePath.Substring(sysTable.ClientLuaFilePath.LastIndexOf("/") + 1
    ).Replace(".bytes", "");
            StringBuilder sbrClientLua = new StringBuilder();

            sbrClientLua.AppendFormat("{0} = {{\r\n", clientLuaFileName);
            sbrClientLua.Append("\r\n");

            for (int i = 3; i < rows; i++)
            {
                string id = dt.Rows[i][0].ToString();
                string desc = dt.Rows[i][1].ToString();
                string name = dt.Rows[i][2].ToString();

                //客户端c#
                sbrClientCsharp.Append("    /// <summary>\r\n");
                sbrClientCsharp.AppendFormat("    /// {0}\r\n", desc);
                sbrClientCsharp.Append("    /// </summary>\r\n");
                sbrClientCsharp.AppendFormat("    public const int {0} = {1};\r\n", name, id);
                sbrClientCsharp.Append("\r\n");

                //服务器c#
                sbrServerCsharp.Append("    /// <summary>\r\n");
                sbrServerCsharp.AppendFormat("    /// {0}\r\n", desc);
                sbrServerCsharp.Append("    /// </summary>\r\n");
                sbrServerCsharp.AppendFormat("    public const int {0} = {1};\r\n", name, id);
                sbrServerCsharp.Append("\r\n");

                //客户端lua
                sbrClientLua.AppendFormat("    --{0}\r\n", desc);
                sbrClientLua.AppendFormat("    {0} = {1},\r\n", name, id);
                sbrClientLua.Append("\r\n");
            }

            //客户端c#
            sbrClientCsharp.Append("}");

            //服务器c#
            sbrServerCsharp.Append("}");

            //客户端lua
            sbrClientLua.Append("}");

            //客户端c#
            if (!string.IsNullOrEmpty(sysTable.ClientCSharpFilePath))
            {
                string clientCsharpFileFoler = sysTable.ClientCSharpFilePath.Substring(0, sysTable.ClientCSharpFilePath.LastIndexOf("/"));
                if (!Directory.Exists(clientCsharpFileFoler))
                {
                    Directory.CreateDirectory(clientCsharpFileFoler);
                }
                using (FileStream fs = new FileStream(sysTable.ClientCSharpFilePath, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(sbrClientCsharp.ToString());
                    }
                }
            }

            //服务器c#
            if (!string.IsNullOrEmpty(sysTable.ServerCSharpFilePath))
            {
                string serverCsharpFileFoler = sysTable.ServerCSharpFilePath.Substring(0, sysTable.ServerCSharpFilePath.LastIndexOf("/"));
                if (!Directory.Exists(serverCsharpFileFoler))
                {
                    Directory.CreateDirectory(serverCsharpFileFoler);
                }
                using (FileStream fs = new FileStream(sysTable.ServerCSharpFilePath, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(sbrServerCsharp.ToString());
                    }
                }
            }

            //客户端lua
            if (!string.IsNullOrEmpty(sysTable.ClientLuaFilePath))
            {
                string clientLuaFileFoler = sysTable.ClientLuaFilePath.Substring(0, sysTable.ClientLuaFilePath.LastIndexOf("/"));
                if (!Directory.Exists(clientLuaFileFoler))
                {
                    Directory.CreateDirectory(clientLuaFileFoler);
                }
                using (FileStream fs = new FileStream(sysTable.ClientLuaFilePath, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(sbrClientLua.ToString());
                    }
                }
            }

            Console.WriteLine("系统表=>" + sysTable.TableName + " 处理完毕");
        }
        #endregion

        /// <summary>
        /// 所有表表头
        /// </summary>
        private static DataTableHead CurrTableHead;

        #region 创建表头

        private static void CreateTableHead()
        {

            StringBuilder sbr = new StringBuilder();
            sbr.Append("namespace HHFramework.DataTable;");
            sbr.Append("\r\n");

            foreach (DataTableHeadData dataTableHeadData in CurrTableHead.TableHeadDataList)
            {
                //if (Config.CSharpTableList.Find((TableListItem item) =>
                //        item.TableName == dataTableHeadData.TableName) != null)
                //{
                sbr.AppendFormat("\r\n");
                sbr.AppendFormat("table {0} {{\r\n", dataTableHeadData.TableName);

                string str = string.Empty;
                foreach (DataTableFieldData field in dataTableHeadData.TableFieldDataList)
                {
                    if (field.IsListField)
                    {
                        str += string.Format("	{0}:[{1}];\r\n", field.FieldName, ChangeByteType(field.FieldType));
                    }
                    else
                    {
                        string dataType = field.FieldType.Trim().ToLower();
                        if (dataType == "int_1"
                            || dataType == "string_1"
                            || dataType == "float_1"
                            )
                        {
                            str += string.Format("	{0}:[{1}];\r\n", field.FieldName, ChangeByteType(field.FieldType));
                        }
                        else
                        {
                            str += string.Format("	{0}:{1};\r\n", field.FieldName, ChangeByteType(field.FieldType));
                        }
                    }
                }

                sbr.AppendFormat("{0}}}\r\n", str);

                sbr.AppendFormat("table {0}List {{\r\n", dataTableHeadData.TableName);
                sbr.AppendFormat("	{0}s:[{0}];\r\n", dataTableHeadData.TableName);
                sbr.AppendFormat("}}\r\n");

                //sbr.AppendFormat("root_type {0};\r\n", dataTableHeadData.TableName);
                //sbr.AppendFormat("root_type {0}List;\r\n", dataTableHeadData.TableName);
                //}
            }

            sbr.AppendFormat("table DTSys_Localization {{\r\n");
            sbr.AppendFormat("	Key: string;\r\n");
            sbr.AppendFormat("	Value: string;\r\n");
            sbr.AppendFormat("}}\r\n");
            sbr.AppendFormat("table DTSys_LocalizationList {{\r\n");
            sbr.AppendFormat("	DTSys_Localizations:[DTSys_Localization];\r\n");
            sbr.AppendFormat("}}\r\n");

            //存储
            //------------------
            //写入文件
            using (FileStream fs = new FileStream(Config.FlatcPath + "/AllTables.fbs", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(sbr.ToString());
                }
            }

            //创建c#文件
            //执行Flatc.exe
            Process.Start(Config.FlatcPath + "/flatc.exe", "--csharp -o " + Config.FlatcPath + "/Resource/DataTableCS " + Config.FlatcPath + "/AllTables.fbs");

            Console.WriteLine("等待创建文件");
            Thread.Sleep(500);//
            //File.Delete(Config.FlatcPath + "/AllTables.fbs");
            //把这些文件复制到目标目录
            string[] files = Directory.GetFiles(Config.FlatcPath + "/Resource/DataTableCS/HHFramework/DataTable");
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                if (!string.IsNullOrEmpty(Config.ClientOutCSharpFilePath))
                {
                    File.Copy(fileInfo.FullName, Config.ClientOutCSharpFilePath + "/" + fileInfo.Name, true);
                }

                if (!string.IsNullOrEmpty(Config.ServerOutCSharpFilePath))
                {
                    File.Copy(fileInfo.FullName, Config.ServerOutCSharpFilePath + "/" + fileInfo.Name, true);
                }
            }

            Console.WriteLine("创建文件完毕");
        }

        private static string ChangeByteType(string fieldType)
        {
            if (fieldType.Equals("byte", StringComparison.CurrentCultureIgnoreCase))
            {
                return "ubyte";
            }
            else if (fieldType.Equals("sbyte", StringComparison.CurrentCultureIgnoreCase))
            {
                return "sbyte";
            }
            else if (fieldType.Equals("int_1", StringComparison.CurrentCultureIgnoreCase))
            {
                return "int";
            }
            else if (fieldType.Equals("string_1", StringComparison.CurrentCultureIgnoreCase))
            {
                return "string";
            }
            else if (fieldType.Equals("float_1", StringComparison.CurrentCultureIgnoreCase))
            {
                return "float";
            }
            return fieldType;
        }

        #endregion
    }
}
