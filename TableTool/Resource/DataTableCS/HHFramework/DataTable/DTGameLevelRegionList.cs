// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DTGameLevelRegionList : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static DTGameLevelRegionList GetRootAsDTGameLevelRegionList(ByteBuffer _bb) { return GetRootAsDTGameLevelRegionList(_bb, new DTGameLevelRegionList()); }
  public static DTGameLevelRegionList GetRootAsDTGameLevelRegionList(ByteBuffer _bb, DTGameLevelRegionList obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DTGameLevelRegionList __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public HHFramework.DataTable.DTGameLevelRegion? DTGameLevelRegions(int j) { int o = __p.__offset(4); return o != 0 ? (HHFramework.DataTable.DTGameLevelRegion?)(new HHFramework.DataTable.DTGameLevelRegion()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DTGameLevelRegionsLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<HHFramework.DataTable.DTGameLevelRegionList> CreateDTGameLevelRegionList(FlatBufferBuilder builder,
      VectorOffset DTGameLevelRegionsOffset = default(VectorOffset)) {
    builder.StartTable(1);
    DTGameLevelRegionList.AddDTGameLevelRegions(builder, DTGameLevelRegionsOffset);
    return DTGameLevelRegionList.EndDTGameLevelRegionList(builder);
  }

  public static void StartDTGameLevelRegionList(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddDTGameLevelRegions(FlatBufferBuilder builder, VectorOffset DTGameLevelRegionsOffset) { builder.AddOffset(0, DTGameLevelRegionsOffset.Value, 0); }
  public static VectorOffset CreateDTGameLevelRegionsVector(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTGameLevelRegion>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateDTGameLevelRegionsVectorBlock(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTGameLevelRegion>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTGameLevelRegionsVectorBlock(FlatBufferBuilder builder, ArraySegment<Offset<HHFramework.DataTable.DTGameLevelRegion>> data) { builder.StartVector(4, data.Count, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTGameLevelRegionsVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<Offset<HHFramework.DataTable.DTGameLevelRegion>>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartDTGameLevelRegionsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<HHFramework.DataTable.DTGameLevelRegionList> EndDTGameLevelRegionList(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.DTGameLevelRegionList>(o);
  }
}


}
