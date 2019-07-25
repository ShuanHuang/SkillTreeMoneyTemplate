using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MoneyTemplate.Models {
    public enum AccountTypeEnum {
        [Description("收入")]
        income =0,
        [Description("支出")]
        expenditure =1
    }
}