using Enities;
using Logic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using static Logic.CollectionLogic;

namespace AdminView.Controllers
{
    public class MaintenanceController : Controller
    {
        // GET: Maintenance
        public ActionResult Collection()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }

        #region COLLECTION
        [HttpGet]
        public JsonResult GetCollectionsList()
        {
            try
            {
                List<Collection> oList = new CollectionLogic().GetList();
                return Json(new { data = oList }, JsonRequestBehavior.AllowGet);
            }
            catch (ValidationException ex)
            {
                Response.StatusCode = 400; // Bad Request
                return Json(new { error = ex.Message });
            }
            catch (Exception)
            {
                Response.StatusCode = 500; // Internal Server Error
                return Json(new { error = "Ha ocurrido un error al intentar mostrar la colección." });
            }

        }

        [HttpPost]
        public JsonResult AddCollection(Collection collectionController)
        {
            try
            {
                if (collectionController.IdCollection == 0) new CollectionLogic().Add(collectionController);
                else new CollectionLogic().Update(collectionController);
                return Json(new { result = collectionController });
            }
            catch (ValidationException ex)
            {
                Response.StatusCode = 400; // Bad Request
                return Json(new { error = ex.Message });
            }
            catch (Exception)
            {
                Response.StatusCode = 500; // Internal Server Error
                return Json(new { error = "Ha ocurrido un error al intentar agregar la colección." });
            }
        }

        [HttpPost]
        public JsonResult DeleteCollection(int id)
        {
            try
            {
                bool response = false;
                response = new CollectionLogic().Delete(id);
                return Json(new { result = response });
            }
            catch (ValidationException ex)
            {
                Response.StatusCode = 400; // Bad Request
                return Json(new { error = ex.Message });
            }
            catch (Exception)
            {
                Response.StatusCode = 500; // Internal Server Error
                return Json(new { error = "Ha ocurrido un error al intentar borrar la colección." });
            }
        }
        #endregion

        #region PRODUCT
        [HttpGet]
        public JsonResult GetProductsList()
        {
            try
            {
                List<Product> oList = new ProductLogic().GetListWithCollectionInfo();
                return Json(new { data = oList }, JsonRequestBehavior.AllowGet);
            }
            catch (ValidationException ex)
            {
                Response.StatusCode = 400; // Bad Request
                return Json(new { error = ex.Message });
            }
            catch (Exception)
            {
                Response.StatusCode = 500; // Internal Server Error
                return Json(new { error = "Ha ocurrido un error al intentar mostrar la colección." });
            }

        }

        public JsonResult AddProduct(Product productController)
        {
            try
            {
                if (productController.IdProduct == 0) new ProductLogic().Add(productController);
                else new ProductLogic().Update(productController);
                return Json(new { result = productController });
            }
            catch (ValidationException ex)
            {
                Response.StatusCode = 400; // Bad Request
                return Json(new { error = ex.Message });
            }
            catch (Exception)
            {
                Response.StatusCode = 500; // Internal Server Error
                return Json(new { error = "Ha ocurrido un error al intentar agregar la colección." });
            }
        }

        [HttpPost]
        public async Task<JsonResult> AddProductImage(Product productController, HttpPostedFileBase imageFile)
        {
            try
            {
                if (productController.IdProduct != 0 && imageFile != null)
                {
                    var imageStream = imageFile.InputStream;

                    // Genera un nombre único para la imagen (puedes ajustarlo según tus necesidades)
                    var imageName = $"{Guid.NewGuid()}.png";

                    // Sube la imagen a Firebase Storage
                    var imageUrl = await new ProductLogic().UploadImage(imageStream, imageName);

                    // Actualiza la URL de la imagen en la base de datos
                    productController.Url_image = imageUrl;

                    // Llama al método para agregar la imagen en la lógica
                    new ProductLogic().AddImage(productController);
                }

                return Json(new { result = productController });
            }
            catch (ValidationException ex)
            {
                Response.StatusCode = 400; // Bad Request
                return Json(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500; // Internal Server Error
                return Json(new { error = $"Ha ocurrido un error: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<JsonResult> AddProductWithImage(string productController, HttpPostedFileBase imageFile)
        {
            try
            {
                // Deserializa el objeto JSON del producto
                Product oProduct = JsonConvert.DeserializeObject<Product>(productController);

                // Valida el formato del precio
                if (!decimal.TryParse(oProduct.PriceText, NumberStyles.AllowDecimalPoint, new CultureInfo("es-AR"), out decimal price))
                {
                    return Json(new { successfulOperation = false, error = "El formato del precio debe ser ###.##" });
                }

                oProduct.Price = price;

                // Guarda el producto en la base de datos
                if (oProduct.IdProduct == 0)
                {
                    new ProductLogic().Add(oProduct);
                }
                else
                {
                    new ProductLogic().Update(oProduct);
                }

                // Sube la imagen si existe y actualiza la URL en el objeto del producto
                if (imageFile != null)
                {
                    var imageUrl = await UploadProductImage(oProduct, imageFile);
                    oProduct.Url_image = imageUrl;
                }

                return Json(new { result = oProduct });
            }
            catch (ValidationException ex)
            {
                Response.StatusCode = 400; // Bad Request
                return Json(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500; // Internal Server Error
                return Json(new { error = $"Ha ocurrido un error: {ex.Message}" });
            }
        }

        private async Task<string> UploadProductImage(Product product, HttpPostedFileBase imageFile)
        {
            try
            {
                var imageStream = imageFile.InputStream;

                // Genera un nombre único para la imagen (puedes ajustarlo según tus necesidades)
                var imageName = $"{Guid.NewGuid()}.png";

                // Sube la imagen a Firebase Storage y devuelve la URL
                var imageUrl = await new ProductLogic().UploadImage(imageStream, imageName);

                return imageUrl;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al subir la imagen del producto: {ex.Message}");
            }
        }


        [HttpPost]
        public JsonResult DeleteProduct(int id)
        {
            try
            {
                bool response = false;
                response = new ProductLogic().Delete(id);
                return Json(new { result = response });
            }
            catch (ValidationException ex)
            {
                Response.StatusCode = 400; // Bad Request
                return Json(new { error = ex.Message });
            }
            catch (Exception)
            {
                Response.StatusCode = 500; // Internal Server Error
                return Json(new { error = "Ha ocurrido un error al intentar borrar la colección." });
            }
        }
        #endregion
    }
}