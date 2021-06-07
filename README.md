# AlkemyTest

### Luego de clonar el proyecto deben seguirse estos pasos para testear.

* Se debe crear una base de datos SQL en blanco.
* Agregar la cadena de conexión en appsettings.json
* Correr el comando en la consola Menu> Herramientas >Administrador de paquetes NuGet > consola...:  update-database
* En el paso anterior el proyecto genera las tablas y corre un seeder con datos de prueba
* Correr el proyecto ()


## IMPORTANTE
* Si deseas utilizar swagger se recomienda comentar en los controladores la notacion [Authorize] para que no se bloquee el acceso a las consultas.
* Si NO comentas [Authorize] se recomienda utilizar Postman
 
