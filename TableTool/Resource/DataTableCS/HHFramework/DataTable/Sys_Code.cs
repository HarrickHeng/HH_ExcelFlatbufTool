// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct Sys_Code : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static Sys_Code GetRootAsSys_Code(ByteBuffer _bb) { return GetRootAsSys_Code(_bb, new Sys_Code()); }
  public static Sys_Code GetRootAsSys_Code(ByteBuffer _bb, Sys_Code obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Sys_Code __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string Desc { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetDescBytes() { return __p.__vector_as_span<byte>(6, 1); }
#else
  public ArraySegment<byte>? GetDescBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetDescArray() { return __p.__vector_as_array<byte>(6); }
  public string Key { get { int o = __p.__offset(8); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetKeyBytes() { return __p.__vector_as_span<byte>(8, 1); }
#else
  public ArraySegment<byte>? GetKeyBytes() { return __p.__vector_as_arraysegment(8); }
#endif
  public byte[] GetKeyArray() { return __p.__vector_as_array<byte>(8); }

  public static Offset<HHFramework.DataTable.Sys_Code> CreateSys_Code(FlatBufferBuilder builder,
      int Id = 0,
      StringOffset DescOffset = default(StringOffset),
      StringOffset KeyOffset = default(StringOffset)) {
    builder.StartTable(3);
    Sys_Code.AddKey(builder, KeyOffset);
    Sys_Code.AddDesc(builder, DescOffset);
    Sys_Code.AddId(builder, Id);
    return Sys_Code.EndSys_Code(builder);
  }

  public static void StartSys_Code(FlatBufferBuilder builder) { builder.StartTable(3); }
  public static void AddId(FlatBufferBuilder builder, int Id) { builder.AddInt(0, Id, 0); }
  public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset) { builder.AddOffset(1, DescOffset.Value, 0); }
  public static void AddKey(FlatBufferBuilder builder, StringOffset KeyOffset) { builder.AddOffset(2, KeyOffset.Value, 0); }
  public static Offset<HHFramework.DataTable.Sys_Code> EndSys_Code(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.Sys_Code>(o);
  }
}


}
