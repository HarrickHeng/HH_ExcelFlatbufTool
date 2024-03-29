// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DTGameLevelGrade : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static DTGameLevelGrade GetRootAsDTGameLevelGrade(ByteBuffer _bb) { return GetRootAsDTGameLevelGrade(_bb, new DTGameLevelGrade()); }
  public static DTGameLevelGrade GetRootAsDTGameLevelGrade(ByteBuffer _bb, DTGameLevelGrade obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DTGameLevelGrade __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int GameLevelId { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Grade { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string Desc { get { int o = __p.__offset(10); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetDescBytes() { return __p.__vector_as_span<byte>(10, 1); }
#else
  public ArraySegment<byte>? GetDescBytes() { return __p.__vector_as_arraysegment(10); }
#endif
  public byte[] GetDescArray() { return __p.__vector_as_array<byte>(10); }
  public int Type { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string Parameter { get { int o = __p.__offset(14); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetParameterBytes() { return __p.__vector_as_span<byte>(14, 1); }
#else
  public ArraySegment<byte>? GetParameterBytes() { return __p.__vector_as_arraysegment(14); }
#endif
  public byte[] GetParameterArray() { return __p.__vector_as_array<byte>(14); }
  public string ConditionDesc { get { int o = __p.__offset(16); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetConditionDescBytes() { return __p.__vector_as_span<byte>(16, 1); }
#else
  public ArraySegment<byte>? GetConditionDescBytes() { return __p.__vector_as_arraysegment(16); }
#endif
  public byte[] GetConditionDescArray() { return __p.__vector_as_array<byte>(16); }
  public int Exp { get { int o = __p.__offset(18); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Gold { get { int o = __p.__offset(20); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int CommendFighting { get { int o = __p.__offset(22); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public float TimeLimit { get { int o = __p.__offset(24); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  public float Star1 { get { int o = __p.__offset(26); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  public float Star2 { get { int o = __p.__offset(28); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  public string Equip { get { int o = __p.__offset(30); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetEquipBytes() { return __p.__vector_as_span<byte>(30, 1); }
#else
  public ArraySegment<byte>? GetEquipBytes() { return __p.__vector_as_arraysegment(30); }
#endif
  public byte[] GetEquipArray() { return __p.__vector_as_array<byte>(30); }
  public string Item { get { int o = __p.__offset(32); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetItemBytes() { return __p.__vector_as_span<byte>(32, 1); }
#else
  public ArraySegment<byte>? GetItemBytes() { return __p.__vector_as_arraysegment(32); }
#endif
  public byte[] GetItemArray() { return __p.__vector_as_array<byte>(32); }
  public string Material { get { int o = __p.__offset(34); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetMaterialBytes() { return __p.__vector_as_span<byte>(34, 1); }
#else
  public ArraySegment<byte>? GetMaterialBytes() { return __p.__vector_as_arraysegment(34); }
#endif
  public byte[] GetMaterialArray() { return __p.__vector_as_array<byte>(34); }

  public static Offset<HHFramework.DataTable.DTGameLevelGrade> CreateDTGameLevelGrade(FlatBufferBuilder builder,
      int Id = 0,
      int GameLevelId = 0,
      int Grade = 0,
      StringOffset DescOffset = default(StringOffset),
      int Type = 0,
      StringOffset ParameterOffset = default(StringOffset),
      StringOffset ConditionDescOffset = default(StringOffset),
      int Exp = 0,
      int Gold = 0,
      int CommendFighting = 0,
      float TimeLimit = 0.0f,
      float Star1 = 0.0f,
      float Star2 = 0.0f,
      StringOffset EquipOffset = default(StringOffset),
      StringOffset ItemOffset = default(StringOffset),
      StringOffset MaterialOffset = default(StringOffset)) {
    builder.StartTable(16);
    DTGameLevelGrade.AddMaterial(builder, MaterialOffset);
    DTGameLevelGrade.AddItem(builder, ItemOffset);
    DTGameLevelGrade.AddEquip(builder, EquipOffset);
    DTGameLevelGrade.AddStar2(builder, Star2);
    DTGameLevelGrade.AddStar1(builder, Star1);
    DTGameLevelGrade.AddTimeLimit(builder, TimeLimit);
    DTGameLevelGrade.AddCommendFighting(builder, CommendFighting);
    DTGameLevelGrade.AddGold(builder, Gold);
    DTGameLevelGrade.AddExp(builder, Exp);
    DTGameLevelGrade.AddConditionDesc(builder, ConditionDescOffset);
    DTGameLevelGrade.AddParameter(builder, ParameterOffset);
    DTGameLevelGrade.AddType(builder, Type);
    DTGameLevelGrade.AddDesc(builder, DescOffset);
    DTGameLevelGrade.AddGrade(builder, Grade);
    DTGameLevelGrade.AddGameLevelId(builder, GameLevelId);
    DTGameLevelGrade.AddId(builder, Id);
    return DTGameLevelGrade.EndDTGameLevelGrade(builder);
  }

  public static void StartDTGameLevelGrade(FlatBufferBuilder builder) { builder.StartTable(16); }
  public static void AddId(FlatBufferBuilder builder, int Id) { builder.AddInt(0, Id, 0); }
  public static void AddGameLevelId(FlatBufferBuilder builder, int GameLevelId) { builder.AddInt(1, GameLevelId, 0); }
  public static void AddGrade(FlatBufferBuilder builder, int Grade) { builder.AddInt(2, Grade, 0); }
  public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset) { builder.AddOffset(3, DescOffset.Value, 0); }
  public static void AddType(FlatBufferBuilder builder, int Type) { builder.AddInt(4, Type, 0); }
  public static void AddParameter(FlatBufferBuilder builder, StringOffset ParameterOffset) { builder.AddOffset(5, ParameterOffset.Value, 0); }
  public static void AddConditionDesc(FlatBufferBuilder builder, StringOffset ConditionDescOffset) { builder.AddOffset(6, ConditionDescOffset.Value, 0); }
  public static void AddExp(FlatBufferBuilder builder, int Exp) { builder.AddInt(7, Exp, 0); }
  public static void AddGold(FlatBufferBuilder builder, int Gold) { builder.AddInt(8, Gold, 0); }
  public static void AddCommendFighting(FlatBufferBuilder builder, int CommendFighting) { builder.AddInt(9, CommendFighting, 0); }
  public static void AddTimeLimit(FlatBufferBuilder builder, float TimeLimit) { builder.AddFloat(10, TimeLimit, 0.0f); }
  public static void AddStar1(FlatBufferBuilder builder, float Star1) { builder.AddFloat(11, Star1, 0.0f); }
  public static void AddStar2(FlatBufferBuilder builder, float Star2) { builder.AddFloat(12, Star2, 0.0f); }
  public static void AddEquip(FlatBufferBuilder builder, StringOffset EquipOffset) { builder.AddOffset(13, EquipOffset.Value, 0); }
  public static void AddItem(FlatBufferBuilder builder, StringOffset ItemOffset) { builder.AddOffset(14, ItemOffset.Value, 0); }
  public static void AddMaterial(FlatBufferBuilder builder, StringOffset MaterialOffset) { builder.AddOffset(15, MaterialOffset.Value, 0); }
  public static Offset<HHFramework.DataTable.DTGameLevelGrade> EndDTGameLevelGrade(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.DTGameLevelGrade>(o);
  }
}


}
