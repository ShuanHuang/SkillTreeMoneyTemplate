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
        public ActionResult AccountDataPage() {
            var myViewModel = new List<AccountDataViewModel>();

            myViewModel.AddRange(_moneyTemplateService.AccountBookSelect()
                .Select(w =>
                new AccountDataViewModel {
                    DateTime = w.Dateee, Money = string.Format("${0:N0}", w.Amounttt), AccountType = (AccountTypeEnum)w.Categoryyy
                }).ToList());
            return View(myViewModel.OrderByDescending(w => w.DateTime).ThenBy(w => w.AccountType).ThenBy(w => w.Money).ToList());
            //UnitOfWork
            _moneyTemplateService.Add(new AccountBook { Dateee = System.DateTime.Now, Categoryyy = 0, Amounttt = 200 });
            _logService.AddLog(new AccountBook { Dateee = System.DateTime.Now, Categoryyy = 0, Amounttt = 200 });
            _unitOfWork.Commit();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}