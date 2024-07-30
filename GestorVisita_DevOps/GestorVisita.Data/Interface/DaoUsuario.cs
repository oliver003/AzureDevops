using System;

public class DaoUsuario
{
    private readonly GV_Context context;
    public DaoUsuario(GV_Context Context);
 
    {
        context = Context;
    }
    public void AddUsuario(Usuario usuario)
    {
        if (usuario == null)
        {
            throw new ArgumentNullException(nameof(usuario), "El objeto usuario no puede ser nulo.");
        }
        int nextId = context.Usuario.Count() > 0 ? context.Usuario.Max(v => v.Id) + 1 : 1;
        usuario.Id = nextId;
        context.Usuario.Add(usuario);
        context.SaveChanges();
    }

    public void UpdateUsuario(Usuario usuario)
    {
        if (usuario == null)
        {
            throw new ArgumentNullException(nameof(usuario), "El objeto Usuario no puede ser nulo.");
        }

        context.Entry(usuario).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void DeleteUsuario(int id)
    {
        if (id == 0)
        {
            throw new ArgumentNullException("EL ID NO PUEDE SER 0.");
        }
        var usuario = context.Usuario.Find(id);
        if (usuario != null)
        {
            context.Usuario.Remove(visita);
            context.SaveChanges();
        }
        else
        {
            throw new ArgumentNullException("NO SE ENCONTRO EL USUARIO CON EL ID QUE SE PASO.");
        }
    }

    public List<Usuario> GetUsuario()
    {
        return context.Usuario.ToList();
    }

    public Visita GetUsuarioById(int id)
    {
        return context.Usuario.Find(id);
    }
}
}
