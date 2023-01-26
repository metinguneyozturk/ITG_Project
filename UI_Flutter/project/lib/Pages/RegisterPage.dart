import 'dart:html';

import 'package:flutter/material.dart';
import 'package:project/AlertDialogs/oneButtonAlertDialog.dart';
import 'package:project/HttpRequests/Requests.dart';
import 'package:http/http.dart' as http;


class RegisterPage extends StatelessWidget {
  final emailcontroller = TextEditingController();
  final namecontroller = TextEditingController();
  final phonecontroller = TextEditingController();
  RegisterPage({super.key});
  

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Material App',
      home: Scaffold(
        
       body:SingleChildScrollView(
        child: Column(
          children: <Widget>[
            SizedBox(
              height: 50,
            ),
            Padding(
              //padding: const EdgeInsets.only(left:15.0,right: 15.0,top:0,bottom: 0),
              padding: EdgeInsets.symmetric(horizontal: 15),
              
              child: TextField(
                controller: emailcontroller,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    labelText: 'Supplier Email',
                    hintText: 'Enter a valid e-mail'),
              ),
            ),
             Padding(
              //padding: const EdgeInsets.only(left:15.0,right: 15.0,top:0,bottom: 0),
              padding: EdgeInsets.symmetric(horizontal: 15),
              
              child: TextField(
                controller: namecontroller,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    labelText: 'Your Name',
                    ),
              ),
            ),
            Padding(
              //padding: const EdgeInsets.only(left:15.0,right: 15.0,top:0,bottom: 0),
              padding: EdgeInsets.symmetric(horizontal: 15),
              
              child: TextField(
                controller: phonecontroller,
                decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    labelText: 'Phone Number',
                    ),
              ),
            ),
            Container(
              //padding: const EdgeInsets.only(left:15.0,right: 15.0,top:0,bottom: 0),
              padding: EdgeInsets.symmetric(horizontal: 15),
              height: 50,
              width: 250,
              decoration: BoxDecoration(
                color: Colors.blue, borderRadius: BorderRadius.circular(20),
              ),
              child: TextButton(
                onPressed:  () async {
                  if(emailcontroller.text.isEmpty || namecontroller.text.isEmpty|| phonecontroller.text.isEmpty){
                    showOneButtonAlertDialog(context, "Error", "Retry", "Please provide information");
                  }
                  var response = await
                  Requests().createSupplier(namecontroller.text.toString(),
                   emailcontroller.text.toString(), 
                   phonecontroller.text.toString());
                   
                   if(response.toString().compareTo("Supplier Account Created")==0)
                   {
                    showOneButtonAlertDialog(context, "Notification", "Ok", "Account Created");
                   }
                   else if(response.toString().compareTo("Account with the same email exists")==0) {
                    showOneButtonAlertDialog(context, "Error", "Ok", "Account with the same email exists");
                  
                   }
                   else{showOneButtonAlertDialog(context, "Error", "Ok", "An error occured");
                   }
                  
                  
                },
                
                child: Text("Supplier Register",
                style: TextStyle(color: Colors.white, fontSize: 25),
                ),
                    
              ),
            ),
          ]
        ),
      ),
      )
    );
  }
}