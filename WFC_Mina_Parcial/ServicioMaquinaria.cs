using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
//Agregar
using System.Data.Entity.Core;

namespace DemoServiceInfracciones
{
    public class ServicioMaquinaria: IServicioMaquinaria
    {
        public MaquinariaBE ConsultarMaquinaria(String id_maquinaria)
        { 
            //Creamos la instancia del modelo
            MineriaEntities MineraDB = new MineriaEntities();
            
            try
            {
                //Creamos una instancia de la data contractual para devolver el resultado
                MaquinariaBE objMaquinaria = new MaquinariaBE();

                Maquinaria objMaquinariaSelect = (
                            from elemento in MineraDB.Maquinaria
                            where elemento.id_maquinaria == id_maquinaria
                            select elemento
                        ).FirstOrDefault();
               
                objMaquinaria.id_maquinaria = objMaquinariaSelect.id_maquinaria;
                objMaquinaria.id_yacimiento = objMaquinariaSelect.id_yacimiento;
                objMaquinaria.tipo = objMaquinariaSelect.tipo;
                objMaquinaria.marca = objMaquinariaSelect.marca;
                objMaquinaria.modelo = objMaquinariaSelect.modelo;
                objMaquinaria.est_maq = objMaquinariaSelect.est_maq;
                objMaquinaria.UltRevision = Convert.ToDateTime(objMaquinariaSelect.UltRevision);
                objMaquinaria.fec_reg = Convert.ToDateTime(objMaquinariaSelect.fec_reg);
                objMaquinaria.usu_reg = objMaquinariaSelect.usu_reg;
                objMaquinaria.fec_ult_mod = Convert.ToDateTime(objMaquinariaSelect.fec_ult_mod);
                objMaquinaria.usu_ult_mod = objMaquinariaSelect.usu_ult_mod;

                //objClienteBE.Deuda = CalcularDeudaCliente(strCod);

                return objMaquinaria;
            }
            catch (EntityException ex)
            {

                throw new Exception(ex.Message);
            }
        }
        private String mvarid_extraccion;
        private DateTime mvarfechaInicio;
        private DateTime mvarfechaFin;
        private String mvarest_extraccion;
        private String mvarid_yacimiento;
        private DateTime mvarfec_reg;
        private String mvarusu_reg;
        private DateTime mvarfec_ult_mod;
        private String varusu_ult_mod;


        public bool InsertMaquinaria(MaquinariaBE objMaquinariaBE)
        {
            //Creamos la instancia del modelo
            MineriaEntities MineraDB = new MineriaEntities();
            try
            {
                //DEL ENTITY
                Maquinaria objMaquinaria = new Maquinaria();

                var objMaquinariaSelect= (
                        from elemento in MineraDB.Maquinaria
                        select elemento.id_maquinaria
                    ).ToArray();
                string ultimoId = objMaquinariaSelect[objMaquinariaSelect.Length - 1];
                objMaquinaria.id_maquinaria = "M" + (int.Parse(ultimoId.Split('M')[1]) + 1);
                objMaquinaria.id_yacimiento = objMaquinariaBE.id_yacimiento;
                objMaquinaria.tipo = objMaquinariaBE.tipo;
                objMaquinaria.marca = objMaquinariaBE.marca;
                objMaquinaria.modelo = objMaquinariaBE.modelo;
                objMaquinaria.est_maq = objMaquinariaBE.est_maq;
                objMaquinaria.UltRevision = Convert.ToDateTime(objMaquinariaBE.UltRevision);
                objMaquinaria.fec_reg = Convert.ToDateTime(objMaquinariaBE.fec_reg);
                objMaquinaria.usu_reg = objMaquinariaBE.usu_reg;
                objMaquinaria.fec_ult_mod = Convert.ToDateTime(objMaquinariaBE.fec_ult_mod);
                objMaquinaria.usu_ult_mod = objMaquinariaBE.usu_ult_mod;

                MineraDB.Maquinaria.Add(objMaquinaria);

                MineraDB.SaveChanges();
                return true;
            }
            catch (EntityException ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<MaquinariaBE> ListarMaquinaria()
        {
            //Creamos la instancia del modelo
            MineriaEntities MineraDB = new MineriaEntities();
            //Declaramos una instancia de la data contractual
            List<MaquinariaBE> objListaMaquinaria = new List<MaquinariaBE>();

            var objMaquinariaLista = (
                       from elemento in MineraDB.Maquinaria
                       select elemento);
            foreach(var maquinaria in objMaquinariaLista)
            {
                //Declaramos una instancia de la data contractual
                MaquinariaBE objMaquinaria = new MaquinariaBE();

                objMaquinaria.id_maquinaria = objMaquinaria.id_maquinaria;
                objMaquinaria.id_yacimiento = objMaquinaria.id_yacimiento;
                objMaquinaria.tipo = objMaquinaria.tipo;
                objMaquinaria.marca = objMaquinaria.marca;
                objMaquinaria.modelo = objMaquinaria.modelo;
                objMaquinaria.est_maq = objMaquinaria.est_maq;
                objMaquinaria.UltRevision = Convert.ToDateTime(objMaquinaria.UltRevision);
                objMaquinaria.fec_reg = Convert.ToDateTime(objMaquinaria.fec_reg);
                objMaquinaria.usu_reg = objMaquinaria.usu_reg;
                objMaquinaria.fec_ult_mod = Convert.ToDateTime(objMaquinaria.fec_ult_mod);
                objMaquinaria.usu_ult_mod = objMaquinaria.usu_ult_mod;

                //Agregar la instancia de data contractual a la lista
                objListaMaquinaria.Add(objMaquinaria);
            }
            //Se retorna la lista
            return objListaMaquinaria;
        }

        public bool UpdateMaquinaria(MaquinariaBE objmaquinariaBE)
        {
            //Instaciando el modelo
            MineriaEntities MineraDB = new MineriaEntities();
            try
            {
                //Ubicamos la maquinaria que se desea actualizar
                Maquinaria objMaquinariaSelect = (
                        from elemento in MineraDB.Maquinaria
                        where elemento.id_maquinaria == objmaquinariaBE.id_maquinaria
                        select elemento
                    ).FirstOrDefault();

                //Asignamos las propiedades desde la data contractual objVendedorBE
                objMaquinariaSelect.id_maquinaria = objmaquinariaBE.id_maquinaria;
                objMaquinariaSelect.id_yacimiento = objmaquinariaBE.id_yacimiento;
                objMaquinariaSelect.tipo = objmaquinariaBE.tipo;
                objMaquinariaSelect.marca = objmaquinariaBE.marca;
                objMaquinariaSelect.modelo = objmaquinariaBE.modelo;
                objMaquinariaSelect.est_maq = objmaquinariaBE.est_maq;
                objMaquinariaSelect.UltRevision = Convert.ToDateTime(objmaquinariaBE.UltRevision);
                objMaquinariaSelect.fec_reg = Convert.ToDateTime(objmaquinariaBE.fec_reg);
                objMaquinariaSelect.usu_reg = objmaquinariaBE.usu_reg;
                objMaquinariaSelect.fec_ult_mod = Convert.ToDateTime(objmaquinariaBE.fec_ult_mod);
                objMaquinariaSelect.usu_ult_mod = objmaquinariaBE.usu_ult_mod;

                //Refrescamos la BD
                MineraDB.SaveChanges();
                return true;

            }
            catch (EntityException ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
