﻿using Enities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserData
    {
        protected FunkoPopContext _context;
        public UserData()
        {
            _context = new FunkoPopContext();
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

        public void Add(User user)
        {
            try
            {
                _context.User.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al intentar agregar el usuario. " + ex.Message);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var elementToRemove = _context.User.Find(id) ?? throw new Exception($"El usuario con ID {id} no existe.");
                _context.User.Remove(elementToRemove);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido eliminar el usuario. {ex.Message}");
            }
        }

        public void Update(User user)
        {
            try
            {
                var existingUser = _context.User.FirstOrDefault(u => u.IdUser == user.IdUser) ?? throw new ArgumentException("El usuario no existe en la base de datos.", nameof(user.IdUser));
                existingUser.Firstname = user.Firstname;
                existingUser.Lastname = user.Lastname;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                existingUser.Active = user.Active;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al intentar actualizar el usuario. " + ex.Message, ex);
            }
        }

        public bool ExistsByEmail(string email)
        {
            return _context.User.Any(u => u.Email == email);
        }
    }
}
