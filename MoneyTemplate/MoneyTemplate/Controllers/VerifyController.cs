using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTemplate.Controllers {
    public class VerifyController : Controller {
        // GET: Verify
        public ActionResult Index() {
            return View();
        }
        public ActionResult VerifyDate(DateTime date) {
            var isValid = true;
            try {
                if (date > DateTime.Now) {
                    isValid = false;
                }
            } catch (Exception ex) {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(isValid, JsonRequestBehavior.AllowGet);
        }
    }
}