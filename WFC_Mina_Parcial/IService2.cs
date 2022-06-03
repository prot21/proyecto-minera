using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
//add...
using System.Data;

namespace DemoServiceInfracciones
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService2" in both code and config file together.
    [ServiceContract]
    public interface IService2
    {
        [OperationContract]
        DataSet ListarMantenimiento();

        [OperationContract]
        DataSet InsertarMantenimiento(String id_maquinaria, String tipo, DateTime fechaInicio, DateTime fechaFin, String est_man, String comentario, String usu_reg);

        [OperationContract]
        DataSet ActualizarMantenimiento(String id_mantenimiento, String id_maquinaria, String tipo, DateTime fechaInicio, DateTime fechaFin, String est_man, String comentario,String usu_ult_mod);

        [OperationContract]
        DataSet ConsultarMantenimiento(String id_mantenimiento);

        [OperationContract]
        DataSet EliminarMantenimiento(String id_mantenimiento);
    }
}
