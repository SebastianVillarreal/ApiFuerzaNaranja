using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections.Generic;
using FastMember;

namespace marcatel_api.Services
{
    public class RegistroService
    {
        private  string connection;
        
        
        public RegistroService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public void InsertRegistro(RegistroModel registro )
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = registro.Nombre });
            parametros.Add(new SqlParameter { ParameterName = "@ApPaterno", SqlDbType = SqlDbType.VarChar, Value = registro.ApPaterno });
            parametros.Add(new SqlParameter { ParameterName = "@ApMaterno", SqlDbType = SqlDbType.VarChar, Value = registro.ApMaterno });
            parametros.Add(new SqlParameter { ParameterName = "@Telefono", SqlDbType = SqlDbType.VarChar, Value = registro.Telefono });
            parametros.Add(new SqlParameter { ParameterName = "@Calle", SqlDbType = SqlDbType.VarChar, Value = registro.Calle });
            parametros.Add(new SqlParameter { ParameterName = "@Colonia", SqlDbType = SqlDbType.VarChar, Value = registro.Colonia });
            parametros.Add(new SqlParameter { ParameterName = "@Municipio", SqlDbType = SqlDbType.VarChar, Value = registro.Municipio });
            try
            {
                dac.ExecuteNonQuery("spInsertarRegistro", parametros);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
        }

        public List<GetRegistroModel> GetRegistros()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetRegistroModel>();
            try
            {
                DataSet ds = dac.Fill("spObtenerRegistros", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetRegistroModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            ApPaterno = dr["ApPaterno"].ToString(),
                            ApMaterno = dr["ApMaterno"].ToString(),
                            Calle = dr["Calle"].ToString(),
                            Colonia = dr["Colonia"].ToString(),
                            Municipio = dr["Municipio"].ToString(),
                            FechaRegistro = dr["FechaRegistro"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
            return lista;
        }





        public static DataTable ToDataTable<T>(IEnumerable<T> data)
        {
            IEnumerable<T> dat = data;
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(data))
            {
                table.Load(reader);
            }
            return table;
        }










    }

}



