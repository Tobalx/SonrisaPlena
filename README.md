
# 🦷 Sonrisa Plena
**Nombres:**
Hilary Varela, 
Cristobal Martinez, 
Leonardo Miranda

**Sonrisa Plena** es una aplicación web desarrollada con ASP.NET Core MVC y Entity Framework Core que permite 
la gestión integral de una clínica dental. Incluye módulos para pacientes, odontólogos, recepcionistas y
administradores, permitiendo agendar citas, registrar historiales clínicos, y controlar la información de los usuarios.

---

## 📌 Descripción del proyecto

Este sistema web fue creado como solución para la administración de una clínica dental moderna. Entre sus 
características principales se incluyen:

- Registro y gestión de usuarios (Pacientes, Odontólogos, Recepcionistas, Administradores)
- Sistema de autenticación basado en roles
- Agendamiento de citas
- Historial clínico del paciente
- Paneles personalizados según el rol
- Arquitectura MVC con base de datos SQL Server

---

## ⚙️ Tecnologías utilizadas

Este proyecto utiliza las siguientes tecnologías y paquetes NuGet:

- ASP.NET Core MVC (.NET 8/9)
- Entity Framework Core 9.0.6
- EF Core Design Tools 9.0.6
- SQL Server
- EF Tools 8.0.11
- Razor Pages
- Bootstrap (en el frontend)
- Microsoft Visual Studio Web Code Generation Design 8.0.7

---

## 🛠️ Pasos de instalación

### 1. Clonar el repositorio
```bash
git clone https://github.com/Tobalx/SonrisaPlena.git
cd SonrisaPlena
```

### 2. Restaurar los paquetes NuGet
```bash
dotnet restore
```

### 3. Crear la base de datos
Asegúrate de configurar la cadena de conexión en `appsettings.json` apuntando a tu instancia de SQL Server:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=MVCClinica;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### 4. Ejecutar migraciones
Aplica las migraciones para crear la base de datos con sus tablas:

```bash
dotnet ef database update
```

### 5. Ejecutar el proyecto
```bash
dotnet run
```

Accede en tu navegador a `https://localhost:5001` o `http://localhost:5000`

---

## 🧑‍⚕️ Uso del sistema

### 👤 **Administrador**
- Alta/Baja/Modificación de:
  - Odontólogos
  - Recepcionistas
  - Tratamientos
  - Configuración general del sistema

### 🦷 **Odontólogo especialista**
- Visualiza su propia agenda y fichas clínicas de pacientes.
- Crea planes de tratamiento personalizados por paciente:
  - Secuencia de tratamientos propuestos
  - Fechas estimadas para cada paso
  - Estado por paso: pendiente / realizado / cancelado
  - Observaciones clínicas
  - Exportación del plan en PDF
  - Visualización del avance general del plan

### 👥 **Recepcionista**
- Alta/Baja/Modificación de pacientes
- Gestión de turnos:
  - Búsqueda de citas disponibles
  - Asignación de turnos a pacientes y odontólogos
  - Cambio de estado de turnos (pendiente, confirmado, realizado, cancelado)

### 👩‍⚕️ **Paciente**
- Consulta de su historial clínico y tratamientos realizados.
- Visualización de su agenda y planes de tratamiento.
- Operación de transición para **solicitar una cita** con un odontólogo.

### 📅 **Turnos**
- Registro de citas con fecha, hora y duración.
- Asociación con paciente y odontólogo.
- Estados de turno: Pendiente / Confirmado / Realizado / Cancelado.
- Visualización de agenda semanal por profesional.

### 💊 **Tratamientos**
- ABM de tratamientos ofrecidos:
  - Nombre, descripción, precio estimado
- Registro automático en el historial clínico del paciente al ser realizados.

---

# 📘 Manual de Usuario – Sonrisa Plena 🦷

**Versión del sistema:** 1.0  
**Dirigido a:** Usuarios no técnicos de la clínica dental  
**Propósito:** Explicar de forma clara y sencilla cómo utilizar el sistema web **Sonrisa Plena**

---

## 🧑‍💻 1. Ingreso al sistema

- Abre el navegador y accede a `http://localhost:5000`
- Introduce tu **correo electrónico** y **contraseña**
- Según tu perfil, verás opciones distintas en el menú principal

---

## 👤 2. Administrador

**Funcionalidades principales:**

- Crear, editar y eliminar odontólogos, recepcionistas y tratamientos
- Configurar el sistema general

**Ejemplo:**

1. Ir al menú "Odontólogos"
2. Hacer clic en "Agregar"
3. Llenar los campos (nombre, matrícula, especialidad, email)
4. Guardar

---

## 🦷 3. Odontólogo especialista

**Funcionalidades principales:**

- Ver agenda de turnos
- Consultar ficha de pacientes
- Crear planes de tratamiento personalizados

**Ejemplo:**

1. Ir a "Mis pacientes"
2. Seleccionar un paciente
3. Hacer clic en "Crear plan"
4. Añadir pasos con fechas y observaciones
5. Guardar y, si se desea, exportar a PDF

---

## 🧑‍💼 4. Recepcionista

**Funcionalidades principales:**

- Registrar nuevos pacientes
- Asignar y modificar turnos

**Ejemplo:**

1. Ir al menú "Turnos"
2. Hacer clic en "Nuevo"
3. Seleccionar paciente y odontólogo
4. Elegir fecha y hora
5. Confirmar

---

## 👩‍⚕️ 5. Paciente

**Funcionalidades principales:**

- Ver historial clínico
- Solicitar citas
- Ver el plan de tratamiento

**Ejemplo:**

1. Ingresar al sistema
2. Ir al menú "Solicitar cita"
3. Elegir especialidad y profesional
4. Confirmar solicitud

---

## 📌 Recomendaciones

- Utiliza Google Chrome para mejor compatibilidad
- En caso de dudas, contactar al administrador del sistema


