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
import "package:http/http.dart" as http;
import '../AlertDialogs/oneButtonAlertDialog.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

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
                 
                  child: Image.network(
                      'https://img.freepik.com/premium-vector/build-business-bridge-connect-path-together-solution-teamwork-idea-cooperation-collaboration-success-together-concept-business-people-team-help-building-bridge-connect-way_212586-1841.jpg?w=996'),
                ),
              ),
            ),
            Padding(
              padding: EdgeInsets.symmetric(horizontal: 15),

              child: TextField(
                controller: emailcontroller,
                decoration: const InputDecoration(
                    border: OutlineInputBorder(),
                    labelText: 'Email',
                    hintText: 'Enter valid email id as abc@gmail.com'),
              ),
            ),
            const SizedBox(
              height: 25,
            ),
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: <Widget>[
                Container(
                  height: 50,
                  width: 250,
                  decoration: BoxDecoration(
                      color: Colors.blue,
                      borderRadius: BorderRadius.circular(20)),
                  child: TextButton(
                    onPressed: () async {
                      if (emailcontroller.text.isEmpty) {
                        showOneButtonAlertDialog(context, "Error", "Retry",
                            "Please Fill the Blanks");
                      }
                      final endpoints = EndPoints();

                      
                      //print(jsonEncode(data));
                      var response = Requests()
                          .retailerloginrequest(emailcontroller.text.toString())
                          .then((response) {
                        if (response.statusCode == 200) {

                          Navigator.push(
                              context,
                              MaterialPageRoute(
                                  builder: (context) => SupplierPage()));
                        }
                        if (response.statusCode != 200 &&
                            emailcontroller.text.isNotEmpty) {
                          showOneButtonAlertDialog(context, "Error", "Ok",
                              "Wrong E-mail, Try again");
                        }
                      });
                    },
                    child: const Text(
                      'Retailer Login',
                      style: TextStyle(color: Colors.white, fontSize: 25),
                    ),
                  ),
                ),
                Container(
                  height: 50,
                  width: 250,
                  decoration: BoxDecoration(
                      color: Colors.blue,
                      borderRadius: BorderRadius.circular(20)),
                  child: TextButton(
                    onPressed: () async {
                      if (emailcontroller.text.isEmpty) {
                        showOneButtonAlertDialog(context, "Error", "Retry",
                            "Please Fill the Blanks");
                      }
                      final endpoints = EndPoints();

                      Map data = {'email': emailcontroller.text.toString()};
                      //print(jsonEncode(data));
                      var response = Requests()
                          .suploginrequest(emailcontroller.text.toString())
                          .then((response) {
                        if (response.statusCode == 200) {

                          Navigator.push(
                              context,
                              MaterialPageRoute(
                                  builder: (context) => SupplierPage()));
                        }
                        if (response.statusCode != 200 &&
                            emailcontroller.text.isNotEmpty) {
                          showOneButtonAlertDialog(context, "Error", "Ok",
                              "Wrong E-mail, Try again");
                        }
                      });
                    },
                    child: const Text(
                      'Supplier Login',
                      style: TextStyle(color: Colors.white, fontSize: 25),
                    ),
                  ),
                ),
              ],
            ),
           const SizedBox(
              height: 130,
            ),
            TextButton(
              onPressed: () {
                Navigator.push(context,
                    MaterialPageRoute(builder: (context) => RegisterPage()));
              },
              child: const Text("Create Account"),
            )
          ],
        ),
      ),
    );
  }
}
