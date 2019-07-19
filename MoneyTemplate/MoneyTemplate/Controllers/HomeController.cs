using MoneyTemplate.Models;
using MoneyTemplate.Repository;
using MoneyTemplate.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            _moneyTemplateService.AccountBookSelect().ToList().ForEach(w => {
                var myAccountData = new AccountDataViewModel { DateTime = w.Dateee.ToString("yyyy-MM-dd"), Money = string.Format("${0:N0}", w.Amounttt) };
                switch (w.Categoryyy) {
                    case 0:
                        myAccountData.AccountType = "收入";
                        break;
                    case 1:
                        myAccountData.AccountType = "支出";
                        break;
                    case 2:
                        myAccountData.AccountType = "其他";
                        break;
                }
                myViewModel.Add(myAccountData);
            });
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