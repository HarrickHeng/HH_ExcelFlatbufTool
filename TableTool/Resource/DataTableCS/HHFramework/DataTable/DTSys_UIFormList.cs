// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DTSys_UIFormList : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static DTSys_UIFormList GetRootAsDTSys_UIFormList(ByteBuffer _bb) { return GetRootAsDTSys_UIFormList(_bb, new DTSys_UIFormList()); }
  public static DTSys_UIFormList GetRootAsDTSys_UIFormList(ByteBuffer _bb, DTSys_UIFormList obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DTSys_UIFormList __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public HHFramework.DataTable.DTSys_UIForm? DTSysUIForms(int j) { int o = __p.__offset(4); return o != 0 ? (HHFramework.DataTable.DTSys_UIForm?)(new HHFramework.DataTable.DTSys_UIForm()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DTSysUIFormsLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<HHFramework.DataTable.DTSys_UIFormList> CreateDTSys_UIFormList(FlatBufferBuilder builder,
      VectorOffset DTSys_UIFormsOffset = default(VectorOffset)) {
    builder.StartTable(1);
    DTSys_UIFormList.AddDTSysUIForms(builder, DTSys_UIFormsOffset);
    return DTSys_UIFormList.EndDTSys_UIFormList(builder);
  }

  public static void StartDTSys_UIFormList(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddDTSysUIForms(FlatBufferBuilder builder, VectorOffset DTSysUIFormsOffset) { builder.AddOffset(0, DTSysUIFormsOffset.Value, 0); }
  public static VectorOffset CreateDTSysUIFormsVector(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTSys_UIForm>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateDTSysUIFormsVectorBlock(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTSys_UIForm>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTSysUIFormsVectorBlock(FlatBufferBuilder builder, ArraySegment<Offset<HHFramework.DataTable.DTSys_UIForm>> data) { builder.StartVector(4, data.Count, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTSysUIFormsVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<Offset<HHFramework.DataTable.DTSys_UIForm>>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartDTSysUIFormsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<HHFramework.DataTable.DTSys_UIFormList> EndDTSys_UIFormList(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.DTSys_UIFormList>(o);
  }
}


}
