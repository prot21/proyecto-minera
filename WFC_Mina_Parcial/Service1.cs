using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
//agregamos 
using System.Data;
using System.Data.SqlClient;

namespace DemoServiceInfracciones
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class Service1 : IService1
    {
        // los insumos ....
        SqlConnection cnx = new SqlConnection(@"server=DESKTOP-GERA;Database=Mineria;Integrated Security=SSPI");
        //SqlConnection cnx = new SqlConnection(@"server=DESKTOP-GERA;Database=Mineria;Integrated Security=SSPI");

        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter ada; 
        DataSet dts = new DataSet();

        DataSet IService1.ListarYacimiento()
        {
            try
            {
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarYacimiento";
                cmd.Parameters.Clear();
                ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "ListaYacimiento");
                return dts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    DataSet IService1.InsertarYacimiento(String nombre, String idUbigeo, DateTime fecInicio, String estado, String usu_reg)
    {
        try
        {
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertarYacimiento";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@idUbigeo", idUbigeo);
            cmd.Parameters.AddWithValue("@fecInicio", fecInicio);
            cmd.Parameters.AddWithValue("@estado", estado);
            cmd.Parameters.AddWithValue("@usu_reg", usu_reg);
             
                ada = new SqlDataAdapter(cmd);
            ada.Fill(dts, "Insertar");
            return dts;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

        DataSet IService1.ActualizarYacimiento(String idYacimiento, String nombre, String idUbigeo, DateTime fecInicio, String estado, String usuUltMod)
        {
            try
            {
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ActualizarYacimiento";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idYacimiento", idYacimiento);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@idUbigeo", idUbigeo);
                cmd.Parameters.AddWithValue("@fecInicio", fecInicio);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@usuUltMod", usuUltMod);

                ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "Actualizar");
                return dts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        DataSet IService1.ConsultarYacimiento(String idYacimiento)
        {
            try
            {
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ConsultarYacimiento";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idYacimiento", idYacimiento);

                ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "Consultar");
                return dts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        DataSet IService1.EliminarYacimiento(String idYacimiento)
        {
            try
            {
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_EliminarYacimiento";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idYacimiento", idYacimiento);

                ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "eliminar");
                return dts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
