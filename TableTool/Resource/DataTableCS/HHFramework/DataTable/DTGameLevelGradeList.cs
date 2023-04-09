// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DTGameLevelGradeList : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static DTGameLevelGradeList GetRootAsDTGameLevelGradeList(ByteBuffer _bb) { return GetRootAsDTGameLevelGradeList(_bb, new DTGameLevelGradeList()); }
  public static DTGameLevelGradeList GetRootAsDTGameLevelGradeList(ByteBuffer _bb, DTGameLevelGradeList obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DTGameLevelGradeList __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public HHFramework.DataTable.DTGameLevelGrade? DTGameLevelGrades(int j) { int o = __p.__offset(4); return o != 0 ? (HHFramework.DataTable.DTGameLevelGrade?)(new HHFramework.DataTable.DTGameLevelGrade()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DTGameLevelGradesLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<HHFramework.DataTable.DTGameLevelGradeList> CreateDTGameLevelGradeList(FlatBufferBuilder builder,
      VectorOffset DTGameLevelGradesOffset = default(VectorOffset)) {
    builder.StartTable(1);
    DTGameLevelGradeList.AddDTGameLevelGrades(builder, DTGameLevelGradesOffset);
    return DTGameLevelGradeList.EndDTGameLevelGradeList(builder);
  }

  public static void StartDTGameLevelGradeList(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddDTGameLevelGrades(FlatBufferBuilder builder, VectorOffset DTGameLevelGradesOffset) { builder.AddOffset(0, DTGameLevelGradesOffset.Value, 0); }
  public static VectorOffset CreateDTGameLevelGradesVector(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTGameLevelGrade>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateDTGameLevelGradesVectorBlock(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTGameLevelGrade>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTGameLevelGradesVectorBlock(FlatBufferBuilder builder, ArraySegment<Offset<HHFramework.DataTable.DTGameLevelGrade>> data) { builder.StartVector(4, data.Count, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTGameLevelGradesVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<Offset<HHFramework.DataTable.DTGameLevelGrade>>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartDTGameLevelGradesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<HHFramework.DataTable.DTGameLevelGradeList> EndDTGameLevelGradeList(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.DTGameLevelGradeList>(o);
  }
}


}