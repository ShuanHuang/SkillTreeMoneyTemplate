using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyTemplate.Models;
using System.Data.Entity;

namespace MoneyTemplate.Service {
    public class MoneyTemplateService {
        private readonly SkillTreeHomeworkEntities _db;
        public MoneyTemplateService() {
            _db = new SkillTreeHomeworkEntities();
        }
        public IEnumerable<AccountBook> AccountBookSelect(int? top = null) {
            return top == null ? _db.AccountBook.ToList() : _db.AccountBook.Take(top.Value).ToList();
        }
        public void Add(AccountBook data) {
            _db.AccountBook.Add(data);
        }
        public void Edit(AccountBook pageData, AccountBook oldData) {
            oldData.Categoryyy = pageData.Categoryyy;
            oldData.Amounttt = pageData.Amounttt;
            oldData.Dateee = pageData.Dateee;
        }
        public void Delete(AccountBook data) {
            _db.AccountBook.Remove(data);
        }
        public void SaveToDB() {
            _db.SaveChanges();
        }
    }
}