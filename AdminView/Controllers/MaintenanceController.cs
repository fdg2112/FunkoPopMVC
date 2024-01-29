using Enities;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
                List<Product> oList = new ProductLogic().GetList();
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