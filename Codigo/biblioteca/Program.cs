using System;
using System.Collections.Generic;



List<Libro> books = new List<Libro>();
List<Usuario> users = new List<Usuario>();
List<Prestamo> loans = new List<Prestamo>();

bool exit = false;
while (!exit)
{
    Console.Clear();
    Console.WriteLine("===== SISTEMA DE BIBLIOTECA =====");
    Console.WriteLine("1. Gestión de Libros");
    Console.WriteLine("2. Gestión de Usuarios");
    Console.WriteLine("3. Préstamos y Devoluciones");
    Console.WriteLine("4. Reseñas y Calificaciones");
    Console.WriteLine("5. Estadísticas");
    Console.WriteLine("6. Salir");
    Console.Write("\nSeleccione una opción: ");

    string mainOption = Console.ReadLine();

    switch (mainOption)
    {
        case "1": // Libros
            Console.Clear();
            Console.WriteLine("*** Gestión de Libros ***");
            Console.WriteLine("1. Registrar un nuevo libro");
            Console.WriteLine("2. Listar todos los libros");
            Console.WriteLine("3. Buscar un libro");
            Console.Write("\nSeleccione una opción: ");
            string bookOption = Console.ReadLine();

            switch (bookOption)
            {
                case "1": // Registrar
                    Console.Clear();
                    Console.WriteLine("*** Registrar Nuevo Libro ***");
                    Console.Write("Título: ");
                    string title = Console.ReadLine();
                    Console.Write("Autor: ");
                    string author = Console.ReadLine();
                    Console.Write("Categoría: ");
                    string category = Console.ReadLine();
                    Console.Write("Año de publicación: ");
                    int year = int.Parse(Console.ReadLine());
                    books.Add(new Libro(title, author, category, year));
                    Console.WriteLine("\nLibro registrado con éxito");
                    break;
                case "2": // Listar
                    Console.Clear();
                    Console.WriteLine("*** Listado de Libros ***");
                    if (books.Count == 0) { Console.WriteLine("No hay libros registrados."); }
                    else
                    {
                        foreach (var book in books)
                        {
                            string status = book.Disponible ? "Disponible" : "Prestado";
                            Console.WriteLine($"Título: {book.Titulo}, Autor: {book.Autor}, Categoría: {book.Categoria}, Año: {book.Año}, Estado: {status}");
                        }
                    }
                    break;
                case "3": // Buscar
                    Console.Clear();
                    Console.WriteLine("*** Buscar Libro ***");
                    Console.Write("Ingrese término de búsqueda: ");
                    string searchTerm = Console.ReadLine().ToLower();

                    List<Libro> results = new List<Libro>();
                    foreach (var book in books)
                    {
                        if (book.Titulo.ToLower().Contains(searchTerm) || book.Autor.ToLower().Contains(searchTerm) || book.Categoria.ToLower().Contains(searchTerm))
                        {
                            results.Add(book);
                        }
                    }

                    if (results.Count == 0) { Console.WriteLine("No se encontraron libros."); }
                    else
                    {
                        Console.WriteLine("\nResultados encontrados:");
                        foreach (var book in results)
                        {
                            string status = book.Disponible ? "Disponible" : "Prestado";
                            Console.WriteLine($" - {book.Titulo} por {book.Autor} ({status})");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("\nOpción no válida.");
                    break;
            }
            Console.WriteLine("\nPresione una tecla para volver...");
            Console.ReadKey();
            break;

        case "2": // Usuarios
            Console.Clear();
            Console.WriteLine("*** Gestión de Usuarios ***");
            Console.WriteLine("1. Registrar un nuevo usuario");
            Console.WriteLine("2. Listar todos los usuarios");
            Console.Write("\nSeleccione una opción: ");
            string userOption = Console.ReadLine();

            switch (userOption)
            {
                case "1": // Registrar
                    Console.Clear();
                    Console.WriteLine("*** Registrar Nuevo Usuario ***");
                    Console.Write("Nombre completo: ");
                    string name = Console.ReadLine();
                    Console.Write("Identificación (DNI/ID): ");
                    string id = Console.ReadLine();
                    Console.Write("Correo electrónico: ");
                    string email = Console.ReadLine();
                    users.Add(new Usuario(name, id, email));
                    Console.WriteLine("\nUsuario registrado con éxito");
                    break;
                case "2": // Listar
                    Console.Clear();
                    Console.WriteLine("*** Listado de Usuarios ***");
                    if (users.Count == 0) { Console.WriteLine("No hay usuarios registrados."); }
                    else
                    {
                        foreach (var user in users)
                        {
                            Console.WriteLine($"Nombre: {user.Nombre}, ID: {user.Identificacion}, Correo: {user.Correo}");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("\nOpción no válida.");
                    break;
            }
            Console.WriteLine("\nPresione una tecla para volver...");
            Console.ReadKey();
            break;

        case "3": // Préstamos
            Console.Clear();
            Console.WriteLine("*** Préstamos y Devoluciones ***");
            Console.WriteLine("1. Prestar un libro");
            Console.WriteLine("2. Registrar devolución");
            Console.WriteLine("3. Mostrar libros prestados");
            Console.Write("\nSeleccione una opción: ");
            string loanOption = Console.ReadLine();

            switch (loanOption)
            {
                case "1": // Prestar
                    Console.Clear();
                    Console.WriteLine("*** Prestar Libro ***");
                    Console.Write("Ingrese el título del libro a prestar: ");
                    string bookTitle = Console.ReadLine();

                    Libro bookToLoan = null;
                    foreach (var book in books)
                    {
                        if (book.Titulo.Equals(bookTitle, StringComparison.OrdinalIgnoreCase))
                        {
                            bookToLoan = book;
                            break;
                        }
                    }

                    if (bookToLoan == null) { Console.WriteLine("El libro no existe."); }
                    else if (!bookToLoan.Disponible) { Console.WriteLine("El libro no está disponible."); }
                    else
                    {
                        Console.Write("Ingrese la identificación del usuario: ");
                        string userId = Console.ReadLine();

                        Usuario lendingUser = null;
                        foreach (var user in users)
                        {
                            if (user.Identificacion.Equals(userId))
                            {
                                lendingUser = user;
                                break;
                            }
                        }

                        if (lendingUser == null) { Console.WriteLine("El usuario no está registrado."); }
                        else
                        {
                            bookToLoan.Disponible = false;
                            bookToLoan.VecesPrestado++;
                            loans.Add(new Prestamo(bookToLoan, lendingUser));
                            Console.WriteLine($"\nEl libro '{bookToLoan.Titulo}' ha sido prestado a {lendingUser.Nombre}.");
                        }
                    }
                    break;
                case "2": // Devolver
                    Console.Clear();
                    Console.WriteLine("*** Registrar Devolución ***");
                    Console.Write("Ingrese el título del libro a devolver: ");
                    string bookTitleToReturn = Console.ReadLine();

                    Prestamo loanToReturn = null;
                    foreach (var loan in loans)
                    {
                        if (loan.LibroPrestado.Titulo.Equals(bookTitleToReturn, StringComparison.OrdinalIgnoreCase))
                        {
                            loanToReturn = loan;
                            break;
                        }
                    }

                    if (loanToReturn == null) { Console.WriteLine("Este libro no figura como prestado."); }
                    else
                    {
                        loanToReturn.LibroPrestado.Disponible = true;
                        loans.Remove(loanToReturn);
                        Console.WriteLine($"\nEl libro '{loanToReturn.LibroPrestado.Titulo}' ha sido devuelto.");
                    }
                    break;
                case "3": // Listar prestados
                    Console.Clear();
                    Console.WriteLine("*** Libros Actualmente Prestados ***");
                    if (loans.Count == 0) { Console.WriteLine("No hay libros prestados."); }
                    else
                    {
                        foreach (var loan in loans)
                        {
                            Console.WriteLine($" - '{loan.LibroPrestado.Titulo}' prestado a {loan.UsuarioPrestamo.Nombre}");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("\nOpción no válida.");
                    break;
            }
            Console.WriteLine("\nPresione una tecla para volver...");
            Console.ReadKey();
            break;

        case "4": // Reseñas
            Console.Clear();
            Console.WriteLine("*** Reseñas y Calificaciones ***");
            Console.WriteLine("1. Calificar y reseñar un libro");
            Console.WriteLine("2. Consultar calificación de un libro");
            Console.Write("\nSeleccione una opción: ");
            string reviewOption = Console.ReadLine();

            switch (reviewOption)
            {
                case "1": // Calificar
                    Console.Clear();
                    Console.WriteLine("*** Calificar y Reseñar un Libro ***");
                    Console.Write("Ingrese el título del libro: ");
                    string titleToReview = Console.ReadLine();
                    
                    Libro bookToReview = null;
                    foreach(var book in books) { if(book.Titulo.Equals(titleToReview, StringComparison.OrdinalIgnoreCase)) { bookToReview = book; break; } }

                    if (bookToReview == null) { Console.WriteLine("Libro no encontrado."); }
                    else
                    {
                        Console.Write("Ingrese una calificación (0.0 a 5.0): ");
                        double rating = double.Parse(Console.ReadLine());
                        Console.Write("Ingrese un comentario (opcional): ");
                        string comment = Console.ReadLine();
                        bookToReview.Reseñas.Add(new Reseña(rating, comment));
                        Console.WriteLine("\nGracias por tu reseña");
                    }
                    break;
                case "2": // Consultar
                    Console.Clear();
                    Console.WriteLine("*** Consultar Calificación Promedio ***");
                    Console.Write("Ingrese el título del libro: ");
                    string titleToConsult = Console.ReadLine();

                    Libro bookToConsult = null;
                    foreach(var book in books) { if(book.Titulo.Equals(titleToConsult, StringComparison.OrdinalIgnoreCase)) { bookToConsult = book; break; } }
                    
                    if (bookToConsult == null) { Console.WriteLine("Libro no encontrado."); }
                    else
                    {
                        double average = bookToConsult.ObtenerCalificacionPromedio();
                        Console.WriteLine($"La calificación promedio de '{bookToConsult.Titulo}' es: {average:F1} / 5.0");
                        if (bookToConsult.Reseñas.Count > 0)
                        {
                            Console.WriteLine("\nComentarios:");
                            foreach (var review in bookToConsult.Reseñas)
                            {
                                if (!string.IsNullOrEmpty(review.Comentario))
                                {
                                    Console.WriteLine($" - [{review.Calificacion:F1}] {review.Comentario}");
                                }
                            }
                        }
                    }
                    break;
                default:
                    Console.WriteLine("\nOpción no válida.");
                    break;
            }
            Console.WriteLine("\nPresione una tecla para volver...");
            Console.ReadKey();
            break;

        case "5": // Estadísticas
            Console.Clear();
            Console.WriteLine("*** Estadísticas de la Biblioteca ***");
            Console.WriteLine($"Número total de libros: {books.Count}");
            Console.WriteLine($"Número de usuarios: {users.Count}");

            int historicalLoans = loans.Count;
            int returnedLoansCount = 0;
            foreach (var book in books)
            {
                returnedLoansCount += book.VecesPrestado - (book.Disponible ? 0 : 1);
            }
            historicalLoans += returnedLoansCount;
            Console.WriteLine($"Número histórico de préstamos: {historicalLoans}");

            if (books.Count > 0)
            {
                Libro mostLoanedBook = null;
                if (books.Count > 0)
                {
                    mostLoanedBook = books[0]; 
                    foreach (var book in books)
                    {
                        if (book.VecesPrestado > mostLoanedBook.VecesPrestado)
                        {
                            mostLoanedBook = book;
                        }
                    }
                }

                if (mostLoanedBook != null && mostLoanedBook.VecesPrestado > 0)
                {
                    Console.WriteLine($"Libro más prestado: '{mostLoanedBook.Titulo}' ({mostLoanedBook.VecesPrestado} veces)");
                }
                else
                {
                    Console.WriteLine("Aún no se ha prestado ningún libro.");
                }
            }
            Console.WriteLine("\nPresione una tecla para volver...");
            Console.ReadKey();
            break;

        case "6": // Salir
            exit = true;
            Console.WriteLine("\nGracias por usar el sistema. ¡Hasta pronto!");
            break;
            
        default:
            Console.WriteLine("\nOpción no válida. Presione una tecla para continuar...");
            Console.ReadKey();
            break;
    }
}


//  CLASES DEL MODELO 

public class Reseña
{
    public double Calificacion { get; set; }
    public string Comentario { get; set; }
    public Reseña(double calificacion, string comentario) { Calificacion = calificacion; Comentario = comentario; }
}

public class Libro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Categoria { get; set; }
    public int Año { get; set; }
    public bool Disponible { get; set; } = true;
    public List<Reseña> Reseñas { get; set; } = new List<Reseña>();
    public int VecesPrestado { get; set; } = 0;
    public Libro(string titulo, string autor, string categoria, int año) { Titulo = titulo; Autor = autor; Categoria = categoria; Año = año; }

    public double ObtenerCalificacionPromedio()
    {
        if (Reseñas.Count == 0) return 0.0;
        
        double ratingSum = 0;
        foreach (var review in Reseñas)
        {
            ratingSum += review.Calificacion;
        }
        return ratingSum / Reseñas.Count;
    }
}

public class Usuario
{
    public string Nombre { get; set; }
    public string Identificacion { get; set; }
    public string Correo { get; set; }
    public Usuario(string nombre, string identificacion, string correo) { Nombre = nombre; Identificacion = identificacion; Correo = correo; }
}

public class Prestamo
{
    public Libro LibroPrestado { get; set; }
    public Usuario UsuarioPrestamo { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public Prestamo(Libro libro, Usuario usuario) { LibroPrestado = libro; UsuarioPrestamo = usuario; FechaPrestamo = DateTime.Now; }
}