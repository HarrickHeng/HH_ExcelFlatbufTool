// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DTSys_Scene : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static DTSys_Scene GetRootAsDTSys_Scene(ByteBuffer _bb) { return GetRootAsDTSys_Scene(_bb, new DTSys_Scene()); }
  public static DTSys_Scene GetRootAsDTSys_Scene(ByteBuffer _bb, DTSys_Scene obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DTSys_Scene __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

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
  public string SceneName { get { int o = __p.__offset(10); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetSceneNameBytes() { return __p.__vector_as_span<byte>(10, 1); }
#else
  public ArraySegment<byte>? GetSceneNameBytes() { return __p.__vector_as_arraysegment(10); }
#endif
  public byte[] GetSceneNameArray() { return __p.__vector_as_array<byte>(10); }
  public int BGMId { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int SceneType { get { int o = __p.__offset(14); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public float PlayerBornPos(int j) { int o = __p.__offset(16); return o != 0 ? __p.bb.GetFloat(__p.__vector(o) + j * 4) : (float)0; }
  public int PlayerBornPosLength { get { int o = __p.__offset(16); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<float> GetPlayerBornPosBytes() { return __p.__vector_as_span<float>(16, 4); }
#else
  public ArraySegment<byte>? GetPlayerBornPosBytes() { return __p.__vector_as_arraysegment(16); }
#endif
  public float[] GetPlayerBornPosArray() { return __p.__vector_as_array<float>(16); }
  public int SceneLineMaxNumPeople { get { int o = __p.__offset(18); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int SceneMaxNumPeople { get { int o = __p.__offset(20); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }

  public static Offset<HHFramework.DataTable.DTSys_Scene> CreateDTSys_Scene(FlatBufferBuilder builder,
      int Id = 0,
      StringOffset DescOffset = default(StringOffset),
      StringOffset NameOffset = default(StringOffset),
      StringOffset SceneNameOffset = default(StringOffset),
      int BGMId = 0,
      int SceneType = 0,
      VectorOffset PlayerBornPosOffset = default(VectorOffset),
      int SceneLineMaxNumPeople = 0,
      int SceneMaxNumPeople = 0) {
    builder.StartTable(9);
    DTSys_Scene.AddSceneMaxNumPeople(builder, SceneMaxNumPeople);
    DTSys_Scene.AddSceneLineMaxNumPeople(builder, SceneLineMaxNumPeople);
    DTSys_Scene.AddPlayerBornPos(builder, PlayerBornPosOffset);
    DTSys_Scene.AddSceneType(builder, SceneType);
    DTSys_Scene.AddBGMId(builder, BGMId);
    DTSys_Scene.AddSceneName(builder, SceneNameOffset);
    DTSys_Scene.AddName(builder, NameOffset);
    DTSys_Scene.AddDesc(builder, DescOffset);
    DTSys_Scene.AddId(builder, Id);
    return DTSys_Scene.EndDTSys_Scene(builder);
  }

  public static void StartDTSys_Scene(FlatBufferBuilder builder) { builder.StartTable(9); }
  public static void AddId(FlatBufferBuilder builder, int Id) { builder.AddInt(0, Id, 0); }
  public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset) { builder.AddOffset(1, DescOffset.Value, 0); }
  public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset) { builder.AddOffset(2, NameOffset.Value, 0); }
  public static void AddSceneName(FlatBufferBuilder builder, StringOffset SceneNameOffset) { builder.AddOffset(3, SceneNameOffset.Value, 0); }
  public static void AddBGMId(FlatBufferBuilder builder, int BGMId) { builder.AddInt(4, BGMId, 0); }
  public static void AddSceneType(FlatBufferBuilder builder, int SceneType) { builder.AddInt(5, SceneType, 0); }
  public static void AddPlayerBornPos(FlatBufferBuilder builder, VectorOffset PlayerBornPosOffset) { builder.AddOffset(6, PlayerBornPosOffset.Value, 0); }
  public static VectorOffset CreatePlayerBornPosVector(FlatBufferBuilder builder, float[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddFloat(data[i]); return builder.EndVector(); }
  public static VectorOffset CreatePlayerBornPosVectorBlock(FlatBufferBuilder builder, float[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreatePlayerBornPosVectorBlock(FlatBufferBuilder builder, ArraySegment<float> data) { builder.StartVector(4, data.Count, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreatePlayerBornPosVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<float>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartPlayerBornPosVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddSceneLineMaxNumPeople(FlatBufferBuilder builder, int SceneLineMaxNumPeople) { builder.AddInt(7, SceneLineMaxNumPeople, 0); }
  public static void AddSceneMaxNumPeople(FlatBufferBuilder builder, int SceneMaxNumPeople) { builder.AddInt(8, SceneMaxNumPeople, 0); }
  public static Offset<HHFramework.DataTable.DTSys_Scene> EndDTSys_Scene(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.DTSys_Scene>(o);
  }
}


}
