using System.Data;
using System.Data.OleDb;
using System.IO;

namespace pryModeloDB
{
    public class DbConnector
    {
        private const string Proveedor = "Microsoft.ACE.OLEDB.16.0";
        private OleDbConnection conexion;

        public bool EstaConectado
        {
            get { return conexion != null && conexion.State == ConnectionState.Open; }
        }

        public void Conectar(string rutaArchivo)
        {
            Cerrar();

            if (string.IsNullOrWhiteSpace(rutaArchivo) || !File.Exists(rutaArchivo))
            {
                throw new FileNotFoundException("No se encontro el archivo Access seleccionado.");
            }

            string cadenaConexion = "Provider=" + Proveedor + ";Data Source=" + rutaArchivo + ";Persist Security Info=False;";
            conexion = new OleDbConnection(cadenaConexion);
            conexion.Open();
        }

        public DataTable ObtenerTablas()
        {
            if (!EstaConectado)
            {
                return new DataTable();
            }

            DataTable esquema = conexion.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            DataTable tablas = new DataTable();
            tablas.Columns.Add("NombreTabla");

            foreach (DataRow fila in esquema.Rows)
            {
                string tipo = fila["TABLE_TYPE"].ToString();
                string nombre = fila["TABLE_NAME"].ToString();

                if (tipo == "TABLE" && !nombre.StartsWith("MSys"))
                {
                    tablas.Rows.Add(nombre);
                }
            }

            return tablas;
        }

        public DataTable ObtenerDatos(string nombreTabla)
        {
            if (!EstaConectado || string.IsNullOrWhiteSpace(nombreTabla))
            {
                return new DataTable();
            }

            string consulta = "SELECT * FROM [" + nombreTabla + "]";

            using (OleDbDataAdapter adaptador = new OleDbDataAdapter(consulta, conexion))
            {
                DataTable datos = new DataTable();
                adaptador.Fill(datos);
                return datos;
            }
        }

        public void Cerrar()
        {
            if (conexion != null)
            {
                conexion.Close();
                conexion.Dispose();
                conexion = null;
            }
        }
    }
}
