
using System.Collections.Generic;
using HH_ExcelFlatbufTool;

/// <summary>
/// 所有表头数据
/// </summary>
public class DataTableHead
{
    /// <summary>
    /// 表头列表
    /// </summary>
    public List<DataTableHeadData> TableHeadDataList;
}

/// <summary>
/// 一个表的表头
/// </summary>
public class DataTableHeadData
{
    /// <summary>
    /// 表名
    /// </summary>
    public string TableName;

    /// <summary>
    /// 字段列表
    /// </summary>
    public List<DataTableFieldData> TableFieldDataList;
}

/// <summary>
/// 字段
/// </summary>
public class DataTableFieldData
{
    /// <summary>
    /// 字段名称
    /// </summary>
    public string FieldName;

    /// <summary>
    /// 字段类型
    /// </summary>
    public string FieldType;

    /// <summary>
    /// 是否列表字段
    /// </summary>
    public bool IsListField;

    /// <summary>
    /// 字段值 这里用列表是考虑到有列表类型字段
    /// </summary>
    public List<string> FieldValues = new List<string>();
}