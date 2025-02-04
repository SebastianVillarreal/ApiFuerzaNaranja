using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;

namespace marcatel_api.Services
{
    public class LoginService
    {
        private  string connection;
        
        
        public LoginService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public UsuarioModel Login(string user, string pass)
        {
            
            UsuarioModel usuario = new UsuarioModel();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList();
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.VarChar, Value = user });
                parametros.Add(new SqlParameter { ParameterName = "@pPass", SqlDbType = SqlDbType.VarChar, Value = pass });
                DataSet ds = dac.Fill("sp_login_pv", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        usuario.NombreUsuario = row["NombreUsuario"].ToString();
                        usuario.NombrePersona = row["NombrePersona"].ToString();
                        usuario.IdSucursal = int.Parse(row["IdSucursal"].ToString());
                        usuario.NombreSucursal = row["NombreSucursal"].ToString();
                        usuario.Id = int.Parse(row["Id"].ToString());
                        usuario.IdPerfil = int.Parse(row["id_perfil"].ToString());
                        usuario.PctDescuento = decimal.Parse( row["Aplica"].ToString());
                        usuario.Cajon = int.Parse(row["Cajon"].ToString());
                        usuario.SuspenderCuenta = int.Parse(row["SuspenderCuenta"].ToString());
                        usuario.CancelarVenta = int.Parse(row["CancelarVenta"].ToString());
                        usuario.CancelarArticulo = int.Parse(row["CancelarArticulo"].ToString());
                        usuario.CorteZ = int.Parse(row["CorteZ"].ToString());
                    
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {   
                Console.Write(ex.Message);
                throw ex;
            }
           
        }

        public void InsertSessionCajero(int id_usuario, int id_sucursal, int caja)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = SqlDbType.VarChar, Value = id_usuario });
            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = id_sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pCaja", SqlDbType = SqlDbType.VarChar, Value = caja });
            try
            {
                dac.ExecuteNonQuery("sp_insert_login_cajero", parametros);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
        }

        public DatosHuellaModel GetDatosHuella(int id)
        {
            
            DatosHuellaModel usuario = new DatosHuellaModel();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList();
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.VarChar, Value = id });

                DataSet ds = dac.Fill("PV_GetDatosUsuarioHuella", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {

                        usuario.Descuento = decimal.Parse( row["PorcentajeDescuento"].ToString());
                        usuario.Id = int.Parse(row["Id"].ToString());
                        usuario.IdUsuario = int.Parse(row["IdUsuario"].ToString());
                        usuario.NombreCompleto = row["nombreCompleto"].ToString();
                    
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {   
                Console.Write(ex.Message);
                throw ex;
            }
           
        }

        
    }
}
