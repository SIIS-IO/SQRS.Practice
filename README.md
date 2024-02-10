# Implementación del Patrón CQRS en C#

## Descripción

Este proyecto demuestra la implementación del patrón de diseño Command Query Responsibility Segregation (CQRS) en C#. El patrón CQRS separa las operaciones de lectura (query) de las operaciones de escritura (command) en una aplicación, lo que permite una mayor flexibilidad, escalabilidad y mantenibilidad.

## Requisitos

- .NET 5.0 o superior
- Visual Studio 2019 o superior
- SQL Server o cualquier otra base de datos compatible

## Configuración

1. Clona el repositorio a tu máquina local.
2. Abre la solución en Visual Studio.
3. Configura la cadena de conexión a tu base de datos en el archivo `appsettings.json`.
4. Ejecuta las migraciones de la base de datos usando Entity Framework Core para crear las tablas necesarias. Esto se puede hacer a través de la consola del administrador de paquetes con el comando `Update-Database`.

## Estructura del Proyecto

El proyecto se divide en varias capas para separar responsabilidades:

- **Api**: Capa de presentación que expone los endpoints HTTP.
- **Aplicación**: Contiene la lógica de negocio, incluyendo los comandos y consultas.
- **Dominio**: Define las entidades y reglas de negocio.
- **Infraestructura**: Implementación de acceso a datos y otras operaciones de infraestructura.

## Ejemplo de Uso

### Comandos

Los comandos representan las solicitudes de operaciones de escritura. Ejemplo:

```csharp
public class CrearUsuarioCommand : IRequest<int>
{
    public string Nombre { get; set; }
    public string Email { get; set; }
    // Otros campos relevantes
}
