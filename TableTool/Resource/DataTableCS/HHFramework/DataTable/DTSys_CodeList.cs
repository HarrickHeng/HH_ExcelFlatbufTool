// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DTSys_CodeList : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static DTSys_CodeList GetRootAsDTSys_CodeList(ByteBuffer _bb) { return GetRootAsDTSys_CodeList(_bb, new DTSys_CodeList()); }
  public static DTSys_CodeList GetRootAsDTSys_CodeList(ByteBuffer _bb, DTSys_CodeList obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DTSys_CodeList __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public HHFramework.DataTable.DTSys_Code? DTSysCodes(int j) { int o = __p.__offset(4); return o != 0 ? (HHFramework.DataTable.DTSys_Code?)(new HHFramework.DataTable.DTSys_Code()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DTSysCodesLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<HHFramework.DataTable.DTSys_CodeList> CreateDTSys_CodeList(FlatBufferBuilder builder,
      VectorOffset DTSys_CodesOffset = default(VectorOffset)) {
    builder.StartTable(1);
    DTSys_CodeList.AddDTSysCodes(builder, DTSys_CodesOffset);
    return DTSys_CodeList.EndDTSys_CodeList(builder);
  }

  public static void StartDTSys_CodeList(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddDTSysCodes(FlatBufferBuilder builder, VectorOffset DTSysCodesOffset) { builder.AddOffset(0, DTSysCodesOffset.Value, 0); }
  public static VectorOffset CreateDTSysCodesVector(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTSys_Code>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateDTSysCodesVectorBlock(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTSys_Code>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTSysCodesVectorBlock(FlatBufferBuilder builder, ArraySegment<Offset<HHFramework.DataTable.DTSys_Code>> data) { builder.StartVector(4, data.Count, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTSysCodesVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<Offset<HHFramework.DataTable.DTSys_Code>>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartDTSysCodesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<HHFramework.DataTable.DTSys_CodeList> EndDTSys_CodeList(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.DTSys_CodeList>(o);
  }
}


}