using Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductData
    {
        protected FunkoPopContext _context;
        public ProductData()
        {
            _context = new FunkoPopContext();
        }
        public List<Product> GetList()
        {
            try
            {
                return _context.Product.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de productos.", ex);
            }
        }

        public void Add(Product product)
        {
            try
            {
                _context.Product.Add(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al intentar agregar el producto. " + ex.Message);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var elementToRemove = _context.Product.Find(id) ?? throw new Exception($"El producto con ID {id} no existe.");
                _context.Product.Remove(elementToRemove);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"No se ha podido eliminar el producto. {ex.Message}");
            }
        }

        public void Update(Product product)
        {
            try
            {
                var existingProduct = _context.Product.FirstOrDefault(u => u.IdProduct == product.IdProduct) ?? throw new ArgumentException("El producto no existe en la base de datos.", nameof(product.IdProduct));
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.IdCollection = product.IdCollection;
                existingProduct.Price = product.Price;
                existingProduct.Stock = product.Stock;
                existingProduct.Shine = product.Shine;
                existingProduct.Active = product.Active;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al intentar actualizar el producto. " + ex.Message, ex);
            }
        }
    }
}