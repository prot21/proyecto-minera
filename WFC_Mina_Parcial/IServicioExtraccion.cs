using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DemoServiceInfracciones
{
    [ServiceContract]
    public interface IServicioExtraccion
    {
        [OperationContract]
        ExtraccionBE ConsultarExtraccion(String id_extraccion);
        [OperationContract]
        List<ExtraccionBE> ListarExtraccion();
        bool InsertarExtraccion(ExtraccionBE objExtraccionBE);

        [OperationContract]
        bool ActualizarExtraccion(ExtraccionBE objExtraccionBE);
        
    }

    [DataContract]
    [Serializable]
    public class ExtraccionBE
    {
        // Miembros privados
        private String mvarid_extraccion;
        private DateTime mvarfechaInicio;
        private DateTime mvarfechaFin;
        private String mvarest_extraccion;
        private String mvarid_yacimiento;
        private DateTime mvarfec_reg;
        private String mvarusu_reg;
        private DateTime mvarfec_ult_mod;
        private String varusu_ult_mod;

        [DataMember]
        public String id_extraccion
        {
            get { return mvarid_extraccion; }
            set { mvarid_extraccion = value; }
        }

        [DataMember]
        public DateTime fechaInicio
        {
            get { return mvarfechaInicio; }
            set { mvarfechaInicio = value; }
        }

        [DataMember]
        public DateTime fechaFin
        {
            get { return mvarfechaFin; }
            set { mvarfechaFin = value; }
        }

        [DataMember]
        public String est_extraccion
        {
            get { return mvarest_extraccion; }
            set { mvarest_extraccion = value; }
        }

        [DataMember]
        public String id_yacimiento
        {
            get { return mvarid_yacimiento; }
            set { mvarid_yacimiento = value; }
        }

        [DataMember]
        public DateTime fec_reg
        {
            get { return mvarfec_reg; }
            set { mvarfec_reg = value; }
        }

        [DataMember]
        public String usu_reg
        {
            get { return mvarusu_reg; }
            set { mvarusu_reg = value; }
        }
        [DataMember]
        public DateTime fec_ult_mod
        {
            get { return mvarfec_ult_mod; }
            set { mvarfec_ult_mod = value; }
        }
        [DataMember]
        public String usu_ult_mod
        {
            get { return varusu_ult_mod; }
            set { varusu_ult_mod = value; }
        }
    }
}
