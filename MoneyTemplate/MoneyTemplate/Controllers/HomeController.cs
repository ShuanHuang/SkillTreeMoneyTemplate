using MoneyTemplate.Models;
using MoneyTemplate.Repository;
using MoneyTemplate.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MoneyTemplate.EnumDescription;

namespace MoneyTemplate.Controllers {
    public class HomeController : Controller {
        private readonly MoneyTemplateService _moneyTemplateService;
        private readonly LogService _logService;
        private readonly UnitOfWork _unitOfWork;
        public HomeController() {
            _unitOfWork = new UnitOfWork();
            _moneyTemplateService = new MoneyTemplateService(_unitOfWork);
            _logService = new LogService(_unitOfWork);

        }
        public ActionResult Index() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AccountDataViewModel data) {
            if (ModelState.IsValid) {
                //UnitOfWork
                _moneyTemplateService.Add(new AccountBook { Id = data.Id, Dateee = data.DateTime, Categoryyy = (int)data.AccountType, Amounttt = data.Money, Remarkkk = $"{data.Remark}" });
                //_logService.AddLog(new AccountBook { Dateee = System.DateTime.Now, Categoryyy = 0, Amounttt = 200 });
                _unitOfWork.Commit();
                ModelState.AddModelError("", "新增成功");
                return View();
            } else {
                ModelState.AddModelError("", "新增失敗");
                return View(data);
            }
        }
        public ActionResult AjaxIndex() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxIndex(AccountDataViewModel data) {
            if (ModelState.IsValid) {
                //UnitOfWork
                _moneyTemplateService.Add(new AccountBook { Id = data.Id, Dateee = data.DateTime, Categoryyy = (int)data.AccountType, Amounttt = data.Money, Remarkkk = $"{data.Remark}" });
                //_logService.AddLog(new AccountBook { Dateee = System.DateTime.Now, Categoryyy = 0, Amounttt = 200 });
                _unitOfWork.Commit();
                ModelState.AddModelError("", "新增成功");
                return View();
            } else {
                ModelState.AddModelError("", "新增失敗");
                return View(data);
            }
        }
        public ActionResult AccountDataPage() {
            var myViewModel = new List<AccountDataViewModel>();

            myViewModel.AddRange(_moneyTemplateService.AccountBookSelect()
                .Select(w =>
                new AccountDataViewModel {
                    DateTime = w.Dateee, Money = w.Amounttt, AccountType = (AccountTypeEnum)w.Categoryyy
                }).ToList());
            return View(myViewModel.OrderByDescending(w => w.DateTime).ThenBy(w => w.AccountType).ThenBy(w => w.Money).ToList());

        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult VerifyDate(DateTime dateTime) {
            var isValid = true;
            try {
                if (dateTime.Date > DateTime.Now.Date) {
                    isValid = false;
                }
            } catch (Exception ex) {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(isValid, JsonRequestBehavior.AllowGet);
        }

    }
}