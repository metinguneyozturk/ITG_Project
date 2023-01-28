import 'package:flutter/material.dart';
import 'package:project/Models/ProductModel.dart';



class DetailedProduct extends StatelessWidget {
  final ProductModel productModel;
  const DetailedProduct({Key? key, required this.productModel}) : super(key: key);
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text(productModel.productName!),),
      body: Column(
        children: [
          Image.network(productModel.productImageURL!),
          SizedBox(
            height: 10,
          ),
          Text("Quantity: ${productModel.quantity.toString()}",
          style: TextStyle(fontWeight: FontWeight.bold,fontSize: 20),
          ),
          SizedBox(
            height: 10,),
            
            Text("Price: ${productModel.price.toString()}"),

        ],
      ),
    );
  }
}