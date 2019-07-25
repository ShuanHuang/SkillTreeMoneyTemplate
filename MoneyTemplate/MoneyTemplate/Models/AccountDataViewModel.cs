using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyTemplate.Models {
    public class AccountDataViewModel {
        public AccountTypeEnum AccountType { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateTime { get; set; }
        public string Money { get; set; }
    }
}