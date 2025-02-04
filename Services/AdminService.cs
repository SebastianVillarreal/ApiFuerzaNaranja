using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections.Generic;

namespace marcatel_api.Services
{
    public class AdminService
    {
        private  string connection;

        public AdminService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }



        public string InsertCategoria(CategoriaModel categoria)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            string mensaje = "";
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = categoria.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pDescripcion", SqlDbType = SqlDbType.VarChar, Value = categoria.Descripcion });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.Int, Value = categoria.usuario });
                dac.ExecuteNonQuery("sp_insert_categoria", parametros);
                mensaje = "Registro insertado";
                return mensaje;
            }
            catch (Exception ex)
            {
                mensaje = "Ha courrido el siguiente error: " + ex.Message;
                return mensaje;
            }
            
        }

        public string UpdatePWd(string key, int id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            string mensaje = "";
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.VarChar, Value = id });
                parametros.Add(new SqlParameter { ParameterName = "@pKey", SqlDbType = SqlDbType.VarChar, Value = key });
                dac.ExecuteNonQuery("ADM_UpdatePwdUsuario", parametros);
                mensaje = "Registro insertado";
                return mensaje;
            }
            catch (Exception ex)
            {
                mensaje = "Ha courrido el siguiente error: " + ex.Message;
                return mensaje;
            }
            
        }


        public List<PersonaModel> GetUsuarios()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<PersonaModel>();
            try
            {
                DataSet ds = dac.Fill("sp_get_usuarios", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new PersonaModel
                        {
                            Id = int.Parse(dr["IdPersona"].ToString()),
                            IdUsuario = int.Parse(dr["id"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            NombreUsuario = dr["nombre_usuario"].ToString(),
                            NombreSede = dr["NombreSucursal"].ToString()
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

        public void UpodateHuellaCajero(byte[] Huella, int IdCajero)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pHuella", SqlDbType = SqlDbType.VarBinary, Value = Huella });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.Int, Value = IdCajero });
                dac.ExecuteNonQuery("PV_UpdateHuellaUsuario", parametros);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw ex;
            }
        }

        public void InsertaHuellaCajero(byte[] Huella, int IdCajero)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pHuella", SqlDbType = SqlDbType.VarBinary, Value = Huella });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.Int, Value = IdCajero });
                dac.ExecuteNonQuery("sp_insert_huella_cajero", parametros);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw ex;
            }
        }

        public int InsertPersona(PersonaModel persona, int id_usuario)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            int resultado = 0;
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = persona.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pApPaterno", SqlDbType = SqlDbType.VarChar, Value = persona.ApPaterno });
                parametros.Add(new SqlParameter { ParameterName = "@pApMaterno", SqlDbType = SqlDbType.VarChar, Value = persona.ApMaterno });
                parametros.Add(new SqlParameter { ParameterName = "@pPerfil", SqlDbType = SqlDbType.Int, Value = persona.Perfil });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.Int, Value = id_usuario });
                parametros.Add(new SqlParameter { ParameterName = "@pSede", SqlDbType = SqlDbType.Int, Value = persona.IdSede });


                DataSet ds = dac.Fill("sp_insert_persona", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        resultado =  int.Parse(dr["Id"].ToString());
                        return resultado;
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                Console.Write("Ha courrido el siguiente error: " + ex.Message);
                return 0;
            }

        }

        
    }
    

}