using Repositorios;
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

        public void generoTokenNuevo(Usuarios user, string token)
        {
            Usuarios myUser = Context.Usuarios.Find(user.IdUsuario);
            myUser.Token = token;
            Context.SaveChanges();
        }

        public Usuarios Modificar(Usuarios u)
        {
 
            Usuarios user = Context.Usuarios.Find(u.IdUsuario);
            user.Nombre = u.Nombre;
            user.Apellido = u.Apellido;
            user.FechaNacimiento = u.FechaNacimiento;
            user.Foto = u.Foto;
            int cont = 0;

            if (user.UserName == null)
            { //verifico xq en el login no se carga el ombre ni el apellido por lo tanto es probable q una vez este nulo
                string usuarioPosible = u.Nombre + u.Apellido;
                string nombreUsuarioPosible = "";
                Usuarios user2 = new Usuarios();
                user2 = Context.Usuarios.Where(p => (string)p.UserName == usuarioPosible).FirstOrDefault();
                if (user2 != null)
                {
                    do
                    {
                        cont = cont + 1;
                        nombreUsuarioPosible = usuarioPosible + Convert.ToString(cont);
                        user2 = Context.Usuarios.Where(p => (string)p.UserName == nombreUsuarioPosible).FirstOrDefault();
                    } while (user2 != null);

                    user.UserName = nombreUsuarioPosible;
                    Context.SaveChanges();
                    return user;
                }
                else
                {
                    user.UserName = usuarioPosible;
                    Context.SaveChanges();
                    return user;
                }
            }
            else
            {
                Context.SaveChanges();
                return user;
            }
        }

        public void hacerAdmin(int id)
        {
            Usuarios user = Context.Usuarios.Where(o => o.IdUsuario == id).First();
            user.TipoUsuario = 0;
            Context.SaveChanges();
        }

        public List<Usuarios> obtengoUsuariosTipo1()
        {
            return Context.Usuarios.Where(o => o.TipoUsuario == 1).ToList();
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

        public void activoToken(Usuarios user)
        {
                user.Activo = true;
                user.Token = "000000000";
                Context.SaveChanges();
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

        public Usuarios Editar(Usuarios user, int id)
        {
            throw new NotImplementedException();
        }

        public Usuarios obtenerPorToken(string token)
        {
            try
            {
                var user = Context.Usuarios
                .Where(b => (string)b.Token == (string)token)
                .FirstOrDefault();
                return user;
            }
            catch (Exception)
            {
                return default;
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
            u.ConfirmPassword = "0";
            Context.SaveChanges();      
        }

    }
}
