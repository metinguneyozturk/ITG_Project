
class Products{

  List<ProductModel>? products;

  Products(
    {this.products});
    Products.fromJson(List<dynamic> json)
    {
      products = List.from(json).map((e) => ProductModel.fromJson(e)).toList();
    }
    
}


class ProductModel {
  int? productId;
  String? productName;
  int? quantity;
  int? price;
  Null? retailerId;
  int? supplierId;
  String? productImageURL;

  ProductModel(
      {this.productId,
      this.productName,
      this.quantity,
      this.price,
      this.retailerId,
      this.supplierId,
      this.productImageURL});

  ProductModel.fromJson(Map<String, dynamic> json) {
    productId = json['productId'];
    productName = json['productName'];
    quantity = json['quantity'];
    price = json['price'];
    retailerId = json['retailerId'];
    supplierId = json['supplierId'];
    productImageURL = json['productImageURL'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['productId'] = this.productId;
    data['productName'] = this.productName;
    data['quantity'] = this.quantity;
    data['price'] = this.price;
    data['retailerId'] = this.retailerId;
    data['supplierId'] = this.supplierId;
    data['productImageURL'] = this.productImageURL;
    return data;
  }
}