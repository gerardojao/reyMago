# CHALLENGE BACKEND - C# .NET IA INTERACTIVE
<h3 align="center">
:construction: Proyecto en construcción :construction:
</h3>

### En este proyecto, se utilizó:
 - Visual Studio 2022
 - .NET 6.0
 - SQL SERVER
 - IMPORTANTE: En el proyecto se utilizaron SEEDS con la intencion de alimentar la base de datos, una vez aplicados se realizao la migracion desde la terminal NuGGET con los comandos add-Migration "NOMBRE DE LA MIGRACION", luego update-Migration, y asi se alimenta la base de datos SQL SERVER


## :mega:Indicaciones para inicializar el Proyecto
1. Utiliza para este proyecta Visual Studio 2022, si aún no lo tienes descarga VISUAL STUDIO COMMUNITY.
2. Clona el repositorio desde esta url: https://github.com/gerardojao/reyMago.git.
3. Checa que las dependencias esten instaladas.
4. Esta es la cadena de conexión para con la Base de Datos, **"DevConnection": "Server=TU PROPIO SERVIDOR; database=TU BASE DE DATOS; Trusted_Connection=true; MultipleActiveResultSets=true"**. Debes configurar tu archivo **appsettings.json**.
9. Procede a correr el proyector y a utilizar la aplicación ReyMagoAPI, puedes hacerlo desde ViSUAL STUDIO CODE.
 
## :hammer:Funcionalidades del proyecto

1. Primero que todo trate de entender el requerimiento, y luego de esto se comenzó a planificar la estructura del proyecto.
2. Para poder darle funionalidad a la API, se crearon MOdelos, DTO (Data TRansfer Object), Controladores, Interfaces y Repositorios
3. `Obtener todas las Solicitudes de Ingreso`: (GET/SolicitudIngreso)
4. `Creación, Edición, Eliminación de Solicitudes de Ingreso (CRUD)`: Podrá crear nuevas solicitudes, editar y/o eliminar solicitudes existentes. 
 - POST /SolicitudIngreso
 - PUT /SolicitudIngreso/id 
 - DELETE /SolicitudIngreso/id.
5.  `Consultar asignaciones de Grimorios`: A través de este endpoint se podrá chequear todas las solicitudes que ya tiene asignado algún grimorio es decir, se podrá hacer una busqueda por nombre de Grimorio. El endpoint a utilizar: 
 - GET /SolicitudIngreso/ByGrimorio/name.
6.  `Editar Estatus de la Solicitud`: A través de este endpoint se podrá actualizar el estatus de cada solicitud, una vez hech esto, se asiganra a cada solicitud un ekemento (grimorio) aleatoriamente.
 -  PUT /solicitudIngreso/StatusUpdate/{id}
 



