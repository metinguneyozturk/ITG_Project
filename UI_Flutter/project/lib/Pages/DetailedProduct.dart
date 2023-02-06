import 'package:flutter/material.dart';
import 'package:project/AlertDialogs/oneButtonAlertDialog.dart';
import 'package:project/HttpRequests/Requests.dart';
import 'package:project/Models/ProductModel.dart';



class DetailedProduct extends StatefulWidget {
  final ProductModel productModel;

   const DetailedProduct({Key? key, required this.productModel}) : super(key: key);

  @override
  State<DetailedProduct> createState() => _DetailedProductState();
}

class _DetailedProductState extends State<DetailedProduct> {
  final quantitycontroller = TextEditingController();

  @override
  Widget build(BuildContext context) {
    
      
        return Scaffold(
          appBar: AppBar(
            title: Text(widget.productModel.productName!),),
          body: SingleChildScrollView(
            child: Column(
              children: [
                Image.network(widget.productModel.productImageURL!),
                const SizedBox(
                  height: 10,
                ),
                Text("Quantity: ${widget.productModel.quantity.toString()}",
                style: TextStyle(fontWeight: FontWeight.bold,fontSize: 20),
                ),
                const SizedBox(
                  height: 10,),
                  
                  Text("Price: ${widget.productModel.price.toString()}"),
                  const SizedBox(
                    height: 10,
                  ),
          
                  Padding(
                    padding: const EdgeInsets.all(20),
                    child: Center(
                      child: Container(
                        child: TextField(
                          controller: quantitycontroller,
                        decoration: const InputDecoration(
                            border:  OutlineInputBorder(),
                            labelText: "Desired Quantity",
                            ),
          
                    
                        ),
                      ),
                    ),
                  ),
                  ElevatedButton(onPressed: (() {
                    if(quantitycontroller.text.isEmpty){
                      
                       showOneButtonAlertDialog(context, "Error", "Ok", "Please enter a quantity");
                    }
                    else if(int.parse(quantitycontroller.text.toString())>(widget.productModel.quantity as int) )
                    {
                       showOneButtonAlertDialog(context, "Error", "Ok", "Desired quantity is higher than in stocks");
                  }
                  else{
                  Requests().generatebilling(widget.productModel.productId!, int.parse(quantitycontroller.text.toString())).
                  then((value) 
                  {
                    print(value.toString());
                    Navigator.pop(context);
                    Navigator.push(context, MaterialPageRoute(builder: (context)=>
                    DetailedProduct(productModel: widget.productModel)
                    )
                    );
                  } 

     
      
                  );
                    
                    
                  } 
                  }), child: const Text("Buy"))
          
              ],
            ),
          ),
        );
      
    
  }
}