// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DTSys_UIForm : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static DTSys_UIForm GetRootAsDTSys_UIForm(ByteBuffer _bb) { return GetRootAsDTSys_UIForm(_bb, new DTSys_UIForm()); }
  public static DTSys_UIForm GetRootAsDTSys_UIForm(ByteBuffer _bb, DTSys_UIForm obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DTSys_UIForm __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

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
  public byte UIGroupId { get { int o = __p.__offset(10); return o != 0 ? __p.bb.Get(o + __p.bb_pos) : (byte)0; } }
  public int DisableUILayer { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int IsLock { get { int o = __p.__offset(14); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string AssetPathCN { get { int o = __p.__offset(16); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetAssetPathCNBytes() { return __p.__vector_as_span<byte>(16, 1); }
#else
  public ArraySegment<byte>? GetAssetPathCNBytes() { return __p.__vector_as_arraysegment(16); }
#endif
  public byte[] GetAssetPathCNArray() { return __p.__vector_as_array<byte>(16); }
  public string AssetPathEN { get { int o = __p.__offset(18); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetAssetPathENBytes() { return __p.__vector_as_span<byte>(18, 1); }
#else
  public ArraySegment<byte>? GetAssetPathENBytes() { return __p.__vector_as_arraysegment(18); }
#endif
  public byte[] GetAssetPathENArray() { return __p.__vector_as_array<byte>(18); }
  public bool CanMulit { get { int o = __p.__offset(20); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }
  public byte ShowMode { get { int o = __p.__offset(22); return o != 0 ? __p.bb.Get(o + __p.bb_pos) : (byte)0; } }
  public byte FreezeMode { get { int o = __p.__offset(24); return o != 0 ? __p.bb.Get(o + __p.bb_pos) : (byte)0; } }

  public static Offset<HHFramework.DataTable.DTSys_UIForm> CreateDTSys_UIForm(FlatBufferBuilder builder,
      int Id = 0,
      StringOffset DescOffset = default(StringOffset),
      StringOffset NameOffset = default(StringOffset),
      byte UIGroupId = 0,
      int DisableUILayer = 0,
      int IsLock = 0,
      StringOffset AssetPath_CNOffset = default(StringOffset),
      StringOffset AssetPath_ENOffset = default(StringOffset),
      bool CanMulit = false,
      byte ShowMode = 0,
      byte FreezeMode = 0) {
    builder.StartTable(11);
    DTSys_UIForm.AddAssetPathEN(builder, AssetPath_ENOffset);
    DTSys_UIForm.AddAssetPathCN(builder, AssetPath_CNOffset);
    DTSys_UIForm.AddIsLock(builder, IsLock);
    DTSys_UIForm.AddDisableUILayer(builder, DisableUILayer);
    DTSys_UIForm.AddName(builder, NameOffset);
    DTSys_UIForm.AddDesc(builder, DescOffset);
    DTSys_UIForm.AddId(builder, Id);
    DTSys_UIForm.AddFreezeMode(builder, FreezeMode);
    DTSys_UIForm.AddShowMode(builder, ShowMode);
    DTSys_UIForm.AddCanMulit(builder, CanMulit);
    DTSys_UIForm.AddUIGroupId(builder, UIGroupId);
    return DTSys_UIForm.EndDTSys_UIForm(builder);
  }

  public static void StartDTSys_UIForm(FlatBufferBuilder builder) { builder.StartTable(11); }
  public static void AddId(FlatBufferBuilder builder, int Id) { builder.AddInt(0, Id, 0); }
  public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset) { builder.AddOffset(1, DescOffset.Value, 0); }
  public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset) { builder.AddOffset(2, NameOffset.Value, 0); }
  public static void AddUIGroupId(FlatBufferBuilder builder, byte UIGroupId) { builder.AddByte(3, UIGroupId, 0); }
  public static void AddDisableUILayer(FlatBufferBuilder builder, int DisableUILayer) { builder.AddInt(4, DisableUILayer, 0); }
  public static void AddIsLock(FlatBufferBuilder builder, int IsLock) { builder.AddInt(5, IsLock, 0); }
  public static void AddAssetPathCN(FlatBufferBuilder builder, StringOffset AssetPathCNOffset) { builder.AddOffset(6, AssetPathCNOffset.Value, 0); }
  public static void AddAssetPathEN(FlatBufferBuilder builder, StringOffset AssetPathENOffset) { builder.AddOffset(7, AssetPathENOffset.Value, 0); }
  public static void AddCanMulit(FlatBufferBuilder builder, bool CanMulit) { builder.AddBool(8, CanMulit, false); }
  public static void AddShowMode(FlatBufferBuilder builder, byte ShowMode) { builder.AddByte(9, ShowMode, 0); }
  public static void AddFreezeMode(FlatBufferBuilder builder, byte FreezeMode) { builder.AddByte(10, FreezeMode, 0); }
  public static Offset<HHFramework.DataTable.DTSys_UIForm> EndDTSys_UIForm(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.DTSys_UIForm>(o);
  }
}


}
