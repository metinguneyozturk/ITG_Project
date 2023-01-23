import 'package:flutter/material.dart';
import "package:http/http.dart" as http;
import 'package:project/EndPoints.dart';
import 'package:project/HttpRequests/Requests.dart';
import 'package:project/Models/ProductModel.dart';
import 'package:project/Pages/PostProductPage.dart';


class SupplierPage extends StatefulWidget {
  const SupplierPage({super.key});

  @override
  State<SupplierPage> createState() => _SupplierPageState();
}


class _SupplierPageState extends State<SupplierPage> {
late Future<Products> futureProduct;
  @override
  void initState() {
    
    super.initState();
    futureProduct = Requests().getAllProducts();
    futureProduct.then((futureProduct){
      print("Sa ${futureProduct.products!.length}");
    });
          
  }
 
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Material App',
      
      
      home: Scaffold(
        bottomNavigationBar: BottomNavigationBar(
        items: const  <BottomNavigationBarItem>[
          BottomNavigationBarItem(
            icon: Icon(Icons.home),
            label: 'Home',
            
            
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.business),
            label: 'Update Product',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.school),
            label: 'Nothing here :)',
          ),
        ],
        onTap: (value) {
          switch(value){
            case 0:
            Navigator.push(context, 
            MaterialPageRoute(builder: (context)=>
            SupplierPage()
            ));
            break;
            case 1:
            Navigator.push(context, MaterialPageRoute(builder: (context)=>
            PostProductPage()
            ));
            
            break;
            case 2:

            break;
          }
        },
        
        ),

        body: Container(
          child: Center(
          child: FutureBuilder(
              future: futureProduct,
              builder: (BuildContext ctx, AsyncSnapshot snapshot) {
                if (snapshot.hasData) {
                    //print("Line 43: ${snapshot.data.products.length}");
                } else {
                   //print("Line 43: " +snapshot.data.elementAt(1));
                  return const CircularProgressIndicator();
                }
                //buradan devam 7 Adet products Objesi Geliyor!!
                return ListView.builder(
                    scrollDirection: Axis.vertical,
                    itemCount: snapshot.data!.products.length,
                    itemBuilder: (context, index) {
                      return Row(
                        children: [
                          Container(
                            height: 180,
                            width: 180,
                            color: Colors.green[100 * (1 + index)],
                            child: Image.network(
                                '${snapshot.data.products[index].productImageURL}'),
                          ),
                          Container(
                            height: 180,
                            width: 180,
                            color: Colors.green[100 * (1 + index)],
                            child: Column(
                              children: [
                                Container(
                                  alignment: Alignment.topLeft,
                                  color: Colors.green[100 * (1 + index)],
                                  child: Text(
                                      "Product Name: ${snapshot.data.products[index].productName}"),
                                ),
                                Container(
                                  alignment: Alignment.topLeft,
                                  color: Colors.green[100 * (1 + index)],
                                  child: Text(
                                      "Quantity: ${snapshot.data.products[index].quantity}"),
                                ),
                                Container(
                                  alignment: Alignment.topLeft,
                                  color: Colors.green[100 * (1 + index)],
                                  child: Text(
                                      "Price: ${snapshot.data.products[index].price}"),
                                ),
                                Container(
                                  alignment: Alignment.topLeft,
                                  color: Colors.green[100 * (1 + index)],
                                  child: Text(
                                      "Supplier: ${snapshot.data.products[index].supplierId}"),
                                ),
                               
                              ],
                            ),
                          ),
                        ],
                      );
                    });
              }),
      ),
        ),
      ),
    );
  }
}
