using Data;
using Enities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic
{
    public class CollectionLogic
    {
        private readonly CollectionData collectionData = new CollectionData();

        public List<Collection> GetList()
        {
            return collectionData.GetList();
        }

        public void Add(Collection collection)
        {
            Validation(collection);
            collectionData.Add(collection);
        }

        public bool Delete(int id)
        {
            try
            {
                return collectionData.Delete(id);
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
                        throw new Exception($"No se puede eliminar la colección porque está relacionado con la tabla {tableName}.");
                    }
                }
                throw new Exception("No se ha podido eliminar la colección.");
            }

        }
        public void Update(Collection collection)
        {
            Validation(collection);
            collectionData.Update(collection);
        }

        public class ValidationException : Exception
        {
            public ValidationException(string message) : base(message)
            {
            }
        }

        private static void Validation(Collection collection)
        {
            if (collection == null) throw new ValidationException("La colección no puede ser nulo.");
            if (string.IsNullOrEmpty(collection.Name) || string.IsNullOrWhiteSpace(collection.Name)) throw new ValidationException("El campo Nombre de la colección no puede estar vacío.");
            if (string.IsNullOrEmpty(collection.Description) || string.IsNullOrWhiteSpace(collection.Description)) throw new ValidationException("El campo Descripción de la colección no puede estar vacío.");
            if (collection.Name.Length > 100) throw new ValidationException("El límite del campo Nombre de la colección es de 100 caracteres.");
            if (collection.Description.Length > 500) throw new ValidationException("El límite del campo Descripción de la colección es de 500 caracteres.");
        }

    }
}
