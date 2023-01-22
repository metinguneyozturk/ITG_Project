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
    // If the server did return a 200 OK response,
    // then parse the JSON.
    
        
    

    //.values.map<ProductModel>((e) => 
    //ProductModel.fromJson(e)).toList();
    
    // List<ProductModel> res1 = List.from(response.body as List<dynamic>).map((e)=> ProductModel.fromJson(e)).toList();
    // List<ProductModel> res2 = List<ProductModel>.from(response.body as List<dynamic>).forEach((element) {
    //   ProductModel.fromJson(response.body)
    // });
   
    
     
    
    return Products.fromJson(jsonDecode(response.body.toString()));
  } else {
    // If the server did not return a 200 OK response,
    // then throw an exception.
    throw Exception('Failed to load data: ${response.statusCode}' );
  }
}


  }

