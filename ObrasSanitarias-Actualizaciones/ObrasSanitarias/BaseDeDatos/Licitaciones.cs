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
    internal class Licitaciones : IAgregarListar<Licitacion>
    {
        /*
            El uso de using en los metodos que hacen consultas a la base de datos son una buena practica,
            te aseguran de que los recursos sean liberados correctamente al finalizar el bloque,
            hace que el codigo sea mas claro y legible, ya que la intención de administrar y liberar los recursos se vuelve explícita.
            Al encapsular la instancia en un bloque using, indicas claramente que la instancia se utilizará solo dentro de ese bloque
            y se liberará automáticamente al finalizar. Esto es ideal para las conexiones a la bases de datos
        */
        
        public void Agregar(Licitacion l)
        {
            using (Conexiones conexiones = new Conexiones()) // Para poder hacer esto, la clase debe implementar la interfaz IDisposable
            {
                try
                {
                    conexiones.Abrir();
                    string query = "INSERT INTO Licitaciones VALUES (@tipoDeObra,@presupuestoEstimado,@ubicacion,@fechaLimite,@estado)";
                    using (SqlCommand cmd = new SqlCommand(query, conexiones.Conexion()))
                    {
                        // El uso de .Add, ayuda a la conversion de datos y evita errores con éste, en comparacion con el metodo .AddWithValues
                        cmd.Parameters.Add("@tipoDeObra",SqlDbType.VarChar).Value=l.tipoDeObra;
                        cmd.Parameters.Add("@presupuestoEstimado", SqlDbType.Decimal).Value = l.presupuestoEstimado;
                        cmd.Parameters.Add("@ubicacion", SqlDbType.VarChar).Value = l.ubicacion;
                        cmd.Parameters.Add("@fechaLimite", SqlDbType.VarChar).Value = l.fechaLimite;
                        cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = l.estado;
                        cmd.ExecuteNonQuery();

                    }
                    //conexiones.Cerrar(); // No seria necesario utilizando el using 
                    Console.Clear();
                    Console.WriteLine("Licitacion Agregada");
                }
                catch (Exception ex)
                {
                    //conexiones.Cerrar(); // No seria necesario utilizando el using
                    Console.Clear();
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public List<Licitacion> Listar()
        {
            List<Licitacion> licitaciones = new List<Licitacion>();
            using (Conexiones conexiones = new Conexiones())
            {
                conexiones.Abrir();
                string query = "SELECT TipoDeObra,PresupuestoEstimado,Ubicacion,FechaLimite,Estado FROM Licitaciones";
                using (SqlCommand cmd = new SqlCommand(query, conexiones.Conexion()))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Licitacion licitacion = new Licitacion
                            {
                                // reader.GetTipo(indice) => me da el dato que hay en la columna en la posicion indice.
                                // reader.GetOrdinal("Nombre de columna") => me da el valor del indice, donde la columna se llama "Nombre de columna".
                                tipoDeObra = reader.GetString(reader.GetOrdinal("TipoDeObra")),
                                presupuestoEstimado = reader.GetDouble(reader.GetOrdinal("PresupuestoEstimado")),
                                ubicacion = reader.GetString(reader.GetOrdinal("Ubicacion")),
                                fechaLimite = reader.GetString(reader.GetOrdinal("FechaLimite")),
                                estado = reader.GetString(reader.GetOrdinal("Estado")),
                            };
                            licitaciones.Add(licitacion);
                        }
                    }
                }
            }
            return licitaciones;
        }
    }
}
