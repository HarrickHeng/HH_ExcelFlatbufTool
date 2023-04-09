// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DTJobList : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static DTJobList GetRootAsDTJobList(ByteBuffer _bb) { return GetRootAsDTJobList(_bb, new DTJobList()); }
  public static DTJobList GetRootAsDTJobList(ByteBuffer _bb, DTJobList obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DTJobList __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public HHFramework.DataTable.DTJob? DTJobs(int j) { int o = __p.__offset(4); return o != 0 ? (HHFramework.DataTable.DTJob?)(new HHFramework.DataTable.DTJob()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DTJobsLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<HHFramework.DataTable.DTJobList> CreateDTJobList(FlatBufferBuilder builder,
      VectorOffset DTJobsOffset = default(VectorOffset)) {
    builder.StartTable(1);
    DTJobList.AddDTJobs(builder, DTJobsOffset);
    return DTJobList.EndDTJobList(builder);
  }

  public static void StartDTJobList(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddDTJobs(FlatBufferBuilder builder, VectorOffset DTJobsOffset) { builder.AddOffset(0, DTJobsOffset.Value, 0); }
  public static VectorOffset CreateDTJobsVector(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTJob>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateDTJobsVectorBlock(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTJob>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTJobsVectorBlock(FlatBufferBuilder builder, ArraySegment<Offset<HHFramework.DataTable.DTJob>> data) { builder.StartVector(4, data.Count, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTJobsVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<Offset<HHFramework.DataTable.DTJob>>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartDTJobsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<HHFramework.DataTable.DTJobList> EndDTJobList(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.DTJobList>(o);
  }
}


}
