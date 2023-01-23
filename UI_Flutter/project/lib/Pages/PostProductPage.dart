import 'package:flutter/material.dart';
import 'package:http/http.dart';
import 'package:project/AlertDialogs/oneButtonAlertDialog.dart';
import 'package:project/HttpRequests/Requests.dart';


class PostProductPage extends StatefulWidget {
  const PostProductPage({super.key});

  @override
  State<PostProductPage> createState() => _PostProductPageState();
}

class _PostProductPageState extends State<PostProductPage> {
  final idcontroller = TextEditingController();
  final updatedquantity = TextEditingController();
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Material App',
      debugShowCheckedModeBanner: false,
      home: Scaffold(
        
        
        body:SingleChildScrollView(
        child: Column(
          children: <Widget>[
            Padding(
              //padding: const EdgeInsets.only(left:15.0,right: 15.0,top:0,bottom: 0),
              padding: EdgeInsets.symmetric(horizontal: 15),
              
              child: TextField(
                controller: idcontroller,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    labelText: 'Product id',
                    hintText: 'Enter a product you own'),
              ),
            ),
            Padding(
              //padding: const EdgeInsets.only(left:15.0,right: 15.0,top:0,bottom: 0),
              padding: EdgeInsets.symmetric(horizontal: 15),
              
              child: TextField(
                controller: updatedquantity,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    labelText: 'Quantity',
                    hintText: 'Enter a updated product quantity'),
              ),
            ),
            Padding(
              //padding: const EdgeInsets.only(left:15.0,right: 15.0,top:0,bottom: 0),
              padding: EdgeInsets.symmetric(horizontal: 15),
              
              child: TextButton(
                onPressed: (() async{
                  if(idcontroller.text.isEmpty || updatedquantity.text.isEmpty){showOneButtonAlertDialog(context, "Error", "Retry", "Miss entered the values please check");}

                  var x =await Requests().updateProduct(int.parse(idcontroller.text.toString()), int.parse(updatedquantity.text.toString()));
                  if(x.toString().compareTo("Success")==0){
                  return showOneButtonAlertDialog(context, "Result", "Ok", "Process succeded.");
                  
                  }
                  else{
                    return showOneButtonAlertDialog(context, "Error", "Retry", "An error occured");
                  }
                  
                }), child: Text("Update"),

              
              ),
            ),
          ],
        ),
          ),
        ),
      );
    
  }
}