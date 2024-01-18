using Enities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public class UserLogic:BaseLogic
    {
        public UserLogic() { }

        public User Get(int id)
        {
            try
            {
                return _context.User.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario.", ex);
            }
        }
        public List<User> GetList()
        {
            try
            {
                return _context.User.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de usuarios.", ex);
            }
        }

        public bool Finded(int id)
        {
            if (_context.User.Find(id) != null) return true;
            else return false;
        }

        //public void Add(USER user)
        //{
        //    try
        //    {
        //        if (user == null) throw new ArgumentNullException(nameof(user), "El usuario no puede ser nulo.");
        //        if (string.IsNullOrEmpty(user.Firstname)) throw new ArgumentException("El campo Nombre del usuario no puede estar vacío.", nameof(user.Firstname));
        //        if (string.IsNullOrEmpty(user.Lastname)) throw new ArgumentException("El campo Apellido del usuario no puede estar vacío.", nameof(user.Lastname));
        //        if (string.IsNullOrEmpty(user.Email)) throw new ArgumentException("El campo Email del usuario no puede estar vacío.", nameof(user.Email));
        //        if (user.Firstname.Length > 255) throw new ArgumentException("El límite del campo Nombre de Usuario es de 255 caracteres.", nameof(user.Firstname));
        //        if (user.Lastname.Length > 255) throw new ArgumentException("El límite del campo Apellido de Usuario es de 255 caracteres.", nameof(user.Lastname));
        //        if (user.Email.Length > 45) throw new ArgumentException("El límite del campo Email de Usuario es de 45 caracteres.", nameof(user.Email));
        //        if (user.Phone != null && user.Phone.Length > 20) throw new ArgumentException("El límite del campo Teléfono de Usuario es de 20 caracteres.", nameof(user.Phone));
        //        if (string.IsNullOrEmpty(user.Role)) throw new ArgumentException("No se especificó el rol del usuario.", nameof(user.Role));
        //        _context.USER.Add(user);
        //        _context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Ha ocurrido un error al intentar agregar el usuario. " + ex.Message);
        //    }
        //}

        //public void Delete(int id)
        //{
        //    try
        //    {
        //        var elementToRemove = _context.USER.Find(id) ?? throw new Exception($"El usuario con ID {id} no existe.");
        //        _context.USER.Remove(elementToRemove);
        //        _context.SaveChanges();
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        var innerException = ex.InnerException.InnerException;
        //        if (innerException != null && innerException.Message.Contains("FK_"))
        //        {
        //            var match = System.Text.RegularExpressions.Regex.Match(innerException.Message, @"(?<=tabla ')([^']*)");
        //            if (match.Success)
        //            {
        //                string tableName = match.Value;
        //                throw new Exception($"No se puede eliminar el usuario porque está relacionado con la tabla {tableName}.");
        //            }
        //        }
        //        throw new Exception("No se ha podido eliminar el usuario.");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"No se ha podido eliminar el usuario. {ex.Message}");
        //    }
        //}

        //public void Update(USER user)
        //{
        //    try
        //    {
        //        if (user == null) throw new ArgumentNullException(nameof(user), "El usuario no puede ser nulo.");
        //        var existingUser = _context.USER.FirstOrDefault(u => u.Id == user.Id) ?? throw new ArgumentException("El usuario no existe en la base de datos.", nameof(user.Id));
        //        existingUser.Firstname = user.Firstname;
        //        existingUser.Lastname = user.Lastname;
        //        existingUser.Email = user.Email;
        //        existingUser.Phone = user.Phone;
        //        existingUser.Role = user.Role;
        //        existingUser.Active = user.Active;
        //        _context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Ha ocurrido un error al intentar actualizar el usuario. " + ex.Message, ex);
        //    }
        //}

        //public USER GetUserByEmail(string email)
        //{
        //    try
        //    {
        //        return _context.USER.FirstOrDefault(user => user.Email == email);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error al obtener el usuario.", ex);
        //    }
        //}
    }
}
