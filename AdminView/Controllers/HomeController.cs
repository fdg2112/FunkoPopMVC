using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Enities;
using Logic;

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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
            return Json(new { result = userController }, JsonRequestBehavior.AllowGet);
        }
    }
}