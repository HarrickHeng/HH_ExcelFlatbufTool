// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct Sys_UIFormList : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static Sys_UIFormList GetRootAsSys_UIFormList(ByteBuffer _bb) { return GetRootAsSys_UIFormList(_bb, new Sys_UIFormList()); }
  public static Sys_UIFormList GetRootAsSys_UIFormList(ByteBuffer _bb, Sys_UIFormList obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Sys_UIFormList __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public HHFramework.DataTable.Sys_UIForm? SysUIForms(int j) { int o = __p.__offset(4); return o != 0 ? (HHFramework.DataTable.Sys_UIForm?)(new HHFramework.DataTable.Sys_UIForm()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int SysUIFormsLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<HHFramework.DataTable.Sys_UIFormList> CreateSys_UIFormList(FlatBufferBuilder builder,
      VectorOffset Sys_UIFormsOffset = default(VectorOffset)) {
    builder.StartTable(1);
    Sys_UIFormList.AddSysUIForms(builder, Sys_UIFormsOffset);
    return Sys_UIFormList.EndSys_UIFormList(builder);
  }

  public static void StartSys_UIFormList(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddSysUIForms(FlatBufferBuilder builder, VectorOffset SysUIFormsOffset) { builder.AddOffset(0, SysUIFormsOffset.Value, 0); }
  public static VectorOffset CreateSysUIFormsVector(FlatBufferBuilder builder, Offset<HHFramework.DataTable.Sys_UIForm>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateSysUIFormsVectorBlock(FlatBufferBuilder builder, Offset<HHFramework.DataTable.Sys_UIForm>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateSysUIFormsVectorBlock(FlatBufferBuilder builder, ArraySegment<Offset<HHFramework.DataTable.Sys_UIForm>> data) { builder.StartVector(4, data.Count, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateSysUIFormsVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<Offset<HHFramework.DataTable.Sys_UIForm>>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartSysUIFormsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<HHFramework.DataTable.Sys_UIFormList> EndSys_UIFormList(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.Sys_UIFormList>(o);
  }
}


}
