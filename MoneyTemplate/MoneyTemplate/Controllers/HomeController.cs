using MoneyTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTemplate.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }
        public ActionResult AccountDataPage() {
            //load data
            var RamdomSource = Enumerable.Range(1, 1000).OrderBy(x => x * new Random().Next()).ToList();
            var returnData = new List<AccountDataViewModel>();
            for (int i = 0; i < 100; i++) {
                var myAccountData = new AccountDataViewModel();
                var myRamdom = RamdomSource[i];
                switch (myRamdom % 3) {
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

                myAccountData.DateTime = DateTime.Now.AddMonths(-(myRamdom % 13)).AddDays(-(myRamdom % 30)).ToString("yyyy-MM-dd");
                var MoneyStr = string.Format("${0:N0}", myRamdom * myRamdom * 0.01);
                myAccountData.Money = MoneyStr == "$0" ? "$150" : MoneyStr;
                returnData.Add(myAccountData);
            }
            return View(returnData.OrderByDescending(w => w.DateTime).ThenBy(w => w.AccountType).ThenBy(w => w.Money).ToList());
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