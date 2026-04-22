using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace pryModeloDB
{
    public static class DbConnector
    {
        private static readonly string[] AceProviders =
        {
            "Microsoft.ACE.OLEDB.16.0",
            "Microsoft.ACE.OLEDB.12.0",
            "Microsoft.Jet.OLEDB.4.0"
        };

        public static string LastError { get; private set; }

        public static OleDbConnection TryConnect(string filePath)
        {
            LastError = null;

            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                LastError = "La ruta indicada no existe o no apunta a un archivo valido.";
                return null;
            }

            string extension = Path.GetExtension(filePath).ToLowerInvariant();

            if (extension == ".xls" || extension == ".xlsx")
            {
                foreach (string provider in AceProviders)
                {
                    string excelProperties = extension == ".xlsx"
                        ? "Excel 12.0 Xml;HDR=YES;IMEX=1"
                        : "Excel 8.0;HDR=YES;IMEX=1";

                    string connectionString = $"Provider={provider};Data Source={filePath};Extended Properties=\"{excelProperties}\";";
                    OleDbConnection connection = TryOpen(connectionString);
                    if (connection != null)
                    {
                        return connection;
                    }
                }

                AppendError("No se encontro un proveedor compatible para abrir el archivo de Excel.");
                return null;
            }

            if (extension == ".mdb" || extension == ".accdb")
            {
                foreach (string provider in AceProviders)
                {
                    string connectionString = $"Provider={provider};Data Source={filePath};Persist Security Info=False;";
                    OleDbConnection connection = TryOpen(connectionString);
                    if (connection != null)
                    {
                        return connection;
                    }
                }

                AppendError("No se encontro un proveedor compatible para abrir la base Access.");
                return null;
            }

            LastError = "Tipo de archivo no soportado. Solo se permiten Access o Excel.";
            return null;
        }

        private static OleDbConnection TryOpen(string connectionString)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                AppendError(ex.Message);
                return null;
            }
        }

        public static List<string> GetTableNames(OleDbConnection connection)
        {
            List<string> tables = new List<string>();

            if (connection == null)
            {
                return tables;
            }

            try
            {
                DataTable schema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (schema == null)
                {
                    return tables;
                }

                foreach (DataRow row in schema.Rows)
                {
                    string tableType = row["TABLE_TYPE"].ToString();
                    string tableName = row["TABLE_NAME"].ToString();

                    if (string.IsNullOrWhiteSpace(tableName))
                    {
                        continue;
                    }

                    if (tableType == "TABLE" || tableType == "VIEW" || tableType == "SYSTEM TABLE")
                    {
                        if (!tables.Contains(tableName))
                        {
                            tables.Add(tableName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AppendError("No se pudieron obtener las tablas: " + ex.Message);
            }

            return tables;
        }

        public static DataTable GetTableData(OleDbConnection connection, string tableName)
        {
            DataTable table = new DataTable();

            if (connection == null || string.IsNullOrWhiteSpace(tableName))
            {
                return table;
            }

            try
            {
                using (OleDbCommand command = new OleDbCommand($"SELECT * FROM [{tableName}]", connection))
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    adapter.Fill(table);
                }
            }
            catch (Exception ex)
            {
                AppendError("No se pudieron cargar los datos: " + ex.Message);
            }

            return table;
        }

        private static void AppendError(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(LastError))
            {
                LastError = message;
            }
            else
            {
                LastError += Environment.NewLine + message;
            }
        }
    }
}
