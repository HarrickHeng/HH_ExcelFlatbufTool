// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DTRoleAnimCategory : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static DTRoleAnimCategory GetRootAsDTRoleAnimCategory(ByteBuffer _bb) { return GetRootAsDTRoleAnimCategory(_bb, new DTRoleAnimCategory()); }
  public static DTRoleAnimCategory GetRootAsDTRoleAnimCategory(ByteBuffer _bb, DTRoleAnimCategory obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DTRoleAnimCategory __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public string Desc { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetDescBytes() { return __p.__vector_as_span<byte>(6, 1); }
#else
  public ArraySegment<byte>? GetDescBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetDescArray() { return __p.__vector_as_array<byte>(6); }
  public int IdleNormalAnimId { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int RunAnimId { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int HurtAnimId { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Attack(int j) { int o = __p.__offset(14); return o != 0 ? __p.bb.GetInt(__p.__vector(o) + j * 4) : (int)0; }
  public int AttackLength { get { int o = __p.__offset(14); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<int> GetAttackBytes() { return __p.__vector_as_span<int>(14, 4); }
#else
  public ArraySegment<byte>? GetAttackBytes() { return __p.__vector_as_arraysegment(14); }
#endif
  public int[] GetAttackArray() { return __p.__vector_as_array<int>(14); }
  public int Die { get { int o = __p.__offset(16); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }

  public static Offset<HHFramework.DataTable.DTRoleAnimCategory> CreateDTRoleAnimCategory(FlatBufferBuilder builder,
      int Id = 0,
      StringOffset DescOffset = default(StringOffset),
      int IdleNormalAnimId = 0,
      int RunAnimId = 0,
      int HurtAnimId = 0,
      VectorOffset AttackOffset = default(VectorOffset),
      int Die = 0) {
    builder.StartTable(7);
    DTRoleAnimCategory.AddDie(builder, Die);
    DTRoleAnimCategory.AddAttack(builder, AttackOffset);
    DTRoleAnimCategory.AddHurtAnimId(builder, HurtAnimId);
    DTRoleAnimCategory.AddRunAnimId(builder, RunAnimId);
    DTRoleAnimCategory.AddIdleNormalAnimId(builder, IdleNormalAnimId);
    DTRoleAnimCategory.AddDesc(builder, DescOffset);
    DTRoleAnimCategory.AddId(builder, Id);
    return DTRoleAnimCategory.EndDTRoleAnimCategory(builder);
  }

  public static void StartDTRoleAnimCategory(FlatBufferBuilder builder) { builder.StartTable(7); }
  public static void AddId(FlatBufferBuilder builder, int Id) { builder.AddInt(0, Id, 0); }
  public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset) { builder.AddOffset(1, DescOffset.Value, 0); }
  public static void AddIdleNormalAnimId(FlatBufferBuilder builder, int IdleNormalAnimId) { builder.AddInt(2, IdleNormalAnimId, 0); }
  public static void AddRunAnimId(FlatBufferBuilder builder, int RunAnimId) { builder.AddInt(3, RunAnimId, 0); }
  public static void AddHurtAnimId(FlatBufferBuilder builder, int HurtAnimId) { builder.AddInt(4, HurtAnimId, 0); }
  public static void AddAttack(FlatBufferBuilder builder, VectorOffset AttackOffset) { builder.AddOffset(5, AttackOffset.Value, 0); }
  public static VectorOffset CreateAttackVector(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddInt(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateAttackVectorBlock(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateAttackVectorBlock(FlatBufferBuilder builder, ArraySegment<int> data) { builder.StartVector(4, data.Count, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateAttackVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<int>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartAttackVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddDie(FlatBufferBuilder builder, int Die) { builder.AddInt(6, Die, 0); }
  public static Offset<HHFramework.DataTable.DTRoleAnimCategory> EndDTRoleAnimCategory(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.DTRoleAnimCategory>(o);
  }
}


}
