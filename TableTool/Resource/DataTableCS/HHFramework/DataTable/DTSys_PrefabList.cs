// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DTSys_PrefabList : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static DTSys_PrefabList GetRootAsDTSys_PrefabList(ByteBuffer _bb) { return GetRootAsDTSys_PrefabList(_bb, new DTSys_PrefabList()); }
  public static DTSys_PrefabList GetRootAsDTSys_PrefabList(ByteBuffer _bb, DTSys_PrefabList obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DTSys_PrefabList __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public HHFramework.DataTable.DTSys_Prefab? DTSysPrefabs(int j) { int o = __p.__offset(4); return o != 0 ? (HHFramework.DataTable.DTSys_Prefab?)(new HHFramework.DataTable.DTSys_Prefab()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DTSysPrefabsLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<HHFramework.DataTable.DTSys_PrefabList> CreateDTSys_PrefabList(FlatBufferBuilder builder,
      VectorOffset DTSys_PrefabsOffset = default(VectorOffset)) {
    builder.StartTable(1);
    DTSys_PrefabList.AddDTSysPrefabs(builder, DTSys_PrefabsOffset);
    return DTSys_PrefabList.EndDTSys_PrefabList(builder);
  }

  public static void StartDTSys_PrefabList(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddDTSysPrefabs(FlatBufferBuilder builder, VectorOffset DTSysPrefabsOffset) { builder.AddOffset(0, DTSysPrefabsOffset.Value, 0); }
  public static VectorOffset CreateDTSysPrefabsVector(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTSys_Prefab>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateDTSysPrefabsVectorBlock(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTSys_Prefab>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTSysPrefabsVectorBlock(FlatBufferBuilder builder, ArraySegment<Offset<HHFramework.DataTable.DTSys_Prefab>> data) { builder.StartVector(4, data.Count, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTSysPrefabsVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<Offset<HHFramework.DataTable.DTSys_Prefab>>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartDTSysPrefabsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<HHFramework.DataTable.DTSys_PrefabList> EndDTSys_PrefabList(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.DTSys_PrefabList>(o);
  }
}


}
