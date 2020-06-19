using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Repositorios
{
    public class UsuarioRepository : ICrud<Usuarios>
    {
        Context Context;
        public UsuarioRepository(Context context)
        {
            this.Context = context;
        }

        public int Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public int Crear(Usuarios u)
        {
            try
            {
                Context.Usuarios.Add(u);
                Context.SaveChanges();
                return u.IdUsuario;
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

        public Usuarios Modificar(Usuarios obj)
        {
            throw new NotImplementedException();
        }

        public Usuarios ObtenerPorId(int id)
        {
            try
            {
                return Context.Usuarios.Find(id);
            }
            catch (Exception)
            {
                return default;
            }
        }

        public List<Usuarios> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public Usuarios obtenerUsuario(string email)
        {
            try
            {
                var user = Context.Usuarios
                    .Where(b => (string)b.Email == (string)email)
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


        public void MD5Hash(Usuarios u)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(u.Password));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }

            u.Password = hash.ToString();
            Context.SaveChanges();
            
        }

    }
}
