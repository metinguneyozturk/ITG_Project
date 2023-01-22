import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

showOneButtonAlertDialog(BuildContext context,String title,String buttonText, String content) {
                      // set up the button
                      Widget okButton = TextButton(
                        child: Text(buttonText),
                        onPressed: () {
                        Navigator.pop(context);
                        
                         
                          
                         
                        
                          
                          // Navigator.pop(context, MaterialPageRoute(builder: (context)=>
                          // LoginDemo()
                          // ),
                          // );
                          
                        },
                      );

                      // set up the AlertDialog
                      AlertDialog alert = AlertDialog(
                        title: Text(title),
                        content: Text(content),
                        actions: [
                          okButton,
                        ],
                      );

                      // show the dialog
                      showDialog(
                        context: context,
                        builder: (BuildContext context) {
                          return alert;
                        },
                      );
                    }