# ITG_Project
To run the project you should have set a database on local host with name ITG_Project. Username is remote and password is "1234".
run:
dotnet ef migrations add InitDB && dotnet ef database update
once, and you are good to go.
All endpoints are specified in postman collection.
