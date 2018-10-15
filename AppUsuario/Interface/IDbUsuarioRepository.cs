using System.Collections.Generic;

namespace AppUsuario.Model
{
    public interface IDbUsuarioRepository
    {
        IEnumerable<Usuario> FindAll();

        bool Delete(int id);
        Usuario Find(int id);
        Usuario Insert(Usuario item);
        Usuario Update(Usuario p);
        bool Exists(int id);
    }
}