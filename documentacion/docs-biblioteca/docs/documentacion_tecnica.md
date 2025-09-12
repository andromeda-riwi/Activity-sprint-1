# Documentación Técnica del Sistema de Biblioteca

## 1. Introducción y Justificación

Este proyecto implementa un **Sistema de Biblioteca en Consola** desarrollado en C#, diseñado para resolver las ineficiencias de la gestión manual en una biblioteca tradicional. Proporciona una plataforma centralizada para administrar libros, usuarios, préstamos y reseñas, mejorando la eficiencia administrativa y la experiencia del usuario.

## 2. Arquitectura del Proyecto

El sistema se organiza en un enfoque de Programación Orientada a Objetos (POO), utilizando clases para modelar las entidades principales. Las clases principales son `Libro`, `Usuario`, `Reseña` y `Prestamo`. La clase `SistemaBiblioteca` actúa como el motor principal del programa, gestionando las listas globales de libros, usuarios y préstamos, y controlando el flujo de la aplicación a través de un menú en la consola.

### 2.1 Clases Principales

* **`Libro`**: Representa un libro con propiedades como `Titulo`, `Autor`, `Categoria`, `Año` y `Disponible`. Incluye una lista para almacenar las `Reseñas` y un contador para las veces que ha sido prestado (`VecesPrestado`). También tiene un método para calcular la calificación promedio de las reseñas (`ObtenerCalificacionPromedio`).
* **`Usuario`**: Almacena información del usuario, incluyendo `Nombre`, `Identificacion` y `Correo`.
* **`Reseña`**: Guarda la `Calificacion` (0.0-5.0) y un `Comentario` sobre un libro.
* **`Prestamo`**: Registra un préstamo activo, vinculando un `Libro` y un `Usuario`, y almacena la `FechaPrestamo`.

## 3. Funcionalidades del Sistema

El programa está estructurado en módulos accesibles a través de un menú principal.

* **Gestión de Libros**: Permite registrar nuevos libros, listarlos y buscarlos por título, autor o categoría.
* **Gestión de Usuarios**: Facilita el registro y la consulta de usuarios.
* **Préstamos y Devoluciones**: Gestiona el proceso de prestar y devolver libros, verificando la disponibilidad.
* **Reseñas y Calificaciones**: Permite a los usuarios calificar libros y consultar sus calificaciones promedio.
* **Estadísticas**: Proporciona información clave como el número total de libros y usuarios, y el libro más prestado.

---
