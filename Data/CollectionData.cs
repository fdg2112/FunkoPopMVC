using Enities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CollectionData
    {
        protected FunkoPopContext _context;
        public CollectionData()
        {
            _context = new FunkoPopContext();
        }
        public List<Collection> GetList()
        {
            try
            {
                return _context.Collection.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de colecciones.", ex);
            }
        }

        public void Add(Collection collection)
        {
            try
            {
                _context.Collection.Add(collection);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al intentar agregar la colección. " + ex.Message);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var elementToRemove = _context.Collection.Find(id) ?? throw new Exception($"La colección con ID {id} no existe.");
                _context.Collection.Remove(elementToRemove);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido eliminar la colección. {ex.Message}");
            }
        }

        public void Update(Collection collection)
        {
            try
            {
                var existingCollection = _context.Collection.FirstOrDefault(u => u.IdCollection == collection.IdCollection) ?? throw new ArgumentException("La colección no existe en la base de datos.", nameof(collection.IdCollection));
                existingCollection.Name = collection.Name;
                existingCollection.Description = collection.Description;
                existingCollection.Active = collection.Active;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al intentar actualizar la colección. " + ex.Message, ex);
            }
        }
    }
}
