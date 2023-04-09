// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DTSys_Config : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static DTSys_Config GetRootAsDTSys_Config(ByteBuffer _bb) { return GetRootAsDTSys_Config(_bb, new DTSys_Config()); }
  public static DTSys_Config GetRootAsDTSys_Config(ByteBuffer _bb, DTSys_Config obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DTSys_Config __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string Desc { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetDescBytes() { return __p.__vector_as_span<byte>(6, 1); }
#else
  public ArraySegment<byte>? GetDescBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetDescArray() { return __p.__vector_as_array<byte>(6); }
  public string Name { get { int o = __p.__offset(8); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetNameBytes() { return __p.__vector_as_span<byte>(8, 1); }
#else
  public ArraySegment<byte>? GetNameBytes() { return __p.__vector_as_arraysegment(8); }
#endif
  public byte[] GetNameArray() { return __p.__vector_as_array<byte>(8); }
  public string Type { get { int o = __p.__offset(10); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetTypeBytes() { return __p.__vector_as_span<byte>(10, 1); }
#else
  public ArraySegment<byte>? GetTypeBytes() { return __p.__vector_as_arraysegment(10); }
#endif
  public byte[] GetTypeArray() { return __p.__vector_as_array<byte>(10); }
  public string Value { get { int o = __p.__offset(12); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetValueBytes() { return __p.__vector_as_span<byte>(12, 1); }
#else
  public ArraySegment<byte>? GetValueBytes() { return __p.__vector_as_arraysegment(12); }
#endif
  public byte[] GetValueArray() { return __p.__vector_as_array<byte>(12); }

  public static Offset<HHFramework.DataTable.DTSys_Config> CreateDTSys_Config(FlatBufferBuilder builder,
      int Id = 0,
      StringOffset DescOffset = default(StringOffset),
      StringOffset NameOffset = default(StringOffset),
      StringOffset TypeOffset = default(StringOffset),
      StringOffset ValueOffset = default(StringOffset)) {
    builder.StartTable(5);
    DTSys_Config.AddValue(builder, ValueOffset);
    DTSys_Config.AddType(builder, TypeOffset);
    DTSys_Config.AddName(builder, NameOffset);
    DTSys_Config.AddDesc(builder, DescOffset);
    DTSys_Config.AddId(builder, Id);
    return DTSys_Config.EndDTSys_Config(builder);
  }

  public static void StartDTSys_Config(FlatBufferBuilder builder) { builder.StartTable(5); }
  public static void AddId(FlatBufferBuilder builder, int Id) { builder.AddInt(0, Id, 0); }
  public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset) { builder.AddOffset(1, DescOffset.Value, 0); }
  public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset) { builder.AddOffset(2, NameOffset.Value, 0); }
  public static void AddType(FlatBufferBuilder builder, StringOffset TypeOffset) { builder.AddOffset(3, TypeOffset.Value, 0); }
  public static void AddValue(FlatBufferBuilder builder, StringOffset ValueOffset) { builder.AddOffset(4, ValueOffset.Value, 0); }
  public static Offset<HHFramework.DataTable.DTSys_Config> EndDTSys_Config(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.DTSys_Config>(o);
  }
}


}