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
                    string query = "INSERT INTO Proveedores VALUES (@nombre,@direccion,@email)";
                    using (SqlCommand cmd = new SqlCommand(query, conexiones.Conexion()))
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
                string query = "SELECT Nombre,Direccion,Email FROM Proveedores";
                using (SqlCommand cmd = new SqlCommand(query, conexiones.Conexion()))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Proveedor proveedor = new Proveedor
                            {
                                // reader.GetTipo(indice) => me da el dato que hay en la columna en la posicion indice.
                                // reader.GetOrdinal("Nombre de columna") => me da el valor del indice, donde la columna se llama "Nombre de columna".
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
    }
}
