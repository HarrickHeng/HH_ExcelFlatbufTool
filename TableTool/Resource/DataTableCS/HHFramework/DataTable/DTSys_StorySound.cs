// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DTSys_StorySound : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static DTSys_StorySound GetRootAsDTSys_StorySound(ByteBuffer _bb) { return GetRootAsDTSys_StorySound(_bb, new DTSys_StorySound()); }
  public static DTSys_StorySound GetRootAsDTSys_StorySound(ByteBuffer _bb, DTSys_StorySound obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DTSys_StorySound __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string Desc { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetDescBytes() { return __p.__vector_as_span<byte>(6, 1); }
#else
  public ArraySegment<byte>? GetDescBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetDescArray() { return __p.__vector_as_array<byte>(6); }
  public string AssetPathCN { get { int o = __p.__offset(8); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetAssetPathCNBytes() { return __p.__vector_as_span<byte>(8, 1); }
#else
  public ArraySegment<byte>? GetAssetPathCNBytes() { return __p.__vector_as_arraysegment(8); }
#endif
  public byte[] GetAssetPathCNArray() { return __p.__vector_as_array<byte>(8); }
  public string AssetPathEN { get { int o = __p.__offset(10); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetAssetPathENBytes() { return __p.__vector_as_span<byte>(10, 1); }
#else
  public ArraySegment<byte>? GetAssetPathENBytes() { return __p.__vector_as_arraysegment(10); }
#endif
  public byte[] GetAssetPathENArray() { return __p.__vector_as_array<byte>(10); }

  public static Offset<HHFramework.DataTable.DTSys_StorySound> CreateDTSys_StorySound(FlatBufferBuilder builder,
      int Id = 0,
      StringOffset DescOffset = default(StringOffset),
      StringOffset AssetPath_CNOffset = default(StringOffset),
      StringOffset AssetPath_ENOffset = default(StringOffset)) {
    builder.StartTable(4);
    DTSys_StorySound.AddAssetPathEN(builder, AssetPath_ENOffset);
    DTSys_StorySound.AddAssetPathCN(builder, AssetPath_CNOffset);
    DTSys_StorySound.AddDesc(builder, DescOffset);
    DTSys_StorySound.AddId(builder, Id);
    return DTSys_StorySound.EndDTSys_StorySound(builder);
  }

  public static void StartDTSys_StorySound(FlatBufferBuilder builder) { builder.StartTable(4); }
  public static void AddId(FlatBufferBuilder builder, int Id) { builder.AddInt(0, Id, 0); }
  public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset) { builder.AddOffset(1, DescOffset.Value, 0); }
  public static void AddAssetPathCN(FlatBufferBuilder builder, StringOffset AssetPathCNOffset) { builder.AddOffset(2, AssetPathCNOffset.Value, 0); }
  public static void AddAssetPathEN(FlatBufferBuilder builder, StringOffset AssetPathENOffset) { builder.AddOffset(3, AssetPathENOffset.Value, 0); }
  public static Offset<HHFramework.DataTable.DTSys_StorySound> EndDTSys_StorySound(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.DTSys_StorySound>(o);
  }
}


}
