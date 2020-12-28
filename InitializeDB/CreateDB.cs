
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using BookReViewGenNHibernate.EN.BookReview;
using BookReViewGenNHibernate.CEN.BookReview;
using BookReViewGenNHibernate.CAD.BookReview;
using BookReViewGenNHibernate.Enumerated.BookReview;
using BookReViewGenNHibernate.CP.BookReview;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

        try
        {
                // Insert the initilizations of entities using the CEN classes

                //prueba cambio
                // p.e. CustomerCEN customer = new CustomerCEN();
                // customer.New_ (p_user:"user", p_password:"1234");
                //lub_lecCEN club = new Club_lecCEN();
                //           w DateTime(2020, 11, 21),
                //creamos USUARIOS y ADMINS
                UsuarioCEN usuCEN = new UsuarioCEN ();
                int idUSU1 = usuCEN.New_ ("password", "us@alu.ua", "fotoperf", "usu1", 0);
                int idUSU2 = usuCEN.New_ ("password", "us2@alu.ua", "fotoperf", "usu2", 0);
                int idUSU3 = usuCEN.New_ ("password", "us3@alu.ua", "fotoperf", "usu3", 0);
                AdminCEN adCEN = new AdminCEN ();
                int idAD1 = adCEN.New_ ("password", "us4@alu.ua", "fotoperf", "Admin1", 0);

                //creamos LIBROS
                LibroCEN libCEN = new LibroCEN ();
                int idLIB = libCEN.PublicarLibro ("Poe", "El cuervo", "Terror", new DateTime (2020, 01, 22), "ingles", "Portada", 4.4, "enlacecompra.com", 200, 50, idUSU1, 0);
                int idLIB2 = libCEN.PublicarLibro ("Poe", "El cuervo 2", "Terror 2", new DateTime (2020, 01, 22), "ingles 2", "Portada 2", 4.4, "enlacecompra2.com", 200, 60, idUSU3, 0);
                int idLIB3 = libCEN.PublicarLibro ("Poe", "El cuervo 3", "Terror 3", new DateTime (2020, 01, 22), "ingles 3", "Portada 3", 4.4, "enlacecompra3.com", 200, 300, idUSU1, 1);
                int idLIB4 = libCEN.PublicarLibro ("Poe", "El cuervo 4", "Terror 4", new DateTime (2020, 01, 22), "ingles 4", "Portada 4", 4.4, "enlacecompra4.com", 200, 30, idUSU1, 1);

                //creamos PUNTUACION
                PuntuacionCEN punCEN = new PuntuacionCEN ();
                int idPUN = punCEN.New_ (4, idUSU1, idLIB);

                //creamos CLUB con un libro
                Club_lecCEN clubCEN = new Club_lecCEN ();
                int idCLUB = clubCEN.New_ (new DateTime (2020, 12, 22), 150, true, idLIB);

                //creamos COMENTARIO con un libro y usuario
                ComentarioCEN comCEN = new ComentarioCEN ();
                int idCOM = comCEN.PublicarComentario ("titulo", new DateTime (2020, 01, 22), "contenido texto etc este es amigo", idLIB, idUSU2, 125);
                int idCOM2 = comCEN.PublicarComentario ("titulo", new DateTime (2020, 01, 22), "contenido texto etc este no es amigo", idLIB, idUSU2, 120);
                //creamos SOLICITUD AMISTAD y la inciamos ACEPTADA
                SolicitudCEN soliCEN = new SolicitudCEN ();
                int idSOLI = soliCEN.CrearSolicitud (TiposolicitudEnum.aceptado, idUSU1, idUSU2);
                //cen customizado y ver que esta pendiente

                //creamos LISTA
                ListaCEN lisCEN = new ListaCEN ();
                int idLIS = lisCEN.New_ (TipolistaEnum.favorito, idUSU1);



                /* ==== NUEVA COMPRA ====*/
                CompraCP compraCP = new CompraCP ();
                compraCP.New_ (idUSU1, idLIB, "paypal", "87237136763-CV123", new DateTime (2020, 01, 22), "terminal", "amazon");
                // Mostramos por pantalla con un console log que se han actualizado las compras del libro
                LibroEN libEN = libCEN.ReadOID (idLIB); // Primero sacamos el libro actual
                UsuarioEN usuEN = usuCEN.ReadOID (libEN.Creador.UsuarioID); // Sacamos el usuario asociado a la id del libro
                Console.WriteLine ("Las compras del libro con nombre \"" + libEN.Nombre + "\" son: " + libEN.Compras);
                Console.WriteLine ("El usuario: " + usuEN.Nombre + " ha recibido " + libEN.Precio + "EUROS. Su total ahora es de: " + usuEN.Dineroventa);

                /* ==== NUEVA COMPRA ====*/
                compraCP.New_ (idUSU2, idLIB, "mastercard", "2828282828-C33", new DateTime (2020, 01, 22), "terminal2", "amazon");
                // Mostramos por pantalla con un console log que se han actualizado las compras del libro
                libEN = libCEN.ReadOID (idLIB); // Primero sacamos el libro actual
                usuEN = usuCEN.ReadOID (libEN.Creador.UsuarioID); // Sacamos el usuario asociado a la id del libro
                Console.WriteLine ("Las compras del libro con nombre \"" + libEN.Nombre + "\" son: " + libEN.Compras);
                Console.WriteLine ("El usuario: " + usuEN.Nombre + " ha recibido " + libEN.Precio + "EUROS. Su total ahora es de: " + usuEN.Dineroventa);

                /* ==== NUEVA COMPRA ====*/
                compraCP.New_ (idUSU2, idLIB2, "mastercard", "2828282828-C33", new DateTime (2020, 01, 22), "terminal2", "amazon");
                // Mostramos por pantalla con un console log que se han actualizado las compras del libro
                libEN = libCEN.ReadOID (idLIB2); // Primero sacamos el libro actual
                usuEN = usuCEN.ReadOID (libEN.Creador.UsuarioID); // Sacamos el usuario asociado a la id del libro
                Console.WriteLine ("Las compras del libro con nombre \"" + libEN.Nombre + "\" son: " + libEN.Compras);
                Console.WriteLine ("El usuario: " + usuEN.Nombre + " ha recibido " + libEN.Precio + "EUROS. Su total ahora es de: " + usuEN.Dineroventa);

                // ACEPTAR SOLICITUD
                /*
                 * try
                 * {
                 *  solCEN.aceptar(idSol1);
                 * }
                 * catch (Exception e)
                 * {
                 *  System.Console.WriteLine(e.Message);
                 * }
                 *
                 * solCEN.aceptar(idSol1);
                 *
                 * SolicitudEN solEN = new SolicitudCAD().ReadOIDDefault(idSol1);
                 * Console.WriteLine("La solicitud ha sido aceptada");
                 */

                // ZONA FILTROS
                Console.WriteLine ("==== FILTROS ====");
                Console.WriteLine (":::::Lista de usuarios registrados:::::");
                IList<UsuarioEN> listaUsus = usuCEN.ReadFilter ();
                foreach (UsuarioEN usu in listaUsus) {
                        Console.WriteLine ("Nombre:" + usu.Nombre + " Email:" + usu.Mail);
                }
                Console.WriteLine (":::::::::::::::::::::::::::::::::::::::");
                Console.WriteLine ();
                Console.WriteLine (":::::Filtrado de comentarios:::::");
                Console.WriteLine ("Lista comentarios filtrados por paginas (100)");
                IList<ComentarioEN> listaCom = comCEN.ReadFilter (100);
                foreach (ComentarioEN com in listaCom) {
                        Console.WriteLine ("Autor: " + com.Titulo);
                        Console.WriteLine ("Comentario: " + com.Contenido);
                        Console.WriteLine ();
                }
                Console.WriteLine (":::::::::::::::::::::::::::::::::::::::");
                Console.WriteLine ();
                Console.WriteLine (":::::Lista libros por precio:::::");
                Console.WriteLine (" Un filtro por los mas caros a partir de un precio (establecido por nosotros, 500)");
                IList<LibroEN> listaLibros = libCEN.ReadFilter (500);
                foreach (LibroEN libro in listaLibros) {
                        Console.WriteLine ("Libro: " + libro.Nombre + " Precio: " + libro.Precio);
                }
                Console.WriteLine (":::::::::::::::::::::::::::::::::::::::");
                Console.WriteLine ();
                Console.WriteLine (":::::Bestsellers de un vendedor:::::");
                Console.WriteLine (" Un filtro de libros por el dinero total que han dado a un usuario concreto (usu1)");
                usuEN = usuCEN.ReadOID (idUSU1);
                listaLibros = libCEN.FiltroBestSeller (usuEN.Mail);
                foreach (LibroEN libro in listaLibros) {
                        double precio = libro.Precio * (double)libro.Compras;
                        Console.WriteLine ("Libro: " + libro.Nombre + " con " + libro.Compras + " unidades a un precio de " + libro.Precio + " // Total ingresos: " + precio);
                }
                Console.WriteLine (":::::::::::::::::::::::::::::::::::::::");

                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
