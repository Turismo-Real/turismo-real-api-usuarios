# Tursmo Real Usuarios
Servicio REST para administrar los usuarios de Turismo Real.  
Actualmente el proyecto se encuentra sin la validación de los datos de entrada.

## Prerrequisito
Antes de levantar el servicio REST se debe haber levantado completamente la base de datos en Oracle, de lo contrario el servicio no funcionará como corresponde.  
- [Levantar base de datos Turismo Real - Oracle 11g](https://github.com/Turismo-Real/turismo-real-database)
  
## Levantar Servicio
Para poder levantar el servicio localmente, lo primero que se debe asegurar es tener instalado el runtime de .NET Core 3.1 que se puede descargar desde el siguiente enlace *(se recomienda instalar SDK)*: [Runtime y SDK .NET Core 3.1 LTS](https://dotnet.microsoft.com/download).  

### Comprobar instalación de Runtime o SDK  
Abrir una terminal y ejecutar los siguientes comandos, según sea la necesidad. Información extraída de la [documentación de dotnet](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet).
- `dotnet --info`: Obtener información detallada sobre la instalación de .NET en la máquina local.  
- `dotnet --version`: Obtener la versión de .NET SDK.
- `dotnet --list-runtimes`: Obtener lista de los runtimes de .NET instalados en la máquina.
- `dotnet --list-sdks`: Lista los SDKs de .NET instalados en la máquina.

### Compilar y ejecutar servicio desde CLI
Una vez instaladas las herramientas necesarias para la ejecución, el siguiente paso es clonar el repositorio y ubicarse dentro de él, donde se puede encontrar un archivo con la extensión `sln`. En esa ubicación se ejecuta el comando `dotnet build` que comenzará la compilación de la solución.  
  
Una vez compilado, se debe dirigir al directorio `TurismoReal_Usuarios.Api` y dentro ejecutar el comando `dotnet run`.  
Con esto el servicio quedaría corriendo en `http://localhost:5001`.

### Abrir desde Visual Studio
Para abrir el servicio desde visual studio, solamente se debe abrir un proyecto y buscar el archivo que termina con la extensión `sln` y el IDE hace el resto.

---
## Consumir Servicio  
Para consumir el servicio cuando este se encuentra en ejecución, se debe hacer uso de un cliente HTTP como Insomnia o Postman. El servicio cuenta con los siguientes endpoints.

- **GET /api/v1/usuario**
- **GET /api/v1/usuario/{id}**
- **POST /api/v1/usuario**
- **PUT /api/v1/usuario/{id}**
- **DELETE /api/v1/usuario/{id}**  
---  

A continuación se detalla como consumir cada uno de los endpoints del servicio.  
## GET /api/v1/usuario  
Retorna todos los usuarios reigstrados en la base de datos  
- **URL:** http://localhost:5001/api/v1/usuario
- **Method:** GET
- **Respuesta:** Retorna un arreglo con los usuarios del sistema ordenados por ID  

## GET /api/v1/usuario/{rut}
Retorna información del usuario especificado por id.  
El password del usuario siempre se recibe como `null`.
- **URL:** http://localhost:5001/api/v1/usuario/{id}
- **Method:** GET
- **Respuesta:** Retorna un objeto con la información del usuario.  
```
# EJEMPLO OBJETO DE SALIDA
{
    "id": 9,
    "pasaporte": "654654987",
    "rut": "",
    "dv": "",
    "primerNombre": "Javiera",
    "segundoNombre": "Ignacia",
    "apellidoPaterno": "Gomez",
    "apellidoMaterno": "Lopez",
    "fechaNacimiento": "0089-09-21T00:00:00",
    "correo": "fransc.gomez@gmail.com",
    "telefonoMovil": "+56911234458",
    "telefonoFijo": "+56265652458",
    "password": null,
    "genero": "Femenino",
    "pais": "Chile",
    "tipoUsuario": "Cliente",
    "direccion": {
        "region": "Metropolitana de Santiago",
        "comuna": "Cerro Navia",
        "calle": "La galaxia",
        "numero": "1225",
        "depto": "22",
        "casa": ""
    }
}

```

## POST /api/v1/usuario
Crea un nuevo usuario en la base de datos.  
El atributo password debe ser la contraseña del usuario encriptada en SHA256.  
Este es el único objeto donde es visible la contraseña cifrada del usuario. 
No es necesario enviar la región, ya que está directamente vinculada con la comuna.   

- **URL:**  http://localhost:5001/api/v1/usuario
- **Method:** POST
- **Respuesta:** Retorna el mismo objeto de entrada pero añadiendo el ID generado en la base de datos

```
# EJEMPLO OBJETO DE ENTRADA
{
    "pasaporte": "654654987",
    "rut": "",
    "dv": "",
    "primerNombre": "Francisca",
    "segundoNombre": "Fernanda",
    "apellidoPaterno": "Gomez",
    "apellidoMaterno": "Lopez",
    "fechaNacimiento": "1989-09-21T00:00:00",
    "correo": "xyx.gomez@gmail.com",
    "telefonoMovil": "+56911234458",
    "telefonoFijo": "+56265652458",
    "password": "37d74b2b81bda7ee94262f273b4b1d4dd8bf443b5b2d58f4f1fe3117d07c2407",
    "genero": "Femenino",
    "pais": "Chile",
    "tipoUsuario": "cliente",
    "direccion": {
      "comuna": "cerro navia",
      "calle": "La galaxia",
      "numero": "1225",
      "depto": "22",
      "casa": ""
    }
  }
  ```

## PUT /api/v1/usuario/{id}
Modifica la información del usuario especificado por ID.  
No es necesario enviar nombre de región, ya que está directamente vinculada con la comuna.  
Con este método no es posible modificar la contraseña del usuario, por lo que no es necesario enviarla en el payload.  

- **URL:** http://localhost:5001/api/v1/usuario/{id}
- **Method:** PUT
- **Respuesta:** Retorna toda la información del usuario, incluyendo su ID, excepto la contraseña.  
```
# EJEMPLO OBJETO DE ENTRADA
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
      "comuna": "Coquimbo",
      "calle": "Calle Santa Europa",
      "numero": "1225",
      "depto": "22",
      "casa": ""
    }
  }
  ```

## DELETE /api/v1/usuario/{rut}
Elimina del sistema, al usuario especificado por ID.  
- **URL:** http://localhost:5001/api/v1/usuario/{id}
- **Method:** PUT
- **Respuestas:**  
```
# RESPONSE OK
{
    "message": "Usuario eliminado.",
    "removed": true
}
```

```
# RESPONSE ID INEXISTENTE
{
    "message": "No existe el usuario con id 50",
    "removed": false
}
```
```
# BAD RESPONSE
{
    "message": "Error al eliminar el usuario.",
    "removed": false
}
```