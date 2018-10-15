
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AppUsuario.Model
{
    public class dbUsuarioRepository : IDbUsuarioRepository
    {
        private readonly dbUsuarioContext _contextU;
      
        public dbUsuarioRepository(dbUsuarioContext uc)
        {            
            _contextU = uc;
        }

        public IEnumerable<Usuario> FindAll()
        {
           
                return  _contextU.Usuarios                                
                                .ToList<Usuario>();
        }


        public bool Exists(int id)
        {
            return _contextU.Usuarios.Any(p => p.ID ==   id);
        }


        public Usuario Find(int id)
        {
            return _contextU.Usuarios.FirstOrDefault(p => p.ID == id);
        }

        public Usuario Insert(Usuario p)
        {            
            _contextU.Usuarios.Add(p);
            _contextU.SaveChanges();

            return p;
        }

        public Usuario Update(Usuario p)
        {
            var usuario = _contextU.Usuarios.Find(p);

            if (usuario == null)
                return null;
            try
            {
                _contextU.Add(p);
                _contextU.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                _contextU.SaveChanges();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (usuario != null)
                    throw;
               
            }

            return p;
        }

        public bool Delete(int id)
        {
            var usuario = _contextU.Usuarios.Find(id);

            if (usuario == null)
                return false;

            _contextU.Usuarios.Remove(usuario);
            _contextU.SaveChanges();

            return true;
        }


        public bool ChangePassword(int id, string newPassword)
        {
            Usuario u = Find(id);
                       
            if (u == null)
                return false;

            u.Password = newPassword;            
            _contextU.SaveChanges();

            return true;
        }
    }
    
}
