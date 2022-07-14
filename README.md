# TestWebApiWhitArchitectureCQRS

1.- cambiar el string de conexión a la bd
"DefaultConnection": "Server=NameServer; Database=NameDatabase;Trusted_Connection=True;"

2.- Usar el comando Update-Database (ya se tiene el contextModel de la creación), debe hacer referencia al proyecto Infrastructure.Persistence.

3.- Validar el puerto para el proyecto angular, en caso de ser necesario cambiarlo para el acceso a politicas y permisos, dentro del cors
