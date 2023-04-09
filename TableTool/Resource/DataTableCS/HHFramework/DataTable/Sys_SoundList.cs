// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct Sys_SoundList : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static Sys_SoundList GetRootAsSys_SoundList(ByteBuffer _bb) { return GetRootAsSys_SoundList(_bb, new Sys_SoundList()); }
  public static Sys_SoundList GetRootAsSys_SoundList(ByteBuffer _bb, Sys_SoundList obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Sys_SoundList __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public HHFramework.DataTable.Sys_Sound? SysSounds(int j) { int o = __p.__offset(4); return o != 0 ? (HHFramework.DataTable.Sys_Sound?)(new HHFramework.DataTable.Sys_Sound()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int SysSoundsLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<HHFramework.DataTable.Sys_SoundList> CreateSys_SoundList(FlatBufferBuilder builder,
      VectorOffset Sys_SoundsOffset = default(VectorOffset)) {
    builder.StartTable(1);
    Sys_SoundList.AddSysSounds(builder, Sys_SoundsOffset);
    return Sys_SoundList.EndSys_SoundList(builder);
  }

  public static void StartSys_SoundList(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddSysSounds(FlatBufferBuilder builder, VectorOffset SysSoundsOffset) { builder.AddOffset(0, SysSoundsOffset.Value, 0); }
  public static VectorOffset CreateSysSoundsVector(FlatBufferBuilder builder, Offset<HHFramework.DataTable.Sys_Sound>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateSysSoundsVectorBlock(FlatBufferBuilder builder, Offset<HHFramework.DataTable.Sys_Sound>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateSysSoundsVectorBlock(FlatBufferBuilder builder, ArraySegment<Offset<HHFramework.DataTable.Sys_Sound>> data) { builder.StartVector(4, data.Count, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateSysSoundsVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<Offset<HHFramework.DataTable.Sys_Sound>>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartSysSoundsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<HHFramework.DataTable.Sys_SoundList> EndSys_SoundList(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.Sys_SoundList>(o);
  }
}


}
