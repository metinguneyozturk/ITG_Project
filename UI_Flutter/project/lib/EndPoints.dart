import 'dart:convert';

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
class EndPoints{
 
  Uri loginSupplier(){
    var uri = Uri.http('localhost:5183', '/Auth/SupplierLogin');
    return uri;

  } 
  //JSON body lazım
  Uri loginRetailer(){
      var uri = Uri.http('localhost:5183', '/Auth/RetailerLogin');
    return uri;

  }  
  
  //JSON body lazım
  String registerSupplier = "http://localhost:5183/Auth/SupplierRegister";
  //JSON body lazım
  String registerRetailer = "http://localhost:5183/Auth/RetailerRegister";
  //JSON body lazım
   
   
   
   Uri getAllProducts(){
    var uri = Uri.http('localhost:5183', '/Product');
    return uri;

   } 



   String getProductbyId(int productId){
    return  "http://localhost:5183/Product?$productId";
   }
   String deleteProductbyId(int productId)
   {
    return "http://localhost:5183/Product?$productId";
   }
   String createProduct = "http://localhost:5183/Product/CreateProduct";
   //JSON body lazım 
   Uri updateProduct(int productid,int updatedquantity){
    var uri = Uri.http('localhost:5183', '/Product/UpdateProduct',{'productid' : '$productid' ,'updatedquantity':'$updatedquantity' });
    print(uri.toString());
   return uri;
   } 
  String defaultimg = "https://i.ibb.co/47jDBbg/Default-Image.png";

}