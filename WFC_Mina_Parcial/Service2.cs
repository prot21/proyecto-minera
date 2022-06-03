using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
//add...
using System.Data;
using System.Data.SqlClient;

namespace DemoServiceInfracciones
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in both code and config file together.
    public class Service2 : IService2
    {
        // los insumos ....
        SqlConnection cnx = new SqlConnection(@"server=DESKTOP-GERA;Database=Mineria;Integrated Security=SSPI");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter ada;
        DataSet dts = new DataSet();

        DataSet IService2.ListarMantenimiento()
        {
            try
            {
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarMantenimiento";
                cmd.Parameters.Clear();
                ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "ListaMantenimiento");
                return dts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        DataSet IService2.InsertarMantenimiento(String id_maquinaria, String tipo, DateTime fechaInicio, DateTime fechaFin, String est_man, String comentario, String usu_reg)
        {
            try
            {
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertarMantenimiento";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_maquinaria", id_maquinaria);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                cmd.Parameters.AddWithValue("@est_man", est_man);
                cmd.Parameters.AddWithValue("@comentario", comentario);
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

        DataSet IService2.ActualizarMantenimiento(String id_mantenimiento, String id_maquinaria, String tipo, DateTime fechaInicio, DateTime fechaFin, String est_man, String comentario, String usu_ult_mod)
        {
            try
            {
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ActualizarMantenimiento";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_mantenimiento", id_mantenimiento);
                cmd.Parameters.AddWithValue("@id_maquinaria", id_maquinaria);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                cmd.Parameters.AddWithValue("@est_man", est_man);
                cmd.Parameters.AddWithValue("@comentario", comentario);
                cmd.Parameters.AddWithValue("@usu_ult_mod", usu_ult_mod);

                ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "Actualizar");
                return dts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        DataSet IService2.ConsultarMantenimiento(String id_mantenimiento)
        {
            try
            {
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ConsultarMantenimiento";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_mantenimiento", id_mantenimiento);

                ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "Consultar");
                return dts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        DataSet IService2.EliminarMantenimiento(String id_mantenimiento)
        {
            try
            {
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_EliminarMantenimiento";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_mantenimiento", id_mantenimiento);

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
