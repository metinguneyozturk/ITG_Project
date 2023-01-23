# ITG_Project
To run the project(ASPNet WebAPI) you should set a database on localhost with name ITG_Project. Username is remote and password is "1234".
run:
dotnet ef migrations add InitDB && dotnet ef database update && dotnet run 
once, and you are good to go.
All endpoints are specified in postman collection.

After that to run GUI open a new terminal and run the following command:
flutter run lib/Pages/main.dart





