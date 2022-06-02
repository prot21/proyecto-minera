using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DemoServiceInfracciones
{
    [ServiceContract]
    public interface IServicioMaquinaria
    {
        [OperationContract]
        MaquinariaBE ConsultarMaquinaria(String id_maquinaria);
        [OperationContract]
        List<MaquinariaBE> ListarMaquinaria();
        bool InsertVendedor(MaquinariaBE objmaquinariaBE);

        [OperationContract]
        bool UpdateMaquinaria(MaquinariaBE objMaquinariaBE);
    }


    // Definimos la clase contractual MaquinariaBE
    [DataContract]
    [Serializable]
    public class MaquinariaBE
    {
        // Miembros privados
        private String mvarid_maquinaria;
        private String mvarid_yacimiento;
        private String mvartipo;
        private String mvarmarca;
        private String mvarmodelo;
        private String mvarest_maq;
        private DateTime mvarUltRevision;
        private DateTime mvarfec_reg;
        private String mvarusu_reg;
        private DateTime mvarfec_ult_mod;
        private String varusu_ult_mod;

        [DataMember]
        public String id_maquinaria
        {
            get { return mvarid_maquinaria; }
            set { mvarid_maquinaria = value; }
        }

        [DataMember]
        public String id_yacimiento
        {
            get { return mvarid_yacimiento; }
            set { mvarid_yacimiento = value; }
        }

        [DataMember]
        public String tipo
        {
            get { return mvartipo; }
            set { mvartipo = value; }
        }

        [DataMember]
        public String marca
        {
            get { return mvarmarca; }
            set { mvarmarca = value; }
        }

        [DataMember]
        public String modelo
        {
            get { return mvarmodelo; }
            set { mvarmodelo = value; }
        }

        [DataMember]
        public String est_maq
        {
            get { return mvarest_maq; }
            set { mvarest_maq = value; }
        }

        [DataMember]
        public DateTime UltRevision
        {
            get { return mvarUltRevision; }
            set { mvarUltRevision = value; }
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
