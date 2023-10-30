# Api Rest .NET 6 con C# y Entity Framework

## TABLA DE CONTENIDO

* [Acerca del proyecto](#acerca-del-proyecto)
* [Características](#caracteristicas)
* [Instalación](#instalacion)
* [Documentación API_ABAN](#documentacion-api-aban)
  * [Endpoints](#endpoints)
* [Validaciones](#validaciones)
* [Arquitectura de Software](#arquitectura-de-software)
  * [Principios SOLID](#principios-solid)
  * [Patrones de Diseño](#patrones-de-diseño)

## 🔥 ACERCA DEL PROYECTO

🦄 Este proyecto es una muestra de una solución CRUD base de una API con autenticación JWT. Se utilizó ``ASP.NET Core 6`` Web API.

## ✔️ CARACTERÍSTICAS

- [x] GetCliente
- [x] GetByIdCliente
- [x] FilterByNameCliente
- [x] PostCliente
- [x] PutCliente
- [x] DeleteCliente
- [x] RestaurarCliente


## ⚙️ INSTALACIÓN

#### Clonar el repositorio.

```bash
gh repo clone https://github.com/ronyepez/Test-ABAN.git
```


#### Configuración de la aplicación .NET 6 (Desarrollo)

##### Ruta: `/appsettings.Development.json`  
Archivo de configuración con ajustes de la aplicación que son específicos del entorno de desarrollo, incluye la cadena de conexión `Default`, cambiar el valor de `{"server name"}` por el nombre del servidor SQL donde se alojará la base de datos de desarrollo.

##### Ejemplo Actual
    "Default": "Server={"server name"}; Database=TestAban_Ry; Integrated Security=True;TrustServerCertificate=True;",
##### Ejemplo de como debe quedar
    "Default": "Server=localhost; Database=TestAban_Ry; Integrated Security=True;TrustServerCertificate=True;"


#### Crear BD y Modelo de datos.
Ejecutar en la consola de Visual de estudio el comando:
```bash
PM> Update-Database
```
Verificar en SQL que se haya creado la BD `TestAban_Ry` con las tablas `clientes` y `domicilios` con 3 registros para realizar pruebas.

## 📓 Documentación API_ABAN
### Endpoints
### 1. Obtener una lista de Clientes
###### Método: `GET`
###### Ruta: `/clientes`
###### Descripción: `Este endpoint devuelve una lista de todos los clientes registrados en el sistema, incluyendo sus direcciones asociadas.`
###### Respuesta Exitosa: `200 OK `
###### Respuesta Exitosa (Ejemplo):
```
[
  {
    "clienteId": 1,
    "nombres": "Pedro",
    "apellidos": "Pérez",
    "fechaNacimiento": "2000-10-23T00:00:00",
    "cuit": "252032546",
    "email": "pperez@gmail.com",
    "celular": 1125631478,
    "direccion": {
      "direccionID": 1,
      "calle": "Calle 2",
      "numero": 123,
      "ciudad": "Ciudad B",
      "provincia": "Provincia A",
      "pais": "Argentina"
    }
  },
  // ... Otros clientes
]
```

### 2. Consultar un Cliente por ID
###### Método: `GET`
###### Ruta: `/clientes/{id}`
###### Descripción: `Este endpoint devuelve la información detallada de un cliente específico, incluyendo su dirección asociada.`
###### Parámetros de Ruta: `id (int)` Identificador único del cliente.
###### Respuesta Exitosa: `200 OK`
###### Respuesta Exitosa (Ejemplo):
```
{
  "clienteId": 2,
  "nombres": "María",
  "apellidos": "Santana",
  "fechaNacimiento": "1995-02-19T00:00:00",
  "cuit": "202054564",
  "email": "msantana@gmail.com",
  "celular": 1165231590,
  "direccion": {
    "direccionID": 3,
    "calle": "Calle 1",
    "numero": 456,
    "ciudad": "Ciudad C",
    "provincia": "Provincia C",
    "pais": "Argentina"
  }
}
```

### 3. Filtrar Clientes por Nombre
###### Método: `GET`
###### Ruta: `/clientes/filtrar/{nombre}`
###### Descripción: `Este endpoint permite filtrar clientes por nombre. Retorna una lista de clientes cuyos nombres contengan las letras indicadas.`
###### Parámetros de Ruta: `nombre (string)` Letras a utilizar para el filtrado.
###### Respuesta Exitosa: `200 OK`
###### Respuesta Exitosa (Ejemplo):
```
[
  {
    "clienteId": 1,
    "nombres": "Pedro",
    "apellidos": "Pérez",
    "fechaNacimiento": "2000-10-23T00:00:00",
    "cuit": "252032546",
    "email": "pperez@gmail.com",
    "celular": 1125631478,
    "direccion": {
      "direccionID": 1,
      "calle": "Calle 2",
      "numero": 123,
      "ciudad": "Ciudad B",
      "provincia": "Provincia A",
      "pais": "Argentina"
    }
  },
  // ... Otros clientes
]
```

### 4. Crear un Nuevo Cliente
###### Método: `POST`
###### Ruta: `/clientes`
###### Descripción: `Este endpoint permite agregar un nuevo cliente al sistema. Debes proporcionar los detalles del cliente en el cuerpo de la solicitud.`
###### Cuerpo de la Solicitud (Ejemplo):
```
{
  "nombres": "Axel",
  "apellidos": "Peña",
  "fechaNacimiento": "2020-10-23T00:42:29.497Z",
  "cuit": "25952016",
  "email": "apeña@gmail.com",
  "celular": 1130192603,
  "direccion": {
    "calle": "La Rioja",
    "numero": 789,
    "ciudad": "Buenos Aires",
    "provincia": "CABA",
    "pais": "Argentina"
  }
}```
###### Respuesta Exitosa: `200 OK`
###### Respuesta Exitosa (Ejemplo):
```
{
  "message": "Cliente agregado correctamente.",
  "clienteId": 4
}
```

### 5. Actualizar Cliente
###### Método: `PUT`
###### Ruta: `/clientes/{id}`
###### Descripción: `Este endpoint permite actualizar la información de un cliente existente. Debes proporcionar el ID del cliente en la ruta y los detalles actualizados en el cuerpo de la solicitud.`
###### Parámetros de Ruta: `id (int)` Identificador único del cliente.
###### Cuerpo de la Solicitud (Ejemplo):
```
{
    "nombres": "Carmen Luisa",
    "apellidos": "Contreras",
    "fechaNacimiento": "1999-12-19T00:00:00",
    "cuit": "252005569",
    "email": "ccontreras@gmail.com",
    "celular": 1161971590,
    "direccion": {
      "direccionID": 2,
      "calle": "Sarmiento",
      "numero": 1439,
      "ciudad": "Gran Buenos Aires",
      "provincia": "Mar del Plata",
      "pais": "Argentina"
  }
}
```
###### Respuesta Exitosa: `204 No Content`
###### Respuesta Exitosa (Ejemplo):
```
{
  "message": "Cliente Modificado correctamente."
}
```
### 6. Eliminar Cliente (Lógicamente)
###### Método: `DELETE`
###### Ruta: `/clientes/{id}`
###### Descripción: `Este endpoint permite eliminar lógicamente un cliente al establecer el campo DeletedAt en true.`
###### Parámetros de Ruta: `id (int)` Identificador único del cliente.
###### Respuesta Exitosa: `204 No Content`
```
{
  "message": "Cliente Eliminado correctamente."
}
```
### 7. Restaurar Cliente
###### Método: `POST`
###### Ruta: `/clientes/restaurar/{id}`
###### Descripción: `Este endpoint permite restaurar un cliente previamente eliminado lógicamente al establecer el campo DeletedAt en false.`
###### Parámetros de Ruta: `id (int): Identificador único del cliente.`
###### Respuesta Exitosa: `200 OK`
###### Respuesta Exitosa (Ejemplo):
```
{
  "message": "Cliente Restaurado correctamente."
}
```

## 📄 Validaciones
Se agregaron las siguientes las sigueintes validaciones en el create y update: 
##### Campo: `Nombre`
##### Descripción: `El Nombre es obligatorio`
##### Ejemplo de response:
```
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "traceId": "00-de5c42d56ced38f37f8d160f7e1e1489-593e49bd4b1b1edd-00",
  "errors": {
    "Nombres": [
      "El Nombre es obligatorio."
    ]
  }
}
```
##### Campo: `Apellido`
##### Descripción: `El Apellido es obligatorio`
##### Ejemplo de response:
```
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "traceId": "00-02a445cc1adc0c0793a0669ccdd91734-17ba359edce49bf9-00",
  "errors": {
    "Apellidos": [
      "El Apellido es obligatorio."
    ]
  }
}
```
##### Campo: `CUIT`
##### Descripción: `El CUIT es obligatorio`
##### Ejemplo de response:
```
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "traceId": "00-86045da9c42a09e9d594ccf42347e2be-949f12e72045f640-00",
  "errors": {
    "CUIT": [
      "El CUIT es obligatorio."
    ]
  }
}
```
##### Campo: `Email`
##### Descripción: `Dirección de correo electrónico no válida`
##### Ejemplo de response:
```
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "traceId": "00-22933c340bf524711a5f53a7731dc46c-f9971dca39e77840-00",
  "errors": {
    "Email": [
      "Dirección de correo electrónico no válida."
    ]
  }
}
```

## 📥 Arquitectura de Software
### Principios SOLID
##### 1. Principio de Responsabilidad Única (SRP):
###### Aplicación: 
Cada clase y método tiene una única responsabilidad. Por ejemplo, el ClienteService se encarga de la lógica de negocio relacionada con los clientes y el ClienteRepository se encarga de interactuar con la base de datos para obtener o modificar datos de los clientes.

##### 2. Principio de Abierto/Cerrado (OCP):
###### Aplicación: 
El código está abierto para extensiones pero cerrado para modificaciones. Esto significa que se pueden agregar nuevas funcionalidades (por ejemplo, nuevos métodos en el servicio o repositorio) sin modificar el código existente.

##### 3. Principio de Sustitución de Liskov (LSP):
###### Aplicación: 
Las clases derivadas (ClienteService y ClienteRepository) pueden ser sustituidas por sus clases base (IClienteService e IClienteRepository) sin afectar la corrección del programa.

##### 4. Principio de Segregación de la Interfaz (ISP):
###### Aplicación: 
Las interfaces (IClienteService e IClienteRepository) están diseñadas para ser específicas y no contienen métodos innecesarios para las clases que las implementan. Cada interfaz tiene un propósito claro.

##### 5. Principio de Inversión de Dependencia (DIP):
###### Aplicación: 
Las clases de alto nivel (como ClientesController y ClienteService) dependen de abstracciones (IClienteService e IClienteRepository) en lugar de implementaciones concretas. Esto facilita la sustitución y extensión de implementaciones sin modificar el código de alto nivel.

### Patrones de Diseño
##### 1. Inyección de Dependencias:
###### Aplicación: 
Se utilizó a través del constructor en las clases que lo requieren. Por ejemplo, ClientesController recibe una instancia de IClienteService a través del constructor, lo que facilita la prueba unitaria y desacopla las dependencias.

##### 2. Patrón de Servicio:
###### Aplicación: 
Se utilizó para encapsular la lógica de negocio relacionada con los clientes en el ClienteService. Esto ayuda a mantener los controladores limpios y separa la lógica de negocio de la lógica de presentación.

##### 3. Patrón de Repositorio:
###### Aplicación: 
Se utilizó para encapsular la interacción con la base de datos en el ClienteRepository. Esto facilita la prueba y el cambio de la capa de persistencia en el futuro sin afectar la lógica de negocio.

##### 4. Mapeo de Objetos (AutoMapper):
###### Aplicación: 
Se utilizó para mapear entre las entidades y los DTOs. Esto reduce la complejidad de copiar manualmente los datos y mejora la legibilidad del código.
Estos principios y patrones ayudan a crear un código más mantenible, flexible y escalable, lo que facilita la incorporación de nuevas funcionalidades y la gestión de cambios en el proyecto a medida que evoluciona.

###End