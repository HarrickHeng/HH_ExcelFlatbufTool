// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DTRechargeShopList : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static DTRechargeShopList GetRootAsDTRechargeShopList(ByteBuffer _bb) { return GetRootAsDTRechargeShopList(_bb, new DTRechargeShopList()); }
  public static DTRechargeShopList GetRootAsDTRechargeShopList(ByteBuffer _bb, DTRechargeShopList obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DTRechargeShopList __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public HHFramework.DataTable.DTRechargeShop? DTRechargeShops(int j) { int o = __p.__offset(4); return o != 0 ? (HHFramework.DataTable.DTRechargeShop?)(new HHFramework.DataTable.DTRechargeShop()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int DTRechargeShopsLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<HHFramework.DataTable.DTRechargeShopList> CreateDTRechargeShopList(FlatBufferBuilder builder,
      VectorOffset DTRechargeShopsOffset = default(VectorOffset)) {
    builder.StartTable(1);
    DTRechargeShopList.AddDTRechargeShops(builder, DTRechargeShopsOffset);
    return DTRechargeShopList.EndDTRechargeShopList(builder);
  }

  public static void StartDTRechargeShopList(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddDTRechargeShops(FlatBufferBuilder builder, VectorOffset DTRechargeShopsOffset) { builder.AddOffset(0, DTRechargeShopsOffset.Value, 0); }
  public static VectorOffset CreateDTRechargeShopsVector(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTRechargeShop>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateDTRechargeShopsVectorBlock(FlatBufferBuilder builder, Offset<HHFramework.DataTable.DTRechargeShop>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTRechargeShopsVectorBlock(FlatBufferBuilder builder, ArraySegment<Offset<HHFramework.DataTable.DTRechargeShop>> data) { builder.StartVector(4, data.Count, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDTRechargeShopsVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<Offset<HHFramework.DataTable.DTRechargeShop>>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartDTRechargeShopsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<HHFramework.DataTable.DTRechargeShopList> EndDTRechargeShopList(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.DTRechargeShopList>(o);
  }
}


}
