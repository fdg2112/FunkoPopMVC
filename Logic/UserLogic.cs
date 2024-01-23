using Data;
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
    public class UserLogic
    {
        private readonly UserData objUser = new UserData();

        public List<User> GetList()
        {
            return objUser.GetList();
        }

        public void Add(User user) {
            Validation(user); 
            objUser.Add(user); 
        }

        public void Delete(int id) => objUser.Delete(id);

        public void Update(User user)
        {
            Validation(user);
            objUser.Update(user);
        }

        private static void Validation(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user), "El usuario no puede ser nulo.");
            if (string.IsNullOrEmpty(user.Firstname) || string.IsNullOrWhiteSpace(user.Firstname)) throw new ArgumentException("El campo Nombre del usuario no puede estar vacío.", nameof(user.Firstname));
            if (string.IsNullOrEmpty(user.Lastname) || string.IsNullOrWhiteSpace(user.Lastname)) throw new ArgumentException("El campo Apellido del usuario no puede estar vacío.", nameof(user.Lastname));
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrWhiteSpace(user.Email)) throw new ArgumentException("El campo Email del usuario no puede estar vacío.", nameof(user.Email));
            if (string.IsNullOrEmpty(user.Password) || string.IsNullOrWhiteSpace(user.Password)) throw new ArgumentException("El campo Contraseña del usuario no puede estar vacío.", nameof(user.Email));
            if (user.Firstname.Length > 100) throw new ArgumentException("El límite del campo Nombre de Usuario es de 100 caracteres.", nameof(user.Firstname));
            if (user.Lastname.Length > 100) throw new ArgumentException("El límite del campo Apellido de Usuario es de 100 caracteres.", nameof(user.Lastname));
            if (user.Email.Length > 150) throw new ArgumentException("El límite del campo Email de Usuario es de 150 caracteres.", nameof(user.Email));
        }
    }
}
