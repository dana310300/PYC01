using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REP001.Comun.Service.Interface;
using REP001.Comun.BO;
using REP001.Comun.BO.Context;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.Entity;
using REP001.Comun.Helpers;
namespace REP001.Comun.Service.Implement
{
   public class EmployeeService:IEmployeeService
    {

       ComunContext db = new ComunContext();
       ETipoAccion accion;

        public Employee Create(Employee p)
        {
            if ( p != null  && p.Person!=null) {
                accion = ETipoAccion.CREATE;
                ValidateEmployeeProperty(p);
                db.Employee.Add(p);
                db.SaveChanges();
                return db.Employee.FirstOrDefault(x => x.Person.ID == p.Person.ID);
            }
            else {
                throw new ArgumentNullException("Employee");
            }
        }

        public void Delete(Employee p)
        {
            if ( p != null ) {
                accion = ETipoAccion.DELETE;
                ValidateEmployeeProperty(p);
                db.Employee.Remove(p); ;
                db.SaveChanges();
              }
            else {
                throw new ArgumentNullException("Employee");
            }
        }

        public Employee Retrieve(Employee p)
        {

            Employee po = null;
            if ( p.EmployeeID != null ) {
                po = db.Employee.FirstOrDefault(x => x.EmployeeID == p.EmployeeID);
            }
            if ( p == null ) {
                po = db.Employee.Find(p);
            }
            return po;
        }

        public Employee RetrieveComplete(Employee p)
        {
            if ( p != null  && p.EmployeeID!=null && p.EmployeeID>0) {
                
                var po =(from e in db.Employee.Include("Person")
                         where e.EmployeeID==p.EmployeeID
                          select e).FirstOrDefault();
                //var po = (from e in db.Employee
                //          join per in db.Person
                //          on e.Person.ID equals per.ID
                //          where e.EmployeeID == p.EmployeeID
                //          select new Employee {
                //              EmployeeID = e.EmployeeID,
                //              PayMent = e.PayMent,
                //              Position = e.Position,
                //              Person = per
                //          });

                return po;
            }
            else {
                return null;
            }
          
        }

        public void Edit(Employee p)
        {
            if ( p != null ) {
                accion = ETipoAccion.EDIT;
                ValidateEmployeeProperty(p);
                db.Entry(p).State = EntityState.Modified;
            }
            else
                throw new ArgumentNullException("Employee");
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public List<Employee> RetrieveEmployees()
        {

            var em = db.Employee;
            List<Employee> ls = new List<Employee>();

           foreach (Employee item in em ) {

               Employee emp = new Employee();
               emp = RetrieveComplete(item);
               ls.Add(emp);
               
               
           }
           return ls;
        }

        public List<Employee> RetrieveEmployees(Employee p)
        {
            if ( p != null ) {

                long? eId = p.EmployeeID != null ? p.EmployeeID : null;
                long? id = p.Person != null && p.Person.ID != null ? p.Person.ID : null;
                List<Employee> ls = null;
                if ( eId != null ) {
                    ls = db.Employee.Where(x => x.EmployeeID == eId).ToList<Employee>();

                }
                if ( id != null ) {
                    if ( ls != null && ls.Count >= 1 ) {
                        ls = ls.Where(x => x.Person.ID == p.Person.ID).ToList<Employee>();
                    }
                    else {
                        ls = db.Employee.Where(x => x.Person.ID == p.Person.ID).ToList<Employee>();
                    }
                }

                return ls.ToList<Employee>();
            }
            else {
              return  db.Employee.ToList<Employee>();
            }
        }



        public List<Employee> RetrieveEmployees(int page, int count, string sort, bool sortdecending, out int resultcount)
        {
            List<Employee> ls = new List<Employee>();

            var result = (from a in db.Employee.Include("Person")
                          where a.EmployeeID == a.EmployeeID
                          select a);

                result = (from a in result
                          group a by a.EmployeeID into u
                         select u.FirstOrDefault());

             resultcount = result.Count();
             int skip = getSkip(page, count);
             int co = getCount(page,resultcount, count, skip);
             result = result.OrderBy(sort).Skip(skip).Take(co);

             List<Employee> elementsls = result.ToList<Employee>();

             foreach ( Employee item in elementsls ) {
                 Employee emp = RetrieveComplete(item);
                 ls.Add(emp);
             }

            return ls;
        }

        private void ValidateEmployeeProperty(Employee p)
        {
            switch ( accion ) {
                case ETipoAccion.CREATE:
                    if ( p == null || p.EmployeeID == null || p.Person == null || p.Person.ID == null ) {
                        throw new DbEntityValidationException("EmployeeID,PersonID");

                    }
                    break;
                case ETipoAccion.EDIT:

                    if ( p == null || p.EmployeeID == null || p.Person == null || p.Person.ID == null ) {
                        throw new DbEntityValidationException("EmployeeID,PersonID");

                    }
                    break;
                case ETipoAccion.DELETE:

                    if ( p == null || p.EmployeeID == null ) {
                        throw new DbEntityValidationException("EmployeeID,PersonID");

                    }
                    break;
                default:
                    break;
            }
            return;
        }

        private int getSkip(int page,int count) {
            if ( page < 2 ) {
                return 0;
            }
            else {
                return (page-1) * count;
            }
        }

        private int getCount(int page,int result, int count, int skip) {

            if ( page > 1 ) {
                int numPages = getNumPages(result, count);

                if ( page == numPages ) {
                    if ( (result - skip) > count ) {
                        return (result - skip);
                    }
                    else {
                        return count;
                    }
                }
                else return count;
                
            }
            else { return count; }
        
        }

        private int getNumPages(int result, int count) {
            return result / count;
        }
    }
}
