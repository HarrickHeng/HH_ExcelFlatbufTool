// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DTGameLevel : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static DTGameLevel GetRootAsDTGameLevel(ByteBuffer _bb) { return GetRootAsDTGameLevel(_bb, new DTGameLevel()); }
  public static DTGameLevel GetRootAsDTGameLevel(ByteBuffer _bb, DTGameLevel obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DTGameLevel __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int ChapterID { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string Name { get { int o = __p.__offset(8); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetNameBytes() { return __p.__vector_as_span<byte>(8, 1); }
#else
  public ArraySegment<byte>? GetNameBytes() { return __p.__vector_as_arraysegment(8); }
#endif
  public byte[] GetNameArray() { return __p.__vector_as_array<byte>(8); }
  public string SceneName { get { int o = __p.__offset(10); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetSceneNameBytes() { return __p.__vector_as_span<byte>(10, 1); }
#else
  public ArraySegment<byte>? GetSceneNameBytes() { return __p.__vector_as_arraysegment(10); }
#endif
  public byte[] GetSceneNameArray() { return __p.__vector_as_array<byte>(10); }
  public string SmallMapImg { get { int o = __p.__offset(12); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetSmallMapImgBytes() { return __p.__vector_as_span<byte>(12, 1); }
#else
  public ArraySegment<byte>? GetSmallMapImgBytes() { return __p.__vector_as_arraysegment(12); }
#endif
  public byte[] GetSmallMapImgArray() { return __p.__vector_as_array<byte>(12); }
  public int IsBoss { get { int o = __p.__offset(14); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string Ico { get { int o = __p.__offset(16); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetIcoBytes() { return __p.__vector_as_span<byte>(16, 1); }
#else
  public ArraySegment<byte>? GetIcoBytes() { return __p.__vector_as_arraysegment(16); }
#endif
  public byte[] GetIcoArray() { return __p.__vector_as_array<byte>(16); }
  public string PosInMap { get { int o = __p.__offset(18); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetPosInMapBytes() { return __p.__vector_as_span<byte>(18, 1); }
#else
  public ArraySegment<byte>? GetPosInMapBytes() { return __p.__vector_as_arraysegment(18); }
#endif
  public byte[] GetPosInMapArray() { return __p.__vector_as_array<byte>(18); }
  public string DlgPic { get { int o = __p.__offset(20); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetDlgPicBytes() { return __p.__vector_as_span<byte>(20, 1); }
#else
  public ArraySegment<byte>? GetDlgPicBytes() { return __p.__vector_as_arraysegment(20); }
#endif
  public byte[] GetDlgPicArray() { return __p.__vector_as_array<byte>(20); }
  public string CameraRotation { get { int o = __p.__offset(22); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetCameraRotationBytes() { return __p.__vector_as_span<byte>(22, 1); }
#else
  public ArraySegment<byte>? GetCameraRotationBytes() { return __p.__vector_as_arraysegment(22); }
#endif
  public byte[] GetCameraRotationArray() { return __p.__vector_as_array<byte>(22); }
  public string AudioBG { get { int o = __p.__offset(24); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetAudioBGBytes() { return __p.__vector_as_span<byte>(24, 1); }
#else
  public ArraySegment<byte>? GetAudioBGBytes() { return __p.__vector_as_arraysegment(24); }
#endif
  public byte[] GetAudioBGArray() { return __p.__vector_as_array<byte>(24); }

  public static Offset<HHFramework.DataTable.DTGameLevel> CreateDTGameLevel(FlatBufferBuilder builder,
      int Id = 0,
      int ChapterID = 0,
      StringOffset NameOffset = default(StringOffset),
      StringOffset SceneNameOffset = default(StringOffset),
      StringOffset SmallMapImgOffset = default(StringOffset),
      int isBoss = 0,
      StringOffset IcoOffset = default(StringOffset),
      StringOffset PosInMapOffset = default(StringOffset),
      StringOffset DlgPicOffset = default(StringOffset),
      StringOffset CameraRotationOffset = default(StringOffset),
      StringOffset Audio_BGOffset = default(StringOffset)) {
    builder.StartTable(11);
    DTGameLevel.AddAudioBG(builder, Audio_BGOffset);
    DTGameLevel.AddCameraRotation(builder, CameraRotationOffset);
    DTGameLevel.AddDlgPic(builder, DlgPicOffset);
    DTGameLevel.AddPosInMap(builder, PosInMapOffset);
    DTGameLevel.AddIco(builder, IcoOffset);
    DTGameLevel.AddIsBoss(builder, isBoss);
    DTGameLevel.AddSmallMapImg(builder, SmallMapImgOffset);
    DTGameLevel.AddSceneName(builder, SceneNameOffset);
    DTGameLevel.AddName(builder, NameOffset);
    DTGameLevel.AddChapterID(builder, ChapterID);
    DTGameLevel.AddId(builder, Id);
    return DTGameLevel.EndDTGameLevel(builder);
  }

  public static void StartDTGameLevel(FlatBufferBuilder builder) { builder.StartTable(11); }
  public static void AddId(FlatBufferBuilder builder, int Id) { builder.AddInt(0, Id, 0); }
  public static void AddChapterID(FlatBufferBuilder builder, int ChapterID) { builder.AddInt(1, ChapterID, 0); }
  public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset) { builder.AddOffset(2, NameOffset.Value, 0); }
  public static void AddSceneName(FlatBufferBuilder builder, StringOffset SceneNameOffset) { builder.AddOffset(3, SceneNameOffset.Value, 0); }
  public static void AddSmallMapImg(FlatBufferBuilder builder, StringOffset SmallMapImgOffset) { builder.AddOffset(4, SmallMapImgOffset.Value, 0); }
  public static void AddIsBoss(FlatBufferBuilder builder, int isBoss) { builder.AddInt(5, isBoss, 0); }
  public static void AddIco(FlatBufferBuilder builder, StringOffset IcoOffset) { builder.AddOffset(6, IcoOffset.Value, 0); }
  public static void AddPosInMap(FlatBufferBuilder builder, StringOffset PosInMapOffset) { builder.AddOffset(7, PosInMapOffset.Value, 0); }
  public static void AddDlgPic(FlatBufferBuilder builder, StringOffset DlgPicOffset) { builder.AddOffset(8, DlgPicOffset.Value, 0); }
  public static void AddCameraRotation(FlatBufferBuilder builder, StringOffset CameraRotationOffset) { builder.AddOffset(9, CameraRotationOffset.Value, 0); }
  public static void AddAudioBG(FlatBufferBuilder builder, StringOffset AudioBGOffset) { builder.AddOffset(10, AudioBGOffset.Value, 0); }
  public static Offset<HHFramework.DataTable.DTGameLevel> EndDTGameLevel(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.DTGameLevel>(o);
  }
}


}