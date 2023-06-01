﻿using ObrasSanitarias.Interfaces;
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
        public void Agregar(Propuesta p)
        {
            using (Conexiones conexiones = new Conexiones()) 
            {
                try
                {
                    conexiones.Abrir();
                    using (SqlCommand cmd = new SqlCommand(getSQLquery(), conexiones.Conexion()))
                    {
                        cmd.Parameters.Add("@ID_Licitaciones", SqlDbType.Int).Value = p.licitacion.ID;
                        cmd.Parameters.Add("@ID_Proveedor", SqlDbType.Int).Value = p.proveedor.ID;
                        cmd.Parameters.Add("@FechaPresentacion", SqlDbType.Int).Value = p.fechaPresentacion;
                        cmd.Parameters.Add("@Monto", SqlDbType.Int).Value = p.monto;
                        cmd.ExecuteNonQuery();
                    }
                    Console.Clear();
                    Console.WriteLine("Propuesta Agregada con Exito");

                }catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.ToString());
                }
                
            }
        }

        private string getSQLquery()
        {
            return "INSERT INTO Propuestas Values(@ID_Licitaciones,@ID_Proveedor,@FechaPresentacion,@Monto)";
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
                            /*  Propuesta propuesta = new Propuesta();
                               {
                                   // reader.GetTipo(indice) => me da el dato que hay en la columna en la posicion indice.
                                   // reader.GetOrdinal("Nombre de columna") => me da el valor del indice, donde la columna se llama "Nombre de columna".
                                    = reader.GetString(reader.GetOrdinal("Nombre")),
                                   direccion = reader.GetString(reader.GetOrdinal("Direccion")),
                                   email = reader.GetString(reader.GetOrdinal("Email")),
                               }; 
                            propuestas.Add(propuesta); */
                        }
                    }
                }
                return propuestas;
            }
    }

        private string SQLquery_SELECT()
        {
            return @"SELECT
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
                   INNER JOIN Licitaciones AS l ON l.ID_Licitacion = prop.ID
                   INNER JOIN Proveedores AS p ON l.ID_Proveederes = prop.ID

                   ";
        }
    }
