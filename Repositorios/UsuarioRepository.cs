using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Repositorios;

namespace Repositorios
{
    public class UsuarioRepository
    {
        Context Context;
        public UsuarioRepository(Context context)
        {
            this.Context = context;
        }

        public Usuarios obtenerUsuario(string email)
        {
            try
            {
                var user = Context.Usuarios
                    .Where(b => (string)b.Email == (string)email)
                    .FirstOrDefault();
                return user;

            } catch(DbEntityValidationException e)
            {
                foreach(var eve in e.EntityValidationErrors)
                {
                     foreach(var p in eve.ValidationErrors)
                    {
                        Console.WriteLine(p.GetType().Name);
                        Console.WriteLine(p.ErrorMessage);
                        throw;
                    }
                }
            }
            return null;
        }

        public Usuarios obtenerUsuarioPorUserName(string userName)
        {
            try
            {
                var user = Context.Usuarios
                    .Where(b => (string)b.UserName == (string)userName)
                    .FirstOrDefault();
                return user;

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    foreach (var p in eve.ValidationErrors)
                    {
                        Console.WriteLine(p.GetType().Name);
                        Console.WriteLine(p.ErrorMessage);
                        throw;
                    }
                }
            }
            return null;
        }


        public void altaUsuario(Usuarios u)
        {

            try
            {
                Context.Usuarios.Add(u);
                Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }


        public List<Usuarios> traerUsuariosActivos()
        {
             List<Usuarios> user = Context.Usuarios
            .Where(b => b.Activo == true)
            .ToList();
            return user;
        }

        public List<Usuarios> traerTodosLosUsuarios()
        {
            List<Usuarios> miListita = Context.Usuarios.ToList();
            return miListita;
        }
    }
}
