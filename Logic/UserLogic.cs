using Data;
using Enities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public class UserLogic
    {
        private readonly UserData userData = new UserData();

        public List<User> GetList()
        {
            return userData.GetList();
        }

        public void Add(User user) {
            Validation(user);
            if (userData.ExistsByEmail(user.Email))
            {
                throw new ValidationException("Ya existe un usuario con el mismo correo electrónico.");
            }
            user.Password = Resources.ConvertSha256("contraseña");
            userData.Add(user); 
        }

        public void Delete(int id)
        {
            try
            {
                userData.Delete(id);
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException.InnerException;
                if (innerException != null && innerException.Message.Contains("FK_"))
                {
                    var match = System.Text.RegularExpressions.Regex.Match(innerException.Message, @"(?<=tabla ')([^']*)");
                    if (match.Success)
                    {
                        string tableName = match.Value;
                        throw new Exception($"No se puede eliminar el usuario porque está relacionado con la tabla {tableName}.");
                    }
                }
                throw new Exception("No se ha podido eliminar el usuario.");
            }

        }
        public void Update(User user)
        {
            Validation(user);
            userData.Update(user);
        }

        public class ValidationException : Exception
        {
            public ValidationException(string message) : base(message)
            {
            }
        }
        private static void Validation(User user)
        {
            if (user == null) throw new ValidationException("El usuario no puede ser nulo.");
            if (string.IsNullOrEmpty(user.Firstname) || string.IsNullOrWhiteSpace(user.Firstname)) throw new ValidationException("El campo Nombre del usuario no puede estar vacío.");
            if (string.IsNullOrEmpty(user.Lastname) || string.IsNullOrWhiteSpace(user.Lastname)) throw new ValidationException("El campo Apellido del usuario no puede estar vacío.");
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrWhiteSpace(user.Email)) throw new ValidationException("El campo Email del usuario no puede estar vacío.");
            if (user.Firstname.Length > 100) throw new ValidationException("El límite del campo Nombre de Usuario es de 100 caracteres.");
            if (user.Lastname.Length > 100) throw new ValidationException("El límite del campo Apellido de Usuario es de 100 caracteres.");
            if (user.Email.Length > 150) throw new ValidationException("El límite del campo Email de Usuario es de 150 caracteres.");
        }

    }
}
