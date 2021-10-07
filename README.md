# turismo-real-api-usuarios
Proyecto de API Usuarios Turismo Real.  
Actualmente el proyecto se encuentra sin la validación de los datos de entrada.

## Endpoints
---
- **GET /api/v1/usuario**
- **GET /api/v1/usuario/{rut}**
- **POST /api/v1/usuario**
- **PUT /api/v1/usuario/{rut}**
- **DELETE /api/v1/usuario/{rut}**  
---  
  
## GET /api/v1/usuario  
Retorna todos los usuarios reigstrados en la base de datos  

## GET /api/v1/usuario/{rut}
Retorna información del usuario especificado por rut

## POST /api/v1/usuario
Crea un nuevo usuario en la base de datos.  
El atributo password debe ser la contraseña del usuario encriptada. Este es el único objeto donde es visible la contraseña cifrada del usuario.

```
// JSON de entrada
{
    "rut": "14622572",
    "dv": "0",
    "primerNombre": "Andrea",
    "segundoNombre": "Fernanda",
    "apellidoPaterno": "Espinoza",
    "apellidoMaterno": "Lopez",
    "fechaNacimiento": "1989-09-21T00:00:00",
    "correo": "a.fernan@gmail.com",
    "telefonoMovil": "+56911234458",
    "telefonoFijo": "+56265652458",
    "password": "4c882dcb24bcb1bc225391a602feca7c",
    "genero": "Femenino",
    "pais": "Chile",
    "tipoUsuario": "Administrador",
    "direccion": {
      "region": "Coquimbo",
      "comuna": "Coquimbo",
      "calle": "Calle Santa Europa",
      "numero": "1225",
      "depto": "22",
      "casa": ""
    }
  }
  ```

## PUT /api/v1/usuario/{rut}
Modifica la información del usuario especificado por rut
```
// JSON de entrada
{
    "rut": "14622572",
    "dv": "0",
    "primerNombre": "Andrea",
    "segundoNombre": "Fernanda",
    "apellidoPaterno": "Espinoza",
    "apellidoMaterno": "Lopez",
    "fechaNacimiento": "1989-09-21T00:00:00",
    "correo": "a.fernan@gmail.com",
    "telefonoMovil": "+56911234458",
    "telefonoFijo": "+56265652458",
    "genero": "Femenino",
    "pais": "Chile",
    "tipoUsuario": "Administrador",
    "direccion": {
      "region": "Coquimbo",
      "comuna": "Coquimbo",
      "calle": "Calle Santa Europa",
      "numero": "1225",
      "depto": "22",
      "casa": ""
    }
  }
  ```

## DELETE /api/v1/usuario/{rut}
Elimina de la base de datos al usuario especificado por rut