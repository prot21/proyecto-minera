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
    public class ServicioExtraccion : IServicioExtraccion
    {
        

        public ExtraccionBE ConsultarExtraccion(string id_extraccion)
        {
            MineriaEntities MineraDB = new MineriaEntities();
            try
            {
                //Creamos una instancia de la data contractual para devolver el resultado
                ExtraccionBE objExtraccion = new ExtraccionBE();

                Extraccion objExtraccionSelect = (
                            from elemento in MineraDB.Extraccion
                            where elemento.id_extraccion == id_extraccion
                            select elemento
                        ).FirstOrDefault();

                objExtraccion.id_extraccion = objExtraccionSelect.id_extraccion;
                objExtraccion.fechaInicio = Convert.ToDateTime(objExtraccionSelect.fechaInicio);
                objExtraccion.fechaFin = Convert.ToDateTime(objExtraccionSelect.fechaFin);
                objExtraccion.est_extraccion = objExtraccionSelect.est_extraccion;
                objExtraccion.id_yacimiento = objExtraccionSelect.id_yacimiento;
                objExtraccion.fec_reg = Convert.ToDateTime(objExtraccionSelect.fec_reg);
                objExtraccion.usu_reg = objExtraccionSelect.usu_reg;
                objExtraccion.fec_ult_mod = Convert.ToDateTime(objExtraccionSelect.fec_ult_mod);
                objExtraccion.usu_ult_mod = objExtraccionSelect.usu_ult_mod;


                return objExtraccion;
            }
            catch (EntityException ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public List<ExtraccionBE> ListarExtraccion()
        {
            MineriaEntities MineraDB = new MineriaEntities();
            //Declaramos una instancia de la data contractual
            List<ExtraccionBE> objListaExtraccion = new List<ExtraccionBE>();

            var objExtraccionLista = (
                       from elemento in MineraDB.Extraccion
                       select elemento);
            foreach (var extraccion in objExtraccionLista)
            {
                //Declaramos una instancia de la data contractual
                ExtraccionBE objExtraccion = new ExtraccionBE();

                objExtraccion.id_extraccion = objExtraccion.id_extraccion;
                objExtraccion.fechaInicio = Convert.ToDateTime(objExtraccion.fechaInicio);
                objExtraccion.fechaFin = Convert.ToDateTime(objExtraccion.fechaFin);
                objExtraccion.est_extraccion = objExtraccion.est_extraccion;
                objExtraccion.id_yacimiento = objExtraccion.id_yacimiento;
                objExtraccion.fec_reg = Convert.ToDateTime(objExtraccion.fec_reg);
                objExtraccion.usu_reg = objExtraccion.usu_reg;
                objExtraccion.fec_ult_mod = Convert.ToDateTime(objExtraccion.fec_ult_mod);
                objExtraccion.usu_ult_mod = objExtraccion.usu_ult_mod;

                //Agregar la instancia de data contractual a la lista
                objListaExtraccion.Add(objExtraccion);
            }
            //Se retorna la lista
            return objListaExtraccion;
        }
        public bool InsertarExtraccion(ExtraccionBE objExtraccionBE)
        {
            //Creamos la instancia del modelo
            MineriaEntities MineraDB = new MineriaEntities();
            try
            {
                //DEL ENTITY
                Extraccion objExtraccion = new Extraccion();

                var objExtraccionSelect = (
                        from elemento in MineraDB.Extraccion
                        select elemento.id_extraccion
                    ).ToArray();
                string ultimoId = objExtraccionSelect[objExtraccionSelect.Length - 1];
                objExtraccion.id_extraccion = "X" + (int.Parse(ultimoId.Split('X')[1]) + 1);
                objExtraccion.fechaInicio = Convert.ToDateTime(objExtraccionBE.fechaInicio);
                objExtraccion.fechaFin = Convert.ToDateTime(objExtraccionBE.fechaFin);
                objExtraccion.est_extraccion = objExtraccionBE.est_extraccion;
                objExtraccion.id_yacimiento = objExtraccionBE.id_yacimiento;
                objExtraccion.fec_reg = Convert.ToDateTime(objExtraccionBE.fec_reg);
                objExtraccion.usu_reg = objExtraccionBE.usu_reg;
                objExtraccion.fec_ult_mod = Convert.ToDateTime(objExtraccionBE.fec_ult_mod);
                objExtraccion.usu_ult_mod = objExtraccionBE.usu_ult_mod;

                MineraDB.Extraccion.Add(objExtraccion);

                MineraDB.SaveChanges();
                return true;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        public bool ActualizarExtraccion(ExtraccionBE objExtraccionBE)
        {
            //Instaciando el modelo
            MineriaEntities MineraDB = new MineriaEntities();
            try
            {
                //Ubicamos la maquinaria que se desea actualizar
                Extraccion objExtraccionSelect = (
                        from elemento in MineraDB.Extraccion
                        where elemento.id_extraccion == objExtraccionBE.id_extraccion
                        select elemento
                    ).FirstOrDefault();

                //Asignamos las propiedades desde la data contractual objVendedorBE
                objExtraccionSelect.id_extraccion = objExtraccionBE.id_extraccion;
                objExtraccionSelect.fechaInicio = Convert.ToDateTime(objExtraccionBE.fechaInicio);
                objExtraccionSelect.fechaFin = Convert.ToDateTime(objExtraccionBE.fechaFin);
                objExtraccionSelect.est_extraccion = objExtraccionBE.est_extraccion;
                objExtraccionSelect.id_yacimiento = objExtraccionBE.id_yacimiento;
                objExtraccionSelect.fec_reg = Convert.ToDateTime(objExtraccionBE.fec_reg);
                objExtraccionSelect.usu_reg = objExtraccionBE.usu_reg;
                objExtraccionSelect.fec_ult_mod = Convert.ToDateTime(objExtraccionBE.fec_ult_mod);
                objExtraccionSelect.usu_ult_mod = objExtraccionBE.usu_ult_mod;

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
