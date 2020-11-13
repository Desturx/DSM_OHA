
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
                int idUSU1 = usuCEN.New_ ("password", "us@alu.ua", "fotoperf", "usu1");
                int idUSU2 = usuCEN.New_ ("password", "us2@alu.ua", "fotoperf", "usu2");
                int idUSU3 = usuCEN.New_ ("password", "us3@alu.ua", "fotoperf", "usu3");

                AdminCEN adCEN = new AdminCEN ();
                int idAD1 = adCEN.New_ ("password", "us@alu.ua", "fotoperf", "Admin1", 0);

                //creamos LIBROS
                LibroCEN libCEN = new LibroCEN ();
                int idLIB = libCEN.PublicarLibro ("Poe", "El cuervo", "Terror", new DateTime (2020, 01, 22), "ingles", "Portada", 4.4, "enlacecompra.com", 200, 50, idUSU1);
                int idLIB2 = libCEN.PublicarLibro ("Poe", "El cuervo 2", "Terror 2", new DateTime (2020, 01, 22), "ingles 2", "Portada 2", 4.4, "enlacecompra2.com", 200, 50, idUSU3);

                //creamos PUNTUACION
                PuntuacionCEN punCEN = new PuntuacionCEN ();
                int idPUN = punCEN.New_ (4, idUSU1, idLIB);

                //creamos CLUB con un libro
                Club_lecCEN clubCEN = new Club_lecCEN ();
                int idCLUB = clubCEN.New_ (new DateTime (2020, 12, 22), 150, true, idLIB);

                //creamos COMENTARIO con un libro y usuario
                ComentarioCEN comCEN = new ComentarioCEN ();
                int idCOM = comCEN.New_ ("titulo", "contenido texto etc", idLIB, idUSU2, 125); //por algun motivo las paginas leidas salen como string? preguntar en clase

                //creamos SOLICITUD AMISTAD y la inciamos ACEPTADA
                SolicitudCEN soliCEN = new SolicitudCEN ();
                int idSOLI = soliCEN.CrearSolicitud (TiposolicitudEnum.aceptado, idUSU1, idUSU2);

                //creamos COMPRAS con usuarios
                CompraCP compraCP = new CompraCP ();
                /* ==== NUEVA COMPRA ====*/
                compraCP.New_ (idUSU1, idLIB, "paypal", "87237136763-CV123", new DateTime (2020, 01, 22), "terminal", "amazon");
                // Mostramos por pantalla con un console log que se han actualizado las compras del libro
                LibroEN libEN = libCEN.ReadOID (idLIB); // Primero sacamos el libro actual
                UsuarioEN usuEN = usuCEN.ReadOID (libEN.Creador.UsuarioID); // Sacamos el usuario asociado a la id del libro
                Console.WriteLine ("Las compras del libro con nombre: " + libEN.Nombre + "son: " + libEN.Compras);
                Console.WriteLine ("El usuario: " + usuEN.Nombre + " ha recibido " + libEN.Precio + "�. Su total ahora es de: " + usuEN.Dineroventa);
                /* ==== NUEVA COMPRA ====*/
                compraCP.New_ (idUSU2, idLIB2, "mastercard", "2828282828-C33", new DateTime (2020, 01, 22), "terminal2", "amazon");
                // Mostramos por pantalla con un console log que se han actualizado las compras del libro
                libEN = libCEN.ReadOID (idLIB2); // Primero sacamos el libro actual
                usuEN = usuCEN.ReadOID (libEN.Creador.UsuarioID); // Sacamos el usuario asociado a la id del libro
                Console.WriteLine ("Las compras del libro con nombre: " + libEN.Nombre + "son: " + libEN.Compras);
                Console.WriteLine ("El usuario: " + usuEN.Nombre + " ha recibido " + libEN.Precio + "�. Su total ahora es de: " + usuEN.Dineroventa);

                //creamos LISTA
                ListaCEN lisCEN = new ListaCEN ();
                int idLIS = lisCEN.New_ (TipolistaEnum.favorito, idUSU1);
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
