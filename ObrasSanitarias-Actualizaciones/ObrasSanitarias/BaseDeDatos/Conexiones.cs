using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ObrasSanitarias.BaseDeDatos
{
    internal class Conexiones:IDisposable
    {
        private SqlConnection conexionSQL;

        public Conexiones()
        {
            SqlConnectionStringBuilder StringSQL = new SqlConnectionStringBuilder();
            StringSQL.WorkstationID = "obrassanitarias.mssql.somee.com";
            StringSQL.PacketSize = 4096;
            StringSQL.UserID = "churritodeflores_SQLLogin_1";
            StringSQL.Password = "qdnok4dfwx";
            StringSQL.DataSource = "obrassanitarias.mssql.somee.com";
            StringSQL.PersistSecurityInfo = false;
            StringSQL.InitialCatalog = "obrassanitarias";
            conexionSQL = new SqlConnection(StringSQL.ConnectionString);
        }
        public void Abrir()
        {
            conexionSQL.Open();
        }
        public void Cerrar()
        {
            conexionSQL.Close();
        }
        public SqlConnection Conexion()
        {
            return conexionSQL;
        }

        public void Dispose() // Este metodo es implementado por IDisposable, para el uso de using
        {
            Cerrar();
            conexionSQL.Dispose();
        }
    }
}
