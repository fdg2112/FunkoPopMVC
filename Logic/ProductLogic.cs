using Data;
using Enities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using Firebase.Storage;
using System.IO;
using System.Threading.Tasks;

namespace Logic
{
    public class ProductLogic
    {
        private readonly ProductData productData = new ProductData();
        private readonly FirebaseStorage firebaseStorage = new FirebaseStorage("funkopop-imgs.appspot.com");

        public List<Product> GetList()
        {
            return productData.GetList();
        }

        public List<Product> GetListWithCollectionInfo()
        {
            return productData.GetListWithCollectionInfo();
        }

        public void Add(Product product)
        {
            Validation(product);
            productData.Add(product);
        }
        public void AddImage(Product product)
        {
            productData.AddImage(product);
        }
        public async Task<string> UploadImage(Stream imageStream, string fileName)
        {
            var imageUrl = await firebaseStorage
                .Child("images")
                .Child(fileName)
                .PutAsync(imageStream);

            return imageUrl;
        }

        public bool Delete(int id)
        {
            try
            {
                return productData.Delete(id);
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
        public void Update(Product product)
        {
            Validation(product);
            productData.Update(product);
        }

        public class ValidationException : Exception
        {
            public ValidationException(string message) : base(message)
            {
            }
        }

        private static void Validation(Product product)
        {
            if (product == null) throw new ValidationException("El usuario no puede ser nulo.");
            if (string.IsNullOrEmpty(product.Name) || string.IsNullOrWhiteSpace(product.Name)) throw new ValidationException("El campo Nombre del usuario no puede estar vacío.");
            if (string.IsNullOrEmpty(product.Description) || string.IsNullOrWhiteSpace(product.Description)) throw new ValidationException("El campo Apellido del usuario no puede estar vacío.");
            if (product.Name.Length > 100) throw new ValidationException("El límite del campo Nombre de Usuario es de 100 caracteres.");
            if (product.Description.Length > 100) throw new ValidationException("El límite del campo Apellido de Usuario es de 100 caracteres.");
        }
    }
}
