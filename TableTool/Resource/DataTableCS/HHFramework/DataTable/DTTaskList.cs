// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DTTaskList : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static DTTaskList GetRootAsDTTaskList(ByteBuffer _bb) { return GetRootAsDTTaskList(_bb, new DTTaskList()); }
  public static DTTaskList GetRootAsDTTaskList(ByteBuffer _bb, DTTaskList obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DTTaskList __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public HHFramework.DataTable.DTTask? DTTasks(int j) { int o = __p.__offset(4); return o != 0 ? (HHFramework.DataTable.DTTask?)(new HHFramework.DataTable.DTTask()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DTTasksLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<HHFramework.DataTable.DTTaskList> CreateDTTaskList(FlatBufferBuilder builder,
      VectorOffset DTTasksOffset = default(VectorOffset)) {
    builder.StartTable(1);
    DTTaskList.AddDTTasks(builder, DTTasksOffset);
    return DTTaskList.EndDTTaskList(builder);
  }

  public static void StartDTTaskList(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddDTTasks(FlatBufferBuilder builder, VectorOffset DTTasksOffset) { builder.AddOffset(0, DTTasksOffset.Value, 0); }
  public static VectorOffset CreateDTTasksVector(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTTask>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateDTTasksVectorBlock(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTTask>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTTasksVectorBlock(FlatBufferBuilder builder, ArraySegment<Offset<HHFramework.DataTable.DTTask>> data) { builder.StartVector(4, data.Count, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTTasksVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<Offset<HHFramework.DataTable.DTTask>>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartDTTasksVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<HHFramework.DataTable.DTTaskList> EndDTTaskList(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.DTTaskList>(o);
  }
}


}