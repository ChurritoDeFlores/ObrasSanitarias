using ObrasSanitarias.Interfaces;
using ObrasSanitarias.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;

namespace ObrasSanitarias.BaseDeDatos
{
    internal class Proveedores : IAgregarListar<Proveedor>, IExiste<Proveedor>
    {
        public void Agregar(Proveedor p)
        {
            using (Conexiones conexiones = new Conexiones()) // Para poder hacer esto, la clase debe implementar la interfaz IDisposable
            {
                try
                {
                    conexiones.Abrir();
                    using (SqlCommand cmd = new SqlCommand(Sql_Agregar(), conexiones.Conexion()))
                    {
                        // El uso de .Add, ayuda a la conversion de datos y evita errores con éste, en comparacion con el metodo .AddWithValues
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = p.nombre;
                        cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = p.direccion;
                        cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = p.email;
                        cmd.ExecuteNonQuery();
                    }
                    //conexiones.Cerrar(); // No seria necesario utilizando el using 
                }
                catch (Exception ex)
                {
                    //conexiones.Cerrar(); // No seria necesario utilizando el using
                    Console.Clear();
                    Console.WriteLine(ex.ToString());
                    Console.ReadKey();

                }
            }
        }

        public void Eliminar(int id_p)
        {
            using (Conexiones conexiones = new Conexiones())
            {
                try
                {
                    conexiones.Abrir();
                    using (SqlCommand cmd = new SqlCommand(Sql_Eliminar(), conexiones.Conexion()))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id_p;
                        cmd.ExecuteNonQuery();

                    }
                    conexiones.Cerrar();
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    conexiones.Cerrar();
                    Console.Clear();
                    Console.WriteLine(ex.ToString());
                    Console.ReadKey();
                }
            }
        }

        public bool Existe(Proveedor p)
        {
            using (Conexiones conexiones = new Conexiones())
            {
                conexiones.Abrir();
                string query = "SELECT * FROM Proveedores WHERE Nombre = @nombre";
                using (SqlCommand cmd = new SqlCommand(query, conexiones.Conexion()))
                {
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = p.nombre;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine("El proveedor ya se encuentra registrado");
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public List<Proveedor> Listar()
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            using (Conexiones conexiones = new Conexiones())
            {
                conexiones.Abrir();
                using (SqlCommand cmd = new SqlCommand(Sql_Listar(), conexiones.Conexion()))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Proveedor proveedor = new Proveedor
                            {
                                // reader.GetTipo(indice) => me da el dato que hay en la columna en la posicion indice.
                                // reader.GetOrdinal("Nombre de columna") => me da el valor del indice, donde la columna se llama "Nombre de columna".
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                direccion = reader.GetString(reader.GetOrdinal("Direccion")),
                                email = reader.GetString(reader.GetOrdinal("Email")),
                            };
                            proveedores.Add(proveedor);
                        }
                    }
                }
                return proveedores;
            }
        }

        public void EditarNombre(int id, string nombre)
        {
            using (Conexiones conexiones = new Conexiones())
            {
                try
                {
                    conexiones.Abrir();
                    using (SqlCommand cmd = new SqlCommand(Sql_EditarNombre(), conexiones.Conexion()))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                        cmd.ExecuteNonQuery();
                    }
                    conexiones.Cerrar();
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    conexiones.Cerrar();
                    Console.Clear();
                    Console.WriteLine(ex.ToString());
                    Console.ReadKey();
                }
            }
        }

        #region Querys
        private string Sql_Agregar()
        {
            return "INSERT INTO Proveedores VALUES (@nombre,@direccion,@email)";
        }

        private string Sql_Listar()
        {
            return "SELECT * FROM Proveedores";
        }

        private string Sql_EditarNombre()
        {
            return "UPDATE Proveedores SET Nombre = @nombre WHERE ID = @id";
        }

        private string Sql_Eliminar()
        {
            return "DELETE FROM Proveedores WHERE ID=@id";
        }
        #endregion
    }
}
