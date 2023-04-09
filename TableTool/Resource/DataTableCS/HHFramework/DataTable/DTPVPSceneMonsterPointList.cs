// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DTPVPSceneMonsterPointList : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static DTPVPSceneMonsterPointList GetRootAsDTPVPSceneMonsterPointList(ByteBuffer _bb) { return GetRootAsDTPVPSceneMonsterPointList(_bb, new DTPVPSceneMonsterPointList()); }
  public static DTPVPSceneMonsterPointList GetRootAsDTPVPSceneMonsterPointList(ByteBuffer _bb, DTPVPSceneMonsterPointList obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DTPVPSceneMonsterPointList __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public HHFramework.DataTable.DTPVPSceneMonsterPoint? DTPVPSceneMonsterPoints(int j) { int o = __p.__offset(4); return o != 0 ? (HHFramework.DataTable.DTPVPSceneMonsterPoint?)(new HHFramework.DataTable.DTPVPSceneMonsterPoint()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DTPVPSceneMonsterPointsLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<HHFramework.DataTable.DTPVPSceneMonsterPointList> CreateDTPVPSceneMonsterPointList(FlatBufferBuilder builder,
      VectorOffset DTPVPSceneMonsterPointsOffset = default(VectorOffset)) {
    builder.StartTable(1);
    DTPVPSceneMonsterPointList.AddDTPVPSceneMonsterPoints(builder, DTPVPSceneMonsterPointsOffset);
    return DTPVPSceneMonsterPointList.EndDTPVPSceneMonsterPointList(builder);
  }

  public static void StartDTPVPSceneMonsterPointList(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddDTPVPSceneMonsterPoints(FlatBufferBuilder builder, VectorOffset DTPVPSceneMonsterPointsOffset) { builder.AddOffset(0, DTPVPSceneMonsterPointsOffset.Value, 0); }
  public static VectorOffset CreateDTPVPSceneMonsterPointsVector(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTPVPSceneMonsterPoint>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateDTPVPSceneMonsterPointsVectorBlock(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTPVPSceneMonsterPoint>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTPVPSceneMonsterPointsVectorBlock(FlatBufferBuilder builder, ArraySegment<Offset<HHFramework.DataTable.DTPVPSceneMonsterPoint>> data) { builder.StartVector(4, data.Count, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTPVPSceneMonsterPointsVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<Offset<HHFramework.DataTable.DTPVPSceneMonsterPoint>>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartDTPVPSceneMonsterPointsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<HHFramework.DataTable.DTPVPSceneMonsterPointList> EndDTPVPSceneMonsterPointList(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.DTPVPSceneMonsterPointList>(o);
  }
}


}