// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DTSys_LocalizationList : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static DTSys_LocalizationList GetRootAsDTSys_LocalizationList(ByteBuffer _bb) { return GetRootAsDTSys_LocalizationList(_bb, new DTSys_LocalizationList()); }
  public static DTSys_LocalizationList GetRootAsDTSys_LocalizationList(ByteBuffer _bb, DTSys_LocalizationList obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DTSys_LocalizationList __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public HHFramework.DataTable.DTSys_Localization? DTSysLocalizations(int j) { int o = __p.__offset(4); return o != 0 ? (HHFramework.DataTable.DTSys_Localization?)(new HHFramework.DataTable.DTSys_Localization()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DTSysLocalizationsLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<HHFramework.DataTable.DTSys_LocalizationList> CreateDTSys_LocalizationList(FlatBufferBuilder builder,
      VectorOffset DTSys_LocalizationsOffset = default(VectorOffset)) {
    builder.StartTable(1);
    DTSys_LocalizationList.AddDTSysLocalizations(builder, DTSys_LocalizationsOffset);
    return DTSys_LocalizationList.EndDTSys_LocalizationList(builder);
  }

  public static void StartDTSys_LocalizationList(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddDTSysLocalizations(FlatBufferBuilder builder, VectorOffset DTSysLocalizationsOffset) { builder.AddOffset(0, DTSysLocalizationsOffset.Value, 0); }
  public static VectorOffset CreateDTSysLocalizationsVector(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTSys_Localization>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateDTSysLocalizationsVectorBlock(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTSys_Localization>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTSysLocalizationsVectorBlock(FlatBufferBuilder builder, ArraySegment<Offset<HHFramework.DataTable.DTSys_Localization>> data) { builder.StartVector(4, data.Count, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTSysLocalizationsVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<Offset<HHFramework.DataTable.DTSys_Localization>>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartDTSysLocalizationsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<HHFramework.DataTable.DTSys_LocalizationList> EndDTSys_LocalizationList(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.DTSys_LocalizationList>(o);
  }
}


}
