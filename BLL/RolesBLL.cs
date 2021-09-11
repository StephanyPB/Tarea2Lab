using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tarea2Lab.DAL;
using Tarea2Lab.Entidades;

namespace Tarea2Lab.BLL
{
    /// <summary>
    /// En esta clase debemos programar toda la logica de negocios
    /// </summary>
    public class RolesBLL
    {
        /// <summary>
        /// Permite Guardar una entidad en la base de datos
        /// </summary>

        public static bool Guardar(Roles roles)
        {
            if (!Existe(roles.RolId))
                return Insertar(roles);
            else
                return Modificar(roles);
        }
        private static bool Insertar(Roles roles)
        {
            bool paso = false;
            //Creamos una instancia del contexto para poder conectar con la DB
            Contexto db = new Contexto();
            try
            {
                if (db.Roles.Add(roles) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            { throw; }
            finally
            {
                db.Dispose();//Cerramos la conexion
            }
            return paso;
        }
        /// <summary>
        /// Permite Modificar una entidad en la base de datos
        /// </summary>
        private static bool Modificar(Roles roles)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(roles).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            { throw; }
            finally
            {
                db.Dispose();//Cerramos la conexion
            }
            return paso;
        }
        /// <summary>
        /// Permite Eliminar una entidad en la base de datos
        /// </summary>
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                Roles roles = db.Roles.Find(id);

                if (Existe(id))
                {
                    db.Roles.Remove(roles);
                    paso = db.SaveChanges() > 0;
                }
                   
            }
            catch (Exception)
            { throw; }
            finally
            {
                db.Dispose();//Cerramos la conexion
            }
            return paso;
        }
        /// <summary>
        /// Permite Buscar una entidad en la base de datos
        /// </summary>
        public static Roles Buscar(int id)
        {
            Contexto db = new Contexto();
            Roles roles = new Roles();
            try
            {
                roles = db.Roles.Find(id);
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return roles;
        }
        /// <summary>
        /// Permite extraer una lista de Roles de la base de datos
        /// </summary>
        public static List<Roles> GetList(Expression<Func<Roles, bool>> expression)
        {
            List<Roles> Roles = new List<Roles>();
            Contexto db = new Contexto();
            try
            {
                Roles = db.Roles.Where(expression).ToList();
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Roles;
        }
        private static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();
            try
            {
                encontrado = db.Roles.Any(x => x.RolId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }
    }
}
