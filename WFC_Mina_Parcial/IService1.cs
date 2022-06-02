using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
//agregamos
using System.Data;

namespace DemoServiceInfracciones
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        DataSet ListarYacimiento();

        [OperationContract]
        DataSet InsertarYacimiento(String nombre, String idUbigeo, DateTime fecInicio, String estado, String usu_reg);


        [OperationContract]
        DataSet ActualizarYacimiento(String idYacimiento,  String nombre, String idUbigeo, DateTime fecInicio, String estado, String usuUltMod);

        [OperationContract]
        DataSet ConsultarYacimiento(String idYacimiento);

        [OperationContract]
        DataSet EliminarYacimiento(String idYacimiento);

        // TODO: agregue aquí sus operaciones de servicio
    }

    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    // Puede agregar archivos XSD al proyecto. Después de compilar el proyecto, puede usar directamente los tipos de datos definidos aquí, con el espacio de nombres "DemoServiceInfracciones.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
