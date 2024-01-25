using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Enities;
using Logic;
using static Logic.UserLogic;

namespace AdminView.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetUsersList()
        {
            List<User> oList = new UserLogic().GetList();

            return Json(new { data = oList } , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddUser(User userController)
        {
            try
            {
                if (userController.IdUser == 0) new UserLogic().Add(userController);
                else new UserLogic().Update(userController);
                return Json(new { result = userController });
            }
            catch (ValidationException ex)
            {
                Response.StatusCode = 400; // Bad Request
                return Json(new { error = ex.Message });
            }
            catch (Exception)
            {
                Response.StatusCode = 500; // Internal Server Error
                return Json(new { error = "Ha ocurrido un error al intentar agregar el usuario." });
            }
        }

        [HttpPost]
        public JsonResult DeleteUser(int id)
        {
            try
            {
                bool response = false;
                response = new UserLogic().Delete(id);
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
                return Json(new { error = "Ha ocurrido un error al intentar agregar el usuario." });
            }
        }

    }
}