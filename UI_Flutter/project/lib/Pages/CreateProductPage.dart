import 'package:flutter/material.dart';

import '../AlertDialogs/oneButtonAlertDialog.dart';
import '../HttpRequests/Requests.dart';




class CreateProductPage extends StatefulWidget {
  const CreateProductPage({super.key});

  @override
  State<CreateProductPage> createState() => _CreateProductPageState();
}

class _CreateProductPageState extends State<CreateProductPage> {
  final productNameController = TextEditingController();
  final quantityController = TextEditingController();
  final priceController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Create Product',
      home: Scaffold(
        appBar: AppBar(
          title: const Text('Create Product'),
        ),
         body:SingleChildScrollView(
        child: Column(
          children: <Widget>[
            SizedBox(height: 25,),
            Padding(
              //padding: const EdgeInsets.only(left:15.0,right: 15.0,top:0,bottom: 0),
              padding: EdgeInsets.symmetric(horizontal: 15),
              
              child: TextField(
                controller: productNameController,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    labelText: 'Product Name',
                    ),
              ),
            ),
            Padding(
              //padding: const EdgeInsets.only(left:15.0,right: 15.0,top:0,bottom: 0),
              padding: EdgeInsets.symmetric(horizontal: 15),
              
              child: TextField(
                controller: quantityController,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    labelText: 'Quantity',
                    ),
              ),
            ),
             Padding(
              //padding: const EdgeInsets.only(left:15.0,right: 15.0,top:0,bottom: 0),
              padding: EdgeInsets.symmetric(horizontal: 15),
              
              child: TextField(
                controller: priceController,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    labelText: 'Price',
                    ),
              ),
            ),
            Padding(
              //padding: const EdgeInsets.only(left:15.0,right: 15.0,top:0,bottom: 0),
              padding: EdgeInsets.symmetric(horizontal: 15),
              
              child: TextButton(
                onPressed: (() async{
                  if(quantityController.text.isEmpty || priceController.text.isEmpty || productNameController.text.isEmpty){showOneButtonAlertDialog(context, "Error", "Retry", "Miss entered the values please check");}

                  var x = await Requests().createProduct(productNameController.text.toString(), int.parse(quantityController.text.toString()), int.parse(priceController.text.toString()));

                  if(x.toString().compareTo("Success")==0){
                  return showOneButtonAlertDialog(context, "Result", "Ok", "Product created.");
                  
                  }
                  else{
                    return showOneButtonAlertDialog(context, "Error", "Retry", "An error occured");
                  }
                  
                }), child: Text("Create"),

              
              ),
            ),
          ],
        ),
          ),
      ),
    );
  }
}