// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DTChapterList : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static DTChapterList GetRootAsDTChapterList(ByteBuffer _bb) { return GetRootAsDTChapterList(_bb, new DTChapterList()); }
  public static DTChapterList GetRootAsDTChapterList(ByteBuffer _bb, DTChapterList obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DTChapterList __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public HHFramework.DataTable.DTChapter? DTChapters(int j) { int o = __p.__offset(4); return o != 0 ? (HHFramework.DataTable.DTChapter?)(new HHFramework.DataTable.DTChapter()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DTChaptersLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<HHFramework.DataTable.DTChapterList> CreateDTChapterList(FlatBufferBuilder builder,
      VectorOffset DTChaptersOffset = default(VectorOffset)) {
    builder.StartTable(1);
    DTChapterList.AddDTChapters(builder, DTChaptersOffset);
    return DTChapterList.EndDTChapterList(builder);
  }

  public static void StartDTChapterList(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddDTChapters(FlatBufferBuilder builder, VectorOffset DTChaptersOffset) { builder.AddOffset(0, DTChaptersOffset.Value, 0); }
  public static VectorOffset CreateDTChaptersVector(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTChapter>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateDTChaptersVectorBlock(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTChapter>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTChaptersVectorBlock(FlatBufferBuilder builder, ArraySegment<Offset<HHFramework.DataTable.DTChapter>> data) { builder.StartVector(4, data.Count, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTChaptersVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<Offset<HHFramework.DataTable.DTChapter>>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartDTChaptersVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<HHFramework.DataTable.DTChapterList> EndDTChapterList(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.DTChapterList>(o);
  }
}


}
