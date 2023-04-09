// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DTSys_ConfigList : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static DTSys_ConfigList GetRootAsDTSys_ConfigList(ByteBuffer _bb) { return GetRootAsDTSys_ConfigList(_bb, new DTSys_ConfigList()); }
  public static DTSys_ConfigList GetRootAsDTSys_ConfigList(ByteBuffer _bb, DTSys_ConfigList obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DTSys_ConfigList __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public HHFramework.DataTable.DTSys_Config? DTSysConfigs(int j) { int o = __p.__offset(4); return o != 0 ? (HHFramework.DataTable.DTSys_Config?)(new HHFramework.DataTable.DTSys_Config()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DTSysConfigsLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<HHFramework.DataTable.DTSys_ConfigList> CreateDTSys_ConfigList(FlatBufferBuilder builder,
      VectorOffset DTSys_ConfigsOffset = default(VectorOffset)) {
    builder.StartTable(1);
    DTSys_ConfigList.AddDTSysConfigs(builder, DTSys_ConfigsOffset);
    return DTSys_ConfigList.EndDTSys_ConfigList(builder);
  }

  public static void StartDTSys_ConfigList(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddDTSysConfigs(FlatBufferBuilder builder, VectorOffset DTSysConfigsOffset) { builder.AddOffset(0, DTSysConfigsOffset.Value, 0); }
  public static VectorOffset CreateDTSysConfigsVector(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTSys_Config>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateDTSysConfigsVectorBlock(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTSys_Config>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTSysConfigsVectorBlock(FlatBufferBuilder builder, ArraySegment<Offset<HHFramework.DataTable.DTSys_Config>> data) { builder.StartVector(4, data.Count, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTSysConfigsVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<Offset<HHFramework.DataTable.DTSys_Config>>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartDTSysConfigsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<HHFramework.DataTable.DTSys_ConfigList> EndDTSys_ConfigList(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.DTSys_ConfigList>(o);
  }
}


}
