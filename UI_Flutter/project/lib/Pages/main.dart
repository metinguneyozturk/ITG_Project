import 'dart:convert';
import 'dart:html';
import 'dart:js';
import 'package:dio/dio.dart';
import 'package:project/HttpRequests/Requests.dart';
import 'package:project/Pages/RegisterPage.dart';
import 'package:project/Pages/SupplierPage.dart';
import 'dart:js';

import '../EndPoints.dart';
import 'package:flutter/material.dart';
import  "package:http/http.dart" as http;
import '../AlertDialogs/oneButtonAlertDialog.dart';


void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      home: LoginDemo(),
    );
  }
}

class LoginDemo extends StatefulWidget {
  @override
  _LoginDemoState createState() => _LoginDemoState();
}

class _LoginDemoState extends State<LoginDemo> {
  final emailcontroller = TextEditingController();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: SingleChildScrollView(
        child: Column(
          children: <Widget>[
            Padding(
              padding: const EdgeInsets.only(top: 60.0),
              child: Center(
                child: Container(
                  width: 200,
                  height: 150,
                  /*decoration: BoxDecoration(
                        color: Colors.red,
                        borderRadius: BorderRadius.circular(50.0)),*/
                  child: Image.network('https://img.freepik.com/premium-vector/build-business-bridge-connect-path-together-solution-teamwork-idea-cooperation-collaboration-success-together-concept-business-people-team-help-building-bridge-connect-way_212586-1841.jpg?w=996'),
                ),
              ),
            ),
            Padding(
              //padding: const EdgeInsets.only(left:15.0,right: 15.0,top:0,bottom: 0),
              padding: EdgeInsets.symmetric(horizontal: 15),
              
              child: TextField(
                controller: emailcontroller,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    labelText: 'Email',
                    hintText: 'Enter valid email id as abc@gmail.com'),
              ),
            ),

           
            SizedBox(
              height: 25,
            ),
            Row(
              mainAxisAlignment: MainAxisAlignment.center ,
              children: <Widget> [
                Container(
                  height: 50,
                  width: 250,
                  decoration: BoxDecoration(
                      color: Colors.blue, borderRadius: BorderRadius.circular(20)),
                  child: TextButton(
                    onPressed: ()  {
                   
                            showOneButtonAlertDialog(context,"Error","Ok","Under construction please Login as Supplier");
                    
                    },
                    child: Text(
                      'Retailer Login',
                      style: TextStyle(color: Colors.white, fontSize: 25),
                    ),
                  ),
                ),
                Container(
                  height: 50,
                  width: 250,
                  decoration: BoxDecoration(
                      color: Colors.blue, borderRadius: BorderRadius.circular(20)),
                  child: TextButton(
                    onPressed: () async {
                    if (emailcontroller.text.isEmpty) 
                          {
                            showOneButtonAlertDialog(context,"Error","Retry","Please Fill the Blanks");
                          }
                          final endpoints = EndPoints();
                          
                        
                         
                         Map data = {
                          'email': emailcontroller.text.toString()
                         };
                         //print(jsonEncode(data));
                         var response = Requests().suploginrequest(emailcontroller.text.toString()).
                          then((response){
                                print(response.statusCode);
                                print(response.body);
                                
                                
                            if(response.statusCode ==200){
                              //showOneButtonAlertDialog(context,"Login Successfull", "Continue","Press continue to proceed");
                              
                              Navigator.push(context, 
                              MaterialPageRoute(builder: 
                              (context) =>  SupplierPage()
                              ));
                              
                              }
                              if(response.statusCode!=200 && emailcontroller.text.isNotEmpty)
                              {showOneButtonAlertDialog(context, "Error", "Ok", "Wrong E-mail, Try again");
                              }
                          } );;
                          // var response = await http.post(
                            
                          //     endpoints.loginSupplier(),
                          //     headers: {
                          //       "Content-Type" : "application/json",
                          //       "Accept" : "*/*",
                          //       "Connection": "keep-alive"
                                
                          //       },
                          //     body: jsonEncode(
                          //      data
                          //       )).
                             
                         

                            
                            
                        

                        //   ScaffoldMessenger.of(context).showSnackBar
                        // (SnackBar(content:
                        // const Text("HOOOOOOOOOOOOOP"),
                        // duration: const Duration(milliseconds: 5),
                        // ),
                        // );

                     
                        //Navigator.push(
                        //context, MaterialPageRoute(builder: (_) => LoginDemo()));

                      
                    },
                    child: Text(
                      'Supplier Login',
                      style: TextStyle(color: Colors.white, fontSize: 25),
                    ),
                  ),
                ),
              ],
            ),
            SizedBox(
              height: 130,
            ),
            TextButton(
              
            onPressed:(){
              Navigator.push(context, MaterialPageRoute(builder: (context)=>
              const RegisterPage()
              ));
            }
            ,
            child: Text("Create Supplier Account"),
            
            )
            
          ],
        ),
      ),
    );
  }
}
