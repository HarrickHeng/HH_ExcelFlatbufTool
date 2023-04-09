// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DTSys_AudioList : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static DTSys_AudioList GetRootAsDTSys_AudioList(ByteBuffer _bb) { return GetRootAsDTSys_AudioList(_bb, new DTSys_AudioList()); }
  public static DTSys_AudioList GetRootAsDTSys_AudioList(ByteBuffer _bb, DTSys_AudioList obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DTSys_AudioList __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public HHFramework.DataTable.DTSys_Audio? DTSysAudios(int j) { int o = __p.__offset(4); return o != 0 ? (HHFramework.DataTable.DTSys_Audio?)(new HHFramework.DataTable.DTSys_Audio()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DTSysAudiosLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<HHFramework.DataTable.DTSys_AudioList> CreateDTSys_AudioList(FlatBufferBuilder builder,
      VectorOffset DTSys_AudiosOffset = default(VectorOffset)) {
    builder.StartTable(1);
    DTSys_AudioList.AddDTSysAudios(builder, DTSys_AudiosOffset);
    return DTSys_AudioList.EndDTSys_AudioList(builder);
  }

  public static void StartDTSys_AudioList(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddDTSysAudios(FlatBufferBuilder builder, VectorOffset DTSysAudiosOffset) { builder.AddOffset(0, DTSysAudiosOffset.Value, 0); }
  public static VectorOffset CreateDTSysAudiosVector(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTSys_Audio>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateDTSysAudiosVectorBlock(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTSys_Audio>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTSysAudiosVectorBlock(FlatBufferBuilder builder, ArraySegment<Offset<HHFramework.DataTable.DTSys_Audio>> data) { builder.StartVector(4, data.Count, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTSysAudiosVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<Offset<HHFramework.DataTable.DTSys_Audio>>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartDTSysAudiosVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<HHFramework.DataTable.DTSys_AudioList> EndDTSys_AudioList(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.DTSys_AudioList>(o);
  }
}


}
