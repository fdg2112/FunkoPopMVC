using Enities;
using Logic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

        [HttpPost]
        public async Task<JsonResult> AddProduct(string productController, HttpPostedFileBase fileImage)
        {
            bool successfulOperation = true;
            Product oProduct = JsonConvert.DeserializeObject<Product>(productController);
            try
            {
                if (decimal.TryParse(oProduct.PriceText, NumberStyles.AllowDecimalPoint, new CultureInfo("es-AR"), out decimal price)) oProduct.Price = price;
                else return Json(new { successfulOperation = false }, JsonRequestBehavior.AllowGet);
                if (oProduct.IdProduct == 0)
                {
                    try
                    {
                        new ProductLogic().Add(oProduct);
                    }
                    catch (Exception)
                    {
                        successfulOperation = false;
                    }

                }
                else try
                    {
                        new ProductLogic().Update(oProduct);
                    }
                    catch (Exception)
                    {
                        successfulOperation = false;
                    }

                if (successfulOperation)
                {
                    if (fileImage != null)
                    {
                        try
                        {
                            // Llama al método para agregar la imagen en la lógica
                            await AddProductImage(oProduct, fileImage);
                        }
                        catch (ValidationException ex)
                        {
                            // Maneja la excepción de validación
                            Response.StatusCode = 400; // Bad Request
                            return Json(new { error = ex.Message });
                        }
                        catch (Exception ex)
                        {
                            // Maneja otras excepciones
                            Response.StatusCode = 500; // Internal Server Error
                            return Json(new { error = $"Ha ocurrido un error al intentar agregar la imagen: {ex.Message}" });
                        }
                    }
                }

                return Json(new { result = oProduct });
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
        public async Task<JsonResult> AddProductImage(Product productController, HttpPostedFileBase fileImage)
        {
            try
            {
                if (productController.IdProduct != 0 && fileImage != null)
                {
                    var imageStream = fileImage.InputStream;

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