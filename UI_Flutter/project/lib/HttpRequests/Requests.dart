import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:project/EndPoints.dart';
import 'package:project/Models/ProductModel.dart';




// var uri =Uri.http('localhost:5183', '/Auth/SupplierLogin');
//                      print(uri.toString());
//                      Map data = {
//                       'email': emailcontroller.text.toString()
//                      };
//                      print(jsonEncode(data));
//                       var response = await http.post(
                        
//                           uri,
//                           headers: {
//                             "Content-Type" : "application/json",
//                             "Accept" : "*/*",
//                             "Connection": "keep-alive"
                            
//                             },
//                           body: jsonEncode(
//                            data
//                             )).
//                           then((response){
//                             print(response.statusCode);
//                             print(response.body);
class Requests
{
  Future suploginrequest(String email) async
  {
     Map data ={
        'email': email,
      };
      
    var response = await http.post(
      EndPoints().loginSupplier(),
        headers: 
        {
      "Content-Type" : "application/json",
      "Accept" : "*/*",
      "Connection": "keep-alive"
        }, 
      body: jsonEncode(data)
    );

return response;
  }
  Future<Products> getAllProducts() async
  {
          
    var response = await http.get(
      EndPoints().getAllProducts(),
        headers: 
        {
      "Content-Type" : "application/json",
      "Accept" : "*/*",
      "Connection": "keep-alive"
        }, 
        
      
    );
      if (response.statusCode == 200) {   
    return Products.fromJson(jsonDecode(response.body.toString()));
  } else {
    throw Exception('Failed to load data: ${response.statusCode}' );
  }
}

Future  updateProduct(int productId,int updatedquant) async
  {
     
      
    var response = await http.put(
      EndPoints().updateProduct(productId, updatedquant),
       headers: 
        {
      "Content-Type" : "application/json",
      "Accept" : "*/*",
      "Connection": "keep-alive"
      
        }, 
      
    );
    if(response.statusCode ==200)
    {
      return response.body;
    }
    else{
      throw Exception('Failed to update quantity ${response.statusCode}');
    }

  }
  Future createSupplier(String name, String email, String phoneNumber) async{
     Map data ={
        'name': name,
        'email': email,
        'phoneNumber': phoneNumber,
      };
    var response = await http.post(EndPoints().registerSupplier(),
     headers: 
        {
      "Content-Type" : "application/json",
      "Accept" : "*/*",
      "Connection": "keep-alive"
        }, 
      body: jsonEncode(data)
    );
   if(response.statusCode ==200)
    {
      return response.body;
    }
    else{
      throw Exception('Failed to Create Account ${response.statusCode}');
    }

  }
}
