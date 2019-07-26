using MoneyTemplate.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTemplate.Models {
    public class AccountDataViewModel {
        public Guid Id { get; set; }
        [Required]
        public AccountTypeEnum AccountType { get; set; }
        [RemoteDoublePlus("VerifyDate", "Home", "", ErrorMessage = "「日期」不得大於今天")]
        //[Remote("VerifyDate", "Home", "", ErrorMessage = "「日期」不得大於今天")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateTime { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "「金額」只能輸入正整數")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int Money { get; set; }
        [StringLength(100, MinimumLength = 0, ErrorMessage = "「備註」最多輸入100個字元")]
        public string Remark { get; set; }
        public AccountDataViewModel() {
            Id = Guid.NewGuid();
        }
    }
}