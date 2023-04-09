// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace HHFramework.DataTable
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DTShop : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_23_1_4(); }
  public static DTShop GetRootAsDTShop(ByteBuffer _bb) { return GetRootAsDTShop(_bb, new DTShop()); }
  public static DTShop GetRootAsDTShop(ByteBuffer _bb, DTShop obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DTShop __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int ShopCategoryId { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int GoodsType { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int GoodsId { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int OldPrice { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Price { get { int o = __p.__offset(14); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int SellStatus { get { int o = __p.__offset(16); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }

  public static Offset<HHFramework.DataTable.DTShop> CreateDTShop(FlatBufferBuilder builder,
      int Id = 0,
      int ShopCategoryId = 0,
      int GoodsType = 0,
      int GoodsId = 0,
      int OldPrice = 0,
      int Price = 0,
      int SellStatus = 0) {
    builder.StartTable(7);
    DTShop.AddSellStatus(builder, SellStatus);
    DTShop.AddPrice(builder, Price);
    DTShop.AddOldPrice(builder, OldPrice);
    DTShop.AddGoodsId(builder, GoodsId);
    DTShop.AddGoodsType(builder, GoodsType);
    DTShop.AddShopCategoryId(builder, ShopCategoryId);
    DTShop.AddId(builder, Id);
    return DTShop.EndDTShop(builder);
  }

  public static void StartDTShop(FlatBufferBuilder builder) { builder.StartTable(7); }
  public static void AddId(FlatBufferBuilder builder, int Id) { builder.AddInt(0, Id, 0); }
  public static void AddShopCategoryId(FlatBufferBuilder builder, int ShopCategoryId) { builder.AddInt(1, ShopCategoryId, 0); }
  public static void AddGoodsType(FlatBufferBuilder builder, int GoodsType) { builder.AddInt(2, GoodsType, 0); }
  public static void AddGoodsId(FlatBufferBuilder builder, int GoodsId) { builder.AddInt(3, GoodsId, 0); }
  public static void AddOldPrice(FlatBufferBuilder builder, int OldPrice) { builder.AddInt(4, OldPrice, 0); }
  public static void AddPrice(FlatBufferBuilder builder, int Price) { builder.AddInt(5, Price, 0); }
  public static void AddSellStatus(FlatBufferBuilder builder, int SellStatus) { builder.AddInt(6, SellStatus, 0); }
  public static Offset<HHFramework.DataTable.DTShop> EndDTShop(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<HHFramework.DataTable.DTShop>(o);
  }
}


}
