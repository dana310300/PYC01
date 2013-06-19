using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REP001.Comun.BO;
using REP001.Comun.BO.Context;
using REP001.Comun.Service.Interface;

namespace REP001.Comun.Service.Implement
{
    public class PaisService : IPaisService
    {
        ComunContext db = new ComunContext();
        ETipoAccion accion;
        public Pais Create(Pais p)
        {
            if ( p != null ) {
                accion = ETipoAccion.CREATE;
                
                ValidatePaisProperty(p);
                db.Pais.Add(p);
                db.SaveChanges();
                return db.Pais.FirstOrDefault(x => x.Clave == p.Clave);
            }
            else {
                throw new ArgumentNullException("Pais");
            }

        }

        public void Delete(Pais p)
        {
            if ( p != null ) {
                accion=ETipoAccion.DELETE;
                ValidatePaisProperty(p);
                db.Pais.Remove(p);
                db.SaveChanges();
            }
            else {
                throw new ArgumentNullException("Pais");
            }

        }

        public Pais Retrieve(Pais p)
        {

            Pais po = null;
            if ( p != null ) {
                if ( p.ID != null ) {
                    po = db.Pais.FirstOrDefault(x => x.ID == p.ID);
                }

                if ( po == null ) {
                    po = db.Pais.Find(p);
                }
            }
            return po;
        }

        public void Edit(Pais p)
        {
            if ( p != null ) {
                accion= ETipoAccion.EDIT;
                ValidatePaisProperty(p);
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            throw new ArgumentNullException("Pais");
        }

        public void Dispose()
        {
            db.Dispose();
            
        }

        public List<Pais> RetrievePaises()
        {
            return db.Pais.ToList<Pais>();
        }

        public List<Pais> RetrievePaises(Pais p)
        {
            if ( p != null ) {
                List<Pais> ls = null;
                //agregar filtros
                int? id = null;
                string clave,name= null;
               

                id = p.ID != null ? p.ID : (int?)null;
                clave = !string.IsNullOrEmpty(p.Clave) ? p.Clave : null;
                name = !string.IsNullOrEmpty(p.Name) ? p.Name : null;

                if ( id != null ) {
                    ls = db.Pais.Where(x => x.ID == id).ToList<Pais>();

                }
                if ( clave != null ) {
                    if ( ls != null && ls.Count>=1) {
                        ls = ls.Where(x => x.Clave == clave).ToList<Pais>();
                    }
                    else {
                        ls = db.Pais.Where(x => x.Clave == clave).ToList<Pais>();
                    }
                }
                if ( name != null) {

                    if ( ls != null && ls.Count >= 1 ) {
                        ls = ls.Where(x => x.Name == name).ToList<Pais>();
                    }
                    else {
                        ls = db.Pais.Where(x => x.Name == name).ToList<Pais>();
                    }
                }
                return ls.ToList<Pais>();
            }
            else {
                throw new ArgumentNullException("Pais");
            }

        }


        private void ValidatePaisProperty(Pais p)
        {
            Pais po = null;
            po = p;
            if ( po != null ) {

                if ( accion == ETipoAccion.CREATE ) {
                    Pais prev = db.Pais.FirstOrDefault(x => x.Clave == po.Clave);
                    if ( prev != null ) {
                        throw new DbEntityValidationException("Clave no disponible");
                    }
                }

                if ( accion == ETipoAccion.EDIT ) {

                    if ( po.ID == null ) { throw new DbEntityValidationException("PaisID requerido"); }
                   
                    List<Pais> prev = db.Pais.Where(x => x.Clave == po.Clave).ToList<Pais>();
                    if ( prev != null && prev.Count >= 1 ) {

                        if(prev.Any(x=>x.ID != po.ID))
                            throw new DbEntityValidationException("Clave no disponible");

                    }
                }

                if ( accion == ETipoAccion.DELETE ) {

                    if ( po.ID == null ) { throw new DbEntityValidationException("PaisID requerido"); }

                    List<Ubicacion> ub = null;
                    ub = db.Ubicacion.Where(x => x.Pais != null && x.Pais.ID == po.ID).ToList<Ubicacion>();
                    if ( ub != null && ub.Count>=1) {
                        throw new DbEntityValidationException("Pais se encuentra en uso por una Ubicación");
                    }
                    List<Estado> es = null;
                    es = db.Estado.Where(x => x.Pais != null && x.Pais.ID == po.ID).ToList<Estado>();
                    if ( es != null && es.Count>=1 ) {
                        throw new DbEntityValidationException("Pais se encuentra en uso por un Estado");
                    }

                }

            }

        }

        
    }
}
