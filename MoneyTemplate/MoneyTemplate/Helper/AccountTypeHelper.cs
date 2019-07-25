using MoneyTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTemplate.Helper {
    public static class AccountTypeHelper {
        public static HtmlString DisplayAccountTypeColor(this HtmlHelper htmlHelper, AccountTypeEnum AccountType) {
            var className = "";
            switch (AccountType) {
                case AccountTypeEnum.income:
                    className = "text-primary";
                    break;
                case AccountTypeEnum.expenditure:
                    className = "text-danger";
                    break;
                default:
                    break;
            }
            return MvcHtmlString.Create($"<span class='{className}'>{AccountType.GetEnumDescription()}</span>");
        }
    }
}