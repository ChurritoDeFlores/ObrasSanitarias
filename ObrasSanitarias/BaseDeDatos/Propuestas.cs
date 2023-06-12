using ObrasSanitarias.Interfaces;
using ObrasSanitarias.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrasSanitarias.BaseDeDatos
{
    internal class Propuestas : IAgregarListar<Propuesta>
    {
        #region Metodos Publicos
        public void Agregar(int IDLicitacion, int IDProveedor, string fechaPresentacion, double monto)
        {
            using (Conexiones conexiones = new Conexiones())
            {
                try
                {
                    conexiones.Abrir();
                    using (SqlCommand cmd = new SqlCommand(SQLquery_INSERT(), conexiones.Conexion()))
                    {
                        cmd.Parameters.Add("@ID_Licitaciones", SqlDbType.Int).Value = IDLicitacion;
                        cmd.Parameters.Add("@ID_Proveedor", SqlDbType.Int).Value = IDProveedor;
                        cmd.Parameters.Add("@FechaPresentacion", SqlDbType.VarChar).Value = fechaPresentacion;
                        cmd.Parameters.Add("@Monto", SqlDbType.Decimal).Value = monto;
                        cmd.ExecuteNonQuery();
                    }
                    Console.Clear();
                    Console.WriteLine("Propuesta Agregada con Exito");

                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.ToString());
                }

            }
        }

        public void Agregar(Propuesta t)
        {
            throw new NotImplementedException();
        }
        public void Eliminar(int id)
        {
            using (Conexiones conexiones = new Conexiones())
            {
                try
                {
                    conexiones.Abrir();
                    using (SqlCommand cmd = new SqlCommand(Sql_Eliminar(), conexiones.Conexion()))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        cmd.ExecuteNonQuery();
                    }
                    conexiones.Cerrar();
                    Console.Clear();
                    Console.WriteLine("Propuesta eliminada");
                    Console.ReadKey();
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

        public List<Propuesta> Listar()
        {
            List<Propuesta> propuestas = new List<Propuesta>();
            using (Conexiones conexiones = new Conexiones())
            {
                conexiones.Abrir();
                using (SqlCommand cmd = new SqlCommand(SQLquery_SELECT(), conexiones.Conexion()))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Propuesta propuesta = new Propuesta
                            {
                                // nreader.GetTipo(indice) => me da el dato que hay en la columna en la posicion indice.
                                // reader.GetOrdinal("Nombre de columna") => me da el valor del indice, donde la columna se llama "Nombre de columna".
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                licitacion = new Licitacion(reader.GetString(reader.GetOrdinal("TipoDeObra")), reader.GetDouble(reader.GetOrdinal("PresupuestoEstimado")), reader.GetString(reader.GetOrdinal("Ubicacion")), reader.GetString(reader.GetOrdinal("FechaLimite")), reader.GetString(reader.GetOrdinal("Estado"))),
                                proveedor = new Proveedor(reader.GetString(reader.GetOrdinal("Nombre")), reader.GetString(reader.GetOrdinal("Direccion")), reader.GetString(reader.GetOrdinal("Email"))),
                                fechaPresentacion = reader.GetString(reader.GetOrdinal("FechaPresentacion")),
                                monto = reader.GetDouble(reader.GetOrdinal("Monto"))   
                               }; 
                            propuestas.Add(propuesta); 
                        }
                    }
                }
                return propuestas;
            }
        }
        #endregion

        #region Metodos Privados
        private string Sql_Eliminar()
        {
            return "DELETE FROM Propuestas WHERE ID=@id";
        }
        private string SQLquery_INSERT()
        {
            return "INSERT INTO Propuestas Values(@ID_Licitaciones,@ID_Proveedor,@FechaPresentacion,@Monto)";
        }
        private string SQLquery_SELECT()
        {
            return @"SELECT
                   prop.ID,
                   l.TipoDeObra,
                   l.PresupuestoEstimado,
                   l.Ubicacion,
                   l.FechaLimite,
                   l.Estado,
                   p.Nombre,
                   p.Direccion,
                   p.Email,
                   FechaPresentacion,
                   Monto
                   FROM
                   Propuestas AS prop
                   INNER JOIN Licitaciones AS l ON l.ID = prop.ID
                   INNER JOIN Proveedores AS p ON p.ID = prop.ID";
        }
        #endregion
    }
}
